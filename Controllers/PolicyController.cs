using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using SuperFormulaRestAPI.BusinessLogic;
using SuperFormulaRestAPI.BusinessLogic.Services;
using SuperFormulaRestAPI.Data;
using SuperFormulaRestAPI.Helpers;
using SuperFormulaRestAPI.Models;
using System.Linq.Expressions;

namespace SuperFormulaRestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PolicyController : ControllerBase
    {
        private IPolicyValidator _policyValidator;
        private IEventBusService _eventBusService;
        private readonly DatabaseContext _db;
        private enum SortOrder{
            asc,
            desc
        }

        public PolicyController(DatabaseContext db)
        {
            _db = db;
            _policyValidator = new PolicyValidatorRepository();
            _eventBusService = new EventBusService();
        }

        [Route("/create")]
        [HttpPost]
        public async Task<IActionResult> CreatePolicy([BindRequired] Payload pl)
        {
            var trans = _db.Database.BeginTransaction();
            if (ModelState.IsValid)
            {
                try
                {
                    var stateValidation = _policyValidator.ValidateStateRegulations(pl);
                    Guid? memId = null;
                    if (stateValidation.IsSuccess)
                    {
                        bool memberExists = _db.Members.Any(x => x.DriverLicenseNumber.ToLower() == pl.DriverLicenseNumber.ToLower() && x.FirstName.ToLower() == pl.FirstName.ToLower() && x.LastName.ToLower() == pl.LastName.ToLower());
                        if (!memberExists)
                        {
                            SuperFormulaRestAPI.Data.Entities.Member member = new SuperFormulaRestAPI.Data.Entities.Member()
                            {
                                FirstName = pl.FirstName,
                                LastName = pl.LastName,
                                DriverLicenseNumber = pl.DriverLicenseNumber,
                                Address = pl.FullAddress
                            };
                            await _db.Members.AddAsync(member);
                            await _db.SaveChangesAsync();
                            memId = member.MemberId;
                        }

                        SuperFormulaRestAPI.Data.Entities.Policy policy = new SuperFormulaRestAPI.Data.Entities.Policy()
                        {
                            CreateDate = DateTime.Now,
                            EffectiveDate = pl.EffectiveDate,
                            VehicleManufacturer = pl.VehicleManufacturer,
                            VehicleModel = pl.VehicleModel,
                            VehicleName = pl.VehicleName,
                            VehicleYear = pl.VehicleYear,
                            ExpirationDate = pl.ExpirationDate,
                            Premium = pl.Premium,
                        };
                        if (memberExists)
                        {
                            Guid existingMemId = _db.Members.Where(x => x.DriverLicenseNumber == pl.DriverLicenseNumber).Select(y => y.MemberId).FirstOrDefault();
                            policy.MemberId = existingMemId;
                        }
                        if (memId != null)
                            policy.MemberId = (Guid)memId;
                        await _db.Policies.AddAsync(policy);
                        await _db.SaveChangesAsync();
                        trans.Commit();

                        //Fire and forget send message to event bus
                        _= _eventBusService.SendMessageAsync("This is Event Bus Message to Send", 3);
                        return Ok("Policy Created");
                    }
                    else
                    {
                        return BadRequest(stateValidation);
                    }
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    return Problem(ex.Message);
                }
            }
            else
                return BadRequest();
        }

        [Route("/dl/getpolicy/{dlNum}")]
        [HttpGet]
        public async Task<IActionResult> GetPolicyByDriverLicense([BindRequired] string dlNum, string? sort = null, bool? includeExpired = false )
        {
            if (ModelState.IsValid)
            {
                try
                {
                    bool sortAscending = true;
                    if (sort != null && (sort.ToLower() == "asc" || sort.ToLower().Contains("asc")))
                        sortAscending = true;
                    if (sort != null && (sort.ToLower() == "desc" || sort.ToLower().Contains("desc")))
                        sortAscending = false;
                    USAddress.AddressParser parser = new USAddress.AddressParser();
                    var result = await (from p in _db.Policies
                                        join m in _db.Members
                                        on p.MemberId equals m.MemberId
                                        where m.DriverLicenseNumber == dlNum
                                        select new Payload
                                        {
                                            FirstName = m.FirstName,
                                            LastName = m.LastName,
                                            DriverLicenseNumber = m.DriverLicenseNumber,
                                            MemberId = m.MemberId,
                                            StreetAddress = parser.ParseAddress(m.Address).StreetLine,
                                            City = parser.ParseAddress(m.Address).City,
                                            State = parser.ParseAddress(m.Address).State,
                                            Zip = parser.ParseAddress(m.Address).Zip,
                                            PolicyNumber = p.PolicyId,
                                            VehicleManufacturer = p.VehicleManufacturer,
                                            VehicleModel = p.VehicleModel,
                                            VehicleYear = p.VehicleYear,
                                            VehicleName = p.VehicleName,
                                            Premium = p.Premium,
                                            EffectiveDate = p.EffectiveDate,
                                            ExpirationDate = p.ExpirationDate
                                        }).AsQueryable().OrderByPropertyName("VehicleYear",sortAscending).ToListAsync();
                    bool includeExpiredPolicy = (bool)includeExpired;
                    if (!includeExpiredPolicy)
                        result = result.Where(x => x.PolicyExpired == includeExpired).ToList();
                    
                    if (result != null)
                        return Ok(result);
                    return NotFound("Could not find matching driver license");
                }
                catch(Exception ex)
                {
                    return Problem(ex.Message);
                }
            }
            else
                return BadRequest();
        }

        [Route("/pl/getpolicy")]
        [HttpGet]
        public async Task<IActionResult> GetPolicyByPolicyId([BindRequired] Guid policyId, [BindRequired] string dlNum)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var dlNumExists = _db.Members.Where(x => x.DriverLicenseNumber == dlNum).Any();
                    if (dlNumExists)
                    {
                        var result = await (from p in _db.Policies
                                            join m in _db.Members
                                            on p.MemberId equals m.MemberId
                                            where p.PolicyId == policyId
                                            select new Payload
                                            {
                                                FirstName = m.FirstName,
                                                LastName = m.LastName,
                                                DriverLicenseNumber = m.DriverLicenseNumber,
                                                MemberId = m.MemberId,
                                                FullAddress = m.Address,
                                                PolicyNumber = p.PolicyId,
                                                VehicleManufacturer = p.VehicleManufacturer,
                                                VehicleModel = p.VehicleModel,
                                                VehicleYear = p.VehicleYear,
                                                VehicleName = p.VehicleName,
                                                Premium = p.Premium,
                                                EffectiveDate = p.EffectiveDate,
                                                ExpirationDate = p.ExpirationDate
                                            }).FirstOrDefaultAsync();
                        if (result != null)
                            return Ok(result);
                        else
                            return NotFound("Could not find matching policy number");
                    }
                    else
                        return NotFound("Could not find matching driver license");
                }
                catch(Exception ex)
                {
                    return Problem(ex.Message);
                }
            }
            else
                return BadRequest();
        }
    }
}

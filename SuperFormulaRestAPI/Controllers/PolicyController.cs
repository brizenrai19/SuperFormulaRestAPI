using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using SuperFormulaRestAPI.BusinessLogic;
using SuperFormulaRestAPI.BusinessLogic.Services;
using SuperFormulaRestAPI.Data;
using SuperFormulaRestAPI.Data.Entities;
using SuperFormulaRestAPI.Helpers;
using SuperFormulaRestAPI.Models;

namespace SuperFormulaRestAPI.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class PolicyController : ControllerBase
    {
        private USAddress.AddressParser parser = new USAddress.AddressParser();
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

        [Route("create")]
        [HttpPost]
        public async Task<IActionResult> CreatePolicyAsync([BindRequired] Payload pl)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    //State Vaidation returns random success or failure flag
                    var stateValidation = _policyValidator.ValidateStateRegulations(pl);
                    
                    Guid? memId = null;
                    if (stateValidation.IsSuccess)
                    {
                        bool memberExists = await _db.Members.Where(x => x.DriverLicenseNumber.ToLower() == pl.DriverLicenseNumber.ToLower() && x.FirstName.ToLower() == pl.FirstName.ToLower() && x.LastName.ToLower() == pl.LastName.ToLower()).AnyAsync();
                        
                        //if member does not exists create a new member record 
                        if (!memberExists)
                        {
                            Member member = new Member()
                            {
                                FirstName = pl.FirstName,
                                LastName = pl.LastName,
                                DriverLicenseNumber = pl.DriverLicenseNumber,
                                Address = pl.FullAddress
                            };
                            await _db.Members.AddAsync(member);
                            memId = member.MemberId;
                        }

                        Policy policy = new Policy()
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

                        //if member exists associate the policy to the member
                        if (memberExists)
                        {
                            Guid existingMemId = _db.Members.Where(x => x.DriverLicenseNumber == pl.DriverLicenseNumber).Select(y => y.MemberId).FirstOrDefault();
                            policy.MemberId = existingMemId;
                        }

                        if (memId != null)
                            policy.MemberId = (Guid)memId;

                        await _db.Policies.AddAsync(policy);
                        await _db.SaveChangesAsync();

                        //Fire and forget - send message to event bus
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
                    return Problem(ex.Message);
                }
            }
            else
                return BadRequest();
        }

        [Route("getpolicy/{dlNum}")]
        [HttpGet]
        public async Task<IActionResult> GetPolicyByDriverLicenseAsync([BindRequired] string dlNum, string? sort = null, bool? includeExpired = false )
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
                    
                    //Filter only policies that haven't expired if includeExpiredPolicy is true
                    if (!(bool)includeExpired)
                        result = result.Where(x => x.PolicyExpired == false).ToList();
                    
                    //Return OK response if count of list is greater than 0 else return not found 
                    if (result.Count() > 0)
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

        [Route("getpolicy")]
        [HttpGet]
        public async Task<IActionResult> GetPolicyByPolicyIdAsync([BindRequired] Guid policyId, [BindRequired] string dlNum)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    bool dlNumExists = await _db.Members.Where(x => x.DriverLicenseNumber == dlNum).AnyAsync();
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

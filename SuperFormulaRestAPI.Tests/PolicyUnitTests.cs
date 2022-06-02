using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuperFormulaRestAPI.Controllers;
using SuperFormulaRestAPI.Data;
using SuperFormulaRestAPI.Data.Entities;
using SuperFormulaRestAPI.Models;
using SuperFormulaRestAPITests.WebHost.Models;
using SuperFormulaRestAPIUnitTests.MockDB;

namespace SuperFormulaRestAPIUnitTests
{
    public class PolicyUnitTests
    {
        private readonly PolicyController _policyController;
        
        public PolicyUnitTests()
        {
            _policyController = new PolicyController(MockDbContext.GetDatabaseContext().Result);
        }


        #region Unit Tests -> Get Policy by Policy Id
        [Fact]
        public async void GetPolicyByPolicyId_Unit_ReturnOkResponseIfDriverLicenseNumberExists()
        {
            //Arrange
            var policyId = new Guid("97471354-5D3C-4666-98F4-448E238D606F");
            string dlNum = "DL1000002";

            //Act
            var response = await _policyController.GetPolicyByPolicyIdAsync(policyId, dlNum);

            //Assert
            Assert.IsType<OkObjectResult>(response);
        }

        [Fact]
        public async void GetPolicyByPolicyId_Unit_ReturnNotFoundIfDriverLicenseNumberDoesNotExist()
        {
            //Arrange
            var policyId = new Guid();
            string dlNum = "DL100";

            //Act
            var response = await _policyController.GetPolicyByPolicyIdAsync(policyId, dlNum);

            //Assert
            Assert.IsType<NotFoundObjectResult>(response);
        }

        [Fact]
        public async void GetPolicyByPolicyId_Unit_ReturnNotFoundForInvalidPolicyNumber()
        {
            //Arrange
            var policyId = new Guid("9E3C6919-AC82-473A-849A-08DA3ECE4C76");
            string dlNum = "DL1000003";

            //Act
            var response = await _policyController.GetPolicyByPolicyIdAsync(policyId, dlNum);

            //Assert
            Assert.Equal("Could not find matching policy number", (response as ObjectResult)?.Value);
            Assert.IsType<NotFoundObjectResult>(response);
        }

        [Fact]
        public async void GetPolicyByPolicyId_Unit_ReturnBadRequestForInvalidModelState()
        {
            //Arrange
            var policyId = new Guid();
            string dlNum = "";

            //Act
            _policyController.ModelState.AddModelError("Required", "Missing Required Parameters");
            var response = await _policyController.GetPolicyByPolicyIdAsync(policyId, dlNum);

            //Assert
            Assert.IsType<BadRequestResult>(response);
        }
        #endregion

        #region Unit Tests -> Get Policy by Driver License Number
        [Fact]
        public async void GetPolicyByDriverLicense_Unit_ReturnPoliciesForDriverLicenseNumber()
        {
            //Arrange
            string dlNum = "DL1000003";

            //Act            
            var response = await _policyController.GetPolicyByDriverLicenseAsync(dlNum);
            var value = (response as ObjectResult)?.Value;

            //Assert
            Assert.NotNull(response);
            Assert.Equal(200, (response as ObjectResult)?.StatusCode);
            var data = Assert.IsType<List<Payload>>(value);

            //validate specified driver license has two policies from seed data
            Assert.Equal(2, data.Count);
            Assert.IsType<OkObjectResult>(response);
        }

        [Fact]
        public async void GetPolicyByDriverLicense_Unit_ReturnPoliciesAscending()
        {
            //Arrange
            string dlNum = "DL1000003";

            //Act
            var response = await _policyController.GetPolicyByDriverLicenseAsync(dlNum,"asc",true);
            var value = (response as ObjectResult)?.Value;

            //Assert
            Assert.NotNull(response);
            Assert.Equal(200, (response as ObjectResult)?.StatusCode);
            var data = Assert.IsType<List<Payload>>(value);

            //validate ascending order from seed data
            Assert.Equal(1955, data.First().VehicleYear);
            Assert.Equal(1976, data.Last().VehicleYear);
            
            Assert.IsType<OkObjectResult>(response);
        }

        [Fact]
        public async void GetPolicyByDriverLicense_Unit_ReturnPoliciesDescending()
        {
            //Arrange
            string dlNum = "DL1000003";

            //Act
            var response = await _policyController.GetPolicyByDriverLicenseAsync(dlNum, "desc", true);
            var value = (response as ObjectResult)?.Value;

            //Assert
            Assert.NotNull(response);
            Assert.Equal(200, (response as ObjectResult)?.StatusCode);
            var data = Assert.IsType<List<Payload>>(value);

            //validate descending order from seed data
            Assert.Equal(1976, data.First().VehicleYear);
            Assert.Equal(1955, data.Last().VehicleYear);
            
            Assert.IsType<OkObjectResult>(response);
        }

        [Fact]
        public async void GetPolicyByDriverLicense_Unit_ReturnOnlyValidPolicies()
        {
            //Arrange
            string dlNum = "DL1000003";

            //Act
            var response = await _policyController.GetPolicyByDriverLicenseAsync(dlNum,"",false);
            var value = (response as ObjectResult)?.Value;

            //Assert
            Assert.NotNull(response);
            Assert.Equal(200, (response as ObjectResult)?.StatusCode);
            var data = Assert.IsType<List<Payload>>(value);

            Assert.Equal(2,data.Count);
            Assert.IsType<OkObjectResult>(response);
        }

        [Fact]
        public async void GetPolicyByDriverLicense_Unit_ReturnAllPolicies()
        {
            //Arrange
            string dlNum = "DL1000002";

            //Act
            var response = await _policyController.GetPolicyByDriverLicenseAsync(dlNum, "", true);
            var value = (response as ObjectResult)?.Value;

            //Assert
            Assert.NotNull(response);
            Assert.Equal(200, (response as ObjectResult)?.StatusCode);
            var data = Assert.IsType<List<Payload>>(value);

            //validate specified driver license has two policies from seed data
            Assert.Equal(2, data.Count);
            Assert.IsType<OkObjectResult>(response);
        }

        [Fact]
        public async void GetPolicyByDriverLicense_Unit_ReturnBadRequestForInvalidModelState()
        {
            //Arrange
            string dlNum = "";

            //Act
            _policyController.ModelState.AddModelError("Required", "Missing Required Parameters");
            var response = await _policyController.GetPolicyByDriverLicenseAsync(dlNum);

            //Assert
            Assert.IsType<BadRequestResult>(response);
        }

        #endregion

        #region Unit Tests -> Create Policy

        [Fact]
        public async void CreatePolicy_Unit_ReturnBadRequestForInvalidModelState()
        {
            //Arrange
            var payload = new Payload()
            {
                FirstName = "Testfirstname",
                LastName = "Testlastname",
                EffectiveDate = DateTime.Now.AddDays(30),
                DriverLicenseNumber = "DL100004",
                VehicleYear = 1955,
                VehicleManufacturer = "Honda",
                VehicleModel = "CRV",
                VehicleName = "Daily Driver",
                StreetAddress = "450 W Hamton Rd",
                City = "Richmond",
                State = "VA",
                Zip = "23224",
                ExpirationDate = DateTime.Now.AddDays(60),
                Premium = 95.89
            };

            //Act
            //Force Model error on Policy Controller
            _policyController.ModelState.AddModelError("Required", "Missing Required Parameters");
            var response = await _policyController.CreatePolicyAsync(payload);

            //Assert
            Assert.IsType<BadRequestResult>(response);
        }

        [Theory]
        [ClassData(typeof(PayloadTestClass))]
        public async void CreatePolicy_Unit_CreateNewPolicy(List<Payload> payloads)
        {
            //Arrange
            //Possible outcomes for State Validation 
            List<Response> possibleReponses = new()
            {
                new Response
                {
                    IsSuccess = true,
                    Message = "State validation failed due to expired license!"
                },
                new Response
                {
                    IsSuccess = true,
                    Message = "State validation completed successfully!"
                },
                new Response
                {
                    IsSuccess = false,
                    Message = "State validation failed due to missing vehicle registration!"
                }
            };

            foreach(var payload in payloads)
            {
                //Act
                var response = await _policyController.CreatePolicyAsync(payload);
                var value = response as ObjectResult;

                //Assert
                if (value.StatusCode == 200)
                {
                    //Validate Status OK when insert completes
                    Assert.IsType<OkObjectResult>(response);

                    //Validate success response message body
                    Assert.Equal("Policy Created", value.Value);
                }
                else
                {
                    var failedStateValidationResponse = (response as ObjectResult)?.Value as Response;
                    //Valid Reponse if result is any item from possible outcomes for state validation
                    var validResponse = possibleReponses.Any(x => failedStateValidationResponse?.Message == x.Message);
                    
                    //Validate proper State Validation error message
                    Assert.True(validResponse);

                    Assert.IsType<BadRequestObjectResult>(response);
                }
            }            
        }

        #endregion
    }  
}

using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SuperFormulaRestAPI.Controllers;
using SuperFormulaRestAPI.Models;
using SuperFormulaRestAPITests.WebHost;
using SuperFormulaRestAPITests.WebHost.Models;
using SuperFormulaRestAPIUnitTests.MockDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SuperFormulaRestAPIUnitTests
{
    public class PolicyIntegrationTests: IClassFixture<WebAppFactory<Program>>
    {
        private readonly HttpClient _httpClient;
        private readonly string requestUri = "/api/policy";
        public PolicyIntegrationTests(WebAppFactory<Program> webAppFactory)
        {
            _httpClient = webAppFactory.CreateClient();
        }

        #region Integration Tests -> Get Policy by Policy Id
        
        [Theory]
        [InlineData("45E1658F-7530-4AFB-A10D-62862ED124DF", "DL1000001")]
        [InlineData("0F045C1A-244D-4666-86E9-5B1BA088A771", "DL1000002")]
        [InlineData("A533D47B-41DC-43D6-9834-EC0C2E3C39D7", "DL1000003")]
        public async void GetPolicyByPolicyId_Integration_ReturnOkResponseIfDriverLicenseNumberExists(string policyId, string dlNum)
        {
            //Act
            var response = await _httpClient.GetAsync($"{requestUri}/getpolicy?policyId={policyId}&dlNum={dlNum}");
            var policy = JsonConvert.DeserializeObject<Payload>(await response.Content.ReadAsStringAsync());

            //Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);            
            Assert.Equal(dlNum, policy.DriverLicenseNumber);
        }

        [Theory]
        [InlineData("45E1658F-7530-4AFB-A10D-62862ED124DF", "DL1001")]
        [InlineData("0F045C1A-244D-4666-86E9-5B1BA088A771", "DL1002")]
        [InlineData("A533D47B-41DC-43D6-9834-EC0C2E3C39D7", "DL1003")]
        public async void GetPolicyByPolicyId_Integration_ReturnNotFoundIfDriverLicenseNumberDoesNotExist(string policyId, string dlNum)
        {
            //Act
            var response = await _httpClient.GetAsync($"{requestUri}/getpolicy?policyId={policyId}&dlNum={dlNum}");
            var message = await response.Content.ReadAsStringAsync();

            //Assert
            //Validate not found response for invalid driver license numbers
            Assert.Equal(HttpStatusCode.NotFound,response.StatusCode);
            Assert.Equal("Could not find matching driver license",message);
        }

        [Theory]
        [InlineData("9E3C6919-AC82-473A-849A-08DA3ECE4C76", "DL1000001")]
        [InlineData("3F8D7861-8680-4F03-50D1-08DA3ED51A56", "DL1000002")]
        [InlineData("3FF53CD7-B19B-4979-06CF-08DA3ED6E4C9", "DL1000003")]
        public async void GetPolicyByPolicyId_Integration_ReturnNotFoundForInvalidPolicyNumber(string policyId, string dlNum)
        {
            //Act
            var response = await _httpClient.GetAsync($"{requestUri}/getpolicy?policyId={policyId}&dlNum={dlNum}");
            var message = await response.Content.ReadAsStringAsync();

            //Assert
            //Validate not found response for invalid policy numbers
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
            Assert.Equal("Could not find matching policy number", message);
        }

        [Theory]
        [InlineData("45E1658F-7530-4AFB-A10D-62862ED124DF", "")]
        [InlineData("", "DL1002")]
        [InlineData("", "")]
        public async void GetPolicyByPolicyId_Integration_ReturnBadRequestForInvalidModelState(string policyId, string dlNum)
        {
            //Act
            var response = await _httpClient.GetAsync($"{requestUri}/getpolicy?policyId={policyId}&dlNum={dlNum}");
            var message = await response.Content.ReadAsStringAsync();
            var badRequest = JsonConvert.DeserializeObject<CustomBadRequest>(message);

            //Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
            //validate model state error generic response message
            Assert.Equal("One or more validation errors occurred.", badRequest.Title);
        }
        #endregion

        #region Integration Tests -> Get Policies by Driver License Number

        [Theory]
        [InlineData("DL1000001")]
        [InlineData("DL1000002")]
        [InlineData("DL1000003")]
        public async void GetPolicyByDriverLicense_Integration_ReturnPoliciesForDriverLicenseNumber(string dlNum)
        {
            //Act            
            var response = await _httpClient.GetAsync($"{requestUri}/getpolicy/{dlNum}?includeExpired=false");
            var message = await response.Content.ReadAsStringAsync();
            var policies = JsonConvert.DeserializeObject<IEnumerable<Payload>>(message);

            //Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            //validate number of policies for each driver license based on seed/test data
            if (dlNum == "DL1000001")
                Assert.Single(policies);
            if (dlNum == "DL1000002")
                Assert.Equal(2, policies.Count());
            if (dlNum == "DL1000003")
                Assert.Equal(2, policies.Count());
        }

        [Theory]
        [InlineData("DL1000002")]
        [InlineData("DL1000003")]
        public async void GetPolicyByDriverLicense_Integration_ReturnPoliciesAscending(string dlNum)
        {
            //Act            
            var response = await _httpClient.GetAsync($"{requestUri}/getpolicy/{dlNum}?sort=asc&includeExpired=true");
            var message = await response.Content.ReadAsStringAsync();
            var policies = JsonConvert.DeserializeObject<IEnumerable<Payload>>(message);

            //Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            if (dlNum == "DL1000002")
            {
                Assert.Equal(1970, policies.First().VehicleYear);
                Assert.Equal(1972, policies.Last().VehicleYear);
            }
            if (dlNum == "DL1000003")
            {
                Assert.Equal(1955, policies.First().VehicleYear);
                Assert.Equal(1976, policies.Last().VehicleYear);
            }
        }

        [Theory]
        [InlineData("DL1000002")]
        [InlineData("DL1000003")]
        public async void GetPolicyByDriverLicense_Integration_ReturnPoliciesDescending(string dlNum)
        {
            //Act            
            var response = await _httpClient.GetAsync($"{requestUri}/getpolicy/{dlNum}?sort=desc&includeExpired=true");
            var message = await response.Content.ReadAsStringAsync();
            var policies = JsonConvert.DeserializeObject<IEnumerable<Payload>>(message);

            //Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            if (dlNum == "DL1000002")
            {
                Assert.Equal(1972, policies.First().VehicleYear);
                Assert.Equal(1970, policies.Last().VehicleYear);
            }
            if (dlNum == "DL1000003")
            {
                Assert.Equal(1976, policies.First().VehicleYear);
                Assert.Equal(1955, policies.Last().VehicleYear);
            }
        }

        [Theory]
        [InlineData("DL1000001")]
        [InlineData("DL1000002")]
        [InlineData("DL1000003")]
        public async void GetPolicyByDriverLicense_Integration_ReturnOnlyValidPolicies(string dlNum)
        {
            //Act            
            var response = await _httpClient.GetAsync($"{requestUri}/getpolicy/{dlNum}?includeExpired=false");
            var message = await response.Content.ReadAsStringAsync();
            var policies = JsonConvert.DeserializeObject<IEnumerable<Payload>>(message);

            //Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            if (dlNum == "DL1000001")
                Assert.Single(policies);
            if (dlNum == "DL1000002")
                Assert.Equal(2, policies.Count());
            if (dlNum == "DL1000003")
                Assert.Equal(2, policies.Count());
        }

        [Theory]
        [InlineData("DL1000001")]
        [InlineData("DL1000002")]
        [InlineData("DL1000003")]
        public async void GetPolicyByDriverLicense_Integration_ReturnAllPolicies(string dlNum)
        {
            //Act            
            var response = await _httpClient.GetAsync($"{requestUri}/getpolicy/{dlNum}?includeExpired=true");
            var message = await response.Content.ReadAsStringAsync();
            var policies = JsonConvert.DeserializeObject<IEnumerable<Payload>>(message);

            //Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            if (dlNum == "DL1000001")
                Assert.Single(policies);
            if (dlNum == "DL1000002")
                Assert.Equal(2, policies.Count());
            if (dlNum == "DL1000003")
                Assert.Equal(3, policies.Count());
        }

        [Theory]
        [InlineData("")]
        public async void GetPolicyByDriverLicense_Integration_ReturnBadRequestForInvalidModelState(string dlNum)
        {
            //Act
            var response = await _httpClient.GetAsync($"{requestUri}/getpolicy/{dlNum}?includeExpired=true");
            var message = await response.Content.ReadAsStringAsync();
            var badRequest = JsonConvert.DeserializeObject<CustomBadRequest>(message);

            //Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
            Assert.Equal("One or more validation errors occurred.", badRequest.Title);
        }

        #endregion

        #region Integration Tests -> Create Policies

        [Theory]
        [ClassData(typeof(PayloadTestClass))]
        public async void CreatePolicy_Integration_ReturnBadRequestForInvalidModelState(List<Payload> payloads)
        {
            int counter = 0;
            foreach(var payload in payloads)
            {
                //Arrange
                //Generate validation error for different attributes
                if(counter == 0)
                    payload.EffectiveDate = DateTime.Now.AddDays(5);
                if(counter == 1)
                    payload.VehicleYear = 1999;
                if (counter == 2)
                {
                    payload.StreetAddress = "Random St Address";
                    payload.City = "12345";
                    payload.Zip = "Houston";
                }
                    
                var httpPayLoad = new StringContent(JsonConvert.SerializeObject(payload), Encoding.UTF8, "application/json");

                //Act
                var response = await _httpClient.PostAsync($"{requestUri}/create", httpPayLoad);
                var message = await response.Content.ReadAsStringAsync();
                var badRequest = JsonConvert.DeserializeObject<CustomBadRequest>(message);

                //Assert
                //Validate Bad Request response when model state validation fails
                Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
                //Model state validation generic error message validation
                Assert.Equal("One or more validation errors occurred.", badRequest.Title);

                counter++;
            }
            
        }

        [Theory]
        [ClassData(typeof(PayloadTestClass))]
        public async void CreatePolicy_Integration_CreateNewPolicy(List<Payload> payloads)
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
                var httpPayLoad = new StringContent(JsonConvert.SerializeObject(payload), Encoding.UTF8, "application/json");

                //Act
                var response = await _httpClient.PostAsync($"{requestUri}/create", httpPayLoad);
                var message = await response.Content.ReadAsStringAsync();
                var test = message;

                //Assert
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    //Validate OK Status
                    Assert.Equal(HttpStatusCode.OK, response.StatusCode);
                    
                    var createdPolicy = await _httpClient.GetAsync($"{requestUri}/getpolicy/{payload.DriverLicenseNumber}?includeExpired=true");
                    var createdPolicyJsonString = await createdPolicy.Content.ReadAsStringAsync();
                    var policy = JsonConvert.DeserializeObject<IEnumerable<Payload>>(createdPolicyJsonString);
                    
                    //Validate Success Message
                    Assert.Equal("Policy Created", message);
                    //Validate Response Type
                    Assert.IsType<List<Payload>>(policy);
                    
                    //Validate new policy was created in DB
                    //Assert.Single(policy);
                }
                else
                {
                    //Validate Bad Request
                    Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
                    
                    var failedStateValidationResponse = JsonConvert.DeserializeObject<Response>(message);
                    var validResponse = possibleReponses.Any(x => failedStateValidationResponse.Message == x.Message);
                    
                    //Validate Response.IsSuccess is false
                    Assert.False(failedStateValidationResponse.IsSuccess);

                    //Validate State Validation Message is one of the correct responses
                    Assert.True(validResponse);

                    //var createdPolicy = await _httpClient.GetAsync($"{requestUri}/getpolicy/{payload.DriverLicenseNumber}?includeExpired=true");
                    var policies = await _httpClient.GetAsync($"{requestUri}/getpolicy/{payload.DriverLicenseNumber}?includeExpired=true");

                    //Validate not found response to verify policy wasn't created in DB
                    Assert.Equal(HttpStatusCode.NotFound, policies.StatusCode);

                }
            }       
        }

        #endregion
    }
}

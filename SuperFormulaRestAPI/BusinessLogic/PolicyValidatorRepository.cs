using SuperFormulaRestAPI.Helpers;
using SuperFormulaRestAPI.Models;

namespace SuperFormulaRestAPI.BusinessLogic
{
    public class PolicyValidatorRepository : IPolicyValidator
    {
        public Response ValidateStateRegulations(Payload policy)
        {
            var randInt = RandomGenerator.GetRandomNumber(0, 100, 1);
            Response resp = new Response();
            if (randInt <= 50)
            {
                resp.IsSuccess = false;
                resp.Message = "State validation failed due to expired license!";
            }
            else if (randInt <= 50 && randInt > 25)
            {
                resp.IsSuccess = true;
                resp.Message = "State validation completed successfully!";
            }
            if (randInt <= 100 && randInt > 50)
            {
                resp.IsSuccess = false;
                resp.Message = "State validation failed due to missing vehicle registration!";
            }
            else
            {
                resp.IsSuccess = true;
                resp.Message = "State validation completed successfully!";
            }
            return resp;      
        }
    }
}

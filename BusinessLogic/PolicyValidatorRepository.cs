using SuperFormulaRestAPI.Helpers;
using SuperFormulaRestAPI.Models;

namespace SuperFormulaRestAPI.BusinessLogic
{
    public class PolicyValidatorRepository : IPolicyValidator
    {
        public Error ValidateStateRegulations(Payload policy)
        {
            var randInt = RandomGenerator.GetRandomNumber(0, 100, 1);
            Error error = new Error();
            if (randInt <= 25)
            {
                error.IsSuccess = false;
                error.Message = "State validation failed due to expired license!";
            }
            else if (randInt <= 50 && randInt > 25)
            {
                error.IsSuccess = true;
                error.Message = "State validation completed successfully!";
            }
            else if (randInt <= 75 && randInt > 50)
            {
                error.IsSuccess = false;
                error.Message = "State validation failed due to invalid address for submitted policy!";
            }
            else
            {
                error.IsSuccess = false;
                error.Message = "State validation failed due to missing vehicle registration!";
            }
            error.IsSuccess = true;
            error.Message = "State validation completed successfully!";
            return error;      
        }
    }
}

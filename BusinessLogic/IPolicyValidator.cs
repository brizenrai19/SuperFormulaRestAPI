using SuperFormulaRestAPI.Models;

namespace SuperFormulaRestAPI.BusinessLogic
{
    public interface IPolicyValidator
    {
       Error ValidateStateRegulations(Payload policy);
    }
}

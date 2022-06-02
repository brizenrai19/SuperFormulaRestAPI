using SuperFormulaRestAPI.Models;

namespace SuperFormulaRestAPI.BusinessLogic
{
    public interface IPolicyValidator
    {
       Response ValidateStateRegulations(Payload policy);
    }
}

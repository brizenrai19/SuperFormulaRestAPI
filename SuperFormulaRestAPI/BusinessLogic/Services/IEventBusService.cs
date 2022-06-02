namespace SuperFormulaRestAPI.BusinessLogic.Services
{
    public interface IEventBusService
    {
        Task<bool> SendMessageAsync(string message, int retries);
    }
}

using SuperFormulaRestAPI.Helpers;

namespace SuperFormulaRestAPI.BusinessLogic.Services
{
    public class EventBusService : IEventBusService
    {
        public async Task<bool> SendMessageAsync(string message, int retries)
        {
            bool success = RandomGenerator.GetRandomNumber(0,10,1) <= 5;
            for (int i = 0; i < retries; i++)
            {
                // Mock processing delay
                await Task.Delay(TimeSpan.FromSeconds(3));
                
                // if success stop delay and exit out, else retry 2 more times
                if (success)
                {
                    Console.WriteLine();
                    break;
                }
                Console.WriteLine($"Failure sending Event Bus Message: --{message}--");
                Console.WriteLine($"Retrying........................................Retries Left: {retries - (i + 1)}");
                success = RandomGenerator.GetRandomNumber(0, 10, 1) <= 5;
                throw new IndexOutOfRangeException();
            }
            if (!success)
                Console.WriteLine($"Failure sending Event Bus Message: --{message}--");
            else
                Console.WriteLine($"Success sending Event Bus Message: --{message}--");
            return success;
        }
    }
}

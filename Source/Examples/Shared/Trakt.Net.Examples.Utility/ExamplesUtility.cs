using TraktNet.Exceptions;

namespace Trakt.Net.Examples.Utility
{
    public static class ExamplesUtility
    {
        public static void PrintTraktException(TraktException ex)
        {
            Console.WriteLine("-------------- Trakt Exception --------------");
            Console.WriteLine($"Exception message: {ex.Message}");
            Console.WriteLine($"Status code: {ex.StatusCode}");
            Console.WriteLine($"Request URL: {ex.RequestUrl}");
            Console.WriteLine($"Request message: {ex.RequestBody}");
            Console.WriteLine($"Request response: {ex.Response}");
            Console.WriteLine($"Server Reason Phrase: {ex.ServerReasonPhrase}");
            Console.WriteLine("---------------------------------------------");
        }

        public static void PrintException(Exception ex)
        {
            Console.WriteLine("-------------- Exception --------------");
            Console.WriteLine($"Exception message: {ex.Message}");
            Console.WriteLine("---------------------------------------");
        }
    }
}

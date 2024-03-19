using TraktNET;

namespace Trakt.NET.Framework.NET5
{
    internal sealed class Program
    {
        static void Main(string[] _)
        {
            var client = new TraktClient("clientID", "clientSecret");

            Console.WriteLine("Welcome to Trakt.NET in .NET 5.");
        }
    }
}

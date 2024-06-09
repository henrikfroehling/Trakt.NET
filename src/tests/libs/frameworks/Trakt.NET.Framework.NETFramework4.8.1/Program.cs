using System;
using TraktNET;

namespace Trakt.NET.Framework.NETFramework481
{
    internal sealed class Program
    {
        static void Main(string[] _)
        {
            var client = new TraktClient("clientID", "clientSecret");

            Console.WriteLine("Welcome to Trakt.NET in .NET Framework 4.8.1.");
        }
    }
}

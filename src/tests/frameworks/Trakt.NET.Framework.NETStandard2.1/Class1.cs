﻿using TraktNET;

namespace Trakt.NET.Framework.NETStandard21
{
    public class Class1
    {
        public static void Test()
        {
            var client = new TraktClient("clientID", "clientSecret");

            Console.WriteLine("Welcome to Trakt.NET in .NET Standard 2.1.");
        }
    }
}

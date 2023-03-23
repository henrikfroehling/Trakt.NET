using TraktNet;

Console.WriteLine("Please enter your Trakt Client-ID:");
string clientID = Console.ReadLine();

Console.WriteLine("Please enter your Trakt Client-Secret:");
string clientSecret = Console.ReadLine();

var client = new TraktClient(clientID, clientSecret);
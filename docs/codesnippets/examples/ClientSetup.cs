using TraktNet;

Console.ReadLine("Please enter your Trakt Client-ID:");
string clientID = Console.ReadLine();

var client = new TraktClient(clientID);
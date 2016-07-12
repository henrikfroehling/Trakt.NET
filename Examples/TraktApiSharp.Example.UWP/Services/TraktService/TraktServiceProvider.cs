namespace TraktApiSharp.Example.UWP.Services.TraktService
{
    public class TraktServiceProvider
    {
        private static readonly string CLIENT_ID = "ENTER YOUR TRAKT CLIENT ID HERE!!!";

        public static TraktClient Client { get; } = new TraktClient(CLIENT_ID);
    }
}

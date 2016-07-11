namespace TraktApiSharp.Example.UWP.Services.TraktService
{
    using Requests;

    public class TraktServiceProvider
    {
        private static readonly string CLIENT_ID = "ENTER YOUR TRAKT CLIENT ID HERE!!!";

        public static TraktClient Client { get; } = new TraktClient(CLIENT_ID);

        public static TraktExtendedOption ExtendedFullImages { get; } = new TraktExtendedOption { Full = true, Images = true };
    }
}

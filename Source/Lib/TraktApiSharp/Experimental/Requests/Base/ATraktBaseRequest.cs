namespace TraktApiSharp.Experimental.Requests.Base
{
    internal abstract class ATraktBaseRequest
    {
        internal ATraktBaseRequest(TraktClient client)
        {
            Client = client;
        }

        internal TraktClient Client { get; }
    }
}

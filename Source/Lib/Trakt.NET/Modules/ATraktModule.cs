namespace TraktNet.Modules
{
    public abstract class ATraktModule
    {
        protected ATraktModule(TraktClient client) => Client = client;

        internal TraktClient Client { get; }
    }
}

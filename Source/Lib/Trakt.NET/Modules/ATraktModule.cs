namespace TraktNet.Modules
{
    public abstract class ATraktModule
    {
        internal ATraktModule(TraktClient client) => Client = client;

        internal TraktClient Client { get; }
    }
}

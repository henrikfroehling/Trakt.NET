namespace TraktApiSharp.Modules
{
    public abstract class TraktBaseModule
    {
        internal TraktBaseModule(TraktClient client) { Client = client; }

        /// <summary>Gets a reference to the associated <see cref="TraktClient" /> instance.</summary>
        public TraktClient Client { get; }
    }
}

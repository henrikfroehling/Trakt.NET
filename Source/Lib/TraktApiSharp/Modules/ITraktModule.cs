namespace TraktApiSharp.Modules
{
    public interface ITraktModule
    {
        /// <summary>Gets a reference to the associated <see cref="TraktClient" /> instance.</summary>
        TraktClient Client { get; }
    }
}

namespace TraktNet.Objects.Basic
{
    /// <summary>A Trakt network.</summary>
    public interface ITraktNetwork
    {
        /// <summary>Gets or sets the network name.<para>Nullable</para></summary>
        string Name { get; set; }
    }
}

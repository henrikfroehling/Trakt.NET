namespace TraktNet.Objects.Basic
{
    /// <summary>An image for an item available in only one size.</summary>
    public interface ITraktImage
    {
        /// <summary>The address to the full size image.<para>Nullable</para></summary>
        string Full { get; set; }
    }
}

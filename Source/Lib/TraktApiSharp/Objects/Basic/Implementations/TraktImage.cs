namespace TraktNet.Objects.Basic
{
    /// <summary>An image for an item available in only one size.</summary>
    public class TraktImage : ITraktImage
    {
        /// <summary>The address to the full size image.<para>Nullable</para></summary>
        public string Full { get; set; }
    }
}

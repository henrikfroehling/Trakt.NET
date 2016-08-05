namespace TraktApiSharp.Objects.Basic
{
    using Attributes;
    using Newtonsoft.Json;

    /// <summary>An image for an item available in only one size.</summary>
    public class TraktImage
    {
        /// <summary>The address to the full size image.<para>Nullable</para></summary>
        [JsonProperty(PropertyName = "full")]
        [Nullable]
        public string Full { get; set; }
    }
}

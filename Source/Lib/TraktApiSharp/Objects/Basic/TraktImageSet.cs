namespace TraktApiSharp.Objects.Basic
{
    using Attributes;
    using Newtonsoft.Json;

    /// <summary>An image for an item in various sizes.</summary>
    public class TraktImageSet
    {
        /// <summary>The address to the full size image.<para>Nullable</para></summary>
        [JsonProperty(PropertyName = "full")]
        [Nullable]
        public string Full { get; set; }

        /// <summary>The address to the medium size image.<para>Nullable</para></summary>
        [JsonProperty(PropertyName = "medium")]
        [Nullable]
        public string Medium { get; set; }

        /// <summary>The address to the thumbnail image.<para>Nullable</para></summary>
        [JsonProperty(PropertyName = "thumb")]
        [Nullable]
        public string Thumb { get; set; }
    }
}

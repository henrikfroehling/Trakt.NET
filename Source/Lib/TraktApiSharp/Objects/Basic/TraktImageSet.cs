namespace TraktApiSharp.Objects.Basic
{
    using Newtonsoft.Json;

    /// <summary>An image for an item in various sizes.</summary>
    public class TraktImageSet
    {
        /// <summary>The address to the full size image.</summary>
        [JsonProperty(PropertyName = "full")]
        public string Full { get; set; }

        /// <summary>The address to the medium size image.</summary>
        [JsonProperty(PropertyName = "medium")]
        public string Medium { get; set; }

        /// <summary>The address to the thumbnail image.</summary>
        [JsonProperty(PropertyName = "thumb")]
        public string Thumb { get; set; }
    }
}

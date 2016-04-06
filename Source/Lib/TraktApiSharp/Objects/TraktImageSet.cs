namespace TraktApiSharp.Objects
{
    using Newtonsoft.Json;
    using System;

    /// <summary>
    /// An image for an item in various sizes.
    /// </summary>
    public class TraktImageSet
    {
        /// <summary>
        /// The address to the full size image.
        /// </summary>
        [JsonProperty(PropertyName = "full")]
        public string Full { get; set; }

        /// <summary>
        /// The URI to the full size image.
        /// </summary>
        [JsonIgnore]
        public Uri FullUri
        {
            get { return !string.IsNullOrEmpty(Full) ? new Uri(Full) : null; }
            set { Full = value.AbsoluteUri; }
        }

        /// <summary>
        /// The address to the medium size image.
        /// </summary>
        [JsonProperty(PropertyName = "medium")]
        public string Medium { get; set; }

        /// <summary>
        /// The URI to the medium size image.
        /// </summary>
        [JsonIgnore]
        public Uri MediumUri
        {
            get { return !string.IsNullOrEmpty(Medium) ? new Uri(Medium) : null; }
            set { Medium = value.AbsoluteUri; }
        }

        /// <summary>
        /// The address to the thumbnail image.
        /// </summary>
        [JsonProperty(PropertyName = "thumb")]
        public string Thumb { get; set; }

        /// <summary>
        /// The URI to the thumbnail image.
        /// </summary>
        [JsonIgnore]
        public Uri ThumbUri
        {
            get { return !string.IsNullOrEmpty(Thumb) ? new Uri(Thumb) : null; }
            set { Thumb = value.AbsoluteUri; }
        }
    }
}

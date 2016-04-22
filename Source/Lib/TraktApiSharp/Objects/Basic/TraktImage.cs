namespace TraktApiSharp.Objects.Basic
{
    using Newtonsoft.Json;
    using System;

    /// <summary>
    /// An image for an item available on only one size.
    /// </summary>
    public class TraktImage
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
    }
}

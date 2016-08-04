namespace TraktApiSharp.Objects.Basic
{
    using Attributes;
    using Newtonsoft.Json;

    /// <summary>Represents a Trakt error response.</summary>
    public class TraktError
    {
        /// <summary>Gets or sets the error name.<para>Nullable</para></summary>
        [JsonProperty(PropertyName = "error")]
        [Nullable]
        public string Error { get; set; }

        /// <summary>Gets or sets the error description.<para>Nullable</para></summary>
        [JsonProperty(PropertyName = "error_description")]
        [Nullable]
        public string Description { get; set; }
    }
}

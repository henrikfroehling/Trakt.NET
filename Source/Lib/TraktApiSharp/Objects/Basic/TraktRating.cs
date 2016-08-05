namespace TraktApiSharp.Objects.Basic
{
    using Attributes;
    using Newtonsoft.Json;
    using System.Collections.Generic;

    /// <summary>Represents a Trakt rating.</summary>
    public class TraktRating
    {
        /// <summary>Gets or sets the rating value.</summary>
        [JsonProperty(PropertyName = "rating")]
        public float? Rating { get; set; }

        /// <summary>Gets or sets the number of votes for this rating.</summary>
        [JsonProperty(PropertyName = "votes")]
        public int? Votes { get; set; }

        /// <summary>Gets or sets the rating distribution.<para>Nullable</para></summary>
        [JsonProperty(PropertyName = "distribution")]
        [Nullable]
        public Dictionary<string, int> Distribution { get; set; }
    }
}

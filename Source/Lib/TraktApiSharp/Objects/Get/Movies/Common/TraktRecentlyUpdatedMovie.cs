namespace TraktApiSharp.Objects.Get.Movies.Common
{
    using Newtonsoft.Json;
    using System;

    /// <summary>An updated Trakt movie.</summary>
    public class TraktRecentlyUpdatedMovie
    {
        /// <summary>Gets or sets the UTC datetime, when the <see cref="Movie" /> was updated.</summary>
        [JsonProperty(PropertyName = "updated_at")]
        public DateTime? UpdatedAt { get; set; }

        /// <summary>Gets or sets the Trakt movie.</summary>
        [JsonProperty(PropertyName = "movie")]
        public TraktMovie Movie { get; set; }
    }
}

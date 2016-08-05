namespace TraktApiSharp.Objects.Get.Movies.Common
{
    using Attributes;
    using Newtonsoft.Json;
    using System;

    /// <summary>An updated Trakt movie.</summary>
    public class TraktRecentlyUpdatedMovie
    {
        /// <summary>Gets or sets the UTC datetime, when the <see cref="Movie" /> was updated.</summary>
        [JsonProperty(PropertyName = "updated_at")]
        public DateTime? UpdatedAt { get; set; }

        /// <summary>Gets or sets the Trakt movie. See also <seealso cref="TraktMovie" />.<para>Nullable</para></summary>
        [JsonProperty(PropertyName = "movie")]
        [Nullable]
        public TraktMovie Movie { get; set; }
    }
}

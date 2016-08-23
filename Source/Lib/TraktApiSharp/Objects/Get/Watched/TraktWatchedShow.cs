namespace TraktApiSharp.Objects.Get.Watched
{
    using Attributes;
    using Newtonsoft.Json;
    using Shows;
    using System;
    using System.Collections.Generic;

    /// <summary>Contains information about a watched Trakt show.</summary>
    public class TraktWatchedShow
    {
        /// <summary>Gets or sets the number of plays for the watched show.</summary>
        [JsonProperty(PropertyName = "plays")]
        public int? Plays { get; set; }

        /// <summary>Gets or sets the UTC datetime, when the show was last watched.</summary>
        [JsonProperty(PropertyName = "last_watched_at")]
        public DateTime? LastWatchedAt { get; set; }

        /// <summary>Gets or sets the Trakt show. See also <seealso cref="TraktShow" />.<para>Nullable</para></summary>
        [JsonProperty(PropertyName = "show")]
        [Nullable]
        public TraktShow Show { get; set; }

        /// <summary>
        /// Gets or sets a list of watched seasons in the watched show.
        /// See also <seealso cref="TraktWatchedShowSeason" />.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "seasons")]
        [Nullable]
        public IEnumerable<TraktWatchedShowSeason> Seasons { get; set; }
    }
}

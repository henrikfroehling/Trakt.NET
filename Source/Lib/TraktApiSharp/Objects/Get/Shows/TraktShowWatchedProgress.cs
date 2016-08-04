namespace TraktApiSharp.Objects.Get.Shows
{
    using Attributes;
    using Newtonsoft.Json;
    using Seasons;
    using System;
    using System.Collections.Generic;

    /// <summary>Represents the watched progress of a Trakt show.</summary>
    public class TraktShowWatchedProgress : TraktShowProgress
    {
        /// <summary>Gets or sets the UTC datetime, when the last watch occured.</summary>
        [JsonProperty(PropertyName = "last_watched_at")]
        public DateTime? LastWatchedAt { get; set; }

        /// <summary>
        /// Gets or sets the watched seasons. See also <seealso cref="TraktSeasonWatchedProgress" />.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "seasons")]
        [Nullable]
        public IEnumerable<TraktSeasonWatchedProgress> Seasons { get; set; }
    }
}

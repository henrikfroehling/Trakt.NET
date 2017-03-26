namespace TraktApiSharp.Objects.Get.Shows.Implementations
{
    using Newtonsoft.Json;
    using Seasons;
    using System;
    using System.Collections.Generic;
    using TraktApiSharp.Objects.Get.Seasons.Implementations;

    /// <summary>Represents the watched progress of a Trakt show.</summary>
    public class TraktShowWatchedProgress : TraktShowProgress, ITraktShowWatchedProgress
    {
        /// <summary>Gets or sets the UTC datetime, when the last watch occured.</summary>
        [JsonProperty(PropertyName = "last_watched_at")]
        public DateTime? LastWatchedAt { get; set; }

        /// <summary>
        /// Gets or sets the watched seasons. See also <seealso cref="ITraktSeasonWatchedProgress" />.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "seasons")]
        public IEnumerable<ITraktSeasonWatchedProgress> Seasons { get; set; }
    }
}

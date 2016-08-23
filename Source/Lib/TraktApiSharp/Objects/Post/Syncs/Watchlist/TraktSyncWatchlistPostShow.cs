namespace TraktApiSharp.Objects.Post.Syncs.Watchlist
{
    using Attributes;
    using Get.Shows;
    using Newtonsoft.Json;
    using System.Collections.Generic;

    /// <summary>
    /// A Trakt watchlist post show, containing the required show ids.
    /// <para>Can also contain optional seasons.</para>
    /// </summary>
    public class TraktSyncWatchlistPostShow
    {
        /// <summary>Gets or sets the optional title of the Trakt show.<para>Nullable</para></summary>
        [JsonProperty(PropertyName = "title")]
        [Nullable]
        public string Title { get; set; }

        /// <summary>Gets or sets the optional year of the Trakt show.</summary>
        [JsonProperty(PropertyName = "year")]
        public int? Year { get; set; }

        /// <summary>Gets or sets the required show ids. See also <seealso cref="TraktShowIds" />.</summary>
        [JsonProperty(PropertyName = "ids")]
        public TraktShowIds Ids { get; set; }

        /// <summary>
        /// An optional list of <see cref="TraktSyncWatchlistPostShowSeason" />s.
        /// <para>
        /// If no seasons are set, the whole Trakt show will be added to the watchlist.
        /// Otherwise, only the specified seasons and / or episodes will be added to the watchlist.
        /// </para>
        /// </summary>
        [JsonProperty(PropertyName = "seasons")]
        [Nullable]
        public IEnumerable<TraktSyncWatchlistPostShowSeason> Seasons { get; set; }
    }
}

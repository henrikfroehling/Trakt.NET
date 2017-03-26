namespace TraktApiSharp.Objects.Get.Seasons.Implementations
{
    using Episodes;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using TraktApiSharp.Objects.Get.Episodes.Implementations;

    /// <summary>Represents the watched progress of a Trakt season.</summary>
    public class TraktSeasonWatchedProgress : TraktSeasonProgress, ITraktSeasonWatchedProgress
    {
        /// <summary>
        /// Gets or sets the watched episodes. See also <seealso cref="ITraktEpisodeWatchedProgress" />.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "episodes")]
        public IEnumerable<ITraktEpisodeWatchedProgress> Episodes { get; set; }
    }
}

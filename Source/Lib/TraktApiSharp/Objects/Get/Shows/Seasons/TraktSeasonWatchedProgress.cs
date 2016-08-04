namespace TraktApiSharp.Objects.Get.Shows.Seasons
{
    using Attributes;
    using Episodes;
    using Newtonsoft.Json;
    using System.Collections.Generic;

    /// <summary>Represents the watched progress of a Trakt season.</summary>
    public class TraktSeasonWatchedProgress : TraktSeasonProgress
    {
        /// <summary>
        /// Gets or sets the watched episodes. See also <seealso cref="TraktEpisodeWatchedProgress" />.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "episodes")]
        [Nullable]
        public IEnumerable<TraktEpisodeWatchedProgress> Episodes { get; set; }
    }
}

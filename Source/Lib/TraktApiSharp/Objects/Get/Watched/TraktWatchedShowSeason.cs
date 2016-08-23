namespace TraktApiSharp.Objects.Get.Watched
{
    using Attributes;
    using Newtonsoft.Json;
    using System.Collections.Generic;

    /// <summary>Contains information about a watched Trakt season.</summary>
    public class TraktWatchedShowSeason
    {
        /// <summary>Gets or sets the number of the watched season.</summary>
        [JsonProperty(PropertyName = "number")]
        public int? Number { get; set; }

        /// <summary>
        /// Gets or sets a list of watched episodes in the watched season.
        /// See also <seealso cref="TraktWatchedShowEpisode" />.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "episodes")]
        [Nullable]
        public IEnumerable<TraktWatchedShowEpisode> Episodes { get; set; }
    }
}

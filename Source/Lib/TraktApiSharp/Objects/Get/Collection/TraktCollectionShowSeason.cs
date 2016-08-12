namespace TraktApiSharp.Objects.Get.Collection
{
    using Attributes;
    using Newtonsoft.Json;
    using System.Collections.Generic;

    /// <summary>Contains information about a collected Trakt season.</summary>
    public class TraktCollectionShowSeason
    {
        /// <summary>Gets or sets the number of the collected season.</summary>
        [JsonProperty(PropertyName = "number")]
        public int? Number { get; set; }

        /// <summary>
        /// Gets or sets a list of collected episodes in the collected season.
        /// See also <seealso cref="TraktCollectionShowEpisode" />.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "episodes")]
        [Nullable]
        public IEnumerable<TraktCollectionShowEpisode> Episodes { get; set; }
    }
}

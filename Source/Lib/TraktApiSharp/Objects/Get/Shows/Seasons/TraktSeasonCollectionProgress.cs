namespace TraktApiSharp.Objects.Get.Shows.Seasons
{
    using Attributes;
    using Episodes;
    using Newtonsoft.Json;
    using System.Collections.Generic;

    /// <summary>Represents the collection progress of a Trakt season.</summary>
    public class TraktSeasonCollectionProgress : TraktSeasonProgress
    {
        /// <summary>
        /// Gets or sets the collected episodes. See also <seealso cref="TraktEpisodeCollectionProgress" />.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "episodes")]
        [Nullable]
        public IEnumerable<TraktEpisodeCollectionProgress> Episodes { get; set; }
    }
}

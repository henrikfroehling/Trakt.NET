namespace TraktApiSharp.Objects.Get.Seasons
{
    using Newtonsoft.Json;
    using Shows.Episodes;
    using System.Collections.Generic;

    /// <summary>Represents the collection progress of a Trakt season.</summary>
    public class TraktSeasonCollectionProgress : TraktSeasonProgress
    {
        /// <summary>
        /// Gets or sets the collected episodes. See also <seealso cref="TraktEpisodeCollectionProgress" />.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "episodes")]
        public IEnumerable<TraktEpisodeCollectionProgress> Episodes { get; set; }
    }
}

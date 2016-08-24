namespace TraktApiSharp.Objects.Post.Syncs.Collection
{
    using Attributes;
    using Newtonsoft.Json;
    using System.Collections.Generic;

    /// <summary>A Trakt collection post season, containing the required season number and optional episodes.</summary>
    public class TraktSyncCollectionPostShowSeason
    {
        /// <summary>Gets or sets the required season number of the Trakt season.</summary>
        [JsonProperty(PropertyName = "number")]
        public int Number { get; set; }

        /// <summary>
        /// An optional list of <see cref="TraktSyncCollectionPostShowEpisode" />s.
        /// <para>
        /// If no episodes are set, the whole Trakt season will be added to the collection.
        /// Otherwise, only the specified episodes will be added to the collection.
        /// </para>
        /// </summary>
        [JsonProperty(PropertyName = "episodes")]
        [Nullable]
        public IEnumerable<TraktSyncCollectionPostShowEpisode> Episodes { get; set; }
    }
}

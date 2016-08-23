namespace TraktApiSharp.Objects.Post.Syncs.Responses
{
    using Attributes;
    using Get.Movies;
    using Get.Shows;
    using Get.Shows.Episodes;
    using Get.Shows.Seasons;
    using Newtonsoft.Json;
    using System.Collections.Generic;

    /// <summary>A collection containing the ids of movies, shows, seasons and episodes, which were not found.</summary>
    public class TraktSyncPostResponseNotFound
    {
        /// <summary>
        /// A list of <see cref="TraktSyncPostResponseNotFoundItem{T}" />, containing the ids of movies, which were not found.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "movies")]
        [Nullable]
        public IEnumerable<TraktSyncPostResponseNotFoundItem<TraktMovieIds>> Movies { get; set; }

        /// <summary>
        /// A list of <see cref="TraktSyncPostResponseNotFoundItem{T}" />, containing the ids of shows, which were not found.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "shows")]
        [Nullable]
        public IEnumerable<TraktSyncPostResponseNotFoundItem<TraktShowIds>> Shows { get; set; }

        /// <summary>
        /// A list of <see cref="TraktSyncPostResponseNotFoundItem{T}" />, containing the ids of seasons, which were not found.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "seasons")]
        [Nullable]
        public IEnumerable<TraktSyncPostResponseNotFoundItem<TraktSeasonIds>> Seasons { get; set; }

        /// <summary>
        /// A list of <see cref="TraktSyncPostResponseNotFoundItem{T}" />, containing the ids of episodes, which were not found.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "episodes")]
        [Nullable]
        public IEnumerable<TraktSyncPostResponseNotFoundItem<TraktEpisodeIds>> Episodes { get; set; }
    }
}

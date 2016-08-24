namespace TraktApiSharp.Objects.Post.Syncs.Ratings.Responses
{
    using Attributes;
    using Get.Movies;
    using Get.Shows;
    using Get.Shows.Episodes;
    using Get.Shows.Seasons;
    using Newtonsoft.Json;
    using System.Collections.Generic;

    /// <summary>A collection containing the ids of rated movies, shows, seasons and episodes, which were not found.</summary>
    public class TraktSyncRatingsPostResponseNotFound
    {
        /// <summary>
        /// A list of <see cref="TraktSyncRatingsPostResponseNotFoundItem{T}" />, containing the ids of rated movies, which were not found.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "movies")]
        [Nullable]
        public IEnumerable<TraktSyncRatingsPostResponseNotFoundItem<TraktMovieIds>> Movies { get; set; }

        /// <summary>
        /// A list of <see cref="TraktSyncRatingsPostResponseNotFoundItem{T}" />, containing the ids of rated shows, which were not found.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "shows")]
        [Nullable]
        public IEnumerable<TraktSyncRatingsPostResponseNotFoundItem<TraktShowIds>> Shows { get; set; }

        /// <summary>
        /// A list of <see cref="TraktSyncRatingsPostResponseNotFoundItem{T}" />, containing the ids of rated seasons, which were not found.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "seasons")]
        [Nullable]
        public IEnumerable<TraktSyncRatingsPostResponseNotFoundItem<TraktSeasonIds>> Seasons { get; set; }

        /// <summary>
        /// A list of <see cref="TraktSyncRatingsPostResponseNotFoundItem{T}" />, containing the ids of rated episodes, which were not found.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "episodes")]
        [Nullable]
        public IEnumerable<TraktSyncRatingsPostResponseNotFoundItem<TraktEpisodeIds>> Episodes { get; set; }
    }
}

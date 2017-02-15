namespace TraktApiSharp.Objects.Post.Syncs.Ratings.Responses
{
    using Get.Movies;
    using Get.Seasons;
    using Get.Shows;
    using Get.Shows.Episodes;
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
        public IEnumerable<TraktSyncRatingsPostResponseNotFoundItem<TraktMovieIds>> Movies { get; set; }

        /// <summary>
        /// A list of <see cref="TraktSyncRatingsPostResponseNotFoundItem{T}" />, containing the ids of rated shows, which were not found.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "shows")]
        public IEnumerable<TraktSyncRatingsPostResponseNotFoundItem<TraktShowIds>> Shows { get; set; }

        /// <summary>
        /// A list of <see cref="TraktSyncRatingsPostResponseNotFoundItem{T}" />, containing the ids of rated seasons, which were not found.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "seasons")]
        public IEnumerable<TraktSyncRatingsPostResponseNotFoundItem<TraktSeasonIds>> Seasons { get; set; }

        /// <summary>
        /// A list of <see cref="TraktSyncRatingsPostResponseNotFoundItem{T}" />, containing the ids of rated episodes, which were not found.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "episodes")]
        public IEnumerable<TraktSyncRatingsPostResponseNotFoundItem<TraktEpisodeIds>> Episodes { get; set; }
    }
}

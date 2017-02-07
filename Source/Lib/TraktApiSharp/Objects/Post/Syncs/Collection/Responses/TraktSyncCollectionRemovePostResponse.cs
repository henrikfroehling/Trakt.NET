﻿namespace TraktApiSharp.Objects.Post.Syncs.Collection.Responses
{
    using Newtonsoft.Json;
    using Syncs.Responses;

    /// <summary>
    /// Represents the response for a collection remove post. See also <see cref="TraktSyncCollectionPost" />.
    /// <para>Contains the number of deleted and not found movies, shows, seasons and episodes.</para>
    /// </summary>
    public class TraktSyncCollectionRemovePostResponse
    {
        /// <summary>
        /// A collection containing the number of deleted movies, shows, seasons and episodes.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "deleted")]
        public TraktSyncPostResponseGroup Deleted { get; set; }

        /// <summary>
        /// A collection containing the ids of movies, shows, seasons and episodes, which were not found.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "not_found")]
        public TraktSyncPostResponseNotFound NotFound { get; set; }
    }
}

﻿namespace TraktNet.Objects.Post.Syncs.Responses.Json.Writer
{
    using Newtonsoft.Json;
    using Objects.Json;
    using Post.Responses;
    using System.Threading;
    using System.Threading.Tasks;

    internal class ASyncPostResponseNotFoundGroupObjectJsonWriter<TSyncPostResponseNotFoundGroupObjectType> : AObjectJsonWriter<TSyncPostResponseNotFoundGroupObjectType> where TSyncPostResponseNotFoundGroupObjectType : ITraktSyncPostResponseNotFoundGroup
    {
        public override async Task WriteObjectAsync(JsonTextWriter jsonWriter, TSyncPostResponseNotFoundGroupObjectType obj, CancellationToken cancellationToken = default)
        {
            CheckJsonTextWriter(jsonWriter);
            await jsonWriter.WriteStartObjectAsync(cancellationToken).ConfigureAwait(false);
            await WriteSyncPostResponseObjectAsync(jsonWriter, obj, cancellationToken).ConfigureAwait(false);
            await jsonWriter.WriteEndObjectAsync(cancellationToken).ConfigureAwait(false);
        }

        protected virtual async Task WriteSyncPostResponseObjectAsync(JsonTextWriter jsonWriter, TSyncPostResponseNotFoundGroupObjectType obj, CancellationToken cancellationToken = default)
        {
            if (obj.Movies != null)
            {
                var postResponseNotFoundMovieArrayJsonWriter = new ArrayJsonWriter<ITraktPostResponseNotFoundMovie>();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.SYNC_POST_RESPONSE_NOT_FOUND_GROUP_PROPERTY_NAME_MOVIES, cancellationToken).ConfigureAwait(false);
                await postResponseNotFoundMovieArrayJsonWriter.WriteArrayAsync(jsonWriter, obj.Movies, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Shows != null)
            {
                var postResponseNotFoundShowArrayJsonWriter = new ArrayJsonWriter<ITraktPostResponseNotFoundShow>();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.SYNC_POST_RESPONSE_NOT_FOUND_GROUP_PROPERTY_NAME_SHOWS, cancellationToken).ConfigureAwait(false);
                await postResponseNotFoundShowArrayJsonWriter.WriteArrayAsync(jsonWriter, obj.Shows, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Seasons != null)
            {
                var postResponseNotFoundSeasonArrayJsonWriter = new ArrayJsonWriter<ITraktPostResponseNotFoundSeason>();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.SYNC_POST_RESPONSE_NOT_FOUND_GROUP_PROPERTY_NAME_SEASONS, cancellationToken).ConfigureAwait(false);
                await postResponseNotFoundSeasonArrayJsonWriter.WriteArrayAsync(jsonWriter, obj.Seasons, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Episodes != null)
            {
                var postResponseNotFoundEpisodeArrayJsonWriter = new ArrayJsonWriter<ITraktPostResponseNotFoundEpisode>();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.SYNC_POST_RESPONSE_NOT_FOUND_GROUP_PROPERTY_NAME_EPISODES, cancellationToken).ConfigureAwait(false);
                await postResponseNotFoundEpisodeArrayJsonWriter.WriteArrayAsync(jsonWriter, obj.Episodes, cancellationToken).ConfigureAwait(false);
            }
        }
    }
}

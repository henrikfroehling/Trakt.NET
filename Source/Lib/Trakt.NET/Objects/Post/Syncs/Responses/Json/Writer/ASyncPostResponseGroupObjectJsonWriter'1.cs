﻿namespace TraktNet.Objects.Post.Syncs.Responses.Json.Writer
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class ASyncPostResponseGroupObjectJsonWriter<TSyncPostResponseGroupObjectType> : AObjectJsonWriter<TSyncPostResponseGroupObjectType> where TSyncPostResponseGroupObjectType : ITraktSyncPostResponseGroup
    {
        public override async Task WriteObjectAsync(JsonTextWriter jsonWriter, TSyncPostResponseGroupObjectType obj, CancellationToken cancellationToken = default)
        {
            CheckJsonTextWriter(jsonWriter);
            await jsonWriter.WriteStartObjectAsync(cancellationToken).ConfigureAwait(false);
            await WriteSyncPostResponseObjectAsync(jsonWriter, obj, cancellationToken).ConfigureAwait(false);
            await jsonWriter.WriteEndObjectAsync(cancellationToken).ConfigureAwait(false);
        }

        protected virtual async Task WriteSyncPostResponseObjectAsync(JsonTextWriter jsonWriter, TSyncPostResponseGroupObjectType obj, CancellationToken cancellationToken = default)
        {
            if (obj.Movies.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.SYNC_POST_RESPONSE_GROUP_PROPERTY_NAME_MOVIES, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.Movies, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Shows.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.SYNC_POST_RESPONSE_GROUP_PROPERTY_NAME_SHOWS, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.Shows, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Seasons.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.SYNC_POST_RESPONSE_GROUP_PROPERTY_NAME_SEASONS, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.Seasons, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Episodes.HasValue)
            {
                await jsonWriter.WritePropertyNameAsync(JsonProperties.SYNC_POST_RESPONSE_GROUP_PROPERTY_NAME_EPISODES, cancellationToken).ConfigureAwait(false);
                await jsonWriter.WriteValueAsync(obj.Episodes, cancellationToken).ConfigureAwait(false);
            }
        }
    }
}

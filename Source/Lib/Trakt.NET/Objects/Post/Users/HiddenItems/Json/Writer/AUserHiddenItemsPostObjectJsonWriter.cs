﻿namespace TraktNet.Objects.Post.Users.HiddenItems.Json.Writer
{
    using Newtonsoft.Json;
    using System.Threading;
    using System.Threading.Tasks;
    using TraktNet.Objects.Get.Users;
    using TraktNet.Objects.Json;

    internal abstract class AUserHiddenItemsPostObjectJsonWriter<TUserHiddenItemsPost> : AObjectJsonWriter<TUserHiddenItemsPost>
        where TUserHiddenItemsPost : ITraktUserHiddenItemsPost
    {
        public override async Task WriteObjectAsync(JsonTextWriter jsonWriter, TUserHiddenItemsPost obj, CancellationToken cancellationToken = default)
        {
            CheckJsonTextWriter(jsonWriter);
            await jsonWriter.WriteStartObjectAsync(cancellationToken).ConfigureAwait(false);
            await WriteHiddenItemsPostObjectAsync(jsonWriter, obj, cancellationToken).ConfigureAwait(false);
            await jsonWriter.WriteEndObjectAsync(cancellationToken).ConfigureAwait(false);
        }

        protected virtual async Task WriteHiddenItemsPostObjectAsync(JsonTextWriter jsonWriter, TUserHiddenItemsPost obj, CancellationToken cancellationToken = default)
        {
            if (obj.Movies != null)
            {
                var hiddenItemsPostMovieArrayJsonWriter = new ArrayJsonWriter<ITraktUserHiddenItemsPostMovie>();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_MOVIES, cancellationToken).ConfigureAwait(false);
                await hiddenItemsPostMovieArrayJsonWriter.WriteArrayAsync(jsonWriter, obj.Movies, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Shows != null)
            {
                var hiddenItemsPostShowArrayJsonWriter = new ArrayJsonWriter<ITraktUserHiddenItemsPostShow>();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_SHOWS, cancellationToken).ConfigureAwait(false);
                await hiddenItemsPostShowArrayJsonWriter.WriteArrayAsync(jsonWriter, obj.Shows, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Seasons != null)
            {
                var hiddenItemsPostSeasonArrayJsonWriter = new ArrayJsonWriter<ITraktUserHiddenItemsPostSeason>();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_SEASONS, cancellationToken).ConfigureAwait(false);
                await hiddenItemsPostSeasonArrayJsonWriter.WriteArrayAsync(jsonWriter, obj.Seasons, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Users != null)
            {
                var hiddenItemsPostUserArrayJsonWriter = new ArrayJsonWriter<ITraktUser>();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.PROPERTY_NAME_USERS, cancellationToken).ConfigureAwait(false);
                await hiddenItemsPostUserArrayJsonWriter.WriteArrayAsync(jsonWriter, obj.Users, cancellationToken).ConfigureAwait(false);
            }
        }
    }
}

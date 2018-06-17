namespace TraktApiSharp.Objects.Post.Users.HiddenItems.Responses.Json.Writer
{
    using Newtonsoft.Json;
    using Objects.Json;
    using Post.Responses;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    internal class UserHiddenItemsPostResponseNotFoundGroupObjectJsonWriter : AObjectJsonWriter<ITraktUserHiddenItemsPostResponseNotFoundGroup>
    {
        public override async Task WriteObjectAsync(JsonTextWriter jsonWriter, ITraktUserHiddenItemsPostResponseNotFoundGroup obj, CancellationToken cancellationToken = default)
        {
            if (jsonWriter == null)
                throw new ArgumentNullException(nameof(jsonWriter));

            await jsonWriter.WriteStartObjectAsync(cancellationToken).ConfigureAwait(false);

            if (obj.Movies != null)
            {
                var notFoundMovieArrayJsonWriter = new ArrayJsonWriter<ITraktPostResponseNotFoundMovie>();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.USER_HIDDEN_ITEMS_POST_RESPONSE_NOT_FOUND_GROUP_PROPERTY_NAME_MOVIES, cancellationToken).ConfigureAwait(false);
                await notFoundMovieArrayJsonWriter.WriteArrayAsync(jsonWriter, obj.Movies, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Shows != null)
            {
                var notFoundShowArrayJsonWriter = new ArrayJsonWriter<ITraktPostResponseNotFoundShow>();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.USER_HIDDEN_ITEMS_POST_RESPONSE_NOT_FOUND_GROUP_PROPERTY_NAME_SHOWS, cancellationToken).ConfigureAwait(false);
                await notFoundShowArrayJsonWriter.WriteArrayAsync(jsonWriter, obj.Shows, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Seasons != null)
            {
                var notFoundSeasonArrayJsonWriter = new ArrayJsonWriter<ITraktPostResponseNotFoundSeason>();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.USER_HIDDEN_ITEMS_POST_RESPONSE_NOT_FOUND_GROUP_PROPERTY_NAME_SEASONS, cancellationToken).ConfigureAwait(false);
                await notFoundSeasonArrayJsonWriter.WriteArrayAsync(jsonWriter, obj.Seasons, cancellationToken).ConfigureAwait(false);
            }

            await jsonWriter.WriteEndObjectAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}

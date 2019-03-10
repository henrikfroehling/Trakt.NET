namespace TraktNet.Objects.Post.Users.CustomListItems.Responses.Json.Writer
{
    using Newtonsoft.Json;
    using Objects.Json;
    using Post.Responses;
    using System.Threading;
    using System.Threading.Tasks;

    internal class UserCustomListItemsPostResponseNotFoundGroupObjectJsonWriter : AObjectJsonWriter<ITraktUserCustomListItemsPostResponseNotFoundGroup>
    {
        public override async Task WriteObjectAsync(JsonTextWriter jsonWriter, ITraktUserCustomListItemsPostResponseNotFoundGroup obj, CancellationToken cancellationToken = default)
        {
            CheckJsonTextWriter(jsonWriter);
            await jsonWriter.WriteStartObjectAsync(cancellationToken).ConfigureAwait(false);

            if (obj.Movies != null)
            {
                var notFoundMovieArrayJsonWriter = new ArrayJsonWriter<ITraktPostResponseNotFoundMovie>();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.USER_CUSTOM_LIST_ITEMS_POST_RESPONSE_NOT_FOUND_GROUP_PROPERTY_NAME_MOVIES, cancellationToken).ConfigureAwait(false);
                await notFoundMovieArrayJsonWriter.WriteArrayAsync(jsonWriter, obj.Movies, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Shows != null)
            {
                var notFoundShowArrayJsonWriter = new ArrayJsonWriter<ITraktPostResponseNotFoundShow>();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.USER_CUSTOM_LIST_ITEMS_POST_RESPONSE_NOT_FOUND_GROUP_PROPERTY_NAME_SHOWS, cancellationToken).ConfigureAwait(false);
                await notFoundShowArrayJsonWriter.WriteArrayAsync(jsonWriter, obj.Shows, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Seasons != null)
            {
                var notFoundSeasonArrayJsonWriter = new ArrayJsonWriter<ITraktPostResponseNotFoundSeason>();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.USER_CUSTOM_LIST_ITEMS_POST_RESPONSE_NOT_FOUND_GROUP_PROPERTY_NAME_SEASONS, cancellationToken).ConfigureAwait(false);
                await notFoundSeasonArrayJsonWriter.WriteArrayAsync(jsonWriter, obj.Seasons, cancellationToken).ConfigureAwait(false);
            }

            if (obj.Episodes != null)
            {
                var notFoundEpisodeArrayJsonWriter = new ArrayJsonWriter<ITraktPostResponseNotFoundEpisode>();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.USER_CUSTOM_LIST_ITEMS_POST_RESPONSE_NOT_FOUND_GROUP_PROPERTY_NAME_EPISODES, cancellationToken).ConfigureAwait(false);
                await notFoundEpisodeArrayJsonWriter.WriteArrayAsync(jsonWriter, obj.Episodes, cancellationToken).ConfigureAwait(false);
            }

            if (obj.People != null)
            {
                var notFoundPersonArrayJsonWriter = new ArrayJsonWriter<ITraktPostResponseNotFoundPerson>();
                await jsonWriter.WritePropertyNameAsync(JsonProperties.USER_CUSTOM_LIST_ITEMS_POST_RESPONSE_NOT_FOUND_GROUP_PROPERTY_NAME_PEOPLE, cancellationToken).ConfigureAwait(false);
                await notFoundPersonArrayJsonWriter.WriteArrayAsync(jsonWriter, obj.People, cancellationToken).ConfigureAwait(false);
            }

            await jsonWriter.WriteEndObjectAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}

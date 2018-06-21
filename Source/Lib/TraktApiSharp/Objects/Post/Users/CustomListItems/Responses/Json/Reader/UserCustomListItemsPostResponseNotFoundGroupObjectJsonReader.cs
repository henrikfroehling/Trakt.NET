namespace TraktNet.Objects.Post.Users.CustomListItems.Responses.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using Post.Responses.Json.Reader;
    using System.Threading;
    using System.Threading.Tasks;

    internal class UserCustomListItemsPostResponseNotFoundGroupObjectJsonReader : AObjectJsonReader<ITraktUserCustomListItemsPostResponseNotFoundGroup>
    {
        public override async Task<ITraktUserCustomListItemsPostResponseNotFoundGroup> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(ITraktUserCustomListItemsPostResponseNotFoundGroup));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                var notFoundMoviesReader = new PostResponseNotFoundMovieArrayJsonReader();
                var notFoundShowsReader = new PostResponseNotFoundShowArrayJsonReader();
                var notFoundSeasonsReader = new PostResponseNotFoundSeasonArrayJsonReader();
                var notFoundEpisodesReader = new PostResponseNotFoundEpisodeArrayJsonReader();
                var notFoundPeopleReader = new PostResponseNotFoundPersonArrayJsonReader();
                ITraktUserCustomListItemsPostResponseNotFoundGroup customListItemsPostResponseNotFoundGroup = new TraktUserCustomListItemsPostResponseNotFoundGroup();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.USER_CUSTOM_LIST_ITEMS_POST_RESPONSE_NOT_FOUND_GROUP_PROPERTY_NAME_MOVIES:
                            customListItemsPostResponseNotFoundGroup.Movies = await notFoundMoviesReader.ReadArrayAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.USER_CUSTOM_LIST_ITEMS_POST_RESPONSE_NOT_FOUND_GROUP_PROPERTY_NAME_SHOWS:
                            customListItemsPostResponseNotFoundGroup.Shows = await notFoundShowsReader.ReadArrayAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.USER_CUSTOM_LIST_ITEMS_POST_RESPONSE_NOT_FOUND_GROUP_PROPERTY_NAME_SEASONS:
                            customListItemsPostResponseNotFoundGroup.Seasons = await notFoundSeasonsReader.ReadArrayAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.USER_CUSTOM_LIST_ITEMS_POST_RESPONSE_NOT_FOUND_GROUP_PROPERTY_NAME_EPISODES:
                            customListItemsPostResponseNotFoundGroup.Episodes = await notFoundEpisodesReader.ReadArrayAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.USER_CUSTOM_LIST_ITEMS_POST_RESPONSE_NOT_FOUND_GROUP_PROPERTY_NAME_PEOPLE:
                            customListItemsPostResponseNotFoundGroup.People = await notFoundPeopleReader.ReadArrayAsync(jsonReader, cancellationToken);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return customListItemsPostResponseNotFoundGroup;
            }

            return await Task.FromResult(default(ITraktUserCustomListItemsPostResponseNotFoundGroup));
        }
    }
}

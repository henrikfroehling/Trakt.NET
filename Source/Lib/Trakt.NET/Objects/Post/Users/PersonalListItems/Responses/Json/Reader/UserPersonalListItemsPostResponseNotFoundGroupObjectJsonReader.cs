namespace TraktNet.Objects.Post.Users.PersonalListItems.Responses.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using Post.Responses;
    using System.Threading;
    using System.Threading.Tasks;

    internal class UserPersonalListItemsPostResponseNotFoundGroupObjectJsonReader : AObjectJsonReader<ITraktUserPersonalListItemsPostResponseNotFoundGroup>
    {
        public override async Task<ITraktUserPersonalListItemsPostResponseNotFoundGroup> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            CheckJsonTextReader(jsonReader);

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                var notFoundMoviesReader = new ArrayJsonReader<ITraktPostResponseNotFoundMovie>();
                var notFoundShowsReader = new ArrayJsonReader<ITraktPostResponseNotFoundShow>();
                var notFoundSeasonsReader = new ArrayJsonReader<ITraktPostResponseNotFoundSeason>();
                var notFoundEpisodesReader = new ArrayJsonReader<ITraktPostResponseNotFoundEpisode>();
                var notFoundPeopleReader = new ArrayJsonReader<ITraktPostResponseNotFoundPerson>();
                ITraktUserPersonalListItemsPostResponseNotFoundGroup customListItemsPostResponseNotFoundGroup = new TraktUserPersonalListItemsPostResponseNotFoundGroup();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.PROPERTY_NAME_MOVIES:
                            customListItemsPostResponseNotFoundGroup.Movies = await notFoundMoviesReader.ReadArrayAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_SHOWS:
                            customListItemsPostResponseNotFoundGroup.Shows = await notFoundShowsReader.ReadArrayAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_SEASONS:
                            customListItemsPostResponseNotFoundGroup.Seasons = await notFoundSeasonsReader.ReadArrayAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_EPISODES:
                            customListItemsPostResponseNotFoundGroup.Episodes = await notFoundEpisodesReader.ReadArrayAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_PEOPLE:
                            customListItemsPostResponseNotFoundGroup.People = await notFoundPeopleReader.ReadArrayAsync(jsonReader, cancellationToken);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return customListItemsPostResponseNotFoundGroup;
            }

            return await Task.FromResult(default(ITraktUserPersonalListItemsPostResponseNotFoundGroup));
        }
    }
}

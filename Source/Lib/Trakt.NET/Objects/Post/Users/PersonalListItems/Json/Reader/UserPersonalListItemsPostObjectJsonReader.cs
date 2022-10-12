namespace TraktNet.Objects.Post.Users.PersonalListItems.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class UserPersonalListItemsPostObjectJsonReader : AObjectJsonReader<ITraktUserPersonalListItemsPost>
    {
        public override async Task<ITraktUserPersonalListItemsPost> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            CheckJsonTextReader(jsonReader);

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                var movieArrayJsonReader = new ArrayJsonReader<ITraktUserPersonalListItemsPostMovie>();
                var showArrayJsonReader = new ArrayJsonReader<ITraktUserPersonalListItemsPostShow>();
                var seasonArrayJsonReader = new ArrayJsonReader<ITraktUserPersonalListItemsPostSeason>();
                var episodeArrayJsonReader = new ArrayJsonReader<ITraktUserPersonalListItemsPostEpisode>();
                var personArrayJsonReader = new ArrayJsonReader<ITraktUserPersonalListItemsPostPerson>();
                ITraktUserPersonalListItemsPost customListItemsPost = new TraktUserPersonalListItemsPost();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.PROPERTY_NAME_MOVIES:
                            customListItemsPost.Movies = await movieArrayJsonReader.ReadArrayAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_SHOWS:
                            customListItemsPost.Shows = await showArrayJsonReader.ReadArrayAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_SEASONS:
                            customListItemsPost.Seasons = await seasonArrayJsonReader.ReadArrayAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_EPISODES:
                            customListItemsPost.Episodes = await episodeArrayJsonReader.ReadArrayAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_PEOPLE:
                            customListItemsPost.People = await personArrayJsonReader.ReadArrayAsync(jsonReader, cancellationToken);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return customListItemsPost;
            }

            return await Task.FromResult(default(ITraktUserPersonalListItemsPost));
        }
    }
}

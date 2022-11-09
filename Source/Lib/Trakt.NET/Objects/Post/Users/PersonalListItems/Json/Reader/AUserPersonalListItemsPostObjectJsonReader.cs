namespace TraktNet.Objects.Post.Users.PersonalListItems.Json.Reader
{
    using Newtonsoft.Json;
    using System.Threading;
    using System.Threading.Tasks;
    using TraktNet.Objects.Json;

    internal abstract class AUserPersonalListItemsPostObjectJsonReader<TUserListItemsPost> : AObjectJsonReader<TUserListItemsPost>
        where TUserListItemsPost : ITraktUserPersonalListItemsPost
    {
        public override async Task<TUserListItemsPost> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            CheckJsonTextReader(jsonReader);

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                TUserListItemsPost personalListItemsPost = CreateInstance();
                var movieArrayJsonReader = new ArrayJsonReader<ITraktUserPersonalListItemsPostMovie>();
                var showArrayJsonReader = new ArrayJsonReader<ITraktUserPersonalListItemsPostShow>();
                var seasonArrayJsonReader = new ArrayJsonReader<ITraktUserPersonalListItemsPostSeason>();
                var episodeArrayJsonReader = new ArrayJsonReader<ITraktUserPersonalListItemsPostEpisode>();
                var personArrayJsonReader = new ArrayJsonReader<ITraktUserPersonalListItemsPostPerson>();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.PROPERTY_NAME_MOVIES:
                            personalListItemsPost.Movies = await movieArrayJsonReader.ReadArrayAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_SHOWS:
                            personalListItemsPost.Shows = await showArrayJsonReader.ReadArrayAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_SEASONS:
                            personalListItemsPost.Seasons = await seasonArrayJsonReader.ReadArrayAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_EPISODES:
                            personalListItemsPost.Episodes = await episodeArrayJsonReader.ReadArrayAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_PEOPLE:
                            personalListItemsPost.People = await personArrayJsonReader.ReadArrayAsync(jsonReader, cancellationToken);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return personalListItemsPost;
            }

            return await Task.FromResult(default(TUserListItemsPost));
        }

        protected abstract TUserListItemsPost CreateInstance();
    }
}

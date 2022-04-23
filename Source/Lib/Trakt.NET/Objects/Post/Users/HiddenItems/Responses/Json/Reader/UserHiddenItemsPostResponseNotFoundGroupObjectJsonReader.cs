namespace TraktNet.Objects.Post.Users.HiddenItems.Responses.Json.Reader
{
    using Get.Users;
    using Newtonsoft.Json;
    using Objects.Json;
    using Post.Responses;
    using System.Threading;
    using System.Threading.Tasks;

    internal class UserHiddenItemsPostResponseNotFoundGroupObjectJsonReader : AObjectJsonReader<ITraktUserHiddenItemsPostResponseNotFoundGroup>
    {
        public override async Task<ITraktUserHiddenItemsPostResponseNotFoundGroup> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            CheckJsonTextReader(jsonReader);

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                var notFoundMoviesReader = new ArrayJsonReader<ITraktPostResponseNotFoundMovie>();
                var notFoundShowsReader = new ArrayJsonReader<ITraktPostResponseNotFoundShow>();
                var notFoundSeasonsReader = new ArrayJsonReader<ITraktPostResponseNotFoundSeason>();
                var notFoundUsersReader = new ArrayJsonReader<ITraktUser>();
                ITraktUserHiddenItemsPostResponseNotFoundGroup hiddenItemsPostResponseNotFoundGroup = new TraktUserHiddenItemsPostResponseNotFoundGroup();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.PROPERTY_NAME_MOVIES:
                            hiddenItemsPostResponseNotFoundGroup.Movies = await notFoundMoviesReader.ReadArrayAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_SHOWS:
                            hiddenItemsPostResponseNotFoundGroup.Shows = await notFoundShowsReader.ReadArrayAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_SEASONS:
                            hiddenItemsPostResponseNotFoundGroup.Seasons = await notFoundSeasonsReader.ReadArrayAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_USERS:
                            hiddenItemsPostResponseNotFoundGroup.Users = await notFoundUsersReader.ReadArrayAsync(jsonReader, cancellationToken);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return hiddenItemsPostResponseNotFoundGroup;
            }

            return await Task.FromResult(default(ITraktUserHiddenItemsPostResponseNotFoundGroup));
        }
    }
}

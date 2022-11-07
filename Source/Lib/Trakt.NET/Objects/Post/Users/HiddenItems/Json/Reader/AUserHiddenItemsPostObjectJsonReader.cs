namespace TraktNet.Objects.Post.Users.HiddenItems.Json.Reader
{
    using Newtonsoft.Json;
    using System.Threading;
    using System.Threading.Tasks;
    using TraktNet.Objects.Get.Users;
    using TraktNet.Objects.Json;

    internal abstract class AUserHiddenItemsPostObjectJsonReader<TUserHiddenItemsPost> : AObjectJsonReader<TUserHiddenItemsPost>
        where TUserHiddenItemsPost : ITraktUserHiddenItemsPost
    {
        public override async Task<TUserHiddenItemsPost> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            CheckJsonTextReader(jsonReader);

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                TUserHiddenItemsPost hiddenItemsPost = CreateInstance();
                var movieArrayJsonReader = new ArrayJsonReader<ITraktUserHiddenItemsPostMovie>();
                var showArrayJsonReader = new ArrayJsonReader<ITraktUserHiddenItemsPostShow>();
                var seasonArrayJsonReader = new ArrayJsonReader<ITraktUserHiddenItemsPostSeason>();
                var userArrayJsonReader = new ArrayJsonReader<ITraktUser>();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.PROPERTY_NAME_MOVIES:
                            hiddenItemsPost.Movies = await movieArrayJsonReader.ReadArrayAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_SHOWS:
                            hiddenItemsPost.Shows = await showArrayJsonReader.ReadArrayAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_SEASONS:
                            hiddenItemsPost.Seasons = await seasonArrayJsonReader.ReadArrayAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_USERS:
                            hiddenItemsPost.Users = await userArrayJsonReader.ReadArrayAsync(jsonReader, cancellationToken);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return hiddenItemsPost;
            }

            return await Task.FromResult(default(TUserHiddenItemsPost));
        }

        protected abstract TUserHiddenItemsPost CreateInstance();
    }
}

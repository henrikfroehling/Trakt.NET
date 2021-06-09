namespace TraktNet.Objects.Get.Users.Lists.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;
    using Users.Json.Reader;

    internal class ListLikeObjectJsonReader : AObjectJsonReader<ITraktListLike>
    {
        public override async Task<ITraktListLike> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            CheckJsonTextReader(jsonReader);

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                var userReader = new UserObjectJsonReader();

                ITraktListLike traktListLike = new TraktListLike();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.PROPERTY_NAME_LIKED_AT:
                            {
                                var value = await JsonReaderHelper.ReadDateTimeValueAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    traktListLike.LikedAt = value.Second;

                                break;
                            }
                        case JsonProperties.PROPERTY_NAME_USER:
                            traktListLike.User = await userReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return traktListLike;
            }

            return await Task.FromResult(default(ITraktListLike));
        }
    }
}

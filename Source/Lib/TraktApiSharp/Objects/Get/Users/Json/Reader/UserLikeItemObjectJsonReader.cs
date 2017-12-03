namespace TraktApiSharp.Objects.Get.Users.Json.Reader
{
    using Basic.Json;
    using Basic.Json.Reader;
    using Enums;
    using Implementations;
    using Lists.Json;
    using Lists.Json.Reader;
    using Newtonsoft.Json;
    using Objects.Json;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    internal class UserLikeItemObjectJsonReader : IObjectJsonReader<ITraktUserLikeItem>
    {
        public Task<ITraktUserLikeItem> ReadObjectAsync(string json, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrEmpty(json))
                return Task.FromResult(default(ITraktUserLikeItem));

            using (var reader = new StringReader(json))
            using (var jsonReader = new JsonTextReader(reader))
            {
                return ReadObjectAsync(jsonReader, cancellationToken);
            }
        }

        public Task<ITraktUserLikeItem> ReadObjectAsync(Stream stream, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (stream == null)
                return Task.FromResult(default(ITraktUserLikeItem));

            using (var streamReader = new StreamReader(stream))
            using (var jsonReader = new JsonTextReader(streamReader))
            {
                return ReadObjectAsync(jsonReader, cancellationToken);
            }
        }

        public async Task<ITraktUserLikeItem> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (jsonReader == null)
                return await Task.FromResult(default(ITraktUserLikeItem));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                var commentReader = new CommentObjectJsonReader();
                var listReader = new ListObjectJsonReader();
                ITraktUserLikeItem traktUserLikeItem = new TraktUserLikeItem();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.USER_LIKE_ITEM_PROPERTY_NAME_LIKED_AT:
                            {
                                var value = await JsonReaderHelper.ReadDateTimeValueAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    traktUserLikeItem.LikedAt = value.Second;

                                break;
                            }
                        case JsonProperties.USER_LIKE_ITEM_PROPERTY_NAME_TYPE:
                            traktUserLikeItem.Type = await JsonReaderHelper.ReadEnumerationValueAsync<TraktUserLikeType>(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.USER_LIKE_ITEM_PROPERTY_NAME_COMMENT:
                            traktUserLikeItem.Comment = await commentReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.USER_LIKE_ITEM_PROPERTY_NAME_LIST:
                            traktUserLikeItem.List = await listReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return traktUserLikeItem;
            }

            return await Task.FromResult(default(ITraktUserLikeItem));
        }
    }
}

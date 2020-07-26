namespace TraktNet.Objects.Get.Users.Json.Reader
{
    using Basic.Json.Reader;
    using Enums;
    using Lists.Json.Reader;
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class UserLikeItemObjectJsonReader : AObjectJsonReader<ITraktUserLikeItem>
    {
        public override async Task<ITraktUserLikeItem> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
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
                        case JsonProperties.PROPERTY_NAME_LIKED_AT:
                            {
                                var value = await JsonReaderHelper.ReadDateTimeValueAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    traktUserLikeItem.LikedAt = value.Second;

                                break;
                            }
                        case JsonProperties.PROPERTY_NAME_TYPE:
                            traktUserLikeItem.Type = await JsonReaderHelper.ReadEnumerationValueAsync<TraktUserLikeType>(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_COMMENT:
                            traktUserLikeItem.Comment = await commentReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_LIST:
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

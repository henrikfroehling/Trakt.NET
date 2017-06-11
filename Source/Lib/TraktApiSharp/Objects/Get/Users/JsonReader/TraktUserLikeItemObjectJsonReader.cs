namespace TraktApiSharp.Objects.Get.Users.JsonReader
{
    using Basic.JsonReader;
    using Enums;
    using Implementations;
    using Lists.JsonReader;
    using Newtonsoft.Json;
    using Objects.JsonReader;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    internal class TraktUserLikeItemObjectJsonReader : ITraktObjectJsonReader<ITraktUserLikeItem>
    {
        private const string PROPERTY_NAME_LIKED_AT = "liked_at";
        private const string PROPERTY_NAME_TYPE = "type";
        private const string PROPERTY_NAME_COMMENT = "comment";
        private const string PROPERTY_NAME_LIST = "list";

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
                var commentReader = new TraktCommentObjectJsonReader();
                var listReader = new TraktListObjectJsonReader();
                ITraktUserLikeItem traktUserLikeItem = new TraktUserLikeItem();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case PROPERTY_NAME_LIKED_AT:
                            {
                                var value = await JsonReaderHelper.ReadDateTimeValueAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    traktUserLikeItem.LikedAt = value.Second;

                                break;
                            }
                        case PROPERTY_NAME_TYPE:
                            traktUserLikeItem.Type = await JsonReaderHelper.ReadEnumerationValueAsync<TraktUserLikeType>(jsonReader, cancellationToken);
                            break;
                        case PROPERTY_NAME_COMMENT:
                            traktUserLikeItem.Comment = await commentReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        case PROPERTY_NAME_LIST:
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

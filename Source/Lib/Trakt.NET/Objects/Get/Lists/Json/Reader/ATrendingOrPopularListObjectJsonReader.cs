namespace TraktNet.Objects.Get.Lists.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal abstract class ATrendingOrPopularListObjectJsonReader<TListObjectType> : AObjectJsonReader<TListObjectType> where TListObjectType : ITraktTrendingOrPopularList
    {
        private readonly ListObjectJsonReader listObjectReader = new ListObjectJsonReader();

        public override async Task<TListObjectType> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            CheckJsonTextReader(jsonReader);

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                TListObjectType movie = CreateListObject();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();
                    await ReadPropertyAsync(jsonReader, movie, propertyName, cancellationToken);
                }

                return movie;
            }

            return await Task.FromResult(default(TListObjectType));
        }

        protected virtual async Task ReadPropertyAsync(JsonTextReader jsonReader, TListObjectType list, string propertyName, CancellationToken cancellationToken = default)
        {
            switch (propertyName)
            {
                case JsonProperties.PROPERTY_NAME_LIKE_COUNT:
                    list.LikeCount = await jsonReader.ReadAsInt32Async(cancellationToken);
                    break;
                case JsonProperties.PROPERTY_NAME_COMMENT_COUNT:
                    list.CommentCount = await jsonReader.ReadAsInt32Async(cancellationToken);
                    break;
                case JsonProperties.PROPERTY_NAME_LIST:
                    list.List = await listObjectReader.ReadObjectAsync(jsonReader, cancellationToken);
                    break;
                default:
                    await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                    break;
            }
        }

        protected abstract TListObjectType CreateListObject();
    }
}

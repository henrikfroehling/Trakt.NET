namespace TraktNet.Objects.Post.Syncs.Lists.Json.Reader
{
    using Enums;
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal sealed class UpdateListPostObjectJsonReader : AObjectJsonReader<ITraktUpdateListPost>
    {
        public override async Task<ITraktUpdateListPost> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            CheckJsonTextReader(jsonReader);

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject) {
                ITraktUpdateListPost updateListPost = new TraktUpdateListPost();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName) {
                    string propertyName = jsonReader.Value.ToString();

                    switch (propertyName) {
                        case JsonProperties.PROPERTY_NAME_DESCRIPTION:
                            updateListPost.Description = await jsonReader.ReadAsStringAsync(cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_SORT_BY:
                            updateListPost.SortBy = await JsonReaderHelper.ReadEnumerationValueAsync<TraktSortBy>(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_SORT_HOW:
                            updateListPost.SortHow = await JsonReaderHelper.ReadEnumerationValueAsync<TraktSortHow>(jsonReader, cancellationToken);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return updateListPost;
            }

            return await Task.FromResult(default(ITraktUpdateListPost));
        }
    }
}

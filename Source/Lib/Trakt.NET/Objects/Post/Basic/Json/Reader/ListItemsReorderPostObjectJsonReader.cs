namespace TraktNet.Objects.Post.Basic.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class ListItemsReorderPostObjectJsonReader : AObjectJsonReader<ITraktListItemsReorderPost>
    {
        public override async Task<ITraktListItemsReorderPost> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            CheckJsonTextReader(jsonReader);

            if (await jsonReader.ReadAsync(cancellationToken).ConfigureAwait(false) && jsonReader.TokenType == JsonToken.StartObject)
            {
                ITraktListItemsReorderPost listItemsReorderPost = new TraktListItemsReorderPost();

                while (await jsonReader.ReadAsync(cancellationToken).ConfigureAwait(false) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.PROPERTY_NAME_RANK:
                            listItemsReorderPost.Rank = await JsonReaderHelper.ReadUnsignedIntegerArrayAsync(jsonReader, cancellationToken).ConfigureAwait(false);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken).ConfigureAwait(false);
                            break;
                    }
                }

                return listItemsReorderPost;
            }

            return await Task.FromResult(default(ITraktListItemsReorderPost)).ConfigureAwait(false);
        }
    }
}

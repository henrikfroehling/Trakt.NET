namespace TraktNet.Objects.Post.Basic.Responses.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using Objects.Post.Responses.Json.Reader;
    using System.Threading;
    using System.Threading.Tasks;

    internal class ListItemsReorderPostResponseObjectJsonReader : AObjectJsonReader<ITraktListItemsReorderPostResponse>
    {
        public override async Task<ITraktListItemsReorderPostResponse> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            CheckJsonTextReader(jsonReader);

            if (await jsonReader.ReadAsync(cancellationToken).ConfigureAwait(false) && jsonReader.TokenType == JsonToken.StartObject)
            {
                var listDataReader = new PostResponseListDataObjectJsonReader();
                ITraktListItemsReorderPostResponse listsReorderPostResponse = new TraktListItemsReorderPostResponse();

                while (await jsonReader.ReadAsync(cancellationToken).ConfigureAwait(false) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.PROPERTY_NAME_UPDATED:
                            listsReorderPostResponse.Updated = await jsonReader.ReadAsInt32Async(cancellationToken).ConfigureAwait(false);
                            break;
                        case JsonProperties.PROPERTY_NAME_SKIPPED_IDS:
                            listsReorderPostResponse.SkippedIds = await JsonReaderHelper.ReadUnsignedIntegerArrayAsync(jsonReader, cancellationToken).ConfigureAwait(false);
                            break;
                        case JsonProperties.PROPERTY_NAME_LIST:
                            listsReorderPostResponse.List = await listDataReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken).ConfigureAwait(false);
                            break;
                    }
                }

                return listsReorderPostResponse;
            }

            return await Task.FromResult(default(ITraktListItemsReorderPostResponse)).ConfigureAwait(false);
        }
    }
}

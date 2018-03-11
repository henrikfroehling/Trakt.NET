namespace TraktApiSharp.Objects.Get.Users.Lists.Json.Reader
{
    using Implementations;
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class ListIdsObjectJsonReader : AObjectJsonReader<ITraktListIds>
    {
        public override async Task<ITraktListIds> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(ITraktListIds));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                ITraktListIds traktListIds = new TraktListIds();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.LIST_IDS_PROPERTY_NAME_TRAKT:
                            {
                                var value = await JsonReaderHelper.ReadUnsignedIntegerValueAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    traktListIds.Trakt = value.Second;

                                break;
                            }
                        case JsonProperties.LIST_IDS_PROPERTY_NAME_SLUG:
                            traktListIds.Slug = jsonReader.ReadAsString();
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return traktListIds;
            }

            return await Task.FromResult(default(ITraktListIds));
        }
    }
}

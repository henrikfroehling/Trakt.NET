namespace TraktNet.Objects.Get.Collections.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using Shows.Json.Reader;
    using System.Threading;
    using System.Threading.Tasks;

    internal class CollectionShowObjectJsonReader : AObjectJsonReader<ITraktCollectionShow>
    {
        public override async Task<ITraktCollectionShow> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            CheckJsonTextReader(jsonReader);

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                var showObjectReader = new ShowObjectJsonReader();
                var showSeasonsArrayReader = new ArrayJsonReader<ITraktCollectionShowSeason>();

                ITraktCollectionShow traktCollectionShow = new TraktCollectionShow();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.PROPERTY_NAME_LAST_COLLECTED_AT:
                            {
                                var value = await JsonReaderHelper.ReadDateTimeValueAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    traktCollectionShow.LastCollectedAt = value.Second;

                                break;
                            }
                        case JsonProperties.PROPERTY_NAME_LAST_UPDATED_AT:
                            {
                                var value = await JsonReaderHelper.ReadDateTimeValueAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    traktCollectionShow.LastUpdatedAt = value.Second;

                                break;
                            }
                        case JsonProperties.PROPERTY_NAME_SHOW:
                            traktCollectionShow.Show = await showObjectReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.PROPERTY_NAME_SEASONS:
                            traktCollectionShow.CollectionSeasons = await showSeasonsArrayReader.ReadArrayAsync(jsonReader, cancellationToken);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return traktCollectionShow;
            }

            return await Task.FromResult(default(ITraktCollectionShow));
        }
    }
}

namespace TraktApiSharp.Objects.Get.Collections.Json.Reader
{
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class CollectionShowSeasonObjectJsonReader : AObjectJsonReader<ITraktCollectionShowSeason>
    {
        public override async Task<ITraktCollectionShowSeason> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
        {
            if (jsonReader == null)
                return await Task.FromResult(default(ITraktCollectionShowSeason));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                var collectionShowEpisodeArrayReader = new CollectionShowEpisodeArrayJsonReader();

                ITraktCollectionShowSeason traktCollectionShowSeason = new TraktCollectionShowSeason();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case JsonProperties.COLLECTION_SHOW_SEASON_PROPERTY_NAME_NUMBER:
                            traktCollectionShowSeason.Number = await jsonReader.ReadAsInt32Async(cancellationToken);
                            break;
                        case JsonProperties.COLLECTION_SHOW_SEASON_PROPERTY_NAME_EPISODES:
                            traktCollectionShowSeason.Episodes = await collectionShowEpisodeArrayReader.ReadArrayAsync(jsonReader, cancellationToken);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return traktCollectionShowSeason;
            }

            return await Task.FromResult(default(ITraktCollectionShowSeason));
        }
    }
}

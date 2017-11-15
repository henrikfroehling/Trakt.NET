namespace TraktApiSharp.Objects.Get.Collections.Json
{
    using Implementations;
    using Newtonsoft.Json;
    using Objects.Json;
    using Shows.Json;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    internal class CollectionShowObjectJsonReader : IObjectJsonReader<ITraktCollectionShow>
    {
        private const string PROPERTY_NAME_LAST_COLLECTED_AT = "last_collected_at";
        private const string PROPERTY_NAME_SHOW = "show";
        private const string PROPERTY_NAME_SEASONS = "seasons";

        public Task<ITraktCollectionShow> ReadObjectAsync(string json, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrEmpty(json))
                return Task.FromResult(default(ITraktCollectionShow));

            using (var reader = new StringReader(json))
            using (var jsonReader = new JsonTextReader(reader))
            {
                return ReadObjectAsync(jsonReader, cancellationToken);
            }
        }

        public Task<ITraktCollectionShow> ReadObjectAsync(Stream stream, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (stream == null)
                return Task.FromResult(default(ITraktCollectionShow));

            using (var streamReader = new StreamReader(stream))
            using (var jsonReader = new JsonTextReader(streamReader))
            {
                return ReadObjectAsync(jsonReader, cancellationToken);
            }
        }

        public async Task<ITraktCollectionShow> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (jsonReader == null)
                return await Task.FromResult(default(ITraktCollectionShow));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                var showObjectReader = new ShowObjectJsonReader();
                var showSeasonsArrayReader = new CollectionShowSeasonArrayJsonReader();

                ITraktCollectionShow traktCollectionShow = new TraktCollectionShow();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case PROPERTY_NAME_LAST_COLLECTED_AT:
                            {
                                var value = await JsonReaderHelper.ReadDateTimeValueAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    traktCollectionShow.LastCollectedAt = value.Second;

                                break;
                            }
                        case PROPERTY_NAME_SHOW:
                            traktCollectionShow.Show = await showObjectReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        case PROPERTY_NAME_SEASONS:
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

namespace TraktApiSharp.Objects.Get.Shows.JsonReader
{
    using Implementations;
    using Newtonsoft.Json;
    using Objects.JsonReader;
    using Shows;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    internal class TraktTrendingShowObjectJsonReader : ITraktObjectJsonReader<ITraktTrendingShow>
    {
        private const string PROPERTY_NAME_WATCHERS = "watchers";
        private const string PROPERTY_NAME_SHOW = "show";

        public Task<ITraktTrendingShow> ReadObjectAsync(string json, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrEmpty(json))
                return Task.FromResult(default(ITraktTrendingShow));

            using (var reader = new StringReader(json))
            using (var jsonReader = new JsonTextReader(reader))
            {
                return ReadObjectAsync(jsonReader, cancellationToken);
            }
        }

        public Task<ITraktTrendingShow> ReadObjectAsync(Stream stream, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (stream == null)
                return Task.FromResult(default(ITraktTrendingShow));

            using (var streamReader = new StreamReader(stream))
            using (var jsonReader = new JsonTextReader(streamReader))
            {
                return ReadObjectAsync(jsonReader, cancellationToken);
            }
        }

        public async Task<ITraktTrendingShow> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (jsonReader == null)
                return await Task.FromResult(default(ITraktTrendingShow));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                var showObjectReader = new TraktShowObjectJsonReader();
                ITraktTrendingShow traktTrendingShow = new TraktTrendingShow();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case PROPERTY_NAME_WATCHERS:
                            traktTrendingShow.Watchers = await jsonReader.ReadAsInt32Async(cancellationToken);
                            break;
                        case PROPERTY_NAME_SHOW:
                            traktTrendingShow.Show = await showObjectReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return traktTrendingShow;
            }

            return await Task.FromResult(default(ITraktTrendingShow));
        }
    }
}

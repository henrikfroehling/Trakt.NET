namespace TraktApiSharp.Objects.Get.Shows.Json
{
    using Implementations;
    using Newtonsoft.Json;
    using Objects.Json;
    using Shows;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    internal class RecentlyUpdatedShowObjectJsonReader : IObjectJsonReader<ITraktRecentlyUpdatedShow>
    {
        private const string PROPERTY_NAME_UPDATED_AT = "updated_at";
        private const string PROPERTY_NAME_SHOW = "show";

        public Task<ITraktRecentlyUpdatedShow> ReadObjectAsync(string json, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrEmpty(json))
                return Task.FromResult(default(ITraktRecentlyUpdatedShow));

            using (var reader = new StringReader(json))
            using (var jsonReader = new JsonTextReader(reader))
            {
                return ReadObjectAsync(jsonReader, cancellationToken);
            }
        }

        public Task<ITraktRecentlyUpdatedShow> ReadObjectAsync(Stream stream, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (stream == null)
                return Task.FromResult(default(ITraktRecentlyUpdatedShow));

            using (var streamReader = new StreamReader(stream))
            using (var jsonReader = new JsonTextReader(streamReader))
            {
                return ReadObjectAsync(jsonReader, cancellationToken);
            }
        }

        public async Task<ITraktRecentlyUpdatedShow> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (jsonReader == null)
                return await Task.FromResult(default(ITraktRecentlyUpdatedShow));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                var showObjectReader = new ShowObjectJsonReader();
                ITraktRecentlyUpdatedShow traktRecentlyUpdatedShow = new TraktRecentlyUpdatedShow();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case PROPERTY_NAME_UPDATED_AT:
                            {
                                var value = await JsonReaderHelper.ReadDateTimeValueAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    traktRecentlyUpdatedShow.RecentlyUpdatedAt = value.Second;

                                break;
                            }
                        case PROPERTY_NAME_SHOW:
                            traktRecentlyUpdatedShow.Show = await showObjectReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return traktRecentlyUpdatedShow;
            }

            return await Task.FromResult(default(ITraktRecentlyUpdatedShow));
        }
    }
}

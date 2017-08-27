namespace TraktApiSharp.Objects.Post.Checkins.Responses.JsonReader
{
    using Basic.JsonReader;
    using Get.Episodes.JsonReader;
    using Get.Shows.JsonReader;
    using Implementations;
    using Newtonsoft.Json;
    using Objects.JsonReader;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    internal class TraktEpisodeCheckinPostResponseObjectJsonReader : IObjectJsonReader<ITraktEpisodeCheckinPostResponse>
    {
        private const string PROPERTY_NAME_ID = "id";
        private const string PROPERTY_NAME_WATCHED_AT = "watched_at";
        private const string PROPERTY_NAME_SHARING = "sharing";
        private const string PROPERTY_NAME_EPISODE = "episode";
        private const string PROPERTY_NAME_SHOW = "show";

        public Task<ITraktEpisodeCheckinPostResponse> ReadObjectAsync(string json, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrEmpty(json))
                return Task.FromResult(default(ITraktEpisodeCheckinPostResponse));

            using (var reader = new StringReader(json))
            using (var jsonReader = new JsonTextReader(reader))
            {
                return ReadObjectAsync(jsonReader, cancellationToken);
            }
        }

        public Task<ITraktEpisodeCheckinPostResponse> ReadObjectAsync(Stream stream, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (stream == null)
                return Task.FromResult(default(ITraktEpisodeCheckinPostResponse));

            using (var streamReader = new StreamReader(stream))
            using (var jsonReader = new JsonTextReader(streamReader))
            {
                return ReadObjectAsync(jsonReader, cancellationToken);
            }
        }

        public async Task<ITraktEpisodeCheckinPostResponse> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (jsonReader == null)
                return await Task.FromResult(default(ITraktEpisodeCheckinPostResponse));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                var sharingReader = new SharingObjectJsonReader();
                var episodeReader = new TraktEpisodeObjectJsonReader();
                var showReader = new TraktShowObjectJsonReader();
                ITraktEpisodeCheckinPostResponse checkinEpisodeResponse = new TraktEpisodeCheckinPostResponse();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case PROPERTY_NAME_ID:
                            {
                                var value = await JsonReaderHelper.ReadUnsignedLongIntegerAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    checkinEpisodeResponse.Id = value.Second;

                                break;
                            }
                        case PROPERTY_NAME_WATCHED_AT:
                            {
                                var value = await JsonReaderHelper.ReadDateTimeValueAsync(jsonReader, cancellationToken);

                                if (value.First)
                                    checkinEpisodeResponse.WatchedAt = value.Second;

                                break;
                            }
                        case PROPERTY_NAME_SHARING:
                            checkinEpisodeResponse.Sharing = await sharingReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        case PROPERTY_NAME_EPISODE:
                            checkinEpisodeResponse.Episode = await episodeReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        case PROPERTY_NAME_SHOW:
                            checkinEpisodeResponse.Show = await showReader.ReadObjectAsync(jsonReader, cancellationToken);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return checkinEpisodeResponse;
            }

            return await Task.FromResult(default(ITraktEpisodeCheckinPostResponse));
        }
    }
}

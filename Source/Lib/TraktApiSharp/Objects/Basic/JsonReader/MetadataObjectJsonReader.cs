namespace TraktApiSharp.Objects.Basic.JsonReader
{
    using Enums;
    using Implementations;
    using Newtonsoft.Json;
    using Objects.JsonReader;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    internal class MetadataObjectJsonReader : IObjectJsonReader<ITraktMetadata>
    {
        private const string PROPERTY_NAME_MEDIA_TYPE = "media_type";
        private const string PROPERTY_NAME_RESOLUTION = "resolution";
        private const string PROPERTY_NAME_AUDIO = "audio";
        private const string PROPERTY_NAME_AUDIO_CHANNELS = "audio_channels";
        private const string PROPERTY_NAME_3D = "3d";

        public Task<ITraktMetadata> ReadObjectAsync(string json, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (string.IsNullOrEmpty(json))
                return Task.FromResult(default(ITraktMetadata));

            using (var reader = new StringReader(json))
            using (var jsonReader = new JsonTextReader(reader))
            {
                return ReadObjectAsync(jsonReader, cancellationToken);
            }
        }

        public Task<ITraktMetadata> ReadObjectAsync(Stream stream, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (stream == null)
                return Task.FromResult(default(ITraktMetadata));

            using (var streamReader = new StreamReader(stream))
            using (var jsonReader = new JsonTextReader(streamReader))
            {
                return ReadObjectAsync(jsonReader, cancellationToken);
            }
        }

        public async Task<ITraktMetadata> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (jsonReader == null)
                return await Task.FromResult(default(ITraktMetadata));

            if (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.StartObject)
            {
                ITraktMetadata traktMetadata = new TraktMetadata();

                while (await jsonReader.ReadAsync(cancellationToken) && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case PROPERTY_NAME_MEDIA_TYPE:
                            traktMetadata.MediaType = await JsonReaderHelper.ReadEnumerationValueAsync<TraktMediaType>(jsonReader, cancellationToken);
                            break;
                        case PROPERTY_NAME_RESOLUTION:
                            traktMetadata.MediaResolution = await JsonReaderHelper.ReadEnumerationValueAsync<TraktMediaResolution>(jsonReader, cancellationToken);
                            break;
                        case PROPERTY_NAME_AUDIO:
                            traktMetadata.Audio = await JsonReaderHelper.ReadEnumerationValueAsync<TraktMediaAudio>(jsonReader, cancellationToken);
                            break;
                        case PROPERTY_NAME_AUDIO_CHANNELS:
                            traktMetadata.AudioChannels = await JsonReaderHelper.ReadEnumerationValueAsync<TraktMediaAudioChannel>(jsonReader, cancellationToken);
                            break;
                        case PROPERTY_NAME_3D:
                            traktMetadata.ThreeDimensional = await jsonReader.ReadAsBooleanAsync(cancellationToken);
                            break;
                        default:
                            await JsonReaderHelper.ReadAndIgnoreInvalidContentAsync(jsonReader, cancellationToken);
                            break;
                    }
                }

                return traktMetadata;
            }

            return await Task.FromResult(default(ITraktMetadata));
        }
    }
}

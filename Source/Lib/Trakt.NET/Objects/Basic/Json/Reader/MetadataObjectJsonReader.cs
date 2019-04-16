namespace TraktNet.Objects.Basic.Json.Reader
{
    using Enums;
    using Newtonsoft.Json;
    using Objects.Json;
    using System.Threading;
    using System.Threading.Tasks;

    internal class MetadataObjectJsonReader : AObjectJsonReader<ITraktMetadata>
    {
        public override async Task<ITraktMetadata> ReadObjectAsync(JsonTextReader jsonReader, CancellationToken cancellationToken = default)
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
                        case JsonProperties.METADATA_PROPERTY_NAME_MEDIA_TYPE:
                            traktMetadata.MediaType = await JsonReaderHelper.ReadEnumerationValueAsync<TraktMediaType>(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.METADATA_PROPERTY_NAME_RESOLUTION:
                            traktMetadata.MediaResolution = await JsonReaderHelper.ReadEnumerationValueAsync<TraktMediaResolution>(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.METADATA_PROPERTY_NAME_AUDIO:
                            traktMetadata.Audio = await JsonReaderHelper.ReadEnumerationValueAsync<TraktMediaAudio>(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.METADATA_PROPERTY_NAME_AUDIO_CHANNELS:
                            traktMetadata.AudioChannels = await JsonReaderHelper.ReadEnumerationValueAsync<TraktMediaAudioChannel>(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.METADATA_PROPERTY_NAME_HDR:
                            traktMetadata.HDR = await JsonReaderHelper.ReadEnumerationValueAsync<TraktMediaHDR>(jsonReader, cancellationToken);
                            break;
                        case JsonProperties.METADATA_PROPERTY_NAME_3D:
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

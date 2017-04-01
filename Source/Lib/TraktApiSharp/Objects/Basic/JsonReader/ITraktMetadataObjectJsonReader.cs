namespace TraktApiSharp.Objects.Basic.JsonReader
{
    using Enums;
    using Implementations;
    using Newtonsoft.Json;
    using Objects.JsonReader;
    using System.IO;

    internal class ITraktMetadataObjectJsonReader : ITraktObjectJsonReader<ITraktMetadata>
    {
        private const string PROPERTY_NAME_MEDIA_TYPE = "media_type";
        private const string PROPERTY_NAME_RESOLUTION = "resolution";
        private const string PROPERTY_NAME_AUDIO = "audio";
        private const string PROPERTY_NAME_AUDIO_CHANNELS = "audio_channels";
        private const string PROPERTY_NAME_3D = "3d";

        public ITraktMetadata ReadObject(string json)
        {
            if (string.IsNullOrEmpty(json))
                return null;

            using (var reader = new StringReader(json))
            using (var jsonReader = new JsonTextReader(reader))
            {
                return ReadObject(jsonReader);
            }
        }

        public ITraktMetadata ReadObject(JsonTextReader jsonReader)
        {
            if (jsonReader == null)
                return null;

            if (jsonReader.Read() && jsonReader.TokenType == JsonToken.StartObject)
            {
                ITraktMetadata traktMetadata = new TraktMetadata();

                while (jsonReader.Read() && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case PROPERTY_NAME_MEDIA_TYPE:
                            TraktMediaType mediaType = null;
                            JsonReaderHelper.ReadEnumerationValue(jsonReader, out mediaType);
                            traktMetadata.MediaType = mediaType;
                            break;
                        case PROPERTY_NAME_RESOLUTION:
                            TraktMediaResolution mediaResolution = null;
                            JsonReaderHelper.ReadEnumerationValue(jsonReader, out mediaResolution);
                            traktMetadata.MediaResolution = mediaResolution;
                            break;
                        case PROPERTY_NAME_AUDIO:
                            TraktMediaAudio mediaAudio = null;
                            JsonReaderHelper.ReadEnumerationValue(jsonReader, out mediaAudio);
                            traktMetadata.Audio = mediaAudio;
                            break;
                        case PROPERTY_NAME_AUDIO_CHANNELS:
                            TraktMediaAudioChannel mediaAudioChannel = null;
                            JsonReaderHelper.ReadEnumerationValue(jsonReader, out mediaAudioChannel);
                            traktMetadata.AudioChannels = mediaAudioChannel;
                            break;
                        case PROPERTY_NAME_3D:
                            traktMetadata.ThreeDimensional = jsonReader.ReadAsBoolean();
                            break;
                        default:
                            JsonReaderHelper.OverreadInvalidContent(jsonReader);
                            break;
                    }
                }

                return traktMetadata;
            }

            return null;
        }
    }
}

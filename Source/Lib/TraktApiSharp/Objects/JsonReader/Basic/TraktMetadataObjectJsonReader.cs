namespace TraktApiSharp.Objects.JsonReader.Basic
{
    using Enums;
    using Newtonsoft.Json;
    using Objects.Basic;
    using System.IO;

    internal class TraktMetadataObjectJsonReader : ITraktObjectJsonReader<TraktMetadata>
    {
        private const string PROPERTY_NAME_MEDIA_TYPE = "media_type";
        private const string PROPERTY_NAME_RESOLUTION = "resolution";
        private const string PROPERTY_NAME_AUDIO = "audio";
        private const string PROPERTY_NAME_AUDIO_CHANNELS = "audio_channels";
        private const string PROPERTY_NAME_3D = "3d";

        public TraktMetadata ReadObject(string json)
        {
            if (string.IsNullOrEmpty(json))
                return null;

            using (var reader = new StringReader(json))
            using (var jsonReader = new JsonTextReader(reader))
            {
                return ReadObject(jsonReader);
            }
        }

        public TraktMetadata ReadObject(JsonTextReader jsonReader)
        {
            if (jsonReader == null)
                return null;

            if (jsonReader.Read() && jsonReader.TokenType == JsonToken.StartObject)
            {
                var traktMetadata = new TraktMetadata();

                while (jsonReader.Read() && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case PROPERTY_NAME_MEDIA_TYPE:
                            {
                                var value = jsonReader.ReadAsString();

                                if (!string.IsNullOrEmpty(value))
                                    traktMetadata.MediaType = TraktEnumeration.FromObjectName<TraktMediaType>(value);

                                break;
                            }
                        case PROPERTY_NAME_RESOLUTION:
                            {
                                var value = jsonReader.ReadAsString();

                                if (!string.IsNullOrEmpty(value))
                                    traktMetadata.MediaResolution = TraktEnumeration.FromObjectName<TraktMediaResolution>(value);

                                break;
                            }
                        case PROPERTY_NAME_AUDIO:
                            {
                                var value = jsonReader.ReadAsString();

                                if (!string.IsNullOrEmpty(value))
                                    traktMetadata.Audio = TraktEnumeration.FromObjectName<TraktMediaAudio>(value);

                                break;
                            }
                        case PROPERTY_NAME_AUDIO_CHANNELS:
                            {
                                var value = jsonReader.ReadAsString();

                                if (!string.IsNullOrEmpty(value))
                                    traktMetadata.AudioChannels = TraktEnumeration.FromObjectName<TraktMediaAudioChannel>(value);

                                break;
                            }
                        case PROPERTY_NAME_3D:
                            traktMetadata.ThreeDimensional = jsonReader.ReadAsBoolean();
                            break;
                        default:
                            jsonReader.Read(); // read unmatched property value
                            break;
                    }
                }

                return traktMetadata;
            }

            return null;
        }
    }
}

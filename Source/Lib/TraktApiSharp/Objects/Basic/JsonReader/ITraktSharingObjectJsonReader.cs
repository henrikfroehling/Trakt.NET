namespace TraktApiSharp.Objects.Basic.JsonReader
{
    using Implementations;
    using Newtonsoft.Json;
    using Objects.JsonReader;
    using System.IO;

    internal class ITraktSharingObjectJsonReader : ITraktObjectJsonReader<ITraktSharing>
    {
        private const string PROPERTY_NAME_FACEBOOK = "facebook";
        private const string PROPERTY_NAME_TWITTER = "twitter";
        private const string PROPERTY_NAME_GOOGLE = "google";
        private const string PROPERTY_NAME_TUMBLR = "tumblr";
        private const string PROPERTY_NAME_MEDIUM = "medium";
        private const string PROPERTY_NAME_SLACK = "slack";

        public ITraktSharing ReadObject(string json)
        {
            if (string.IsNullOrEmpty(json))
                return null;

            using (var reader = new StringReader(json))
            using (var jsonReader = new JsonTextReader(reader))
            {
                return ReadObject(jsonReader);
            }
        }

        public ITraktSharing ReadObject(JsonTextReader jsonReader)
        {
            if (jsonReader == null)
                return null;

            if (jsonReader.Read() && jsonReader.TokenType == JsonToken.StartObject)
            {
                ITraktSharing traktSharing = new TraktSharing();

                while (jsonReader.Read() && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case PROPERTY_NAME_FACEBOOK:
                            traktSharing.Facebook = jsonReader.ReadAsBoolean();
                            break;
                        case PROPERTY_NAME_TWITTER:
                            traktSharing.Twitter = jsonReader.ReadAsBoolean();
                            break;
                        case PROPERTY_NAME_GOOGLE:
                            traktSharing.Google = jsonReader.ReadAsBoolean();
                            break;
                        case PROPERTY_NAME_TUMBLR:
                            traktSharing.Tumblr = jsonReader.ReadAsBoolean();
                            break;
                        case PROPERTY_NAME_MEDIUM:
                            traktSharing.Medium = jsonReader.ReadAsBoolean();
                            break;
                        case PROPERTY_NAME_SLACK:
                            traktSharing.Slack = jsonReader.ReadAsBoolean();
                            break;
                        default:
                            JsonReaderHelper.OverreadInvalidContent(jsonReader);
                            break;
                    }
                }

                return traktSharing;
            }

            return null;
        }
    }
}

namespace TraktApiSharp.Objects.JsonReader.Basic
{
    using Newtonsoft.Json;
    using Objects.Basic;
    using System.IO;

    internal class TraktErrorObjectJsonReader : ITraktObjectJsonReader<TraktError>
    {
        public const string PROPERTY_NAME_ERROR = "error";
        public const string PROPERTY_NAME_ERROR_DESCRIPTION = "error_description";

        public TraktError ReadObject(string json)
        {
            if (string.IsNullOrEmpty(json))
                return null;

            using (var reader = new StringReader(json))
            using (var jsonReader = new JsonTextReader(reader))
            {
                return ReadObject(jsonReader);
            }
        }

        public TraktError ReadObject(JsonTextReader jsonReader)
        {
            if (jsonReader == null)
                return null;

            if (jsonReader.Read() && jsonReader.TokenType == JsonToken.StartObject)
            {
                var traktError = new TraktError();

                while (jsonReader.Read() && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    if (propertyName == PROPERTY_NAME_ERROR)
                        traktError.Error = jsonReader.ReadAsString();
                    else if (propertyName == PROPERTY_NAME_ERROR_DESCRIPTION)
                        traktError.Description = jsonReader.ReadAsString();
                    else
                        jsonReader.Read(); // read unmatched property value
                }

                return traktError;
            }

            return null;
        }
    }
}

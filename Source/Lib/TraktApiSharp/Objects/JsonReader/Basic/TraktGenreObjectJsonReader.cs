namespace TraktApiSharp.Objects.JsonReader.Basic
{
    using Newtonsoft.Json;
    using Objects.Basic;
    using System.IO;

    internal class TraktGenreObjectJsonReader : ITraktObjectJsonReader<TraktGenre>
    {
        private const string PROPERTY_NAME_NAME = "name";
        private const string PROPERTY_NAME_SLUG = "slug";

        public TraktGenre ReadObject(string json)
        {
            if (string.IsNullOrEmpty(json))
                return null;

            using (var reader = new StringReader(json))
            using (var jsonReader = new JsonTextReader(reader))
            {
                return ReadObject(jsonReader);
            }
        }

        public TraktGenre ReadObject(JsonTextReader jsonReader)
        {
            if (jsonReader == null)
                return null;

            if (jsonReader.Read() && jsonReader.TokenType == JsonToken.StartObject)
            {
                var traktGenre = new TraktGenre();

                while (jsonReader.Read() && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case PROPERTY_NAME_NAME:
                            traktGenre.Name = jsonReader.ReadAsString();
                            break;
                        case PROPERTY_NAME_SLUG:
                            traktGenre.Slug = jsonReader.ReadAsString();
                            break;
                        default:
                            jsonReader.Read(); // read unmatched property value
                            break;
                    }
                }

                return traktGenre;
            }

            return null;
        }
    }
}

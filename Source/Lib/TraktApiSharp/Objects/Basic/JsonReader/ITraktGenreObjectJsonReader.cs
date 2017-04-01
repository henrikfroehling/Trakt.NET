namespace TraktApiSharp.Objects.Basic.JsonReader
{
    using Implementations;
    using Newtonsoft.Json;
    using Objects.JsonReader;
    using System.IO;

    internal class ITraktGenreObjectJsonReader : ITraktObjectJsonReader<ITraktGenre>
    {
        private const string PROPERTY_NAME_NAME = "name";
        private const string PROPERTY_NAME_SLUG = "slug";

        public ITraktGenre ReadObject(string json)
        {
            if (string.IsNullOrEmpty(json))
                return null;

            using (var reader = new StringReader(json))
            using (var jsonReader = new JsonTextReader(reader))
            {
                return ReadObject(jsonReader);
            }
        }

        public ITraktGenre ReadObject(JsonTextReader jsonReader)
        {
            if (jsonReader == null)
                return null;

            if (jsonReader.Read() && jsonReader.TokenType == JsonToken.StartObject)
            {
                ITraktGenre traktGenre = new TraktGenre();

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
                            JsonReaderHelper.OverreadInvalidContent(jsonReader);
                            break;
                    }
                }

                return traktGenre;
            }

            return null;
        }
    }
}

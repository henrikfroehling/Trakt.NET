namespace TraktApiSharp.Objects.JsonReader.Get.People
{
    using Newtonsoft.Json;
    using Objects.Get.People;
    using System;
    using System.IO;

    internal class TraktPersonObjectJsonReader : ITraktObjectJsonReader<TraktPerson>
    {
        private const string PROPERTY_NAME_NAME = "name";
        private const string PROPERTY_NAME_IDS = "ids";
        private const string PROPERTY_NAME_BIOGRAPHY = "biography";
        private const string PROPERTY_NAME_BIRTHDAY = "birthday";
        private const string PROPERTY_NAME_DEATH = "death";
        private const string PROPERTY_NAME_BIRTHPLACE = "birthplace";
        private const string PROPERTY_NAME_HOMEPAGE = "homepage";

        public TraktPerson ReadObject(string json)
        {
            if (string.IsNullOrEmpty(json))
                return null;

            using (var reader = new StringReader(json))
            using (var jsonReader = new JsonTextReader(reader))
            {
                return ReadObject(jsonReader);
            }
        }

        public TraktPerson ReadObject(JsonTextReader jsonReader)
        {
            if (jsonReader == null)
                return null;

            if (jsonReader.Read() && jsonReader.TokenType == JsonToken.StartObject)
            {
                var idsObjectReader = new TraktPersonIdsObjectJsonReader();
                var traktPerson = new TraktPerson();

                while (jsonReader.Read() && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case PROPERTY_NAME_NAME:
                            traktPerson.Name = jsonReader.ReadAsString();
                            break;
                        case PROPERTY_NAME_IDS:
                            traktPerson.Ids = idsObjectReader.ReadObject(jsonReader);
                            break;
                        case PROPERTY_NAME_BIOGRAPHY:
                            traktPerson.Biography = jsonReader.ReadAsString();
                            break;
                        case PROPERTY_NAME_BIRTHDAY:
                            if (jsonReader.Read())
                            {
                                if (jsonReader.ValueType == typeof(DateTime))
                                    traktPerson.Birthday = (DateTime)jsonReader.Value;
                                else if (jsonReader.ValueType == typeof(string))
                                    traktPerson.Birthday = DateTime.Parse(jsonReader.Value.ToString());
                            }

                            break;
                        case PROPERTY_NAME_DEATH:
                            if (jsonReader.Read())
                            {
                                if (jsonReader.ValueType == typeof(DateTime))
                                    traktPerson.Death = (DateTime)jsonReader.Value;
                                else if (jsonReader.ValueType == typeof(string))
                                    traktPerson.Death = DateTime.Parse(jsonReader.Value.ToString());
                            }

                            break;
                        case PROPERTY_NAME_BIRTHPLACE:
                            traktPerson.Birthplace = jsonReader.ReadAsString();
                            break;
                        case PROPERTY_NAME_HOMEPAGE:
                            traktPerson.Homepage = jsonReader.ReadAsString();
                            break;
                        default:
                            jsonReader.Read(); // read unmatched property value

                            if (jsonReader.TokenType == JsonToken.StartArray)
                            {
                                // step over possible array values for unmatched property
                                while (jsonReader.Read() && jsonReader.TokenType != JsonToken.EndArray)
                                {
                                }
                            }
                            else if (jsonReader.TokenType == JsonToken.StartObject)
                            {
                                // step over possible object values for unmatched property
                                while (jsonReader.Read() && jsonReader.TokenType != JsonToken.EndObject)
                                {
                                }
                            }

                            break;
                    }
                }

                return traktPerson;
            }

            return null;
        }
    }
}

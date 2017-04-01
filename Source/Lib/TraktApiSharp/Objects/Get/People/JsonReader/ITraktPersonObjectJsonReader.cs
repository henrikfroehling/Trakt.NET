namespace TraktApiSharp.Objects.Get.People.JsonReader
{
    using Implementations;
    using Newtonsoft.Json;
    using Objects.JsonReader;
    using System;
    using System.IO;

    internal class ITraktPersonObjectJsonReader : ITraktObjectJsonReader<TraktPerson>
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
                var idsObjectReader = new ITraktPersonIdsObjectJsonReader();
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
                            {
                                DateTime dateTime;
                                if (JsonReaderHelper.ReadDateTimeValue(jsonReader, out dateTime))
                                    traktPerson.Birthday = dateTime;

                                break;
                            }
                        case PROPERTY_NAME_DEATH:
                            {
                                DateTime dateTime;
                                if (JsonReaderHelper.ReadDateTimeValue(jsonReader, out dateTime))
                                    traktPerson.Death = dateTime;

                                break;
                            }
                        case PROPERTY_NAME_BIRTHPLACE:
                            traktPerson.Birthplace = jsonReader.ReadAsString();
                            break;
                        case PROPERTY_NAME_HOMEPAGE:
                            traktPerson.Homepage = jsonReader.ReadAsString();
                            break;
                        default:
                            JsonReaderHelper.OverreadInvalidContent(jsonReader);
                            break;
                    }
                }

                return traktPerson;
            }

            return null;
        }
    }
}

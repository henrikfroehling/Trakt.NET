namespace TraktApiSharp.Objects.JsonReader.Basic
{
    using Newtonsoft.Json;
    using Objects.Basic;
    using System.Collections.Generic;
    using System.IO;

    internal class TraktRatingObjectJsonReader : ITraktObjectJsonReader<TraktRating>
    {
        private const string PROPERTY_NAME_RATING = "rating";
        private const string PROPERTY_NAME_VOTES = "votes";
        private const string PROPERTY_NAME_DISTRIBUTION = "distribution";

        public TraktRating ReadObject(string json)
        {
            if (string.IsNullOrEmpty(json))
                return null;

            using (var reader = new StringReader(json))
            using (var jsonReader = new JsonTextReader(reader))
            {
                return ReadObject(jsonReader);
            }
        }

        public TraktRating ReadObject(JsonTextReader jsonReader)
        {
            if (jsonReader == null)
                return null;

            if (jsonReader.Read() && jsonReader.TokenType == JsonToken.StartObject)
            {
                var traktRating = new TraktRating();

                while (jsonReader.Read() && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case PROPERTY_NAME_RATING:
                            traktRating.Rating = (float)jsonReader.ReadAsDouble();
                            break;
                        case PROPERTY_NAME_VOTES:
                            traktRating.Votes = jsonReader.ReadAsInt32();
                            break;
                        case PROPERTY_NAME_DISTRIBUTION:
                            ReadDistribution(jsonReader, traktRating);
                            break;
                        default:
                            jsonReader.Read(); // read unmatched property value
                            break;
                    }
                }

                return traktRating;
            }

            return null;
        }

        private static void ReadDistribution(JsonTextReader jsonReader, TraktRating traktRating)
        {
            const string nr1 = "1";
            const string nr2 = "2";
            const string nr3 = "3";
            const string nr4 = "4";
            const string nr5 = "5";
            const string nr6 = "6";
            const string nr7 = "7";
            const string nr8 = "8";
            const string nr9 = "9";
            const string nr10 = "10";

            if (jsonReader.Read() && jsonReader.TokenType == JsonToken.StartObject)
            {
                var distribution = new Dictionary<string, int>
                {
                    [nr1] = 0,
                    [nr2] = 0,
                    [nr3] = 0,
                    [nr4] = 0,
                    [nr5] = 0,
                    [nr6] = 0,
                    [nr7] = 0,
                    [nr8] = 0,
                    [nr9] = 0,
                    [nr10] = 0
                };

                while (jsonReader.Read() && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var numberProperty = jsonReader.Value.ToString();

                    switch (numberProperty)
                    {
                        case nr1:
                            distribution[nr1] = (int)jsonReader.ReadAsInt32();
                            break;
                        case nr2:
                            distribution[nr2] = (int)jsonReader.ReadAsInt32();
                            break;
                        case nr3:
                            distribution[nr3] = (int)jsonReader.ReadAsInt32();
                            break;
                        case nr4:
                            distribution[nr4] = (int)jsonReader.ReadAsInt32();
                            break;
                        case nr5:
                            distribution[nr5] = (int)jsonReader.ReadAsInt32();
                            break;
                        case nr6:
                            distribution[nr6] = (int)jsonReader.ReadAsInt32();
                            break;
                        case nr7:
                            distribution[nr7] = (int)jsonReader.ReadAsInt32();
                            break;
                        case nr8:
                            distribution[nr8] = (int)jsonReader.ReadAsInt32();
                            break;
                        case nr9:
                            distribution[nr9] = (int)jsonReader.ReadAsInt32();
                            break;
                        case nr10:
                            distribution[nr10] = (int)jsonReader.ReadAsInt32();
                            break;
                        default:
                            jsonReader.Read(); // read unmatched property value
                            continue;
                    }
                }

                traktRating.Distribution = distribution;
            }
        }
    }
}

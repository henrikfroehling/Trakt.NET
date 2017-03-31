namespace TraktApiSharp.Objects.Get.Movies.JsonReader
{
    using Newtonsoft.Json;
    using Objects.Get.Movies;
    using Objects.Get.Movies.Implementations;
    using Objects.JsonReader;
    using System;
    using System.IO;

    internal class ITraktMovieObjectJsonReader : ITraktObjectJsonReader<ITraktMovie>
    {
        private const string PROPERTY_NAME_TITLE = "title";
        private const string PROPERTY_NAME_YEAR = "year";
        private const string PROPERTY_NAME_IDS = "ids";
        private const string PROPERTY_NAME_TAGLINE = "tagline";
        private const string PROPERTY_NAME_OVERVIEW = "overview";
        private const string PROPERTY_NAME_RELEASED = "released";
        private const string PROPERTY_NAME_RUNTIME = "runtime";
        private const string PROPERTY_NAME_TRAILER = "trailer";
        private const string PROPERTY_NAME_HOMEPAGE = "homepage";
        private const string PROPERTY_NAME_RATING = "rating";
        private const string PROPERTY_NAME_VOTES = "votes";
        private const string PROPERTY_NAME_UPDATED_AT = "updated_at";
        private const string PROPERTY_NAME_LANGUAGE = "language";
        private const string PROPERTY_NAME_AVAILABLE_TRANSLATIONS = "available_translations";
        private const string PROPERTY_NAME_GENRES = "genres";
        private const string PROPERTY_NAME_CERTIFICATION = "certification";

        private static readonly TraktMovie movie = new TraktMovie();

        public ITraktMovie ReadObject(string json)
        {
            if (string.IsNullOrEmpty(json))
                return null;

            using (var reader = new StringReader(json))
            using (var jsonReader = new JsonTextReader(reader))
            {
                return ReadObject(jsonReader);
            }
        }

        public ITraktMovie ReadObject(JsonTextReader jsonReader)
        {
            if (jsonReader == null)
                return null;

            if (jsonReader.Read() && jsonReader.TokenType == JsonToken.StartObject)
            {
                var idsObjectReader = new TraktMovieIdsObjectJsonReader();
                ITraktMovie traktMovie = new TraktMovie();

                while (jsonReader.Read() && jsonReader.TokenType == JsonToken.PropertyName)
                {
                    var propertyName = jsonReader.Value.ToString();

                    switch (propertyName)
                    {
                        case PROPERTY_NAME_TITLE:
                            traktMovie.Title = jsonReader.ReadAsString();
                            break;
                        case PROPERTY_NAME_YEAR:
                            traktMovie.Year = jsonReader.ReadAsInt32();
                            break;
                        case PROPERTY_NAME_IDS:
                            // TODO use interface
                            //traktMovie.Ids = idsObjectReader.ReadObject(jsonReader);
                            break;
                        case PROPERTY_NAME_TAGLINE:
                            traktMovie.Tagline = jsonReader.ReadAsString();
                            break;
                        case PROPERTY_NAME_OVERVIEW:
                            traktMovie.Overview = jsonReader.ReadAsString();
                            break;
                        case PROPERTY_NAME_RELEASED:
                            {
                                DateTime dateTime;
                                if (JsonReaderHelper.ReadDateTimeValue(jsonReader, out dateTime))
                                    traktMovie.Released = dateTime;

                                break;
                            }
                        case PROPERTY_NAME_RUNTIME:
                            traktMovie.Runtime = jsonReader.ReadAsInt32();
                            break;
                        case PROPERTY_NAME_TRAILER:
                            traktMovie.Trailer = jsonReader.ReadAsString();
                            break;
                        case PROPERTY_NAME_HOMEPAGE:
                            traktMovie.Homepage = jsonReader.ReadAsString();
                            break;
                        case PROPERTY_NAME_RATING:
                            traktMovie.Rating = (float?)jsonReader.ReadAsDouble();
                            break;
                        case PROPERTY_NAME_VOTES:
                            traktMovie.Votes = jsonReader.ReadAsInt32();
                            break;
                        case PROPERTY_NAME_UPDATED_AT:
                            {
                                DateTime dateTime;
                                if (JsonReaderHelper.ReadDateTimeValue(jsonReader, out dateTime))
                                    traktMovie.UpdatedAt = dateTime;

                                break;
                            }
                        case PROPERTY_NAME_LANGUAGE:
                            traktMovie.LanguageCode = jsonReader.ReadAsString();
                            break;
                        case PROPERTY_NAME_AVAILABLE_TRANSLATIONS:
                            traktMovie.AvailableTranslationLanguageCodes = JsonReaderHelper.ReadStringArray(jsonReader);
                            break;
                        case PROPERTY_NAME_GENRES:
                            traktMovie.Genres = JsonReaderHelper.ReadStringArray(jsonReader);
                            break;
                        case PROPERTY_NAME_CERTIFICATION:
                            traktMovie.Certification = jsonReader.ReadAsString();
                            break;
                        default:
                            JsonReaderHelper.OverreadInvalidContent(jsonReader);
                            break;
                    }
                }

                return traktMovie;
            }

            return null;
        }
    }
}

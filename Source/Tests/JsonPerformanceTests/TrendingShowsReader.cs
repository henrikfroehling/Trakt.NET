namespace JsonPerformanceTests
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using TraktApiSharp.Enums;
    using TraktApiSharp.Objects.Get.Shows;
    using TraktApiSharp.Objects.Get.Shows.Common;

    public sealed class TrendingShowsReader
    {
        public TrendingShowsReader() { }

        public IEnumerable<TraktTrendingShow> ReadTrendingShows(string json)
        {
            if (string.IsNullOrEmpty(json))
                return null;

            var trendingShows = new List<TraktTrendingShow>();

            using (var reader = new StringReader(json))
            {
                using (var jsonReader = new JsonTextReader(reader))
                {
                    if (jsonReader.Read() && jsonReader.TokenType == JsonToken.StartArray)
                    {
                        while (jsonReader.Read() && jsonReader.TokenType == JsonToken.StartObject)
                        {
                            var trendingShow = ReadTrendingShow(jsonReader);
                            trendingShows.Add(trendingShow);
                            jsonReader.Read();
                        }
                    }
                }
            }

            return trendingShows;
        }

        private TraktTrendingShow ReadTrendingShow(JsonTextReader reader)
        {
            var trendingShow = new TraktTrendingShow();

            if (reader.Read() && reader.TokenType == JsonToken.PropertyName)
            {
                if ((string)reader.Value == "watchers")
                    trendingShow.Watchers = reader.ReadAsInt32();
            }

            if (reader.Read() && reader.TokenType == JsonToken.PropertyName)
            {
                if ((string)reader.Value == "show")
                    trendingShow.Show = ReadShow(reader);
            }

            return trendingShow;
        }

        private TraktShow ReadShow(JsonTextReader reader)
        {
            if (reader.Read() && reader.TokenType == JsonToken.StartObject)
            {
                var show = new TraktShow();

                while (reader.Read() && reader.TokenType == JsonToken.PropertyName)
                    ReadProperty(show, null, null, reader, (string)reader.Value);

                return show;
            }

            return null;
        }

        private TraktShowIds ReadShowIds(JsonTextReader reader)
        {
            if (reader.Read() && reader.TokenType == JsonToken.StartObject)
            {
                var ids = new TraktShowIds();

                while (reader.Read() && reader.TokenType == JsonToken.PropertyName)
                    ReadProperty(null, ids, null, reader, (string)reader.Value);

                return ids;
            }

            return null;
        }

        private TraktShowAirs ReadShowAirs(JsonTextReader reader)
        {
            if (reader.Read() && reader.TokenType == JsonToken.StartObject)
            {
                var airs = new TraktShowAirs();

                while (reader.Read() && reader.TokenType == JsonToken.PropertyName)
                    ReadProperty(null, null, airs, reader, (string)reader.Value);

                return airs;
            }

            return null;
        }

        private IEnumerable<string> ReadStringArray(JsonTextReader reader)
        {
            var values = new List<string>();

            if (reader.Read() && reader.TokenType == JsonToken.StartArray)
            {
                while (reader.Read() && reader.TokenType == JsonToken.String)
                {
                    var value = (string)reader.Value;

                    if (!string.IsNullOrEmpty(value))
                        values.Add(value);
                }
            }

            return values;
        }

        private void ReadProperty(TraktShow show, TraktShowIds ids, TraktShowAirs airs, JsonTextReader reader, string propertyName)
        {
            if (propertyName == "ids")
            {
                var showIds = ReadShowIds(reader);

                if (showIds != null && show != null)
                    show.Ids = showIds;

                return;
            }
            else if (propertyName == "airs")
            {
                var showAirs = ReadShowAirs(reader);

                if (showAirs != null && show != null)
                    show.Airs = showAirs;

                return;
            }
            else if (propertyName == "available_translations")
            {
                var values = ReadStringArray(reader);

                if (values != null && show != null)
                    show.AvailableTranslationLanguageCodes = values;

                return;
            }
            else if (propertyName == "genres")
            {
                var values = ReadStringArray(reader);

                if (values != null && show != null)
                    show.Genres = values;

                return;
            }

            if (reader.Read())
            {
                var valueType = reader.ValueType;
                var tokenType = reader.TokenType;

                if (valueType == typeof(bool))
                {
                    var value = (bool)reader.Value;
                }
                else if (valueType == typeof(float))
                {
                    var value = (float)reader.Value;
                }
                else if (valueType == typeof(double))
                {
                    var value = (double)reader.Value;

                    if (show != null)
                    {
                        if (propertyName == "rating")
                            show.Rating = (float)value;
                    }
                }
                else if (valueType == typeof(decimal))
                {
                    var value = (decimal)reader.Value;
                }
                else if (tokenType == JsonToken.Integer)
                {
                    var value = reader.Value.ToString();

                    if (!string.IsNullOrEmpty(value))
                    {
                        int nValue = 0;

                        if (int.TryParse(value, out nValue))
                        {
                            if (show != null)
                            {
                                if (propertyName == "aired_episodes")
                                    show.AiredEpisodes = nValue;
                                else if (propertyName == "runtime")
                                    show.Runtime = nValue;
                                else if (propertyName == "votes")
                                    show.Votes = nValue;
                                else if (propertyName == "year")
                                    show.Year = nValue;
                            }
                            else if (ids != null)
                            {
                                if (propertyName == "trakt")
                                    ids.Trakt = (uint)nValue;
                                else if (propertyName == "tvdb")
                                    ids.Tvdb = (uint)nValue;
                                else if (propertyName == "tmdb")
                                    ids.Tmdb = (uint)nValue;
                                else if (propertyName == "tvrage")
                                    ids.TvRage = (uint)nValue;
                            }
                        }
                    }
                }
                else if (valueType == typeof(string))
                {
                    var value = (string)reader.Value;

                    if (!string.IsNullOrEmpty(value))
                    {
                        if (show != null)
                        {
                            if (propertyName == "title")
                                show.Title = value;
                            else if (propertyName == "overview")
                                show.Overview = value;
                            else if (propertyName == "certification")
                                show.Certification = value;
                            else if (propertyName == "network")
                                show.Network = value;
                            else if (propertyName == "country")
                                show.CountryCode = value;
                            else if (propertyName == "trailer")
                                show.Trailer = value;
                            else if (propertyName == "homepage")
                                show.Homepage = value;
                            else if (propertyName == "language")
                                show.LanguageCode = value;
                            else if (propertyName == "status")
                            {
                                var status = TraktEnumeration.FromObjectName<TraktShowStatus>(value);
                                show.Status = status;
                            }
                        }
                        else if (airs != null)
                        {
                            if (propertyName == "day")
                                airs.Day = value;
                            else if (propertyName == "time")
                                airs.Time = value;
                            else if (propertyName == "timezone")
                                airs.TimeZoneId = value;
                        }
                        else if (ids != null)
                        {
                            if (propertyName == "slug")
                                ids.Slug = value;
                            else if (propertyName == "imdb")
                                ids.Imdb = value;
                        }
                    }
                }
                else if (valueType == typeof(DateTime))
                {
                    var value = reader.Value;

                    if (value != null && show != null)
                    {
                        if (propertyName == "first_aired")
                            show.FirstAired = (DateTime)value;
                        else if (propertyName == "updated_at")
                            show.UpdatedAt = (DateTime)value;
                    }
                }
            }
        }
    }
}

namespace TraktApiSharp.Objects.Movies
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Globalization;

    public class TraktMovie
    {
        #region Minimal Info

        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "year")]
        public int Year { get; set; }

        [JsonProperty(PropertyName = "ids")]
        public TraktMovieIds Ids { get; set; }

        #endregion

        #region Images

        [JsonProperty(PropertyName = "images")]
        public TraktMovieImages Images { get; set; }

        #endregion

        #region Full (additional info)

        [JsonProperty(PropertyName = "tagline")]
        public string Tagline { get; set; }

        [JsonProperty(PropertyName = "overview")]
        public string Overview { get; set; }

        [JsonProperty(PropertyName = "released")]
        public DateTime? Released { get; set; }

        [JsonProperty(PropertyName = "runtime")]
        public int? Runtime { get; set; }

        [JsonProperty(PropertyName = "trailer")]
        public string Trailer { get; set; }

        [JsonIgnore]
        public Uri TrailerUri
        {
            get { return !string.IsNullOrEmpty(Trailer) ? new Uri(Trailer) : null; }
            set { Trailer = value.AbsoluteUri; }
        }

        [JsonProperty(PropertyName = "homepage")]
        public string Homepage { get; set; }

        [JsonIgnore]
        public Uri HomepageUri
        {
            get { return !string.IsNullOrEmpty(Homepage) ? new Uri(Homepage) : null; }
            set { Homepage = value.AbsoluteUri; }
        }

        [JsonProperty(PropertyName = "rating")]
        public decimal? Rating { get; set; }

        [JsonProperty(PropertyName = "votes")]
        public int? Votes { get; set; }

        [JsonProperty(PropertyName = "updated_at")]
        public DateTime? UpdatedAt { get; set; }

        [JsonProperty(PropertyName = "language")]
        public string LanguageCode { get; set; }

        [JsonIgnore]
        public string Language
        {
            get
            {
                if (string.IsNullOrEmpty(LanguageCode))
                    return null;

                try
                {
                    return new CultureInfo(LanguageCode).DisplayName;
                }
                catch
                {
                    return string.Empty;
                }
            }
        }

        [JsonProperty(PropertyName = "available_translations")]
        public IEnumerable<string> AvailableTranslationLanguageCodes { get; set; }

        [JsonIgnore]
        public List<string> AvailableTranslationLanguages
        {
            get
            {
                if (AvailableTranslationLanguageCodes == null)
                    return null;

                var languages = new List<string>();

                foreach (var languageCode in AvailableTranslationLanguageCodes)
                {
                    try
                    {
                        languages.Add(new RegionInfo(languageCode).DisplayName);
                    }
                    catch { }
                }

                return languages;
            }
        }

        [JsonProperty(PropertyName = "genres")]
        public IEnumerable<string> Genres { get; set; }

        [JsonProperty(PropertyName = "certification")]
        public string Certification { get; set; }

        #endregion
    }
}

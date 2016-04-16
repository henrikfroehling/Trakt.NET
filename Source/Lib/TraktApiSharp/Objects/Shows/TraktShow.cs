namespace TraktApiSharp.Objects.Shows
{
    using Enums;
    using Newtonsoft.Json;
    using Seasons;
    using System;
    using System.Collections.Generic;
    using System.Globalization;

    /// <summary>
    /// A Trakt show.
    /// </summary>
    public class TraktShow
    {
        #region Minimal Info

        /// <summary>
        /// The show title.
        /// </summary>
        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        /// <summary>
        /// THe show release year (first episode of the first season).
        /// </summary>
        [JsonProperty(PropertyName = "year")]
        public int Year { get; set; }

        /// <summary>
        /// A collection of ids for the show for various web services.
        /// </summary>
        [JsonProperty(PropertyName = "ids")]
        public TraktShowIds Ids { get; set; }

        #endregion

        #region Images

        /// <summary>
        /// A collection of images for the show.
        /// </summary>
        [JsonProperty(PropertyName = "images")]
        public TraktShowImages Images { get; set; }

        #endregion

        #region Full (additional info)

        /// <summary>
        /// A synopsis of the show.
        /// </summary>
        [JsonProperty(PropertyName = "overview")]
        public string Overview { get; set; }

        /// <summary>
        /// The UTC date when the first episode of the first season of the show was aired.
        /// </summary>
        [JsonProperty(PropertyName = "first_aired")]
        public DateTime? FirstAired { get; set; }

        /// <summary>
        /// The air time of the show.
        /// </summary>
        [JsonProperty(PropertyName = "airs")]
        public TraktShowAirs Airs { get; set; }

        /// <summary>
        /// The runtime for the show's episodes, in minutes.
        /// </summary>
        [JsonProperty(PropertyName = "runtime")]
        public int? Runtime { get; set; }

        /// <summary>
        /// The certification of the show.
        /// </summary>
        [JsonProperty(PropertyName = "certification")]
        public string Certification { get; set; }

        /// <summary>
        /// The producing network of the show.
        /// </summary>
        [JsonProperty(PropertyName = "network")]
        public string Network { get; set; }

        /// <summary>
        /// A two letter language code for the country in which the show is produced.
        /// </summary>
        [JsonProperty(PropertyName = "country")]
        public string CountryCode { get; set; }

        /// <summary>
        /// The country in which the show is produced.
        /// </summary>
        [JsonIgnore]
        public string Country
        {
            get
            {
                if (string.IsNullOrEmpty(CountryCode))
                    return null;

                try
                {
                    return new RegionInfo(CountryCode).DisplayName;
                }
                catch
                {
                    return string.Empty;
                }
            }
        }

        /// <summary>
        /// The address of a trailer for the show.
        /// </summary>
        [JsonProperty(PropertyName = "trailer")]
        public string Trailer { get; set; }

        /// <summary>
        /// The URI of a trailer for the show.
        /// </summary>
        [JsonIgnore]
        public Uri TrailerUri
        {
            get { return !string.IsNullOrEmpty(Trailer) ? new Uri(Trailer) : null; }
            set { Trailer = value.AbsoluteUri; }
        }

        /// <summary>
        /// The address of the homepage of the show.
        /// </summary>
        [JsonProperty(PropertyName = "homepage")]
        public string Homepage { get; set; }

        /// <summary>
        /// The URI of the homepage of the show.
        /// </summary>
        [JsonIgnore]
        public Uri HomepageUri
        {
            get { return !string.IsNullOrEmpty(Homepage) ? new Uri(Homepage) : null; }
            set { Homepage = value.AbsoluteUri; }
        }

        /// <summary>
        /// The show's current status.
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        [JsonConverter(typeof(TraktShowStatusConverter))]
        public TraktShowStatus Status { get; set; }

        /// <summary>
        /// The average user rating of the show.
        /// </summary>
        [JsonProperty(PropertyName = "rating")]
        public decimal? Rating { get; set; }

        /// <summary>
        /// The number of votes for the show.
        /// </summary>
        [JsonProperty(PropertyName = "votes")]
        public int? Votes { get; set; }

        /// <summary>
        /// The UTC date when the show was last updated.
        /// </summary>
        [JsonProperty(PropertyName = "updated_at")]
        public DateTime? UpdatedAt { get; set; }

        /// <summary>
        /// A two letter language code of the show.
        /// </summary>
        [JsonProperty(PropertyName = "language")]
        public string LanguageCode { get; set; }

        /// <summary>
        /// The language of the show.
        /// </summary>
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

        /// <summary>
        /// A list of translation language codes (two letters) for the show.
        /// </summary>
        [JsonProperty(PropertyName = "available_translations")]
        public IEnumerable<string> AvailableTranslationLanguageCodes { get; set; }

        /// <summary>
        /// A list of translation languages for the show.
        /// </summary>
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

        /// <summary>
        /// A collection of genres for the show.
        /// </summary>
        [JsonProperty(PropertyName = "genres")]
        public IEnumerable<string> Genres { get; set; }

        /// <summary>
        /// The absolute number of already aired episodes in all seasons of the show.
        /// </summary>
        [JsonProperty(PropertyName = "aired_episodes")]
        public int? AiredEpisodes { get; set; }

        #endregion

        #region Seasons

        /// <summary>
        /// A collection of Trakt seasons for the show.
        /// </summary>
        [JsonProperty(PropertyName = "seasons")]
        public IEnumerable<TraktSeason> Seasons { get; set; }

        #endregion
    }
}

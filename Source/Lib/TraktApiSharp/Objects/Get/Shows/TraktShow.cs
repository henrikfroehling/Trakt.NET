namespace TraktApiSharp.Objects.Get.Shows
{
    using Enums;
    using Newtonsoft.Json;
    using Seasons;
    using System;
    using System.Collections.Generic;

    /// <summary>A Trakt show.</summary>
    public class TraktShow
    {
        /// <summary>Gets or sets the show title.</summary>
        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        /// <summary>Gets or sets the show release year (first episode of the first season).</summary>
        [JsonProperty(PropertyName = "year")]
        public int? Year { get; set; }

        /// <summary>Gets or sets the collection of ids for the show for various web services.</summary>
        [JsonProperty(PropertyName = "ids")]
        public TraktShowIds Ids { get; set; }

        /// <summary>Gets or sets the collection of images and image sets for the show.</summary>
        [JsonProperty(PropertyName = "images")]
        public TraktShowImages Images { get; set; }

        /// <summary>Gets or sets the synopsis of the show.</summary>
        [JsonProperty(PropertyName = "overview")]
        public string Overview { get; set; }

        /// <summary>Gets or sets the UTC datetime when the first episode of the first season of the show was aired.</summary>
        [JsonProperty(PropertyName = "first_aired")]
        public DateTime? FirstAired { get; set; }

        /// <summary>Gets or sets the air time of the show.</summary>
        [JsonProperty(PropertyName = "airs")]
        public TraktShowAirs Airs { get; set; }

        /// <summary>Gets or sets the runtime for the show's episodes, in minutes.</summary>
        [JsonProperty(PropertyName = "runtime")]
        public int? Runtime { get; set; }

        /// <summary>Gets or sets the content certification of the show.</summary>
        [JsonProperty(PropertyName = "certification")]
        public string Certification { get; set; }

        /// <summary>Gets or sets the producing network name of the show.</summary>
        [JsonProperty(PropertyName = "network")]
        public string Network { get; set; }

        /// <summary>Gets or sets the two letter language code for the country in which the show is produced.</summary>
        [JsonProperty(PropertyName = "country")]
        public string CountryCode { get; set; }

        /// <summary>Gets or sets the web address of a trailer for the show.</summary>
        [JsonProperty(PropertyName = "trailer")]
        public string Trailer { get; set; }

        /// <summary>Gets or sets the web address of the homepage of the show.</summary>
        [JsonProperty(PropertyName = "homepage")]
        public string Homepage { get; set; }

        /// <summary>Gets or sets the show's current status. See also <seealso cref="TraktShowStatus" />.</summary>
        [JsonProperty(PropertyName = "status")]
        [JsonConverter(typeof(TraktShowStatusConverter))]
        public TraktShowStatus? Status { get; set; }

        /// <summary>Gets or sets the average user rating of the show.</summary>
        [JsonProperty(PropertyName = "rating")]
        public float? Rating { get; set; }

        /// <summary>Gets or sets the number of votes for the show.</summary>
        [JsonProperty(PropertyName = "votes")]
        public int? Votes { get; set; }

        /// <summary>Gets or sets the UTC datetime when the show was last updated.</summary>
        [JsonProperty(PropertyName = "updated_at")]
        public DateTime? UpdatedAt { get; set; }

        /// <summary>Gets or sets the two letter language code of the show.</summary>
        [JsonProperty(PropertyName = "language")]
        public string LanguageCode { get; set; }

        /// <summary>Gets or sets the list of translation language codes (two letters) for the show.</summary>
        [JsonProperty(PropertyName = "available_translations")]
        public IEnumerable<string> AvailableTranslationLanguageCodes { get; set; }

        /// <summary>Gets or sets the collection of Trakt genre slugs for the show.</summary>
        [JsonProperty(PropertyName = "genres")]
        public IEnumerable<string> Genres { get; set; }

        /// <summary>Gets or sets the absolute number of already aired episodes in all seasons of the show.</summary>
        [JsonProperty(PropertyName = "aired_episodes")]
        public int? AiredEpisodes { get; set; }

        /// <summary>Gets or sets the collection of Trakt seasons for the show.</summary>
        [JsonProperty(PropertyName = "seasons")]
        public IEnumerable<TraktSeason> Seasons { get; set; }
    }
}

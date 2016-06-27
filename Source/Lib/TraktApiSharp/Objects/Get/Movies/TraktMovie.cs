namespace TraktApiSharp.Objects.Get.Movies
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;

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

        [JsonProperty(PropertyName = "homepage")]
        public string Homepage { get; set; }

        [JsonProperty(PropertyName = "rating")]
        public float? Rating { get; set; }

        [JsonProperty(PropertyName = "votes")]
        public int? Votes { get; set; }

        [JsonProperty(PropertyName = "updated_at")]
        public DateTime? UpdatedAt { get; set; }

        [JsonProperty(PropertyName = "language")]
        public string LanguageCode { get; set; }

        [JsonProperty(PropertyName = "available_translations")]
        public IEnumerable<string> AvailableTranslationLanguageCodes { get; set; }

        [JsonProperty(PropertyName = "genres")]
        public IEnumerable<string> Genres { get; set; }

        [JsonProperty(PropertyName = "certification")]
        public string Certification { get; set; }

        #endregion
    }
}

namespace TraktApiSharp.Objects.Get.Movies
{
    using Enums;
    using Newtonsoft.Json;
    using System;

    public class TraktMovieRelease
    {
        [JsonProperty(PropertyName = "country")]
        public string CountryCode { get; set; }

        [JsonProperty(PropertyName = "certification")]
        public string Certification { get; set; }

        [JsonProperty(PropertyName = "release_date")]
        public DateTime? ReleaseDate { get; set; }

        [JsonProperty(PropertyName = "release_type")]
        [JsonConverter(typeof(TraktReleaseTypeConverter))]
        public TraktReleaseType? ReleaseType { get; set; }

        [JsonProperty(PropertyName = "note")]
        public string Note { get; set; }
    }
}

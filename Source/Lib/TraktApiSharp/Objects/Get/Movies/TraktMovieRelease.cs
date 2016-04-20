namespace TraktApiSharp.Objects.Get.Movies
{
    using Enums;
    using Newtonsoft.Json;
    using System;
    using System.Globalization;

    public class TraktMovieRelease
    {
        [JsonProperty(PropertyName = "country")]
        public string CountryCode { get; set; }

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

        [JsonProperty(PropertyName = "certification")]
        public string Certification { get; set; }

        [JsonProperty(PropertyName = "release_date")]
        public DateTime ReleaseDate { get; set; }

        [JsonProperty(PropertyName = "release_type")]
        [JsonConverter(typeof(TraktReleaseTypeConverter))]
        public TraktReleaseType ReleaseType { get; set; }

        [JsonProperty(PropertyName = "note")]
        public string Note { get; set; }
    }
}

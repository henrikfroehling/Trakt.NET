namespace TraktApiSharp.Objects.Movies
{
    using Newtonsoft.Json;
    using System.Globalization;

    public class TraktMovieTranslation
    {
        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "overview")]
        public string Overview { get; set; }

        [JsonProperty(PropertyName = "tagline")]
        public string Tagline { get; set; }

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
    }
}

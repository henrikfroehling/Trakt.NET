namespace TraktApiSharp.Objects.Get.Shows
{
    using Newtonsoft.Json;
    using System.Globalization;

    public class TraktShowAlias
    {
        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

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
    }
}

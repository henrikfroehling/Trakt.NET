namespace TraktApiSharp.Objects.Checkins
{
    using Get.Movies;
    using Newtonsoft.Json;

    public class TraktCheckinMovie : TraktCheckin
    {
        [JsonProperty(PropertyName = "movie")]
        public TraktMovie Movie { get; set; }
    }
}

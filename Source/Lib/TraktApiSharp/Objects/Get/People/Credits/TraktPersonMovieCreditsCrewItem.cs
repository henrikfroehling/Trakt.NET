namespace TraktApiSharp.Objects.Get.People.Credits
{
    using Movies;
    using Newtonsoft.Json;

    public class TraktPersonMovieCreditsCrewItem
    {
        [JsonProperty(PropertyName = "job")]
        public string Job { get; set; }

        [JsonProperty(PropertyName = "movie")]
        public TraktMovie Movie { get; set; }
    }
}

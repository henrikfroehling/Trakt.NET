namespace TraktApiSharp.Objects.Get.People.Credits
{
    using Attributes;
    using Movies;
    using Newtonsoft.Json;

    public class TraktPersonMovieCreditsCrewItem
    {
        [JsonProperty(PropertyName = "job")]
        [Nullable]
        public string Job { get; set; }

        [JsonProperty(PropertyName = "movie")]
        [Nullable]
        public TraktMovie Movie { get; set; }
    }
}

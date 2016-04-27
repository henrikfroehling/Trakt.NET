namespace TraktApiSharp.Objects.Get.People.Credits
{
    using Movies;
    using Newtonsoft.Json;

    public class TraktPersonMovieCreditsCastItem
    {
        [JsonProperty(PropertyName = "character")]
        public string Character { get; set; }

        [JsonProperty(PropertyName = "movie")]
        public TraktMovie Movie { get; set; }
    }
}

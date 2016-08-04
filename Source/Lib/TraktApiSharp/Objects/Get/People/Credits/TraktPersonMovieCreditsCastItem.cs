namespace TraktApiSharp.Objects.Get.People.Credits
{
    using Attributes;
    using Movies;
    using Newtonsoft.Json;

    public class TraktPersonMovieCreditsCastItem
    {
        [JsonProperty(PropertyName = "character")]
        [Nullable]
        public string Character { get; set; }

        [JsonProperty(PropertyName = "movie")]
        [Nullable]
        public TraktMovie Movie { get; set; }
    }
}

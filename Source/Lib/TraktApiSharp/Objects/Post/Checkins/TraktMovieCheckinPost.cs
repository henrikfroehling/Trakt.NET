namespace TraktApiSharp.Objects.Post.Checkins
{
    using Get.Movies;
    using Newtonsoft.Json;

    public class TraktMovieCheckinPost : TraktCheckinPost
    {
        [JsonProperty(PropertyName = "movie")]
        public TraktMovie Movie { get; set; }
    }
}

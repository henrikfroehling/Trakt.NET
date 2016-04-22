namespace TraktApiSharp.Objects.Post.Checkins.Responses
{
    using Get.Movies;
    using Newtonsoft.Json;

    public class TraktMovieCheckinPostResponse : TraktCheckinPostResponse
    {
        [JsonProperty(PropertyName = "movie")]
        public TraktMovie Movie { get; set; }
    }
}

namespace TraktApiSharp.Objects.Post.Scrobbles.Responses
{
    using Get.Movies;
    using Newtonsoft.Json;

    public class TraktMovieScrobblePostResponse : TraktScrobblePostResponse
    {
        [JsonProperty(PropertyName = "movie")]
        public TraktMovie Movie { get; set; }
    }
}

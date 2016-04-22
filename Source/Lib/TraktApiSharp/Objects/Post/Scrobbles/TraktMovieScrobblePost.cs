namespace TraktApiSharp.Objects.Post.Scrobbles
{
    using Get.Movies;
    using Newtonsoft.Json;

    public class TraktMovieScrobblePost : TraktScrobblePost
    {
        [JsonProperty(PropertyName = "movie")]
        public TraktMovie Movie { get; set; }
    }
}

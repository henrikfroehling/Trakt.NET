namespace TraktApiSharp.Objects.Post.Scrobbles.Responses
{
    using Attributes;
    using Get.Movies;
    using Newtonsoft.Json;

    public class TraktMovieScrobblePostResponse : TraktScrobblePostResponse
    {
        [JsonProperty(PropertyName = "movie")]
        [Nullable]
        public TraktMovie Movie { get; set; }
    }
}

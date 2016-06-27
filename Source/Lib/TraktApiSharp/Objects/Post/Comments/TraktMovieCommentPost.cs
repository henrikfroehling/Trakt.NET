namespace TraktApiSharp.Objects.Post.Comments
{
    using Get.Movies;
    using Newtonsoft.Json;

    public class TraktMovieCommentPost : TraktCommentPost
    {
        [JsonProperty(PropertyName = "movie")]
        public TraktMovie Movie { get; set; }
    }
}

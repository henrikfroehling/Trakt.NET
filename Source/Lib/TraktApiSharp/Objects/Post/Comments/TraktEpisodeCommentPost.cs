namespace TraktApiSharp.Objects.Post.Comments
{
    using Get.Shows.Episodes;
    using Newtonsoft.Json;

    public class TraktEpisodeCommentPost : TraktCommentPost
    {
        [JsonProperty(PropertyName = "episode")]
        public TraktEpisode Episode { get; set; }
    }
}

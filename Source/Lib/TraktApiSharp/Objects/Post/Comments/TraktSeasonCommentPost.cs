namespace TraktApiSharp.Objects.Post.Comments
{
    using Get.Shows.Seasons;
    using Newtonsoft.Json;

    public class TraktSeasonCommentPost : TraktCommentPost
    {
        [JsonProperty(PropertyName = "season")]
        public TraktSeason Season { get; set; }
    }
}

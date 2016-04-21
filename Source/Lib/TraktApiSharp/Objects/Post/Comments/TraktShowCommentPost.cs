namespace TraktApiSharp.Objects.Post.Comments
{
    using Get.Shows;
    using Newtonsoft.Json;

    public class TraktShowCommentPost : TraktCommentPost
    {
        [JsonProperty(PropertyName = "show")]
        public TraktShow Show { get; set; }
    }
}

namespace TraktApiSharp.Objects.Post.Comments
{
    using Get.Users.Lists;
    using Newtonsoft.Json;

    public class TraktListCommentPost : TraktCommentPost
    {
        [JsonProperty(PropertyName = "list")]
        public TraktList List { get; set; }
    }
}

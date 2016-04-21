namespace TraktApiSharp.Objects.Post.Comments.Responses
{
    using Basic;
    using Newtonsoft.Json;

    public class TraktCommentPostResponse : TraktComment
    {
        [JsonProperty(PropertyName = "sharing")]
        public TraktSharing Sharing { get; set; }
    }
}

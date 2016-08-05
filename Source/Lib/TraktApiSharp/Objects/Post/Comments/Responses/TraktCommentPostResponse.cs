namespace TraktApiSharp.Objects.Post.Comments.Responses
{
    using Attributes;
    using Basic;
    using Newtonsoft.Json;

    public class TraktCommentPostResponse : TraktComment
    {
        [JsonProperty(PropertyName = "sharing")]
        [Nullable]
        public TraktSharing Sharing { get; set; }
    }
}

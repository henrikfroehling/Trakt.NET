namespace TraktApiSharp.Objects.Post.Comments
{
    using Basic;
    using Newtonsoft.Json;

    public abstract class TraktCommentPost
    {
        [JsonProperty(PropertyName = "comment")]
        public string Comment { get; set; }

        [JsonProperty(PropertyName = "spoiler")]
        public bool Spoiler { get; set; }

        [JsonProperty(PropertyName = "sharing")]
        public TraktSharing Sharing { get; set; }
    }
}

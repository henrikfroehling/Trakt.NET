namespace TraktApiSharp.Objects.Post.Comments
{
    using Newtonsoft.Json;

    public class TraktCommentReplyPost
    {
        [JsonIgnore]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "message")]
        public string Message { get; set; }

        [JsonProperty(PropertyName = "spoiler")]
        public bool Spoiler { get; set; }
    }
}

namespace TraktApiSharp.Objects.Post.Comments
{
    using Newtonsoft.Json;

    public class TraktCommentUpdatePost
    {
        [JsonProperty(PropertyName = "comment")]
        public string Comment { get; set; }

        [JsonProperty(PropertyName = "spoiler")]
        public bool Spoiler { get; set; }
    }
}

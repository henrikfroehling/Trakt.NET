namespace TraktApiSharp.Objects.Post.Comments
{
    using Newtonsoft.Json;
    using System;

    public class TraktCommentUpdatePost : IValidatable
    {
        [JsonProperty(PropertyName = "comment")]
        public string Comment { get; set; }

        [JsonProperty(PropertyName = "spoiler")]
        public bool Spoiler { get; set; }

        public void Validate()
        {
            if (string.IsNullOrEmpty(Comment))
                throw new ArgumentException("comment is empty");
        }
    }
}

namespace TraktApiSharp.Objects.Post.Comments
{
    using Get.Users.Lists;
    using Newtonsoft.Json;
    using System;

    public class TraktListCommentPost : TraktCommentPost, IValidatable
    {
        [JsonProperty(PropertyName = "list")]
        public TraktList List { get; set; }

        public void Validate()
        {
            if (List == null)
                throw new ArgumentNullException("list not set");

            if (List.Ids == null || !List.Ids.HasAnyId)
                throw new ArgumentException("list ids not set");
        }
    }
}

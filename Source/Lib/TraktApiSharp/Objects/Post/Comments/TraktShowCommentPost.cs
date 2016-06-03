namespace TraktApiSharp.Objects.Post.Comments
{
    using Get.Shows;
    using Newtonsoft.Json;
    using System;

    public class TraktShowCommentPost : TraktCommentPost, IValidatable
    {
        [JsonProperty(PropertyName = "show")]
        public TraktShow Show { get; set; }

        public void Validate()
        {
            if (Show == null)
                throw new ArgumentNullException("show not set");

            if (string.IsNullOrEmpty(Show.Title))
                throw new ArgumentException("show title not set");

            if (Show.Ids == null || !Show.Ids.HasAnyId)
                throw new ArgumentException("show ids not set");
        }
    }
}

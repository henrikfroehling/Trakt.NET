namespace TraktApiSharp.Objects.Post.Comments
{
    using Get.Shows.Seasons;
    using Newtonsoft.Json;
    using System;

    public class TraktSeasonCommentPost : TraktCommentPost, IValidatable
    {
        [JsonProperty(PropertyName = "season")]
        public TraktSeason Season { get; set; }

        public void Validate()
        {
            if (Season == null)
                throw new ArgumentNullException("season not set");

            if (Season.Ids == null || !Season.Ids.HasAnyId)
                throw new ArgumentException("season ids not set");
        }
    }
}

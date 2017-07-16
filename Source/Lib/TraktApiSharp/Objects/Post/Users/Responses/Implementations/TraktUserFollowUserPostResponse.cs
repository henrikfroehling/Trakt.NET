namespace TraktApiSharp.Objects.Post.Users.Responses.Implementations
{
    using Get.Users;
    using Newtonsoft.Json;
    using System;

    /// <summary>Represents the response for the approve of a follower request.</summary>
    public class TraktUserFollowUserPostResponse : ITraktUserFollowUserPostResponse
    {
        /// <summary>Gets or sets the UTC datetime, when the follower request was approved.</summary>
        [JsonProperty(PropertyName = "approved_at")]
        public DateTime? ApprovedAt { get; set; }

        /// <summary>Gets or sets the <see cref="ITraktUser" />, who was approved.<para>Nullable</para></summary>
        [JsonProperty(PropertyName = "user")]
        public ITraktUser User { get; set; }
    }
}

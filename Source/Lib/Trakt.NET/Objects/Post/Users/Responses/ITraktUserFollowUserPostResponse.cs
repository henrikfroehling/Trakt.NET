namespace TraktNet.Objects.Post.Users.Responses
{
    using Get.Users;
    using System;

    /// <summary>Represents the response for the approve of a follower request.</summary>
    public interface ITraktUserFollowUserPostResponse
    {
        /// <summary>Gets or sets the UTC datetime, when the follower request was approved.</summary>
        DateTime? ApprovedAt { get; set; }

        /// <summary>Gets or sets the <see cref="ITraktUser" />, who was approved.<para>Nullable</para></summary>
        ITraktUser User { get; set; }
    }
}

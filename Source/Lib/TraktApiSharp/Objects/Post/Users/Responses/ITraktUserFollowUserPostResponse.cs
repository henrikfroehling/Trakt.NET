namespace TraktApiSharp.Objects.Post.Users.Responses
{
    using Get.Users;
    using System;

    public interface ITraktUserFollowUserPostResponse
    {
        DateTime? ApprovedAt { get; set; }

        ITraktUser User { get; set; }
    }
}

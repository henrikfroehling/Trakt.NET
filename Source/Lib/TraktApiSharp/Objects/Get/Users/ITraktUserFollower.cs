namespace TraktNet.Objects.Get.Users
{
    using System;

    public interface ITraktUserFollower : ITraktUser
    {
        DateTime? FollowedAt { get; set; }

        ITraktUser User { get; set; }
    }
}

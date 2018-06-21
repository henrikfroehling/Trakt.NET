namespace TraktNet.Objects.Get.Users
{
    using System;

    public interface ITraktUserFriend : ITraktUser
    {
        DateTime? FriendsAt { get; set; }

        ITraktUser User { get; set; }
    }
}

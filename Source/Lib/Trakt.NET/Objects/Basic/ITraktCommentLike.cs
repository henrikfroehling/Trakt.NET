namespace TraktNet.Objects.Basic
{
    using Get.Users;
    using System;

    public interface ITraktCommentLike
    {
        DateTime? LikedAt { get; set; }

        ITraktUser User { get; set; }
    }
}

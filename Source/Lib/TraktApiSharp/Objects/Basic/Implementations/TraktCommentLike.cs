namespace TraktApiSharp.Objects.Basic
{
    using Get.Users;
    using System;

    public class TraktCommentLike : ITraktCommentLike
    {
        public DateTime? LikedAt { get; set; }

        public ITraktUser User { get; set; }
    }
}

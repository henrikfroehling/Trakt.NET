namespace TraktApiSharp.Objects.Get.Users
{
    using Basic;
    using Enums;
    using Lists;
    using System;

    public interface ITraktUserLikeItem
    {
        DateTime? LikedAt { get; set; }

        TraktUserLikeType Type { get; set; }

        ITraktComment Comment { get; set; }

        ITraktList List { get; set; }
    }
}

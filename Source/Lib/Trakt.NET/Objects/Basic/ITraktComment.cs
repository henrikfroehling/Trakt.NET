namespace TraktNet.Objects.Basic
{
    using Get.Users;
    using System;

    public interface ITraktComment
    {
        uint Id { get; set; }

        uint? ParentId { get; set; }

        DateTime CreatedAt { get; set; }

        DateTime? UpdatedAt { get; set; }

        string Comment { get; set; }

        bool Spoiler { get; set; }

        bool Review { get; set; }

        int? Replies { get; set; }

        int? Likes { get; set; }

        float? UserRating { get; set; }

        ITraktUser User { get; set; }
    }
}

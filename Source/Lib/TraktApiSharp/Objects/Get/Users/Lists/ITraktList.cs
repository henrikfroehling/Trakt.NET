namespace TraktNet.Objects.Get.Users.Lists
{
    using Enums;
    using System;

    public interface ITraktList
    {
        string Name { get; set; }

        string Description { get; set; }

        TraktAccessScope Privacy { get; set; }

        bool? DisplayNumbers { get; set; }

        bool? AllowComments { get; set; }

        string SortBy { get; set; }

        string SortHow { get; set; }

        DateTime? CreatedAt { get; set; }

        DateTime? UpdatedAt { get; set; }

        int? ItemCount { get; set; }

        int? CommentCount { get; set; }

        int? Likes { get; set; }

        ITraktListIds Ids { get; set; }

        ITraktUser User { get; set; }
    }
}

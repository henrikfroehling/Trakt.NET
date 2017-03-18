namespace TraktApiSharp.Objects.Get.Users
{
    using System;

    public interface ITraktUser
    {
        string Username { get; set; }

        bool? IsPrivate { get; set; }

        ITraktUserIds Ids { get; set; }

        string Name { get; set; }

        bool? IsVIP { get; set; }

        bool? IsVIP_EP { get; set; }

        DateTime? JoinedAt { get; set; }

        string Location { get; set; }

        string About { get; set; }

        string Gender { get; set; }

        int? Age { get; set; }

        TraktUserImages Images { get; set; }
    }
}

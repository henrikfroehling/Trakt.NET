namespace TraktApiSharp.Objects.Get.Users
{
    using System;

    public interface ITraktUserFollowRequest
    {
        uint Id { get; set; }

        DateTime? RequestedAt { get; set; }

        ITraktUser User { get; set; }
    }
}

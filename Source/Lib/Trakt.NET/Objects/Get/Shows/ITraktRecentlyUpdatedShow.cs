namespace TraktNet.Objects.Get.Shows
{
    using System;

    public interface ITraktRecentlyUpdatedShow : ITraktShow
    {
        DateTime? RecentlyUpdatedAt { get; set; }

        ITraktShow Show { get; set; }
    }
}

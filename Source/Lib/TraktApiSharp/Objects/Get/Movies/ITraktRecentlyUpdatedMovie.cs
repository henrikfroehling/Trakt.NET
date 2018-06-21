namespace TraktNet.Objects.Get.Movies
{
    using System;

    public interface ITraktRecentlyUpdatedMovie : ITraktMovie
    {
        DateTime? RecentlyUpdatedAt { get; set; }

        ITraktMovie Movie { get; set; }
    }
}

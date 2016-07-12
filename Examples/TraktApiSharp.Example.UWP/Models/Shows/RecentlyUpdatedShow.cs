namespace TraktApiSharp.Example.UWP.Models.Shows
{
    using Objects.Get.Shows;
    using System;

    public class RecentlyUpdatedShow : TraktShow
    {
        public DateTime? ShowUpdatedAt { get; set; }
    }
}

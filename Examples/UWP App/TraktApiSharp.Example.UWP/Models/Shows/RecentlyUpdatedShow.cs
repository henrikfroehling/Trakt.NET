namespace TraktApiSharp.Example.UWP.Models.Shows
{
    using Objects.Get.Shows;
    using TraktApiSharp.Objects.Get.Shows.Implementations;

    public class RecentlyUpdatedShow : TraktShow
    {
        public string ShowUpdatedAt { get; set; }
    }
}

namespace TraktApiSharp.Example.UWP.Models.Shows
{
    using Objects.Get.Shows;

    public class MostPWCShow : TraktShow
    {
        public int? WatcherCount { get; set; }

        public int? PlayCount { get; set; }

        public int? CollectedCount { get; set; }

        public int? CollectorCount { get; set; }
    }
}

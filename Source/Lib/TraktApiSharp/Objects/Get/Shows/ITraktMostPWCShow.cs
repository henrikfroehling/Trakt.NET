namespace TraktApiSharp.Objects.Get.Shows
{
    public interface ITraktMostPWCShow : ITraktShow
    {
        int? WatcherCount { get; set; }

        int? PlayCount { get; set; }

        int? CollectedCount { get; set; }

        int? CollectorCount { get; set; }

        ITraktShow Show { get; set; }
    }
}

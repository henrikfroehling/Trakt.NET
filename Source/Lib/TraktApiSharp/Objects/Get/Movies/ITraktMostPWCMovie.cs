namespace TraktApiSharp.Objects.Get.Movies
{
    public interface ITraktMostPWCMovie : ITraktMovie
    {
        int? WatcherCount { get; set; }

        int? PlayCount { get; set; }

        int? CollectedCount { get; set; }

        ITraktMovie Movie { get; set; }
    }
}

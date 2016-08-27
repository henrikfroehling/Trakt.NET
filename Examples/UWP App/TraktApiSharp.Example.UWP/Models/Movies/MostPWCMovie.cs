namespace TraktApiSharp.Example.UWP.Models.Movies
{
    using Objects.Get.Movies;

    public class MostPWCMovie : TraktMovie
    {
        public int? WatcherCount { get; set; }

        public int? PlayCount { get; set; }

        public int? CollectedCount { get; set; }
    }
}

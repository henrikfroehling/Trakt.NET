namespace TraktApiSharp.Example.UWP.Models.Movies
{
    using Objects.Get.Movies;
    using TraktApiSharp.Objects.Get.Movies.Implementations;

    public class MostPWCMovie : TraktMovie
    {
        public int? WatcherCount { get; set; }

        public int? PlayCount { get; set; }

        public int? CollectedCount { get; set; }
    }
}

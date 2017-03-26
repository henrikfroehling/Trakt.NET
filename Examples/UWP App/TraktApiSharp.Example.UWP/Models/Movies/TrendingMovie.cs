namespace TraktApiSharp.Example.UWP.Models.Movies
{
    using Objects.Get.Movies;
    using TraktApiSharp.Objects.Get.Movies.Implementations;

    public class TrendingMovie : TraktMovie
    {
        public int? Watchers { get; set; }
    }
}

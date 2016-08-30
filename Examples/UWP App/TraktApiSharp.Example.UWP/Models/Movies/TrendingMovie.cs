namespace TraktApiSharp.Example.UWP.Models.Movies
{
    using Objects.Get.Movies;

    public class TrendingMovie : TraktMovie
    {
        public int? Watchers { get; set; }
    }
}

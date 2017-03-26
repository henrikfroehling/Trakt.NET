namespace TraktApiSharp.Example.UWP.Models.Movies
{
    using Objects.Get.Movies;
    using TraktApiSharp.Objects.Get.Movies.Implementations;

    public class RecentlyUpdatedMovie : TraktMovie
    {
        public string MovieUpdatedAt { get; set; }
    }
}

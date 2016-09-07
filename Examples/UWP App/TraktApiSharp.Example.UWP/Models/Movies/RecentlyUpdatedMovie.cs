namespace TraktApiSharp.Example.UWP.Models.Movies
{
    using Objects.Get.Movies;

    public class RecentlyUpdatedMovie : TraktMovie
    {
        public string MovieUpdatedAt { get; set; }
    }
}

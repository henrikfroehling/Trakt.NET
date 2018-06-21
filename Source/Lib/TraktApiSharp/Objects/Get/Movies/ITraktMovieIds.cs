namespace TraktNet.Objects.Get.Movies
{
    using Basic;

    public interface ITraktMovieIds : IIds
    {
        uint Trakt { get; set; }

        string Slug { get; set; }

        string Imdb { get; set; }

        uint? Tmdb { get; set; }
    }
}

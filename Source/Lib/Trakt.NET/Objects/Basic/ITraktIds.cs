namespace TraktNet.Objects.Basic
{
    public interface ITraktIds : IIds
    {
        uint Trakt { get; set; }

        string Slug { get; set; }

        uint? Tvdb { get; set; }

        string Imdb { get; set; }

        uint? Tmdb { get; set; }

        uint? TvRage { get; set; }
    }
}

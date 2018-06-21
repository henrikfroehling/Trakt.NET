namespace TraktNet.Objects.Get.Episodes
{
    using Basic;

    public interface ITraktEpisodeIds : IIds
    {
        uint Trakt { get; set; }

        uint? Tvdb { get; set; }

        string Imdb { get; set; }

        uint? Tmdb { get; set; }

        uint? TvRage { get; set; }
    }
}

namespace TraktApiSharp.Objects.Get.Seasons
{
    using Basic;

    public interface ITraktSeasonIds : IIds
    {
        uint Trakt { get; set; }

        uint? Tvdb { get; set; }

        uint? Tmdb { get; set; }

        uint? TvRage { get; set; }
    }
}

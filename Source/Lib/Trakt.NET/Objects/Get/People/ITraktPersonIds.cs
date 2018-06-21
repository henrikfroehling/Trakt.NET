namespace TraktNet.Objects.Get.People
{
    using Basic;

    public interface ITraktPersonIds : IIds
    {
        uint Trakt { get; set; }

        string Slug { get; set; }

        string Imdb { get; set; }

        uint? Tmdb { get; set; }

        uint? TvRage { get; set; }
    }
}

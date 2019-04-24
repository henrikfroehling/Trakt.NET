namespace TraktNet.Objects.Get.Seasons
{
    using Basic;

    /// <summary>A collection of ids for various web services, including the Trakt id, for a Trakt season.</summary>
    public interface ITraktSeasonIds : IIds
    {
        /// <summary>Gets or sets the Trakt numeric id.</summary>
        uint Trakt { get; set; }

        /// <summary>Gets or sets the numeric id from thetvdb.com</summary>
        uint? Tvdb { get; set; }

        /// <summary>Gets or sets the numeric id from themoviedb.org</summary>
        uint? Tmdb { get; set; }

        /// <summary>Gets or sets the numeric id from tvrage.com</summary>
        uint? TvRage { get; set; }
    }
}

namespace TraktNet.Objects.Get.People
{
    using Basic;

    /// <summary>A collection of ids for various web services, including the Trakt id, for a Trakt person.</summary>
    public interface ITraktPersonIds : IIds
    {
        /// <summary>Gets or sets the Trakt numeric id.</summary>
        uint Trakt { get; set; }

        /// <summary>Gets or sets the Trakt slug.<para>Nullable</para></summary>
        string Slug { get; set; }

        /// <summary>Gets or sets the id from imdb.com<para>Nullable</para></summary>
        string Imdb { get; set; }

        /// <summary>Gets or sets the numeric id from themoviedb.org</summary>
        uint? Tmdb { get; set; }

        /// <summary>Gets or sets the numeric id from tvrage.com</summary>
        uint? TvRage { get; set; }
    }
}

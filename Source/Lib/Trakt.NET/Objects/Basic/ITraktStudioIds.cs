namespace TraktNet.Objects.Basic
{
    /// <summary>A collection of ids for various web services, including the Trakt id, for a Trakt studio.</summary>
    public interface ITraktStudioIds : IIds
    {
        /// <summary>Gets or sets the Trakt numeric id.</summary>
        uint Trakt { get; set; }

        /// <summary>Gets or sets the Trakt slug.<para>Nullable</para></summary>
        string Slug { get; set; }

        /// <summary>Gets or sets the numeric id from themoviedb.org</summary>
        uint? Tmdb { get; set; }
    }
}

namespace TraktNet.Objects.Get.Movies
{
    /// <summary>A collection of ids for various web services, including the Trakt id, for a Trakt movie.</summary>
    public class TraktMovieIds : ITraktMovieIds
    {
        /// <summary>Gets or sets the Trakt numeric id.</summary>
        public uint Trakt { get; set; }

        /// <summary>Gets or sets the Trakt slug.<para>Nullable</para></summary>
        public string Slug { get; set; }

        /// <summary>Gets or sets the id from imdb.com<para>Nullable</para></summary>
        public string Imdb { get; set; }

        /// <summary>Gets or sets the numeric id from themoviedb.org</summary>
        public uint? Tmdb { get; set; }

        /// <summary>Returns, whether any id has been set.</summary>
        public bool HasAnyId => Trakt > 0 || !string.IsNullOrEmpty(Slug) || !string.IsNullOrEmpty(Imdb) || Tmdb > 0;

        /// <summary>Gets the most reliable id from those that have been set.</summary>
        /// <returns>The id as a string or an empty string, if no id is set.</returns>
        public string GetBestId()
        {
            if (Trakt > 0)
                return Trakt.ToString();

            if (!string.IsNullOrEmpty(Slug))
                return Slug;

            if (!string.IsNullOrEmpty(Imdb))
                return Imdb;

            if (Tmdb.HasValue && Tmdb.Value > 0)
                return Tmdb.Value.ToString();

            return string.Empty;
        }
    }
}

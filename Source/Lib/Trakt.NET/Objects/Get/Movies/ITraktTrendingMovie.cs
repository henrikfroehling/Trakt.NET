namespace TraktNet.Objects.Get.Movies
{
    /// <summary>A trending Trakt movie.</summary>
    public interface ITraktTrendingMovie : ITraktMovie
    {
        /// <summary>Gets or sets the watcher count for the <see cref="Movie" />.</summary>
        int? Watchers { get; set; }

        /// <summary>Gets or sets the Trakt movie. See also <seealso cref="ITraktMovie" />.<para>Nullable</para></summary>
        ITraktMovie Movie { get; set; }
    }
}

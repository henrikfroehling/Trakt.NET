namespace TraktNet.Objects.Get.Movies
{
    /// <summary>A played Trakt movie.</summary>
    public interface ITraktMostPWCMovie : ITraktMovie
    {
        /// <summary>Gets or sets the watcher count for the <see cref="Movie" />.</summary>
        int? WatcherCount { get; set; }

        /// <summary>Gets or sets the play count for the <see cref="Movie" />.</summary>
        int? PlayCount { get; set; }

        /// <summary>Gets or sets the collected count for the <see cref="Movie" />.</summary>
        int? CollectedCount { get; set; }

        /// <summary>Gets or sets the Trakt movie. See also <seealso cref="ITraktMovie" />.<para>Nullable</para></summary>
        ITraktMovie Movie { get; set; }
    }
}

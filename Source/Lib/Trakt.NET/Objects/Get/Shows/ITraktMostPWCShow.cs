namespace TraktNet.Objects.Get.Shows
{
    /// <summary>A played Trakt show.</summary>
    public interface ITraktMostPWCShow : ITraktShow
    {
        /// <summary>Gets or sets the watcher count for the <see cref="Show" />.</summary>
        int? WatcherCount { get; set; }

        /// <summary>Gets or sets the play count for the <see cref="Show" />.</summary>
        int? PlayCount { get; set; }

        /// <summary>Gets or sets the collected count for the <see cref="Show" />.</summary>
        int? CollectedCount { get; set; }

        /// <summary>Gets or sets the collectors count for the <see cref="Show" />.</summary>
        int? CollectorCount { get; set; }

        /// <summary>Gets or sets the Trakt show. See also <seealso cref="ITraktShow" />.<para>Nullable</para></summary>
        ITraktShow Show { get; set; }
    }
}

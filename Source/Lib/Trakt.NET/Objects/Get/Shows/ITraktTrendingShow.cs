namespace TraktNet.Objects.Get.Shows
{
    /// <summary>A trending Trakt show.</summary>
    public interface ITraktTrendingShow : ITraktShow
    {
        /// <summary>Gets or sets the watcher count for the <see cref="Show" />.</summary>
        int? Watchers { get; set; }

        /// <summary>Gets or sets the Trakt show. See also <seealso cref="ITraktShow" />.<para>Nullable</para></summary>
        ITraktShow Show { get; set; }
    }
}

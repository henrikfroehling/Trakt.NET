namespace TraktNet.Objects.Get.Seasons
{
    using Episodes;
    using System.Collections.Generic;

    /// <summary>Represents the watched progress of a Trakt season.</summary>
    public interface ITraktSeasonWatchedProgress : ITraktSeasonProgress
    {
        /// <summary>
        /// Gets or sets the watched episodes. See also <seealso cref="ITraktEpisodeWatchedProgress" />.
        /// <para>Nullable</para>
        /// </summary>
        IList<ITraktEpisodeWatchedProgress> Episodes { get; set; }
    }
}

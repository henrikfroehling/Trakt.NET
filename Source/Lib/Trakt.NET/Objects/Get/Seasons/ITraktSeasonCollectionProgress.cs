namespace TraktNet.Objects.Get.Seasons
{
    using Episodes;
    using System.Collections.Generic;

    /// <summary>Represents the collection progress of a Trakt season.</summary>
    public interface ITraktSeasonCollectionProgress : ITraktSeasonProgress
    {
        /// <summary>
        /// Gets or sets the collected episodes. See also <seealso cref="ITraktEpisodeCollectionProgress" />.
        /// <para>Nullable</para>
        /// </summary>
        IEnumerable<ITraktEpisodeCollectionProgress> Episodes { get; set; }
    }
}

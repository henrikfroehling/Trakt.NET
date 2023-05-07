namespace TraktNet.Objects.Get.Watched
{
    using System.Collections.Generic;

    /// <summary>Contains information about a watched Trakt season.</summary>
    public interface ITraktWatchedShowSeason
    {
        /// <summary>Gets or sets the number of the watched season.</summary>
        int? Number { get; set; }

        /// <summary>
        /// Gets or sets a list of watched episodes in the watched season.
        /// See also <seealso cref="ITraktWatchedShowEpisode" />.
        /// <para>Nullable</para>
        /// </summary>
        IList<ITraktWatchedShowEpisode> Episodes { get; set; }
    }
}

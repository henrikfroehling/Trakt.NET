namespace TraktNet.Objects.Get.Watched
{
    using System.Collections.Generic;

    /// <summary>Contains information about a watched Trakt season.</summary>
    public class TraktWatchedShowSeason : ITraktWatchedShowSeason
    {
        /// <summary>Gets or sets the number of the watched season.</summary>
        public int? Number { get; set; }

        /// <summary>
        /// Gets or sets a list of watched episodes in the watched season.
        /// See also <seealso cref="ITraktWatchedShowEpisode" />.
        /// <para>Nullable</para>
        /// </summary>
        public IList<ITraktWatchedShowEpisode> Episodes { get; set; }
    }
}

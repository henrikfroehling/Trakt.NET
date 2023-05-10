namespace TraktNet.Objects.Get.Collections
{
    using System.Collections.Generic;

    /// <summary>Contains information about a collected Trakt season.</summary>
    public interface ITraktCollectionShowSeason
    {
        /// <summary>Gets or sets the number of the collected season.</summary>
        int? Number { get; set; }

        /// <summary>
        /// Gets or sets a list of collected episodes in the collected season.
        /// See also <seealso cref="ITraktCollectionShowEpisode" />.
        /// <para>Nullable</para>
        /// </summary>
        IList<ITraktCollectionShowEpisode> Episodes { get; set; }
    }
}

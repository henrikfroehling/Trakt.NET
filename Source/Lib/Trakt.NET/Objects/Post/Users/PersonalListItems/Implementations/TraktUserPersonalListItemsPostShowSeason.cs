namespace TraktNet.Objects.Post.Users.PersonalListItems
{
    using System.Collections.Generic;

    /// <summary>An user personal list items post season, containing the required season number and optional episodes.</summary>
    public class TraktUserPersonalListItemsPostShowSeason : ITraktUserPersonalListItemsPostShowSeason
    {
        /// <summary>Gets or sets the required season number of the Trakt season.</summary>
        public int Number { get; set; }

        /// <summary>
        /// An optional list of <see cref="ITraktUserPersonalListItemsPostShowEpisode" />s.
        /// <para>
        /// If no episodes are set, the whole Trakt season will be added to the personal list.
        /// Otherwise, only the specified episodes will be added to the personal list.
        /// </para>
        /// </summary>
        public IEnumerable<ITraktUserPersonalListItemsPostShowEpisode> Episodes { get; set; }
    }
}

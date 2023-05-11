namespace TraktNet.Objects.Post.Users.PersonalListItems
{
    using Requests.Interfaces;
    using System.Collections.Generic;

    /// <summary>
    /// An user personal list items post, containing all movies, shows, seasons, episodes and / or people,
    /// which should be added to an user's personal list.
    /// </summary>
    public interface ITraktUserPersonalListItemsPost : IRequestBody
    {
        /// <summary>
        /// An optional list of <see cref="ITraktUserPersonalListItemsPostMovie" />s.
        /// <para>Each <see cref="ITraktUserPersonalListItemsPostMovie" /> must have at least a valid Trakt id.</para>
        /// </summary>
        IList<ITraktUserPersonalListItemsPostMovie> Movies { get; set; }

        /// <summary>
        /// An optional list of <see cref="ITraktUserPersonalListItemsPostShow" />s.
        /// <para>Each <see cref="ITraktUserPersonalListItemsPostShow" /> must have at least a valid Trakt id.</para>
        /// </summary>
        IList<ITraktUserPersonalListItemsPostShow> Shows { get; set; }

        /// <summary>
        /// An optional list of <see cref="ITraktUserPersonalListItemsPostSeason" />s.
        /// <para>Each <see cref="ITraktUserPersonalListItemsPostSeason" /> must have at least a valid Trakt id.</para>
        /// </summary>
        IList<ITraktUserPersonalListItemsPostSeason> Seasons { get; set; }

        /// <summary>
        /// An optional list of <see cref="ITraktUserPersonalListItemsPostEpisode" />s.
        /// <para>Each <see cref="ITraktUserPersonalListItemsPostEpisode" /> must have at least a valid Trakt id.</para>
        /// </summary>
        IList<ITraktUserPersonalListItemsPostEpisode> Episodes { get; set; }

        /// <summary>
        /// An optional list of <see cref="ITraktUserPersonalListItemsPostPerson" />s.
        /// <para>Each <see cref="ITraktUserPersonalListItemsPostPerson" /> must have at least a valid Trakt id and a name.</para>
        /// </summary>
        IList<ITraktUserPersonalListItemsPostPerson> People { get; set; }
    }
}

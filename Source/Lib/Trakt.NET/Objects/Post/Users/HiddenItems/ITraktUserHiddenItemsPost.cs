namespace TraktNet.Objects.Post.Users.HiddenItems
{
    using Get.Users;
    using Requests.Interfaces;
    using System.Collections.Generic;

    /// <summary>
    /// An user hidden items post, containing all movies, shows, seasons and / or users,
    /// which should be added to an user's hidden items list.
    /// </summary>
    public interface ITraktUserHiddenItemsPost : IRequestBody
    {
        /// <summary>
        /// An optional list of <see cref="ITraktUserHiddenItemsPostMovie" />s.
        /// <para>Each <see cref="ITraktUserHiddenItemsPostMovie" /> must have at least a valid Trakt id.</para>
        /// </summary>
        IList<ITraktUserHiddenItemsPostMovie> Movies { get; set; }

        /// <summary>
        /// An optional list of <see cref="ITraktUserHiddenItemsPostShow" />s.
        /// <para>Each <see cref="ITraktUserHiddenItemsPostShow" /> must have at least a valid Trakt id.</para>
        /// </summary>
        IList<ITraktUserHiddenItemsPostShow> Shows { get; set; }

        /// <summary>
        /// An optional list of <see cref="ITraktUserHiddenItemsPostSeason" />s.
        /// <para>Each <see cref="ITraktUserHiddenItemsPostSeason" /> must have at least a valid Trakt id and a name.</para>
        /// </summary>
        IList<ITraktUserHiddenItemsPostSeason> Seasons { get; set; }

        /// <summary>An optional list of <see cref="ITraktUser" />s.</summary>
        IList<ITraktUser> Users { get; set; }
    }
}

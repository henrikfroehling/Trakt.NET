namespace TraktNet.Objects.Post.Users.CustomListItems
{
    using Get.People;
    using Requests.Interfaces;
    using System.Collections.Generic;

    /// <summary>
    /// An user custom list items post, containing all movies, shows, episodes and / or people,
    /// which should be added to an user's custom list.
    /// </summary>
    public interface ITraktUserCustomListItemsPost : IRequestBody
    {
        /// <summary>
        /// An optional list of <see cref="ITraktUserCustomListItemsPostMovie" />s.
        /// <para>Each <see cref="ITraktUserCustomListItemsPostMovie" /> must have at least a valid Trakt id.</para>
        /// </summary>
        IEnumerable<ITraktUserCustomListItemsPostMovie> Movies { get; set; }

        /// <summary>
        /// An optional list of <see cref="ITraktUserCustomListItemsPostShow" />s.
        /// <para>Each <see cref="ITraktUserCustomListItemsPostShow" /> must have at least a valid Trakt id.</para>
        /// </summary>
        IEnumerable<ITraktUserCustomListItemsPostShow> Shows { get; set; }

        /// <summary>
        /// An optional list of <see cref="ITraktPerson" />s.
        /// <para>Each <see cref="ITraktPerson" /> must have at least a valid Trakt id and a name.</para>
        /// </summary>
        IEnumerable<ITraktPerson> People { get; set; }
    }
}

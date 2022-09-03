namespace TraktNet.Objects.Post.Users.PersonalListItems
{
    using Get.People;
    using Requests.Interfaces;
    using System.Collections.Generic;

    /// <summary>
    /// An user personal list items post, containing all movies, shows, episodes and / or people,
    /// which should be added to an user's personal list.
    /// </summary>
    public interface ITraktUserPersonalListItemsPost : IRequestBody
    {
        /// <summary>
        /// An optional list of <see cref="ITraktUserPersonalListItemsPostMovie" />s.
        /// <para>Each <see cref="ITraktUserPersonalListItemsPostMovie" /> must have at least a valid Trakt id.</para>
        /// </summary>
        IEnumerable<ITraktUserPersonalListItemsPostMovie> Movies { get; set; }

        /// <summary>
        /// An optional list of <see cref="ITraktUserPersonalListItemsPostShow" />s.
        /// <para>Each <see cref="ITraktUserPersonalListItemsPostShow" /> must have at least a valid Trakt id.</para>
        /// </summary>
        IEnumerable<ITraktUserPersonalListItemsPostShow> Shows { get; set; }

        /// <summary>
        /// An optional list of <see cref="ITraktPerson" />s.
        /// <para>Each <see cref="ITraktPerson" /> must have at least a valid Trakt id and a name.</para>
        /// </summary>
        IEnumerable<ITraktPerson> People { get; set; }
    }
}

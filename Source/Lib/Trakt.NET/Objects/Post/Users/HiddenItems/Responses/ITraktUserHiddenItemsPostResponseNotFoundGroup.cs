namespace TraktNet.Objects.Post.Users.HiddenItems.Responses
{
    using Get.Users;
    using Post.Responses;
    using System.Collections.Generic;

    /// <summary>A collection containing the ids of movies, shows and seasons, which were not found.</summary>
    public interface ITraktUserHiddenItemsPostResponseNotFoundGroup
    {
        /// <summary>
        /// A list of <see cref="ITraktPostResponseNotFoundMovie" />s, containing the ids of movies, which were not found.
        /// <para>Nullable</para>
        /// </summary>
        IList<ITraktPostResponseNotFoundMovie> Movies { get; set; }

        /// <summary>
        /// A list of <see cref="ITraktPostResponseNotFoundShow" />s, containing the ids of shows, which were not found.
        /// <para>Nullable</para>
        /// </summary>
        IList<ITraktPostResponseNotFoundShow> Shows { get; set; }

        /// <summary>
        /// A list of <see cref="ITraktPostResponseNotFoundSeason" />s, containing the ids of seasons, which were not found.
        /// <para>Nullable</para>
        /// </summary>
        IList<ITraktPostResponseNotFoundSeason> Seasons { get; set; }

        /// <summary>
        /// A list of <see cref="ITraktUser" />s, containing users, which were not found.
        /// <para>Nullable</para>
        /// </summary>
        IList<ITraktUser> Users { get; set; }
    }
}

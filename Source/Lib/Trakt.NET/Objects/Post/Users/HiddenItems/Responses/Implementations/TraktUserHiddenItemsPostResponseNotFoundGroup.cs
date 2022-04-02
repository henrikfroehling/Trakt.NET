namespace TraktNet.Objects.Post.Users.HiddenItems.Responses
{
    using Get.Users;
    using Post.Responses;
    using System.Collections.Generic;

    /// <summary>A collection containing the ids of movies, shows and seasons, which were not found.</summary>
    public class TraktUserHiddenItemsPostResponseNotFoundGroup : ITraktUserHiddenItemsPostResponseNotFoundGroup
    {
        /// <summary>
        /// A list of <see cref="ITraktPostResponseNotFoundMovie" />, containing the ids of movies, which were not found.
        /// <para>Nullable</para>
        /// </summary>
        public IEnumerable<ITraktPostResponseNotFoundMovie> Movies { get; set; }

        /// <summary>
        /// A list of <see cref="ITraktPostResponseNotFoundShow" />, containing the ids of shows, which were not found.
        /// <para>Nullable</para>
        /// </summary>
        public IEnumerable<ITraktPostResponseNotFoundShow> Shows { get; set; }

        /// <summary>
        /// A list of <see cref="ITraktPostResponseNotFoundSeason" />, containing the ids of seasons, which were not found.
        /// <para>Nullable</para>
        /// </summary>
        public IEnumerable<ITraktPostResponseNotFoundSeason> Seasons { get; set; }

        /// <summary>
        /// A list of <see cref="ITraktUser" />s, containing users, which were not found.
        /// <para>Nullable</para>
        /// </summary>
        public IEnumerable<ITraktUser> Users { get; set; }
    }
}

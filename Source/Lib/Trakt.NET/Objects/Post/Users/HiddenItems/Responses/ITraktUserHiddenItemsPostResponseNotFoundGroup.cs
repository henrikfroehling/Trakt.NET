namespace TraktNet.Objects.Post.Users.HiddenItems.Responses
{
    using Post.Responses;
    using System.Collections.Generic;

    /// <summary>A collection containing the ids of movies, shows and seasons, which were not found.</summary>
    public interface ITraktUserHiddenItemsPostResponseNotFoundGroup
    {
        /// <summary>
        /// A list of <see cref="ITraktPostResponseNotFoundMovie" />, containing the ids of movies, which were not found.
        /// <para>Nullable</para>
        /// </summary>
        IEnumerable<ITraktPostResponseNotFoundMovie> Movies { get; set; }

        /// <summary>
        /// A list of <see cref="ITraktPostResponseNotFoundShow" />, containing the ids of shows, which were not found.
        /// <para>Nullable</para>
        /// </summary>
        IEnumerable<ITraktPostResponseNotFoundShow> Shows { get; set; }

        /// <summary>
        /// A list of <see cref="ITraktPostResponseNotFoundSeason" />, containing the ids of seasons, which were not found.
        /// <para>Nullable</para>
        /// </summary>
        IEnumerable<ITraktPostResponseNotFoundSeason> Seasons { get; set; }
    }
}

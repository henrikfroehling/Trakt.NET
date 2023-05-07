namespace TraktNet.Objects.Post.Users.PersonalListItems.Responses
{
    using Post.Responses;
    using System.Collections.Generic;

    /// <summary>A collection containing the ids of movies, shows, seasons, episodes and people, which were not found.</summary>
    public interface ITraktUserPersonalListItemsPostResponseNotFoundGroup
    {
        /// <summary>
        /// A list of <see cref="ITraktPostResponseNotFoundMovie" />, containing the ids of movies, which were not found.
        /// <para>Nullable</para>
        /// </summary>
        IList<ITraktPostResponseNotFoundMovie> Movies { get; set; }

        /// <summary>
        /// A list of <see cref="ITraktPostResponseNotFoundShow" />, containing the ids of shows, which were not found.
        /// <para>Nullable</para>
        /// </summary>
        IList<ITraktPostResponseNotFoundShow> Shows { get; set; }

        /// <summary>
        /// A list of <see cref="ITraktPostResponseNotFoundSeason" />, containing the ids of seasons, which were not found.
        /// <para>Nullable</para>
        /// </summary>
        IList<ITraktPostResponseNotFoundSeason> Seasons { get; set; }

        /// <summary>
        /// A list of <see cref="ITraktPostResponseNotFoundEpisode" />, containing the ids of episodes, which were not found.
        /// <para>Nullable</para>
        /// </summary>
        IList<ITraktPostResponseNotFoundEpisode> Episodes { get; set; }

        /// <summary>
        /// A list of <see cref="ITraktPostResponseNotFoundPerson" />, containing the ids of people, which were not found.
        /// <para>Nullable</para>
        /// </summary>
        IList<ITraktPostResponseNotFoundPerson> People { get; set; }
    }
}

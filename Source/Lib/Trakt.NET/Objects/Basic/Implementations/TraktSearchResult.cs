namespace TraktNet.Objects.Basic
{
    using Enums;
    using Get.Episodes;
    using Get.Movies;
    using Get.People;
    using Get.Shows;
    using Get.Users.Lists;

    /// <summary>A Trakt search result.</summary>
    public class TraktSearchResult : ITraktSearchResult
    {
        /// <summary>Gets or sets the result type. See also <seealso cref="TraktSearchResultType" />.<para>Nullable</para></summary>
        public TraktSearchResultType Type { get; set; }

        /// <summary>Gets or sets the result score.</summary>
        public float? Score { get; set; }

        /// <summary>
        /// Gets or sets the result movie, if <see cref="Type" /> is <see cref="TraktSearchResultType.Movie" />.
        /// See also <seealso cref="ITraktMovie" />.
        /// <para>Nullable</para>
        /// </summary>
        public ITraktMovie Movie { get; set; }

        /// <summary>
        /// Gets or sets the result show, if <see cref="Type" /> is <see cref="TraktSearchResultType.Show" />.
        /// See also <seealso cref="ITraktShow" />.
        /// <para>Nullable</para>
        /// </summary>
        public ITraktShow Show { get; set; }

        /// <summary>
        /// Gets or sets the result episode, if <see cref="Type" /> is <see cref="TraktSearchResultType.Episode" />.
        /// See also <seealso cref="ITraktEpisode" />.
        /// <para>Nullable</para>
        /// </summary>
        public ITraktEpisode Episode { get; set; }

        /// <summary>
        /// Gets or sets the result person, if <see cref="Type" /> is <see cref="TraktSearchResultType.Person" />.
        /// See also <seealso cref="ITraktPerson" />.
        /// <para>Nullable</para>
        /// </summary>
        public ITraktPerson Person { get; set; }

        /// <summary>
        /// Gets or sets the result list, if <see cref="Type" /> is <see cref="TraktSearchResultType.List" />.
        /// See also <seealso cref="ITraktList" />.
        /// <para>Nullable</para>
        /// </summary>
        public ITraktList List { get; set; }
    }
}

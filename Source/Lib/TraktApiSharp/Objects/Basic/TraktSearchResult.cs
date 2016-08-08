namespace TraktApiSharp.Objects.Basic
{
    using Attributes;
    using Enums;
    using Get.Movies;
    using Get.People;
    using Get.Shows;
    using Get.Shows.Episodes;
    using Get.Users.Lists;
    using Newtonsoft.Json;

    /// <summary>A Trakt search result.</summary>
    public class TraktSearchResult
    {
        /// <summary>Gets or sets the result type. See also <seealso cref="TraktSearchResultType" />.<para>Nullable</para></summary>
        [JsonProperty(PropertyName = "type")]
        [JsonConverter(typeof(TraktEnumerationConverter<TraktSearchResultType>))]
        [Nullable]
        public TraktSearchResultType Type { get; set; }

        /// <summary>Gets or sets the result score.</summary>
        [JsonProperty(PropertyName = "score")]
        public float? Score { get; set; }

        /// <summary>
        /// Gets or sets the result movie, if <see cref="Type" /> is <see cref="TraktSearchResultType.Movie" />.
        /// See also <seealso cref="TraktMovie" />.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "movie")]
        [Nullable]
        public TraktMovie Movie { get; set; }

        /// <summary>
        /// Gets or sets the result show, if <see cref="Type" /> is <see cref="TraktSearchResultType.Show" />.
        /// See also <seealso cref="TraktShow" />.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "show")]
        [Nullable]
        public TraktShow Show { get; set; }

        /// <summary>
        /// Gets or sets the result episode, if <see cref="Type" /> is <see cref="TraktSearchResultType.Episode" />.
        /// See also <seealso cref="TraktEpisode" />.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "episode")]
        [Nullable]
        public TraktEpisode Episode { get; set; }

        /// <summary>
        /// Gets or sets the result person, if <see cref="Type" /> is <see cref="TraktSearchResultType.Person" />.
        /// See also <seealso cref="TraktPerson" />.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "person")]
        [Nullable]
        public TraktPerson Person { get; set; }

        /// <summary>
        /// Gets or sets the result list, if <see cref="Type" /> is <see cref="TraktSearchResultType.List" />.
        /// See also <seealso cref="TraktList" />.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "list")]
        [Nullable]
        public TraktList List { get; set; }
    }
}

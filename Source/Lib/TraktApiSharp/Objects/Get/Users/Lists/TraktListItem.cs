namespace TraktApiSharp.Objects.Get.Users.Lists
{
    using Enums;
    using Episodes;
    using Movies;
    using Newtonsoft.Json;
    using People;
    using Seasons;
    using Shows;
    using System;
    using TraktApiSharp.Objects.Get.Episodes.Implementations;
    using TraktApiSharp.Objects.Get.Movies.Implementations;

    /// <summary>Represents a Trakt user list item.</summary>
    public class TraktListItem
    {
        /// <summary>Gets or sets the ranking number of the list item.<para>Nullable</para></summary>
        [JsonProperty(PropertyName = "rank")]
        public string Rank { get; set; }

        /// <summary>Gets or sets the UTC datetime, when the list item was added to a list.</summary>
        [JsonProperty(PropertyName = "listed_at")]
        public DateTime? ListedAt { get; set; }

        /// <summary>Gets or sets the list item type. See also <seealso cref="TraktListItemType" />.<para>Nullable</para></summary>
        [JsonProperty(PropertyName = "type")]
        [JsonConverter(typeof(TraktEnumerationConverter<TraktListItemType>))]
        public TraktListItemType Type { get; set; }

        /// <summary>
        /// Gets or sets the list item movie, if <see cref="Type" /> is <see cref="TraktListItemType.Movie" />.
        /// See also <seealso cref="TraktMovie" />.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "movie")]
        public TraktMovie Movie { get; set; }

        /// <summary>
        /// Gets or sets the list item show, if <see cref="Type" /> is <see cref="TraktListItemType.Show" />.
        /// See also <seealso cref="TraktShow" />.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "show")]
        public TraktShow Show { get; set; }

        /// <summary>
        /// Gets or sets the list item season, if <see cref="Type" /> is <see cref="TraktListItemType.Season" />.
        /// See also <seealso cref="TraktSeason" />.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "season")]
        public TraktSeason Season { get; set; }

        /// <summary>
        /// Gets or sets the list item episode, if <see cref="Type" /> is <see cref="TraktListItemType.Episode" />.
        /// See also <seealso cref="TraktEpisode" />.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "episode")]
        public TraktEpisode Episode { get; set; }

        /// <summary>
        /// Gets or sets the list item person, if <see cref="Type" /> is <see cref="TraktListItemType.Person" />.
        /// See also <seealso cref="TraktPerson" />.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "person")]
        public TraktPerson Person { get; set; }
    }
}

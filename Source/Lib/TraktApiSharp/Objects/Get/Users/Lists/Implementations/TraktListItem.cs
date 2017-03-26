namespace TraktApiSharp.Objects.Get.Users.Lists.Implementations
{
    using Enums;
    using Episodes;
    using Movies;
    using Newtonsoft.Json;
    using People;
    using Seasons;
    using Shows;
    using System;

    /// <summary>Represents a Trakt user list item.</summary>
    public class TraktListItem : ITraktListItem
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
        /// See also <seealso cref="ITraktMovie" />.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "movie")]
        public ITraktMovie Movie { get; set; }

        /// <summary>
        /// Gets or sets the list item show, if <see cref="Type" /> is <see cref="TraktListItemType.Show" />.
        /// See also <seealso cref="ITraktShow" />.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "show")]
        public ITraktShow Show { get; set; }

        /// <summary>
        /// Gets or sets the list item season, if <see cref="Type" /> is <see cref="TraktListItemType.Season" />.
        /// See also <seealso cref="ITraktSeason" />.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "season")]
        public ITraktSeason Season { get; set; }

        /// <summary>
        /// Gets or sets the list item episode, if <see cref="Type" /> is <see cref="TraktListItemType.Episode" />.
        /// See also <seealso cref="ITraktEpisode" />.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "episode")]
        public ITraktEpisode Episode { get; set; }

        /// <summary>
        /// Gets or sets the list item person, if <see cref="Type" /> is <see cref="TraktListItemType.Person" />.
        /// See also <seealso cref="ITraktPerson" />.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "person")]
        public ITraktPerson Person { get; set; }
    }
}

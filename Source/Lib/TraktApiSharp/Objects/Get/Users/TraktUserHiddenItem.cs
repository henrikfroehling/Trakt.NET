namespace TraktApiSharp.Objects.Get.Users
{
    using Enums;
    using Movies;
    using Newtonsoft.Json;
    using Seasons;
    using Shows;
    using System;
    using TraktApiSharp.Objects.Get.Movies.Implementations;
    using TraktApiSharp.Objects.Get.Seasons.Implementations;
    using TraktApiSharp.Objects.Get.Shows.Implementations;

    /// <summary>Contains information about a Trakt user's hidden item, including the corresponding movie, show or season.</summary>
    public class TraktUserHiddenItem
    {
        /// <summary>Gets or sets the UTC datetime, when the movie, show or season was hidden.</summary>
        [JsonProperty(PropertyName = "hidden_at")]
        public DateTime? HiddenAt { get; set; }

        /// <summary>
        /// Gets or sets the object type, which this hidden item contains.
        /// See also <seealso cref="TraktHiddenItemType" />.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        [JsonConverter(typeof(TraktEnumerationConverter<TraktHiddenItemType>))]
        public TraktHiddenItemType Type { get; set; }

        /// <summary>
        /// Gets or sets the movie, if <see cref="Type" /> is <see cref="TraktHiddenItemType.Movie" />.
        /// See also <seealso cref="TraktMovie" />.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "movie")]
        public TraktMovie Movie { get; set; }

        /// <summary>
        /// Gets or sets the show, if <see cref="Type" /> is <see cref="TraktHiddenItemType.Show" />.
        /// See also <seealso cref="TraktShow" />.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "show")]
        public TraktShow Show { get; set; }

        /// <summary>
        /// Gets or sets the season, if <see cref="Type" /> is <see cref="TraktHiddenItemType.Season" />.
        /// See also <seealso cref="TraktSeason" />.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "season")]
        public TraktSeason Season { get; set; }
    }
}

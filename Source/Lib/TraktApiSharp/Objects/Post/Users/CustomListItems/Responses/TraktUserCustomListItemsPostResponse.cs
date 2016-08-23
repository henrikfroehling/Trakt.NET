namespace TraktApiSharp.Objects.Post.Users.CustomListItems.Responses
{
    using Attributes;
    using Newtonsoft.Json;

    /// <summary>
    /// Represents the response for an user custom list items post. See also <see cref="TraktUserCustomListItemsPost" />.
    /// <para>Contains the number of added, existing and not found movies, shows, seasons, episodes and people.</para>
    /// </summary>
    public class TraktUserCustomListItemsPostResponse
    {
        /// <summary>
        /// A collection containing the number of added movies, shows, seasons, episodes and people.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "added")]
        [Nullable]
        public TraktUserCustomListItemsPostResponseGroup Added { get; set; }

        /// <summary>
        /// A collection containing the number of existing movies, shows, seasons, episodes and people.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "existing")]
        [Nullable]
        public TraktUserCustomListItemsPostResponseGroup Existing { get; set; }

        /// <summary>
        /// A collection containing the ids of movies, shows, seasons, episodes and people, which were not found.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "not_found")]
        [Nullable]
        public TraktUserCustomListItemsPostResponseNotFound NotFound { get; set; }
    }
}

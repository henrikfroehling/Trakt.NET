namespace TraktApiSharp.Objects.Post.Users.CustomListItems.Responses.Implementations
{
    using Newtonsoft.Json;

    /// <summary>
    /// Represents the response for an user custom list items remove post. See also <see cref="TraktUserCustomListItemsPost" />.
    /// <para>Contains the number of deleted and not found movies, shows, seasons, episodes and people.</para>
    /// </summary>
    public class TraktUserCustomListItemsRemovePostResponse : ITraktUserCustomListItemsRemovePostResponse
    {
        /// <summary>
        /// A collection containing the number of deleted movies, shows, seasons, episodes and people.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "deleted")]
        public ITraktUserCustomListItemsPostResponseGroup Deleted { get; set; }

        /// <summary>
        /// A collection containing the ids of movies, shows, seasons, episodes and people, which were not found.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "not_found")]
        public ITraktUserCustomListItemsPostResponseNotFoundGroup NotFound { get; set; }
    }
}

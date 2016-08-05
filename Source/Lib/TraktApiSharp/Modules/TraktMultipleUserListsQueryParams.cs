namespace TraktApiSharp.Modules
{
    /// <summary>
    /// Collection containing multiple different combinations of usernames and list ids.
    /// </summary>
    /// <example>
    /// This example shows an instantiation of this class.
    /// <code>
    /// new TraktMultipleUserListsQueryParams
    /// {
    ///     // { username, list-id }
    ///     { "username-1", "list-id-1" },
    ///     { "username-2", "list-id-3" },
    ///     { "username-3", "list-id-5" }
    /// };
    /// </code>
    /// </example>
    public class TraktMultipleUserListsQueryParams : TraktMultipleQueryParams<TraktUserListsQueryParams>
    {
        /// <summary>Adds a new user list query parameter pack to the collection.</summary>
        /// <param name="usernameOrSlug">An username or slug for a Trakt user.</param>
        /// <param name="listId">A list id for a list, which belongs the an user with the given username or slug.</param>
        public void Add(string usernameOrSlug, string listId)
        {
            Add(new TraktUserListsQueryParams(usernameOrSlug, listId));
        }
    }

    /// <summary>
    /// A single query parameter for multiple user list queries.
    /// Contains a combination of an username or slug and a list id.
    /// </summary>
    public struct TraktUserListsQueryParams
    {
        /// <summary>Initializes a new instance of the <see cref="TraktUserListsQueryParams" /> class.</summary>
        /// <param name="username">A username or slug for a Trakt user.</param>
        /// <param name="listId"></param>
        public TraktUserListsQueryParams(string username, string listId)
        {
            Username = username;
            ListId = listId;
        }

        /// <summary>Returns the username of slug for a Trakt user.</summary>
        public string Username { get; }

        /// <summary>Returns the list id.</summary>
        public string ListId { get; }
    }
}

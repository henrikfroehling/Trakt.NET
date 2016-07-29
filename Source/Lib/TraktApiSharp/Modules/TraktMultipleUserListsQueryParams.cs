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
        public void Add(string username, string listId)
        {
            Add(new TraktUserListsQueryParams(username, listId));
        }
    }

    public struct TraktUserListsQueryParams
    {
        public TraktUserListsQueryParams(string username, string listId)
        {
            Username = username;
            ListId = listId;
        }

        public string Username { get; }

        public string ListId { get; }
    }
}

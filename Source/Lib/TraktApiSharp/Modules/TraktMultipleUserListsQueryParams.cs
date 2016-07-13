namespace TraktApiSharp.Modules
{
    using Utils;

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

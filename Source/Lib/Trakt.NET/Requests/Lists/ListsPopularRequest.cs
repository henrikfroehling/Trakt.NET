namespace TraktNet.Requests.Lists
{
    internal sealed class ListsPopularRequest : AListsRequest
    {
        public override string UriTemplate => "lists/popular{?page,limit}";
    }
}

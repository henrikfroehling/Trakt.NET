namespace TraktNet.Requests.Lists
{
    internal sealed class ListsPopularRequest : AListsRequest
    {
        public override string UriTemplate => "lists/popular{?extended,page,limit}";
    }
}

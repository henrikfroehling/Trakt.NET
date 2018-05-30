namespace TraktApiSharp.Requests.Lists
{
    internal sealed class ListsTrendingRequest : AListsRequest
    {
        public override string UriTemplate => "lists/trending{?page,limit}";
    }
}

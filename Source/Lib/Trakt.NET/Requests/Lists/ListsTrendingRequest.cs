namespace TraktNet.Requests.Lists
{
    using Objects.Get.Lists;

    internal sealed class ListsTrendingRequest : AListsRequest<ITraktTrendingList>
    {
        public override string UriTemplate => "lists/trending{?extended,page,limit}";
    }
}

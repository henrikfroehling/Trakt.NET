namespace TraktNet.Requests.Lists
{
    using Objects.Get.Lists;

    internal sealed class ListsPopularRequest : AListsRequest<ITraktPopularList>
    {
        public override string UriTemplate => "lists/popular{?extended,page,limit}";
    }
}

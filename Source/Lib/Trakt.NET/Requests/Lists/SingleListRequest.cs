using TraktNet.Objects.Get.Lists;

namespace TraktNet.Requests.Lists
{
    internal class SingleListRequest : AListRequest<ITraktList>
    {
        public override string UriTemplate => "lists/{id}";
    }
}

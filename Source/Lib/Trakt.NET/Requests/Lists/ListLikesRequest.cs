namespace TraktNet.Requests.Lists
{
    using Interfaces;
    using Objects.Get.Lists;
    using System.Collections.Generic;

    internal class ListLikesRequest : AListRequest<ITraktListLike>, ISupportsPagination
    {
        public override string UriTemplate => "lists/{id}/likes{?page,limit}";

        public uint? Page { get; set; }

        public uint? Limit { get; set; }

        public override IDictionary<string, object> GetUriPathParameters()
        {
            var uriParams = base.GetUriPathParameters();

            if (Page.HasValue)
                uriParams.Add("page", Page.Value.ToString());

            if (Limit.HasValue)
                uriParams.Add("limit", Limit.Value.ToString());

            return uriParams;
        }
    }
}

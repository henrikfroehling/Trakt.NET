namespace TraktNet.Requests.Lists
{
    using Enums;
    using Interfaces;
    using Objects.Basic;
    using Parameters;
    using System.Collections.Generic;

    internal class ListCommentsRequest : AListRequest<ITraktComment>, ISupportsPagination
    {
        public override string UriTemplate => "lists/{id}/comments{/sort_order}{?extended,page,limit}";

        internal TraktCommentSortOrder SortOrder { get; set; }

        internal TraktExtendedInfo ExtendedInfo { get; set; }

        public uint? Page { get; set; }

        public uint? Limit { get; set; }

        public override IDictionary<string, object> GetUriPathParameters()
        {
            var uriParams = base.GetUriPathParameters();

            if (SortOrder != null && SortOrder != TraktCommentSortOrder.Unspecified)
                uriParams.Add("sort_order", SortOrder.UriName);

            if (ExtendedInfo != null && ExtendedInfo.HasAnySet)
                uriParams.Add("extended", ExtendedInfo.ToString());

            if (Page.HasValue)
                uriParams.Add("page", Page.Value.ToString());

            if (Limit.HasValue)
                uriParams.Add("limit", Limit.Value.ToString());

            return uriParams;
        }
    }
}

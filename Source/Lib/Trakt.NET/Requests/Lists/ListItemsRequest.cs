namespace TraktNet.Requests.Lists
{
    using Enums;
    using Interfaces;
    using Objects.Get.Lists;
    using Parameters;
    using System.Collections.Generic;

    internal class ListItemsRequest : AListRequest<ITraktListItem>, ISupportsPagination
    {
        public override string UriTemplate => "lists/{id}/items{/type}{?extended,page,limit}";

        internal TraktListItemType Type { get; set; }

        public TraktExtendedInfo ExtendedInfo { get; set; }

        public uint? Page { get; set; }

        public uint? Limit { get; set; }

        public override IDictionary<string, object> GetUriPathParameters()
        {
            var uriParams = base.GetUriPathParameters();

            if (Type != null && Type != TraktListItemType.Unspecified)
                uriParams.Add("type", Type.UriName);

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

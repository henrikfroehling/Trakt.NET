namespace TraktNet.Requests.Lists
{
    using Base;
    using Interfaces;
    using Parameters;
    using System.Collections.Generic;

    internal abstract class AListsRequest<TListResponseContentType> : AGetRequest<TListResponseContentType>, ISupportsPagination
    {
        public TraktExtendedInfo ExtendedInfo { get; set; }

        public uint? Page { get; set; }

        public uint? Limit { get; set; }

        public override IDictionary<string, object> GetUriPathParameters()
        {
            var uriParams = new Dictionary<string, object>();

            if (ExtendedInfo != null && ExtendedInfo.HasAnySet)
                uriParams.Add("extended", ExtendedInfo.ToString());

            if (Page.HasValue)
                uriParams.Add("page", Page.Value.ToString());

            if (Limit.HasValue)
                uriParams.Add("limit", Limit.Value.ToString());

            return uriParams;
        }

        public override void Validate()
        {
        }
    }
}

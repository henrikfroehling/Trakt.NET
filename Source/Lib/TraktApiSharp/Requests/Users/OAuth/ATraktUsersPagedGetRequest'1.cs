namespace TraktApiSharp.Requests.Users.OAuth
{
    using Interfaces;
    using System.Collections.Generic;

    internal abstract class ATraktUsersPagedGetRequest<TResponseContentType> : AUsersGetRequest<TResponseContentType>, ISupportsPagination
    {
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

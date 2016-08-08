namespace TraktApiSharp.Requests.WithoutOAuth.Search
{
    using Enums;
    using Objects.Basic;
    using System.Collections.Generic;

    internal class TraktSearchIdLookupRequest : TraktSearchRequest<TraktSearchResult>
    {
        internal TraktSearchIdLookupRequest(TraktClient client) : base(client) { }

        internal TraktSearchIdType IdType { get; set; }

        internal string LookupId { get; set; }

        internal TraktSearchResultType ResultType { get; set; }

        protected override IDictionary<string, object> GetUriPathParameters()
        {
            var uriParams = base.GetUriPathParameters();

            uriParams.Add("id_type", IdType.UriName);
            uriParams.Add("id", LookupId);

            if (ResultType != null && ResultType != TraktSearchResultType.Unspecified)
                uriParams.Add("type", ResultType.UriName);

            return uriParams;
        }

        protected override string UriTemplate => "search/{id_type}/{id}{?type,extended,page,limit}";
    }
}

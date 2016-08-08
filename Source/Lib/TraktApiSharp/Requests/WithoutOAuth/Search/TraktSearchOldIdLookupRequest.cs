namespace TraktApiSharp.Requests.WithoutOAuth.Search
{
    using Enums;
    using Objects.Basic;
    using System.Collections.Generic;

    internal class TraktSearchOldIdLookupRequest : TraktSearchRequest<TraktSearchResult>
    {
        internal TraktSearchOldIdLookupRequest(TraktClient client) : base(client) { }

        internal TraktSearchIdLookupType Type { get; set; }

        internal string LookupId { get; set; }

        protected override IDictionary<string, object> GetUriPathParameters()
        {
            var uriParams = base.GetUriPathParameters();

            uriParams.Add("id_type", Type.UriName);
            uriParams.Add("id", LookupId);

            return uriParams;
        }

        protected override string UriTemplate => "search{?id_type,id,page,limit}";
    }
}

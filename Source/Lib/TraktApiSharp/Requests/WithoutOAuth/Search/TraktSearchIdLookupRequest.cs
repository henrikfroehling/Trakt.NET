namespace TraktApiSharp.Requests.WithoutOAuth.Search
{
    using Enums;
    using Objects.Basic;
    using System.Collections.Generic;

    internal class TraktSearchIdLookupRequest : TraktSearchRequest<TraktSearchIdLookupResult>
    {
        internal TraktSearchIdLookupRequest(TraktClient client) : base(client) { }

        internal TraktSearchLookupIdType Type { get; set; }

        internal string LookupId { get; set; }

        protected override IDictionary<string, object> GetUriPathParameters()
        {
            var uriParams = base.GetUriPathParameters();

            uriParams.Add("id_type", Type.AsString());
            uriParams.Add("lookup_id", LookupId);

            return uriParams;
        }

        protected override string UriTemplate => "search{?id_type,lookup_id}";
    }
}

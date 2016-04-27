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

        protected override IEnumerable<KeyValuePair<string, string>> GetSearchOptionParameters()
        {
            var searchParams = new Dictionary<string, string>();

            searchParams["id_type"] = Type.AsString();
            searchParams["id"] = LookupId;

            return searchParams;
        }
    }
}

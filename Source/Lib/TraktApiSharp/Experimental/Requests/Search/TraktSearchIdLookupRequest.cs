namespace TraktApiSharp.Experimental.Requests.Search
{
    using Enums;
    using System;
    using System.Collections.Generic;

    internal sealed class TraktSearchIdLookupRequest : ATraktSearchRequest
    {
        internal TraktSearchIdLookupRequest(TraktClient client) : base(client) { }

        internal TraktSearchIdType IdType { get; set; }

        internal string LookupId { get; set; }

        public IDictionary<string, object> GetUriPathParameters()
        {
            var uriParams = new Dictionary<string, object>();

            if (IdType == null)
                throw new ArgumentNullException(nameof(IdType));

            if (string.IsNullOrEmpty(LookupId))
                throw new ArgumentException("lookup id must not be empty", nameof(LookupId));

            uriParams.Add("id_type", IdType.UriName);
            uriParams.Add("id", LookupId);

            if (ResultTypes != null && ResultTypes != TraktSearchResultType.Unspecified)
                uriParams.Add("type", ResultTypes.UriName);

            return uriParams;
        }

        public string UriTemplate => "search/{id_type}/{id}{?type,extended,page,limit}";
    }
}

namespace TraktApiSharp.Experimental.Requests.Search
{
    using Enums;
    using Interfaces;
    using System;
    using System.Collections.Generic;
    using TraktApiSharp.Requests.Params;

    internal sealed class TraktSearchTextQueryRequest : ATraktSearchRequest, ITraktFilterable
    {
        internal TraktSearchTextQueryRequest(TraktClient client) : base(client) { }

        public TraktCommonFilter Filter { get; set; }

        internal TraktSearchField SearchFields { get; set; }

        internal string Query { get; set; }

        public override IDictionary<string, object> GetUriPathParameters()
        {
            var uriParams = base.GetUriPathParameters();

            if (ResultTypes == null)
                throw new ArgumentNullException(nameof(ResultTypes));

            if (string.IsNullOrEmpty(Query))
                throw new ArgumentException("query must not be empty", nameof(Query));

            uriParams.Add("type", ResultTypes.UriName);
            uriParams.Add("query", Query);

            if (SearchFields != null && SearchFields != TraktSearchField.Unspecified)
                uriParams.Add("fields", SearchFields.UriName);

            return uriParams;
        }

        public override string UriTemplate => "search/{type}{?query,fields,years,genres,languages,countries,runtimes,ratings,extended,page,limit}";
    }
}

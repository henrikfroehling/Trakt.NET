namespace TraktApiSharp.Experimental.Requests.Search
{
    using Enums;
    using Interfaces;
    using System;
    using System.Collections.Generic;
    using TraktApiSharp.Requests.Params;

    internal sealed class TraktSearchTextQueryRequest : ATraktSearchRequest, ITraktSupportsFilter
    {
        public TraktCommonFilter Filter { get; set; }

        internal TraktSearchField SearchFields { get; set; }

        internal string Query { get; set; }

        public override string UriTemplate => "search/{type}{?query,fields,years,genres,languages,countries,runtimes,ratings,extended,page,limit}";

        public override IDictionary<string, object> GetUriPathParameters()
        {
            var uriParams = base.GetUriPathParameters();

            uriParams.Add("type", ResultTypes.UriName);
            uriParams.Add("query", Query);

            if (SearchFields != null && SearchFields != TraktSearchField.Unspecified)
                uriParams.Add("fields", SearchFields.UriName);

            if (Filter != null && Filter.HasValues)
            {
                var filterParameters = Filter.GetParameters();

                foreach (var param in filterParameters)
                    uriParams.Add(param.Key, param.Value);
            }

            return uriParams;
        }

        public override void Validate()
        {
            if (ResultTypes == null)
                throw new ArgumentNullException(nameof(ResultTypes));

            if (ResultTypes == TraktSearchResultType.Unspecified)
                throw new ArgumentException($"{nameof(ResultTypes)} must not be unspecified", nameof(ResultTypes));

            if (Query == null)
                throw new ArgumentNullException(nameof(Query));
            
            if (Query == string.Empty)
                throw new ArgumentException($"{nameof(Query)} must not be empty", nameof(Query));
        }
    }
}

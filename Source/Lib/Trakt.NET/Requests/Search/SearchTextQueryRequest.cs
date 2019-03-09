namespace TraktNet.Requests.Search
{
    using Enums;
    using Interfaces;
    using Parameters.Filter;
    using System;
    using System.Collections.Generic;

    internal sealed class SearchTextQueryRequest : ASearchRequest, ISupportsFilter
    {
        public ITraktFilter Filter { get; set; }

        internal TraktSearchField SearchFields { get; set; }

        internal string Query { get; set; }

        public override string UriTemplate => "search/{type}{?query,fields,years,genres,languages,countries,runtimes,ratings,certifications,networks,status,extended,page,limit}";

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
                throw new ArgumentException("result type must not be unspecified", nameof(ResultTypes));

            if (Query == null)
                throw new ArgumentNullException(nameof(Query));
        }
    }
}

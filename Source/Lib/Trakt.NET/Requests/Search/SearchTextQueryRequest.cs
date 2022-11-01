namespace TraktNet.Requests.Search
{
    using Enums;
    using Exceptions;
    using Interfaces;
    using Parameters.Filter;
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
                throw new TraktRequestValidationException(nameof(ResultTypes), "result type must not be null");

            if (ResultTypes == TraktSearchResultType.Unspecified)
                throw new TraktRequestValidationException(nameof(ResultTypes), "result type must not be unspecified");

            if (Query == null)
                throw new TraktRequestValidationException(nameof(Query), "query must not be null");

            if (Query.Length == 0)
                throw new TraktRequestValidationException(nameof(Query), "query must not be empty");
        }
    }
}

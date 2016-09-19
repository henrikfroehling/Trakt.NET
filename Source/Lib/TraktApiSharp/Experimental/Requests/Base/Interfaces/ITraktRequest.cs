namespace TraktApiSharp.Experimental.Requests.Base.Interfaces
{
    using System.Collections.Generic;
    using System.Net.Http;
    using TraktApiSharp.Requests;

    internal interface ITraktRequest<TRequestBody>
    {
        TraktClient Client { get; }

        HttpMethod Method { get; }

        TRequestBody RequestBody { get; set; }

        string Url { get; }

        string UriTemplate { get; }

        TraktAuthorizationRequirement AuthorizationRequirement { get; }

        TraktRequestObjectType? RequestObjectType { get; }

        HttpContent RequestBodyContent { get; }

        string RequestBodyJson { get; }

        IDictionary<string, object> GetUriPathParameters();

        void Validate();

        string BuildUrl();
    }
}

namespace TraktApiSharp.Experimental.Requests.Base
{
    using Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using TraktApiSharp.Requests;

    internal abstract class ATraktBaseRequest : ITraktRequest
    {
        internal ATraktBaseRequest(TraktClient client)
        {
            Client = client;
        }

        public abstract TraktAuthorizationRequirement AuthorizationRequirement { get; }

        public abstract HttpMethod Method { get; }

        public abstract string UriTemplate { get; }

        public string Url => BuildUrl();

        internal TraktClient Client { get; }

        public string BuildUrl()
        {
            throw new NotImplementedException();
        }

        public virtual IDictionary<string, object> GetUriPathParameters() => new Dictionary<string, object>();
    }
}

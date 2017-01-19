namespace TraktApiSharp.Experimental.Requests.Base
{
    using Interfaces.Base;
    using System.Collections.Generic;
    using System.Net.Http;
    using TraktApiSharp.Requests;

    internal abstract class TraktRequest<TContentType> : ITraktRequest<TContentType>
    {
        public abstract TraktAuthorizationRequirement AuthorizationRequirement { get; }

        public abstract HttpMethod Method { get; }

        public abstract string UriTemplate { get; }

        public abstract IDictionary<string, object> GetUriPathParameters();

        public abstract void Validate();
    }
}

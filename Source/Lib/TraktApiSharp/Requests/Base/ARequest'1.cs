namespace TraktApiSharp.Requests.Base
{
    using Interfaces.Base;
    using System.Collections.Generic;
    using System.Net.Http;

    internal abstract class ARequest<TResponseContentType> : ITraktRequest<TResponseContentType>
    {
        public abstract TraktAuthorizationRequirement AuthorizationRequirement { get; }

        public abstract HttpMethod Method { get; }

        public abstract string UriTemplate { get; }

        public abstract IDictionary<string, object> GetUriPathParameters();

        public abstract void Validate();
    }
}

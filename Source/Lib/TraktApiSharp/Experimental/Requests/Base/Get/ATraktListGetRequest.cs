namespace TraktApiSharp.Experimental.Requests.Base.Get
{
    using Interfaces;
    using System.Net.Http;
    using TraktApiSharp.Requests;

    internal abstract class ATraktListGetRequest<TItem> : ATraktListRequest<TItem>, ITraktRequest
    {
        internal ATraktListGetRequest(TraktClient client) : base(client) { }

        public abstract TraktAuthorizationRequirement AuthorizationRequirement { get; }

        public HttpMethod Method => HttpMethod.Get;
    }
}

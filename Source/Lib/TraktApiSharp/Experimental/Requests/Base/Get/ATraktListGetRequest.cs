namespace TraktApiSharp.Experimental.Requests.Base.Get
{
    using Interfaces.Requests;
    using System.Net.Http;
    using TraktApiSharp.Requests;

    internal abstract class ATraktListGetRequest<TItem> : ATraktListRequest<TItem>, ITraktRequest
    {
        public ATraktListGetRequest(TraktClient client) : base(client) { }

        public abstract TraktAuthorizationRequirement AuthorizationRequirement { get; }

        public HttpMethod Method => HttpMethod.Get;
    }
}

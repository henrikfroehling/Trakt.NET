namespace TraktApiSharp.Experimental.Requests.Base.Get
{
    using Interfaces;
    using System.Net.Http;
    using TraktApiSharp.Requests;

    internal abstract class ATraktSingleItemGetRequest<TItem> : ATraktSingleItemRequest<TItem>, ITraktRequest
    {
        public ATraktSingleItemGetRequest(TraktClient client) : base(client) { }

        public abstract TraktAuthorizationRequirement AuthorizationRequirement { get; }

        public HttpMethod Method => HttpMethod.Get;
    }
}

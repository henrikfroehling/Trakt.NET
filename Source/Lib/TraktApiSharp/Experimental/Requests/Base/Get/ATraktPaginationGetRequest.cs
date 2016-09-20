namespace TraktApiSharp.Experimental.Requests.Base.Get
{
    using Interfaces.Requests;
    using System.Net.Http;
    using TraktApiSharp.Requests;

    internal abstract class ATraktPaginationGetRequest<TItem> : ATraktPaginationRequest<TItem>, ITraktRequest
    {
        public ATraktPaginationGetRequest(TraktClient client) : base(client) { }

        public abstract TraktAuthorizationRequirement AuthorizationRequirement { get; }

        public HttpMethod Method => HttpMethod.Get;
    }
}

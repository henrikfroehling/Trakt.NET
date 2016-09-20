namespace TraktApiSharp.Experimental.Requests.Base.Post
{
    using System.Net.Http;
    using TraktApiSharp.Requests;

    internal abstract class ATraktPaginationBodylessPostRequest<TItem> : ATraktPaginationRequest<TItem, object>
    {
        public ATraktPaginationBodylessPostRequest(TraktClient client) : base(client) { }

        protected override HttpMethod Method => HttpMethod.Put;

        protected override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.Required;
    }
}

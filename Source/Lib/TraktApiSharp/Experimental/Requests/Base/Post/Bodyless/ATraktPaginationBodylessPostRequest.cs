namespace TraktApiSharp.Experimental.Requests.Base.Post.Bodyless
{
    using Interfaces.Requests;
    using System.Net.Http;
    using TraktApiSharp.Requests;

    internal abstract class ATraktPaginationBodylessPostRequest<TItem> : ATraktPaginationRequest<TItem>, ITraktRequest
    {
        public ATraktPaginationBodylessPostRequest(TraktClient client) : base(client) { }

        public TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.Required;

        public HttpMethod Method => HttpMethod.Post;
    }
}

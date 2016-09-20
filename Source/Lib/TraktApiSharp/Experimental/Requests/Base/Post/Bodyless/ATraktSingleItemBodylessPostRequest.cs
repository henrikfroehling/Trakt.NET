namespace TraktApiSharp.Experimental.Requests.Base.Post.Bodyless
{
    using Interfaces.Requests;
    using System.Net.Http;
    using TraktApiSharp.Requests;

    internal abstract class ATraktSingleItemBodylessPostRequest<TItem> : ATraktSingleItemRequest<TItem>, ITraktRequest
    {
        public ATraktSingleItemBodylessPostRequest(TraktClient client) : base(client) { }

        public TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.Required;

        public HttpMethod Method => HttpMethod.Post;
    }
}

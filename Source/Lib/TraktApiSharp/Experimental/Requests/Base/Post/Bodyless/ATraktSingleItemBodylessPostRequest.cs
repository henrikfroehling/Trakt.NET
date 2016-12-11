namespace TraktApiSharp.Experimental.Requests.Base.Post.Bodyless
{
    using Interfaces;
    using System.Net.Http;
    using TraktApiSharp.Requests;

    internal abstract class ATraktSingleItemBodylessPostRequest<TItem> : ATraktSingleItemRequest<TItem>, ITraktRequest
    {
        internal ATraktSingleItemBodylessPostRequest(TraktClient client) : base(client) { }

        public override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.Required;

        public override HttpMethod Method => HttpMethod.Post;
    }
}

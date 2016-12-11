namespace TraktApiSharp.Experimental.Requests.Base.Post.Bodyless
{
    using System.Net.Http;
    using TraktApiSharp.Requests;

    internal abstract class ATraktPaginationBodylessPostRequest<TItem> : ATraktPaginationRequest<TItem>
    {
        internal ATraktPaginationBodylessPostRequest(TraktClient client) : base(client) { }

        public override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.Required;

        public override HttpMethod Method => HttpMethod.Post;
    }
}

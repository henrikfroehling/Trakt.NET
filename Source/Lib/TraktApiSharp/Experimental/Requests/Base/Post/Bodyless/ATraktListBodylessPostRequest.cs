namespace TraktApiSharp.Experimental.Requests.Base.Post.Bodyless
{
    using Interfaces.Base.Post.Bodyless;
    using System.Net.Http;
    using TraktApiSharp.Requests;

    internal abstract class ATraktListBodylessPostRequest<TItem> : ATraktListRequest<TItem>, ITraktListBodylessPostRequest<TItem>
    {
        internal ATraktListBodylessPostRequest(TraktClient client) : base(client) { }

        public override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.Required;

        public override HttpMethod Method => HttpMethod.Post;
    }
}

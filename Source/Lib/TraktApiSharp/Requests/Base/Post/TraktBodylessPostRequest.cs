namespace TraktApiSharp.Requests.Base.Post
{
    using System.Net.Http;

    internal abstract class TraktBodylessPostRequest<TResult, TItem> : TraktRequest<TResult, TItem, object>
    {
        protected TraktBodylessPostRequest(TraktClient client) : base(client) { }

        protected override HttpMethod Method => HttpMethod.Post;

        protected override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.Required;
    }
}

namespace TraktApiSharp.Requests.Base.Post
{
    using System.Net.Http;

    internal abstract class TraktBodylessPostRequest<TResult, TItem> : TraktRequest<TResult, TItem, object>
    {
        protected TraktBodylessPostRequest(TraktClient client) : base(client) { }

        protected override HttpMethod Method { get { return HttpMethod.Post; } }

        protected override TraktAuthorizationRequirement AuthorizationRequirement { get { return TraktAuthorizationRequirement.Required; } }
    }
}

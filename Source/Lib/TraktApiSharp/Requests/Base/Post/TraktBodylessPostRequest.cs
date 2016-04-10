namespace TraktApiSharp.Requests.Base.Post
{
    using System.Net.Http;

    internal abstract class TraktBodylessPostRequest<TResult, TItem> : TraktRequest<TResult, TItem>
    {
        protected TraktBodylessPostRequest(TraktClient client) : base(client) { }

        protected override HttpMethod Method { get { return HttpMethod.Post; } }

        protected override TraktAuthenticationRequirement AuthenticationRequirement { get { return TraktAuthenticationRequirement.Required; } }
    }
}

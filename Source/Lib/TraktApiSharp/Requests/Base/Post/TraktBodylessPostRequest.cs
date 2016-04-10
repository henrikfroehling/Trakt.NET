namespace TraktApiSharp.Requests.Base.Post
{
    using System.Net.Http;

    internal abstract class TraktBodylessPostRequest<ResultType, ItemType> : TraktRequest<ResultType, ItemType>
    {
        protected TraktBodylessPostRequest(TraktClient client) : base(client) { }

        protected override HttpMethod Method { get { return HttpMethod.Post; } }

        protected override TraktAuthenticationRequirement AuthenticationRequirement { get { return TraktAuthenticationRequirement.Required; } }
    }
}

namespace TraktApiSharp.Requests.Base.Delete
{
    using System.Net.Http;

    internal abstract class TraktDeleteRequest : TraktRequest<object, object>
    {
        protected TraktDeleteRequest(TraktClient client) : base(client) { }

        protected override HttpMethod Method { get { return HttpMethod.Delete; } }

        protected override TraktAuthenticationRequirement AuthenticationRequirement { get { return TraktAuthenticationRequirement.Required; } }
    }
}

namespace TraktApiSharp.Requests.Base.Put
{
    using System;
    using System.Net.Http;

    internal abstract class TraktPutRequest<TResult, TItem> : TraktRequest<TResult, TItem>
    {
        protected TraktPutRequest(TraktClient client) : base(client) { }

        protected override HttpMethod Method { get { return HttpMethod.Put; } }

        protected override TraktAuthenticationRequirement AuthenticationRequirement { get { return TraktAuthenticationRequirement.Required; } }

        protected override void Validate()
        {
            base.Validate();

            if (RequestBody == null)
                throw new ArgumentException("request body not valid");
        }
    }
}

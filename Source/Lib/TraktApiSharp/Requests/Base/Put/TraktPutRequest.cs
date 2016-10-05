namespace TraktApiSharp.Requests.Base.Put
{
    using System;
    using System.Net.Http;

    internal abstract class TraktPutRequest<TResult, TItem, TRequestBody> : TraktRequest<TResult, TItem, TRequestBody>
    {
        protected TraktPutRequest(TraktClient client) : base(client) { }

        protected override HttpMethod Method => HttpMethod.Put;

        protected override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.Required;

        protected override void Validate()
        {
            base.Validate();

            if (RequestBody == null)
                throw new ArgumentException("request body not valid");
        }
    }
}

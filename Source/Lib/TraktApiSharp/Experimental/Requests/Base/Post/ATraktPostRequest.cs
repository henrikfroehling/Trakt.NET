namespace TraktApiSharp.Experimental.Requests.Base.Post
{
    using System;
    using System.Net.Http;
    using TraktApiSharp.Requests;

    internal abstract class ATraktPostRequest<TItem, TRequestBody> : ATraktRequest<TItem, TRequestBody>
    {
        public ATraktPostRequest(TraktClient client) : base(client) { }

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

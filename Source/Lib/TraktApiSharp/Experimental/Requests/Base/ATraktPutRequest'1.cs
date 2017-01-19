namespace TraktApiSharp.Experimental.Requests.Base
{
    using Interfaces.Base;
    using System;
    using System.Net.Http;
    using TraktApiSharp.Requests;

    internal abstract class ATraktPutRequest<TRequestBody> : ATraktRequest, ITraktPutRequest<TRequestBody>
    {
        public override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.Required;

        public sealed override HttpMethod Method => HttpMethod.Put;

        public abstract TRequestBody RequestBody { get; set; }

        public override void Validate()
        {
            if (RequestBody == null)
                throw new ArgumentNullException(nameof(RequestBody));
        }
    }
}

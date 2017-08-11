namespace TraktApiSharp.Requests.Base
{
    using Interfaces.Base;
    using System;
    using System.Net.Http;

    internal abstract class ATraktPostRequest<TRequestBodyType> : ATraktRequest, ITraktPostRequest<TRequestBodyType>
    {
        public override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.Required;

        public sealed override HttpMethod Method => HttpMethod.Post;

        public abstract TRequestBodyType RequestBody { get; set; }

        public override void Validate()
        {
            if (RequestBody == null)
                throw new ArgumentNullException(nameof(RequestBody));
        }
    }
}

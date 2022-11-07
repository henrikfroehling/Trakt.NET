namespace TraktNet.Requests.Base
{
    using Exceptions;
    using Interfaces;
    using Interfaces.Base;
    using System.Collections.Generic;
    using System.Net.Http;

    internal abstract class APostRequest<TRequestBodyType> : ARequest, IPostRequest<TRequestBodyType> where TRequestBodyType : IRequestBody
    {
        public override AuthorizationRequirement AuthorizationRequirement => AuthorizationRequirement.Required;

        public sealed override HttpMethod Method => HttpMethod.Post;

        public abstract TRequestBodyType RequestBody { get; set; }

        public override void Validate()
        {
            if (EqualityComparer<TRequestBodyType>.Default.Equals(RequestBody, default))
                throw new TraktRequestValidationException(nameof(RequestBody), "request body must not be null");

            RequestBody.Validate();
        }
    }
}

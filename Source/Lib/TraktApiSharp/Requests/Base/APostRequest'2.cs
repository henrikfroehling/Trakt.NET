namespace TraktApiSharp.Requests.Base
{
    using Interfaces.Base;
    using System;
    using System.Net.Http;

    internal abstract class APostRequest<TResponseContentType, TRequestBodyType> : ARequest<TResponseContentType>, IPostRequest<TResponseContentType, TRequestBodyType>
    {
        public override AuthorizationRequirement AuthorizationRequirement => AuthorizationRequirement.Required;

        public sealed override HttpMethod Method => HttpMethod.Post;

        public abstract TRequestBodyType RequestBody { get; set; }

        public override void Validate()
        {
            if (RequestBody == null)
                throw new ArgumentNullException(nameof(RequestBody));
        }
    }
}

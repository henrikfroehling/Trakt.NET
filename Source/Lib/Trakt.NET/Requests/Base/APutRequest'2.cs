namespace TraktNet.Requests.Base
{
    using Interfaces;
    using Interfaces.Base;
    using System;
    using System.Collections.Generic;
    using System.Net.Http;

    internal abstract class APutRequest<TResponseContentType, TRequestBodyType> : ARequest<TResponseContentType>, IPutRequest<TResponseContentType, TRequestBodyType> where TRequestBodyType : IRequestBody
    {
        public override AuthorizationRequirement AuthorizationRequirement => AuthorizationRequirement.Required;

        public sealed override HttpMethod Method => HttpMethod.Put;

        public abstract TRequestBodyType RequestBody { get; set; }

        public override void Validate()
        {
            if (EqualityComparer<TRequestBodyType>.Default.Equals(RequestBody, default))
                throw new ArgumentNullException(nameof(RequestBody));

            RequestBody.Validate();
        }
    }
}

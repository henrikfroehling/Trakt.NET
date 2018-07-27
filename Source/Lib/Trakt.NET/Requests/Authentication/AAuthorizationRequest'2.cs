namespace TraktNet.Requests.Authentication
{
    using Base;
    using Interfaces;
    using System.Collections.Generic;

    internal abstract class AAuthorizationRequest<TResponseContentType, TRequestBodyType> : APostRequest<TResponseContentType, TRequestBodyType> where TRequestBodyType : IRequestBody
    {
        public override AuthorizationRequirement AuthorizationRequirement => AuthorizationRequirement.NotRequired;

        public override TRequestBodyType RequestBody { get; set; }

        public override IDictionary<string, object> GetUriPathParameters() => new Dictionary<string, object>();
    }
}

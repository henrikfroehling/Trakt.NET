namespace TraktNet.Requests.Users.OAuth
{
    using Base;
    using Exceptions;
    using Extensions;
    using Interfaces;
    using System.Collections.Generic;

    internal abstract class AUsersPostByIdRequest<TResponseContentType, TRequestBodyType> : APostRequest<TResponseContentType, TRequestBodyType>, IHasId where TRequestBodyType : IRequestBody
    {
        public string Id { get; set; }

        public abstract RequestObjectType RequestObjectType { get; }

        public override TRequestBodyType RequestBody { get; set; }

        public override IDictionary<string, object> GetUriPathParameters()
            => new Dictionary<string, object>
            {
                ["id"] = Id
            };

        public override void Validate()
        {
            base.Validate();

            if (Id == null)
                throw new TraktRequestValidationException(nameof(Id), "id must not be null");

            if (Id == string.Empty || Id.ContainsSpace())
                throw new TraktRequestValidationException(nameof(Id), "id not valid");
        }
    }
}

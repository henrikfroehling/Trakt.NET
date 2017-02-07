namespace TraktApiSharp.Requests.Users.OAuth
{
    using Base;
    using Extensions;
    using Interfaces;
    using System;
    using System.Collections.Generic;

    internal abstract class ATraktUsersPostByIdRequest<TContentType, TRequestBody> : ATraktPostRequest<TContentType, TRequestBody>, ITraktHasId
    {
        public string Id { get; set; }

        public abstract TraktRequestObjectType RequestObjectType { get; }

        public override TRequestBody RequestBody { get; set; }

        public override IDictionary<string, object> GetUriPathParameters()
            => new Dictionary<string, object>
            {
                ["id"] = Id
            };

        public override void Validate()
        {
            base.Validate();

            if (Id == null)
                throw new ArgumentNullException(nameof(Id));

            if (Id == string.Empty || Id.ContainsSpace())
                throw new ArgumentException("id not valid", nameof(Id));
        }
    }
}

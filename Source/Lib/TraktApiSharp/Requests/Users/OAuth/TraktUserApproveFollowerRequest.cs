namespace TraktApiSharp.Requests.Users.OAuth
{
    using Base;
    using Extensions;
    using Interfaces;
    using Objects.Get.Users;
    using System;
    using System.Collections.Generic;
    using TraktApiSharp.Objects.Get.Users.Implementations;

    internal sealed class TraktUserApproveFollowerRequest : ATraktBodylessPostRequest<TraktUserFollower>, ITraktHasId
    {
        public string Id { get; set; }

        public TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Unspecified;

        public override string UriTemplate => "users/requests/{id}";

        public override IDictionary<string, object> GetUriPathParameters()
            => new Dictionary<string, object>
            {
                ["id"] = Id
            };

        public override void Validate()
        {
            if (Id == null)
                throw new ArgumentNullException(nameof(Id));

            if (Id == string.Empty || Id.ContainsSpace())
                throw new ArgumentException("id not valid", nameof(Id));
        }
    }
}

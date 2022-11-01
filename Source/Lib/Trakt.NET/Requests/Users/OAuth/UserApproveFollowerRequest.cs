namespace TraktNet.Requests.Users.OAuth
{
    using Base;
    using Exceptions;
    using Extensions;
    using Interfaces;
    using Objects.Get.Users;
    using System.Collections.Generic;

    internal sealed class UserApproveFollowerRequest : ABodylessPostRequest<ITraktUserFollower>, IHasId
    {
        public string Id { get; set; }

        public RequestObjectType RequestObjectType => RequestObjectType.Object;

        public override string UriTemplate => "users/requests/{id}";

        public override IDictionary<string, object> GetUriPathParameters()
            => new Dictionary<string, object>
            {
                ["id"] = Id
            };

        public override void Validate()
        {
            if (Id == null)
                throw new TraktRequestValidationException(nameof(Id), "id must not be null");

            if (Id == string.Empty || Id.ContainsSpace())
                throw new TraktRequestValidationException(nameof(Id), "id not valid");
        }
    }
}

namespace TraktApiSharp.Requests.Users.OAuth
{
    using Base;
    using Enums;
    using Interfaces;
    using Objects.Get.Users;
    using System.Collections.Generic;

    internal sealed class UserLikesRequest : AGetRequest<ITraktUserLikeItem>, ISupportsPagination
    {
        internal TraktUserLikeType Type { get; set; }

        public uint? Page { get; set; }

        public uint? Limit { get; set; }

        public override AuthorizationRequirement AuthorizationRequirement => AuthorizationRequirement.Required;

        public override string UriTemplate => "users/likes{/type}{?page,limit}";

        public override IDictionary<string, object> GetUriPathParameters()
        {
            var uriParams = new Dictionary<string, object>();

            if (Type != null && Type != TraktUserLikeType.Unspecified)
                uriParams.Add("type", Type.UriName);

            if (Page.HasValue)
                uriParams.Add("page", Page.Value.ToString());

            if (Limit.HasValue)
                uriParams.Add("limit", Limit.Value.ToString());

            return uriParams;
        }

        public override void Validate() { }
    }
}

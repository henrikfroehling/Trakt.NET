namespace TraktApiSharp.Experimental.Requests.Users.OAuth
{
    using Base.Get;
    using Enums;
    using Objects.Get.Users;
    using System.Collections.Generic;
    using TraktApiSharp.Requests;

    internal sealed class TraktUserLikesRequest : ATraktPaginationGetRequest<TraktUserLikeItem>
    {
        internal TraktUserLikesRequest(TraktClient client) : base(client) {}

        internal TraktUserLikeType Type { get; set; }

        public override IDictionary<string, object> GetUriPathParameters()
        {
            return base.GetUriPathParameters();
        }

        public override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.Required;

        public override string UriTemplate => "users/likes{/type}{?page,limit}";
    }
}

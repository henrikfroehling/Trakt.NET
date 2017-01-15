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
            var uriParams = base.GetUriPathParameters();

            if (Type != null && Type != TraktUserLikeType.Unspecified)
                uriParams.Add("type", Type.UriName);

            return uriParams;
        }

        public override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.Required;

        public override string UriTemplate => "users/likes{/type}{?page,limit}";
    }
}

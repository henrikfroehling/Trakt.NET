namespace TraktApiSharp.Experimental.Requests.Users.OAuth
{
    using Enums;
    using Objects.Get.Users;
    using System.Collections.Generic;
    using TraktApiSharp.Requests;

    internal sealed class TraktUserHiddenItemsRequest : ATraktUsersPaginationGetRequest<TraktUserHiddenItem>
    {
        internal TraktUserHiddenItemsRequest(TraktClient client) : base(client) {}

        internal TraktHiddenItemsSection Section { get; set; }

        internal TraktHiddenItemType Type { get; set; }

        public override IDictionary<string, object> GetUriPathParameters()
        {
            var uriParams = base.GetUriPathParameters();

            uriParams.Add("section", Section.UriName);

            if (Type != null && Type != TraktHiddenItemType.Unspecified)
                uriParams.Add("type", Type.UriName);

            return uriParams;
        }

        public override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.Required;

        public override string UriTemplate => "users/hidden/{section}{?type,extended,page,limit}";
    }
}

namespace TraktApiSharp.Experimental.Requests.Users.OAuth
{
    using Enums;
    using Objects.Get.Users;
    using System.Collections.Generic;
    using TraktApiSharp.Requests;

    internal sealed class TraktUserHiddenItemsRequest //: ATraktUsersPaginationGetRequest<TraktUserHiddenItem>
    {
        internal TraktUserHiddenItemsRequest(TraktClient client)  {}

        internal TraktHiddenItemsSection Section { get; set; }

        internal TraktHiddenItemType Type { get; set; }

        public IDictionary<string, object> GetUriPathParameters()
        {
            var uriParams = new Dictionary<string, object>();

            uriParams.Add("section", Section.UriName);

            if (Type != null && Type != TraktHiddenItemType.Unspecified)
                uriParams.Add("type", Type.UriName);

            return uriParams;
        }

        public new TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.Required;

        public string UriTemplate => "users/hidden/{section}{?type,extended,page,limit}";
    }
}

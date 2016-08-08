namespace TraktApiSharp.Requests.WithOAuth.Users
{
    using Base.Get;
    using Enums;
    using Objects.Basic;
    using Objects.Get.Users;
    using System.Collections.Generic;

    internal class TraktUserHiddenItemsRequest : TraktGetRequest<TraktPaginationListResult<TraktUserHiddenItem>, TraktUserHiddenItem>
    {
        internal TraktUserHiddenItemsRequest(TraktClient client) : base(client) { }

        protected override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.Required;

        internal TraktHiddenItemsSection Section { get; set; }

        internal TraktHiddenItemType Type { get; set; }

        protected override IDictionary<string, object> GetUriPathParameters()
        {
            var uriParams = base.GetUriPathParameters();

            uriParams.Add("section", Section.UriName);

            if (Type != null && Type != TraktHiddenItemType.Unspecified)
                uriParams.Add("type", Type.UriName);

            return uriParams;
        }

        protected override string UriTemplate => "users/hidden/{section}{?type,extended,page,limit}";

        protected override bool SupportsPagination => true;

        protected override bool IsListResult => true;
    }
}

namespace TraktNet.Requests.Users.OAuth
{
    using Base;
    using Enums;
    using Exceptions;
    using Objects.Get.Users;
    using System.Collections.Generic;

    internal sealed class UserHiddenItemsRequest : AUsersPagedGetRequest<ITraktUserHiddenItem>
    {
        internal TraktHiddenItemsSection Section { get; set; }

        internal TraktHiddenItemType Type { get; set; }

        public override AuthorizationRequirement AuthorizationRequirement => AuthorizationRequirement.Required;

        public override string UriTemplate => "users/hidden/{section}{?type,extended,page,limit}";

        public override IDictionary<string, object> GetUriPathParameters()
        {
            var uriParams = base.GetUriPathParameters();

            uriParams.Add("section", Section.UriName);

            if (Type != null && Type != TraktHiddenItemType.Unspecified)
                uriParams.Add("type", Type.UriName);

            return uriParams;
        }

        public override void Validate()
        {
            base.Validate();

            if (Section == null)
                throw new TraktRequestValidationException(nameof(Section), "section type must not be null");

            if (Section == TraktHiddenItemsSection.Unspecified)
                throw new TraktRequestValidationException(nameof(Section), "section type must not be unspecified");
        }
    }
}

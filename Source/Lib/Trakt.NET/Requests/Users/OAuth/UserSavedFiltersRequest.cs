namespace TraktNet.Requests.Users.OAuth
{
    using Base;
    using Enums;
    using Interfaces;
    using Objects.Get.Users;
    using System.Collections.Generic;

    internal sealed class UserSavedFiltersRequest : AGetRequest<ITraktUserSavedFilter>, ISupportsPagination
    {
        public override string UriTemplate => "users/saved_filters{?section,page,limit}";

        public override AuthorizationRequirement AuthorizationRequirement => AuthorizationRequirement.Required;

        public TraktFilterSection Section { get; set; }

        public uint? Page { get; set; }

        public uint? Limit { get; set; }

        public override IDictionary<string, object> GetUriPathParameters()
        {
            var uriParams = new Dictionary<string, object>();

            if (Section != null && Section != TraktFilterSection.Unspecified)
                uriParams.Add("section", Section.UriName);

            if (Page.HasValue)
                uriParams.Add("page", Page.Value.ToString());

            if (Limit.HasValue)
                uriParams.Add("limit", Limit.Value.ToString());

            return uriParams;
        }

        public override void Validate() { }
    }
}

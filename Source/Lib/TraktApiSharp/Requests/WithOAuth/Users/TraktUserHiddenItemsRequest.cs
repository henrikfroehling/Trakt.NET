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

        protected override TraktAuthenticationRequirement AuthenticationRequirement => TraktAuthenticationRequirement.Required;

        internal TraktHiddenItemsSection Section { get; set; }

        internal TraktHiddenItemType? Type { get; set; }

        protected override IEnumerable<KeyValuePair<string, string>> GetPathParameters()
        {
            return new Dictionary<string, string> { { "section", Section.AsString() } };
        }

        protected override string UriTemplate => "users/hidden/{section}";

        protected override bool SupportsPagination => true;

        protected override bool IsListResult => true;

        protected override bool UseCustomExtendedOptions => true;

        protected override IEnumerable<KeyValuePair<string, string>> GetCustomExtendedOptionParameters()
        {
            var optionParams = new Dictionary<string, string>();

            if (Type.HasValue)
                optionParams["type"] = Type.Value.ToString().ToLower();

            if (ExtendedOption != TraktExtendedOptionOld.Unspecified)
                optionParams["extended"] = ExtendedOption.AsString();

            return optionParams;
        }
    }
}

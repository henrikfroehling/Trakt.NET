namespace TraktApiSharp.Requests.WithoutOAuth.Shows
{
    using Base.Get;
    using Enums;
    using Objects.Basic;
    using Objects.Get.Shows;
    using System.Collections.Generic;

    internal class TraktShowCommentsRequest : TraktGetByIdRequest<TraktPaginationListResult<TraktShowComment>, TraktShowComment>
    {
        internal TraktShowCommentsRequest(TraktClient client) : base(client) { }

        internal TraktCommentSortOrder Sorting { get; set; }

        protected override IEnumerable<KeyValuePair<string, string>> GetPathParameters()
        {
            return new Dictionary<string, string> { { "sorting", Sorting.AsString() } };
        }

        protected override TraktAuthenticationRequirement AuthenticationRequirement => TraktAuthenticationRequirement.NotRequired;

        protected override string UriTemplate => "shows/{id}/comments/{sorting}";

        protected override bool SupportsPagination => true;

        protected override TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Shows;

        protected override bool IsListResult => true;
    }
}

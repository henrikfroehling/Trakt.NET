namespace TraktApiSharp.Requests.Shows.Common
{
    using Base.Get;
    using Objects;
    using Objects.Shows.Common;
    using System;
    using System.Collections.Generic;

    internal class TraktShowsRecentlyUpdatedRequest : TraktGetRequest<TraktPaginationListResult<TraktShowsRecentlyUpdatedItem>, TraktShowsRecentlyUpdatedItem>
    {
        internal TraktShowsRecentlyUpdatedRequest(TraktClient client) : base(client) { StartDate = DateTime.UtcNow; }

        internal DateTime? StartDate { get; set; }

        protected override IEnumerable<KeyValuePair<string, string>> GetPathParameters()
        {
            return new Dictionary<string, string> { { "start_date", StartDate.HasValue ? StartDate.Value.ToString("yyyy-MM-dd") : string.Empty } };
        }

        protected override string UriTemplate => "shows/updates/{start_date}";

        protected override TraktAuthenticationRequirement AuthenticationRequirement => TraktAuthenticationRequirement.NotRequired;

        protected override bool SupportsPagination => true;

        protected override TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Shows;

        protected override bool IsListResult => true;
    }
}

namespace TraktApiSharp.Requests.WithoutOAuth.Movies.Common
{
    using Base.Get;
    using Objects.Basic;
    using Objects.Get.Movies.Common;
    using System;
    using System.Collections.Generic;

    internal class TraktMoviesRecentlyUpdatedRequest : TraktGetRequest<TraktPaginationListResult<TraktMoviesRecentlyUpdatedItem>, TraktMoviesRecentlyUpdatedItem>
    {
        internal TraktMoviesRecentlyUpdatedRequest(TraktClient client) : base(client) { StartDate = DateTime.UtcNow; }

        internal DateTime? StartDate { get; set; }

        protected override IEnumerable<KeyValuePair<string, string>> GetPathParameters()
        {
            return new Dictionary<string, string> { { "start_date", StartDate.HasValue ? StartDate.Value.ToString("yyyy-MM-dd") : string.Empty } };
        }

        protected override string UriTemplate => "movies/updates/{start_date}";

        protected override TraktAuthenticationRequirement AuthenticationRequirement => TraktAuthenticationRequirement.NotRequired;

        protected override bool SupportsPagination => true;

        protected override TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Movies;

        protected override bool IsListResult => true;
    }
}

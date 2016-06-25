namespace TraktApiSharp.Requests.WithoutOAuth.Movies.Common
{
    using Base.Get;
    using Extensions;
    using Objects.Basic;
    using Objects.Get.Movies.Common;
    using System;
    using System.Collections.Generic;

    internal class TraktMoviesRecentlyUpdatedRequest : TraktGetRequest<TraktPaginationListResult<TraktRecentlyUpdatedMovie>, TraktRecentlyUpdatedMovie>
    {
        internal TraktMoviesRecentlyUpdatedRequest(TraktClient client) : base(client) { StartDate = DateTime.UtcNow; }

        internal DateTime? StartDate { get; set; }

        protected override IDictionary<string, object> GetUriPathParameters()
        {
            var uriParams = base.GetUriPathParameters();

            if (StartDate.HasValue)
                uriParams.Add("start_date", StartDate.Value.ToTraktDateString());

            return uriParams;
        }

        protected override string UriTemplate => "movies/updates{/start_date}{?extended,page,limit}";

        protected override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.NotRequired;

        protected override bool SupportsPagination => true;

        protected override bool IsListResult => true;
    }
}

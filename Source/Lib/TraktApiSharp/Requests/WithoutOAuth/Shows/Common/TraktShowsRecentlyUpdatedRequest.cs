namespace TraktApiSharp.Requests.WithoutOAuth.Shows.Common
{
    using Base.Get;
    using Extensions;
    using Objects.Basic;
    using Objects.Get.Shows.Common;
    using System;
    using System.Collections.Generic;

    internal class TraktShowsRecentlyUpdatedRequest : TraktGetRequest<TraktPaginationListResult<TraktRecentlyUpdatedShow>, TraktRecentlyUpdatedShow>
    {
        internal TraktShowsRecentlyUpdatedRequest(TraktClient client) : base(client) { StartDate = DateTime.UtcNow; }

        internal DateTime? StartDate { get; set; }

        protected override IDictionary<string, object> GetUriPathParameters()
        {
            var uriParams = base.GetUriPathParameters();

            if (StartDate.HasValue)
                uriParams.Add("start_date", StartDate.Value.ToTraktDateString());

            return uriParams;
        }

        protected override string UriTemplate => "shows/updates{/start_date}{?extended,page,limit}";

        protected override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.NotRequired;

        protected override bool SupportsPagination => true;

        protected override bool IsListResult => true;
    }
}

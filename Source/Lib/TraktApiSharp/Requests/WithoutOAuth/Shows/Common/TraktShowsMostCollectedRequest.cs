namespace TraktApiSharp.Requests.WithoutOAuth.Shows.Common
{
    using Base.Get;
    using Enums;
    using Objects.Basic;
    using Objects.Get.Shows.Common;
    using System.Collections.Generic;

    internal class TraktShowsMostCollectedRequest : TraktGetRequest<TraktPaginationListResult<TraktMostCollectedShow>, TraktMostCollectedShow>
    {
        internal TraktShowsMostCollectedRequest(TraktClient client) : base(client) { Period = TraktTimePeriod.Weekly; }

        internal TraktTimePeriod Period { get; set; }

        protected override IDictionary<string, object> GetUriPathParameters()
        {
            var uriParams = base.GetUriPathParameters();

            if (Period != null && Period != TraktTimePeriod.Unspecified)
                uriParams.Add("period", Period.UriName);

            return uriParams;
        }

        protected override string UriTemplate => "shows/collected{/period}{?extended,page,limit,query,years,genres,languages,countries,runtimes,ratings,certifications,networks,status}";

        protected override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.NotRequired;

        protected override bool SupportsPagination => true;

        protected override bool IsListResult => true;
    }
}

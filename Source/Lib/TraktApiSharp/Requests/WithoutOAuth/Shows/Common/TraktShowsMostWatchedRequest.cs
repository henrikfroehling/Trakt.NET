namespace TraktApiSharp.Requests.WithoutOAuth.Shows.Common
{
    using Base;
    using Base.Get;
    using Enums;
    using Objects.Basic;
    using Objects.Get.Shows.Common;
    using System.Collections.Generic;

    internal class TraktShowsMostWatchedRequest : TraktGetRequest<TraktPaginationListResult<TraktMostWatchedShow>, TraktMostWatchedShow>
    {
        internal TraktShowsMostWatchedRequest(TraktClient client) : base(client) { Period = TraktPeriod.Weekly; }

        internal TraktPeriod? Period { get; set; }

        protected override IDictionary<string, object> GetUriPathParameters()
        {
            var uriParams = base.GetUriPathParameters();

            if (Period.HasValue && Period.Value != TraktPeriod.Unspecified)
                uriParams.Add("period", Period.Value.AsString());

            return uriParams;
        }

        protected override string UriTemplate => "shows/watched{/period}{?extended,page,limit,query,years,genres,languages,countries,runtimes,ratings,certifications,networks,status}";

        protected override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.NotRequired;

        internal TraktShowFilter Filter { get; set; }

        protected override bool SupportsPagination => true;

        protected override bool IsListResult => true;
    }
}

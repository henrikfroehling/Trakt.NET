namespace TraktApiSharp.Requests.WithoutOAuth.Movies.Common
{
    using Base.Get;
    using Enums;
    using Objects.Basic;
    using Objects.Get.Movies.Common;
    using System.Collections.Generic;

    internal class TraktMoviesMostCollectedRequest : TraktGetRequest<TraktPaginationListResult<TraktMostCollectedMovie>, TraktMostCollectedMovie>
    {
        internal TraktMoviesMostCollectedRequest(TraktClient client) : base(client) { Period = TraktTimePeriod.Weekly; }

        internal TraktTimePeriod Period { get; set; }

        protected override IDictionary<string, object> GetUriPathParameters()
        {
            var uriParams = base.GetUriPathParameters();

            if (Period != null && Period != TraktTimePeriod.Unspecified)
                uriParams.Add("period", Period.UriName);

            return uriParams;
        }

        protected override string UriTemplate => "movies/collected{/period}{?extended,page,limit,query,years,genres,languages,countries,runtimes,ratings,certifications}";

        protected override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.NotRequired;

        protected override bool SupportsPagination => true;

        protected override bool IsListResult => true;
    }
}

namespace TraktApiSharp.Requests.WithoutOAuth.Movies.Common
{
    using Base;
    using Base.Get;
    using Enums;
    using Objects.Basic;
    using Objects.Get.Movies.Common;
    using System.Collections.Generic;

    internal class TraktMoviesMostPlayedRequest : TraktGetRequest<TraktPaginationListResult<TraktMostPlayedMovie>, TraktMostPlayedMovie>
    {
        internal TraktMoviesMostPlayedRequest(TraktClient client) : base(client) { Period = TraktPeriod.Weekly; }

        internal TraktPeriod? Period { get; set; }

        protected override IDictionary<string, object> GetUriPathParameters()
        {
            var uriParams = base.GetUriPathParameters();

            if (Period.HasValue && Period.Value != TraktPeriod.Unspecified)
                uriParams.Add("period", Period.Value.AsString());

            return uriParams;
        }

        protected override string UriTemplate => "movies/played{/period}{?extended,page,limit,query,years,genres,languages,countries,runtimes,ratings,certifications}";

        protected override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.NotRequired;

        internal TraktMovieFilter Filter { get; set; }

        protected override bool SupportsPagination => true;

        protected override bool IsListResult => true;
    }
}

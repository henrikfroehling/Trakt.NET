namespace TraktApiSharp.Requests.WithoutOAuth.Movies.Common
{
    using Base.Get;
    using Enums;
    using Objects.Basic;
    using Objects.Get.Movies.Common;
    using System.Collections.Generic;

    internal class TraktMoviesMostWatchedRequest : TraktGetRequest<TraktPaginationListResult<TraktMostWatchedMovie>, TraktMostWatchedMovie>
    {
        internal TraktMoviesMostWatchedRequest(TraktClient client) : base(client) { Period = TraktPeriod.Weekly; }

        internal TraktPeriod? Period { get; set; }

        protected override IDictionary<string, object> GetUriPathParameters()
        {
            var uriParams = base.GetUriPathParameters();

            if (Period.HasValue && Period.Value != TraktPeriod.Unspecified)
                uriParams.Add("period", Period.Value.AsString());

            return uriParams;
        }

        protected override string UriTemplate => "movies/watched{/period}";

        protected override TraktAuthenticationRequirement AuthenticationRequirement => TraktAuthenticationRequirement.NotRequired;

        protected override bool SupportsPagination => true;

        protected override bool IsListResult => true;
    }
}

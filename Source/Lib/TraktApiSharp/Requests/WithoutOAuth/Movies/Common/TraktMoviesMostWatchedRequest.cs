namespace TraktApiSharp.Requests.WithoutOAuth.Movies.Common
{
    using Base.Get;
    using Enums;
    using Objects.Basic;
    using Objects.Get.Movies.Common;
    using System.Collections.Generic;

    internal class TraktMoviesMostWatchedRequest : TraktGetRequest<TraktPaginationListResult<TraktMoviesMostWatchedItem>, TraktMoviesMostWatchedItem>
    {
        internal TraktMoviesMostWatchedRequest(TraktClient client) : base(client) { Period = TraktPeriod.Weekly; }

        internal TraktPeriod Period { get; set; }

        protected override IEnumerable<KeyValuePair<string, string>> GetPathParameters()
        {
            return new Dictionary<string, string> { { "period", Period.AsString() } };
        }

        protected override string UriTemplate => "movies/watched/{period}";

        protected override TraktAuthenticationRequirement AuthenticationRequirement => TraktAuthenticationRequirement.NotRequired;

        protected override bool SupportsPagination => true;

        protected override TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Movies;

        protected override bool IsListResult => true;
    }
}

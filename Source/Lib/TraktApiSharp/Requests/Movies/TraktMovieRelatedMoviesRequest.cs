namespace TraktApiSharp.Requests.Movies
{
    using Interfaces;
    using Objects.Get.Movies;
    using Parameters;
    using System.Collections.Generic;

    internal sealed class TraktMovieRelatedMoviesRequest : ATraktMovieRequest<TraktMovie>, ITraktSupportsExtendedInfo, ITraktSupportsPagination
    {
        public TraktExtendedInfo ExtendedInfo { get; set; }

        public int? Page { get; set; }

        public int? Limit { get; set; }

        public override string UriTemplate => "movies/{id}/related{?extended,page,limit}";

        public override IDictionary<string, object> GetUriPathParameters()
        {
            var uriParams = base.GetUriPathParameters();

            if (ExtendedInfo != null && ExtendedInfo.HasAnySet)
                uriParams.Add("extended", ExtendedInfo.ToString());

            if (Page.HasValue)
                uriParams.Add("page", Page.Value.ToString());

            if (Limit.HasValue)
                uriParams.Add("limit", Limit.Value.ToString());

            return uriParams;
        }
    }
}

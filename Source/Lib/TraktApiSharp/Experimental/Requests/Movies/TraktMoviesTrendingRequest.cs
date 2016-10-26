namespace TraktApiSharp.Experimental.Requests.Movies
{
    using Objects.Get.Movies.Common;
    using System;
    using TraktApiSharp.Requests;

    internal sealed class TraktMoviesTrendingRequest : ATraktMoviesRequest<TraktTrendingMovie>
    {
        internal TraktMoviesTrendingRequest(TraktClient client) : base(client) { }

        public override TraktAuthorizationRequirement AuthorizationRequirement
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override string UriTemplate
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }
}

namespace TraktApiSharp.Experimental.Requests.Movies
{
    using Objects.Get.Movies.Common;
    using System;
    using TraktApiSharp.Requests;

    internal sealed class TraktMoviesMostWatchedRequest : ATraktMoviesMostPWCRequest<TraktMostWatchedMovie>
    {
        internal TraktMoviesMostWatchedRequest(TraktClient client) : base(client) { }

        public override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.NotRequired;

        public override string UriTemplate
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }
}

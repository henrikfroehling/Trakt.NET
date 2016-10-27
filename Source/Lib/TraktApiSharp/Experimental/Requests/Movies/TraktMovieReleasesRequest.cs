namespace TraktApiSharp.Experimental.Requests.Movies
{
    using Base.Get;
    using Objects.Get.Movies;
    using System;
    using TraktApiSharp.Requests;

    internal sealed class TraktMovieReleasesRequest : ATraktListGetByIdRequest<TraktMovieRelease>
    {
        internal TraktMovieReleasesRequest(TraktClient client) : base(client) { }

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

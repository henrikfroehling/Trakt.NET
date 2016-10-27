namespace TraktApiSharp.Experimental.Requests.Movies
{
    using Base.Get;
    using Objects.Get.Movies.Common;
    using System;
    using TraktApiSharp.Requests;

    internal sealed class TraktMoviesRecentlyUpdatedRequest : ATraktPaginationGetRequest<TraktRecentlyUpdatedMovie>
    {
        internal TraktMoviesRecentlyUpdatedRequest(TraktClient client) : base(client) { }

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

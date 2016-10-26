namespace TraktApiSharp.Experimental.Requests.Movies
{
    using Objects.Get.Movies;
    using System;
    using TraktApiSharp.Requests;

    internal sealed class TraktMoviesPopularRequest : ATraktMoviesRequest<TraktMovie>
    {
        internal TraktMoviesPopularRequest(TraktClient client) : base(client) { }

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

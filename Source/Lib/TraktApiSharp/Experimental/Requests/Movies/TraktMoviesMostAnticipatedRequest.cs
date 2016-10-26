namespace TraktApiSharp.Experimental.Requests.Movies
{
    using Objects.Get.Movies.Common;
    using TraktApiSharp.Requests;

    internal sealed class TraktMoviesMostAnticipatedRequest : ATraktMoviesRequest<TraktMostAnticipatedMovie>
    {
        internal TraktMoviesMostAnticipatedRequest(TraktClient client) : base(client) { }

        public override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.NotRequired;

        public override string UriTemplate => "movies/anticipated{?extended,page,limit,query,years,genres,languages,countries,runtimes,ratings,certifications}";
    }
}

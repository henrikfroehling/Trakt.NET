namespace TraktApiSharp.Experimental.Requests.Movies
{
    using Base.Get;
    using Objects.Basic;
    using TraktApiSharp.Requests;

    internal sealed class TraktMovieCommentsRequest : ATraktPaginationGetByIdRequest<TraktComment>
    {
        internal TraktMovieCommentsRequest(TraktClient client) : base(client) { }

        public override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.NotRequired;

        public override string UriTemplate => "movies/{id}/comments{/sorting}{?page,limit}";
    }
}

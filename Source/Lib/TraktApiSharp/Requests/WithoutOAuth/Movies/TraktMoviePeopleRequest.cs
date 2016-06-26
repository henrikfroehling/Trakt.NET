namespace TraktApiSharp.Requests.WithoutOAuth.Movies
{
    using Base.Get;
    using Objects.Basic;

    internal class TraktMoviePeopleRequest : TraktGetByIdRequest<TraktCastAndCrew, TraktCastAndCrew>
    {
        internal TraktMoviePeopleRequest(TraktClient client) : base(client) { }

        protected override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.NotRequired;

        protected override string UriTemplate => "movies/{id}/people{?extended}";

        protected override TraktRequestObjectType? RequestObjectType => TraktRequestObjectType.Movies;
    }
}

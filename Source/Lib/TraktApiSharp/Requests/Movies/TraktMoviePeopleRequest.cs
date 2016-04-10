namespace TraktApiSharp.Requests.Movies
{
    using Base.Get;
    using Objects.Movies;

    internal class TraktMoviePeopleRequest : TraktGetByIdRequest<TraktMoviePeople, TraktMoviePeople>
    {
        internal TraktMoviePeopleRequest(TraktClient client) : base(client) { }

        protected override TraktAuthenticationRequirement AuthenticationRequirement => TraktAuthenticationRequirement.NotRequired;

        protected override string UriTemplate => "movies/{id}/people";

        protected override TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Movies;
    }
}

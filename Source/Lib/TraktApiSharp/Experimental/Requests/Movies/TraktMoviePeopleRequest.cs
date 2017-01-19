namespace TraktApiSharp.Experimental.Requests.Movies
{
    using Base.Get;
    using Interfaces;
    using Objects.Basic;
    using TraktApiSharp.Requests;
    using TraktApiSharp.Requests.Params;

    internal sealed class TraktMoviePeopleRequest : ATraktSingleItemGetByIdRequest<TraktCastAndCrew>, ITraktSupportsExtendedInfo
    {
        internal TraktMoviePeopleRequest(TraktClient client) : base(client) { }

        public override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.NotRequired;

        public TraktExtendedInfo ExtendedInfo { get; set; }

        public override TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Movies;

        public override string UriTemplate => "movies/{id}/people{?extended}";
    }
}

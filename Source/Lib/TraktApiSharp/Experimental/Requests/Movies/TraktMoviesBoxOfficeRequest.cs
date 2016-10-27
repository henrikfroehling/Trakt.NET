namespace TraktApiSharp.Experimental.Requests.Movies
{
    using Base.Get;
    using Interfaces;
    using Objects.Get.Movies.Common;
    using TraktApiSharp.Requests;
    using TraktApiSharp.Requests.Params;

    internal sealed class TraktMoviesBoxOfficeRequest : ATraktListGetRequest<TraktBoxOfficeMovie>, ITraktExtendedInfo
    {
        internal TraktMoviesBoxOfficeRequest(TraktClient client) : base(client) { }

        public override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.NotRequired;

        public TraktExtendedInfo ExtendedInfo { get; set; }

        public override string UriTemplate => "movies/boxoffice{?extended}";
    }
}

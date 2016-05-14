namespace TraktApiSharp.Requests.WithoutOAuth.Movies
{
    using Base.Get;
    using Objects.Get.Movies;
    using System.Collections.Generic;

    internal class TraktMovieSingleReleaseRequest : TraktGetByIdRequest<TraktMovieRelease, TraktMovieRelease>
    {
        internal TraktMovieSingleReleaseRequest(TraktClient client) : base(client) { }

        internal string LanguageCode { get; set; }

        protected override IEnumerable<KeyValuePair<string, string>> GetPathParameters()
        {
            return new Dictionary<string, string> { { "id", Id },
                                                    { "language", LanguageCode } };
        }

        protected override TraktAuthenticationRequirement AuthenticationRequirement => TraktAuthenticationRequirement.NotRequired;

        protected override string UriTemplate => "movies/{id}/releases/{language}";

        protected override TraktRequestObjectType? RequestObjectType => TraktRequestObjectType.Movies;
    }
}

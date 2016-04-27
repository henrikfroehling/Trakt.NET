namespace TraktApiSharp.Requests.WithoutOAuth.Movies
{
    using Base.Get;
    using Objects.Get.Movies;
    using System.Collections.Generic;

    internal class TraktMovieSingleTranslationRequest : TraktGetByIdRequest<TraktMovieTranslation, TraktMovieTranslation>
    {
        public TraktMovieSingleTranslationRequest(TraktClient client) : base(client) { }

        internal string LanguageCode { get; set; }

        protected override IEnumerable<KeyValuePair<string, string>> GetPathParameters()
        {
            return new Dictionary<string, string> { { "language", LanguageCode } };
        }

        protected override TraktAuthenticationRequirement AuthenticationRequirement => TraktAuthenticationRequirement.NotRequired;

        protected override string UriTemplate => "movies/{id}/translations/{language}";

        protected override TraktRequestObjectType? RequestObjectType => TraktRequestObjectType.Movies;

        protected override bool IsListResult => false;
    }
}

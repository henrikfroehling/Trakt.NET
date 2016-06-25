namespace TraktApiSharp.Requests.WithoutOAuth.Movies
{
    using Base.Get;
    using Objects.Get.Movies;
    using System.Collections.Generic;

    internal class TraktMovieSingleTranslationRequest : TraktGetByIdRequest<TraktMovieTranslation, TraktMovieTranslation>
    {
        public TraktMovieSingleTranslationRequest(TraktClient client) : base(client) { }

        internal string LanguageCode { get; set; }

        protected override IDictionary<string, object> GetUriPathParameters()
        {
            var uriParams = base.GetUriPathParameters();
            uriParams.Add("language", LanguageCode);
            return uriParams;
        }

        protected override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.NotRequired;

        protected override string UriTemplate => "movies/{id}/translations/{language}";

        protected override TraktRequestObjectType? RequestObjectType => TraktRequestObjectType.Movies;
    }
}

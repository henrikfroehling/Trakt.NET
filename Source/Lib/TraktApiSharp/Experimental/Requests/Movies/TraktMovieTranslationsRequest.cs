namespace TraktApiSharp.Experimental.Requests.Movies
{
    using Objects.Get.Movies;
    using System.Collections.Generic;

    internal sealed class TraktMovieTranslationsRequest : ATraktMovieRequest<TraktMovieTranslation>
    {
        internal string LanguageCode { get; set; }
        
        public override string UriTemplate => "movies/{id}/translations{/language}";

        public override IDictionary<string, object> GetUriPathParameters()
        {
            var uriParams = base.GetUriPathParameters();

            if (!string.IsNullOrEmpty(LanguageCode))
                uriParams.Add("language", LanguageCode);

            return uriParams;
        }
    }
}

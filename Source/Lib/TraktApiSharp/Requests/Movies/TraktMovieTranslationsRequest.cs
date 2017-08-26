namespace TraktApiSharp.Requests.Movies
{
    using Objects.Get.Movies;
    using System;
    using System.Collections.Generic;

    internal sealed class TraktMovieTranslationsRequest : AMovieRequest<ITraktMovieTranslation>
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

        public override void Validate()
        {
            base.Validate();

            if (LanguageCode != null && LanguageCode.Length != 2)
                throw new ArgumentOutOfRangeException(nameof(LanguageCode), "language code has wrong length");
        }
    }
}

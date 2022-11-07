namespace TraktNet.Requests.Seasons
{
    using Exceptions;
    using Objects.Get.Seasons;
    using System.Collections.Generic;

    internal class SeasonTranslationsRequest : ASeasonRequest<ITraktSeasonTranslation>
    {
        internal string LanguageCode { get; set; }

        public override string UriTemplate => "shows/{id}/seasons/{season}/translations{/language}";

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
                throw new TraktRequestValidationException(nameof(LanguageCode), "language code has wrong length; language code should be two characters long");
        }
    }
}

namespace TraktApiSharp.Experimental.Requests.Shows
{
    using Objects.Get.Shows;
    using System.Collections.Generic;

    internal sealed class TraktShowTranslationsRequest : ATraktShowRequest<TraktShowTranslation>
    {
        internal string LanguageCode { get; set; }

        public override string UriTemplate => "shows/{id}/translations{/language}";

        public override IDictionary<string, object> GetUriPathParameters()
        {
            var uriParams = base.GetUriPathParameters();

            if (!string.IsNullOrEmpty(LanguageCode))
                uriParams.Add("language", LanguageCode);

            return uriParams;
        }
    }
}

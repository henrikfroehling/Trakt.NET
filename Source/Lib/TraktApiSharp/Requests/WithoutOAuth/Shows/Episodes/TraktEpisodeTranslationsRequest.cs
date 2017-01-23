namespace TraktApiSharp.Requests.WithoutOAuth.Shows.Episodes
{
    using Objects.Get.Shows.Episodes;
    using System.Collections.Generic;

    internal class TraktEpisodeTranslationsRequest : TraktGetByIdEpisodeRequest<IEnumerable<TraktEpisodeTranslation>, TraktEpisodeTranslation>
    {
        public TraktEpisodeTranslationsRequest(TraktClient client) : base(client) { }

        internal string LanguageCode { get; set; }

        protected override IDictionary<string, object> GetUriPathParameters()
        {
            var uriParams = base.GetUriPathParameters();

            if (!string.IsNullOrEmpty(LanguageCode))
                uriParams.Add("language", LanguageCode);

            return uriParams;
        }

        protected override string UriTemplate => "shows/{id}/seasons/{season}/episodes/{episode}/translations/{language}";

        protected override bool IsListResult => true;
    }
}

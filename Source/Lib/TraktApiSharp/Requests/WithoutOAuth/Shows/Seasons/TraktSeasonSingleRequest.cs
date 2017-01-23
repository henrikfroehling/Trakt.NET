namespace TraktApiSharp.Requests.WithoutOAuth.Shows.Seasons
{
    using Objects.Get.Shows.Episodes;
    using System.Collections.Generic;

    internal class TraktSeasonSingleRequest : TraktGetByIdSeasonRequest<IEnumerable<TraktEpisode>, TraktEpisode>
    {
        internal TraktSeasonSingleRequest(TraktClient client) : base(client) { }

        internal string TranslationLanguageCode { get; set; }

        protected override IDictionary<string, object> GetUriPathParameters()
        {
            var uriParams = base.GetUriPathParameters();

            if (!string.IsNullOrEmpty(TranslationLanguageCode))
                uriParams.Add("translations", TranslationLanguageCode);

            return uriParams;
        }

        protected override string UriTemplate => "shows/{id}/seasons/{season}{?extended,translations}";

        protected override bool IsListResult => true;
    }
}

namespace TraktApiSharp.Requests.WithoutOAuth.Shows.Seasons
{
    using Base.Get;
    using Objects.Get.Shows.Seasons;
    using System.Collections.Generic;

    internal class TraktSeasonsAllRequest : TraktGetByIdRequest<IEnumerable<TraktSeason>, TraktSeason>
    {
        internal TraktSeasonsAllRequest(TraktClient client) : base(client) { }

        protected override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.NotRequired;

        internal string TranslationLanguageCode { get; set; }

        protected override IDictionary<string, object> GetUriPathParameters()
        {
            var uriParams = base.GetUriPathParameters();

            if (!string.IsNullOrEmpty(TranslationLanguageCode))
                uriParams.Add("translations", TranslationLanguageCode);

            return uriParams;
        }

        protected override string UriTemplate => "shows/{id}/seasons{?extended,translations}";

        protected override bool IsListResult => true;

        protected override TraktRequestObjectType? RequestObjectType => TraktRequestObjectType.Shows;
    }
}

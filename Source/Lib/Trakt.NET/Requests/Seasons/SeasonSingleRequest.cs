namespace TraktNet.Requests.Seasons
{
    using Exceptions;
    using Interfaces;
    using Objects.Get.Episodes;
    using Parameters;
    using System.Collections.Generic;

    internal sealed class SeasonSingleRequest : ASeasonRequest<ITraktEpisode>, ISupportsExtendedInfo
    {
        internal string TranslationLanguageCode { get; set; }

        public TraktExtendedInfo ExtendedInfo { get; set; }

        public override string UriTemplate => "shows/{id}/seasons/{season}{?extended,translations}";

        public override IDictionary<string, object> GetUriPathParameters()
        {
            var uriParams = base.GetUriPathParameters();

            if (!string.IsNullOrEmpty(TranslationLanguageCode))
                uriParams.Add("translations", TranslationLanguageCode);

            if (ExtendedInfo != null && ExtendedInfo.HasAnySet)
                uriParams.Add("extended", ExtendedInfo.ToString());

            return uriParams;
        }

        public override void Validate()
        {
            base.Validate();

            if (TranslationLanguageCode != null && TranslationLanguageCode != "all" && TranslationLanguageCode.Length != 2)
            {
                throw new TraktRequestValidationException(nameof(TranslationLanguageCode),
                    "translation language code has wrong length; translation language code should be two characters long");
            }
        }
    }
}

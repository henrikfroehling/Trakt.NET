namespace TraktApiSharp.Experimental.Requests.Seasons
{
    using Interfaces;
    using Objects.Get.Shows.Episodes;
    using System;
    using System.Collections.Generic;
    using TraktApiSharp.Requests.Params;

    internal sealed class TraktSeasonSingleRequest : ATraktSeasonRequest<TraktEpisode>, ITraktSupportsExtendedInfo
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
                throw new ArgumentOutOfRangeException(nameof(TranslationLanguageCode), "translation language code has wrong length");
        }
    }
}

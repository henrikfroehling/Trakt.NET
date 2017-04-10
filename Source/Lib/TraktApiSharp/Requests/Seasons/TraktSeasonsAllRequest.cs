namespace TraktApiSharp.Requests.Seasons
{
    using Base;
    using Extensions;
    using Interfaces;
    using Objects.Get.Seasons.Implementations;
    using Parameters;
    using System;
    using System.Collections.Generic;

    internal sealed class TraktSeasonsAllRequest : ATraktGetRequest<TraktSeason>, ITraktHasId, ITraktSupportsExtendedInfo
    {
        public string Id { get; set; }

        internal string TranslationLanguageCode { get; set; }

        public TraktExtendedInfo ExtendedInfo { get; set; }

        public TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Shows;

        public override string UriTemplate => "shows/{id}/seasons{?extended,translations}";

        public override IDictionary<string, object> GetUriPathParameters()
        {
            var uriParams = new Dictionary<string, object>
            {
                ["id"] = Id
            };

            if (!string.IsNullOrEmpty(TranslationLanguageCode))
                uriParams.Add("translations", TranslationLanguageCode);

            if (ExtendedInfo != null && ExtendedInfo.HasAnySet)
                uriParams.Add("extended", ExtendedInfo.ToString());

            return uriParams;
        }

        public override void Validate()
        {
            if (Id == null)
                throw new ArgumentNullException(nameof(Id));

            if (Id == string.Empty || Id.ContainsSpace())
                throw new ArgumentException("show id not valid", nameof(Id));

            if (TranslationLanguageCode != null && TranslationLanguageCode != "all" && TranslationLanguageCode.Length != 2)
                throw new ArgumentOutOfRangeException(nameof(TranslationLanguageCode), "translation language code has wrong length");
        }
    }
}

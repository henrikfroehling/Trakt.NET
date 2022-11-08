﻿namespace TraktNet.Requests.Seasons
{
    using Base;
    using Exceptions;
    using Extensions;
    using Interfaces;
    using Objects.Get.Seasons;
    using Parameters;
    using System.Collections.Generic;

    internal sealed class SeasonsAllRequest : AGetRequest<ITraktSeason>, IHasId, ISupportsExtendedInfo
    {
        public string Id { get; set; }

        internal string TranslationLanguageCode { get; set; }

        public TraktExtendedInfo ExtendedInfo { get; set; }

        public RequestObjectType RequestObjectType => RequestObjectType.Shows;

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
                throw new TraktRequestValidationException(nameof(Id), "show id must not be null");

            if (Id == string.Empty || Id.ContainsSpace())
                throw new TraktRequestValidationException(nameof(Id), "show id not valid");

            if (TranslationLanguageCode != null && TranslationLanguageCode != "all" && TranslationLanguageCode.Length != 2)
                throw new TraktRequestValidationException(nameof(TranslationLanguageCode), "translation language code has wrong length");
        }
    }
}

namespace TraktApiSharp.Requests.WithoutOAuth.Shows
{
    using Base.Get;
    using Objects.Get.Shows;
    using System.Collections.Generic;

    internal class TraktShowSingleTranslationRequest : TraktGetByIdRequest<TraktShowTranslation, TraktShowTranslation>
    {
        public TraktShowSingleTranslationRequest(TraktClient client) : base(client) { }

        internal string LanguageCode { get; set; }

        protected override IEnumerable<KeyValuePair<string, string>> GetPathParameters()
        {
            return new Dictionary<string, string> { { "language", LanguageCode } };
        }

        protected override TraktAuthenticationRequirement AuthenticationRequirement => TraktAuthenticationRequirement.NotRequired;

        protected override string UriTemplate => "shows/{id}/translations/{language}";

        protected override TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Shows;

        protected override bool IsListResult => false;
    }
}

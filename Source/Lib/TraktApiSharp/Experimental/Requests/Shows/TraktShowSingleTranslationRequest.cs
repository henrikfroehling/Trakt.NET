namespace TraktApiSharp.Experimental.Requests.Shows
{
    using Base.Get;
    using Objects.Get.Shows;
    using System.Collections.Generic;
    using TraktApiSharp.Requests;

    internal sealed class TraktShowSingleTranslationRequest : ATraktSingleItemGetByIdRequest<TraktShowTranslation>
    {
        internal TraktShowSingleTranslationRequest(TraktClient client) : base(client) { }

        internal string LanguageCode { get; set; }

        public override IDictionary<string, object> GetUriPathParameters()
        {
            var uriParams = base.GetUriPathParameters();
            uriParams.Add("language", LanguageCode);
            return uriParams;
        }

        public override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.NotRequired;

        public override TraktRequestObjectType RequestObjectType => TraktRequestObjectType.Shows;

        public override string UriTemplate => "shows/{id}/translations/{language}";
    }
}

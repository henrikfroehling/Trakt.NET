namespace TraktApiSharp.Requests.WithoutOAuth.Shows
{
    using Base.Get;
    using Objects.Get.Shows;
    using System.Collections.Generic;

    internal class TraktShowTranslationsRequest : TraktGetByIdRequest<IEnumerable<TraktShowTranslation>, TraktShowTranslation>
    {
        internal TraktShowTranslationsRequest(TraktClient client) : base(client) { }

        protected override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.NotRequired;

        protected override string UriTemplate => "shows/{id}/translations";

        protected override TraktRequestObjectType? RequestObjectType => TraktRequestObjectType.Shows;

        protected override bool IsListResult => true;
    }
}

namespace TraktApiSharp.Experimental.Requests.Shows
{
    using Base.Get;
    using Objects.Get.Shows;
    using System;
    using TraktApiSharp.Requests;

    internal sealed class TraktShowSingleTranslationRequest : ATraktSingleItemGetByIdRequest<TraktShowTranslation>
    {
        public TraktShowSingleTranslationRequest(TraktClient client) : base(client) { }

        public override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.NotRequired;

        public override string UriTemplate
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }
}

namespace TraktApiSharp.Experimental.Requests.Shows
{
    using Base.Get;
    using Objects.Get.Shows;
    using System;
    using TraktApiSharp.Requests;

    internal sealed class TraktShowSummaryRequest : ATraktSingleItemGetByIdRequest<TraktShow>
    {
        public TraktShowSummaryRequest(TraktClient client) : base(client) { }

        public override TraktAuthorizationRequirement AuthorizationRequirement
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override string UriTemplate
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }
}

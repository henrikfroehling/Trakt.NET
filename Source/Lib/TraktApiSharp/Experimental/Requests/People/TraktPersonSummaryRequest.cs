namespace TraktApiSharp.Experimental.Requests.People
{
    using Base.Get;
    using Objects.Get.People;
    using System;
    using TraktApiSharp.Requests;

    internal sealed class TraktPersonSummaryRequest : ATraktSingleItemGetByIdRequest<TraktPerson>
    {
        public TraktPersonSummaryRequest(TraktClient client) : base(client) { }

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

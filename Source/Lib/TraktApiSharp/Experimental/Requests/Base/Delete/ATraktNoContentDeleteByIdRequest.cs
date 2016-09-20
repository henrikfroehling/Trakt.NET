namespace TraktApiSharp.Experimental.Requests.Base.Delete
{
    using Interfaces;
    using System.Net.Http;
    using TraktApiSharp.Requests;

    internal abstract class ATraktNoContentDeleteByIdRequest : ATraktNoContentRequest, ITraktRequest, ITraktHasId
    {
        internal ATraktNoContentDeleteByIdRequest(TraktClient client) : base(client)
        {
            RequestId = new TraktRequestId();
        }

        public TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.Required;

        public HttpMethod Method => HttpMethod.Delete;

        public string Id
        {
            get { return RequestId.Id; }
            set { RequestId.Id = value; }
        }

        public TraktRequestId RequestId { get; set; }
    }
}

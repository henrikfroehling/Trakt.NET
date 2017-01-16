namespace TraktApiSharp.Experimental.Requests.Base.Put
{
    using Interfaces.Base;
    using System.Net.Http;
    using TraktApiSharp.Requests;

    internal abstract class ATraktNoContentPutRequest<TRequestBody> : ATraktNoContentRequest, ITraktHasRequestBody<TRequestBody>
    {
        internal ATraktNoContentPutRequest(TraktClient client) : base(client)
        {
            RequestBody = new TraktRequestBody<TRequestBody>();
        }

        public override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.Required;

        public override HttpMethod Method => HttpMethod.Put;

        public TraktRequestBody<TRequestBody> RequestBody { get; set; }

        public TRequestBody RequestBodyContent
        {
            get { return RequestBody.RequestBody; }
            set { RequestBody.RequestBody = value; }
        }
    }
}

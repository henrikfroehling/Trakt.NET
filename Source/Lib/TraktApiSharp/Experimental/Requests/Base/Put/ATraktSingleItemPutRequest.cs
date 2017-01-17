namespace TraktApiSharp.Experimental.Requests.Base.Put
{
    using Interfaces.Base;
    using Interfaces.Base.Put;
    using System.Net.Http;
    using TraktApiSharp.Requests;

    internal abstract class ATraktSingleItemPutRequest<TItem, TRequestBody> : ATraktSingleItemRequest<TItem>, ITraktSingleItemPutRequest<TItem, TRequestBody>
    {
        internal ATraktSingleItemPutRequest(TraktClient client) : base(client)
        {
            RequestBody = new TraktRequestBody<TRequestBody>();
        }

        public override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.Required;

        public override HttpMethod Method => HttpMethod.Put;

        public ITraktPostable<TRequestBody> RequestBody { get; set; }

        public TRequestBody RequestBodyContent
        {
            get { return RequestBody.RequestBody; }
            set { RequestBody.RequestBody = value; }
        }
    }
}

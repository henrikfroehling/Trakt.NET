namespace TraktApiSharp.Experimental.Requests.Base.Put
{
    using Interfaces;
    using Interfaces.Base;
    using TraktApiSharp.Requests;

    internal abstract class ATraktSingleItemPutByIdRequest<TItem, TRequestBody> : ATraktSingleItemPutRequest<TItem, TRequestBody>, ITraktHasId, ITraktObjectRequest
    {
        internal ATraktSingleItemPutByIdRequest(TraktClient client) : base(client)
        {
            RequestId = new TraktRequestId();
        }

        public string Id
        {
            get { return RequestId.Id; }
            set { RequestId.Id = value; }
        }

        public TraktRequestId RequestId { get; set; }

        public abstract TraktRequestObjectType RequestObjectType { get; }
    }
}

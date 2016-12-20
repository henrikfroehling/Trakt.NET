namespace TraktApiSharp.Experimental.Requests.Base.Put
{
    using Interfaces;
    using TraktApiSharp.Requests;

    internal abstract class ATraktListPutByIdRequest<TItem, TRequestBody> : ATraktListPutRequest<TItem, TRequestBody>, ITraktHasId, ITraktObjectRequest
    {
        internal ATraktListPutByIdRequest(TraktClient client) : base(client)
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

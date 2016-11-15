namespace TraktApiSharp.Experimental.Requests.Base.Put
{
    internal abstract class ATraktPaginationPutByIdRequest<TItem, TRequestBody> : ATraktPaginationPutRequest<TItem, TRequestBody>, ITraktHasId
    {
        internal ATraktPaginationPutByIdRequest(TraktClient client) : base(client)
        {
            RequestId = new TraktRequestId();
        }

        public string Id
        {
            get { return RequestId.Id; }
            set { RequestId.Id = value; }
        }

        public TraktRequestId RequestId { get; set; }
    }
}

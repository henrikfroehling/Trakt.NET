namespace TraktApiSharp.Experimental.Requests.Base.Put
{
    internal abstract class ATraktListPutByIdRequest<TItem, TRequestBody> : ATraktListPutRequest<TItem, TRequestBody>, ITraktHasId
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
    }
}

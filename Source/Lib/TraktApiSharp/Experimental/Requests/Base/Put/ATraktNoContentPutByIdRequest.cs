namespace TraktApiSharp.Experimental.Requests.Base.Put
{
    internal abstract class ATraktNoContentPutByIdRequest<TRequestBody> : ATraktNoContentPutRequest<TRequestBody>, ITraktHasId
    {
        internal ATraktNoContentPutByIdRequest(TraktClient client) : base(client)
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

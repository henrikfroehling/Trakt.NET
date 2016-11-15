namespace TraktApiSharp.Experimental.Requests.Base.Post
{
    internal abstract class ATraktSingleItemPostByIdRequest<TItem, TRequestBody> : ATraktSingleItemPostRequest<TItem, TRequestBody>, ITraktHasId
    {
        internal ATraktSingleItemPostByIdRequest(TraktClient client) : base(client)
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

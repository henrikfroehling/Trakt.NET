namespace TraktApiSharp.Experimental.Requests.Base.Post
{
    internal abstract class ATraktPaginationPostByIdRequest<TItem, TRequestBody> : ATraktPaginationPostRequest<TItem, TRequestBody>, ITraktHasId
    {
        internal ATraktPaginationPostByIdRequest(TraktClient client) : base(client)
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

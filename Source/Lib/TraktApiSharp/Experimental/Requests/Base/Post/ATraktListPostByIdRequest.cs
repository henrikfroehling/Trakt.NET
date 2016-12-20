namespace TraktApiSharp.Experimental.Requests.Base.Post
{
    using Interfaces;

    internal abstract class ATraktListPostByIdRequest<TItem, TRequestBody> : ATraktListPostRequest<TItem, TRequestBody>, ITraktHasId
    {
        internal ATraktListPostByIdRequest(TraktClient client) : base(client)
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

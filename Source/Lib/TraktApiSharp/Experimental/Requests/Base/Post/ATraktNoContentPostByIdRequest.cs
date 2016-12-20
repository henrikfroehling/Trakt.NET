namespace TraktApiSharp.Experimental.Requests.Base.Post
{
    using Interfaces;

    internal abstract class ATraktNoContentPostByIdRequest<TRequestBody> : ATraktNoContentPostRequest<TRequestBody>, ITraktHasId
    {
        internal ATraktNoContentPostByIdRequest(TraktClient client) : base(client)
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

namespace TraktApiSharp.Experimental.Requests.Base.Post.Bodyless
{
    using Interfaces;

    internal abstract class ATraktNoContentBodylessPostByIdRequest : ATraktNoContentBodylessPostRequest, ITraktHasId
    {
        internal ATraktNoContentBodylessPostByIdRequest(TraktClient client) : base(client)
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

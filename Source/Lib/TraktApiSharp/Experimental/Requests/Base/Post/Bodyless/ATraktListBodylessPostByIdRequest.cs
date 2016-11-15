namespace TraktApiSharp.Experimental.Requests.Base.Post.Bodyless
{
    internal abstract class ATraktListBodylessPostByIdRequest<TItem> : ATraktListBodylessPostRequest<TItem>, ITraktHasId
    {
        internal ATraktListBodylessPostByIdRequest(TraktClient client) : base(client)
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

namespace TraktApiSharp.Experimental.Requests.Base.Get
{
    internal abstract class ATraktListGetByIdRequest<TItem> : ATraktListGetRequest<TItem>, ITraktHasId
    {
        internal ATraktListGetByIdRequest(TraktClient client) : base(client)
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

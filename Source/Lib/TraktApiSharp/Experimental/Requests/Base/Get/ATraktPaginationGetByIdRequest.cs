namespace TraktApiSharp.Experimental.Requests.Base.Get
{
    using Interfaces;
    using Interfaces.Base;
    using TraktApiSharp.Requests;

    internal abstract class ATraktPaginationGetByIdRequest<TItem> : ATraktPaginationGetRequest<TItem>, ITraktHasId, ITraktObjectRequest
    {
        internal ATraktPaginationGetByIdRequest(TraktClient client) : base(client)
        {
            RequestId = new TraktRequestId();
        }

        public string Id
        {
            get { return RequestId.Id; }
            set { RequestId.Id = value; }
        }

        public TraktRequestId RequestId { get; set; }

        public abstract TraktRequestObjectType RequestObjectType { get; }
    }
}

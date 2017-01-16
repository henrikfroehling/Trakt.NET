namespace TraktApiSharp.Experimental.Requests.Base.Delete
{
    using Interfaces.Base;
    using TraktApiSharp.Requests;

    internal abstract class ATraktNoContentDeleteByIdRequest : ATraktNoContentDeleteRequest, ITraktHasId
    {
        internal ATraktNoContentDeleteByIdRequest(TraktClient client) : base(client)
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

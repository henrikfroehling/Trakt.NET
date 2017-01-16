namespace TraktApiSharp.Experimental.Requests.Base.Put
{
    using Interfaces.Base;
    using TraktApiSharp.Requests;

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

        public abstract TraktRequestObjectType RequestObjectType { get; }
    }
}

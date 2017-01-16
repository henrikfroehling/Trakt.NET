namespace TraktApiSharp.Experimental.Requests.Base.Put
{
    using Interfaces.Base;
    using System;
    using TraktApiSharp.Requests;

    internal abstract class ATraktPaginationPutByIdRequest<TItem, TRequestBody> : ATraktPaginationPutRequest<TItem, TRequestBody>, ITraktHasId
    {
        internal ATraktPaginationPutByIdRequest(TraktClient client) : base(client)
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

        public virtual void Validate()
        {
            throw new NotImplementedException();
        }
    }
}

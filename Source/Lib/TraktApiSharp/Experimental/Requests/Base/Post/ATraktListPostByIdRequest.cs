namespace TraktApiSharp.Experimental.Requests.Base.Post
{
    using Interfaces.Base;
    using System;
    using TraktApiSharp.Requests;

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

        public abstract TraktRequestObjectType RequestObjectType { get; }

        public virtual void Validate()
        {
            throw new NotImplementedException();
        }
    }
}

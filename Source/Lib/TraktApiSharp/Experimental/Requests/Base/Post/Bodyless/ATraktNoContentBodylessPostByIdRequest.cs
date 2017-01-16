namespace TraktApiSharp.Experimental.Requests.Base.Post.Bodyless
{
    using Interfaces.Base;
    using System;
    using TraktApiSharp.Requests;

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

        public abstract TraktRequestObjectType RequestObjectType { get; }

        public void Validate()
        {
            throw new NotImplementedException();
        }
    }
}

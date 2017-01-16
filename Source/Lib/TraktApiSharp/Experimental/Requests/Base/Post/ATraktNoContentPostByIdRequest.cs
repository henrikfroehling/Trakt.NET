namespace TraktApiSharp.Experimental.Requests.Base.Post
{
    using Interfaces.Base;
    using System;
    using TraktApiSharp.Requests;

    internal abstract class ATraktNoContentPostByIdRequest<TRequestBody> : ATraktNoContentPostRequest<TRequestBody>, ITraktHasId
    {
        internal ATraktNoContentPostByIdRequest(TraktClient client) : base(client) { }

        public string Id { get; set; }

        public abstract TraktRequestObjectType RequestObjectType { get; }

        public virtual void Validate()
        {
            throw new NotImplementedException();
        }
    }
}

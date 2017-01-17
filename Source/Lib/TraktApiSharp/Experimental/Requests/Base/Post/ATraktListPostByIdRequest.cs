namespace TraktApiSharp.Experimental.Requests.Base.Post
{
    using Interfaces.Base.Post;
    using System;
    using TraktApiSharp.Requests;

    internal abstract class ATraktListPostByIdRequest<TItem, TRequestBody> : ATraktListPostRequest<TItem, TRequestBody>, ITraktListPostByIdRequest<TItem, TRequestBody>
    {
        internal ATraktListPostByIdRequest(TraktClient client) : base(client) { }

        public string Id { get; set; }

        public abstract TraktRequestObjectType RequestObjectType { get; }

        public virtual void Validate()
        {
            throw new NotImplementedException();
        }
    }
}

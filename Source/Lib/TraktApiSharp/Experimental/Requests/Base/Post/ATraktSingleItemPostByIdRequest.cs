namespace TraktApiSharp.Experimental.Requests.Base.Post
{
    using Interfaces.Base.Post;
    using System;
    using TraktApiSharp.Requests;

    internal abstract class ATraktSingleItemPostByIdRequest<TItem, TRequestBody> : ATraktSingleItemPostRequest<TItem, TRequestBody>, ITraktSingleItemPostByIdRequest<TItem, TRequestBody>
    {
        internal ATraktSingleItemPostByIdRequest(TraktClient client) : base(client) { }

        public string Id { get; set; }

        public abstract TraktRequestObjectType RequestObjectType { get; }

        public virtual void Validate()
        {
            throw new NotImplementedException();
        }
    }
}

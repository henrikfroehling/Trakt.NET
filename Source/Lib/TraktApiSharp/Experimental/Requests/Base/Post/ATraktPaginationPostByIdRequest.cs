namespace TraktApiSharp.Experimental.Requests.Base.Post
{
    using Interfaces.Base.Post;
    using System;
    using TraktApiSharp.Requests;

    internal abstract class ATraktPaginationPostByIdRequest<TItem, TRequestBody> : ATraktPaginationPostRequest<TItem, TRequestBody>, ITraktPaginationPostByIdRequest<TItem, TRequestBody>
    {
        internal ATraktPaginationPostByIdRequest(TraktClient client) : base(client) { }

        public string Id { get; set; }

        public abstract TraktRequestObjectType RequestObjectType { get; }

        public virtual void Validate()
        {
            throw new NotImplementedException();
        }
    }
}

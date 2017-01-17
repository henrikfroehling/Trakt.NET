namespace TraktApiSharp.Experimental.Requests.Base.Put
{
    using Interfaces.Base.Put;
    using System;
    using TraktApiSharp.Requests;

    internal abstract class ATraktPaginationPutByIdRequest<TItem, TRequestBody> : ATraktPaginationPutRequest<TItem, TRequestBody>, ITraktPaginationPutByIdRequest<TItem, TRequestBody>
    {
        internal ATraktPaginationPutByIdRequest(TraktClient client) : base(client) { }

        public string Id { get; set; }

        public abstract TraktRequestObjectType RequestObjectType { get; }

        public virtual void Validate()
        {
            throw new NotImplementedException();
        }
    }
}

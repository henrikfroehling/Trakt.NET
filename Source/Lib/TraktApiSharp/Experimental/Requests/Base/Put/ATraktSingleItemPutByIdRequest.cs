namespace TraktApiSharp.Experimental.Requests.Base.Put
{
    using Interfaces.Base.Put;
    using System;
    using TraktApiSharp.Requests;

    internal abstract class ATraktSingleItemPutByIdRequest<TItem, TRequestBody> : ATraktSingleItemPutRequest<TItem, TRequestBody>, ITraktSingleItemPutByIdRequest<TItem, TRequestBody>
    {
        internal ATraktSingleItemPutByIdRequest(TraktClient client) : base(client) { }

        public string Id { get; set; }

        public abstract TraktRequestObjectType RequestObjectType { get; }

        public virtual void Validate()
        {
            throw new NotImplementedException();
        }
    }
}

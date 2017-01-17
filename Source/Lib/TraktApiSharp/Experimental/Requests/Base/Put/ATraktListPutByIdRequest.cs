namespace TraktApiSharp.Experimental.Requests.Base.Put
{
    using Interfaces.Base.Put;
    using System;
    using TraktApiSharp.Requests;

    internal abstract class ATraktListPutByIdRequest<TItem, TRequestBody> : ATraktListPutRequest<TItem, TRequestBody>, ITraktListPutByIdRequest<TItem, TRequestBody>
    {
        internal ATraktListPutByIdRequest(TraktClient client) : base(client) { }

        public string Id { get; set; }

        public abstract TraktRequestObjectType RequestObjectType { get; }

        public virtual void Validate()
        {
            throw new NotImplementedException();
        }
    }
}

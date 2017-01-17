namespace TraktApiSharp.Experimental.Requests.Base.Get
{
    using Interfaces.Base.Get;
    using System;
    using TraktApiSharp.Requests;

    internal abstract class ATraktSingleItemGetByIdRequest<TItem> : ATraktSingleItemGetRequest<TItem>, ITraktSingleItemGetByIdRequest<TItem>
    {
        internal ATraktSingleItemGetByIdRequest(TraktClient client) : base(client) { }

        public string Id { get; set; }

        public abstract TraktRequestObjectType RequestObjectType { get; }

        public virtual void Validate()
        {
            throw new NotImplementedException();
        }
    }
}

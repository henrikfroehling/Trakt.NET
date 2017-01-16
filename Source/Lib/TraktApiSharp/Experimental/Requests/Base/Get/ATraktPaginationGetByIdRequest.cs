namespace TraktApiSharp.Experimental.Requests.Base.Get
{
    using Interfaces.Base;
    using System;
    using TraktApiSharp.Requests;

    internal abstract class ATraktPaginationGetByIdRequest<TItem> : ATraktPaginationGetRequest<TItem>, ITraktHasId
    {
        internal ATraktPaginationGetByIdRequest(TraktClient client) : base(client) { }

        public string Id { get; set; }

        public abstract TraktRequestObjectType RequestObjectType { get; }

        public virtual void Validate()
        {
            throw new NotImplementedException();
        }
    }
}

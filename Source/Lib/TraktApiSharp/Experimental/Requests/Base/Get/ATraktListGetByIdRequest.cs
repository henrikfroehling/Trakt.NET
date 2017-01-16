namespace TraktApiSharp.Experimental.Requests.Base.Get
{
    using Interfaces.Base.Get;
    using System;
    using TraktApiSharp.Requests;

    internal abstract class ATraktListGetByIdRequest<TItem> : ATraktListGetRequest<TItem>, ITraktListGetByIdRequest<TItem>
    {
        internal ATraktListGetByIdRequest(TraktClient client) : base(client) { }

        public string Id { get; set; }

        public abstract TraktRequestObjectType RequestObjectType { get; }

        public virtual void Validate()
        {
            throw new NotImplementedException();
        }
    }
}

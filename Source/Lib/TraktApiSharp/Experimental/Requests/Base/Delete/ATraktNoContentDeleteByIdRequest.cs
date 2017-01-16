namespace TraktApiSharp.Experimental.Requests.Base.Delete
{
    using Interfaces.Base.Delete;
    using System;
    using TraktApiSharp.Requests;

    internal abstract class ATraktNoContentDeleteByIdRequest : ATraktNoContentDeleteRequest, ITraktNoContentDeleteByIdRequest
    {
        internal ATraktNoContentDeleteByIdRequest(TraktClient client) : base(client) {}

        public string Id {get; set; }

        public abstract TraktRequestObjectType RequestObjectType { get; }

        public virtual void Validate()
        {
            throw new NotImplementedException();
        }
    }
}

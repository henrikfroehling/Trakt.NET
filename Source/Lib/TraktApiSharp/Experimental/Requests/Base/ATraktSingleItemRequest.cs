namespace TraktApiSharp.Experimental.Requests.Base
{
    using Interfaces.Base;
    using Responses.Interfaces.Base;
    using System;
    using System.Threading.Tasks;

    internal abstract class ATraktSingleItemRequest<TItem> : ATraktBaseRequest, ITraktSingleItemRequest<TItem>
    {
        internal ATraktSingleItemRequest(TraktClient client) : base(client) { }

        public Task<ITraktResponse<TItem>> QueryAsync()
        {
            throw new NotImplementedException();
        }
    }
}

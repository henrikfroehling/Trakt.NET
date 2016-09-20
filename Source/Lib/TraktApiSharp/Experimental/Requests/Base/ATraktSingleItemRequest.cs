namespace TraktApiSharp.Experimental.Requests.Base
{
    using Interfaces;
    using Responses;
    using System;
    using System.Threading.Tasks;

    internal abstract class ATraktSingleItemRequest<TItem> : ATraktBaseRequest, ITraktSingleItemRequest<TItem>
    {
        internal ATraktSingleItemRequest(TraktClient client) : base(client) { }

        public Task<TraktResponse<TItem>> QueryAsync()
        {
            throw new NotImplementedException();
        }
    }
}

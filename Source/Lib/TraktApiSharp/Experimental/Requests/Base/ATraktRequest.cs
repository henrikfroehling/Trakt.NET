namespace TraktApiSharp.Experimental.Requests.Base
{
    using Interfaces;
    using Responses;
    using System;
    using System.Threading.Tasks;

    internal abstract class ATraktRequest<TItem, TRequestBody> : ATraktBaseRequest<TRequestBody>, ITraktQueryable<TItem>
    {
        public ATraktRequest(TraktClient client) : base(client) { }

        public Task<TraktResponse<TItem>> QueryAsync()
        {
            throw new NotImplementedException();
        }
    }
}

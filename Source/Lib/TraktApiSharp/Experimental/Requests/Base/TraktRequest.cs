namespace TraktApiSharp.Experimental.Requests.Base
{
    using Interfaces;
    using Responses;
    using System;
    using System.Threading.Tasks;

    internal class TraktRequest<TItem> : ITraktQueryable<TItem>
    {
        public Task<TraktResponse<TItem>> QueryAsync()
        {
            throw new NotImplementedException();
        }
    }
}

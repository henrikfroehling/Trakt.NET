namespace TraktApiSharp.Experimental.Requests.Base
{
    using Responses;
    using System;
    using System.Threading.Tasks;

    internal class TraktPaginationRequest<TItem> : ITraktPaginationQueryable<TItem>
    {
        public Task<TraktPaginationResponse<TItem>> QueryAsync()
        {
            throw new NotImplementedException();
        }
    }
}

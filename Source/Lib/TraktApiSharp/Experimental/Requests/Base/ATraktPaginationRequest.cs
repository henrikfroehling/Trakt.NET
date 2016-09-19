namespace TraktApiSharp.Experimental.Requests.Base
{
    using Interfaces;
    using Responses;
    using System;
    using System.Threading.Tasks;

    internal abstract class ATraktPaginationRequest<TItem, TRequestBody> : ATraktBaseRequest<TRequestBody>, ITraktPaginationQueryable<TItem>
    {
        public Task<TraktPaginationResponse<TItem>> QueryAsync()
        {
            throw new NotImplementedException();
        }
    }
}

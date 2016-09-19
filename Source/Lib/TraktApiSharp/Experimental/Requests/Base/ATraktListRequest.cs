namespace TraktApiSharp.Experimental.Requests.Base
{
    using Interfaces;
    using Responses;
    using System;
    using System.Threading.Tasks;

    internal abstract class ATraktListRequest<TItem, TRequestBody> : ATraktBaseRequest<TRequestBody>, ITraktListQueryable<TItem>
    {
        public Task<TraktListResponse<TItem>> QueryAsync()
        {
            throw new NotImplementedException();
        }
    }
}

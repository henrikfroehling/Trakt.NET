namespace TraktApiSharp.Experimental.Requests.Base
{
    using Responses;
    using System;
    using System.Threading.Tasks;

    internal class TraktListRequest<TItem> : ITraktListQueryable<TItem>
    {
        public Task<TraktListResponse<TItem>> QueryAsync()
        {
            throw new NotImplementedException();
        }
    }
}

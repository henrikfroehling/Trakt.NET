namespace TraktApiSharp.Experimental.Requests.Base
{
    using Interfaces;
    using Responses;
    using System;
    using System.Threading.Tasks;

    internal abstract class ATraktListRequest<TItem> : ATraktBaseRequest, ITraktListRequest<TItem>
    {
        internal ATraktListRequest(TraktClient client) : base(client) { }

        public Task<TraktListResponse<TItem>> QueryAsync()
        {
            throw new NotImplementedException();
        }
    }
}

namespace TraktApiSharp.Experimental.Requests.Base
{
    using Interfaces.Base;
    using Responses.Interfaces.Base;
    using System;
    using System.Threading.Tasks;

    internal abstract class ATraktListRequest<TItem> : ATraktBaseRequest, ITraktListRequest<TItem>
    {
        internal ATraktListRequest(TraktClient client) : base(client) { }

        public Task<ITraktListResponse<TItem>> QueryAsync()
        {
            throw new NotImplementedException();
        }
    }
}

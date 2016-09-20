namespace TraktApiSharp.Experimental.Requests.Base
{
    using Interfaces;
    using Responses;
    using System;
    using System.Threading.Tasks;
    using TraktApiSharp.Requests;

    internal abstract class ATraktPaginationRequest<TItem> : ATraktBaseRequest, ITraktPaginationRequest<TItem>
    {
        internal ATraktPaginationRequest(TraktClient client) : base(client) { }

        public TraktPaginationOptions PaginationOptions { get; set; }

        public virtual bool SupportsOnlyPaginationParameters => false;

        public Task<TraktPaginationResponse<TItem>> QueryAsync()
        {
            throw new NotImplementedException();
        }
    }
}

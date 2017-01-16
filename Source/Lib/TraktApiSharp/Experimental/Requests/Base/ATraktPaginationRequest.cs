namespace TraktApiSharp.Experimental.Requests.Base
{
    using Interfaces.Base;
    using Responses;
    using System;
    using System.Threading.Tasks;

    internal abstract class ATraktPaginationRequest<TItem> : ATraktBaseRequest, ITraktPaginationRequest<TItem>
    {
        internal ATraktPaginationRequest(TraktClient client) : base(client) { }

        public int? Page { get; set; }

        public int? Limit { get; set; }

        public Task<TraktPaginationResponse<TItem>> QueryAsync()
        {
            throw new NotImplementedException();
        }
    }
}

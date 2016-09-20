namespace TraktApiSharp.Experimental.Requests.Base.Get
{
    using System.Net.Http;

    internal abstract class ATraktPaginationGetRequest<TItem> : ATraktPaginationRequest<TItem, object>
    {
        public ATraktPaginationGetRequest(TraktClient client) : base(client) { }

        protected override HttpMethod Method => HttpMethod.Get;
    }
}

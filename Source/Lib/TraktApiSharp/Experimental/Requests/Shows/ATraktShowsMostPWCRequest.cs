namespace TraktApiSharp.Experimental.Requests.Shows
{
    internal abstract class ATraktShowsMostPWCRequest<TItem> : ATraktShowsRequest<TItem>
    {
        public ATraktShowsMostPWCRequest(TraktClient client) : base(client) { }
    }
}

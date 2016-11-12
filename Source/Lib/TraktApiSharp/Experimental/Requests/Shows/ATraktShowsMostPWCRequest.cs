namespace TraktApiSharp.Experimental.Requests.Shows
{
    using Enums;

    internal abstract class ATraktShowsMostPWCRequest<TItem> : ATraktShowsRequest<TItem>
    {
        public ATraktShowsMostPWCRequest(TraktClient client) : base(client) { }

        internal TraktTimePeriod Period { get; set; }
    }
}

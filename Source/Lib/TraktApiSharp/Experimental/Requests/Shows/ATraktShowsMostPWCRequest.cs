namespace TraktApiSharp.Experimental.Requests.Shows
{
    using Enums;
    using System.Collections.Generic;

    internal abstract class ATraktShowsMostPWCRequest<TItem> : ATraktShowsRequest<TItem>
    {
        public ATraktShowsMostPWCRequest(TraktClient client) : base(client) { }

        internal TraktTimePeriod Period { get; set; }

        public override IDictionary<string, object> GetUriPathParameters()
        {
            return base.GetUriPathParameters();
        }
    }
}

namespace TraktApiSharp.Experimental.Requests.Shows
{
    using Enums;
    using System.Collections.Generic;

    internal abstract class ATraktShowsMostPWCRequest<TItem> : ATraktShowsRequest<TItem>
    {
        internal ATraktShowsMostPWCRequest(TraktClient client) : base(client) { }

        internal TraktTimePeriod Period { get; set; }

        public override IDictionary<string, object> GetUriPathParameters()
        {
            var uriParams = base.GetUriPathParameters();

            if (Period != null && Period != TraktTimePeriod.Unspecified)
                uriParams.Add("period", Period.UriName);

            return uriParams;
        }
    }
}

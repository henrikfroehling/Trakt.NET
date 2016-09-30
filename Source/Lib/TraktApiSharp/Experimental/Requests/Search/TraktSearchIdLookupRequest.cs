namespace TraktApiSharp.Experimental.Requests.Search
{
    using System;

    internal sealed class TraktSearchIdLookupRequest : ATraktSearchRequest
    {
        public TraktSearchIdLookupRequest(TraktClient client) : base(client) { }

        public override string UriTemplate
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }
}

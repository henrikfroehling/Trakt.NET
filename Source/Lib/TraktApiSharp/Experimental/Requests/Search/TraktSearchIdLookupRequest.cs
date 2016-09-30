namespace TraktApiSharp.Experimental.Requests.Search
{
    using System;
    using TraktApiSharp.Requests;

    internal sealed class TraktSearchIdLookupRequest : ATraktSearchRequest
    {
        public TraktSearchIdLookupRequest(TraktClient client) : base(client) { }

        public override TraktAuthorizationRequirement AuthorizationRequirement
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override string UriTemplate
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }
}

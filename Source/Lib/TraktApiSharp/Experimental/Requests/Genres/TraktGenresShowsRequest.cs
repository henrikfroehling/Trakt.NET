namespace TraktApiSharp.Experimental.Requests.Genres
{
    using System;
    using TraktApiSharp.Requests;

    internal sealed class TraktGenresShowsRequest : ATraktGenresRequest
    {
        public TraktGenresShowsRequest(TraktClient client) : base(client) { }

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

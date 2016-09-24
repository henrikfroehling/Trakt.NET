namespace TraktApiSharp.Experimental.Requests.Genres
{
    using System;

    internal sealed class TraktGenresShowsRequest : ATraktGenresRequest
    {
        public TraktGenresShowsRequest(TraktClient client) : base(client) { }

        public override string UriTemplate
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }
}

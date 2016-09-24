namespace TraktApiSharp.Experimental.Requests.Genres
{
    using System;
    using TraktApiSharp.Requests;

    internal sealed class TraktGenresMoviesRequest : ATraktGenresRequest
    {
        public TraktGenresMoviesRequest(TraktClient client) : base(client) { }

        public override TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.NotRequired;

        public override string UriTemplate
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }
}

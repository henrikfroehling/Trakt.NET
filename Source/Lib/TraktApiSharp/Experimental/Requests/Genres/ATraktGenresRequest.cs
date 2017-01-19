namespace TraktApiSharp.Experimental.Requests.Genres
{
    using TraktApiSharp.Requests;

    internal abstract class ATraktGenresRequest
    {
        internal ATraktGenresRequest(TraktClient client) { }

        public TraktAuthorizationRequirement AuthorizationRequirement => TraktAuthorizationRequirement.NotRequired;
    }
}

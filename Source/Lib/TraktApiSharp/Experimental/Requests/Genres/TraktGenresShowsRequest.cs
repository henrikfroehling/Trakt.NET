namespace TraktApiSharp.Experimental.Requests.Genres
{
    internal sealed class TraktGenresShowsRequest : ATraktGenresRequest
    {
        internal TraktGenresShowsRequest(TraktClient client) : base(client) { }

        public override string UriTemplate => "genres/shows";
    }
}

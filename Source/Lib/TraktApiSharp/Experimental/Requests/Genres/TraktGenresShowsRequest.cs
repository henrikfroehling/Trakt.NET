namespace TraktApiSharp.Experimental.Requests.Genres
{
    internal sealed class TraktGenresShowsRequest : ATraktGenresRequest
    {
        internal TraktGenresShowsRequest(TraktClient client) : base(client) { }

        public string UriTemplate => "genres/shows";
    }
}

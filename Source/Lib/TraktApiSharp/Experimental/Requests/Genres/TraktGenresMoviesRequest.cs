namespace TraktApiSharp.Experimental.Requests.Genres
{
    internal sealed class TraktGenresMoviesRequest : ATraktGenresRequest
    {
        internal TraktGenresMoviesRequest(TraktClient client) : base(client) { }

        public string UriTemplate => "genres/movies";
    }
}

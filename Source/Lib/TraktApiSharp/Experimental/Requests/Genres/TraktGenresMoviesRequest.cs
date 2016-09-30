namespace TraktApiSharp.Experimental.Requests.Genres
{
    internal sealed class TraktGenresMoviesRequest : ATraktGenresRequest
    {
        internal TraktGenresMoviesRequest(TraktClient client) : base(client) { }

        public override string UriTemplate => "genres/movies";
    }
}

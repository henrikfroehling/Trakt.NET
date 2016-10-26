namespace TraktApiSharp.Experimental.Requests.Movies
{
    internal abstract class ATraktMoviesMostPWCRequest<TItem> : ATraktMoviesRequest<TItem>
    {
        internal ATraktMoviesMostPWCRequest(TraktClient client) : base(client) { }
    }
}

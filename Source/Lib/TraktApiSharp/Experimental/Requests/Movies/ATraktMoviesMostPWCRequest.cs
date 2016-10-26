namespace TraktApiSharp.Experimental.Requests.Movies
{
    using Enums;

    internal abstract class ATraktMoviesMostPWCRequest<TItem> : ATraktMoviesRequest<TItem>
    {
        internal ATraktMoviesMostPWCRequest(TraktClient client) : base(client) { }

        internal TraktTimePeriod Period { get; set; }
    }
}

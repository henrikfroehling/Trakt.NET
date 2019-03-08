namespace TraktNet.Requests.Parameters.Filter.Builder
{
    public sealed class TraktMovieFilterBuilder : TraktShowAndMovieFilterBuilder<TraktMovieFilterBuilder, TraktMovieFilter>
    {
        public TraktMovieFilterBuilder() : base(new TraktMovieFilter())
        {
        }
    }
}

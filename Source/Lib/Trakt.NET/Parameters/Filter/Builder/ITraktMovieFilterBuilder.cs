namespace TraktNet.Parameters
{
    public interface ITraktMovieFilterBuilder
        : ITraktShowAndMovieFilterBuilder<ITraktMovieFilter, ITraktMovieFilterBuilder>,
          ITraktMovieRatingsFilterBuilder
    {
    }
}

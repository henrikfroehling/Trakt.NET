namespace TraktNet.Parameters
{
    /// <summary>
    /// Filter builder for <see cref="ITraktMovieFilter" />s.
    /// <para>Provides methods for adding values to a <see cref="ITraktMovieFilter"/>.</para>
    /// </summary>
    public interface ITraktMovieFilterBuilder
        : ITraktShowAndMovieFilterBuilder<ITraktMovieFilter, ITraktMovieFilterBuilder>,
          ITraktMovieRatingsFilterBuilder
    {
    }
}

namespace TraktNet.Parameters
{
    /// <summary>
    /// Filter builder for <see cref="ITraktSearchFilter" />s.
    /// <para>Provides methods for adding values to a <see cref="ITraktSearchFilter"/>.</para>
    /// </summary>
    public interface ITraktSearchFilterBuilder : ITraktShowAndMovieFilterBuilder<ITraktSearchFilter, ITraktSearchFilterBuilder>, ITraktSearchRatingsFilterBuilder
    {
    }
}

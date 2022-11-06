namespace TraktNet.Parameters
{
    /// <summary>
    /// Filter builder for <see cref="ITraktCalendarFilter" />s.
    /// <para>Provides methods for adding values to a <see cref="ITraktCalendarFilter"/>.</para>
    /// </summary>
    public interface ITraktCalendarFilterBuilder
        : ITraktFilterBuilder<ITraktCalendarFilter, ITraktCalendarFilterBuilder>,
          ITraktCalendarRatingsFilterBuilder
    {
    }
}

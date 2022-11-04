namespace TraktNet.Parameters
{
    public interface ITraktCalendarFilterBuilder
        : ITraktFilterBuilder<ITraktCalendarFilter, ITraktCalendarFilterBuilder>,
          ITraktCalendarRatingsFilterBuilder
    {
    }
}

namespace TraktNet.Parameters
{
    internal sealed class CalendarRatingsFilterBuilder
        : ABasicRatingsFilterBuilder<ITraktCalendarFilter, ITraktCalendarFilterBuilder>, ITraktCalendarRatingsFilterBuilder
    {
        internal CalendarRatingsFilterBuilder(ITraktCalendarFilterBuilder filterBuilder) : base(filterBuilder)
        {
        }
    }
}

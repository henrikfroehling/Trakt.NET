namespace TraktNet.Parameters
{
    public static class TraktFilter
    {
        public static ITraktCalendarFilterBuilder NewCalendarFilter() => new CalendarFilterBuilder();

        public static ITraktMovieFilterBuilder NewMovieFilter() => new MovieFilterBuilder();

        public static ITraktShowFilterBuilder NewShowFilter() => new ShowFilterBuilder();

        public static ITraktSearchFilterBuilder NewSearchFilter() => new SearchFilterBuilder();
    }
}

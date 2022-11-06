namespace TraktNet.Parameters
{
    public static class TraktFilter
    {
        /// <summary>Creates a new <see cref="ITraktCalendarFilterBuilder"/>.</summary>
        /// <returns>An <see cref="ITraktCalendarFilterBuilder"/> instance.</returns>
        public static ITraktCalendarFilterBuilder NewCalendarFilter() => new CalendarFilterBuilder();

        /// <summary>Creates a new <see cref="ITraktMovieFilterBuilder"/>.</summary>
        /// <returns>An <see cref="ITraktMovieFilterBuilder"/> instance.</returns>
        public static ITraktMovieFilterBuilder NewMovieFilter() => new MovieFilterBuilder();

        /// <summary>Creates a new <see cref="ITraktShowFilterBuilder"/>.</summary>
        /// <returns>An <see cref="ITraktShowFilterBuilder"/> instance.</returns>
        public static ITraktShowFilterBuilder NewShowFilter() => new ShowFilterBuilder();

        /// <summary>Creates a new <see cref="ITraktSearchFilterBuilder"/>.</summary>
        /// <returns>An <see cref="ITraktSearchFilterBuilder"/> instance.</returns>
        public static ITraktSearchFilterBuilder NewSearchFilter() => new SearchFilterBuilder();
    }
}

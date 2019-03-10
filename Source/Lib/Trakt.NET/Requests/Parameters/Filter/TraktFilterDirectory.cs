namespace TraktNet.Requests.Parameters.Filter
{
    using Builder;

    public static class TraktFilterDirectory
    {
        public static TraktCalendarFilterBuilder CalendarFilter => new TraktCalendarFilterBuilder();

        public static TraktMovieFilterBuilder MovieFilter => new TraktMovieFilterBuilder();

        public static TraktShowFilterBuilder ShowFilter => new TraktShowFilterBuilder();

        public static TraktSearchFilterBuilder SearchFilter => new TraktSearchFilterBuilder();
    }
}

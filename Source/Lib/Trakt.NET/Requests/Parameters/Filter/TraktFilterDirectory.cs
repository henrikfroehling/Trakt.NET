namespace TraktNet.Requests.Parameters.Filter
{
    public static class TraktFilterDirectory
    {
        public static TraktCalendarFilter CalendarFilter => new TraktCalendarFilter();

        public static TraktMovieFilter MovieFilter => new TraktMovieFilter();

        public static TraktShowFilter ShowFilter => new TraktShowFilter();

        public static TraktSearchFilter SearchFilter => new TraktSearchFilter();
    }
}

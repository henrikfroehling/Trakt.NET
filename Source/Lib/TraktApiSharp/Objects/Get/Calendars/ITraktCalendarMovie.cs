namespace TraktNet.Objects.Get.Calendars
{
    using Movies;
    using System;

    public interface ITraktCalendarMovie : ITraktMovie
    {
        DateTime? CalendarRelease { get; set; }

        ITraktMovie Movie { get; set; }
    }
}

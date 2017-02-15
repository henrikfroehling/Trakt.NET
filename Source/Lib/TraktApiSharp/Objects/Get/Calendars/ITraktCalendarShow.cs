namespace TraktApiSharp.Objects.Get.Calendars
{
    using Episodes;
    using Shows;
    using System;

    public interface ITraktCalendarShow : ITraktShow, ITraktEpisode
    {
        DateTime? FirstAiredInCalendar { get; set; }

        ITraktShow Show { get; set; }

        ITraktEpisode Episode { get; set; }
    }
}

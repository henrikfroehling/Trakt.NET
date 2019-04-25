namespace TraktNet.Objects.Get.Calendars
{
    using Episodes;
    using Shows;
    using System;

    /// <summary>A Trakt calendar show, containing episode and show information.</summary>
    public interface ITraktCalendarShow : ITraktShow, ITraktCalendarEpisode
    {
        /// <summary>Gets or sets the UTC datetime, when the <see cref="Episode" /> first aired.</summary>
        DateTime? FirstAiredInCalendar { get; set; }

        /// <summary>Gets or sets the Trakt show. See also <seealso cref="ITraktShow" />.<para>Nullable</para></summary>
        ITraktShow Show { get; set; }

        /// <summary>Gets or sets the Trakt episode. See also <seealso cref="ITraktEpisode" />.<para>Nullable</para></summary>
        ITraktEpisode Episode { get; set; }
    }
}

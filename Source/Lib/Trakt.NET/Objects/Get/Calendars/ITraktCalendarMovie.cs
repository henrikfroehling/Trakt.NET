namespace TraktNet.Objects.Get.Calendars
{
    using Movies;
    using System;

    /// <summary>A Trakt calendar movie.</summary>
    public interface ITraktCalendarMovie : ITraktMovie
    {
        /// <summary>Gets or sets the release date of the <see cref="Movie" />.<para>Nullable</para></summary>
        DateTime? CalendarRelease { get; set; }

        /// <summary>Gets or sets the Trakt movie. See also <seealso cref="ITraktMovie" />.<para>Nullable</para></summary>
        ITraktMovie Movie { get; set; }
    }
}

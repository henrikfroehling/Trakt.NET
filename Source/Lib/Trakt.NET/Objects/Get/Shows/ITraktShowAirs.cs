namespace TraktNet.Objects.Get.Shows
{
    /// <summary>The air time of a Trakt show.</summary>
    public interface ITraktShowAirs
    {
        /// <summary>Gets or sets the day of week on which the show airs.<para>Nullable</para></summary>
        string Day { get; set; }

        /// <summary>Gets or sets the time of day at which the show airs.<para>Nullable</para></summary>
        string Time { get; set; }

        /// <summary>Gets or sets the time zone id (Olson) for the location in which the show airs.<para>Nullable</para></summary>
        string TimeZoneId { get; set; }
    }
}

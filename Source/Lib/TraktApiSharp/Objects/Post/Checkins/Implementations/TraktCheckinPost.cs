namespace TraktApiSharp.Objects.Post.Checkins.Implementations
{
    using Basic;

    public abstract class TraktCheckinPost : ITraktCheckinPost
    {
        /// <summary>
        /// Gets or sets the sharing options for the checkin post.
        /// See also <seealso cref="ITraktSharing" />.
        /// <para>Nullable</para>
        /// </summary>
        public ITraktSharing Sharing { get; set; }

        /// <summary>Gets or sets the message for the checkin post.<para>Nullable</para></summary>
        public string Message { get; set; }

        /// <summary>Gets or sets the app version for the checkin post.<para>Nullable</para></summary>
        public string AppVersion { get; set; }

        /// <summary>Gets or sets the app build date for the checkin post.<para>Nullable</para></summary>
        public string AppDate { get; set; }

        /// <summary>Gets or sets the Foursquare Venue Id for the checkin post.<para>Nullable</para></summary>
        public string FoursquareVenueId { get; set; }

        /// <summary>Gets or sets the Foursquare Venue Name for the checkin post.<para>Nullable</para></summary>
        public string FoursquareVenueName { get; set; }

        public abstract string ToJson();

        public abstract void Validate();
    }
}

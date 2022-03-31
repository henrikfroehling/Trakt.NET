namespace TraktNet.Objects.Post.Checkins
{
    using Objects.Basic;
    using Requests.Interfaces;

    public interface ITraktCheckinPost : IRequestBody
    {
        /// <summary>
        /// Gets or sets the sharing options for the checkin post.
        /// See also <seealso cref="ITraktSharing" />.
        /// <para>Nullable</para>
        /// </summary>
        ITraktSharing Sharing { get; set; }

        /// <summary>Gets or sets the message for the checkin post.<para>Nullable</para></summary>
        string Message { get; set; }

        /// <summary>Gets or sets the app version for the checkin post.<para>Nullable</para></summary>
        string AppVersion { get; set; }

        /// <summary>Gets or sets the app build date for the checkin post.<para>Nullable</para></summary>
        string AppDate { get; set; }

        /// <summary>Gets or sets the Foursquare Venue Id for the checkin post.<para>Nullable</para></summary>
        string FoursquareVenueId { get; set; }

        /// <summary>Gets or sets the Foursquare Venue Name for the checkin post.<para>Nullable</para></summary>
        string FoursquareVenueName { get; set; }
    }
}

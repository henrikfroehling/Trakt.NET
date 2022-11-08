namespace TraktNet.Objects.Post.Checkins
{
    using Objects.Basic;
    using System.Threading;
    using System.Threading.Tasks;

    public abstract class TraktCheckinPost : ITraktCheckinPost
    {
        /// <summary>
        /// Gets or sets the sharing options for the checkin post.
        /// See also <seealso cref="ITraktConnections" />.
        /// <para>Nullable</para>
        /// </summary>
        public ITraktConnections Sharing { get; set; }

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

        public abstract Task<string> ToJson(CancellationToken cancellationToken = default);

        public abstract void Validate();
    }
}

namespace TraktApiSharp.Objects.Post.Checkins
{
    using Attributes;
    using Basic;
    using Newtonsoft.Json;

    public abstract class TraktCheckinPost
    {
        /// <summary>
        /// Gets or sets the sharing options for the checkin post.
        /// See also <seealso cref="TraktSharing" />.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "sharing")]
        [Nullable]
        public TraktSharing Sharing { get; set; }

        /// <summary>Gets or sets the message for the checkin post.<para>Nullable</para></summary>
        [JsonProperty(PropertyName = "message")]
        [Nullable]
        public string Message { get; set; }

        /// <summary>Gets or sets the app version for the checkin post.<para>Nullable</para></summary>
        [JsonProperty(PropertyName = "app_version")]
        [Nullable]
        public string AppVersion { get; set; }

        /// <summary>Gets or sets the app build date for the checkin post.<para>Nullable</para></summary>
        [JsonProperty(PropertyName = "app_date")]
        [Nullable]
        public string AppDate { get; set; }

        /// <summary>Gets or sets the Foursquare Venue Id for the checkin post.<para>Nullable</para></summary>
        [JsonProperty(PropertyName = "venue_id")]
        [Nullable]
        public string FoursquareVenueId { get; set; }

        /// <summary>Gets or sets the Foursquare Venue Name for the checkin post.<para>Nullable</para></summary>
        [JsonProperty(PropertyName = "venue_name")]
        [Nullable]
        public string FoursquareVenueName { get; set; }
    }
}

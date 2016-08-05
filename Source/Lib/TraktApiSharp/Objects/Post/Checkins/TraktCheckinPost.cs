namespace TraktApiSharp.Objects.Post.Checkins
{
    using Attributes;
    using Basic;
    using Newtonsoft.Json;

    public abstract class TraktCheckinPost
    {
        [JsonProperty(PropertyName = "sharing")]
        [Nullable]
        public TraktSharing Sharing { get; set; }

        [JsonProperty(PropertyName = "message")]
        [Nullable]
        public string Message { get; set; }

        [JsonProperty(PropertyName = "app_version")]
        [Nullable]
        public string AppVersion { get; set; }

        [JsonProperty(PropertyName = "app_date")]
        [Nullable]
        public string AppDate { get; set; }

        [JsonProperty(PropertyName = "venue_id")]
        [Nullable]
        public string FoursquareVenueId { get; set; }

        [JsonProperty(PropertyName = "venue_name")]
        [Nullable]
        public string FoursquareVenueName { get; set; }
    }
}

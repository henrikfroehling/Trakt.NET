namespace TraktApiSharp.Objects.Post.Checkins
{
    using Basic;
    using Newtonsoft.Json;

    public abstract class TraktCheckinPost
    {
        [JsonProperty(PropertyName = "sharing")]
        public TraktSharing Sharing { get; set; }

        [JsonProperty(PropertyName = "message")]
        public string Message { get; set; }

        [JsonProperty(PropertyName = "app_version")]
        public string AppVersion { get; set; }

        [JsonProperty(PropertyName = "app_date")]
        public string AppDate { get; set; }

        [JsonProperty(PropertyName = "venue_id")]
        public string FoursquareVenueId { get; set; }

        [JsonProperty(PropertyName = "venue_name")]
        public string FoursquareVenueName { get; set; }
    }
}

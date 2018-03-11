namespace TraktApiSharp.Objects.Post.Checkins
{
    using Basic;

    public interface ITraktCheckinPost
    {
        ITraktSharing Sharing { get; set; }

        string Message { get; set; }

        string AppVersion { get; set; }

        string AppDate { get; set; }

        string FoursquareVenueId { get; set; }

        string FoursquareVenueName { get; set; }
    }
}

namespace TraktApiSharp.Objects.Post.Checkins
{
    using Basic;
    using Requests.Interfaces;

    public interface ITraktCheckinPost : IRequestBody
    {
        ITraktSharing Sharing { get; set; }

        string Message { get; set; }

        string AppVersion { get; set; }

        string AppDate { get; set; }

        string FoursquareVenueId { get; set; }

        string FoursquareVenueName { get; set; }
    }
}

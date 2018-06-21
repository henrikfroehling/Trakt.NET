namespace TraktNet.Objects.Post.Scrobbles.Responses
{
    using Basic;
    using Enums;

    public interface ITraktScrobblePostResponse
    {
        ulong Id { get; set; }

        TraktScrobbleActionType Action { get; set; }

        float? Progress { get; set; }

        ITraktSharing Sharing { get; set; }
    }
}

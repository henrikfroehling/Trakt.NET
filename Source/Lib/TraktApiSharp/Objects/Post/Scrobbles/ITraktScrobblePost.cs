namespace TraktApiSharp.Objects.Post.Scrobbles
{
    using Requests.Interfaces;

    public interface ITraktScrobblePost : IRequestBody
    {
        float Progress { get; set; }

        string AppVersion { get; set; }

        string AppDate { get; set; }
    }
}

namespace TraktApiSharp.Objects.Post.Scrobbles
{
    public interface ITraktScrobblePost
    {
        float Progress { get; set; }

        string AppVersion { get; set; }

        string AppDate { get; set; }
    }
}

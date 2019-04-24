namespace TraktNet.Objects.Post.Scrobbles
{
    using Requests.Interfaces;

    public interface ITraktScrobblePost : IRequestBody
    {
        /// <summary>Gets or sets the required progress. Should be a value between 0 and 100.</summary>
        float Progress { get; set; }

        /// <summary>Gets or sets the app version for the scrobble post.<para>Nullable</para></summary>
        string AppVersion { get; set; }

        /// <summary>Gets or sets the app build date for the scrobble post.<para>Nullable</para></summary>
        string AppDate { get; set; }
    }
}

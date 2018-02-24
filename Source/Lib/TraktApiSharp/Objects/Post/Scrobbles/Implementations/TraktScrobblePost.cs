namespace TraktApiSharp.Objects.Post.Scrobbles
{
    public abstract class TraktScrobblePost : ITraktScrobblePost
    {
        /// <summary>Gets or sets the required progress. Should be a value between 0 and 100.</summary>
        public float Progress { get; set; }

        /// <summary>Gets or sets the app version for the scrobble post.<para>Nullable</para></summary>
        public string AppVersion { get; set; }

        /// <summary>Gets or sets the app build date for the scrobble post.<para>Nullable</para></summary>
        public string AppDate { get; set; }
    }
}

namespace TraktNet.Objects.Post.Scrobbles
{
    using Exceptions;
    using System.Threading;
    using System.Threading.Tasks;

    public abstract class TraktScrobblePost : ITraktScrobblePost
    {
        /// <summary>Gets or sets the required progress. Should be a value between 0 and 100.</summary>
        public float Progress { get; set; }

        /// <summary>Gets or sets the app version for the scrobble post.<para>Nullable</para></summary>
        public string AppVersion { get; set; }

        /// <summary>Gets or sets the app build date for the scrobble post.<para>Nullable</para></summary>
        public string AppDate { get; set; }

        public abstract Task<string> ToJson(CancellationToken cancellationToken = default);

        public virtual void Validate()
        {
            if (Progress.CompareTo(0.0f) < 0 || Progress.CompareTo(100.0f) > 0)
                throw new TraktPostValidationException(nameof(Progress), "progress value not valid - value must be between 0 and 100");
        }
    }
}

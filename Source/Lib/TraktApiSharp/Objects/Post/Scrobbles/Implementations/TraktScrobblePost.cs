namespace TraktApiSharp.Objects.Post.Scrobbles.Implementations
{
    using System.Net.Http;
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

        public abstract HttpContent ToHttpContent();

        public abstract Task<string> ToJson(CancellationToken cancellationToken = default);

        public abstract void Validate();
    }
}

namespace TraktNet.Objects.Post.Shows
{
    using Objects.Json;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// A Trakt post for resetting the watched progress of a show, containing an optional reset_at UTC date to have it
    /// calculate progress from that specific date onwards.
    /// </summary>
    public class TraktShowResetWatchedProgressPost : ITraktShowResetWatchedProgressPost
    {
        /// <summary>An optional reset_at UTC date to have it calculate progress from that specific date onwards.</summary>
        public DateTime? ResetAt { get; set; }

        public Task<string> ToJson(CancellationToken cancellationToken = default)
        {
            IObjectJsonWriter<ITraktShowResetWatchedProgressPost> objectJsonWriter = JsonFactoryContainer.CreateObjectWriter<ITraktShowResetWatchedProgressPost>();
            return objectJsonWriter.WriteObjectAsync(this, cancellationToken);
        }

        public void Validate()
        {
            // implementation not needed
        }
    }
}

namespace TraktNet.Objects.Post.Scrobbles.Responses
{
    using Objects.Basic;
    using Enums;

    public abstract class TraktScrobblePostResponse : ITraktScrobblePostResponse
    {
        /// <summary>Gets or sets the history id for the scrobble response.</summary>
        public ulong Id { get; set; }

        /// <summary>
        /// Gets or sets the action type for the scrobble response.
        /// See also <seealso cref="TraktScrobbleActionType" />.
        /// <para>Nullable</para>
        /// </summary>
        public TraktScrobbleActionType Action { get; set; }

        /// <summary>Gets or sets the progress for the scrobble response.</summary>
        public float? Progress { get; set; }

        /// <summary>
        /// Gets or sets the sharing options for the scrobble response.
        /// See also <seealso cref="ITraktSharing" />.
        /// <para>Nullable</para>
        /// </summary>
        public ITraktSharing Sharing { get; set; }
    }
}

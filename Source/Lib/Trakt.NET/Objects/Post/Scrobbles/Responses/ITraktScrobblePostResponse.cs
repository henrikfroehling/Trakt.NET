namespace TraktNet.Objects.Post.Scrobbles.Responses
{
    using Objects.Basic;
    using Enums;

    public interface ITraktScrobblePostResponse
    {
        /// <summary>Gets or sets the history id for the scrobble response.</summary>
        ulong Id { get; set; }

        /// <summary>
        /// Gets or sets the action type for the scrobble response.
        /// See also <seealso cref="TraktScrobbleActionType" />.
        /// <para>Nullable</para>
        /// </summary>
        TraktScrobbleActionType Action { get; set; }

        /// <summary>Gets or sets the progress for the scrobble response.</summary>
        float? Progress { get; set; }

        /// <summary>
        /// Gets or sets the sharing options for the scrobble response.
        /// See also <seealso cref="ITraktConnections" />.
        /// <para>Nullable</para>
        /// </summary>
        ITraktConnections Sharing { get; set; }
    }
}

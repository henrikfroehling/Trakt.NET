namespace TraktApiSharp.Objects.Post.Scrobbles.Responses.Implementations
{
    using Basic;
    using Enums;
    using Newtonsoft.Json;

    public abstract class TraktScrobblePostResponse : ITraktScrobblePostResponse
    {
        /// <summary>Gets or sets the history id for the scrobble response.</summary>
        [JsonProperty(PropertyName = "id")]
        public ulong Id { get; set; }

        /// <summary>
        /// Gets or sets the action type for the scrobble response.
        /// See also <seealso cref="TraktScrobbleActionType" />.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "action")]
        [JsonConverter(typeof(TraktEnumerationConverter<TraktScrobbleActionType>))]
        public TraktScrobbleActionType Action { get; set; }

        /// <summary>Gets or sets the progress for the scrobble response.</summary>
        [JsonProperty(PropertyName = "progress")]
        public float? Progress { get; set; }

        /// <summary>
        /// Gets or sets the sharing options for the scrobble response.
        /// See also <seealso cref="ITraktSharing" />.
        /// <para>Nullable</para>
        /// </summary>
        [JsonProperty(PropertyName = "sharing")]
        public ITraktSharing Sharing { get; set; }
    }
}

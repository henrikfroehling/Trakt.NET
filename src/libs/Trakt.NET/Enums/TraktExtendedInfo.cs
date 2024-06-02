using System.Text.Json.Serialization;

namespace TraktNET
{
    /// <summary>
    /// Determines the possible extended options for Trakt API requests, allowing retrieving of additional data.<para />
    /// This enum can be used as a flag and multiple values can be combined.<para />
    /// See <a href ="https://trakt.docs.apiary.io/#introduction/extended-info">"Trakt API Documentation - Extended Info"</a> for more information.
    /// </summary>
    [TraktParameterEnum("extended")]
    [Flags]
    [JsonConverter(typeof(TraktExtendedInfoJsonConverter))]
    public enum TraktExtendedInfo
    {
        /// <summary>No additional data should be retrieved.</summary>
        [TraktEnumMember("")]
        None = 0,

        /// <summary>Metadata information should be retrieved.</summary>
        Metadata = 1,

        /// <summary>Full information for media objects should be retrieved.</summary>
        Full = 2,

        /// <summary>No seasons information should be retrieved.</summary>
        [TraktEnumMember("noseasons")]
        NoSeasons = 4,

        /// <summary>Episodes information should be retrieved.</summary>
        Episodes = 8,

        /// <summary>Guest stars information should be retrieved.</summary>
        GuestStars = 16,

        /// <summary>Comment media object information should be retrieved.</summary>
        Comments = 32,

        /// <summary>User VIP information should be retrieved.</summary>
        VIP = 64
    }
}

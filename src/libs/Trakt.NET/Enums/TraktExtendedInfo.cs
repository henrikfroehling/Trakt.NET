namespace TraktNET
{
    /// <summary>
    /// Determines the possible extended options for Trakt API requests, allowing retrieving of additional data.<para />
    /// This enum can be used as a flag and multiple values can be combined.<para />
    /// See <a href ="https://trakt.docs.apiary.io/#introduction/extended-info">"Trakt API Documentation - Extended Info"</a> for more information.
    /// </summary>
    [TraktEnum(QueryName = "extended", HasQuerySupport = true)]
    [Flags]
    public enum TraktExtendedInfo
    {
        /// <summary>No additional data shall be retrieved.</summary>
        [TraktEnumMember(JsonValue = "")]
        None = 0,

        /// <summary>Metadata information shall be retrieved.</summary>
        Metadata = 1,

        /// <summary>Full information for media objects shall be retrieved.</summary>
        Full = 2,

        /// <summary>No seasons information shall be retrieved.</summary>
        [TraktEnumMember(JsonValue = "noseasons")]
        NoSeasons = 4,

        /// <summary>Episodes information shall be retrieved.</summary>
        Episodes = 8,

        /// <summary>Guest stars information shall be retrieved.</summary>
        GuestStars = 16,

        /// <summary>Comment media object information shall be retrieved.</summary>
        Comments = 32,

        /// <summary>User VIP information shall be retrieved.</summary>
        VIP = 64,

        /// <summary>Media images shall be retrieved.</summary>
        Images = 128
    }
}

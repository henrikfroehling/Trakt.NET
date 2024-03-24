using System.Text.Json.Serialization;
using TraktNET.SourceGenerators;

namespace TraktNET
{
    [TraktEnum]
    [TraktParameterEnum("extended")]
    [Flags]
    [JsonConverter(typeof(TraktExtendedInfoJsonConverter))]
    public enum TraktExtendedInfo
    {
        [TraktEnumMemberJsonValue("")]
        None = 0,

        Metadata = 1,
        Full = 2,

        [TraktEnumMemberJsonValue("noseasons")]
        NoSeasons = 4,

        Episodes = 8,
        GuestStars = 16,
        Comments = 32,
        VIP = 64
    }
}

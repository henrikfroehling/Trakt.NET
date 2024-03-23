using System.Text.Json.Serialization;
using TraktNET.SourceGenerators;

namespace TraktNET
{
    [TraktEnum]
    [JsonConverter(typeof(TraktKnownForDepartmentJsonConverter))]
    public enum TraktKnownForDepartment
    {
        Unspecified,
        Acting,
        Directing,
        Writing,
        Production,

        [TraktEnumMemberJsonValue("visual effects")]
        VisualEffects,

        [TraktEnumMemberJsonValue("costume & make-up", DisplayName = "Costume & Make-Up")]
        CostumeMakeup,

        Camera,
        Sound,
        Editing,
        Art,
        Lighting,
        Crew
    }
}

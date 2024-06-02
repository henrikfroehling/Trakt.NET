using System.Text.Json.Serialization;

namespace TraktNET
{
    /// <summary>Determines the department of a person.</summary>
    [TraktEnum]
    [JsonConverter(typeof(TraktKnownForDepartmentJsonConverter))]
    public enum TraktKnownForDepartment
    {
        /// <summary>An invalid department type.</summary>
        Unspecified,

        /// <summary>The acting department.</summary>
        Acting,

        /// <summary>The directing department.</summary>
        Directing,

        /// <summary>The writing department.</summary>
        Writing,

        /// <summary>The production department.</summary>
        Production,

        /// <summary>The visual effects department.</summary>
        [TraktEnumMember("visual effects")]
        VisualEffects,

        /// <summary>The costume and make-up department.</summary>
        [TraktEnumMember("costume & make-up", DisplayName = "Costume & Make-Up")]
        CostumeMakeup,

        /// <summary>The camera department.</summary>
        Camera,

        /// <summary>The sound department.</summary>
        Sound,

        /// <summary>The editing department.</summary>
        Editing,

        /// <summary>The art department.</summary>
        Art,

        /// <summary>The lighting department.</summary>
        Lighting,

        /// <summary>The crew department.</summary>
        Crew
    }
}

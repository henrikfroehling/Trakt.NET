using System.Text.Json.Serialization;
using TraktNET.SourceGenerators;

namespace TraktNET
{
    /// <summary>Determines the gender of a person.</summary>
    [TraktEnum]
    [JsonConverter(typeof(TraktGenderJsonConverter))]
    public enum TraktGender
    {
        /// <summary>An invalid gender type.</summary>
        Unspecified,

        /// <summary>The male gender.</summary>
        Male,

        /// <summary>The female gender.</summary>
        Female,

        /// <summary>The non binary gender.</summary>
        NonBinary
    }
}

using System.Text.Json.Serialization;
using TraktNET.SourceGenerators;

namespace TraktNET
{
    [TraktEnum]
    [JsonConverter(typeof(TraktGenderJsonConverter))]
    public enum TraktGender
    {
        Unspecified,
        Male,
        Female,
        NonBinary
    }
}

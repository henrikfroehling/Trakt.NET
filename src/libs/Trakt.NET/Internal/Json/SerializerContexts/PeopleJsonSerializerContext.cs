#if NET6_0_OR_GREATER
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace TraktNET
{
    [ExcludeFromCodeCoverage]
    [JsonSerializable(typeof(TraktPerson))]
    [JsonSerializable(typeof(IReadOnlyList<TraktPerson>))]
    [JsonSerializable(typeof(TraktPersonIDs))]
    [JsonSerializable(typeof(IReadOnlyList<TraktPersonIDs>))]
    [JsonSerializable(typeof(TraktPersonImages))]
    [JsonSerializable(typeof(IReadOnlyList<TraktPersonImages>))]
    [JsonSerializable(typeof(TraktPersonMinimal))]
    [JsonSerializable(typeof(IReadOnlyList<TraktPersonMinimal>))]
    [JsonSerializable(typeof(TraktPersonSocialIDs))]
    [JsonSerializable(typeof(IReadOnlyList<TraktPersonSocialIDs>))]
    public sealed partial class PeopleJsonSerializerContext : JsonSerializerContext
    {
    }
}
#endif

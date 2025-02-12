#if NET6_0_OR_GREATER
using System.Text.Json.Serialization;

namespace TraktNET
{
    internal interface IJsonSerializerContextFactory
    {
        JsonSerializerContext GetContext<TJsonObjectType>();
    }
}
#endif

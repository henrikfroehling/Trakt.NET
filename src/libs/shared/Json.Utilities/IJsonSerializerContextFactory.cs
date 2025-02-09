#if NET6_0_OR_GREATER
using System.Text.Json.Serialization;

namespace TraktNET
{
    public interface IJsonSerializerContextFactory
    {
        JsonSerializerContext GetContext<TJsonObjectType>();
    }
}
#endif

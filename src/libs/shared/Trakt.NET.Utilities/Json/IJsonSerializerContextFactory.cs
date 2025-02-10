#if NET6_0_OR_GREATER
using System.Text.Json.Serialization;

namespace TraktNET.Utilities.Json
{
    public interface IJsonSerializerContextFactory
    {
        JsonSerializerContext GetContext<TJsonObjectType>();
    }
}
#endif

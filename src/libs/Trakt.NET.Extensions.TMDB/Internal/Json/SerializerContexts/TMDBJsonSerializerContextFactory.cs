#if NET6_0_OR_GREATER
using System.Text.Json.Serialization;

namespace TraktNET
{
    internal sealed class TMDBJsonSerializerContextFactory : IJsonSerializerContextFactory
    {
        private static readonly TMDBJsonSerializerContext s_jsonSerializerContext = new();

        public JsonSerializerContext GetContext<TJsonObjectType>() => s_jsonSerializerContext;
    }
}
#endif

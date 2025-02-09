#if NET6_0_OR_GREATER
using System.Diagnostics;
using System.Text.Json.Serialization;

namespace TraktNET
{
    public static class JsonSerializerContextFactoryRegistry
    {
        private static readonly Dictionary<string, IJsonSerializerContextFactory> s_jsonSerializerFactories = [];

        public static void RegisterFactory(string key, IJsonSerializerContextFactory factory)
        {
            Debug.Assert(!string.IsNullOrWhiteSpace(key));
            _ = s_jsonSerializerFactories.TryAdd(key, factory);
        }

        public static JsonSerializerContext GetContext<TJsonObjectType>(string factoryKey)
        {
            Debug.Assert(!string.IsNullOrWhiteSpace(factoryKey));
            Debug.Assert(s_jsonSerializerFactories.ContainsKey(factoryKey));
            return s_jsonSerializerFactories[factoryKey].GetContext<TJsonObjectType>();
        }
    }
}
#endif

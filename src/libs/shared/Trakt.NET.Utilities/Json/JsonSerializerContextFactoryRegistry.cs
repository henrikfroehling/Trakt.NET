#if NET6_0_OR_GREATER
using System.Diagnostics;

namespace TraktNET.Utilities.Json
{
    public static class JsonSerializerContextFactoryRegistry
    {
        private static readonly Dictionary<string, IJsonSerializerContextFactory> s_jsonSerializerFactories = [];

        public static void RegisterFactory(string key, IJsonSerializerContextFactory factory)
        {
            Debug.Assert(!string.IsNullOrWhiteSpace(key));
            _ = s_jsonSerializerFactories.TryAdd(key, factory);
        }

        public static IJsonSerializerContextFactory Get(string factoryKey)
        {
            Debug.Assert(!string.IsNullOrWhiteSpace(factoryKey));
            Debug.Assert(s_jsonSerializerFactories.ContainsKey(factoryKey));
            return s_jsonSerializerFactories[factoryKey];
        }
    }
}
#endif

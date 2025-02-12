#if NET6_0_OR_GREATER
using System.Diagnostics;

namespace TraktNET
{
    internal static class JsonSerializerContextFactoryRegistry
    {
        private static readonly Dictionary<string, IJsonSerializerContextFactory> s_jsonSerializerFactories = [];

        internal static void RegisterFactory(string key, IJsonSerializerContextFactory factory)
        {
            Debug.Assert(!string.IsNullOrWhiteSpace(key));
            _ = s_jsonSerializerFactories.TryAdd(key, factory);
        }

        internal static IJsonSerializerContextFactory Get(string factoryKey)
        {
            Debug.Assert(!string.IsNullOrWhiteSpace(factoryKey));
            Debug.Assert(s_jsonSerializerFactories.ContainsKey(factoryKey));
            return s_jsonSerializerFactories[factoryKey];
        }
    }
}
#endif

using System.Collections.Concurrent;
using System.Diagnostics;

namespace TraktNET
{
    internal static class ContextRegistry
    {
        private static readonly ConcurrentDictionary<string, ITraktContext> s_contexts = new();

        internal static void Add(ITraktContext context) => _ = s_contexts.TryAdd(context.ID, context);

        internal static void Add(string id, ITraktContext context)
        {
            Debug.Assert(!string.IsNullOrWhiteSpace(id));
            _ = s_contexts.TryAdd(id, context);
        }

        internal static TContext Get<TContext>(string id) where TContext : class, ITraktContext
        {
            Debug.Assert(s_contexts.ContainsKey(id));
            return (s_contexts[id] as TContext)!;
        }
    }
}

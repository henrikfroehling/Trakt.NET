namespace TraktApiSharp.Objects.JsonReader
{
    using System;
    using System.Collections.Generic;

    internal static class TraktJsonReaderFactory<TReturnType> where TReturnType : class, new()
    {
        private const string DEFAULT_KEY = "default";

        private static readonly IDictionary<string, Func<ITraktObjectJsonReader<TReturnType>>> s_objectReaders
            = new Dictionary<string, Func<ITraktObjectJsonReader<TReturnType>>>();

        private static readonly IDictionary<string, Func<ITraktArrayJsonReader<TReturnType>>> s_arrayReaders
            = new Dictionary<string, Func<ITraktArrayJsonReader<TReturnType>>>();

        public static void RegisterObjectReader(Func<ITraktObjectJsonReader<TReturnType>> creatorFunction, string key = DEFAULT_KEY)
        {
            if (!s_objectReaders.ContainsKey(key))
                s_objectReaders.Add(key, creatorFunction);
        }

        public static void RegisterArrayReader(Func<ITraktArrayJsonReader<TReturnType>> creatorFunction, string key = DEFAULT_KEY)
        {
            if (!s_arrayReaders.ContainsKey(key))
                s_arrayReaders[key] = creatorFunction;
        }

        public static ITraktObjectJsonReader<TReturnType> CreateObjectReader(string key = DEFAULT_KEY)
        {
            Func<ITraktObjectJsonReader<TReturnType>> creatorFunction = null;

            if (s_objectReaders.TryGetValue(key, out creatorFunction))
            {
                if (creatorFunction != null)
                    return creatorFunction();
            }

            throw new ArgumentException($"no creator function registered for the given key: \"{key}\"");
        }

        public static ITraktArrayJsonReader<TReturnType> CreateArrayReader(string key = DEFAULT_KEY)
        {
            Func<ITraktArrayJsonReader<TReturnType>> creatorFunction = null;

            if (s_arrayReaders.TryGetValue(key, out creatorFunction))
            {
                if (creatorFunction != null)
                    return creatorFunction();
            }

            throw new ArgumentException($"no creator function registered for the given key: \"{key}\"");
        }

        public static void ClearObjectReaders() => s_objectReaders.Clear();

        public static void ClearArrayReaders() => s_arrayReaders.Clear();

        public static void ClearAllReaders()
        {
            ClearObjectReaders();
            ClearArrayReaders();
        }
    }
}

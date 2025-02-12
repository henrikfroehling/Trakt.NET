#if NET6_0_OR_GREATER
using TraktNET.Utilities.Json;
#endif

namespace TraktNET
{
    public static class TMDBTestUtility
    {
#if NET6_0_OR_GREATER
        static TMDBTestUtility()
            => JsonSerializerContextFactoryRegistry.RegisterFactory(TMDBConstants.Json.FactoryKey, new TMDBJsonSerializerContextFactory());
#endif

        private static readonly TMDBTestUtilityImplementation s_tmdbTestUtility = new();

        public static async Task<string> GetJsonFileContentAsync(string jsonFilename)
            => await s_tmdbTestUtility.GetJsonFileContentAsync(jsonFilename);

        public static async Task<T?> DeserializeJsonAsync<T>(string jsonFilename) where T : class
            => await s_tmdbTestUtility.DeserializeJsonAsync<T>(jsonFilename);

        public static async Task<IReadOnlyList<T>?> DeserializeJsonListAsync<T>(string jsonFilename) where T : class
            => await s_tmdbTestUtility.DeserializeJsonListAsync<T>(jsonFilename);
    }

    internal sealed class TMDBTestUtilityImplementation : TestUtility
    {
        public TMDBTestUtilityImplementation() : base(TMDBConstants.Json.FactoryKey, "TMDB")
        {
        }
    }
}

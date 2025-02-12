namespace TraktNET
{
    public static class TraktTestUtility
    {
#if NET6_0_OR_GREATER
        static TraktTestUtility()
            => JsonSerializerContextFactoryRegistry.RegisterFactory(Constants.Json.FactoryKey, new JsonSerializerContextFactory());
#endif

        private static readonly TraktTestUtilityImplementation s_traktTestUtility = new();

        public static async Task<string> GetJsonFileContentAsync(string jsonFilename)
            => await s_traktTestUtility.GetJsonFileContentAsync(jsonFilename);

        public static async Task<T?> DeserializeJsonAsync<T>(string jsonFilename) where T : class
            => await s_traktTestUtility.DeserializeJsonAsync<T>(jsonFilename);

        public static async Task<IReadOnlyList<T>?> DeserializeJsonListAsync<T>(string jsonFilename) where T : class
            => await s_traktTestUtility.DeserializeJsonListAsync<T>(jsonFilename);
    }

    internal sealed class TraktTestUtilityImplementation : TestUtility
    {
        internal TraktTestUtilityImplementation() : base(Constants.Json.FactoryKey, "Trakt")
        {
        }
    }
}

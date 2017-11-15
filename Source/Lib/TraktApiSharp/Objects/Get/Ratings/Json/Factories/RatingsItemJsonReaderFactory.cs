namespace TraktApiSharp.Objects.Get.Ratings.Json.Factories
{
    using Objects.Json;

    internal class RatingsItemJsonReaderFactory : IJsonReaderFactory<ITraktRatingsItem>
    {
        public IObjectJsonReader<ITraktRatingsItem> CreateObjectReader() => new RatingsItemObjectJsonReader();

        public IArrayJsonReader<ITraktRatingsItem> CreateArrayReader() => new RatingsItemArrayJsonReader();
    }
}

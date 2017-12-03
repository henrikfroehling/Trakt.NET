namespace TraktApiSharp.Objects.Get.Ratings.Json.Factories.Reader
{
    using Get.Ratings.Json.Reader;
    using Objects.Json;

    internal class RatingsItemJsonReaderFactory : IJsonReaderFactory<ITraktRatingsItem>
    {
        public IObjectJsonReader<ITraktRatingsItem> CreateObjectReader() => new RatingsItemObjectJsonReader();

        public IArrayJsonReader<ITraktRatingsItem> CreateArrayReader() => new RatingsItemArrayJsonReader();
    }
}

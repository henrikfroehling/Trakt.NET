namespace TraktApiSharp.Objects.Get.Ratings.JsonReader.Factories
{
    using Objects.JsonReader;

    internal class RatingsItemJsonReaderFactory : IJsonReaderFactory<ITraktRatingsItem>
    {
        public IObjectJsonReader<ITraktRatingsItem> CreateObjectReader() => new RatingsItemObjectJsonReader();

        public IArrayJsonReader<ITraktRatingsItem> CreateArrayReader() => new RatingsItemArrayJsonReader();
    }
}

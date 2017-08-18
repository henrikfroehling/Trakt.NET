namespace TraktApiSharp.Objects.Get.Ratings.JsonReader.Factories
{
    using Objects.JsonReader;

    internal class TraktRatingsItemJsonReaderFactory : IJsonReaderFactory<ITraktRatingsItem>
    {
        public ITraktObjectJsonReader<ITraktRatingsItem> CreateObjectReader() => new TraktRatingsItemObjectJsonReader();

        public ITraktArrayJsonReader<ITraktRatingsItem> CreateArrayReader() => new TraktRatingsItemArrayJsonReader();
    }
}

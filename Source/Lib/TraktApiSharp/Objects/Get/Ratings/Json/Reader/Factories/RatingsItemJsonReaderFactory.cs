namespace TraktApiSharp.Objects.Get.Ratings.Json.Factories
{
    using Get.Ratings.Json.Reader;
    using Objects.Json;

    internal class RatingsItemJsonReaderFactory : IJsonIOFactory<ITraktRatingsItem>
    {
        public IObjectJsonReader<ITraktRatingsItem> CreateObjectReader() => new RatingsItemObjectJsonReader();

        public IArrayJsonReader<ITraktRatingsItem> CreateArrayReader() => new RatingsItemArrayJsonReader();

        public IObjectJsonReader<ITraktRatingsItem> CreateObjectWriter()
        {
            throw new System.NotImplementedException();
        }

        public IArrayJsonReader<ITraktRatingsItem> CreateArrayWriter()
        {
            throw new System.NotImplementedException();
        }
    }
}

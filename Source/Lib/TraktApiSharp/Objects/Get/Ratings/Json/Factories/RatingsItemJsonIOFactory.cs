namespace TraktApiSharp.Objects.Get.Ratings.Json.Factories
{
    using Get.Ratings.Json.Reader;
    using Objects.Json;

    internal class RatingsItemJsonIOFactory : IJsonIOFactory<ITraktRatingsItem>
    {
        public IObjectJsonReader<ITraktRatingsItem> CreateObjectReader() => new RatingsItemObjectJsonReader();

        public IArrayJsonReader<ITraktRatingsItem> CreateArrayReader() => new RatingsItemArrayJsonReader();

        public IObjectJsonWriter<ITraktRatingsItem> CreateObjectWriter()
        {
            throw new System.NotImplementedException();
        }

        public IArrayJsonWriter<ITraktRatingsItem> CreateArrayWriter()
        {
            throw new System.NotImplementedException();
        }
    }
}

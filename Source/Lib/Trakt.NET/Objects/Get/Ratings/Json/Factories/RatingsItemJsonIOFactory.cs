namespace TraktNet.Objects.Get.Ratings.Json.Factories
{
    using Get.Ratings.Json.Reader;
    using Get.Ratings.Json.Writer;
    using Objects.Json;

    internal class RatingsItemJsonIOFactory : IJsonIOFactory<ITraktRatingsItem>
    {
        public IObjectJsonReader<ITraktRatingsItem> CreateObjectReader() => new RatingsItemObjectJsonReader();

        public IArrayJsonReader<ITraktRatingsItem> CreateArrayReader() => new RatingsItemArrayJsonReader();

        public IObjectJsonWriter<ITraktRatingsItem> CreateObjectWriter() => new RatingsItemObjectJsonWriter();
    }
}

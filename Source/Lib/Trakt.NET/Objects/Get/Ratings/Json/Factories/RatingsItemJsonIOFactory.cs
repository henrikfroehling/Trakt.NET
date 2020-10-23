namespace TraktNet.Objects.Get.Ratings.Json.Factories
{
    using Get.Ratings.Json.Reader;
    using Get.Ratings.Json.Writer;
    using Objects.Json;

    internal class RatingsItemJsonIOFactory : IJsonIOFactory<ITraktRatingsItem>
    {
        public IObjectJsonReader<ITraktRatingsItem> CreateObjectReader() => new RatingsItemObjectJsonReader();

        public IObjectJsonWriter<ITraktRatingsItem> CreateObjectWriter() => new RatingsItemObjectJsonWriter();
    }
}

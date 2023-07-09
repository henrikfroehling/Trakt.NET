namespace TraktNet.Objects.Get.Lists.Json.Factories
{
    using Get.Lists.Json.Reader;
    using Get.Lists.Json.Writer;
    using Objects.Json;

    internal class TrendingListJsonIOFactory : IJsonIOFactory<ITraktTrendingList>
    {
        public IObjectJsonReader<ITraktTrendingList> CreateObjectReader() => new TrendingListObjectJsonReader();

        public IObjectJsonWriter<ITraktTrendingList> CreateObjectWriter() => new TrendingListObjectJsonWriter();
    }
}

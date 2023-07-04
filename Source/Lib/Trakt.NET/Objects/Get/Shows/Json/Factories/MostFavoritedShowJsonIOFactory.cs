namespace TraktNet.Objects.Get.Shows.Json.Factories
{
    using Get.Shows.Json.Reader;
    using Get.Shows.Json.Writer;
    using Objects.Json;

    internal class MostFavoritedShowJsonIOFactory : IJsonIOFactory<ITraktMostFavoritedShow>
    {
        public IObjectJsonReader<ITraktMostFavoritedShow> CreateObjectReader() => new MostFavoritedShowObjectJsonReader();

        public IObjectJsonWriter<ITraktMostFavoritedShow> CreateObjectWriter() => new MostFavoritedShowObjectJsonWriter();
    }
}

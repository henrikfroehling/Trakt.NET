namespace TraktNet.Objects.Get.Recommendations.Json.Factories
{
    using Get.Recommendations.Json.Reader;
    using Get.Recommendations.Json.Writer;
    using Objects.Json;

    internal class FavoritedByJsonIOFactory : IJsonIOFactory<ITraktFavoritedBy>
    {
        public IObjectJsonReader<ITraktFavoritedBy> CreateObjectReader() => new FavoritedByObjectJsonReader();

        public IObjectJsonWriter<ITraktFavoritedBy> CreateObjectWriter() => new FavoritedByObjectJsonWriter();
    }
}

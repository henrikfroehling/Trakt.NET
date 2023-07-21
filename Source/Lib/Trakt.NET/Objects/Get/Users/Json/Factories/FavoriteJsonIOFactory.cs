namespace TraktNet.Objects.Get.Users.Json.Factories
{
    using Get.Users.Json.Reader;
    using Get.Users.Json.Writer;
    using Objects.Json;

    internal class FavoriteJsonIOFactory : IJsonIOFactory<ITraktFavorite>
    {
        public IObjectJsonReader<ITraktFavorite> CreateObjectReader() => new FavoriteObjectJsonReader();

        public IObjectJsonWriter<ITraktFavorite> CreateObjectWriter() => new FavoriteObjectJsonWriter();
    }
}

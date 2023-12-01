namespace TraktNet.Objects.Get.Users.Json.Factories
{
    using Get.Users.Json.Reader;
    using Get.Users.Json.Writer;
    using Objects.Json;

    internal class UserFavoritesLimitsJsonIOFactory : IJsonIOFactory<ITraktUserFavoritesLimits>
    {
        public IObjectJsonReader<ITraktUserFavoritesLimits> CreateObjectReader() => new UserFavoritesLimitsObjectJsonReader();

        public IObjectJsonWriter<ITraktUserFavoritesLimits> CreateObjectWriter() => new UserFavoritesLimitsObjectJsonWriter();
    }
}

namespace TraktNet.Objects.Get.Users.Json.Factories
{
    using Get.Users.Json.Reader;
    using Get.Users.Json.Writer;
    using Objects.Json;

    internal class UserWatchlistLimitsJsonIOFactory : IJsonIOFactory<ITraktUserWatchlistLimits>
    {
        public IObjectJsonReader<ITraktUserWatchlistLimits> CreateObjectReader() => new UserWatchlistLimitsObjectJsonReader();

        public IObjectJsonWriter<ITraktUserWatchlistLimits> CreateObjectWriter() => new UserWatchlistLimitsObjectJsonWriter();
    }
}

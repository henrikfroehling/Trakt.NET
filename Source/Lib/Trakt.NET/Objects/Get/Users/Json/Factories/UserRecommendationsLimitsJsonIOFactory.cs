namespace TraktNet.Objects.Get.Users.Json.Factories
{
    using Get.Users.Json.Reader;
    using Get.Users.Json.Writer;
    using Objects.Json;

    internal class UserRecommendationsLimitsJsonIOFactory : IJsonIOFactory<ITraktUserRecommendationsLimits>
    {
        public IObjectJsonReader<ITraktUserRecommendationsLimits> CreateObjectReader() => new UserRecommendationsLimitsObjectJsonReader();

        public IObjectJsonWriter<ITraktUserRecommendationsLimits> CreateObjectWriter() => new UserRecommendationsLimitsObjectJsonWriter();
    }
}

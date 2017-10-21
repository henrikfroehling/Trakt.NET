namespace TraktApiSharp.Tests.Objects.Get.Users.Implementations
{
    using FluentAssertions;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Objects.Get.Users.Implementations;
    using TraktApiSharp.Objects.Get.Users.JsonReader;
    using Xunit;

    [Category("Objects.Get.Users.Implementations")]
    public class TraktUserIds_Tests
    {
        [Fact]
        public void Test_TraktUserIds_Default_Constructor()
        {
            var userIds = new TraktUserIds();

            userIds.Slug.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktUserIds_From_Json()
        {
            var jsonReader = new UserIdsObjectJsonReader();
            var userIds = await jsonReader.ReadObjectAsync(JSON) as TraktUserIds;

            userIds.Should().NotBeNull();
            userIds.Slug.Should().Be("sean");
        }

        private const string JSON =
            @"{
                ""slug"": ""sean""
              }";
    }
}

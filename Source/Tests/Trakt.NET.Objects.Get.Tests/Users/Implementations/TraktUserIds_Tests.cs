﻿namespace TraktNet.Objects.Get.Tests.Users.Implementations
{
    using FluentAssertions;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Users;
    using TraktNet.Objects.Get.Users.Json.Reader;
    using Xunit;

    [TestCategory("Objects.Get.Users.Implementations")]
    public class TraktUserIds_Tests
    {
        [Fact]
        public void Test_TraktUserIds_Default_Constructor()
        {
            var userIds = new TraktUserIds();

            userIds.Slug.Should().BeNull();
            userIds.UUID.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktUserIds_From_Json()
        {
            var jsonReader = new UserIdsObjectJsonReader();
            var userIds = await jsonReader.ReadObjectAsync(JSON) as TraktUserIds;

            userIds.Should().NotBeNull();
            userIds.Slug.Should().Be("sean");
            userIds.UUID.Should().Be("b6589fc6ab0dc82cf12099d1c2d40ab994e8410c");
        }

        private const string JSON =
            @"{
                ""slug"": ""sean"",
                ""uuid"": ""b6589fc6ab0dc82cf12099d1c2d40ab994e8410c""
              }";
    }
}

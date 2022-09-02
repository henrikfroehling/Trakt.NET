namespace TraktNet.Objects.Get.Tests.Lists.Implementations
{
    using FluentAssertions;
    using System;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Lists;
    using TraktNet.Objects.Get.Lists.Json.Reader;
    using Xunit;

    [Category("Objects.Get.Lists.Implementations")]
    public class TraktListLike_Tests
    {
        [Fact]
        public void Test_TraktListLike_Default_Constructor()
        {
            var listLike = new TraktListLike();

            listLike.LikedAt.Should().BeNull();
            listLike.User.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktListLike_With_Type_Movie_From_Minimal_Json()
        {
            var jsonReader = new ListLikeObjectJsonReader();
            var listLike = await jsonReader.ReadObjectAsync(JSON) as TraktListLike;

            listLike.Should().NotBeNull();
            listLike.LikedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            listLike.User.Should().NotBeNull();
            listLike.User.Username.Should().Be("justin");
            listLike.User.IsPrivate.Should().BeFalse();
            listLike.User.Name.Should().Be("Justin Nemeth");
            listLike.User.IsVIP.Should().BeTrue();
            listLike.User.IsVIP_EP.Should().BeTrue();
            listLike.User.Ids.Should().NotBeNull();
            listLike.User.Ids.Slug.Should().Be("justin");
        }

        private const string JSON =
            @"{
                ""liked_at"": ""2014-09-01T09:10:11.000Z"",
                ""user"": {
                  ""username"": ""justin"",
                  ""private"": false,
                  ""name"": ""Justin Nemeth"",
                  ""vip"": true,
                  ""vip_ep"": true,
                  ""ids"": {
                    ""slug"": ""justin""
                  }
                }
              }";
    }
}

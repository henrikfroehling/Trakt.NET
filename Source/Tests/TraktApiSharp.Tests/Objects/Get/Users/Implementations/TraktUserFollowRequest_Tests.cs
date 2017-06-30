namespace TraktApiSharp.Tests.Objects.Get.Users.Implementations
{
    using FluentAssertions;
    using System;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Objects.Get.Users;
    using TraktApiSharp.Objects.Get.Users.Implementations;
    using TraktApiSharp.Objects.Get.Users.JsonReader;
    using Xunit;

    [Category("Objects.Get.Users.Implementations")]
    public class TraktUserFollowRequest_Tests
    {
        [Fact]
        public void Test_TraktUserFollowRequest_Implements_ITraktUserFollowRequest_Interface()
        {
            typeof(TraktUserFollowRequest).GetInterfaces().Should().Contain(typeof(ITraktUserFollowRequest));
        }

        [Fact]
        public void Test_TraktUserFollowRequest_Default_Constructor()
        {
            var userFollowRequest = new TraktUserFollowRequest();

            userFollowRequest.Id.Should().Be(0);
            userFollowRequest.RequestedAt.Should().BeNull();
            userFollowRequest.User.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktUserFollowRequest_From_Json()
        {
            var jsonReader = new TraktUserFollowRequestObjectJsonReader();
            var userFollowRequest = await jsonReader.ReadObjectAsync(JSON) as TraktUserFollowRequest;

            userFollowRequest.Should().NotBeNull();
            userFollowRequest.Id.Should().Be(12345U);
            userFollowRequest.RequestedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());

            userFollowRequest.User.Should().NotBeNull();
            userFollowRequest.User.Username.Should().Be("sean");
            userFollowRequest.User.IsPrivate.Should().BeFalse();
            userFollowRequest.User.Name.Should().Be("Sean Rudford");
            userFollowRequest.User.IsVIP.Should().BeTrue();
            userFollowRequest.User.IsVIP_EP.Should().BeTrue();
            userFollowRequest.User.Ids.Should().NotBeNull();
            userFollowRequest.User.Ids.Slug.Should().Be("sean");
            userFollowRequest.User.JoinedAt.Should().HaveValue().And.Be(DateTime.Parse("2010-09-25T17:49:25.000Z").ToUniversalTime());
            userFollowRequest.User.Location.Should().Be("SF");
            userFollowRequest.User.About.Should().Be("I have all your cassette tapes.");
            userFollowRequest.User.Gender.Should().Be("male");
            userFollowRequest.User.Age.Should().Be(35);
            userFollowRequest.User.Images.Should().NotBeNull();
            userFollowRequest.User.Images.Avatar.Should().NotBeNull();
            userFollowRequest.User.Images.Avatar.Full.Should().Be("https://walter-dev.trakt.tv/images/users/000/000/001/avatars/large/0ba3f72910.jpg");
        }

        private const string JSON =
            @"{
                ""id"": 12345,
                ""requested_at"": ""2014-09-01T09:10:11.000Z"",
                ""user"": {
                  ""username"": ""sean"",
                  ""private"": false,
                  ""name"": ""Sean Rudford"",
                  ""vip"": true,
                  ""vip_ep"": true,
                  ""ids"": {
                    ""slug"": ""sean""
                  },
                  ""joined_at"": ""2010-09-25T17:49:25.000Z"",
                  ""location"": ""SF"",
                  ""about"": ""I have all your cassette tapes."",
                  ""gender"": ""male"",
                  ""age"": 35,
                  ""images"": {
                    ""avatar"": {
                      ""full"": ""https://walter-dev.trakt.tv/images/users/000/000/001/avatars/large/0ba3f72910.jpg""
                    }
                  }
                }
              }";
    }
}

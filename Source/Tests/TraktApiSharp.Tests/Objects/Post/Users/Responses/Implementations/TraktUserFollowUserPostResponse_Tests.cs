namespace TraktApiSharp.Tests.Objects.Post.Users.Responses.Implementations
{
    using FluentAssertions;
    using System;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Objects.Post.Users.Responses;
    using TraktApiSharp.Objects.Post.Users.Responses.Implementations;
    using TraktApiSharp.Objects.Post.Users.Responses.JsonReader;
    using Xunit;

    [Category("Objects.Post.Users.Responses.Implementations")]
    public class TraktUserFollowUserPostResponse_Tests
    {
        [Fact]
        public void Test_TraktUserFollowUserPostResponse_Implements_ITraktUserFollowUserPostResponse_Interface()
        {
            typeof(TraktUserFollowUserPostResponse).GetInterfaces().Should().Contain(typeof(ITraktUserFollowUserPostResponse));
        }

        [Fact]
        public void Test_TraktUserFollowUserPostResponse_Default_Constructor()
        {
            var userFollowUserPostResponse = new TraktUserFollowUserPostResponse();

            userFollowUserPostResponse.ApprovedAt.Should().BeNull();
            userFollowUserPostResponse.User.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktUserFollowUserPostResponse_From_Json()
        {
            var jsonReader = new UserFollowUserPostResponseObjectJsonReader();
            var userFollowUserPostResponse = await jsonReader.ReadObjectAsync(JSON) as TraktUserFollowUserPostResponse;

            userFollowUserPostResponse.Should().NotBeNull();

            userFollowUserPostResponse.ApprovedAt.Should().Be(DateTime.Parse("2014-11-15T09:41:34.704Z").ToUniversalTime());

            userFollowUserPostResponse.User.Should().NotBeNull();
            userFollowUserPostResponse.User.Username.Should().Be("sean");
            userFollowUserPostResponse.User.IsPrivate.Should().BeFalse();
            userFollowUserPostResponse.User.Name.Should().Be("Sean Rudford");
            userFollowUserPostResponse.User.IsVIP.Should().BeTrue();
            userFollowUserPostResponse.User.IsVIP_EP.Should().BeTrue();
            userFollowUserPostResponse.User.Ids.Should().NotBeNull();
            userFollowUserPostResponse.User.Ids.Slug.Should().Be("sean");
            userFollowUserPostResponse.User.JoinedAt.Should().HaveValue().And.Be(DateTime.Parse("2010-09-25T17:49:25.000Z").ToUniversalTime());
            userFollowUserPostResponse.User.Location.Should().Be("SF");
            userFollowUserPostResponse.User.About.Should().Be("I have all your cassette tapes.");
            userFollowUserPostResponse.User.Gender.Should().Be("male");
            userFollowUserPostResponse.User.Age.Should().Be(35);
            userFollowUserPostResponse.User.Images.Should().NotBeNull();
            userFollowUserPostResponse.User.Images.Avatar.Should().NotBeNull();
            userFollowUserPostResponse.User.Images.Avatar.Full.Should().Be("https://walter-dev.trakt.tv/images/users/000/000/001/avatars/large/0ba3f72910.jpg");
        }

        private const string JSON =
            @"{
                ""approved_at"": ""2014-11-15T09:41:34.704Z"",
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

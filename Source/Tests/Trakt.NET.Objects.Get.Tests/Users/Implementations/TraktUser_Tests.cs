namespace TraktNet.Objects.Get.Tests.Users.Implementations
{
    using FluentAssertions;
    using System;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Users;
    using TraktNet.Objects.Get.Users.Json.Reader;
    using Xunit;

    [Category("Objects.Get.Users.Implementations")]
    public class TraktUser_Tests
    {
        [Fact]
        public void Test_TraktUser_Default_Constructor()
        {
            var user = new TraktUser();

            user.Username.Should().BeNull();
            user.IsPrivate.Should().BeNull();
            user.Name.Should().BeNull();
            user.IsVIP.Should().BeNull();
            user.IsVIP_EP.Should().BeNull();
            user.Ids.Should().BeNull();
            user.JoinedAt.Should().BeNull();
            user.Location.Should().BeNull();
            user.About.Should().BeNull();
            user.Gender.Should().BeNull();
            user.Age.Should().BeNull();
            user.Images.Should().BeNull();
            user.IsVIP_OG.Should().BeNull();
            user.VIP_Years.Should().BeNull();
            user.VIP_CoverImage.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktUser_From_Minimal_Json()
        {
            var jsonReader = new UserObjectJsonReader();
            var user = await jsonReader.ReadObjectAsync(MINIMAL_JSON) as TraktUser;

            user.Should().NotBeNull();
            user.Username.Should().Be("sean");
            user.IsPrivate.Should().BeFalse();
            user.Name.Should().Be("Sean Rudford");
            user.IsVIP.Should().BeTrue();
            user.IsVIP_EP.Should().BeTrue();
            user.Ids.Should().NotBeNull();
            user.Ids.Slug.Should().Be("sean");
            user.Ids.UUID.Should().Be("3528009dgf0dfhkasghsgng00ds7g0907hfdslsha0070");
            user.JoinedAt.Should().BeNull();
            user.Location.Should().BeNull();
            user.About.Should().BeNull();
            user.Gender.Should().BeNull();
            user.Age.Should().BeNull();
            user.Images.Should().BeNull();
            user.IsVIP_OG.Should().BeNull();
            user.VIP_Years.Should().BeNull();
            user.VIP_CoverImage.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktUser_From_Full_Json()
        {
            var jsonReader = new UserObjectJsonReader();
            var user = await jsonReader.ReadObjectAsync(FULL_JSON) as TraktUser;

            user.Should().NotBeNull();
            user.Username.Should().Be("sean");
            user.IsPrivate.Should().BeFalse();
            user.Name.Should().Be("Sean Rudford");
            user.IsVIP.Should().BeTrue();
            user.IsVIP_EP.Should().BeTrue();
            user.Ids.Should().NotBeNull();
            user.Ids.Slug.Should().Be("sean");
            user.Ids.UUID.Should().Be("3528009dgf0dfhkasghsgng00ds7g0907hfdslsha0070");
            user.JoinedAt.Should().HaveValue().And.Be(DateTime.Parse("2010-09-25T17:49:25.000Z").ToUniversalTime());
            user.Location.Should().Be("SF");
            user.About.Should().Be("I have all your cassette tapes.");
            user.Gender.Should().Be("male");
            user.Age.Should().Be(35);
            user.Images.Should().NotBeNull();
            user.Images.Avatar.Should().NotBeNull();
            user.Images.Avatar.Full.Should().Be("https://walter-dev.trakt.tv/images/users/000/000/001/avatars/large/0ba3f72910.jpg");
            user.IsVIP_OG.Should().BeTrue();
            user.VIP_Years.Should().Be(5);
            user.VIP_CoverImage.Should().Be("https://walter.trakt.tv/images/shows/000/043/973/fanarts/full/eb3a126015.jpg");
        }

        private const string MINIMAL_JSON =
            @"{
                ""username"": ""sean"",
                ""private"": false,
                ""name"": ""Sean Rudford"",
                ""vip"": true,
                ""vip_ep"": true,
                ""ids"": {
                  ""slug"": ""sean"",
                  ""uuid"": ""3528009dgf0dfhkasghsgng00ds7g0907hfdslsha0070""
                }
              }";

        private const string FULL_JSON =
            @"{
                ""username"": ""sean"",
                ""private"": false,
                ""name"": ""Sean Rudford"",
                ""vip"": true,
                ""vip_ep"": true,
                ""ids"": {
                  ""slug"": ""sean"",
                  ""uuid"": ""3528009dgf0dfhkasghsgng00ds7g0907hfdslsha0070""
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
                },
                ""vip_og"": true,
                ""vip_years"": 5,
                ""vip_cover_image"": ""https://walter.trakt.tv/images/shows/000/043/973/fanarts/full/eb3a126015.jpg""
              }";
    }
}

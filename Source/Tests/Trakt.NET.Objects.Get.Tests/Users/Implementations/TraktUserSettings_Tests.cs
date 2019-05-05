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
    public class TraktUserSettings_Tests
    {
        [Fact]
        public void Test_TraktUserSettings_Default_Constructor()
        {
            var userSettings = new TraktUserSettings();

            userSettings.User.Should().BeNull();
            userSettings.Account.Should().BeNull();
            userSettings.Connections.Should().BeNull();
            userSettings.SharingText.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktUserSettings_From_Json()
        {
            var jsonReader = new UserSettingsObjectJsonReader();
            var userSettings = await jsonReader.ReadObjectAsync(JSON) as TraktUserSettings;

            userSettings.Should().NotBeNull();

            userSettings.User.Should().NotBeNull();
            userSettings.User.Username.Should().Be("sean");
            userSettings.User.IsPrivate.Should().BeFalse();
            userSettings.User.Name.Should().Be("Sean Rudford");
            userSettings.User.IsVIP.Should().BeTrue();
            userSettings.User.IsVIP_EP.Should().BeTrue();
            userSettings.User.Ids.Should().NotBeNull();
            userSettings.User.Ids.Slug.Should().Be("sean");
            userSettings.User.JoinedAt.Should().HaveValue().And.Be(DateTime.Parse("2010-09-25T17:49:25.000Z").ToUniversalTime());
            userSettings.User.Location.Should().Be("SF");
            userSettings.User.About.Should().Be("I have all your cassette tapes.");
            userSettings.User.Gender.Should().Be("male");
            userSettings.User.Age.Should().Be(35);
            userSettings.User.Images.Should().NotBeNull();
            userSettings.User.Images.Avatar.Should().NotBeNull();
            userSettings.User.Images.Avatar.Full.Should().Be("https://walter-dev.trakt.tv/images/users/000/000/001/avatars/large/0ba3f72910.jpg");

            userSettings.Account.Should().NotBeNull();
            userSettings.Account.TimeZoneId.Should().Be("America/Los_Angeles");
            userSettings.Account.Time24Hr.Should().BeTrue();
            userSettings.Account.CoverImage.Should().Be("https://walter.trakt.us/images/movies/000/001/545/fanarts/original/0abb604492.jpg?1406095042");
            userSettings.Account.Token.Should().Be("60fa34c4f5e7f093ecc5a2d16d691e24");

            userSettings.Connections.Should().NotBeNull();
            userSettings.Connections.Facebook.Should().BeTrue();
            userSettings.Connections.Twitter.Should().BeTrue();
            userSettings.Connections.Google.Should().BeTrue();
            userSettings.Connections.Tumblr.Should().BeTrue();
            userSettings.Connections.Medium.Should().BeTrue();
            userSettings.Connections.Slack.Should().BeTrue();

            userSettings.SharingText.Should().NotBeNull();
            userSettings.SharingText.Watching.Should().Be("I'm watching [item]");
            userSettings.SharingText.Watched.Should().Be("I just watched [item]");
        }

        private const string JSON =
            @"{
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
                },
                ""account"": {
                  ""timezone"": ""America/Los_Angeles"",
                  ""time_24hr"": true,
                  ""cover_image"": ""https://walter.trakt.us/images/movies/000/001/545/fanarts/original/0abb604492.jpg?1406095042"",
                  ""token"": ""60fa34c4f5e7f093ecc5a2d16d691e24""
                },
                ""connections"": {
                  ""facebook"": true,
                  ""twitter"": true,
                  ""google"": true,
                  ""tumblr"": true,
                  ""medium"": true,
                  ""slack"": true
                },
                ""sharing_text"": {
                  ""watching"": ""I'm watching [item]"",
                  ""watched"": ""I just watched [item]""
                }
              }";
    }
}

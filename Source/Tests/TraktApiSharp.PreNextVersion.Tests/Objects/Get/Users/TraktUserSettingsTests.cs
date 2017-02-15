namespace TraktApiSharp.Tests.Objects.Users
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    using System;
    using TraktApiSharp.Objects.Get.Users;
    using Utils;

    [TestClass]
    public class TraktUserSettingsTests
    {
        [TestMethod]
        public void TestTraktUserSettingsDefaultConstructor()
        {
            var userSettings = new TraktUserSettings();

            userSettings.User.Should().BeNull();
            userSettings.Account.Should().BeNull();
            userSettings.Connections.Should().BeNull();
            userSettings.SharingText.Should().BeNull();
        }

        [TestMethod]
        public void TestTraktUserSettingsReadFromJson()
        {
            var jsonFile = TestUtility.ReadFileContents(@"Objects\Get\Users\UserSettings.json");

            jsonFile.Should().NotBeNullOrEmpty();

            var userSettings = JsonConvert.DeserializeObject<TraktUserSettings>(jsonFile);

            userSettings.Should().NotBeNull();
            userSettings.User.Should().NotBeNull();
            userSettings.User.Username.Should().Be("justin");
            userSettings.User.IsPrivate.Should().BeFalse();
            userSettings.User.Name.Should().Be("Justin Nemeth");
            userSettings.User.IsVIP.Should().BeTrue();
            userSettings.User.IsVIP_EP.Should().BeFalse();
            userSettings.User.JoinedAt.Should().HaveValue().And.Be(DateTime.Parse("2010-09-25T17:49:25.000Z").ToUniversalTime());
            userSettings.User.Location.Should().Be("San Diego, CA");
            userSettings.User.About.Should().Be("Co-founder of trakt.");
            userSettings.User.Gender.Should().Be("male");
            userSettings.User.Age.Should().Be(32);
            userSettings.User.Images.Should().NotBeNull();
            userSettings.User.Images.Avatar.Should().NotBeNull();
            userSettings.User.Images.Avatar.Full.Should().Be("https://secure.gravatar.com/avatar/30c2f0dfbc39e48656f40498aa871e33?r=pg&s=256");
            userSettings.Account.Should().NotBeNull();
            userSettings.Account.TimeZoneId.Should().Be("America/Los_Angeles");
            userSettings.Account.Time24Hr.Should().BeFalse();
            userSettings.Account.CoverImage.Should().Be("https://walter.trakt.us/images/movies/000/001/545/fanarts/original/0abb604492.jpg?1406095042");
            userSettings.Connections.Should().NotBeNull();
            userSettings.Connections.Facebook.Should().BeTrue();
            userSettings.Connections.Twitter.Should().BeTrue();
            userSettings.Connections.Google.Should().BeTrue();
            userSettings.Connections.Tumblr.Should().BeFalse();
            userSettings.Connections.Medium.Should().BeFalse();
            userSettings.Connections.Slack.Should().BeFalse();
            userSettings.SharingText.Should().NotBeNull();
            userSettings.SharingText.Watching.Should().Be("I'm watching [item]");
            userSettings.SharingText.Watched.Should().Be("I just watched [item]");
        }
    }
}

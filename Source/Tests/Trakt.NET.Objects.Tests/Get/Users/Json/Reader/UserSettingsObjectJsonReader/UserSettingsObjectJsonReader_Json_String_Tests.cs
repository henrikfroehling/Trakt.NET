﻿namespace TraktNet.Objects.Tests.Get.Users.Json.Reader
{
    using FluentAssertions;
    using System;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Users.Json.Reader;
    using Xunit;

    [Category("Objects.Get.Users.JsonReader")]
    public partial class UserSettingsObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_UserSettingsObjectJsonReader_ReadObject_From_Json_String_Complete()
        {
            var jsonReader = new UserSettingsObjectJsonReader();

            var userSettings = await jsonReader.ReadObjectAsync(JSON_COMPLETE);

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

        [Fact]
        public async Task Test_UserSettingsObjectJsonReader_ReadObject_From_Json_String_Incomplete_1()
        {
            var jsonReader = new UserSettingsObjectJsonReader();

            var userSettings = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_1);

            userSettings.Should().NotBeNull();

            userSettings.User.Should().BeNull();

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

        [Fact]
        public async Task Test_UserSettingsObjectJsonReader_ReadObject_From_Json_String_Incomplete_2()
        {
            var jsonReader = new UserSettingsObjectJsonReader();

            var userSettings = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_2);

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

            userSettings.Account.Should().BeNull();

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

        [Fact]
        public async Task Test_UserSettingsObjectJsonReader_ReadObject_From_Json_String_Incomplete_3()
        {
            var jsonReader = new UserSettingsObjectJsonReader();

            var userSettings = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_3);

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

            userSettings.Connections.Should().BeNull();

            userSettings.SharingText.Should().NotBeNull();
            userSettings.SharingText.Watching.Should().Be("I'm watching [item]");
            userSettings.SharingText.Watched.Should().Be("I just watched [item]");
        }

        [Fact]
        public async Task Test_UserSettingsObjectJsonReader_ReadObject_From_Json_String_Incomplete_4()
        {
            var jsonReader = new UserSettingsObjectJsonReader();

            var userSettings = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_4);

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

            userSettings.SharingText.Should().BeNull();
        }

        [Fact]
        public async Task Test_UserSettingsObjectJsonReader_ReadObject_From_Json_String_Incomplete_5()
        {
            var jsonReader = new UserSettingsObjectJsonReader();

            var userSettings = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_5);

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

            userSettings.Account.Should().BeNull();
            userSettings.Connections.Should().BeNull();
            userSettings.SharingText.Should().BeNull();
        }

        [Fact]
        public async Task Test_UserSettingsObjectJsonReader_ReadObject_From_Json_String_Incomplete_6()
        {
            var jsonReader = new UserSettingsObjectJsonReader();

            var userSettings = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_6);

            userSettings.Should().NotBeNull();

            userSettings.User.Should().BeNull();

            userSettings.Account.Should().NotBeNull();
            userSettings.Account.TimeZoneId.Should().Be("America/Los_Angeles");
            userSettings.Account.Time24Hr.Should().BeTrue();
            userSettings.Account.CoverImage.Should().Be("https://walter.trakt.us/images/movies/000/001/545/fanarts/original/0abb604492.jpg?1406095042");
            userSettings.Account.Token.Should().Be("60fa34c4f5e7f093ecc5a2d16d691e24");

            userSettings.Connections.Should().BeNull();
            userSettings.SharingText.Should().BeNull();
        }

        [Fact]
        public async Task Test_UserSettingsObjectJsonReader_ReadObject_From_Json_String_Incomplete_7()
        {
            var jsonReader = new UserSettingsObjectJsonReader();

            var userSettings = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_7);

            userSettings.Should().NotBeNull();

            userSettings.User.Should().BeNull();
            userSettings.Account.Should().BeNull();

            userSettings.Connections.Should().NotBeNull();
            userSettings.Connections.Facebook.Should().BeTrue();
            userSettings.Connections.Twitter.Should().BeTrue();
            userSettings.Connections.Google.Should().BeTrue();
            userSettings.Connections.Tumblr.Should().BeTrue();
            userSettings.Connections.Medium.Should().BeTrue();
            userSettings.Connections.Slack.Should().BeTrue();

            userSettings.SharingText.Should().BeNull();
        }

        [Fact]
        public async Task Test_UserSettingsObjectJsonReader_ReadObject_From_Json_String_Incomplete_8()
        {
            var jsonReader = new UserSettingsObjectJsonReader();

            var userSettings = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_8);

            userSettings.Should().NotBeNull();

            userSettings.User.Should().BeNull();
            userSettings.Account.Should().BeNull();
            userSettings.Connections.Should().BeNull();

            userSettings.SharingText.Should().NotBeNull();
            userSettings.SharingText.Watching.Should().Be("I'm watching [item]");
            userSettings.SharingText.Watched.Should().Be("I just watched [item]");
        }

        [Fact]
        public async Task Test_UserSettingsObjectJsonReader_ReadObject_From_Json_String_Not_Valid_1()
        {
            var jsonReader = new UserSettingsObjectJsonReader();

            var userSettings = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_1);

            userSettings.Should().NotBeNull();

            userSettings.User.Should().BeNull();

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

        [Fact]
        public async Task Test_UserSettingsObjectJsonReader_ReadObject_From_Json_String_Not_Valid_2()
        {
            var jsonReader = new UserSettingsObjectJsonReader();

            var userSettings = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_2);

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

            userSettings.Account.Should().BeNull();

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

        [Fact]
        public async Task Test_UserSettingsObjectJsonReader_ReadObject_From_Json_String_Not_Valid_3()
        {
            var jsonReader = new UserSettingsObjectJsonReader();

            var userSettings = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_3);

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

            userSettings.Connections.Should().BeNull();

            userSettings.SharingText.Should().NotBeNull();
            userSettings.SharingText.Watching.Should().Be("I'm watching [item]");
            userSettings.SharingText.Watched.Should().Be("I just watched [item]");
        }

        [Fact]
        public async Task Test_UserSettingsObjectJsonReader_ReadObject_From_Json_String_Not_Valid_4()
        {
            var jsonReader = new UserSettingsObjectJsonReader();

            var userSettings = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_4);

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

            userSettings.SharingText.Should().BeNull();
        }

        [Fact]
        public async Task Test_UserSettingsObjectJsonReader_ReadObject_From_Json_String_Not_Valid_5()
        {
            var jsonReader = new UserSettingsObjectJsonReader();

            var userSettings = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_5);

            userSettings.Should().NotBeNull();
            userSettings.User.Should().BeNull();
            userSettings.Account.Should().BeNull();
            userSettings.Connections.Should().BeNull();
            userSettings.SharingText.Should().BeNull();
        }

        [Fact]
        public async Task Test_UserSettingsObjectJsonReader_ReadObject_From_Json_String_Null()
        {
            var jsonReader = new UserSettingsObjectJsonReader();

            var userSettings = await jsonReader.ReadObjectAsync(default(string));
            userSettings.Should().BeNull();
        }

        [Fact]
        public async Task Test_UserSettingsObjectJsonReader_ReadObject_From_Json_String_Empty()
        {
            var jsonReader = new UserSettingsObjectJsonReader();

            var userSettings = await jsonReader.ReadObjectAsync(string.Empty);
            userSettings.Should().BeNull();
        }
    }
}

namespace TraktNet.Objects.Tests.Get.Users.Json.Reader
{
    using FluentAssertions;
    using System;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Users.Json.Reader;
    using Xunit;

    [Category("Objects.Get.Users.JsonReader")]
    public partial class UserObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_UserObjectJsonReader_ReadObject_From_Json_String_Complete()
        {
            var jsonReader = new UserObjectJsonReader();

            var user = await jsonReader.ReadObjectAsync(JSON_COMPLETE);

            user.Should().NotBeNull();
            user.Username.Should().Be("sean");
            user.IsPrivate.Should().BeFalse();
            user.Name.Should().Be("Sean Rudford");
            user.IsVIP.Should().BeTrue();
            user.IsVIP_EP.Should().BeTrue();
            user.Ids.Should().NotBeNull();
            user.Ids.Slug.Should().Be("sean");
            user.JoinedAt.Should().HaveValue().And.Be(DateTime.Parse("2010-09-25T17:49:25.000Z").ToUniversalTime());
            user.Location.Should().Be("SF");
            user.About.Should().Be("I have all your cassette tapes.");
            user.Gender.Should().Be("male");
            user.Age.Should().Be(35);
            user.Images.Should().NotBeNull();
            user.Images.Avatar.Should().NotBeNull();
            user.Images.Avatar.Full.Should().Be("https://walter-dev.trakt.tv/images/users/000/000/001/avatars/large/0ba3f72910.jpg");
        }

        [Fact]
        public async Task Test_UserObjectJsonReader_ReadObject_From_Json_String_Incomplete_1()
        {
            var jsonReader = new UserObjectJsonReader();

            var user = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_1);

            user.Should().NotBeNull();
            user.Username.Should().BeNull();
            user.IsPrivate.Should().BeFalse();
            user.Name.Should().Be("Sean Rudford");
            user.IsVIP.Should().BeTrue();
            user.IsVIP_EP.Should().BeTrue();
            user.Ids.Should().NotBeNull();
            user.Ids.Slug.Should().Be("sean");
            user.JoinedAt.Should().HaveValue().And.Be(DateTime.Parse("2010-09-25T17:49:25.000Z").ToUniversalTime());
            user.Location.Should().Be("SF");
            user.About.Should().Be("I have all your cassette tapes.");
            user.Gender.Should().Be("male");
            user.Age.Should().Be(35);
            user.Images.Should().NotBeNull();
            user.Images.Avatar.Should().NotBeNull();
            user.Images.Avatar.Full.Should().Be("https://walter-dev.trakt.tv/images/users/000/000/001/avatars/large/0ba3f72910.jpg");
        }

        [Fact]
        public async Task Test_UserObjectJsonReader_ReadObject_From_Json_String_Incomplete_2()
        {
            var jsonReader = new UserObjectJsonReader();

            var user = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_2);

            user.Should().NotBeNull();
            user.Username.Should().Be("sean");
            user.IsPrivate.Should().BeNull();
            user.Name.Should().Be("Sean Rudford");
            user.IsVIP.Should().BeTrue();
            user.IsVIP_EP.Should().BeTrue();
            user.Ids.Should().NotBeNull();
            user.Ids.Slug.Should().Be("sean");
            user.JoinedAt.Should().HaveValue().And.Be(DateTime.Parse("2010-09-25T17:49:25.000Z").ToUniversalTime());
            user.Location.Should().Be("SF");
            user.About.Should().Be("I have all your cassette tapes.");
            user.Gender.Should().Be("male");
            user.Age.Should().Be(35);
            user.Images.Should().NotBeNull();
            user.Images.Avatar.Should().NotBeNull();
            user.Images.Avatar.Full.Should().Be("https://walter-dev.trakt.tv/images/users/000/000/001/avatars/large/0ba3f72910.jpg");
        }

        [Fact]
        public async Task Test_UserObjectJsonReader_ReadObject_From_Json_String_Incomplete_3()
        {
            var jsonReader = new UserObjectJsonReader();

            var user = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_3);

            user.Should().NotBeNull();
            user.Username.Should().Be("sean");
            user.IsPrivate.Should().BeFalse();
            user.Name.Should().BeNull();
            user.IsVIP.Should().BeTrue();
            user.IsVIP_EP.Should().BeTrue();
            user.Ids.Should().NotBeNull();
            user.Ids.Slug.Should().Be("sean");
            user.JoinedAt.Should().HaveValue().And.Be(DateTime.Parse("2010-09-25T17:49:25.000Z").ToUniversalTime());
            user.Location.Should().Be("SF");
            user.About.Should().Be("I have all your cassette tapes.");
            user.Gender.Should().Be("male");
            user.Age.Should().Be(35);
            user.Images.Should().NotBeNull();
            user.Images.Avatar.Should().NotBeNull();
            user.Images.Avatar.Full.Should().Be("https://walter-dev.trakt.tv/images/users/000/000/001/avatars/large/0ba3f72910.jpg");
        }

        [Fact]
        public async Task Test_UserObjectJsonReader_ReadObject_From_Json_String_Incomplete_4()
        {
            var jsonReader = new UserObjectJsonReader();

            var user = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_4);

            user.Should().NotBeNull();
            user.Username.Should().Be("sean");
            user.IsPrivate.Should().BeFalse();
            user.Name.Should().Be("Sean Rudford");
            user.IsVIP.Should().BeNull();
            user.IsVIP_EP.Should().BeTrue();
            user.Ids.Should().NotBeNull();
            user.Ids.Slug.Should().Be("sean");
            user.JoinedAt.Should().HaveValue().And.Be(DateTime.Parse("2010-09-25T17:49:25.000Z").ToUniversalTime());
            user.Location.Should().Be("SF");
            user.About.Should().Be("I have all your cassette tapes.");
            user.Gender.Should().Be("male");
            user.Age.Should().Be(35);
            user.Images.Should().NotBeNull();
            user.Images.Avatar.Should().NotBeNull();
            user.Images.Avatar.Full.Should().Be("https://walter-dev.trakt.tv/images/users/000/000/001/avatars/large/0ba3f72910.jpg");
        }

        [Fact]
        public async Task Test_UserObjectJsonReader_ReadObject_From_Json_String_Incomplete_5()
        {
            var jsonReader = new UserObjectJsonReader();

            var user = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_5);

            user.Should().NotBeNull();
            user.Username.Should().Be("sean");
            user.IsPrivate.Should().BeFalse();
            user.Name.Should().Be("Sean Rudford");
            user.IsVIP.Should().BeTrue();
            user.IsVIP_EP.Should().BeNull();
            user.Ids.Should().NotBeNull();
            user.Ids.Slug.Should().Be("sean");
            user.JoinedAt.Should().HaveValue().And.Be(DateTime.Parse("2010-09-25T17:49:25.000Z").ToUniversalTime());
            user.Location.Should().Be("SF");
            user.About.Should().Be("I have all your cassette tapes.");
            user.Gender.Should().Be("male");
            user.Age.Should().Be(35);
            user.Images.Should().NotBeNull();
            user.Images.Avatar.Should().NotBeNull();
            user.Images.Avatar.Full.Should().Be("https://walter-dev.trakt.tv/images/users/000/000/001/avatars/large/0ba3f72910.jpg");
        }

        [Fact]
        public async Task Test_UserObjectJsonReader_ReadObject_From_Json_String_Incomplete_6()
        {
            var jsonReader = new UserObjectJsonReader();

            var user = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_6);

            user.Should().NotBeNull();
            user.Username.Should().Be("sean");
            user.IsPrivate.Should().BeFalse();
            user.Name.Should().Be("Sean Rudford");
            user.IsVIP.Should().BeTrue();
            user.IsVIP_EP.Should().BeTrue();
            user.Ids.Should().BeNull();
            user.JoinedAt.Should().HaveValue().And.Be(DateTime.Parse("2010-09-25T17:49:25.000Z").ToUniversalTime());
            user.Location.Should().Be("SF");
            user.About.Should().Be("I have all your cassette tapes.");
            user.Gender.Should().Be("male");
            user.Age.Should().Be(35);
            user.Images.Should().NotBeNull();
            user.Images.Avatar.Should().NotBeNull();
            user.Images.Avatar.Full.Should().Be("https://walter-dev.trakt.tv/images/users/000/000/001/avatars/large/0ba3f72910.jpg");
        }

        [Fact]
        public async Task Test_UserObjectJsonReader_ReadObject_From_Json_String_Incomplete_7()
        {
            var jsonReader = new UserObjectJsonReader();

            var user = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_7);

            user.Should().NotBeNull();
            user.Username.Should().Be("sean");
            user.IsPrivate.Should().BeFalse();
            user.Name.Should().Be("Sean Rudford");
            user.IsVIP.Should().BeTrue();
            user.IsVIP_EP.Should().BeTrue();
            user.Ids.Should().NotBeNull();
            user.Ids.Slug.Should().Be("sean");
            user.JoinedAt.Should().BeNull();
            user.Location.Should().Be("SF");
            user.About.Should().Be("I have all your cassette tapes.");
            user.Gender.Should().Be("male");
            user.Age.Should().Be(35);
            user.Images.Should().NotBeNull();
            user.Images.Avatar.Should().NotBeNull();
            user.Images.Avatar.Full.Should().Be("https://walter-dev.trakt.tv/images/users/000/000/001/avatars/large/0ba3f72910.jpg");
        }

        [Fact]
        public async Task Test_UserObjectJsonReader_ReadObject_From_Json_String_Incomplete_8()
        {
            var jsonReader = new UserObjectJsonReader();

            var user = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_8);

            user.Should().NotBeNull();
            user.Username.Should().Be("sean");
            user.IsPrivate.Should().BeFalse();
            user.Name.Should().Be("Sean Rudford");
            user.IsVIP.Should().BeTrue();
            user.IsVIP_EP.Should().BeTrue();
            user.Ids.Should().NotBeNull();
            user.Ids.Slug.Should().Be("sean");
            user.JoinedAt.Should().HaveValue().And.Be(DateTime.Parse("2010-09-25T17:49:25.000Z").ToUniversalTime());
            user.Location.Should().BeNull();
            user.About.Should().Be("I have all your cassette tapes.");
            user.Gender.Should().Be("male");
            user.Age.Should().Be(35);
            user.Images.Should().NotBeNull();
            user.Images.Avatar.Should().NotBeNull();
            user.Images.Avatar.Full.Should().Be("https://walter-dev.trakt.tv/images/users/000/000/001/avatars/large/0ba3f72910.jpg");
        }

        [Fact]
        public async Task Test_UserObjectJsonReader_ReadObject_From_Json_String_Incomplete_9()
        {
            var jsonReader = new UserObjectJsonReader();

            var user = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_9);

            user.Should().NotBeNull();
            user.Username.Should().Be("sean");
            user.IsPrivate.Should().BeFalse();
            user.Name.Should().Be("Sean Rudford");
            user.IsVIP.Should().BeTrue();
            user.IsVIP_EP.Should().BeTrue();
            user.Ids.Should().NotBeNull();
            user.Ids.Slug.Should().Be("sean");
            user.JoinedAt.Should().HaveValue().And.Be(DateTime.Parse("2010-09-25T17:49:25.000Z").ToUniversalTime());
            user.Location.Should().Be("SF");
            user.About.Should().BeNull();
            user.Gender.Should().Be("male");
            user.Age.Should().Be(35);
            user.Images.Should().NotBeNull();
            user.Images.Avatar.Should().NotBeNull();
            user.Images.Avatar.Full.Should().Be("https://walter-dev.trakt.tv/images/users/000/000/001/avatars/large/0ba3f72910.jpg");
        }

        [Fact]
        public async Task Test_UserObjectJsonReader_ReadObject_From_Json_String_Incomplete_10()
        {
            var jsonReader = new UserObjectJsonReader();

            var user = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_10);

            user.Should().NotBeNull();
            user.Username.Should().Be("sean");
            user.IsPrivate.Should().BeFalse();
            user.Name.Should().Be("Sean Rudford");
            user.IsVIP.Should().BeTrue();
            user.IsVIP_EP.Should().BeTrue();
            user.Ids.Should().NotBeNull();
            user.Ids.Slug.Should().Be("sean");
            user.JoinedAt.Should().HaveValue().And.Be(DateTime.Parse("2010-09-25T17:49:25.000Z").ToUniversalTime());
            user.Location.Should().Be("SF");
            user.About.Should().Be("I have all your cassette tapes.");
            user.Gender.Should().BeNull();
            user.Age.Should().Be(35);
            user.Images.Should().NotBeNull();
            user.Images.Avatar.Should().NotBeNull();
            user.Images.Avatar.Full.Should().Be("https://walter-dev.trakt.tv/images/users/000/000/001/avatars/large/0ba3f72910.jpg");
        }

        [Fact]
        public async Task Test_UserObjectJsonReader_ReadObject_From_Json_String_Incomplete_11()
        {
            var jsonReader = new UserObjectJsonReader();

            var user = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_11);

            user.Should().NotBeNull();
            user.Username.Should().Be("sean");
            user.IsPrivate.Should().BeFalse();
            user.Name.Should().Be("Sean Rudford");
            user.IsVIP.Should().BeTrue();
            user.IsVIP_EP.Should().BeTrue();
            user.Ids.Should().NotBeNull();
            user.Ids.Slug.Should().Be("sean");
            user.JoinedAt.Should().HaveValue().And.Be(DateTime.Parse("2010-09-25T17:49:25.000Z").ToUniversalTime());
            user.Location.Should().Be("SF");
            user.About.Should().Be("I have all your cassette tapes.");
            user.Gender.Should().Be("male");
            user.Age.Should().BeNull();
            user.Images.Should().NotBeNull();
            user.Images.Avatar.Should().NotBeNull();
            user.Images.Avatar.Full.Should().Be("https://walter-dev.trakt.tv/images/users/000/000/001/avatars/large/0ba3f72910.jpg");
        }

        [Fact]
        public async Task Test_UserObjectJsonReader_ReadObject_From_Json_String_Incomplete_12()
        {
            var jsonReader = new UserObjectJsonReader();

            var user = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_12);

            user.Should().NotBeNull();
            user.Username.Should().Be("sean");
            user.IsPrivate.Should().BeFalse();
            user.Name.Should().Be("Sean Rudford");
            user.IsVIP.Should().BeTrue();
            user.IsVIP_EP.Should().BeTrue();
            user.Ids.Should().NotBeNull();
            user.Ids.Slug.Should().Be("sean");
            user.JoinedAt.Should().HaveValue().And.Be(DateTime.Parse("2010-09-25T17:49:25.000Z").ToUniversalTime());
            user.Location.Should().Be("SF");
            user.About.Should().Be("I have all your cassette tapes.");
            user.Gender.Should().Be("male");
            user.Age.Should().Be(35);
            user.Images.Should().BeNull();
        }

        [Fact]
        public async Task Test_UserObjectJsonReader_ReadObject_From_Json_String_Incomplete_13()
        {
            var jsonReader = new UserObjectJsonReader();

            var user = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_13);

            user.Should().NotBeNull();
            user.Username.Should().Be("sean");
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
        }

        [Fact]
        public async Task Test_UserObjectJsonReader_ReadObject_From_Json_String_Incomplete_14()
        {
            var jsonReader = new UserObjectJsonReader();

            var user = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_14);

            user.Should().NotBeNull();
            user.Username.Should().BeNull();
            user.IsPrivate.Should().BeFalse();
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
        }

        [Fact]
        public async Task Test_UserObjectJsonReader_ReadObject_From_Json_String_Incomplete_15()
        {
            var jsonReader = new UserObjectJsonReader();

            var user = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_15);

            user.Should().NotBeNull();
            user.Username.Should().BeNull();
            user.IsPrivate.Should().BeNull();
            user.Name.Should().Be("Sean Rudford");
            user.IsVIP.Should().BeNull();
            user.IsVIP_EP.Should().BeNull();
            user.Ids.Should().BeNull();
            user.JoinedAt.Should().BeNull();
            user.Location.Should().BeNull();
            user.About.Should().BeNull();
            user.Gender.Should().BeNull();
            user.Age.Should().BeNull();
            user.Images.Should().BeNull();
        }

        [Fact]
        public async Task Test_UserObjectJsonReader_ReadObject_From_Json_String_Incomplete_16()
        {
            var jsonReader = new UserObjectJsonReader();

            var user = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_16);

            user.Should().NotBeNull();
            user.Username.Should().BeNull();
            user.IsPrivate.Should().BeNull();
            user.Name.Should().BeNull();
            user.IsVIP.Should().BeTrue();
            user.IsVIP_EP.Should().BeNull();
            user.Ids.Should().BeNull();
            user.JoinedAt.Should().BeNull();
            user.Location.Should().BeNull();
            user.About.Should().BeNull();
            user.Gender.Should().BeNull();
            user.Age.Should().BeNull();
            user.Images.Should().BeNull();
        }

        [Fact]
        public async Task Test_UserObjectJsonReader_ReadObject_From_Json_String_Incomplete_17()
        {
            var jsonReader = new UserObjectJsonReader();

            var user = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_17);

            user.Should().NotBeNull();
            user.Username.Should().BeNull();
            user.IsPrivate.Should().BeNull();
            user.Name.Should().BeNull();
            user.IsVIP.Should().BeNull();
            user.IsVIP_EP.Should().BeTrue();
            user.Ids.Should().BeNull();
            user.JoinedAt.Should().BeNull();
            user.Location.Should().BeNull();
            user.About.Should().BeNull();
            user.Gender.Should().BeNull();
            user.Age.Should().BeNull();
            user.Images.Should().BeNull();
        }

        [Fact]
        public async Task Test_UserObjectJsonReader_ReadObject_From_Json_String_Incomplete_18()
        {
            var jsonReader = new UserObjectJsonReader();

            var user = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_18);

            user.Should().NotBeNull();
            user.Username.Should().BeNull();
            user.IsPrivate.Should().BeNull();
            user.Name.Should().BeNull();
            user.IsVIP.Should().BeNull();
            user.IsVIP_EP.Should().BeNull();
            user.Ids.Should().NotBeNull();
            user.Ids.Slug.Should().Be("sean");
            user.JoinedAt.Should().BeNull();
            user.Location.Should().BeNull();
            user.About.Should().BeNull();
            user.Gender.Should().BeNull();
            user.Age.Should().BeNull();
            user.Images.Should().BeNull();
        }

        [Fact]
        public async Task Test_UserObjectJsonReader_ReadObject_From_Json_String_Incomplete_19()
        {
            var jsonReader = new UserObjectJsonReader();

            var user = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_19);

            user.Should().NotBeNull();
            user.Username.Should().BeNull();
            user.IsPrivate.Should().BeNull();
            user.Name.Should().BeNull();
            user.IsVIP.Should().BeNull();
            user.IsVIP_EP.Should().BeNull();
            user.Ids.Should().BeNull();
            user.JoinedAt.Should().HaveValue().And.Be(DateTime.Parse("2010-09-25T17:49:25.000Z").ToUniversalTime());
            user.Location.Should().BeNull();
            user.About.Should().BeNull();
            user.Gender.Should().BeNull();
            user.Age.Should().BeNull();
            user.Images.Should().BeNull();
        }

        [Fact]
        public async Task Test_UserObjectJsonReader_ReadObject_From_Json_String_Incomplete_20()
        {
            var jsonReader = new UserObjectJsonReader();

            var user = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_20);

            user.Should().NotBeNull();
            user.Username.Should().BeNull();
            user.IsPrivate.Should().BeNull();
            user.Name.Should().BeNull();
            user.IsVIP.Should().BeNull();
            user.IsVIP_EP.Should().BeNull();
            user.Ids.Should().BeNull();
            user.JoinedAt.Should().BeNull();
            user.Location.Should().Be("SF");
            user.About.Should().BeNull();
            user.Gender.Should().BeNull();
            user.Age.Should().BeNull();
            user.Images.Should().BeNull();
        }

        [Fact]
        public async Task Test_UserObjectJsonReader_ReadObject_From_Json_String_Incomplete_21()
        {
            var jsonReader = new UserObjectJsonReader();

            var user = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_21);

            user.Should().NotBeNull();
            user.Username.Should().BeNull();
            user.IsPrivate.Should().BeNull();
            user.Name.Should().BeNull();
            user.IsVIP.Should().BeNull();
            user.IsVIP_EP.Should().BeNull();
            user.Ids.Should().BeNull();
            user.JoinedAt.Should().BeNull();
            user.Location.Should().BeNull();
            user.About.Should().Be("I have all your cassette tapes.");
            user.Gender.Should().BeNull();
            user.Age.Should().BeNull();
            user.Images.Should().BeNull();
        }

        [Fact]
        public async Task Test_UserObjectJsonReader_ReadObject_From_Json_String_Incomplete_22()
        {
            var jsonReader = new UserObjectJsonReader();

            var user = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_22);

            user.Should().NotBeNull();
            user.Username.Should().BeNull();
            user.IsPrivate.Should().BeNull();
            user.Name.Should().BeNull();
            user.IsVIP.Should().BeNull();
            user.IsVIP_EP.Should().BeNull();
            user.Ids.Should().BeNull();
            user.JoinedAt.Should().BeNull();
            user.Location.Should().BeNull();
            user.About.Should().BeNull();
            user.Gender.Should().Be("male");
            user.Age.Should().BeNull();
            user.Images.Should().BeNull();
        }

        [Fact]
        public async Task Test_UserObjectJsonReader_ReadObject_From_Json_String_Incomplete_23()
        {
            var jsonReader = new UserObjectJsonReader();

            var user = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_23);

            user.Should().NotBeNull();
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
            user.Age.Should().Be(35);
            user.Images.Should().BeNull();
        }

        [Fact]
        public async Task Test_UserObjectJsonReader_ReadObject_From_Json_String_Incomplete_24()
        {
            var jsonReader = new UserObjectJsonReader();

            var user = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_24);

            user.Should().NotBeNull();
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
            user.Images.Should().NotBeNull();
            user.Images.Avatar.Should().NotBeNull();
            user.Images.Avatar.Full.Should().Be("https://walter-dev.trakt.tv/images/users/000/000/001/avatars/large/0ba3f72910.jpg");
        }

        [Fact]
        public async Task Test_UserObjectJsonReader_ReadObject_From_Json_String_Not_Valid_1()
        {
            var jsonReader = new UserObjectJsonReader();

            var user = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_1);

            user.Should().NotBeNull();
            user.Username.Should().BeNull();
            user.IsPrivate.Should().BeFalse();
            user.Name.Should().Be("Sean Rudford");
            user.IsVIP.Should().BeTrue();
            user.IsVIP_EP.Should().BeTrue();
            user.Ids.Should().NotBeNull();
            user.Ids.Slug.Should().Be("sean");
            user.JoinedAt.Should().HaveValue().And.Be(DateTime.Parse("2010-09-25T17:49:25.000Z").ToUniversalTime());
            user.Location.Should().Be("SF");
            user.About.Should().Be("I have all your cassette tapes.");
            user.Gender.Should().Be("male");
            user.Age.Should().Be(35);
            user.Images.Should().NotBeNull();
            user.Images.Avatar.Should().NotBeNull();
            user.Images.Avatar.Full.Should().Be("https://walter-dev.trakt.tv/images/users/000/000/001/avatars/large/0ba3f72910.jpg");
        }

        [Fact]
        public async Task Test_UserObjectJsonReader_ReadObject_From_Json_String_Not_Valid_2()
        {
            var jsonReader = new UserObjectJsonReader();

            var user = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_2);

            user.Should().NotBeNull();
            user.Username.Should().Be("sean");
            user.IsPrivate.Should().BeNull();
            user.Name.Should().Be("Sean Rudford");
            user.IsVIP.Should().BeTrue();
            user.IsVIP_EP.Should().BeTrue();
            user.Ids.Should().NotBeNull();
            user.Ids.Slug.Should().Be("sean");
            user.JoinedAt.Should().HaveValue().And.Be(DateTime.Parse("2010-09-25T17:49:25.000Z").ToUniversalTime());
            user.Location.Should().Be("SF");
            user.About.Should().Be("I have all your cassette tapes.");
            user.Gender.Should().Be("male");
            user.Age.Should().Be(35);
            user.Images.Should().NotBeNull();
            user.Images.Avatar.Should().NotBeNull();
            user.Images.Avatar.Full.Should().Be("https://walter-dev.trakt.tv/images/users/000/000/001/avatars/large/0ba3f72910.jpg");
        }

        [Fact]
        public async Task Test_UserObjectJsonReader_ReadObject_From_Json_String_Not_Valid_3()
        {
            var jsonReader = new UserObjectJsonReader();

            var user = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_3);

            user.Should().NotBeNull();
            user.Username.Should().Be("sean");
            user.IsPrivate.Should().BeFalse();
            user.Name.Should().BeNull();
            user.IsVIP.Should().BeTrue();
            user.IsVIP_EP.Should().BeTrue();
            user.Ids.Should().NotBeNull();
            user.Ids.Slug.Should().Be("sean");
            user.JoinedAt.Should().HaveValue().And.Be(DateTime.Parse("2010-09-25T17:49:25.000Z").ToUniversalTime());
            user.Location.Should().Be("SF");
            user.About.Should().Be("I have all your cassette tapes.");
            user.Gender.Should().Be("male");
            user.Age.Should().Be(35);
            user.Images.Should().NotBeNull();
            user.Images.Avatar.Should().NotBeNull();
            user.Images.Avatar.Full.Should().Be("https://walter-dev.trakt.tv/images/users/000/000/001/avatars/large/0ba3f72910.jpg");
        }

        [Fact]
        public async Task Test_UserObjectJsonReader_ReadObject_From_Json_String_Not_Valid_4()
        {
            var jsonReader = new UserObjectJsonReader();

            var user = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_4);

            user.Should().NotBeNull();
            user.Username.Should().Be("sean");
            user.IsPrivate.Should().BeFalse();
            user.Name.Should().Be("Sean Rudford");
            user.IsVIP.Should().BeNull();
            user.IsVIP_EP.Should().BeTrue();
            user.Ids.Should().NotBeNull();
            user.Ids.Slug.Should().Be("sean");
            user.JoinedAt.Should().HaveValue().And.Be(DateTime.Parse("2010-09-25T17:49:25.000Z").ToUniversalTime());
            user.Location.Should().Be("SF");
            user.About.Should().Be("I have all your cassette tapes.");
            user.Gender.Should().Be("male");
            user.Age.Should().Be(35);
            user.Images.Should().NotBeNull();
            user.Images.Avatar.Should().NotBeNull();
            user.Images.Avatar.Full.Should().Be("https://walter-dev.trakt.tv/images/users/000/000/001/avatars/large/0ba3f72910.jpg");
        }

        [Fact]
        public async Task Test_UserObjectJsonReader_ReadObject_From_Json_String_Not_Valid_5()
        {
            var jsonReader = new UserObjectJsonReader();

            var user = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_5);

            user.Should().NotBeNull();
            user.Username.Should().Be("sean");
            user.IsPrivate.Should().BeFalse();
            user.Name.Should().Be("Sean Rudford");
            user.IsVIP.Should().BeTrue();
            user.IsVIP_EP.Should().BeNull();
            user.Ids.Should().NotBeNull();
            user.Ids.Slug.Should().Be("sean");
            user.JoinedAt.Should().HaveValue().And.Be(DateTime.Parse("2010-09-25T17:49:25.000Z").ToUniversalTime());
            user.Location.Should().Be("SF");
            user.About.Should().Be("I have all your cassette tapes.");
            user.Gender.Should().Be("male");
            user.Age.Should().Be(35);
            user.Images.Should().NotBeNull();
            user.Images.Avatar.Should().NotBeNull();
            user.Images.Avatar.Full.Should().Be("https://walter-dev.trakt.tv/images/users/000/000/001/avatars/large/0ba3f72910.jpg");
        }

        [Fact]
        public async Task Test_UserObjectJsonReader_ReadObject_From_Json_String_Not_Valid_6()
        {
            var jsonReader = new UserObjectJsonReader();

            var user = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_6);

            user.Should().NotBeNull();
            user.Username.Should().Be("sean");
            user.IsPrivate.Should().BeFalse();
            user.Name.Should().Be("Sean Rudford");
            user.IsVIP.Should().BeTrue();
            user.IsVIP_EP.Should().BeTrue();
            user.Ids.Should().BeNull();
            user.JoinedAt.Should().HaveValue().And.Be(DateTime.Parse("2010-09-25T17:49:25.000Z").ToUniversalTime());
            user.Location.Should().Be("SF");
            user.About.Should().Be("I have all your cassette tapes.");
            user.Gender.Should().Be("male");
            user.Age.Should().Be(35);
            user.Images.Should().NotBeNull();
            user.Images.Avatar.Should().NotBeNull();
            user.Images.Avatar.Full.Should().Be("https://walter-dev.trakt.tv/images/users/000/000/001/avatars/large/0ba3f72910.jpg");
        }

        [Fact]
        public async Task Test_UserObjectJsonReader_ReadObject_From_Json_String_Not_Valid_7()
        {
            var jsonReader = new UserObjectJsonReader();

            var user = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_7);

            user.Should().NotBeNull();
            user.Username.Should().Be("sean");
            user.IsPrivate.Should().BeFalse();
            user.Name.Should().Be("Sean Rudford");
            user.IsVIP.Should().BeTrue();
            user.IsVIP_EP.Should().BeTrue();
            user.Ids.Should().NotBeNull();
            user.Ids.Slug.Should().Be("sean");
            user.JoinedAt.Should().BeNull();
            user.Location.Should().Be("SF");
            user.About.Should().Be("I have all your cassette tapes.");
            user.Gender.Should().Be("male");
            user.Age.Should().Be(35);
            user.Images.Should().NotBeNull();
            user.Images.Avatar.Should().NotBeNull();
            user.Images.Avatar.Full.Should().Be("https://walter-dev.trakt.tv/images/users/000/000/001/avatars/large/0ba3f72910.jpg");
        }

        [Fact]
        public async Task Test_UserObjectJsonReader_ReadObject_From_Json_String_Not_Valid_8()
        {
            var jsonReader = new UserObjectJsonReader();

            var user = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_8);

            user.Should().NotBeNull();
            user.Username.Should().Be("sean");
            user.IsPrivate.Should().BeFalse();
            user.Name.Should().Be("Sean Rudford");
            user.IsVIP.Should().BeTrue();
            user.IsVIP_EP.Should().BeTrue();
            user.Ids.Should().NotBeNull();
            user.Ids.Slug.Should().Be("sean");
            user.JoinedAt.Should().HaveValue().And.Be(DateTime.Parse("2010-09-25T17:49:25.000Z").ToUniversalTime());
            user.Location.Should().BeNull();
            user.About.Should().Be("I have all your cassette tapes.");
            user.Gender.Should().Be("male");
            user.Age.Should().Be(35);
            user.Images.Should().NotBeNull();
            user.Images.Avatar.Should().NotBeNull();
            user.Images.Avatar.Full.Should().Be("https://walter-dev.trakt.tv/images/users/000/000/001/avatars/large/0ba3f72910.jpg");
        }

        [Fact]
        public async Task Test_UserObjectJsonReader_ReadObject_From_Json_String_Not_Valid_9()
        {
            var jsonReader = new UserObjectJsonReader();

            var user = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_9);

            user.Should().NotBeNull();
            user.Username.Should().Be("sean");
            user.IsPrivate.Should().BeFalse();
            user.Name.Should().Be("Sean Rudford");
            user.IsVIP.Should().BeTrue();
            user.IsVIP_EP.Should().BeTrue();
            user.Ids.Should().NotBeNull();
            user.Ids.Slug.Should().Be("sean");
            user.JoinedAt.Should().HaveValue().And.Be(DateTime.Parse("2010-09-25T17:49:25.000Z").ToUniversalTime());
            user.Location.Should().Be("SF");
            user.About.Should().BeNull();
            user.Gender.Should().Be("male");
            user.Age.Should().Be(35);
            user.Images.Should().NotBeNull();
            user.Images.Avatar.Should().NotBeNull();
            user.Images.Avatar.Full.Should().Be("https://walter-dev.trakt.tv/images/users/000/000/001/avatars/large/0ba3f72910.jpg");
        }

        [Fact]
        public async Task Test_UserObjectJsonReader_ReadObject_From_Json_String_Not_Valid_10()
        {
            var jsonReader = new UserObjectJsonReader();

            var user = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_10);

            user.Should().NotBeNull();
            user.Username.Should().Be("sean");
            user.IsPrivate.Should().BeFalse();
            user.Name.Should().Be("Sean Rudford");
            user.IsVIP.Should().BeTrue();
            user.IsVIP_EP.Should().BeTrue();
            user.Ids.Should().NotBeNull();
            user.Ids.Slug.Should().Be("sean");
            user.JoinedAt.Should().HaveValue().And.Be(DateTime.Parse("2010-09-25T17:49:25.000Z").ToUniversalTime());
            user.Location.Should().Be("SF");
            user.About.Should().Be("I have all your cassette tapes.");
            user.Gender.Should().BeNull();
            user.Age.Should().Be(35);
            user.Images.Should().NotBeNull();
            user.Images.Avatar.Should().NotBeNull();
            user.Images.Avatar.Full.Should().Be("https://walter-dev.trakt.tv/images/users/000/000/001/avatars/large/0ba3f72910.jpg");
        }

        [Fact]
        public async Task Test_UserObjectJsonReader_ReadObject_From_Json_String_Not_Valid_11()
        {
            var jsonReader = new UserObjectJsonReader();

            var user = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_11);

            user.Should().NotBeNull();
            user.Username.Should().Be("sean");
            user.IsPrivate.Should().BeFalse();
            user.Name.Should().Be("Sean Rudford");
            user.IsVIP.Should().BeTrue();
            user.IsVIP_EP.Should().BeTrue();
            user.Ids.Should().NotBeNull();
            user.Ids.Slug.Should().Be("sean");
            user.JoinedAt.Should().HaveValue().And.Be(DateTime.Parse("2010-09-25T17:49:25.000Z").ToUniversalTime());
            user.Location.Should().Be("SF");
            user.About.Should().Be("I have all your cassette tapes.");
            user.Gender.Should().Be("male");
            user.Age.Should().BeNull();
            user.Images.Should().NotBeNull();
            user.Images.Avatar.Should().NotBeNull();
            user.Images.Avatar.Full.Should().Be("https://walter-dev.trakt.tv/images/users/000/000/001/avatars/large/0ba3f72910.jpg");
        }

        [Fact]
        public async Task Test_UserObjectJsonReader_ReadObject_From_Json_String_Not_Valid_12()
        {
            var jsonReader = new UserObjectJsonReader();

            var user = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_12);

            user.Should().NotBeNull();
            user.Username.Should().Be("sean");
            user.IsPrivate.Should().BeFalse();
            user.Name.Should().Be("Sean Rudford");
            user.IsVIP.Should().BeTrue();
            user.IsVIP_EP.Should().BeTrue();
            user.Ids.Should().NotBeNull();
            user.Ids.Slug.Should().Be("sean");
            user.JoinedAt.Should().HaveValue().And.Be(DateTime.Parse("2010-09-25T17:49:25.000Z").ToUniversalTime());
            user.Location.Should().Be("SF");
            user.About.Should().Be("I have all your cassette tapes.");
            user.Gender.Should().Be("male");
            user.Age.Should().Be(35);
            user.Images.Should().BeNull();
        }

        [Fact]
        public async Task Test_UserObjectJsonReader_ReadObject_From_Json_String_Not_Valid_13()
        {
            var jsonReader = new UserObjectJsonReader();

            var user = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_13);

            user.Should().NotBeNull();
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
        }

        [Fact]
        public async Task Test_UserObjectJsonReader_ReadObject_From_Json_String_Null()
        {
            var jsonReader = new UserObjectJsonReader();

            var user = await jsonReader.ReadObjectAsync(default(string));
            user.Should().BeNull();
        }

        [Fact]
        public async Task Test_UserObjectJsonReader_ReadObject_From_Json_String_Empty()
        {
            var jsonReader = new UserObjectJsonReader();

            var user = await jsonReader.ReadObjectAsync(string.Empty);
            user.Should().BeNull();
        }
    }
}

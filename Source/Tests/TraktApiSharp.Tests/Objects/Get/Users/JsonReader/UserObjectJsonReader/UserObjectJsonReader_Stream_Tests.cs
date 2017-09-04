namespace TraktApiSharp.Tests.Objects.Get.Users.JsonReader
{
    using FluentAssertions;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using TestUtils;
    using Traits;
    using TraktApiSharp.Objects.Get.Users.JsonReader;
    using Xunit;

    [Category("Objects.Get.Users.JsonReader")]
    public partial class UserObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_UserObjectJsonReader_ReadObject_From_Stream_Complete()
        {
            var jsonReader = new UserObjectJsonReader();

            using (var stream = JSON_COMPLETE.ToStream())
            {
                var user = await jsonReader.ReadObjectAsync(stream);

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
        }

        [Fact]
        public async Task Test_UserObjectJsonReader_ReadObject_From_Stream_Incomplete_1()
        {
            var jsonReader = new UserObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_1.ToStream())
            {
                var user = await jsonReader.ReadObjectAsync(stream);

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
        }

        [Fact]
        public async Task Test_UserObjectJsonReader_ReadObject_From_Stream_Incomplete_2()
        {
            var jsonReader = new UserObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_2.ToStream())
            {
                var user = await jsonReader.ReadObjectAsync(stream);

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
        }

        [Fact]
        public async Task Test_UserObjectJsonReader_ReadObject_From_Stream_Incomplete_3()
        {
            var jsonReader = new UserObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_3.ToStream())
            {
                var user = await jsonReader.ReadObjectAsync(stream);

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
        }

        [Fact]
        public async Task Test_UserObjectJsonReader_ReadObject_From_Stream_Incomplete_4()
        {
            var jsonReader = new UserObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_4.ToStream())
            {
                var user = await jsonReader.ReadObjectAsync(stream);

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
        }

        [Fact]
        public async Task Test_UserObjectJsonReader_ReadObject_From_Stream_Incomplete_5()
        {
            var jsonReader = new UserObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_5.ToStream())
            {
                var user = await jsonReader.ReadObjectAsync(stream);

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
        }

        [Fact]
        public async Task Test_UserObjectJsonReader_ReadObject_From_Stream_Incomplete_6()
        {
            var jsonReader = new UserObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_6.ToStream())
            {
                var user = await jsonReader.ReadObjectAsync(stream);

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
        }

        [Fact]
        public async Task Test_UserObjectJsonReader_ReadObject_From_Stream_Incomplete_7()
        {
            var jsonReader = new UserObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_7.ToStream())
            {
                var user = await jsonReader.ReadObjectAsync(stream);

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
        }

        [Fact]
        public async Task Test_UserObjectJsonReader_ReadObject_From_Stream_Incomplete_8()
        {
            var jsonReader = new UserObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_8.ToStream())
            {
                var user = await jsonReader.ReadObjectAsync(stream);

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
        }

        [Fact]
        public async Task Test_UserObjectJsonReader_ReadObject_From_Stream_Incomplete_9()
        {
            var jsonReader = new UserObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_9.ToStream())
            {
                var user = await jsonReader.ReadObjectAsync(stream);

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
        }

        [Fact]
        public async Task Test_UserObjectJsonReader_ReadObject_From_Stream_Incomplete_10()
        {
            var jsonReader = new UserObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_10.ToStream())
            {
                var user = await jsonReader.ReadObjectAsync(stream);

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
        }

        [Fact]
        public async Task Test_UserObjectJsonReader_ReadObject_From_Stream_Incomplete_11()
        {
            var jsonReader = new UserObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_11.ToStream())
            {
                var user = await jsonReader.ReadObjectAsync(stream);

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
        }

        [Fact]
        public async Task Test_UserObjectJsonReader_ReadObject_From_Stream_Incomplete_12()
        {
            var jsonReader = new UserObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_12.ToStream())
            {
                var user = await jsonReader.ReadObjectAsync(stream);

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
        }

        [Fact]
        public async Task Test_UserObjectJsonReader_ReadObject_From_Stream_Incomplete_13()
        {
            var jsonReader = new UserObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_13.ToStream())
            {
                var user = await jsonReader.ReadObjectAsync(stream);

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
        }

        [Fact]
        public async Task Test_UserObjectJsonReader_ReadObject_From_Stream_Incomplete_14()
        {
            var jsonReader = new UserObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_14.ToStream())
            {
                var user = await jsonReader.ReadObjectAsync(stream);

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
        }

        [Fact]
        public async Task Test_UserObjectJsonReader_ReadObject_From_Stream_Incomplete_15()
        {
            var jsonReader = new UserObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_15.ToStream())
            {
                var user = await jsonReader.ReadObjectAsync(stream);

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
        }

        [Fact]
        public async Task Test_UserObjectJsonReader_ReadObject_From_Stream_Incomplete_16()
        {
            var jsonReader = new UserObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_16.ToStream())
            {
                var user = await jsonReader.ReadObjectAsync(stream);

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
        }

        [Fact]
        public async Task Test_UserObjectJsonReader_ReadObject_From_Stream_Incomplete_17()
        {
            var jsonReader = new UserObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_17.ToStream())
            {
                var user = await jsonReader.ReadObjectAsync(stream);

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
        }

        [Fact]
        public async Task Test_UserObjectJsonReader_ReadObject_From_Stream_Incomplete_18()
        {
            var jsonReader = new UserObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_18.ToStream())
            {
                var user = await jsonReader.ReadObjectAsync(stream);

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
        }

        [Fact]
        public async Task Test_UserObjectJsonReader_ReadObject_From_Stream_Incomplete_19()
        {
            var jsonReader = new UserObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_19.ToStream())
            {
                var user = await jsonReader.ReadObjectAsync(stream);

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
        }

        [Fact]
        public async Task Test_UserObjectJsonReader_ReadObject_From_Stream_Incomplete_20()
        {
            var jsonReader = new UserObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_20.ToStream())
            {
                var user = await jsonReader.ReadObjectAsync(stream);

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
        }

        [Fact]
        public async Task Test_UserObjectJsonReader_ReadObject_From_Stream_Incomplete_21()
        {
            var jsonReader = new UserObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_21.ToStream())
            {
                var user = await jsonReader.ReadObjectAsync(stream);

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
        }

        [Fact]
        public async Task Test_UserObjectJsonReader_ReadObject_From_Stream_Incomplete_22()
        {
            var jsonReader = new UserObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_22.ToStream())
            {
                var user = await jsonReader.ReadObjectAsync(stream);

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
        }

        [Fact]
        public async Task Test_UserObjectJsonReader_ReadObject_From_Stream_Incomplete_23()
        {
            var jsonReader = new UserObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_23.ToStream())
            {
                var user = await jsonReader.ReadObjectAsync(stream);

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
        }

        [Fact]
        public async Task Test_UserObjectJsonReader_ReadObject_From_Stream_Incomplete_24()
        {
            var jsonReader = new UserObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_24.ToStream())
            {
                var user = await jsonReader.ReadObjectAsync(stream);

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
        }

        [Fact]
        public async Task Test_UserObjectJsonReader_ReadObject_From_Stream_Not_Valid_1()
        {
            var jsonReader = new UserObjectJsonReader();

            using (var stream = JSON_NOT_VALID_1.ToStream())
            {
                var user = await jsonReader.ReadObjectAsync(stream);

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
        }

        [Fact]
        public async Task Test_UserObjectJsonReader_ReadObject_From_Stream_Not_Valid_2()
        {
            var jsonReader = new UserObjectJsonReader();

            using (var stream = JSON_NOT_VALID_2.ToStream())
            {
                var user = await jsonReader.ReadObjectAsync(stream);

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
        }

        [Fact]
        public async Task Test_UserObjectJsonReader_ReadObject_From_Stream_Not_Valid_3()
        {
            var jsonReader = new UserObjectJsonReader();

            using (var stream = JSON_NOT_VALID_3.ToStream())
            {
                var user = await jsonReader.ReadObjectAsync(stream);

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
        }

        [Fact]
        public async Task Test_UserObjectJsonReader_ReadObject_From_Stream_Not_Valid_4()
        {
            var jsonReader = new UserObjectJsonReader();

            using (var stream = JSON_NOT_VALID_4.ToStream())
            {
                var user = await jsonReader.ReadObjectAsync(stream);

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
        }

        [Fact]
        public async Task Test_UserObjectJsonReader_ReadObject_From_Stream_Not_Valid_5()
        {
            var jsonReader = new UserObjectJsonReader();

            using (var stream = JSON_NOT_VALID_5.ToStream())
            {
                var user = await jsonReader.ReadObjectAsync(stream);

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
        }

        [Fact]
        public async Task Test_UserObjectJsonReader_ReadObject_From_Stream_Not_Valid_6()
        {
            var jsonReader = new UserObjectJsonReader();

            using (var stream = JSON_NOT_VALID_6.ToStream())
            {
                var user = await jsonReader.ReadObjectAsync(stream);

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
        }

        [Fact]
        public async Task Test_UserObjectJsonReader_ReadObject_From_Stream_Not_Valid_7()
        {
            var jsonReader = new UserObjectJsonReader();

            using (var stream = JSON_NOT_VALID_7.ToStream())
            {
                var user = await jsonReader.ReadObjectAsync(stream);

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
        }

        [Fact]
        public async Task Test_UserObjectJsonReader_ReadObject_From_Stream_Not_Valid_8()
        {
            var jsonReader = new UserObjectJsonReader();

            using (var stream = JSON_NOT_VALID_8.ToStream())
            {
                var user = await jsonReader.ReadObjectAsync(stream);

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
        }

        [Fact]
        public async Task Test_UserObjectJsonReader_ReadObject_From_Stream_Not_Valid_9()
        {
            var jsonReader = new UserObjectJsonReader();

            using (var stream = JSON_NOT_VALID_9.ToStream())
            {
                var user = await jsonReader.ReadObjectAsync(stream);

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
        }

        [Fact]
        public async Task Test_UserObjectJsonReader_ReadObject_From_Stream_Not_Valid_10()
        {
            var jsonReader = new UserObjectJsonReader();

            using (var stream = JSON_NOT_VALID_10.ToStream())
            {
                var user = await jsonReader.ReadObjectAsync(stream);

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
        }

        [Fact]
        public async Task Test_UserObjectJsonReader_ReadObject_From_Stream_Not_Valid_11()
        {
            var jsonReader = new UserObjectJsonReader();

            using (var stream = JSON_NOT_VALID_11.ToStream())
            {
                var user = await jsonReader.ReadObjectAsync(stream);

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
        }

        [Fact]
        public async Task Test_UserObjectJsonReader_ReadObject_From_Stream_Not_Valid_12()
        {
            var jsonReader = new UserObjectJsonReader();

            using (var stream = JSON_NOT_VALID_12.ToStream())
            {
                var user = await jsonReader.ReadObjectAsync(stream);

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
        }

        [Fact]
        public async Task Test_UserObjectJsonReader_ReadObject_From_Stream_Not_Valid_13()
        {
            var jsonReader = new UserObjectJsonReader();

            using (var stream = JSON_NOT_VALID_13.ToStream())
            {
                var user = await jsonReader.ReadObjectAsync(stream);

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
        }

        [Fact]
        public async Task Test_UserObjectJsonReader_ReadObject_From_Stream_Null()
        {
            var jsonReader = new UserObjectJsonReader();

            var user = await jsonReader.ReadObjectAsync(default(Stream));
            user.Should().BeNull();
        }

        [Fact]
        public async Task Test_UserObjectJsonReader_ReadObject_From_Stream_Empty()
        {
            var jsonReader = new UserObjectJsonReader();

            using (var stream = string.Empty.ToStream())
            {
                var user = await jsonReader.ReadObjectAsync(stream);
                user.Should().BeNull();
            }
        }
    }
}

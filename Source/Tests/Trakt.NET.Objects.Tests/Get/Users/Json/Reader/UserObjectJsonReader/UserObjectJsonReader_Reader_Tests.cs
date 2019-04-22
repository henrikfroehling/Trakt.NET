namespace TraktNet.Objects.Tests.Get.Users.Json.Reader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Users.Json.Reader;
    using Xunit;

    [Category("Objects.Get.Users.JsonReader")]
    public partial class UserObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_UserObjectJsonReader_ReadObject_From_JsonReader_Complete()
        {
            var traktJsonReader = new UserObjectJsonReader();

            using (var reader = new StringReader(JSON_COMPLETE))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var user = await traktJsonReader.ReadObjectAsync(jsonReader);

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
        public async Task Test_UserObjectJsonReader_ReadObject_From_JsonReader_Incomplete_1()
        {
            var traktJsonReader = new UserObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var user = await traktJsonReader.ReadObjectAsync(jsonReader);

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
        public async Task Test_UserObjectJsonReader_ReadObject_From_JsonReader_Incomplete_2()
        {
            var traktJsonReader = new UserObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var user = await traktJsonReader.ReadObjectAsync(jsonReader);

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
        public async Task Test_UserObjectJsonReader_ReadObject_From_JsonReader_Incomplete_3()
        {
            var traktJsonReader = new UserObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var user = await traktJsonReader.ReadObjectAsync(jsonReader);

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
        public async Task Test_UserObjectJsonReader_ReadObject_From_JsonReader_Incomplete_4()
        {
            var traktJsonReader = new UserObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var user = await traktJsonReader.ReadObjectAsync(jsonReader);

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
        public async Task Test_UserObjectJsonReader_ReadObject_From_JsonReader_Incomplete_5()
        {
            var traktJsonReader = new UserObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_5))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var user = await traktJsonReader.ReadObjectAsync(jsonReader);

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
        public async Task Test_UserObjectJsonReader_ReadObject_From_JsonReader_Incomplete_6()
        {
            var traktJsonReader = new UserObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_6))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var user = await traktJsonReader.ReadObjectAsync(jsonReader);

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
        public async Task Test_UserObjectJsonReader_ReadObject_From_JsonReader_Incomplete_7()
        {
            var traktJsonReader = new UserObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_7))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var user = await traktJsonReader.ReadObjectAsync(jsonReader);

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
        public async Task Test_UserObjectJsonReader_ReadObject_From_JsonReader_Incomplete_8()
        {
            var traktJsonReader = new UserObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_8))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var user = await traktJsonReader.ReadObjectAsync(jsonReader);

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
        public async Task Test_UserObjectJsonReader_ReadObject_From_JsonReader_Incomplete_9()
        {
            var traktJsonReader = new UserObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_9))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var user = await traktJsonReader.ReadObjectAsync(jsonReader);

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
        public async Task Test_UserObjectJsonReader_ReadObject_From_JsonReader_Incomplete_10()
        {
            var traktJsonReader = new UserObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_10))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var user = await traktJsonReader.ReadObjectAsync(jsonReader);

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
        public async Task Test_UserObjectJsonReader_ReadObject_From_JsonReader_Incomplete_11()
        {
            var traktJsonReader = new UserObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_11))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var user = await traktJsonReader.ReadObjectAsync(jsonReader);

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
        public async Task Test_UserObjectJsonReader_ReadObject_From_JsonReader_Incomplete_12()
        {
            var traktJsonReader = new UserObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_12))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var user = await traktJsonReader.ReadObjectAsync(jsonReader);

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
        public async Task Test_UserObjectJsonReader_ReadObject_From_JsonReader_Incomplete_13()
        {
            var traktJsonReader = new UserObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_13))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var user = await traktJsonReader.ReadObjectAsync(jsonReader);

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
        public async Task Test_UserObjectJsonReader_ReadObject_From_JsonReader_Incomplete_14()
        {
            var traktJsonReader = new UserObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_14))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var user = await traktJsonReader.ReadObjectAsync(jsonReader);

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
        public async Task Test_UserObjectJsonReader_ReadObject_From_JsonReader_Incomplete_15()
        {
            var traktJsonReader = new UserObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_15))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var user = await traktJsonReader.ReadObjectAsync(jsonReader);

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
        public async Task Test_UserObjectJsonReader_ReadObject_From_JsonReader_Incomplete_16()
        {
            var traktJsonReader = new UserObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_16))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var user = await traktJsonReader.ReadObjectAsync(jsonReader);

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
        public async Task Test_UserObjectJsonReader_ReadObject_From_JsonReader_Incomplete_17()
        {
            var traktJsonReader = new UserObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_17))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var user = await traktJsonReader.ReadObjectAsync(jsonReader);

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
        public async Task Test_UserObjectJsonReader_ReadObject_From_JsonReader_Incomplete_18()
        {
            var traktJsonReader = new UserObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_18))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var user = await traktJsonReader.ReadObjectAsync(jsonReader);

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
        public async Task Test_UserObjectJsonReader_ReadObject_From_JsonReader_Incomplete_19()
        {
            var traktJsonReader = new UserObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_19))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var user = await traktJsonReader.ReadObjectAsync(jsonReader);

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
        public async Task Test_UserObjectJsonReader_ReadObject_From_JsonReader_Incomplete_20()
        {
            var traktJsonReader = new UserObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_20))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var user = await traktJsonReader.ReadObjectAsync(jsonReader);

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
        public async Task Test_UserObjectJsonReader_ReadObject_From_JsonReader_Incomplete_21()
        {
            var traktJsonReader = new UserObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_21))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var user = await traktJsonReader.ReadObjectAsync(jsonReader);

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
        public async Task Test_UserObjectJsonReader_ReadObject_From_JsonReader_Incomplete_22()
        {
            var traktJsonReader = new UserObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_22))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var user = await traktJsonReader.ReadObjectAsync(jsonReader);

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
        public async Task Test_UserObjectJsonReader_ReadObject_From_JsonReader_Incomplete_23()
        {
            var traktJsonReader = new UserObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_23))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var user = await traktJsonReader.ReadObjectAsync(jsonReader);

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
        public async Task Test_UserObjectJsonReader_ReadObject_From_JsonReader_Incomplete_24()
        {
            var traktJsonReader = new UserObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_24))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var user = await traktJsonReader.ReadObjectAsync(jsonReader);

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
        public async Task Test_UserObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_1()
        {
            var traktJsonReader = new UserObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var user = await traktJsonReader.ReadObjectAsync(jsonReader);

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
        public async Task Test_UserObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_2()
        {
            var traktJsonReader = new UserObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var user = await traktJsonReader.ReadObjectAsync(jsonReader);

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
        public async Task Test_UserObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_3()
        {
            var traktJsonReader = new UserObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var user = await traktJsonReader.ReadObjectAsync(jsonReader);

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
        public async Task Test_UserObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_4()
        {
            var traktJsonReader = new UserObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var user = await traktJsonReader.ReadObjectAsync(jsonReader);

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
        public async Task Test_UserObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_5()
        {
            var traktJsonReader = new UserObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_5))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var user = await traktJsonReader.ReadObjectAsync(jsonReader);

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
        public async Task Test_UserObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_6()
        {
            var traktJsonReader = new UserObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_6))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var user = await traktJsonReader.ReadObjectAsync(jsonReader);

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
        public async Task Test_UserObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_7()
        {
            var traktJsonReader = new UserObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_7))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var user = await traktJsonReader.ReadObjectAsync(jsonReader);

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
        public async Task Test_UserObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_8()
        {
            var traktJsonReader = new UserObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_8))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var user = await traktJsonReader.ReadObjectAsync(jsonReader);

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
        public async Task Test_UserObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_9()
        {
            var traktJsonReader = new UserObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_9))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var user = await traktJsonReader.ReadObjectAsync(jsonReader);

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
        public async Task Test_UserObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_10()
        {
            var traktJsonReader = new UserObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_10))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var user = await traktJsonReader.ReadObjectAsync(jsonReader);

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
        public async Task Test_UserObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_11()
        {
            var traktJsonReader = new UserObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_11))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var user = await traktJsonReader.ReadObjectAsync(jsonReader);

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
        public async Task Test_UserObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_12()
        {
            var traktJsonReader = new UserObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_12))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var user = await traktJsonReader.ReadObjectAsync(jsonReader);

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
        public async Task Test_UserObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_13()
        {
            var traktJsonReader = new UserObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_13))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var user = await traktJsonReader.ReadObjectAsync(jsonReader);

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
        public async Task Test_UserObjectJsonReader_ReadObject_From_JsonReader_Null()
        {
            var traktJsonReader = new UserObjectJsonReader();

            var user = await traktJsonReader.ReadObjectAsync(default(JsonTextReader));
            user.Should().BeNull();
        }

        [Fact]
        public async Task Test_UserObjectJsonReader_ReadObject_From_JsonReader_Empty()
        {
            var traktJsonReader = new UserObjectJsonReader();

            using (var reader = new StringReader(string.Empty))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var user = await traktJsonReader.ReadObjectAsync(jsonReader);
                user.Should().BeNull();
            }
        }
    }
}

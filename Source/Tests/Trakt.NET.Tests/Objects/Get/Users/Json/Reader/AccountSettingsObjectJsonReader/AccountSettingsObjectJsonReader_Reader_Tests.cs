namespace TraktNet.Tests.Objects.Get.Users.Json.Reader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System.IO;
    using System.Threading.Tasks;
    using Traits;
    using TraktNet.Objects.Get.Users.Json.Reader;
    using Xunit;

    [Category("Objects.Get.Users.JsonReader")]
    public partial class AccountSettingsObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_AccountSettingsObjectJsonReader_ReadObject_From_JsonReader_Complete()
        {
            var traktJsonReader = new AccountSettingsObjectJsonReader();

            using (var reader = new StringReader(JSON_COMPLETE))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var userAccountSettings = await traktJsonReader.ReadObjectAsync(jsonReader);

                userAccountSettings.Should().NotBeNull();
                userAccountSettings.TimeZoneId.Should().Be("America/Los_Angeles");
                userAccountSettings.Time24Hr.Should().BeTrue();
                userAccountSettings.CoverImage.Should().Be("https://walter.trakt.us/images/movies/000/001/545/fanarts/original/0abb604492.jpg?1406095042");
                userAccountSettings.Token.Should().Be("60fa34c4f5e7f093ecc5a2d16d691e24");
            }
        }

        [Fact]
        public async Task Test_AccountSettingsObjectJsonReader_ReadObject_From_JsonReader_Incomplete_1()
        {
            var traktJsonReader = new AccountSettingsObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var userAccountSettings = await traktJsonReader.ReadObjectAsync(jsonReader);

                userAccountSettings.Should().NotBeNull();
                userAccountSettings.TimeZoneId.Should().BeNull();
                userAccountSettings.Time24Hr.Should().BeTrue();
                userAccountSettings.CoverImage.Should().Be("https://walter.trakt.us/images/movies/000/001/545/fanarts/original/0abb604492.jpg?1406095042");
                userAccountSettings.Token.Should().Be("60fa34c4f5e7f093ecc5a2d16d691e24");
            }
        }

        [Fact]
        public async Task Test_AccountSettingsObjectJsonReader_ReadObject_From_JsonReader_Incomplete_2()
        {
            var traktJsonReader = new AccountSettingsObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var userAccountSettings = await traktJsonReader.ReadObjectAsync(jsonReader);

                userAccountSettings.Should().NotBeNull();
                userAccountSettings.TimeZoneId.Should().Be("America/Los_Angeles");
                userAccountSettings.Time24Hr.Should().BeNull();
                userAccountSettings.CoverImage.Should().Be("https://walter.trakt.us/images/movies/000/001/545/fanarts/original/0abb604492.jpg?1406095042");
                userAccountSettings.Token.Should().Be("60fa34c4f5e7f093ecc5a2d16d691e24");
            }
        }

        [Fact]
        public async Task Test_AccountSettingsObjectJsonReader_ReadObject_From_JsonReader_Incomplete_3()
        {
            var traktJsonReader = new AccountSettingsObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var userAccountSettings = await traktJsonReader.ReadObjectAsync(jsonReader);

                userAccountSettings.Should().NotBeNull();
                userAccountSettings.TimeZoneId.Should().Be("America/Los_Angeles");
                userAccountSettings.Time24Hr.Should().BeTrue();
                userAccountSettings.CoverImage.Should().BeNull();
                userAccountSettings.Token.Should().Be("60fa34c4f5e7f093ecc5a2d16d691e24");
            }
        }

        [Fact]
        public async Task Test_AccountSettingsObjectJsonReader_ReadObject_From_JsonReader_Incomplete_4()
        {
            var traktJsonReader = new AccountSettingsObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var userAccountSettings = await traktJsonReader.ReadObjectAsync(jsonReader);

                userAccountSettings.Should().NotBeNull();
                userAccountSettings.TimeZoneId.Should().Be("America/Los_Angeles");
                userAccountSettings.Time24Hr.Should().BeTrue();
                userAccountSettings.CoverImage.Should().Be("https://walter.trakt.us/images/movies/000/001/545/fanarts/original/0abb604492.jpg?1406095042");
                userAccountSettings.Token.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_AccountSettingsObjectJsonReader_ReadObject_From_JsonReader_Incomplete_5()
        {
            var traktJsonReader = new AccountSettingsObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_5))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var userAccountSettings = await traktJsonReader.ReadObjectAsync(jsonReader);

                userAccountSettings.Should().NotBeNull();
                userAccountSettings.TimeZoneId.Should().Be("America/Los_Angeles");
                userAccountSettings.Time24Hr.Should().BeNull();
                userAccountSettings.CoverImage.Should().BeNull();
                userAccountSettings.Token.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_AccountSettingsObjectJsonReader_ReadObject_From_JsonReader_Incomplete_6()
        {
            var traktJsonReader = new AccountSettingsObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_6))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var userAccountSettings = await traktJsonReader.ReadObjectAsync(jsonReader);

                userAccountSettings.Should().NotBeNull();
                userAccountSettings.TimeZoneId.Should().BeNull();
                userAccountSettings.Time24Hr.Should().BeTrue();
                userAccountSettings.CoverImage.Should().BeNull();
                userAccountSettings.Token.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_AccountSettingsObjectJsonReader_ReadObject_From_JsonReader_Incomplete_7()
        {
            var traktJsonReader = new AccountSettingsObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_7))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var userAccountSettings = await traktJsonReader.ReadObjectAsync(jsonReader);

                userAccountSettings.Should().NotBeNull();
                userAccountSettings.TimeZoneId.Should().BeNull();
                userAccountSettings.Time24Hr.Should().BeNull();
                userAccountSettings.CoverImage.Should().Be("https://walter.trakt.us/images/movies/000/001/545/fanarts/original/0abb604492.jpg?1406095042");
                userAccountSettings.Token.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_AccountSettingsObjectJsonReader_ReadObject_From_JsonReader_Incomplete_8()
        {
            var traktJsonReader = new AccountSettingsObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_8))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var userAccountSettings = await traktJsonReader.ReadObjectAsync(jsonReader);

                userAccountSettings.Should().NotBeNull();
                userAccountSettings.TimeZoneId.Should().BeNull();
                userAccountSettings.Time24Hr.Should().BeNull();
                userAccountSettings.CoverImage.Should().BeNull();
                userAccountSettings.Token.Should().Be("60fa34c4f5e7f093ecc5a2d16d691e24");
            }
        }

        [Fact]
        public async Task Test_AccountSettingsObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_1()
        {
            var traktJsonReader = new AccountSettingsObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var userAccountSettings = await traktJsonReader.ReadObjectAsync(jsonReader);

                userAccountSettings.Should().NotBeNull();
                userAccountSettings.TimeZoneId.Should().BeNull();
                userAccountSettings.Time24Hr.Should().BeTrue();
                userAccountSettings.CoverImage.Should().Be("https://walter.trakt.us/images/movies/000/001/545/fanarts/original/0abb604492.jpg?1406095042");
                userAccountSettings.Token.Should().Be("60fa34c4f5e7f093ecc5a2d16d691e24");
            }
        }

        [Fact]
        public async Task Test_AccountSettingsObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_2()
        {
            var traktJsonReader = new AccountSettingsObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var userAccountSettings = await traktJsonReader.ReadObjectAsync(jsonReader);

                userAccountSettings.Should().NotBeNull();
                userAccountSettings.TimeZoneId.Should().Be("America/Los_Angeles");
                userAccountSettings.Time24Hr.Should().BeNull();
                userAccountSettings.CoverImage.Should().Be("https://walter.trakt.us/images/movies/000/001/545/fanarts/original/0abb604492.jpg?1406095042");
                userAccountSettings.Token.Should().Be("60fa34c4f5e7f093ecc5a2d16d691e24");
            }
        }

        [Fact]
        public async Task Test_AccountSettingsObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_3()
        {
            var traktJsonReader = new AccountSettingsObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var userAccountSettings = await traktJsonReader.ReadObjectAsync(jsonReader);

                userAccountSettings.Should().NotBeNull();
                userAccountSettings.TimeZoneId.Should().Be("America/Los_Angeles");
                userAccountSettings.Time24Hr.Should().BeTrue();
                userAccountSettings.CoverImage.Should().BeNull();
                userAccountSettings.Token.Should().Be("60fa34c4f5e7f093ecc5a2d16d691e24");
            }
        }

        [Fact]
        public async Task Test_AccountSettingsObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_4()
        {
            var traktJsonReader = new AccountSettingsObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var userAccountSettings = await traktJsonReader.ReadObjectAsync(jsonReader);

                userAccountSettings.Should().NotBeNull();
                userAccountSettings.TimeZoneId.Should().Be("America/Los_Angeles");
                userAccountSettings.Time24Hr.Should().BeTrue();
                userAccountSettings.CoverImage.Should().Be("https://walter.trakt.us/images/movies/000/001/545/fanarts/original/0abb604492.jpg?1406095042");
                userAccountSettings.Token.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_AccountSettingsObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_5()
        {
            var traktJsonReader = new AccountSettingsObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_5))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var userAccountSettings = await traktJsonReader.ReadObjectAsync(jsonReader);

                userAccountSettings.Should().NotBeNull();
                userAccountSettings.TimeZoneId.Should().BeNull();
                userAccountSettings.Time24Hr.Should().BeNull();
                userAccountSettings.CoverImage.Should().BeNull();
                userAccountSettings.Token.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_AccountSettingsObjectJsonReader_ReadObject_From_JsonReader_Null()
        {
            var traktJsonReader = new AccountSettingsObjectJsonReader();

            var userAccountSettings = await traktJsonReader.ReadObjectAsync(default(JsonTextReader));
            userAccountSettings.Should().BeNull();
        }

        [Fact]
        public async Task Test_AccountSettingsObjectJsonReader_ReadObject_From_JsonReader_Empty()
        {
            var traktJsonReader = new AccountSettingsObjectJsonReader();

            using (var reader = new StringReader(string.Empty))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var userAccountSettings = await traktJsonReader.ReadObjectAsync(jsonReader);
                userAccountSettings.Should().BeNull();
            }
        }
    }
}

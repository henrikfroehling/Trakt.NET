namespace TraktNet.Objects.Get.Tests.Users.Json.Reader
{
    using FluentAssertions;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Users.Json.Reader;
    using Xunit;

    [Category("Objects.Get.Users.JsonReader")]
    public partial class AccountSettingsObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_AccountSettingsObjectJsonReader_ReadObject_From_Json_String_Complete()
        {
            var jsonReader = new AccountSettingsObjectJsonReader();

            var userAccountSettings = await jsonReader.ReadObjectAsync(JSON_COMPLETE);

            userAccountSettings.Should().NotBeNull();
            userAccountSettings.TimeZoneId.Should().Be("America/Los_Angeles");
            userAccountSettings.Time24Hr.Should().BeTrue();
            userAccountSettings.CoverImage.Should().Be("https://walter.trakt.us/images/movies/000/001/545/fanarts/original/0abb604492.jpg?1406095042");
            userAccountSettings.Token.Should().Be("60fa34c4f5e7f093ecc5a2d16d691e24");
        }

        [Fact]
        public async Task Test_AccountSettingsObjectJsonReader_ReadObject_From_Json_String_Incomplete_1()
        {
            var jsonReader = new AccountSettingsObjectJsonReader();

            var userAccountSettings = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_1);

            userAccountSettings.Should().NotBeNull();
            userAccountSettings.TimeZoneId.Should().BeNull();
            userAccountSettings.Time24Hr.Should().BeTrue();
            userAccountSettings.CoverImage.Should().Be("https://walter.trakt.us/images/movies/000/001/545/fanarts/original/0abb604492.jpg?1406095042");
            userAccountSettings.Token.Should().Be("60fa34c4f5e7f093ecc5a2d16d691e24");
        }

        [Fact]
        public async Task Test_AccountSettingsObjectJsonReader_ReadObject_From_Json_String_Incomplete_2()
        {
            var jsonReader = new AccountSettingsObjectJsonReader();

            var userAccountSettings = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_2);

            userAccountSettings.Should().NotBeNull();
            userAccountSettings.TimeZoneId.Should().Be("America/Los_Angeles");
            userAccountSettings.Time24Hr.Should().BeNull();
            userAccountSettings.CoverImage.Should().Be("https://walter.trakt.us/images/movies/000/001/545/fanarts/original/0abb604492.jpg?1406095042");
            userAccountSettings.Token.Should().Be("60fa34c4f5e7f093ecc5a2d16d691e24");
        }

        [Fact]
        public async Task Test_AccountSettingsObjectJsonReader_ReadObject_From_Json_String_Incomplete_3()
        {
            var jsonReader = new AccountSettingsObjectJsonReader();

            var userAccountSettings = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_3);

            userAccountSettings.Should().NotBeNull();
            userAccountSettings.TimeZoneId.Should().Be("America/Los_Angeles");
            userAccountSettings.Time24Hr.Should().BeTrue();
            userAccountSettings.CoverImage.Should().BeNull();
            userAccountSettings.Token.Should().Be("60fa34c4f5e7f093ecc5a2d16d691e24");
        }

        [Fact]
        public async Task Test_AccountSettingsObjectJsonReader_ReadObject_From_Json_String_Incomplete_4()
        {
            var jsonReader = new AccountSettingsObjectJsonReader();

            var userAccountSettings = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_4);

            userAccountSettings.Should().NotBeNull();
            userAccountSettings.TimeZoneId.Should().Be("America/Los_Angeles");
            userAccountSettings.Time24Hr.Should().BeTrue();
            userAccountSettings.CoverImage.Should().Be("https://walter.trakt.us/images/movies/000/001/545/fanarts/original/0abb604492.jpg?1406095042");
            userAccountSettings.Token.Should().BeNull();
        }

        [Fact]
        public async Task Test_AccountSettingsObjectJsonReader_ReadObject_From_Json_String_Incomplete_5()
        {
            var jsonReader = new AccountSettingsObjectJsonReader();

            var userAccountSettings = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_5);

            userAccountSettings.Should().NotBeNull();
            userAccountSettings.TimeZoneId.Should().Be("America/Los_Angeles");
            userAccountSettings.Time24Hr.Should().BeNull();
            userAccountSettings.CoverImage.Should().BeNull();
            userAccountSettings.Token.Should().BeNull();
        }

        [Fact]
        public async Task Test_AccountSettingsObjectJsonReader_ReadObject_From_Json_String_Incomplete_6()
        {
            var jsonReader = new AccountSettingsObjectJsonReader();

            var userAccountSettings = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_6);

            userAccountSettings.Should().NotBeNull();
            userAccountSettings.TimeZoneId.Should().BeNull();
            userAccountSettings.Time24Hr.Should().BeTrue();
            userAccountSettings.CoverImage.Should().BeNull();
            userAccountSettings.Token.Should().BeNull();
        }

        [Fact]
        public async Task Test_AccountSettingsObjectJsonReader_ReadObject_From_Json_String_Incomplete_7()
        {
            var jsonReader = new AccountSettingsObjectJsonReader();

            var userAccountSettings = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_7);

            userAccountSettings.Should().NotBeNull();
            userAccountSettings.TimeZoneId.Should().BeNull();
            userAccountSettings.Time24Hr.Should().BeNull();
            userAccountSettings.CoverImage.Should().Be("https://walter.trakt.us/images/movies/000/001/545/fanarts/original/0abb604492.jpg?1406095042");
            userAccountSettings.Token.Should().BeNull();
        }

        [Fact]
        public async Task Test_AccountSettingsObjectJsonReader_ReadObject_From_Json_String_Incomplete_8()
        {
            var jsonReader = new AccountSettingsObjectJsonReader();

            var userAccountSettings = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_8);

            userAccountSettings.Should().NotBeNull();
            userAccountSettings.TimeZoneId.Should().BeNull();
            userAccountSettings.Time24Hr.Should().BeNull();
            userAccountSettings.CoverImage.Should().BeNull();
            userAccountSettings.Token.Should().Be("60fa34c4f5e7f093ecc5a2d16d691e24");
        }

        [Fact]
        public async Task Test_AccountSettingsObjectJsonReader_ReadObject_From_Json_String_Not_Valid_1()
        {
            var jsonReader = new AccountSettingsObjectJsonReader();

            var userAccountSettings = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_1);

            userAccountSettings.Should().NotBeNull();
            userAccountSettings.TimeZoneId.Should().BeNull();
            userAccountSettings.Time24Hr.Should().BeTrue();
            userAccountSettings.CoverImage.Should().Be("https://walter.trakt.us/images/movies/000/001/545/fanarts/original/0abb604492.jpg?1406095042");
            userAccountSettings.Token.Should().Be("60fa34c4f5e7f093ecc5a2d16d691e24");
        }

        [Fact]
        public async Task Test_AccountSettingsObjectJsonReader_ReadObject_From_Json_String_Not_Valid_2()
        {
            var jsonReader = new AccountSettingsObjectJsonReader();

            var userAccountSettings = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_2);

            userAccountSettings.Should().NotBeNull();
            userAccountSettings.TimeZoneId.Should().Be("America/Los_Angeles");
            userAccountSettings.Time24Hr.Should().BeNull();
            userAccountSettings.CoverImage.Should().Be("https://walter.trakt.us/images/movies/000/001/545/fanarts/original/0abb604492.jpg?1406095042");
            userAccountSettings.Token.Should().Be("60fa34c4f5e7f093ecc5a2d16d691e24");
        }

        [Fact]
        public async Task Test_AccountSettingsObjectJsonReader_ReadObject_From_Json_String_Not_Valid_3()
        {
            var jsonReader = new AccountSettingsObjectJsonReader();

            var userAccountSettings = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_3);

            userAccountSettings.Should().NotBeNull();
            userAccountSettings.TimeZoneId.Should().Be("America/Los_Angeles");
            userAccountSettings.Time24Hr.Should().BeTrue();
            userAccountSettings.CoverImage.Should().BeNull();
            userAccountSettings.Token.Should().Be("60fa34c4f5e7f093ecc5a2d16d691e24");
        }

        [Fact]
        public async Task Test_AccountSettingsObjectJsonReader_ReadObject_From_Json_String_Not_Valid_4()
        {
            var jsonReader = new AccountSettingsObjectJsonReader();

            var userAccountSettings = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_4);

            userAccountSettings.Should().NotBeNull();
            userAccountSettings.TimeZoneId.Should().Be("America/Los_Angeles");
            userAccountSettings.Time24Hr.Should().BeTrue();
            userAccountSettings.CoverImage.Should().Be("https://walter.trakt.us/images/movies/000/001/545/fanarts/original/0abb604492.jpg?1406095042");
            userAccountSettings.Token.Should().BeNull();
        }

        [Fact]
        public async Task Test_AccountSettingsObjectJsonReader_ReadObject_From_Json_String_Not_Valid_5()
        {
            var jsonReader = new AccountSettingsObjectJsonReader();

            var userAccountSettings = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_5);

            userAccountSettings.Should().NotBeNull();
            userAccountSettings.TimeZoneId.Should().BeNull();
            userAccountSettings.Time24Hr.Should().BeNull();
            userAccountSettings.CoverImage.Should().BeNull();
            userAccountSettings.Token.Should().BeNull();
        }

        [Fact]
        public async Task Test_AccountSettingsObjectJsonReader_ReadObject_From_Json_String_Null()
        {
            var jsonReader = new AccountSettingsObjectJsonReader();

            var userAccountSettings = await jsonReader.ReadObjectAsync(default(string));
            userAccountSettings.Should().BeNull();
        }

        [Fact]
        public async Task Test_AccountSettingsObjectJsonReader_ReadObject_From_Json_String_Empty()
        {
            var jsonReader = new AccountSettingsObjectJsonReader();

            var userAccountSettings = await jsonReader.ReadObjectAsync(string.Empty);
            userAccountSettings.Should().BeNull();
        }
    }
}

namespace TraktApiSharp.Tests.Objects.Get.Users.JsonReader
{
    using FluentAssertions;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Objects.Get.Users.JsonReader;
    using Xunit;

    [Category("Objects.Get.Users.JsonReader")]
    public partial class TraktAccountSettingsObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_TraktAccountSettingsObjectJsonReader_ReadObject_From_Json_String_Complete()
        {
            var jsonReader = new TraktAccountSettingsObjectJsonReader();

            var userAccountSettings = await jsonReader.ReadObjectAsync(JSON_COMPLETE);

            userAccountSettings.Should().NotBeNull();
            userAccountSettings.TimeZoneId.Should().Be("America/Los_Angeles");
            userAccountSettings.Time24Hr.Should().BeTrue();
            userAccountSettings.CoverImage.Should().Be("https://walter.trakt.us/images/movies/000/001/545/fanarts/original/0abb604492.jpg?1406095042");
        }

        [Fact]
        public async Task Test_TraktAccountSettingsObjectJsonReader_ReadObject_From_Json_String_Incomplete_1()
        {
            var jsonReader = new TraktAccountSettingsObjectJsonReader();

            var userAccountSettings = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_1);

            userAccountSettings.Should().NotBeNull();
            userAccountSettings.TimeZoneId.Should().BeNull();
            userAccountSettings.Time24Hr.Should().BeTrue();
            userAccountSettings.CoverImage.Should().Be("https://walter.trakt.us/images/movies/000/001/545/fanarts/original/0abb604492.jpg?1406095042");
        }

        [Fact]
        public async Task Test_TraktAccountSettingsObjectJsonReader_ReadObject_From_Json_String_Incomplete_2()
        {
            var jsonReader = new TraktAccountSettingsObjectJsonReader();

            var userAccountSettings = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_2);

            userAccountSettings.Should().NotBeNull();
            userAccountSettings.TimeZoneId.Should().Be("America/Los_Angeles");
            userAccountSettings.Time24Hr.Should().BeNull();
            userAccountSettings.CoverImage.Should().Be("https://walter.trakt.us/images/movies/000/001/545/fanarts/original/0abb604492.jpg?1406095042");
        }

        [Fact]
        public async Task Test_TraktAccountSettingsObjectJsonReader_ReadObject_From_Json_String_Incomplete_3()
        {
            var jsonReader = new TraktAccountSettingsObjectJsonReader();

            var userAccountSettings = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_3);

            userAccountSettings.Should().NotBeNull();
            userAccountSettings.TimeZoneId.Should().Be("America/Los_Angeles");
            userAccountSettings.Time24Hr.Should().BeTrue();
            userAccountSettings.CoverImage.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktAccountSettingsObjectJsonReader_ReadObject_From_Json_String_Incomplete_4()
        {
            var jsonReader = new TraktAccountSettingsObjectJsonReader();

            var userAccountSettings = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_4);

            userAccountSettings.Should().NotBeNull();
            userAccountSettings.TimeZoneId.Should().Be("America/Los_Angeles");
            userAccountSettings.Time24Hr.Should().BeNull();
            userAccountSettings.CoverImage.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktAccountSettingsObjectJsonReader_ReadObject_From_Json_String_Incomplete_5()
        {
            var jsonReader = new TraktAccountSettingsObjectJsonReader();

            var userAccountSettings = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_5);

            userAccountSettings.Should().NotBeNull();
            userAccountSettings.TimeZoneId.Should().BeNull();
            userAccountSettings.Time24Hr.Should().BeTrue();
            userAccountSettings.CoverImage.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktAccountSettingsObjectJsonReader_ReadObject_From_Json_String_Incomplete_6()
        {
            var jsonReader = new TraktAccountSettingsObjectJsonReader();

            var userAccountSettings = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_6);

            userAccountSettings.Should().NotBeNull();
            userAccountSettings.TimeZoneId.Should().BeNull();
            userAccountSettings.Time24Hr.Should().BeNull();
            userAccountSettings.CoverImage.Should().Be("https://walter.trakt.us/images/movies/000/001/545/fanarts/original/0abb604492.jpg?1406095042");
        }

        [Fact]
        public async Task Test_TraktAccountSettingsObjectJsonReader_ReadObject_From_Json_String_Not_Valid_1()
        {
            var jsonReader = new TraktAccountSettingsObjectJsonReader();

            var userAccountSettings = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_1);

            userAccountSettings.Should().NotBeNull();
            userAccountSettings.TimeZoneId.Should().BeNull();
            userAccountSettings.Time24Hr.Should().BeTrue();
            userAccountSettings.CoverImage.Should().Be("https://walter.trakt.us/images/movies/000/001/545/fanarts/original/0abb604492.jpg?1406095042");
        }

        [Fact]
        public async Task Test_TraktAccountSettingsObjectJsonReader_ReadObject_From_Json_String_Not_Valid_2()
        {
            var jsonReader = new TraktAccountSettingsObjectJsonReader();

            var userAccountSettings = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_2);

            userAccountSettings.Should().NotBeNull();
            userAccountSettings.TimeZoneId.Should().Be("America/Los_Angeles");
            userAccountSettings.Time24Hr.Should().BeNull();
            userAccountSettings.CoverImage.Should().Be("https://walter.trakt.us/images/movies/000/001/545/fanarts/original/0abb604492.jpg?1406095042");
        }

        [Fact]
        public async Task Test_TraktAccountSettingsObjectJsonReader_ReadObject_From_Json_String_Not_Valid_3()
        {
            var jsonReader = new TraktAccountSettingsObjectJsonReader();

            var userAccountSettings = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_3);

            userAccountSettings.Should().NotBeNull();
            userAccountSettings.TimeZoneId.Should().Be("America/Los_Angeles");
            userAccountSettings.Time24Hr.Should().BeTrue();
            userAccountSettings.CoverImage.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktAccountSettingsObjectJsonReader_ReadObject_From_Json_String_Not_Valid_4()
        {
            var jsonReader = new TraktAccountSettingsObjectJsonReader();

            var userAccountSettings = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_4);

            userAccountSettings.Should().NotBeNull();
            userAccountSettings.TimeZoneId.Should().BeNull();
            userAccountSettings.Time24Hr.Should().BeNull();
            userAccountSettings.CoverImage.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktAccountSettingsObjectJsonReader_ReadObject_From_Json_String_Null()
        {
            var jsonReader = new TraktAccountSettingsObjectJsonReader();

            var userAccountSettings = await jsonReader.ReadObjectAsync(default(string));
            userAccountSettings.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktAccountSettingsObjectJsonReader_ReadObject_From_Json_String_Empty()
        {
            var jsonReader = new TraktAccountSettingsObjectJsonReader();

            var userAccountSettings = await jsonReader.ReadObjectAsync(string.Empty);
            userAccountSettings.Should().BeNull();
        }
    }
}

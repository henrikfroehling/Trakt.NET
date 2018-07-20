namespace TraktNet.Tests.Objects.Get.Users.Implementations
{
    using FluentAssertions;
    using System.Threading.Tasks;
    using Traits;
    using TraktNet.Objects.Get.Users;
    using TraktNet.Objects.Get.Users.Json.Reader;
    using Xunit;

    [Category("Objects.Get.Users.Implementations")]
    public class TraktAccountSettings_Tests
    {
        [Fact]
        public void Test_TraktAccountSettings_Default_Constructor()
        {
            var accountSettings = new TraktAccountSettings();

            accountSettings.TimeZoneId.Should().BeNull();
            accountSettings.Time24Hr.Should().BeNull();
            accountSettings.CoverImage.Should().BeNull();
            accountSettings.Token.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktAccountSettings_From_Json()
        {
            var jsonReader = new AccountSettingsObjectJsonReader();
            var accountSettings = await jsonReader.ReadObjectAsync(JSON) as TraktAccountSettings;

            accountSettings.Should().NotBeNull();
            accountSettings.TimeZoneId.Should().Be("America/Los_Angeles");
            accountSettings.Time24Hr.Should().BeTrue();
            accountSettings.CoverImage.Should().Be("https://walter.trakt.us/images/movies/000/001/545/fanarts/original/0abb604492.jpg?1406095042");
            accountSettings.Token.Should().Be("60fa34c4f5e7f093ecc5a2d16d691e24");
        }

        private const string JSON =
            @"{
                ""timezone"": ""America/Los_Angeles"",
                ""time_24hr"": true,
                ""cover_image"": ""https://walter.trakt.us/images/movies/000/001/545/fanarts/original/0abb604492.jpg?1406095042"",
                ""token"": ""60fa34c4f5e7f093ecc5a2d16d691e24""
              }";
    }
}

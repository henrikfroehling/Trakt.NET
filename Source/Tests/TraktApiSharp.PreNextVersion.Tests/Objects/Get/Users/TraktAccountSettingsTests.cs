namespace TraktApiSharp.Tests.Objects.Users
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    using TraktApiSharp.Objects.Get.Users;
    using Utils;

    [TestClass]
    public class TraktAccountSettingsTests
    {

        [TestMethod]
        public void TestTraktAccountSettingsDefaultConstructor()
        {
            var settings = new TraktAccountSettings();

            settings.TimeZoneId.Should().BeNullOrEmpty();
            settings.Time24Hr.Should().NotHaveValue();
            settings.CoverImage.Should().BeNullOrEmpty();
        }

        [TestMethod]
        public void TestTraktAccountSettingsReadFromJson()
        {
            var jsonFile = TestUtility.ReadFileContents(@"Objects\Get\Users\AccountSettings.json");

            jsonFile.Should().NotBeNullOrEmpty();

            var settings = JsonConvert.DeserializeObject<TraktAccountSettings>(jsonFile);

            settings.Should().NotBeNull();
            settings.TimeZoneId.Should().Be("America/Los_Angeles");
            settings.Time24Hr.Should().BeTrue();
            settings.CoverImage.Should().Be("https://walter.trakt.us/images/movies/000/001/545/fanarts/original/0abb604492.jpg?1406095042");
        }
    }
}

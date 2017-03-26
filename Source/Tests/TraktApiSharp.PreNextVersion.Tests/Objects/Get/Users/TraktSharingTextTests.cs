namespace TraktApiSharp.Tests.Objects.Users
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    using TraktApiSharp.Objects.Get.Users;
    using TraktApiSharp.Objects.Get.Users.Implementations;
    using Utils;

    [TestClass]
    public class TraktSharingTextTests
    {
        [TestMethod]
        public void TestTraktSharingTextDefaultConstructor()
        {
            var sharingText = new TraktSharingText();

            sharingText.Watching.Should().BeNullOrEmpty();
            sharingText.Watched.Should().BeNullOrEmpty();
        }

        [TestMethod]
        public void TestTraktSharingTextReadFromJson()
        {
            var jsonFile = TestUtility.ReadFileContents(@"Objects\Get\Users\SharingText.json");

            jsonFile.Should().NotBeNullOrEmpty();

            var sharingText = JsonConvert.DeserializeObject<TraktSharingText>(jsonFile);

            sharingText.Should().NotBeNull();
            sharingText.Watching.Should().Be("I'm watching [item]");
            sharingText.Watched.Should().Be("I just watched [item]");
        }
    }
}

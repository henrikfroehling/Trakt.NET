namespace TraktApiSharp.Tests.Objects
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    using TraktApiSharp.Objects.Basic;
    using Utils;

    [TestClass]
    public class TraktImageTests
    {
        [TestMethod]
        public void TestTraktImageDefaultConstructor()
        {
            var image = new TraktImage();

            image.Full.Should().BeNullOrEmpty();
        }

        [TestMethod]
        public void TestTraktImageReadFromJson()
        {
            var jsonFile = TestUtility.ReadFileContents(@"Objects\Basic\Image.json");

            jsonFile.Should().NotBeNullOrEmpty();

            var image = JsonConvert.DeserializeObject<TraktImage>(jsonFile);

            image.Should().NotBeNull();
            image.Full.Should().Be("https://walter.trakt.us/images/shows/000/060/300/logos/original/ab151d1043.png");
        }
    }
}

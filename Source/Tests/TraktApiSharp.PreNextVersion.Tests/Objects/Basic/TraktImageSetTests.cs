namespace TraktApiSharp.Tests.Objects
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    using TraktApiSharp.Objects.Basic;
    using Utils;

    [TestClass]
    public class TraktImageSetTests
    {
        [TestMethod]
        public void TestTraktImageSetDefaultConstructor()
        {
            var imageSet = new TraktImageSet();

            imageSet.Full.Should().BeNullOrEmpty();
            imageSet.Medium.Should().BeNullOrEmpty();
            imageSet.Thumb.Should().BeNullOrEmpty();
        }

        [TestMethod]
        public void TestTraktImageSetReadFromJson()
        {
            var jsonFile = TestUtility.ReadFileContents(@"Objects\Basic\ImageSet.json");

            jsonFile.Should().NotBeNullOrEmpty();

            var imageSet = JsonConvert.DeserializeObject<TraktImageSet>(jsonFile);

            imageSet.Should().NotBeNull();
            imageSet.Full.Should().Be("https://walter.trakt.us/images/shows/000/060/300/posters/original/79bd96a4d3.jpg");
            imageSet.Medium.Should().Be("https://walter.trakt.us/images/shows/000/060/300/posters/medium/79bd96a4d3.jpg");
            imageSet.Thumb.Should().Be("https://walter.trakt.us/images/shows/000/060/300/posters/thumb/79bd96a4d3.jpg");
        }
    }
}

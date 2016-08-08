namespace TraktApiSharp.Tests.Objects
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    using TraktApiSharp.Objects.Basic;
    using Utils;

    [TestClass]
    public class TraktGenreTests
    {
        [TestMethod]
        public void TestTraktGenreDefaultConstructor()
        {
            var genre = new TraktGenre();

            genre.Name.Should().BeNullOrEmpty();
            genre.Slug.Should().BeNullOrEmpty();
            genre.Type.Should().BeNull();
        }

        [TestMethod]
        public void TestTraktGenreReadFromJson()
        {
            var jsonFile = TestUtility.ReadFileContents(@"Objects\Basic\Genre.json");

            jsonFile.Should().NotBeNullOrEmpty();

            var genre = JsonConvert.DeserializeObject<TraktGenre>(jsonFile);

            genre.Should().NotBeNull();
            genre.Name.Should().Be("Action");
            genre.Slug.Should().Be("action");
        }
    }
}

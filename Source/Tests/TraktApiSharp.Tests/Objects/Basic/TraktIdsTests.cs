namespace TraktApiSharp.Tests.Objects
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    using TraktApiSharp.Objects.Basic;
    using Utils;

    [TestClass]
    public class TraktIdsTests
    {
        [TestMethod]
        public void TestTraktIdsDefaultConstructor()
        {
            var ids = new TraktIds();

            ids.Trakt.Should().Be(0);
            ids.Slug.Should().BeNullOrEmpty();
            ids.Tvdb.Should().BeNull();
            ids.Imdb.Should().BeNullOrEmpty();
            ids.Tmdb.Should().BeNull();
            ids.TvRage.Should().BeNull();
            ids.HasAnyId.Should().BeFalse();
            ids.GetBestId().Should().BeEmpty();
        }

        [TestMethod]
        public void TestTraktIdsReadFromJson()
        {
            var jsonFile = TestUtility.ReadFileContents(@"Objects\Basic\Ids.json");

            jsonFile.Should().NotBeNullOrEmpty();

            var ids = JsonConvert.DeserializeObject<TraktIds>(jsonFile);

            ids.Should().NotBeNull();
            ids.Trakt.Should().Be(60300U);
            ids.Slug.Should().Be("the-flash-2014");
            ids.Tvdb.Should().Be(279121U);
            ids.Imdb.Should().Be("tt3107288");
            ids.Tmdb.Should().Be(60735U);
            ids.TvRage.Should().Be(36939U);
            ids.HasAnyId.Should().BeTrue();
            ids.GetBestId().Should().Be("60300");
        }
    }
}

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
            ids.Tvdb.Should().NotHaveValue();
            ids.Imdb.Should().BeNullOrEmpty();
            ids.Tmdb.Should().NotHaveValue();
            ids.TvRage.Should().NotHaveValue();
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
            ids.Trakt.Should().Be(60300);
            ids.Slug.Should().Be("the-flash-2014");
            ids.Tvdb.Should().Be(279121);
            ids.Imdb.Should().Be("tt3107288");
            ids.Tmdb.Should().Be(60735);
            ids.TvRage.Should().Be(36939);
            ids.HasAnyId.Should().BeTrue();
            ids.GetBestId().Should().Be("60300");
        }
    }
}

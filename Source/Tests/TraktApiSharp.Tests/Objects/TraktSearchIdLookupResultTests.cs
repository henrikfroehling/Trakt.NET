namespace TraktApiSharp.Tests.Objects
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    using TraktApiSharp.Enums;
    using TraktApiSharp.Objects;
    using Utils;

    [TestClass]
    public class TraktSearchIdLookupResultTests
    {
        [TestMethod]
        public void TestTraktSearchIdLookupResultDefaultConstructor()
        {
            var searchIdLookupResult = new TraktSearchIdLookupResult();

            searchIdLookupResult.Type.Should().Be(TraktSearchResultType.Movie);
            searchIdLookupResult.Score.Should().NotHaveValue();
            searchIdLookupResult.Movie.Should().BeNull();
            searchIdLookupResult.Show.Should().BeNull();
            searchIdLookupResult.Episode.Should().BeNull();
            searchIdLookupResult.Person.Should().BeNull();
            searchIdLookupResult.List.Should().BeNull();
        }

        [TestMethod]
        public void TestTraktSearchIdLookupResultReadFromJsonEpisode()
        {
            var jsonFile = TestUtility.ReadJsonData(@"Basic\Search\SearchIdLookupResultEpisode.json");

            jsonFile.Should().NotBeNullOrEmpty();

            var searchIdLookupResult = JsonConvert.DeserializeObject<TraktSearchIdLookupResult>(jsonFile);

            searchIdLookupResult.Should().NotBeNull();
            searchIdLookupResult.Type.Should().Be(TraktSearchResultType.Episode);
            searchIdLookupResult.Score.Should().NotHaveValue();
            searchIdLookupResult.Movie.Should().BeNull();
            searchIdLookupResult.Show.Should().NotBeNull();
            searchIdLookupResult.Episode.Should().NotBeNull();
            searchIdLookupResult.Person.Should().BeNull();
            searchIdLookupResult.List.Should().BeNull();
        }

        [TestMethod]
        public void TestTraktSearchIdLookupResultReadFromJsonMovie()
        {
            var jsonFile = TestUtility.ReadJsonData(@"Basic\Search\SearchIdLookupResultMovie.json");

            jsonFile.Should().NotBeNullOrEmpty();

            var searchIdLookupResult = JsonConvert.DeserializeObject<TraktSearchIdLookupResult>(jsonFile);

            searchIdLookupResult.Should().NotBeNull();
            searchIdLookupResult.Type.Should().Be(TraktSearchResultType.Movie);
            searchIdLookupResult.Score.Should().NotHaveValue();
            searchIdLookupResult.Movie.Should().NotBeNull();
            searchIdLookupResult.Show.Should().BeNull();
            searchIdLookupResult.Episode.Should().BeNull();
            searchIdLookupResult.Person.Should().BeNull();
            searchIdLookupResult.List.Should().BeNull();
        }

        [TestMethod]
        public void TestTraktSearchIdLookupResultReadFromJsonShow()
        {
            var jsonFile = TestUtility.ReadJsonData(@"Basic\Search\SearchIdLookupResultShow.json");

            jsonFile.Should().NotBeNullOrEmpty();

            var searchIdLookupResult = JsonConvert.DeserializeObject<TraktSearchIdLookupResult>(jsonFile);

            searchIdLookupResult.Should().NotBeNull();
            searchIdLookupResult.Type.Should().Be(TraktSearchResultType.Show);
            searchIdLookupResult.Score.Should().NotHaveValue();
            searchIdLookupResult.Movie.Should().BeNull();
            searchIdLookupResult.Show.Should().NotBeNull();
            searchIdLookupResult.Episode.Should().BeNull();
            searchIdLookupResult.Person.Should().BeNull();
            searchIdLookupResult.List.Should().BeNull();
        }
    }
}

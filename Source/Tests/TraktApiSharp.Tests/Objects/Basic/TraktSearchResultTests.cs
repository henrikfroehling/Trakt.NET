namespace TraktApiSharp.Tests.Objects
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    using TraktApiSharp.Enums;
    using TraktApiSharp.Objects.Basic;
    using Utils;

    [TestClass]
    public class TraktSearchResultTests
    {
        [TestMethod]
        public void TestTraktSearchResultDefaultConstructor()
        {
            var searchResult = new TraktSearchResult();

            searchResult.Type.Should().BeNull();
            searchResult.Score.Should().NotHaveValue();
            searchResult.Movie.Should().BeNull();
            searchResult.Show.Should().BeNull();
            searchResult.Episode.Should().BeNull();
            searchResult.Person.Should().BeNull();
            searchResult.List.Should().BeNull();
        }

        [TestMethod]
        public void TestTraktSearchResultReadFromJsonEpisode()
        {
            var jsonFile = TestUtility.ReadFileContents(@"Objects\Basic\Search\SearchResultEpisode.json");

            jsonFile.Should().NotBeNullOrEmpty();

            var searchResult = JsonConvert.DeserializeObject<TraktSearchResult>(jsonFile);

            searchResult.Should().NotBeNull();
            searchResult.Type.Should().Be(TraktSearchResultType.Episode);
            searchResult.Score.Should().Be(94.02257f);
            searchResult.Movie.Should().BeNull();
            searchResult.Show.Should().NotBeNull();
            searchResult.Episode.Should().NotBeNull();
            searchResult.Person.Should().BeNull();
            searchResult.List.Should().BeNull();
        }

        [TestMethod]
        public void TestTraktSearchResultReadFromJsonList()
        {
            var jsonFile = TestUtility.ReadFileContents(@"Objects\Basic\Search\SearchResultList.json");

            jsonFile.Should().NotBeNullOrEmpty();

            var searchResult = JsonConvert.DeserializeObject<TraktSearchResult>(jsonFile);

            searchResult.Should().NotBeNull();
            searchResult.Type.Should().Be(TraktSearchResultType.List);
            searchResult.Score.Should().Be(121.51058f);
            searchResult.Movie.Should().BeNull();
            searchResult.Show.Should().BeNull();
            searchResult.Episode.Should().BeNull();
            searchResult.Person.Should().BeNull();
            searchResult.List.Should().NotBeNull();
        }

        [TestMethod]
        public void TestTraktSearchResultReadFromJsonMovie()
        {
            var jsonFile = TestUtility.ReadFileContents(@"Objects\Basic\Search\SearchResultMovie.json");

            jsonFile.Should().NotBeNullOrEmpty();

            var searchResult = JsonConvert.DeserializeObject<TraktSearchResult>(jsonFile);

            searchResult.Should().NotBeNull();
            searchResult.Type.Should().Be(TraktSearchResultType.Movie);
            searchResult.Score.Should().Be(46.29501f);
            searchResult.Movie.Should().NotBeNull();
            searchResult.Show.Should().BeNull();
            searchResult.Episode.Should().BeNull();
            searchResult.Person.Should().BeNull();
            searchResult.List.Should().BeNull();
        }

        [TestMethod]
        public void TestTraktSearchResultReadFromJsonPerson()
        {
            var jsonFile = TestUtility.ReadFileContents(@"Objects\Basic\Search\SearchResultPerson.json");

            jsonFile.Should().NotBeNullOrEmpty();

            var searchResult = JsonConvert.DeserializeObject<TraktSearchResult>(jsonFile);

            searchResult.Should().NotBeNull();
            searchResult.Type.Should().Be(TraktSearchResultType.Person);
            searchResult.Score.Should().Be(64.80029f);
            searchResult.Movie.Should().BeNull();
            searchResult.Show.Should().BeNull();
            searchResult.Episode.Should().BeNull();
            searchResult.Person.Should().NotBeNull();
            searchResult.List.Should().BeNull();
        }

        [TestMethod]
        public void TestTraktSearchResultReadFromJsonShow()
        {
            var jsonFile = TestUtility.ReadFileContents(@"Objects\Basic\Search\SearchResultShow.json");

            jsonFile.Should().NotBeNullOrEmpty();

            var searchResult = JsonConvert.DeserializeObject<TraktSearchResult>(jsonFile);

            searchResult.Should().NotBeNull();
            searchResult.Type.Should().Be(TraktSearchResultType.Show);
            searchResult.Score.Should().Be(0.5923821f);
            searchResult.Movie.Should().BeNull();
            searchResult.Show.Should().NotBeNull();
            searchResult.Episode.Should().BeNull();
            searchResult.Person.Should().BeNull();
            searchResult.List.Should().BeNull();
        }
    }
}

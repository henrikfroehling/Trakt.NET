namespace TraktApiSharp.Tests.Objects.Movies.Common
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.Linq;
    using TraktApiSharp.Objects.Get.Movies.Common;
    using Utils;

    [TestClass]
    public class TraktMoviesMostCollectedTests
    {
        [TestMethod]
        public void TestTraktMoviesMostCollectedDefaultConstructor()
        {
            var collectedMovie = new TraktMostCollectedMovie();

            collectedMovie.WatcherCount.Should().NotHaveValue();
            collectedMovie.PlayCount.Should().NotHaveValue();
            collectedMovie.CollectedCount.Should().NotHaveValue();
            collectedMovie.Movie.Should().BeNull();
        }

        [TestMethod]
        public void TestTraktMoviesMostCollectedReadFromJson()
        {
            var jsonFile = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesMostCollected.json");

            jsonFile.Should().NotBeNullOrEmpty();

            var collectedMovies = JsonConvert.DeserializeObject<IEnumerable<TraktMostCollectedMovie>>(jsonFile);

            collectedMovies.Should().NotBeNull().And.HaveCount(2);

            var movies = collectedMovies.ToArray();

            movies[0].WatcherCount.Should().Be(0);
            movies[0].PlayCount.Should().Be(0);
            movies[0].CollectedCount.Should().Be(4353);
            movies[0].Movie.Should().NotBeNull();

            movies[1].WatcherCount.Should().Be(4683);
            movies[1].PlayCount.Should().Be(6542);
            movies[1].CollectedCount.Should().Be(1866);
            movies[1].Movie.Should().NotBeNull();
        }
    }
}

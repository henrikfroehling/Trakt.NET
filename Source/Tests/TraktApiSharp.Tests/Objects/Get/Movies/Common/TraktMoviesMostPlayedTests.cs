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
    public class TraktMoviesMostPlayedTests
    {
        [TestMethod]
        public void TestTraktMoviesMostPlayedDefaultConstructor()
        {
            var playedMovie = new TraktMostPlayedMovie();

            playedMovie.WatcherCount.Should().NotHaveValue();
            playedMovie.PlayCount.Should().NotHaveValue();
            playedMovie.CollectedCount.Should().NotHaveValue();
            playedMovie.Movie.Should().BeNull();
        }

        [TestMethod]
        public void TestTraktMoviesMostPlayedReadFromJson()
        {
            var jsonFile = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesMostPlayed.json");

            jsonFile.Should().NotBeNullOrEmpty();

            var playedMovies = JsonConvert.DeserializeObject<IEnumerable<TraktMostPlayedMovie>>(jsonFile);

            playedMovies.Should().NotBeNull().And.HaveCount(2);

            var movies = playedMovies.ToArray();

            movies[0].WatcherCount.Should().Be(4992);
            movies[0].PlayCount.Should().Be(7100);
            movies[0].CollectedCount.Should().Be(1348);
            movies[0].Movie.Should().NotBeNull();

            movies[1].WatcherCount.Should().Be(3962);
            movies[1].PlayCount.Should().Be(6622);
            movies[1].CollectedCount.Should().Be(1181);
            movies[1].Movie.Should().NotBeNull();
        }
    }
}

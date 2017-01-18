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
    public class TraktMoviesMostWatchedTests
    {
        [TestMethod]
        public void TestTraktMoviesMostWatchedDefaultConstructor()
        {
            var watchedMovie = new TraktMostWatchedMovie();

            watchedMovie.WatcherCount.Should().NotHaveValue();
            watchedMovie.PlayCount.Should().NotHaveValue();
            watchedMovie.CollectedCount.Should().NotHaveValue();
            watchedMovie.Movie.Should().BeNull();
        }

        [TestMethod]
        public void TestTraktMoviesMostWatchedReadFromJson()
        {
            var jsonFile = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesMostWatched.json");

            jsonFile.Should().NotBeNullOrEmpty();

            var watchedMovies = JsonConvert.DeserializeObject<IEnumerable<TraktMostWatchedMovie>>(jsonFile);

            watchedMovies.Should().NotBeNull().And.HaveCount(2);

            var movies = watchedMovies.ToArray();

            movies[0].WatcherCount.Should().Be(4992);
            movies[0].PlayCount.Should().Be(7100);
            movies[0].CollectedCount.Should().Be(1348);
            movies[0].Movie.Should().NotBeNull();

            movies[1].WatcherCount.Should().Be(4683);
            movies[1].PlayCount.Should().Be(6542);
            movies[1].CollectedCount.Should().Be(1866);
            movies[1].Movie.Should().NotBeNull();
        }
    }
}

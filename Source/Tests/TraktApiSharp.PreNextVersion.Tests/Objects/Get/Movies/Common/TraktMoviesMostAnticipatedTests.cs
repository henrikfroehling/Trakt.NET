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
    public class TraktMoviesMostAnticipatedTests
    {
        [TestMethod]
        public void TestTraktMoviesMostAnticipatedDefaultConstructor()
        {
            var anticipatedMovie = new TraktMostAnticipatedMovie();

            anticipatedMovie.ListCount.Should().NotHaveValue();
            anticipatedMovie.Movie.Should().BeNull();
        }

        [TestMethod]
        public void TestTraktMoviesMostAnticipatedReadFromJson()
        {
            var jsonFile = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesMostAnticipated.json");

            jsonFile.Should().NotBeNullOrEmpty();

            var anticipatedMovies = JsonConvert.DeserializeObject<IEnumerable<TraktMostAnticipatedMovie>>(jsonFile);

            anticipatedMovies.Should().NotBeNull().And.HaveCount(2);

            var movies = anticipatedMovies.ToArray();

            movies[0].ListCount.Should().Be(12805);
            movies[0].Movie.Should().NotBeNull();

            movies[1].ListCount.Should().Be(11387);
            movies[1].Movie.Should().NotBeNull();
        }
    }
}

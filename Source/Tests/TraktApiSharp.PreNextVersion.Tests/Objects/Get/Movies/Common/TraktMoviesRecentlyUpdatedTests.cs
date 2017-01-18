namespace TraktApiSharp.Tests.Objects.Movies.Common
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using TraktApiSharp.Objects.Get.Movies.Common;
    using Utils;

    [TestClass]
    public class TraktMoviesRecentlyUpdatedTests
    {
        [TestMethod]
        public void TestTraktMoviesRecentlyUpdatedDefaultConstructor()
        {
            var updatedMovie = new TraktRecentlyUpdatedMovie();

            updatedMovie.UpdatedAt.Should().NotHaveValue();
            updatedMovie.Movie.Should().BeNull();
        }

        [TestMethod]
        public void TestTraktShowsRecentlyUpdatedReadFromJson()
        {
            var jsonFile = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesRecentlyUpdated.json");

            jsonFile.Should().NotBeNullOrEmpty();

            var updatedMovies = JsonConvert.DeserializeObject<IEnumerable<TraktRecentlyUpdatedMovie>>(jsonFile);

            updatedMovies.Should().NotBeNull().And.HaveCount(2);

            var movies = updatedMovies.ToArray();

            movies[0].UpdatedAt.Should().Be(DateTime.Parse("2016-03-31T01:29:13Z").ToUniversalTime());
            movies[0].Movie.Should().NotBeNull();

            movies[1].UpdatedAt.Should().Be(DateTime.Parse("2016-03-31T01:32:43Z").ToUniversalTime());
            movies[1].Movie.Should().NotBeNull();
        }
    }
}

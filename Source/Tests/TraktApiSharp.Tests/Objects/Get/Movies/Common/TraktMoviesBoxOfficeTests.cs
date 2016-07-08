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
    public class TraktMoviesBoxOfficeTests
    {
        [TestMethod]
        public void TestTraktMoviesBoxOfficeDefaultConstructor()
        {
            var boxOfficeMovie = new TraktBoxOfficeMovie();

            boxOfficeMovie.Revenue.Should().NotHaveValue();
            boxOfficeMovie.Movie.Should().BeNull();
        }

        [TestMethod]
        public void TestTraktMoviesBoxOfficeReadFromJson()
        {
            var jsonFile = TestUtility.ReadFileContents(@"Objects\Get\Movies\Common\MoviesBoxOffice.json");

            jsonFile.Should().NotBeNullOrEmpty();

            var boxOfficeMovies = JsonConvert.DeserializeObject<IEnumerable<TraktBoxOfficeMovie>>(jsonFile);

            boxOfficeMovies.Should().NotBeNull().And.HaveCount(2);

            var movies = boxOfficeMovies.ToArray();

            movies[0].Revenue.Should().Be(166007347);
            movies[0].Movie.Should().NotBeNull();

            movies[1].Revenue.Should().Be(24000000);
            movies[1].Movie.Should().NotBeNull();
        }
    }
}

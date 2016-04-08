namespace TraktApiSharp.Tests.Objects.Movies.Common
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    using System.Collections.Generic;
    using System.Linq;
    using TraktApiSharp.Objects.Movies.Common;
    using Utils;

    [TestClass]
    public class TraktMoviesPopularTests
    {
        [TestMethod]
        public void TestTraktMoviesPopularDefaultConstructor()
        {
            var popularShow = new TraktMoviesPopularItem();

            popularShow.Title.Should().BeNullOrEmpty();
            popularShow.Year.Should().NotHaveValue();
            popularShow.Ids.Should().BeNull();
        }

        [TestMethod]
        public void TestTraktMoviesPopularReadFromJson()
        {
            var jsonFile = TestUtility.ReadJsonData(@"Movies\Common\MoviesPopular.json");

            jsonFile.Should().NotBeNullOrEmpty();

            var popularMovies = JsonConvert.DeserializeObject<IEnumerable<TraktMoviesPopularItem>>(jsonFile);

            popularMovies.Should().NotBeNull().And.HaveCount(2);

            var movies = popularMovies.ToArray();

            movies[0].Title.Should().Be("The Dark Knight");
            movies[0].Year.Should().Be(2008);
            movies[0].Ids.Should().NotBeNull();
            movies[0].Ids.Trakt.Should().Be(120);
            movies[0].Ids.Slug.Should().Be("the-dark-knight-2008");
            movies[0].Ids.Imdb.Should().Be("tt0468569");
            movies[0].Ids.Tmdb.Should().Be(155);

            movies[1].Title.Should().Be("Inception");
            movies[1].Year.Should().Be(2010);
            movies[1].Ids.Should().NotBeNull();
            movies[1].Ids.Trakt.Should().Be(16662);
            movies[1].Ids.Slug.Should().Be("inception-2010");
            movies[1].Ids.Imdb.Should().Be("tt1375666");
            movies[1].Ids.Tmdb.Should().Be(27205);
        }
    }
}

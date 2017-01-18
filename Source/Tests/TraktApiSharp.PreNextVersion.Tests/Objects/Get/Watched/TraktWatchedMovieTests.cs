namespace TraktApiSharp.Tests.Objects.Get.Syncs.Watched
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using TraktApiSharp.Objects.Get.Watched;
    using Utils;

    [TestClass]
    public class TraktWatchedMovieTests
    {
        [TestMethod]
        public void TestTraktWatchedMovieDefaultConstructor()
        {
            var movieItem = new TraktWatchedMovie();

            movieItem.Plays.Should().NotHaveValue();
            movieItem.LastWatchedAt.Should().NotHaveValue();
            movieItem.Movie.Should().BeNull();
        }

        [TestMethod]
        public void TestTraktWatchedMovieReadFromJson()
        {
            var jsonFile = TestUtility.ReadFileContents(@"Objects\Get\Watched\WatchedMovies.json");

            jsonFile.Should().NotBeNullOrEmpty();

            var movieItems = JsonConvert.DeserializeObject<IEnumerable<TraktWatchedMovie>>(jsonFile);

            movieItems.Should().NotBeNull();
            movieItems.Should().HaveCount(2);

            var movies = movieItems.ToArray();

            movies[0].Plays.Should().Be(4);
            movies[0].LastWatchedAt.Should().Be(DateTime.Parse("2014-10-11T17:00:54.000Z").ToUniversalTime());
            movies[0].Movie.Should().NotBeNull();
            movies[0].Movie.Title.Should().Be("Batman Begins");
            movies[0].Movie.Year.Should().Be(2005);
            movies[0].Movie.Ids.Should().NotBeNull();
            movies[0].Movie.Ids.Trakt.Should().Be(6U);
            movies[0].Movie.Ids.Slug.Should().Be("batman-begins-2005");
            movies[0].Movie.Ids.Imdb.Should().Be("tt0372784");
            movies[0].Movie.Ids.Tmdb.Should().Be(272U);

            movies[1].Plays.Should().Be(2);
            movies[1].LastWatchedAt.Should().Be(DateTime.Parse("2014-10-12T17:00:54.000Z").ToUniversalTime());
            movies[1].Movie.Should().NotBeNull();
            movies[1].Movie.Title.Should().Be("The Dark Knight");
            movies[1].Movie.Year.Should().Be(2008);
            movies[1].Movie.Ids.Should().NotBeNull();
            movies[1].Movie.Ids.Trakt.Should().Be(4U);
            movies[1].Movie.Ids.Slug.Should().Be("the-dark-knight-2008");
            movies[1].Movie.Ids.Imdb.Should().Be("tt0468569");
            movies[1].Movie.Ids.Tmdb.Should().Be(155U);
        }
    }
}

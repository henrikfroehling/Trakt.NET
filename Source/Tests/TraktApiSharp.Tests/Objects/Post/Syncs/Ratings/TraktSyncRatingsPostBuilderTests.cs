namespace TraktApiSharp.Tests.Objects.Post.Syncs.Ratings
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Linq;
    using TraktApiSharp.Objects.Get.Movies;
    using TraktApiSharp.Objects.Get.Shows;
    using TraktApiSharp.Objects.Get.Shows.Episodes;
    using TraktApiSharp.Objects.Post;
    using TraktApiSharp.Objects.Post.Syncs.Ratings;

    [TestClass]
    public class TraktSyncRatingsPostBuilderTests
    {
        [TestMethod]
        public void TestTraktSyncRatingsPostBuilderAddMovie()
        {
            var movie1 = new TraktMovie
            {
                Title = "movie1",
                Year = 2016,
                Ids = new TraktMovieIds
                {
                    Trakt = 1,
                    Slug = "movie1",
                    Imdb = "imdb1",
                    Tmdb = 1234
                }
            };

            var builder = TraktSyncRatingsPost.Builder();

            builder.AddMovie(movie1);

            var ratingsPost = builder.Build();

            ratingsPost.Should().NotBeNull();
            ratingsPost.Episodes.Should().BeNull();
            ratingsPost.Shows.Should().BeNull();
            ratingsPost.Movies.Should().NotBeNull().And.HaveCount(1);

            builder.AddMovie(movie1);

            ratingsPost = builder.Build();

            ratingsPost.Should().NotBeNull();
            ratingsPost.Episodes.Should().BeNull();
            ratingsPost.Shows.Should().BeNull();
            ratingsPost.Movies.Should().NotBeNull().And.HaveCount(1);

            movie1.Ids.Trakt = 2;

            builder.AddMovie(movie1);

            ratingsPost = builder.Build();

            ratingsPost.Should().NotBeNull();
            ratingsPost.Episodes.Should().BeNull();
            ratingsPost.Shows.Should().BeNull();
            ratingsPost.Movies.Should().NotBeNull().And.HaveCount(1);

            var movies = ratingsPost.Movies.ToArray();

            movies[0].Should().NotBeNull();
            movies[0].Title.Should().Be("movie1");
            movies[0].Year.Should().Be(2016);
            movies[0].Ids.Should().NotBeNull();
            movies[0].Ids.Trakt.Should().Be(2U);
            movies[0].Ids.Slug.Should().Be("movie1");
            movies[0].Ids.Imdb.Should().Be("imdb1");
            movies[0].Ids.Tmdb.Should().Be(1234U);
            movies[0].Rating.Should().NotHaveValue();
            movies[0].RatedAt.Should().NotHaveValue();

            var movie2 = new TraktMovie
            {
                Title = "movie2",
                Year = 2016,
                Ids = new TraktMovieIds
                {
                    Trakt = 3,
                    Slug = "movie2",
                    Imdb = "imdb2",
                    Tmdb = 12345
                }
            };

            builder.AddMovie(movie2);

            ratingsPost = builder.Build();

            ratingsPost.Should().NotBeNull();
            ratingsPost.Episodes.Should().BeNull();
            ratingsPost.Shows.Should().BeNull();
            ratingsPost.Movies.Should().NotBeNull().And.HaveCount(2);

            movies = ratingsPost.Movies.ToArray();

            movies[0].Should().NotBeNull();
            movies[0].Title.Should().Be("movie1");
            movies[0].Year.Should().Be(2016);
            movies[0].Ids.Should().NotBeNull();
            movies[0].Ids.Trakt.Should().Be(2U);
            movies[0].Ids.Slug.Should().Be("movie1");
            movies[0].Ids.Imdb.Should().Be("imdb1");
            movies[0].Ids.Tmdb.Should().Be(1234U);
            movies[0].Rating.Should().NotHaveValue();
            movies[0].RatedAt.Should().NotHaveValue();

            movies[1].Should().NotBeNull();
            movies[1].Title.Should().Be("movie2");
            movies[1].Year.Should().Be(2016);
            movies[1].Ids.Should().NotBeNull();
            movies[1].Ids.Trakt.Should().Be(3U);
            movies[1].Ids.Slug.Should().Be("movie2");
            movies[1].Ids.Imdb.Should().Be("imdb2");
            movies[1].Ids.Tmdb.Should().Be(12345U);
            movies[1].Rating.Should().NotHaveValue();
            movies[1].RatedAt.Should().NotHaveValue();
        }

        [TestMethod]
        public void TestTraktSyncRatingsPostBuilderAddMovieWithRating()
        {
            var movie1 = new TraktMovie
            {
                Title = "movie1",
                Year = 2016,
                Ids = new TraktMovieIds
                {
                    Trakt = 1,
                    Slug = "movie1",
                    Imdb = "imdb1",
                    Tmdb = 1234
                }
            };

            var rating = 5;

            var builder = TraktSyncRatingsPost.Builder();

            builder.AddMovie(movie1, rating);

            var ratingsPost = builder.Build();

            ratingsPost.Should().NotBeNull();
            ratingsPost.Episodes.Should().BeNull();
            ratingsPost.Shows.Should().BeNull();
            ratingsPost.Movies.Should().NotBeNull().And.HaveCount(1);

            builder.AddMovie(movie1, rating);

            ratingsPost = builder.Build();

            ratingsPost.Should().NotBeNull();
            ratingsPost.Episodes.Should().BeNull();
            ratingsPost.Shows.Should().BeNull();
            ratingsPost.Movies.Should().NotBeNull().And.HaveCount(1);

            movie1.Ids.Trakt = 2;

            builder.AddMovie(movie1, rating);

            ratingsPost = builder.Build();

            ratingsPost.Should().NotBeNull();
            ratingsPost.Episodes.Should().BeNull();
            ratingsPost.Shows.Should().BeNull();
            ratingsPost.Movies.Should().NotBeNull().And.HaveCount(1);

            var movies = ratingsPost.Movies.ToArray();

            movies[0].Should().NotBeNull();
            movies[0].Title.Should().Be("movie1");
            movies[0].Year.Should().Be(2016);
            movies[0].Ids.Should().NotBeNull();
            movies[0].Ids.Trakt.Should().Be(2U);
            movies[0].Ids.Slug.Should().Be("movie1");
            movies[0].Ids.Imdb.Should().Be("imdb1");
            movies[0].Ids.Tmdb.Should().Be(1234U);
            movies[0].Rating.Should().HaveValue();
            movies[0].RatedAt.Should().NotHaveValue();

            var movie2 = new TraktMovie
            {
                Title = "movie2",
                Year = 2016,
                Ids = new TraktMovieIds
                {
                    Trakt = 3,
                    Slug = "movie2",
                    Imdb = "imdb2",
                    Tmdb = 12345
                }
            };

            builder.AddMovie(movie2, rating);

            ratingsPost = builder.Build();

            ratingsPost.Should().NotBeNull();
            ratingsPost.Episodes.Should().BeNull();
            ratingsPost.Shows.Should().BeNull();
            ratingsPost.Movies.Should().NotBeNull().And.HaveCount(2);

            movies = ratingsPost.Movies.ToArray();

            movies[0].Should().NotBeNull();
            movies[0].Title.Should().Be("movie1");
            movies[0].Year.Should().Be(2016);
            movies[0].Ids.Should().NotBeNull();
            movies[0].Ids.Trakt.Should().Be(2U);
            movies[0].Ids.Slug.Should().Be("movie1");
            movies[0].Ids.Imdb.Should().Be("imdb1");
            movies[0].Ids.Tmdb.Should().Be(1234U);
            movies[0].Rating.Should().HaveValue();
            movies[0].RatedAt.Should().NotHaveValue();

            movies[1].Should().NotBeNull();
            movies[1].Title.Should().Be("movie2");
            movies[1].Year.Should().Be(2016);
            movies[1].Ids.Should().NotBeNull();
            movies[1].Ids.Trakt.Should().Be(3U);
            movies[1].Ids.Slug.Should().Be("movie2");
            movies[1].Ids.Imdb.Should().Be("imdb2");
            movies[1].Ids.Tmdb.Should().Be(12345U);
            movies[1].Rating.Should().HaveValue();
            movies[1].RatedAt.Should().NotHaveValue();
        }

        [TestMethod]
        public void TestTraktSyncRatingsPostBuilderAddMovieWithRatingAndRatedAt()
        {
            var movie1 = new TraktMovie
            {
                Title = "movie1",
                Year = 2016,
                Ids = new TraktMovieIds
                {
                    Trakt = 1,
                    Slug = "movie1",
                    Imdb = "imdb1",
                    Tmdb = 1234
                }
            };

            var rating = 5;
            var ratedAt = DateTime.Now;

            var builder = TraktSyncRatingsPost.Builder();

            builder.AddMovie(movie1, rating, ratedAt);

            var ratingsPost = builder.Build();

            ratingsPost.Should().NotBeNull();
            ratingsPost.Episodes.Should().BeNull();
            ratingsPost.Shows.Should().BeNull();
            ratingsPost.Movies.Should().NotBeNull().And.HaveCount(1);

            builder.AddMovie(movie1, rating, ratedAt);

            ratingsPost = builder.Build();

            ratingsPost.Should().NotBeNull();
            ratingsPost.Episodes.Should().BeNull();
            ratingsPost.Shows.Should().BeNull();
            ratingsPost.Movies.Should().NotBeNull().And.HaveCount(1);

            movie1.Ids.Trakt = 2;

            builder.AddMovie(movie1, rating, ratedAt);

            ratingsPost = builder.Build();

            ratingsPost.Should().NotBeNull();
            ratingsPost.Episodes.Should().BeNull();
            ratingsPost.Shows.Should().BeNull();
            ratingsPost.Movies.Should().NotBeNull().And.HaveCount(1);

            var movies = ratingsPost.Movies.ToArray();

            movies[0].Should().NotBeNull();
            movies[0].Title.Should().Be("movie1");
            movies[0].Year.Should().Be(2016);
            movies[0].Ids.Should().NotBeNull();
            movies[0].Ids.Trakt.Should().Be(2U);
            movies[0].Ids.Slug.Should().Be("movie1");
            movies[0].Ids.Imdb.Should().Be("imdb1");
            movies[0].Ids.Tmdb.Should().Be(1234U);
            movies[0].Rating.Should().HaveValue();
            movies[0].RatedAt.Should().HaveValue();

            var movie2 = new TraktMovie
            {
                Title = "movie2",
                Year = 2016,
                Ids = new TraktMovieIds
                {
                    Trakt = 3,
                    Slug = "movie2",
                    Imdb = "imdb2",
                    Tmdb = 12345
                }
            };

            builder.AddMovie(movie2, rating, ratedAt);

            ratingsPost = builder.Build();

            ratingsPost.Should().NotBeNull();
            ratingsPost.Episodes.Should().BeNull();
            ratingsPost.Shows.Should().BeNull();
            ratingsPost.Movies.Should().NotBeNull().And.HaveCount(2);

            movies = ratingsPost.Movies.ToArray();

            movies[0].Should().NotBeNull();
            movies[0].Title.Should().Be("movie1");
            movies[0].Year.Should().Be(2016);
            movies[0].Ids.Should().NotBeNull();
            movies[0].Ids.Trakt.Should().Be(2U);
            movies[0].Ids.Slug.Should().Be("movie1");
            movies[0].Ids.Imdb.Should().Be("imdb1");
            movies[0].Ids.Tmdb.Should().Be(1234U);
            movies[0].Rating.Should().HaveValue();
            movies[0].RatedAt.Should().HaveValue();

            movies[1].Should().NotBeNull();
            movies[1].Title.Should().Be("movie2");
            movies[1].Year.Should().Be(2016);
            movies[1].Ids.Should().NotBeNull();
            movies[1].Ids.Trakt.Should().Be(3U);
            movies[1].Ids.Slug.Should().Be("movie2");
            movies[1].Ids.Imdb.Should().Be("imdb2");
            movies[1].Ids.Tmdb.Should().Be(12345U);
            movies[1].Rating.Should().HaveValue();
            movies[1].RatedAt.Should().HaveValue();
        }

        [TestMethod]
        public void TestTraktSyncRatingsPostBuilderAddMovieArgumentExceptions()
        {
            var builder = TraktSyncRatingsPost.Builder();

            Action act = () => builder.AddMovie(null);
            act.ShouldThrow<ArgumentNullException>();

            act = () => builder.AddMovie(new TraktMovie());
            act.ShouldThrow<ArgumentNullException>();

            act = () => builder.AddMovie(new TraktMovie { Ids = new TraktMovieIds() });
            act.ShouldThrow<ArgumentException>();

            act = () => builder.AddMovie(new TraktMovie { Ids = new TraktMovieIds { Trakt = 1 }, Year = 123 });
            act.ShouldThrow<ArgumentException>();

            act = () => builder.AddMovie(new TraktMovie { Ids = new TraktMovieIds { Trakt = 1 }, Year = 12345 });
            act.ShouldThrow<ArgumentException>();
        }

        [TestMethod]
        public void TestTraktSyncRatingsPostBuilderAddMovieWithRatingArgumentExceptions()
        {
            var builder = TraktSyncRatingsPost.Builder();

            var rating = 5;

            Action act = () => builder.AddMovie(null, rating);
            act.ShouldThrow<ArgumentNullException>();

            act = () => builder.AddMovie(new TraktMovie(), rating);
            act.ShouldThrow<ArgumentNullException>();

            act = () => builder.AddMovie(new TraktMovie { Ids = new TraktMovieIds() }, rating);
            act.ShouldThrow<ArgumentException>();

            act = () => builder.AddMovie(new TraktMovie { Ids = new TraktMovieIds { Trakt = 1 }, Year = 123 }, rating);
            act.ShouldThrow<ArgumentException>();

            act = () => builder.AddMovie(new TraktMovie { Ids = new TraktMovieIds { Trakt = 1 }, Year = 12345 }, rating);
            act.ShouldThrow<ArgumentException>();

            act = () => builder.AddMovie(new TraktMovie { Ids = new TraktMovieIds { Trakt = 1 } }, 0);
            act.ShouldThrow<ArgumentOutOfRangeException>();

            act = () => builder.AddMovie(new TraktMovie { Ids = new TraktMovieIds { Trakt = 1 } }, 11);
            act.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [TestMethod]
        public void TestTraktSyncRatingsPostBuilderAddMovieWithRatingAndRatedAtArgumentExceptions()
        {
            var builder = TraktSyncRatingsPost.Builder();

            var rating = 5;
            var ratedAt = DateTime.Now;

            Action act = () => builder.AddMovie(null, rating, ratedAt);
            act.ShouldThrow<ArgumentNullException>();

            act = () => builder.AddMovie(new TraktMovie(), rating, ratedAt);
            act.ShouldThrow<ArgumentNullException>();

            act = () => builder.AddMovie(new TraktMovie { Ids = new TraktMovieIds() }, rating, ratedAt);
            act.ShouldThrow<ArgumentException>();

            act = () => builder.AddMovie(new TraktMovie { Ids = new TraktMovieIds { Trakt = 1 }, Year = 123 }, rating, ratedAt);
            act.ShouldThrow<ArgumentException>();

            act = () => builder.AddMovie(new TraktMovie { Ids = new TraktMovieIds { Trakt = 1 }, Year = 12345 }, rating, ratedAt);
            act.ShouldThrow<ArgumentException>();

            act = () => builder.AddMovie(new TraktMovie { Ids = new TraktMovieIds { Trakt = 1 } }, 0, ratedAt);
            act.ShouldThrow<ArgumentOutOfRangeException>();

            act = () => builder.AddMovie(new TraktMovie { Ids = new TraktMovieIds { Trakt = 1 } }, 11, ratedAt);
            act.ShouldThrow<ArgumentOutOfRangeException>();
        }

        // ----------------------------------------------------------------------------------------
        // ----------------------------------------------------------------------------------------

        [TestMethod]
        public void TestTraktSyncRatingsPostBuilderAddEpisode()
        {
            var episode1 = new TraktEpisode
            {
                Ids = new TraktEpisodeIds
                {
                    Trakt = 1,
                    Imdb = "imdb1",
                    Tmdb = 1234,
                    Tvdb = 12345,
                    TvRage = 123456
                }
            };

            var builder = TraktSyncRatingsPost.Builder();

            builder.AddEpisode(episode1);

            var ratingsPost = builder.Build();

            ratingsPost.Should().NotBeNull();
            ratingsPost.Episodes.Should().NotBeNull().And.HaveCount(1);
            ratingsPost.Shows.Should().BeNull();
            ratingsPost.Movies.Should().BeNull();

            builder.AddEpisode(episode1);

            ratingsPost = builder.Build();

            ratingsPost.Should().NotBeNull();
            ratingsPost.Episodes.Should().NotBeNull().And.HaveCount(1);
            ratingsPost.Shows.Should().BeNull();
            ratingsPost.Movies.Should().BeNull();

            episode1.Ids.Trakt = 2;

            builder.AddEpisode(episode1);

            ratingsPost = builder.Build();

            ratingsPost.Should().NotBeNull();
            ratingsPost.Episodes.Should().NotBeNull().And.HaveCount(1);
            ratingsPost.Shows.Should().BeNull();
            ratingsPost.Movies.Should().BeNull();

            var episodes = ratingsPost.Episodes.ToArray();

            episodes[0].Should().NotBeNull();
            episodes[0].Ids.Should().NotBeNull();
            episodes[0].Ids.Trakt.Should().Be(2U);
            episodes[0].Ids.Imdb.Should().Be("imdb1");
            episodes[0].Ids.Tmdb.Should().Be(1234U);
            episodes[0].Ids.Tvdb.Should().Be(12345U);
            episodes[0].Ids.TvRage.Should().Be(123456U);
            episodes[0].Rating.Should().NotHaveValue();
            episodes[0].RatedAt.Should().NotHaveValue();

            var episode2 = new TraktEpisode
            {
                Ids = new TraktEpisodeIds
                {
                    Trakt = 3,
                    Imdb = "imdb2",
                    Tmdb = 12345,
                    Tvdb = 123456,
                    TvRage = 1234567
                }
            };

            builder.AddEpisode(episode2);

            ratingsPost = builder.Build();

            ratingsPost.Should().NotBeNull();
            ratingsPost.Episodes.Should().NotBeNull().And.HaveCount(2);
            ratingsPost.Shows.Should().BeNull();
            ratingsPost.Movies.Should().BeNull();

            episodes = ratingsPost.Episodes.ToArray();

            episodes[0].Should().NotBeNull();
            episodes[0].Ids.Should().NotBeNull();
            episodes[0].Ids.Trakt.Should().Be(2U);
            episodes[0].Ids.Imdb.Should().Be("imdb1");
            episodes[0].Ids.Tmdb.Should().Be(1234U);
            episodes[0].Ids.Tvdb.Should().Be(12345U);
            episodes[0].Rating.Should().NotHaveValue();
            episodes[0].RatedAt.Should().NotHaveValue();

            episodes[1].Should().NotBeNull();
            episodes[1].Ids.Should().NotBeNull();
            episodes[1].Ids.Trakt.Should().Be(3U);
            episodes[1].Ids.Imdb.Should().Be("imdb2");
            episodes[1].Ids.Tmdb.Should().Be(12345U);
            episodes[1].Ids.Tvdb.Should().Be(123456U);
            episodes[1].Rating.Should().NotHaveValue();
            episodes[1].RatedAt.Should().NotHaveValue();
        }

        [TestMethod]
        public void TestTraktSyncRatingsPostBuilderAddEpisodeWithRating()
        {
            var episode1 = new TraktEpisode
            {
                Ids = new TraktEpisodeIds
                {
                    Trakt = 1,
                    Imdb = "imdb1",
                    Tmdb = 1234,
                    Tvdb = 12345,
                    TvRage = 123456
                }
            };

            var rating = 5;

            var builder = TraktSyncRatingsPost.Builder();

            builder.AddEpisode(episode1, rating);

            var ratingsPost = builder.Build();

            ratingsPost.Should().NotBeNull();
            ratingsPost.Episodes.Should().NotBeNull().And.HaveCount(1);
            ratingsPost.Shows.Should().BeNull();
            ratingsPost.Movies.Should().BeNull();

            builder.AddEpisode(episode1, rating);

            ratingsPost = builder.Build();

            ratingsPost.Should().NotBeNull();
            ratingsPost.Episodes.Should().NotBeNull().And.HaveCount(1);
            ratingsPost.Shows.Should().BeNull();
            ratingsPost.Movies.Should().BeNull();

            episode1.Ids.Trakt = 2;

            builder.AddEpisode(episode1, rating);

            ratingsPost = builder.Build();

            ratingsPost.Should().NotBeNull();
            ratingsPost.Episodes.Should().NotBeNull().And.HaveCount(1);
            ratingsPost.Shows.Should().BeNull();
            ratingsPost.Movies.Should().BeNull();

            var episodes = ratingsPost.Episodes.ToArray();

            episodes[0].Should().NotBeNull();
            episodes[0].Ids.Should().NotBeNull();
            episodes[0].Ids.Trakt.Should().Be(2U);
            episodes[0].Ids.Imdb.Should().Be("imdb1");
            episodes[0].Ids.Tmdb.Should().Be(1234U);
            episodes[0].Ids.Tvdb.Should().Be(12345U);
            episodes[0].Ids.TvRage.Should().Be(123456U);
            episodes[0].Rating.Should().HaveValue();
            episodes[0].RatedAt.Should().NotHaveValue();

            var episode2 = new TraktEpisode
            {
                Ids = new TraktEpisodeIds
                {
                    Trakt = 3,
                    Imdb = "imdb2",
                    Tmdb = 12345,
                    Tvdb = 123456,
                    TvRage = 1234567
                }
            };

            builder.AddEpisode(episode2, rating);

            ratingsPost = builder.Build();

            ratingsPost.Should().NotBeNull();
            ratingsPost.Episodes.Should().NotBeNull().And.HaveCount(2);
            ratingsPost.Shows.Should().BeNull();
            ratingsPost.Movies.Should().BeNull();

            episodes = ratingsPost.Episodes.ToArray();

            episodes[0].Should().NotBeNull();
            episodes[0].Ids.Should().NotBeNull();
            episodes[0].Ids.Trakt.Should().Be(2U);
            episodes[0].Ids.Imdb.Should().Be("imdb1");
            episodes[0].Ids.Tmdb.Should().Be(1234U);
            episodes[0].Ids.Tvdb.Should().Be(12345U);
            episodes[0].Rating.Should().HaveValue();
            episodes[0].RatedAt.Should().NotHaveValue();

            episodes[1].Should().NotBeNull();
            episodes[1].Ids.Should().NotBeNull();
            episodes[1].Ids.Trakt.Should().Be(3U);
            episodes[1].Ids.Imdb.Should().Be("imdb2");
            episodes[1].Ids.Tmdb.Should().Be(12345U);
            episodes[1].Ids.Tvdb.Should().Be(123456U);
            episodes[1].Rating.Should().HaveValue();
            episodes[1].RatedAt.Should().NotHaveValue();
        }

        [TestMethod]
        public void TestTraktSyncRatingsPostBuilderAddEpisodeWithRatingAndRatedAt()
        {
            var episode1 = new TraktEpisode
            {
                Ids = new TraktEpisodeIds
                {
                    Trakt = 1,
                    Imdb = "imdb1",
                    Tmdb = 1234,
                    Tvdb = 12345,
                    TvRage = 123456
                }
            };

            var rating = 5;
            var ratedAt = DateTime.Now;

            var builder = TraktSyncRatingsPost.Builder();

            builder.AddEpisode(episode1, rating, ratedAt);

            var ratingsPost = builder.Build();

            ratingsPost.Should().NotBeNull();
            ratingsPost.Episodes.Should().NotBeNull().And.HaveCount(1);
            ratingsPost.Shows.Should().BeNull();
            ratingsPost.Movies.Should().BeNull();

            builder.AddEpisode(episode1, rating, ratedAt);

            ratingsPost = builder.Build();

            ratingsPost.Should().NotBeNull();
            ratingsPost.Episodes.Should().NotBeNull().And.HaveCount(1);
            ratingsPost.Shows.Should().BeNull();
            ratingsPost.Movies.Should().BeNull();

            episode1.Ids.Trakt = 2;

            builder.AddEpisode(episode1, rating, ratedAt);

            ratingsPost = builder.Build();

            ratingsPost.Should().NotBeNull();
            ratingsPost.Episodes.Should().NotBeNull().And.HaveCount(1);
            ratingsPost.Shows.Should().BeNull();
            ratingsPost.Movies.Should().BeNull();

            var episodes = ratingsPost.Episodes.ToArray();

            episodes[0].Should().NotBeNull();
            episodes[0].Ids.Should().NotBeNull();
            episodes[0].Ids.Trakt.Should().Be(2U);
            episodes[0].Ids.Imdb.Should().Be("imdb1");
            episodes[0].Ids.Tmdb.Should().Be(1234U);
            episodes[0].Ids.Tvdb.Should().Be(12345U);
            episodes[0].Ids.TvRage.Should().Be(123456U);
            episodes[0].Rating.Should().HaveValue();
            episodes[0].RatedAt.Should().HaveValue();

            var episode2 = new TraktEpisode
            {
                Ids = new TraktEpisodeIds
                {
                    Trakt = 3,
                    Imdb = "imdb2",
                    Tmdb = 12345,
                    Tvdb = 123456,
                    TvRage = 1234567
                }
            };

            builder.AddEpisode(episode2, rating, ratedAt);

            ratingsPost = builder.Build();

            ratingsPost.Should().NotBeNull();
            ratingsPost.Episodes.Should().NotBeNull().And.HaveCount(2);
            ratingsPost.Shows.Should().BeNull();
            ratingsPost.Movies.Should().BeNull();

            episodes = ratingsPost.Episodes.ToArray();

            episodes[0].Should().NotBeNull();
            episodes[0].Ids.Should().NotBeNull();
            episodes[0].Ids.Trakt.Should().Be(2U);
            episodes[0].Ids.Imdb.Should().Be("imdb1");
            episodes[0].Ids.Tmdb.Should().Be(1234U);
            episodes[0].Ids.Tvdb.Should().Be(12345U);
            episodes[0].Rating.Should().HaveValue();
            episodes[0].RatedAt.Should().HaveValue();

            episodes[1].Should().NotBeNull();
            episodes[1].Ids.Should().NotBeNull();
            episodes[1].Ids.Trakt.Should().Be(3U);
            episodes[1].Ids.Imdb.Should().Be("imdb2");
            episodes[1].Ids.Tmdb.Should().Be(12345U);
            episodes[1].Ids.Tvdb.Should().Be(123456U);
            episodes[1].Rating.Should().HaveValue();
            episodes[1].RatedAt.Should().HaveValue();
        }

        [TestMethod]
        public void TestTraktSyncRatingsPostBuilderAddEpisodeArgumentExceptions()
        {
            var builder = TraktSyncRatingsPost.Builder();

            Action act = () => builder.AddEpisode(null);
            act.ShouldThrow<ArgumentNullException>();

            act = () => builder.AddEpisode(new TraktEpisode());
            act.ShouldThrow<ArgumentNullException>();

            act = () => builder.AddEpisode(new TraktEpisode { Ids = new TraktEpisodeIds() });
            act.ShouldThrow<ArgumentException>();
        }

        [TestMethod]
        public void TestTraktSyncRatingsPostBuilderAddEpisodeWithRatingArgumentExceptions()
        {
            var builder = TraktSyncRatingsPost.Builder();

            var rating = 5;

            Action act = () => builder.AddEpisode(null, rating);
            act.ShouldThrow<ArgumentNullException>();

            act = () => builder.AddEpisode(new TraktEpisode(), rating);
            act.ShouldThrow<ArgumentNullException>();

            act = () => builder.AddEpisode(new TraktEpisode { Ids = new TraktEpisodeIds() }, rating);
            act.ShouldThrow<ArgumentException>();

            act = () => builder.AddEpisode(new TraktEpisode { Ids = new TraktEpisodeIds { Trakt = 1 } }, 0);
            act.ShouldThrow<ArgumentOutOfRangeException>();

            act = () => builder.AddEpisode(new TraktEpisode { Ids = new TraktEpisodeIds { Trakt = 1 } }, 11);
            act.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [TestMethod]
        public void TestTraktSyncRatingsPostBuilderAddEpisodeWithRatingAndRatedAtArgumentExceptions()
        {
            var builder = TraktSyncRatingsPost.Builder();

            var rating = 5;
            var ratedAt = DateTime.Now;

            Action act = () => builder.AddEpisode(null, rating, ratedAt);
            act.ShouldThrow<ArgumentNullException>();

            act = () => builder.AddEpisode(new TraktEpisode(), rating, ratedAt);
            act.ShouldThrow<ArgumentNullException>();

            act = () => builder.AddEpisode(new TraktEpisode { Ids = new TraktEpisodeIds() }, rating, ratedAt);
            act.ShouldThrow<ArgumentException>();

            act = () => builder.AddEpisode(new TraktEpisode { Ids = new TraktEpisodeIds { Trakt = 1 } }, 0, ratedAt);
            act.ShouldThrow<ArgumentOutOfRangeException>();

            act = () => builder.AddEpisode(new TraktEpisode { Ids = new TraktEpisodeIds { Trakt = 1 } }, 11, ratedAt);
            act.ShouldThrow<ArgumentOutOfRangeException>();
        }

        // ----------------------------------------------------------------------------------------
        // ----------------------------------------------------------------------------------------

        [TestMethod]
        public void TestTraktSyncRatingsPostBuilderAddShow()
        {
            var show1 = new TraktShow
            {
                Title = "show1",
                Year = 2016,
                Ids = new TraktShowIds
                {
                    Trakt = 1,
                    Slug = "show1",
                    Imdb = "imdb1",
                    Tmdb = 1234,
                    Tvdb = 12345,
                    TvRage = 123456
                }
            };

            var builder = TraktSyncRatingsPost.Builder();

            builder.AddShow(show1);

            var ratingsPost = builder.Build();

            ratingsPost.Should().NotBeNull();
            ratingsPost.Episodes.Should().BeNull();
            ratingsPost.Shows.Should().NotBeNull().And.HaveCount(1);
            ratingsPost.Movies.Should().BeNull();

            builder.AddShow(show1);

            ratingsPost = builder.Build();

            ratingsPost.Should().NotBeNull();
            ratingsPost.Episodes.Should().BeNull();
            ratingsPost.Shows.Should().NotBeNull().And.HaveCount(1);
            ratingsPost.Movies.Should().BeNull();

            show1.Ids.Trakt = 2;

            builder.AddShow(show1);

            ratingsPost = builder.Build();

            ratingsPost.Should().NotBeNull();
            ratingsPost.Episodes.Should().BeNull();
            ratingsPost.Shows.Should().NotBeNull().And.HaveCount(1);
            ratingsPost.Movies.Should().BeNull();

            var shows = ratingsPost.Shows.ToArray();

            shows[0].Should().NotBeNull();
            shows[0].Title.Should().Be("show1");
            shows[0].Year.Should().Be(2016);
            shows[0].Ids.Should().NotBeNull();
            shows[0].Ids.Trakt.Should().Be(2U);
            shows[0].Ids.Slug.Should().Be("show1");
            shows[0].Ids.Imdb.Should().Be("imdb1");
            shows[0].Ids.Tmdb.Should().Be(1234U);
            shows[0].Ids.Tvdb.Should().Be(12345U);
            shows[0].Ids.TvRage.Should().Be(123456U);
            shows[0].Rating.Should().NotHaveValue();
            shows[0].RatedAt.Should().NotHaveValue();
            shows[0].Seasons.Should().BeNull();

            var show2 = new TraktShow
            {
                Title = "show2",
                Year = 2016,
                Ids = new TraktShowIds
                {
                    Trakt = 3,
                    Slug = "show2",
                    Imdb = "imdb2",
                    Tmdb = 12345,
                    Tvdb = 123456,
                    TvRage = 1234567
                }
            };

            builder.AddShow(show2);

            ratingsPost = builder.Build();

            ratingsPost.Should().NotBeNull();
            ratingsPost.Episodes.Should().BeNull();
            ratingsPost.Shows.Should().NotBeNull().And.HaveCount(2);
            ratingsPost.Movies.Should().BeNull();

            shows = ratingsPost.Shows.ToArray();

            shows[0].Should().NotBeNull();
            shows[0].Title.Should().Be("show1");
            shows[0].Year.Should().Be(2016);
            shows[0].Ids.Should().NotBeNull();
            shows[0].Ids.Trakt.Should().Be(2U);
            shows[0].Ids.Slug.Should().Be("show1");
            shows[0].Ids.Imdb.Should().Be("imdb1");
            shows[0].Ids.Tmdb.Should().Be(1234U);
            shows[0].Ids.Tvdb.Should().Be(12345U);
            shows[0].Ids.TvRage.Should().Be(123456U);
            shows[0].Rating.Should().NotHaveValue();
            shows[0].RatedAt.Should().NotHaveValue();
            shows[0].Seasons.Should().BeNull();

            shows[1].Should().NotBeNull();
            shows[1].Title.Should().Be("show2");
            shows[1].Year.Should().Be(2016);
            shows[1].Ids.Should().NotBeNull();
            shows[1].Ids.Trakt.Should().Be(3U);
            shows[1].Ids.Slug.Should().Be("show2");
            shows[1].Ids.Imdb.Should().Be("imdb2");
            shows[1].Ids.Tmdb.Should().Be(12345U);
            shows[1].Ids.Tvdb.Should().Be(123456U);
            shows[1].Ids.TvRage.Should().Be(1234567U);
            shows[1].Rating.Should().NotHaveValue();
            shows[1].RatedAt.Should().NotHaveValue();
            shows[1].Seasons.Should().BeNull();
        }

        [TestMethod]
        public void TestTraktSyncRatingsPostBuilderAddShowWithRating()
        {
            var show1 = new TraktShow
            {
                Title = "show1",
                Year = 2016,
                Ids = new TraktShowIds
                {
                    Trakt = 1,
                    Slug = "show1",
                    Imdb = "imdb1",
                    Tmdb = 1234,
                    Tvdb = 12345,
                    TvRage = 123456
                }
            };

            var rating = 5;

            var builder = TraktSyncRatingsPost.Builder();

            builder.AddShowWithRating(show1, rating);

            var ratingsPost = builder.Build();

            ratingsPost.Should().NotBeNull();
            ratingsPost.Episodes.Should().BeNull();
            ratingsPost.Shows.Should().NotBeNull().And.HaveCount(1);
            ratingsPost.Movies.Should().BeNull();

            builder.AddShowWithRating(show1, rating);

            ratingsPost = builder.Build();

            ratingsPost.Should().NotBeNull();
            ratingsPost.Episodes.Should().BeNull();
            ratingsPost.Shows.Should().NotBeNull().And.HaveCount(1);
            ratingsPost.Movies.Should().BeNull();

            show1.Ids.Trakt = 2;

            builder.AddShowWithRating(show1, rating);

            ratingsPost = builder.Build();

            ratingsPost.Should().NotBeNull();
            ratingsPost.Episodes.Should().BeNull();
            ratingsPost.Shows.Should().NotBeNull().And.HaveCount(1);
            ratingsPost.Movies.Should().BeNull();

            var shows = ratingsPost.Shows.ToArray();

            shows[0].Should().NotBeNull();
            shows[0].Title.Should().Be("show1");
            shows[0].Year.Should().Be(2016);
            shows[0].Ids.Should().NotBeNull();
            shows[0].Ids.Trakt.Should().Be(2U);
            shows[0].Ids.Slug.Should().Be("show1");
            shows[0].Ids.Imdb.Should().Be("imdb1");
            shows[0].Ids.Tmdb.Should().Be(1234U);
            shows[0].Ids.Tvdb.Should().Be(12345U);
            shows[0].Ids.TvRage.Should().Be(123456U);
            shows[0].Rating.Should().HaveValue();
            shows[0].RatedAt.Should().NotHaveValue();
            shows[0].Seasons.Should().BeNull();

            var show2 = new TraktShow
            {
                Title = "show2",
                Year = 2016,
                Ids = new TraktShowIds
                {
                    Trakt = 3,
                    Slug = "show2",
                    Imdb = "imdb2",
                    Tmdb = 12345,
                    Tvdb = 123456,
                    TvRage = 1234567
                }
            };

            builder.AddShowWithRating(show2, rating);

            ratingsPost = builder.Build();

            ratingsPost.Should().NotBeNull();
            ratingsPost.Episodes.Should().BeNull();
            ratingsPost.Shows.Should().NotBeNull().And.HaveCount(2);
            ratingsPost.Movies.Should().BeNull();

            shows = ratingsPost.Shows.ToArray();

            shows[0].Should().NotBeNull();
            shows[0].Title.Should().Be("show1");
            shows[0].Year.Should().Be(2016);
            shows[0].Ids.Should().NotBeNull();
            shows[0].Ids.Trakt.Should().Be(2U);
            shows[0].Ids.Slug.Should().Be("show1");
            shows[0].Ids.Imdb.Should().Be("imdb1");
            shows[0].Ids.Tmdb.Should().Be(1234U);
            shows[0].Ids.Tvdb.Should().Be(12345U);
            shows[0].Ids.TvRage.Should().Be(123456U);
            shows[0].Rating.Should().HaveValue();
            shows[0].RatedAt.Should().NotHaveValue();
            shows[0].Seasons.Should().BeNull();

            shows[1].Should().NotBeNull();
            shows[1].Title.Should().Be("show2");
            shows[1].Year.Should().Be(2016);
            shows[1].Ids.Should().NotBeNull();
            shows[1].Ids.Trakt.Should().Be(3U);
            shows[1].Ids.Slug.Should().Be("show2");
            shows[1].Ids.Imdb.Should().Be("imdb2");
            shows[1].Ids.Tmdb.Should().Be(12345U);
            shows[1].Ids.Tvdb.Should().Be(123456U);
            shows[1].Ids.TvRage.Should().Be(1234567U);
            shows[1].Rating.Should().HaveValue();
            shows[1].RatedAt.Should().NotHaveValue();
            shows[1].Seasons.Should().BeNull();
        }

        [TestMethod]
        public void TestTraktSyncRatingsPostBuilderAddShowWithRatingAndRatedAt()
        {
            var show1 = new TraktShow
            {
                Title = "show1",
                Year = 2016,
                Ids = new TraktShowIds
                {
                    Trakt = 1,
                    Slug = "show1",
                    Imdb = "imdb1",
                    Tmdb = 1234,
                    Tvdb = 12345,
                    TvRage = 123456
                }
            };

            var rating = 5;
            var ratedAt = DateTime.Now;

            var builder = TraktSyncRatingsPost.Builder();

            builder.AddShowWithRating(show1, rating, ratedAt);

            var ratingsPost = builder.Build();

            ratingsPost.Should().NotBeNull();
            ratingsPost.Episodes.Should().BeNull();
            ratingsPost.Shows.Should().NotBeNull().And.HaveCount(1);
            ratingsPost.Movies.Should().BeNull();

            builder.AddShowWithRating(show1, rating, ratedAt);

            ratingsPost = builder.Build();

            ratingsPost.Should().NotBeNull();
            ratingsPost.Episodes.Should().BeNull();
            ratingsPost.Shows.Should().NotBeNull().And.HaveCount(1);
            ratingsPost.Movies.Should().BeNull();

            show1.Ids.Trakt = 2;

            builder.AddShowWithRating(show1, rating, ratedAt);

            ratingsPost = builder.Build();

            ratingsPost.Should().NotBeNull();
            ratingsPost.Episodes.Should().BeNull();
            ratingsPost.Shows.Should().NotBeNull().And.HaveCount(1);
            ratingsPost.Movies.Should().BeNull();

            var shows = ratingsPost.Shows.ToArray();

            shows[0].Should().NotBeNull();
            shows[0].Title.Should().Be("show1");
            shows[0].Year.Should().Be(2016);
            shows[0].Ids.Should().NotBeNull();
            shows[0].Ids.Trakt.Should().Be(2U);
            shows[0].Ids.Slug.Should().Be("show1");
            shows[0].Ids.Imdb.Should().Be("imdb1");
            shows[0].Ids.Tmdb.Should().Be(1234U);
            shows[0].Ids.Tvdb.Should().Be(12345U);
            shows[0].Ids.TvRage.Should().Be(123456U);
            shows[0].Rating.Should().HaveValue();
            shows[0].RatedAt.Should().HaveValue();
            shows[0].Seasons.Should().BeNull();

            var show2 = new TraktShow
            {
                Title = "show2",
                Year = 2016,
                Ids = new TraktShowIds
                {
                    Trakt = 3,
                    Slug = "show2",
                    Imdb = "imdb2",
                    Tmdb = 12345,
                    Tvdb = 123456,
                    TvRage = 1234567
                }
            };

            builder.AddShowWithRating(show2, rating, ratedAt);

            ratingsPost = builder.Build();

            ratingsPost.Should().NotBeNull();
            ratingsPost.Episodes.Should().BeNull();
            ratingsPost.Shows.Should().NotBeNull().And.HaveCount(2);
            ratingsPost.Movies.Should().BeNull();

            shows = ratingsPost.Shows.ToArray();

            shows[0].Should().NotBeNull();
            shows[0].Title.Should().Be("show1");
            shows[0].Year.Should().Be(2016);
            shows[0].Ids.Should().NotBeNull();
            shows[0].Ids.Trakt.Should().Be(2U);
            shows[0].Ids.Slug.Should().Be("show1");
            shows[0].Ids.Imdb.Should().Be("imdb1");
            shows[0].Ids.Tmdb.Should().Be(1234U);
            shows[0].Ids.Tvdb.Should().Be(12345U);
            shows[0].Ids.TvRage.Should().Be(123456U);
            shows[0].Rating.Should().HaveValue();
            shows[0].RatedAt.Should().HaveValue();
            shows[0].Seasons.Should().BeNull();

            shows[1].Should().NotBeNull();
            shows[1].Title.Should().Be("show2");
            shows[1].Year.Should().Be(2016);
            shows[1].Ids.Should().NotBeNull();
            shows[1].Ids.Trakt.Should().Be(3U);
            shows[1].Ids.Slug.Should().Be("show2");
            shows[1].Ids.Imdb.Should().Be("imdb2");
            shows[1].Ids.Tmdb.Should().Be(12345U);
            shows[1].Ids.Tvdb.Should().Be(123456U);
            shows[1].Ids.TvRage.Should().Be(1234567U);
            shows[1].Rating.Should().HaveValue();
            shows[1].RatedAt.Should().HaveValue();
            shows[1].Seasons.Should().BeNull();
        }

        [TestMethod]
        public void TestTraktSyncRatingsPostBuilderAddShowArgumentExceptions()
        {
            var builder = TraktSyncRatingsPost.Builder();

            Action act = () => builder.AddShow(null);
            act.ShouldThrow<ArgumentNullException>();

            act = () => builder.AddShow(new TraktShow());
            act.ShouldThrow<ArgumentNullException>();

            act = () => builder.AddShow(new TraktShow { Ids = new TraktShowIds() });
            act.ShouldThrow<ArgumentException>();

            act = () => builder.AddShow(new TraktShow { Ids = new TraktShowIds { Trakt = 1 }, Year = 123 });
            act.ShouldThrow<ArgumentException>();

            act = () => builder.AddShow(new TraktShow { Ids = new TraktShowIds { Trakt = 1 }, Year = 12345 });
            act.ShouldThrow<ArgumentException>();
        }

        [TestMethod]
        public void TestTraktSyncRatingsPostBuilderAddShowWithRatingArgumentExceptions()
        {
            var builder = TraktSyncRatingsPost.Builder();

            var rating = 5;

            Action act = () => builder.AddShowWithRating(null, rating);
            act.ShouldThrow<ArgumentNullException>();

            act = () => builder.AddShowWithRating(new TraktShow(), rating);
            act.ShouldThrow<ArgumentNullException>();

            act = () => builder.AddShowWithRating(new TraktShow { Ids = new TraktShowIds() }, rating);
            act.ShouldThrow<ArgumentException>();

            act = () => builder.AddShowWithRating(new TraktShow { Ids = new TraktShowIds { Trakt = 1 }, Year = 123 }, rating);
            act.ShouldThrow<ArgumentException>();

            act = () => builder.AddShowWithRating(new TraktShow { Ids = new TraktShowIds { Trakt = 1 }, Year = 12345 }, rating);
            act.ShouldThrow<ArgumentException>();

            act = () => builder.AddShowWithRating(new TraktShow { Ids = new TraktShowIds { Trakt = 1 } }, 0);
            act.ShouldThrow<ArgumentOutOfRangeException>();

            act = () => builder.AddShowWithRating(new TraktShow { Ids = new TraktShowIds { Trakt = 1 } }, 11);
            act.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [TestMethod]
        public void TestTraktSyncRatingsPostBuilderAddShowWithRatingAndRatedAtArgumentExceptions()
        {
            var builder = TraktSyncRatingsPost.Builder();

            var rating = 5;
            var ratedAt = DateTime.Now;

            Action act = () => builder.AddShowWithRating(null, rating, ratedAt);
            act.ShouldThrow<ArgumentNullException>();

            act = () => builder.AddShowWithRating(new TraktShow(), rating, ratedAt);
            act.ShouldThrow<ArgumentNullException>();

            act = () => builder.AddShowWithRating(new TraktShow { Ids = new TraktShowIds() }, rating, ratedAt);
            act.ShouldThrow<ArgumentException>();

            act = () => builder.AddShowWithRating(new TraktShow { Ids = new TraktShowIds { Trakt = 1 }, Year = 123 }, rating, ratedAt);
            act.ShouldThrow<ArgumentException>();

            act = () => builder.AddShowWithRating(new TraktShow { Ids = new TraktShowIds { Trakt = 1 }, Year = 12345 }, rating, ratedAt);
            act.ShouldThrow<ArgumentException>();

            act = () => builder.AddShowWithRating(new TraktShow { Ids = new TraktShowIds { Trakt = 1 } }, 0, ratedAt);
            act.ShouldThrow<ArgumentOutOfRangeException>();

            act = () => builder.AddShowWithRating(new TraktShow { Ids = new TraktShowIds { Trakt = 1 } }, 11, ratedAt);
            act.ShouldThrow<ArgumentOutOfRangeException>();
        }

        // ----------------------------------------------------------------------------------------
        // ----------------------------------------------------------------------------------------

        [TestMethod]
        public void TestTraktSyncRatingsPostBuilderAddShowWithSeasons()
        {
            var show1 = new TraktShow
            {
                Title = "show1",
                Year = 2016,
                Ids = new TraktShowIds
                {
                    Trakt = 1,
                    Slug = "show1",
                    Imdb = "imdb1",
                    Tmdb = 1234,
                    Tvdb = 12345,
                    TvRage = 123456
                }
            };

            var builder = TraktSyncRatingsPost.Builder();

            builder.AddShow(show1, 1);

            var ratingsPost = builder.Build();

            ratingsPost.Should().NotBeNull();
            ratingsPost.Episodes.Should().BeNull();
            ratingsPost.Shows.Should().NotBeNull().And.HaveCount(1);
            ratingsPost.Movies.Should().BeNull();

            var shows = ratingsPost.Shows.ToArray();

            shows[0].Should().NotBeNull();
            shows[0].Title.Should().Be("show1");
            shows[0].Year.Should().Be(2016);
            shows[0].Ids.Should().NotBeNull();
            shows[0].Ids.Trakt.Should().Be(1U);
            shows[0].Ids.Slug.Should().Be("show1");
            shows[0].Ids.Imdb.Should().Be("imdb1");
            shows[0].Ids.Tmdb.Should().Be(1234U);
            shows[0].Ids.Tvdb.Should().Be(12345U);
            shows[0].Ids.TvRage.Should().Be(123456U);
            shows[0].Rating.Should().NotHaveValue();
            shows[0].RatedAt.Should().NotHaveValue();
            shows[0].Seasons.Should().NotBeNull().And.HaveCount(1);

            var show1Seasons = shows[0].Seasons.ToArray();

            show1Seasons[0].Number.Should().Be(1);
            show1Seasons[0].Episodes.Should().BeNull();
            show1Seasons[0].Rating.Should().NotHaveValue();
            show1Seasons[0].RatedAt.Should().NotHaveValue();

            // ---------------------------------------------------------

            builder.AddShow(show1, 1, 2);

            ratingsPost = builder.Build();

            ratingsPost.Should().NotBeNull();
            ratingsPost.Episodes.Should().BeNull();
            ratingsPost.Shows.Should().NotBeNull().And.HaveCount(1);
            ratingsPost.Movies.Should().BeNull();

            shows = ratingsPost.Shows.ToArray();

            shows[0].Should().NotBeNull();
            shows[0].Title.Should().Be("show1");
            shows[0].Year.Should().Be(2016);
            shows[0].Ids.Should().NotBeNull();
            shows[0].Ids.Trakt.Should().Be(1U);
            shows[0].Ids.Slug.Should().Be("show1");
            shows[0].Ids.Imdb.Should().Be("imdb1");
            shows[0].Ids.Tmdb.Should().Be(1234U);
            shows[0].Ids.Tvdb.Should().Be(12345U);
            shows[0].Ids.TvRage.Should().Be(123456U);
            shows[0].Rating.Should().NotHaveValue();
            shows[0].RatedAt.Should().NotHaveValue();
            shows[0].Seasons.Should().NotBeNull().And.HaveCount(2);

            show1Seasons = shows[0].Seasons.ToArray();

            show1Seasons[0].Number.Should().Be(1);
            show1Seasons[0].Episodes.Should().BeNull();
            show1Seasons[0].Rating.Should().NotHaveValue();
            show1Seasons[0].RatedAt.Should().NotHaveValue();

            show1Seasons[1].Number.Should().Be(2);
            show1Seasons[1].Episodes.Should().BeNull();
            show1Seasons[1].Rating.Should().NotHaveValue();
            show1Seasons[1].RatedAt.Should().NotHaveValue();

            // ---------------------------------------------------------

            builder.AddShow(show1, 1, 2, 3);

            ratingsPost = builder.Build();

            ratingsPost.Should().NotBeNull();
            ratingsPost.Episodes.Should().BeNull();
            ratingsPost.Shows.Should().NotBeNull().And.HaveCount(1);
            ratingsPost.Movies.Should().BeNull();

            shows = ratingsPost.Shows.ToArray();

            shows[0].Should().NotBeNull();
            shows[0].Title.Should().Be("show1");
            shows[0].Year.Should().Be(2016);
            shows[0].Ids.Should().NotBeNull();
            shows[0].Ids.Trakt.Should().Be(1U);
            shows[0].Ids.Slug.Should().Be("show1");
            shows[0].Ids.Imdb.Should().Be("imdb1");
            shows[0].Ids.Tmdb.Should().Be(1234U);
            shows[0].Ids.Tvdb.Should().Be(12345U);
            shows[0].Ids.TvRage.Should().Be(123456U);
            shows[0].Rating.Should().NotHaveValue();
            shows[0].RatedAt.Should().NotHaveValue();
            shows[0].Seasons.Should().NotBeNull().And.HaveCount(3);

            show1Seasons = shows[0].Seasons.ToArray();

            show1Seasons[0].Number.Should().Be(1);
            show1Seasons[0].Episodes.Should().BeNull();
            show1Seasons[0].Rating.Should().NotHaveValue();
            show1Seasons[0].RatedAt.Should().NotHaveValue();

            show1Seasons[1].Number.Should().Be(2);
            show1Seasons[1].Episodes.Should().BeNull();
            show1Seasons[1].Rating.Should().NotHaveValue();
            show1Seasons[1].RatedAt.Should().NotHaveValue();

            show1Seasons[2].Number.Should().Be(3);
            show1Seasons[2].Episodes.Should().BeNull();
            show1Seasons[2].Rating.Should().NotHaveValue();
            show1Seasons[2].RatedAt.Should().NotHaveValue();

            // ---------------------------------------------------------

            show1.Ids.Trakt = 2;

            builder.AddShow(show1, 1, 2, 3);

            ratingsPost = builder.Build();

            ratingsPost.Should().NotBeNull();
            ratingsPost.Episodes.Should().BeNull();
            ratingsPost.Shows.Should().NotBeNull().And.HaveCount(1);
            ratingsPost.Movies.Should().BeNull();

            shows = ratingsPost.Shows.ToArray();

            shows[0].Should().NotBeNull();
            shows[0].Title.Should().Be("show1");
            shows[0].Year.Should().Be(2016);
            shows[0].Ids.Should().NotBeNull();
            shows[0].Ids.Trakt.Should().Be(2U);
            shows[0].Ids.Slug.Should().Be("show1");
            shows[0].Ids.Imdb.Should().Be("imdb1");
            shows[0].Ids.Tmdb.Should().Be(1234U);
            shows[0].Ids.Tvdb.Should().Be(12345U);
            shows[0].Ids.TvRage.Should().Be(123456U);
            shows[0].Rating.Should().NotHaveValue();
            shows[0].RatedAt.Should().NotHaveValue();
            shows[0].Seasons.Should().NotBeNull().And.HaveCount(3);

            show1Seasons = shows[0].Seasons.ToArray();

            show1Seasons[0].Number.Should().Be(1);
            show1Seasons[0].Episodes.Should().BeNull();
            show1Seasons[0].Rating.Should().NotHaveValue();
            show1Seasons[0].RatedAt.Should().NotHaveValue();

            show1Seasons[1].Number.Should().Be(2);
            show1Seasons[1].Episodes.Should().BeNull();
            show1Seasons[1].Rating.Should().NotHaveValue();
            show1Seasons[1].RatedAt.Should().NotHaveValue();

            show1Seasons[2].Number.Should().Be(3);
            show1Seasons[2].Episodes.Should().BeNull();
            show1Seasons[2].Rating.Should().NotHaveValue();
            show1Seasons[2].RatedAt.Should().NotHaveValue();

            // ---------------------------------------------------------

            var show2 = new TraktShow
            {
                Title = "show2",
                Year = 2016,
                Ids = new TraktShowIds
                {
                    Trakt = 3,
                    Slug = "show2",
                    Imdb = "imdb2",
                    Tmdb = 12345,
                    Tvdb = 123456,
                    TvRage = 1234567
                }
            };

            builder.AddShow(show2, 1, 2, 3);

            ratingsPost = builder.Build();

            ratingsPost.Should().NotBeNull();
            ratingsPost.Episodes.Should().BeNull();
            ratingsPost.Shows.Should().NotBeNull().And.HaveCount(2);
            ratingsPost.Movies.Should().BeNull();

            shows = ratingsPost.Shows.ToArray();

            shows[0].Should().NotBeNull();
            shows[0].Title.Should().Be("show1");
            shows[0].Year.Should().Be(2016);
            shows[0].Ids.Should().NotBeNull();
            shows[0].Ids.Trakt.Should().Be(2U);
            shows[0].Ids.Slug.Should().Be("show1");
            shows[0].Ids.Imdb.Should().Be("imdb1");
            shows[0].Ids.Tmdb.Should().Be(1234U);
            shows[0].Ids.Tvdb.Should().Be(12345U);
            shows[0].Ids.TvRage.Should().Be(123456U);
            shows[0].Rating.Should().NotHaveValue();
            shows[0].RatedAt.Should().NotHaveValue();
            shows[0].Seasons.Should().NotBeNull().And.HaveCount(3);

            shows[1].Should().NotBeNull();
            shows[1].Title.Should().Be("show2");
            shows[1].Year.Should().Be(2016);
            shows[1].Ids.Should().NotBeNull();
            shows[1].Ids.Trakt.Should().Be(3U);
            shows[1].Ids.Slug.Should().Be("show2");
            shows[1].Ids.Imdb.Should().Be("imdb2");
            shows[1].Ids.Tmdb.Should().Be(12345U);
            shows[1].Ids.Tvdb.Should().Be(123456U);
            shows[1].Ids.TvRage.Should().Be(1234567U);
            shows[1].Rating.Should().NotHaveValue();
            shows[1].RatedAt.Should().NotHaveValue();
            shows[1].Seasons.Should().NotBeNull().And.HaveCount(3);

            show1Seasons = shows[0].Seasons.ToArray();

            show1Seasons[0].Number.Should().Be(1);
            show1Seasons[0].Episodes.Should().BeNull();
            show1Seasons[0].Rating.Should().NotHaveValue();
            show1Seasons[0].RatedAt.Should().NotHaveValue();

            show1Seasons[1].Number.Should().Be(2);
            show1Seasons[1].Episodes.Should().BeNull();
            show1Seasons[1].Rating.Should().NotHaveValue();
            show1Seasons[1].RatedAt.Should().NotHaveValue();

            show1Seasons[2].Number.Should().Be(3);
            show1Seasons[2].Episodes.Should().BeNull();
            show1Seasons[2].Rating.Should().NotHaveValue();
            show1Seasons[2].RatedAt.Should().NotHaveValue();

            var show2Seasons = shows[1].Seasons.ToArray();

            show2Seasons[0].Number.Should().Be(1);
            show2Seasons[0].Episodes.Should().BeNull();
            show2Seasons[0].Rating.Should().NotHaveValue();
            show2Seasons[0].RatedAt.Should().NotHaveValue();

            show2Seasons[1].Number.Should().Be(2);
            show2Seasons[1].Episodes.Should().BeNull();
            show2Seasons[1].Rating.Should().NotHaveValue();
            show2Seasons[1].RatedAt.Should().NotHaveValue();

            show2Seasons[2].Number.Should().Be(3);
            show2Seasons[2].Episodes.Should().BeNull();
            show2Seasons[2].Rating.Should().NotHaveValue();
            show2Seasons[2].RatedAt.Should().NotHaveValue();
        }

        [TestMethod]
        public void TestTraktSyncRatingsPostBuilderAddShowWithSeasonsAndRating()
        {
            var show1 = new TraktShow
            {
                Title = "show1",
                Year = 2016,
                Ids = new TraktShowIds
                {
                    Trakt = 1,
                    Slug = "show1",
                    Imdb = "imdb1",
                    Tmdb = 1234,
                    Tvdb = 12345,
                    TvRage = 123456
                }
            };

            var rating = 5;

            var builder = TraktSyncRatingsPost.Builder();

            builder.AddShowWithRating(show1, rating, 1);

            var ratingsPost = builder.Build();

            ratingsPost.Should().NotBeNull();
            ratingsPost.Episodes.Should().BeNull();
            ratingsPost.Shows.Should().NotBeNull().And.HaveCount(1);
            ratingsPost.Movies.Should().BeNull();

            var shows = ratingsPost.Shows.ToArray();

            shows[0].Should().NotBeNull();
            shows[0].Title.Should().Be("show1");
            shows[0].Year.Should().Be(2016);
            shows[0].Ids.Should().NotBeNull();
            shows[0].Ids.Trakt.Should().Be(1U);
            shows[0].Ids.Slug.Should().Be("show1");
            shows[0].Ids.Imdb.Should().Be("imdb1");
            shows[0].Ids.Tmdb.Should().Be(1234U);
            shows[0].Ids.Tvdb.Should().Be(12345U);
            shows[0].Ids.TvRage.Should().Be(123456U);
            shows[0].Rating.Should().HaveValue();
            shows[0].RatedAt.Should().NotHaveValue();
            shows[0].Seasons.Should().NotBeNull().And.HaveCount(1);

            var show1Seasons = shows[0].Seasons.ToArray();

            show1Seasons[0].Number.Should().Be(1);
            show1Seasons[0].Episodes.Should().BeNull();
            show1Seasons[0].Rating.Should().NotHaveValue();
            show1Seasons[0].RatedAt.Should().NotHaveValue();

            // ---------------------------------------------------------

            builder.AddShowWithRating(show1, rating, 1, 2);

            ratingsPost = builder.Build();

            ratingsPost.Should().NotBeNull();
            ratingsPost.Episodes.Should().BeNull();
            ratingsPost.Shows.Should().NotBeNull().And.HaveCount(1);
            ratingsPost.Movies.Should().BeNull();

            shows = ratingsPost.Shows.ToArray();

            shows[0].Should().NotBeNull();
            shows[0].Title.Should().Be("show1");
            shows[0].Year.Should().Be(2016);
            shows[0].Ids.Should().NotBeNull();
            shows[0].Ids.Trakt.Should().Be(1U);
            shows[0].Ids.Slug.Should().Be("show1");
            shows[0].Ids.Imdb.Should().Be("imdb1");
            shows[0].Ids.Tmdb.Should().Be(1234U);
            shows[0].Ids.Tvdb.Should().Be(12345U);
            shows[0].Ids.TvRage.Should().Be(123456U);
            shows[0].Rating.Should().HaveValue();
            shows[0].RatedAt.Should().NotHaveValue();
            shows[0].Seasons.Should().NotBeNull().And.HaveCount(2);

            show1Seasons = shows[0].Seasons.ToArray();

            show1Seasons[0].Number.Should().Be(1);
            show1Seasons[0].Episodes.Should().BeNull();
            show1Seasons[0].Rating.Should().NotHaveValue();
            show1Seasons[0].RatedAt.Should().NotHaveValue();

            show1Seasons[1].Number.Should().Be(2);
            show1Seasons[1].Episodes.Should().BeNull();
            show1Seasons[1].Rating.Should().NotHaveValue();
            show1Seasons[1].RatedAt.Should().NotHaveValue();

            // ---------------------------------------------------------

            builder.AddShowWithRating(show1, rating, 1, 2, 3);

            ratingsPost = builder.Build();

            ratingsPost.Should().NotBeNull();
            ratingsPost.Episodes.Should().BeNull();
            ratingsPost.Shows.Should().NotBeNull().And.HaveCount(1);
            ratingsPost.Movies.Should().BeNull();

            shows = ratingsPost.Shows.ToArray();

            shows[0].Should().NotBeNull();
            shows[0].Title.Should().Be("show1");
            shows[0].Year.Should().Be(2016);
            shows[0].Ids.Should().NotBeNull();
            shows[0].Ids.Trakt.Should().Be(1U);
            shows[0].Ids.Slug.Should().Be("show1");
            shows[0].Ids.Imdb.Should().Be("imdb1");
            shows[0].Ids.Tmdb.Should().Be(1234U);
            shows[0].Ids.Tvdb.Should().Be(12345U);
            shows[0].Ids.TvRage.Should().Be(123456U);
            shows[0].Rating.Should().HaveValue();
            shows[0].RatedAt.Should().NotHaveValue();
            shows[0].Seasons.Should().NotBeNull().And.HaveCount(3);

            show1Seasons = shows[0].Seasons.ToArray();

            show1Seasons[0].Number.Should().Be(1);
            show1Seasons[0].Episodes.Should().BeNull();
            show1Seasons[0].Rating.Should().NotHaveValue();
            show1Seasons[0].RatedAt.Should().NotHaveValue();

            show1Seasons[1].Number.Should().Be(2);
            show1Seasons[1].Episodes.Should().BeNull();
            show1Seasons[1].Rating.Should().NotHaveValue();
            show1Seasons[1].RatedAt.Should().NotHaveValue();

            show1Seasons[2].Number.Should().Be(3);
            show1Seasons[2].Episodes.Should().BeNull();
            show1Seasons[2].Rating.Should().NotHaveValue();
            show1Seasons[2].RatedAt.Should().NotHaveValue();

            // ---------------------------------------------------------

            show1.Ids.Trakt = 2;

            builder.AddShowWithRating(show1, rating, 1, 2, 3);

            ratingsPost = builder.Build();

            ratingsPost.Should().NotBeNull();
            ratingsPost.Episodes.Should().BeNull();
            ratingsPost.Shows.Should().NotBeNull().And.HaveCount(1);
            ratingsPost.Movies.Should().BeNull();

            shows = ratingsPost.Shows.ToArray();

            shows[0].Should().NotBeNull();
            shows[0].Title.Should().Be("show1");
            shows[0].Year.Should().Be(2016);
            shows[0].Ids.Should().NotBeNull();
            shows[0].Ids.Trakt.Should().Be(2U);
            shows[0].Ids.Slug.Should().Be("show1");
            shows[0].Ids.Imdb.Should().Be("imdb1");
            shows[0].Ids.Tmdb.Should().Be(1234U);
            shows[0].Ids.Tvdb.Should().Be(12345U);
            shows[0].Ids.TvRage.Should().Be(123456U);
            shows[0].Rating.Should().HaveValue();
            shows[0].RatedAt.Should().NotHaveValue();
            shows[0].Seasons.Should().NotBeNull().And.HaveCount(3);

            show1Seasons = shows[0].Seasons.ToArray();

            show1Seasons[0].Number.Should().Be(1);
            show1Seasons[0].Episodes.Should().BeNull();
            show1Seasons[0].Rating.Should().NotHaveValue();
            show1Seasons[0].RatedAt.Should().NotHaveValue();

            show1Seasons[1].Number.Should().Be(2);
            show1Seasons[1].Episodes.Should().BeNull();
            show1Seasons[1].Rating.Should().NotHaveValue();
            show1Seasons[1].RatedAt.Should().NotHaveValue();

            show1Seasons[2].Number.Should().Be(3);
            show1Seasons[2].Episodes.Should().BeNull();
            show1Seasons[2].Rating.Should().NotHaveValue();
            show1Seasons[2].RatedAt.Should().NotHaveValue();

            // ---------------------------------------------------------

            var show2 = new TraktShow
            {
                Title = "show2",
                Year = 2016,
                Ids = new TraktShowIds
                {
                    Trakt = 3,
                    Slug = "show2",
                    Imdb = "imdb2",
                    Tmdb = 12345,
                    Tvdb = 123456,
                    TvRage = 1234567
                }
            };

            builder.AddShowWithRating(show2, rating, 1, 2, 3);

            ratingsPost = builder.Build();

            ratingsPost.Should().NotBeNull();
            ratingsPost.Episodes.Should().BeNull();
            ratingsPost.Shows.Should().NotBeNull().And.HaveCount(2);
            ratingsPost.Movies.Should().BeNull();

            shows = ratingsPost.Shows.ToArray();

            shows[0].Should().NotBeNull();
            shows[0].Title.Should().Be("show1");
            shows[0].Year.Should().Be(2016);
            shows[0].Ids.Should().NotBeNull();
            shows[0].Ids.Trakt.Should().Be(2U);
            shows[0].Ids.Slug.Should().Be("show1");
            shows[0].Ids.Imdb.Should().Be("imdb1");
            shows[0].Ids.Tmdb.Should().Be(1234U);
            shows[0].Ids.Tvdb.Should().Be(12345U);
            shows[0].Ids.TvRage.Should().Be(123456U);
            shows[0].Rating.Should().HaveValue();
            shows[0].RatedAt.Should().NotHaveValue();
            shows[0].Seasons.Should().NotBeNull().And.HaveCount(3);

            shows[1].Should().NotBeNull();
            shows[1].Title.Should().Be("show2");
            shows[1].Year.Should().Be(2016);
            shows[1].Ids.Should().NotBeNull();
            shows[1].Ids.Trakt.Should().Be(3U);
            shows[1].Ids.Slug.Should().Be("show2");
            shows[1].Ids.Imdb.Should().Be("imdb2");
            shows[1].Ids.Tmdb.Should().Be(12345U);
            shows[1].Ids.Tvdb.Should().Be(123456U);
            shows[1].Ids.TvRage.Should().Be(1234567U);
            shows[1].Rating.Should().HaveValue();
            shows[1].RatedAt.Should().NotHaveValue();
            shows[1].Seasons.Should().NotBeNull().And.HaveCount(3);

            show1Seasons = shows[0].Seasons.ToArray();

            show1Seasons[0].Number.Should().Be(1);
            show1Seasons[0].Episodes.Should().BeNull();
            show1Seasons[0].Rating.Should().NotHaveValue();
            show1Seasons[0].RatedAt.Should().NotHaveValue();

            show1Seasons[1].Number.Should().Be(2);
            show1Seasons[1].Episodes.Should().BeNull();
            show1Seasons[1].Rating.Should().NotHaveValue();
            show1Seasons[1].RatedAt.Should().NotHaveValue();

            show1Seasons[2].Number.Should().Be(3);
            show1Seasons[2].Episodes.Should().BeNull();
            show1Seasons[2].Rating.Should().NotHaveValue();
            show1Seasons[2].RatedAt.Should().NotHaveValue();

            var show2Seasons = shows[1].Seasons.ToArray();

            show2Seasons[0].Number.Should().Be(1);
            show2Seasons[0].Episodes.Should().BeNull();
            show2Seasons[0].Rating.Should().NotHaveValue();
            show2Seasons[0].RatedAt.Should().NotHaveValue();

            show2Seasons[1].Number.Should().Be(2);
            show2Seasons[1].Episodes.Should().BeNull();
            show2Seasons[1].Rating.Should().NotHaveValue();
            show2Seasons[1].RatedAt.Should().NotHaveValue();

            show2Seasons[2].Number.Should().Be(3);
            show2Seasons[2].Episodes.Should().BeNull();
            show2Seasons[2].Rating.Should().NotHaveValue();
            show2Seasons[2].RatedAt.Should().NotHaveValue();
        }

        [TestMethod]
        public void TestTraktSyncRatingsPostBuilderAddShowWithSeasonsAndRatingAndRatedAt()
        {
            var show1 = new TraktShow
            {
                Title = "show1",
                Year = 2016,
                Ids = new TraktShowIds
                {
                    Trakt = 1,
                    Slug = "show1",
                    Imdb = "imdb1",
                    Tmdb = 1234,
                    Tvdb = 12345,
                    TvRage = 123456
                }
            };

            var rating = 5;
            var ratedAt = DateTime.Now;

            var builder = TraktSyncRatingsPost.Builder();

            builder.AddShowWithRating(show1, rating, ratedAt, 1);

            var ratingsPost = builder.Build();

            ratingsPost.Should().NotBeNull();
            ratingsPost.Episodes.Should().BeNull();
            ratingsPost.Shows.Should().NotBeNull().And.HaveCount(1);
            ratingsPost.Movies.Should().BeNull();

            var shows = ratingsPost.Shows.ToArray();

            shows[0].Should().NotBeNull();
            shows[0].Title.Should().Be("show1");
            shows[0].Year.Should().Be(2016);
            shows[0].Ids.Should().NotBeNull();
            shows[0].Ids.Trakt.Should().Be(1U);
            shows[0].Ids.Slug.Should().Be("show1");
            shows[0].Ids.Imdb.Should().Be("imdb1");
            shows[0].Ids.Tmdb.Should().Be(1234U);
            shows[0].Ids.Tvdb.Should().Be(12345U);
            shows[0].Ids.TvRage.Should().Be(123456U);
            shows[0].Rating.Should().HaveValue();
            shows[0].RatedAt.Should().HaveValue();
            shows[0].Seasons.Should().NotBeNull().And.HaveCount(1);

            var show1Seasons = shows[0].Seasons.ToArray();

            show1Seasons[0].Number.Should().Be(1);
            show1Seasons[0].Episodes.Should().BeNull();
            show1Seasons[0].Rating.Should().NotHaveValue();
            show1Seasons[0].RatedAt.Should().NotHaveValue();

            // ---------------------------------------------------------

            builder.AddShowWithRating(show1, rating, ratedAt, 1, 2);

            ratingsPost = builder.Build();

            ratingsPost.Should().NotBeNull();
            ratingsPost.Episodes.Should().BeNull();
            ratingsPost.Shows.Should().NotBeNull().And.HaveCount(1);
            ratingsPost.Movies.Should().BeNull();

            shows = ratingsPost.Shows.ToArray();

            shows[0].Should().NotBeNull();
            shows[0].Title.Should().Be("show1");
            shows[0].Year.Should().Be(2016);
            shows[0].Ids.Should().NotBeNull();
            shows[0].Ids.Trakt.Should().Be(1U);
            shows[0].Ids.Slug.Should().Be("show1");
            shows[0].Ids.Imdb.Should().Be("imdb1");
            shows[0].Ids.Tmdb.Should().Be(1234U);
            shows[0].Ids.Tvdb.Should().Be(12345U);
            shows[0].Ids.TvRage.Should().Be(123456U);
            shows[0].Rating.Should().HaveValue();
            shows[0].RatedAt.Should().HaveValue();
            shows[0].Seasons.Should().NotBeNull().And.HaveCount(2);

            show1Seasons = shows[0].Seasons.ToArray();

            show1Seasons[0].Number.Should().Be(1);
            show1Seasons[0].Episodes.Should().BeNull();
            show1Seasons[0].Rating.Should().NotHaveValue();
            show1Seasons[0].RatedAt.Should().NotHaveValue();

            show1Seasons[1].Number.Should().Be(2);
            show1Seasons[1].Episodes.Should().BeNull();
            show1Seasons[1].Rating.Should().NotHaveValue();
            show1Seasons[1].RatedAt.Should().NotHaveValue();

            // ---------------------------------------------------------

            builder.AddShowWithRating(show1, rating, ratedAt, 1, 2, 3);

            ratingsPost = builder.Build();

            ratingsPost.Should().NotBeNull();
            ratingsPost.Episodes.Should().BeNull();
            ratingsPost.Shows.Should().NotBeNull().And.HaveCount(1);
            ratingsPost.Movies.Should().BeNull();

            shows = ratingsPost.Shows.ToArray();

            shows[0].Should().NotBeNull();
            shows[0].Title.Should().Be("show1");
            shows[0].Year.Should().Be(2016);
            shows[0].Ids.Should().NotBeNull();
            shows[0].Ids.Trakt.Should().Be(1U);
            shows[0].Ids.Slug.Should().Be("show1");
            shows[0].Ids.Imdb.Should().Be("imdb1");
            shows[0].Ids.Tmdb.Should().Be(1234U);
            shows[0].Ids.Tvdb.Should().Be(12345U);
            shows[0].Ids.TvRage.Should().Be(123456U);
            shows[0].Rating.Should().HaveValue();
            shows[0].RatedAt.Should().HaveValue();
            shows[0].Seasons.Should().NotBeNull().And.HaveCount(3);

            show1Seasons = shows[0].Seasons.ToArray();

            show1Seasons[0].Number.Should().Be(1);
            show1Seasons[0].Episodes.Should().BeNull();
            show1Seasons[0].Rating.Should().NotHaveValue();
            show1Seasons[0].RatedAt.Should().NotHaveValue();

            show1Seasons[1].Number.Should().Be(2);
            show1Seasons[1].Episodes.Should().BeNull();
            show1Seasons[1].Rating.Should().NotHaveValue();
            show1Seasons[1].RatedAt.Should().NotHaveValue();

            show1Seasons[2].Number.Should().Be(3);
            show1Seasons[2].Episodes.Should().BeNull();
            show1Seasons[2].Rating.Should().NotHaveValue();
            show1Seasons[2].RatedAt.Should().NotHaveValue();

            // ---------------------------------------------------------

            show1.Ids.Trakt = 2;

            builder.AddShowWithRating(show1, rating, ratedAt, 1, 2, 3);

            ratingsPost = builder.Build();

            ratingsPost.Should().NotBeNull();
            ratingsPost.Episodes.Should().BeNull();
            ratingsPost.Shows.Should().NotBeNull().And.HaveCount(1);
            ratingsPost.Movies.Should().BeNull();

            shows = ratingsPost.Shows.ToArray();

            shows[0].Should().NotBeNull();
            shows[0].Title.Should().Be("show1");
            shows[0].Year.Should().Be(2016);
            shows[0].Ids.Should().NotBeNull();
            shows[0].Ids.Trakt.Should().Be(2U);
            shows[0].Ids.Slug.Should().Be("show1");
            shows[0].Ids.Imdb.Should().Be("imdb1");
            shows[0].Ids.Tmdb.Should().Be(1234U);
            shows[0].Ids.Tvdb.Should().Be(12345U);
            shows[0].Ids.TvRage.Should().Be(123456U);
            shows[0].Rating.Should().HaveValue();
            shows[0].RatedAt.Should().HaveValue();
            shows[0].Seasons.Should().NotBeNull().And.HaveCount(3);

            show1Seasons = shows[0].Seasons.ToArray();

            show1Seasons[0].Number.Should().Be(1);
            show1Seasons[0].Episodes.Should().BeNull();
            show1Seasons[0].Rating.Should().NotHaveValue();
            show1Seasons[0].RatedAt.Should().NotHaveValue();

            show1Seasons[1].Number.Should().Be(2);
            show1Seasons[1].Episodes.Should().BeNull();
            show1Seasons[1].Rating.Should().NotHaveValue();
            show1Seasons[1].RatedAt.Should().NotHaveValue();

            show1Seasons[2].Number.Should().Be(3);
            show1Seasons[2].Episodes.Should().BeNull();
            show1Seasons[2].Rating.Should().NotHaveValue();
            show1Seasons[2].RatedAt.Should().NotHaveValue();

            // ---------------------------------------------------------

            var show2 = new TraktShow
            {
                Title = "show2",
                Year = 2016,
                Ids = new TraktShowIds
                {
                    Trakt = 3,
                    Slug = "show2",
                    Imdb = "imdb2",
                    Tmdb = 12345,
                    Tvdb = 123456,
                    TvRage = 1234567
                }
            };

            builder.AddShowWithRating(show2, rating, ratedAt, 1, 2, 3);

            ratingsPost = builder.Build();

            ratingsPost.Should().NotBeNull();
            ratingsPost.Episodes.Should().BeNull();
            ratingsPost.Shows.Should().NotBeNull().And.HaveCount(2);
            ratingsPost.Movies.Should().BeNull();

            shows = ratingsPost.Shows.ToArray();

            shows[0].Should().NotBeNull();
            shows[0].Title.Should().Be("show1");
            shows[0].Year.Should().Be(2016);
            shows[0].Ids.Should().NotBeNull();
            shows[0].Ids.Trakt.Should().Be(2U);
            shows[0].Ids.Slug.Should().Be("show1");
            shows[0].Ids.Imdb.Should().Be("imdb1");
            shows[0].Ids.Tmdb.Should().Be(1234U);
            shows[0].Ids.Tvdb.Should().Be(12345U);
            shows[0].Ids.TvRage.Should().Be(123456U);
            shows[0].Rating.Should().HaveValue();
            shows[0].RatedAt.Should().HaveValue();
            shows[0].Seasons.Should().NotBeNull().And.HaveCount(3);

            shows[1].Should().NotBeNull();
            shows[1].Title.Should().Be("show2");
            shows[1].Year.Should().Be(2016);
            shows[1].Ids.Should().NotBeNull();
            shows[1].Ids.Trakt.Should().Be(3U);
            shows[1].Ids.Slug.Should().Be("show2");
            shows[1].Ids.Imdb.Should().Be("imdb2");
            shows[1].Ids.Tmdb.Should().Be(12345U);
            shows[1].Ids.Tvdb.Should().Be(123456U);
            shows[1].Ids.TvRage.Should().Be(1234567U);
            shows[1].Rating.Should().HaveValue();
            shows[1].RatedAt.Should().HaveValue();
            shows[1].Seasons.Should().NotBeNull().And.HaveCount(3);

            show1Seasons = shows[0].Seasons.ToArray();

            show1Seasons[0].Number.Should().Be(1);
            show1Seasons[0].Episodes.Should().BeNull();
            show1Seasons[0].Rating.Should().NotHaveValue();
            show1Seasons[0].RatedAt.Should().NotHaveValue();

            show1Seasons[1].Number.Should().Be(2);
            show1Seasons[1].Episodes.Should().BeNull();
            show1Seasons[1].Rating.Should().NotHaveValue();
            show1Seasons[1].RatedAt.Should().NotHaveValue();

            show1Seasons[2].Number.Should().Be(3);
            show1Seasons[2].Episodes.Should().BeNull();
            show1Seasons[2].Rating.Should().NotHaveValue();
            show1Seasons[2].RatedAt.Should().NotHaveValue();

            var show2Seasons = shows[1].Seasons.ToArray();

            show2Seasons[0].Number.Should().Be(1);
            show2Seasons[0].Episodes.Should().BeNull();
            show2Seasons[0].Rating.Should().NotHaveValue();
            show2Seasons[0].RatedAt.Should().NotHaveValue();

            show2Seasons[1].Number.Should().Be(2);
            show2Seasons[1].Episodes.Should().BeNull();
            show2Seasons[1].Rating.Should().NotHaveValue();
            show2Seasons[1].RatedAt.Should().NotHaveValue();

            show2Seasons[2].Number.Should().Be(3);
            show2Seasons[2].Episodes.Should().BeNull();
            show2Seasons[2].Rating.Should().NotHaveValue();
            show2Seasons[2].RatedAt.Should().NotHaveValue();
        }

        [TestMethod]
        public void TestTraktSyncRatingsPostBuilderAddShowWithSeasonsArgumentExceptions()
        {
            var builder = TraktSyncRatingsPost.Builder();

            Action act = () => builder.AddShow(null, 1, 2, 3, 4);
            act.ShouldThrow<ArgumentNullException>();

            act = () => builder.AddShow(new TraktShow(), 1, 2, 3, 4);
            act.ShouldThrow<ArgumentNullException>();

            act = () => builder.AddShow(new TraktShow { Ids = new TraktShowIds() }, 1, 2, 3, 4);
            act.ShouldThrow<ArgumentException>();

            act = () => builder.AddShow(new TraktShow { Ids = new TraktShowIds { Trakt = 1 }, Year = 123 }, 1, 2, 3, 4);
            act.ShouldThrow<ArgumentException>();

            act = () => builder.AddShow(new TraktShow { Ids = new TraktShowIds { Trakt = 1 }, Year = 12345 }, 1, 2, 3, 4);
            act.ShouldThrow<ArgumentException>();

            act = () => builder.AddShow(new TraktShow { Ids = new TraktShowIds { Trakt = 1 } }, -1);
            act.ShouldThrow<ArgumentOutOfRangeException>();

            act = () => builder.AddShow(new TraktShow { Ids = new TraktShowIds { Trakt = 1 } }, 1, 2, -1);
            act.ShouldThrow<ArgumentOutOfRangeException>();

            act = () => builder.AddShow(new TraktShow { Ids = new TraktShowIds { Trakt = 1 } }, new PostRatingsSeasons { -1 });
            act.ShouldThrow<ArgumentOutOfRangeException>();

            act = () => builder.AddShow(new TraktShow { Ids = new TraktShowIds { Trakt = 1 } }, new PostRatingsSeasons { 1, -1 });
            act.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [TestMethod]
        public void TestTraktSyncRatingsPostBuilderAddShowWithSeasonsAndRatingArgumentExceptions()
        {
            var builder = TraktSyncRatingsPost.Builder();

            var rating = 5;

            Action act = () => builder.AddShowWithRating(null, rating, 1, 2, 3, 4);
            act.ShouldThrow<ArgumentNullException>();

            act = () => builder.AddShowWithRating(new TraktShow(), rating, 1, 2, 3, 4);
            act.ShouldThrow<ArgumentNullException>();

            act = () => builder.AddShowWithRating(new TraktShow { Ids = new TraktShowIds() }, rating, 1, 2, 3, 4);
            act.ShouldThrow<ArgumentException>();

            act = () => builder.AddShowWithRating(new TraktShow { Ids = new TraktShowIds { Trakt = 1 }, Year = 123 }, rating, 1, 2, 3, 4);
            act.ShouldThrow<ArgumentException>();

            act = () => builder.AddShowWithRating(new TraktShow { Ids = new TraktShowIds { Trakt = 1 }, Year = 12345 }, rating, 1, 2, 3, 4);
            act.ShouldThrow<ArgumentException>();

            act = () => builder.AddShowWithRating(new TraktShow { Ids = new TraktShowIds { Trakt = 1 } }, 0, 1, 2, 3, 4);
            act.ShouldThrow<ArgumentOutOfRangeException>();

            act = () => builder.AddShowWithRating(new TraktShow { Ids = new TraktShowIds { Trakt = 1 } }, 11, 1, 2, 3, 4);
            act.ShouldThrow<ArgumentOutOfRangeException>();

            act = () => builder.AddShowWithRating(new TraktShow { Ids = new TraktShowIds { Trakt = 1 } }, rating, -1);
            act.ShouldThrow<ArgumentOutOfRangeException>();

            act = () => builder.AddShowWithRating(new TraktShow { Ids = new TraktShowIds { Trakt = 1 } }, rating, 1, 2, -1);
            act.ShouldThrow<ArgumentOutOfRangeException>();

            act = () => builder.AddShowWithRating(new TraktShow { Ids = new TraktShowIds { Trakt = 1 } }, rating, new PostRatingsSeasons { -1 });
            act.ShouldThrow<ArgumentOutOfRangeException>();

            act = () => builder.AddShowWithRating(new TraktShow { Ids = new TraktShowIds { Trakt = 1 } }, rating, new PostRatingsSeasons { 1, -1 });
            act.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [TestMethod]
        public void TestTraktSyncRatingsPostBuilderAddShowWithSeasonsAndRatingAndRatedAtArgumentExceptions()
        {
            var builder = TraktSyncRatingsPost.Builder();

            var rating = 5;
            var ratedAt = DateTime.Now;

            Action act = () => builder.AddShowWithRating(null, rating, ratedAt, 1, 2, 3, 4);
            act.ShouldThrow<ArgumentNullException>();

            act = () => builder.AddShowWithRating(new TraktShow(), rating, ratedAt, 1, 2, 3, 4);
            act.ShouldThrow<ArgumentNullException>();

            act = () => builder.AddShowWithRating(new TraktShow { Ids = new TraktShowIds() }, rating, ratedAt, 1, 2, 3, 4);
            act.ShouldThrow<ArgumentException>();

            act = () => builder.AddShowWithRating(new TraktShow { Ids = new TraktShowIds { Trakt = 1 }, Year = 123 }, rating, ratedAt, 1, 2, 3, 4);
            act.ShouldThrow<ArgumentException>();

            act = () => builder.AddShowWithRating(new TraktShow { Ids = new TraktShowIds { Trakt = 1 }, Year = 12345 }, rating, ratedAt, 1, 2, 3, 4);
            act.ShouldThrow<ArgumentException>();

            act = () => builder.AddShowWithRating(new TraktShow { Ids = new TraktShowIds { Trakt = 1 } }, 0, ratedAt, 1, 2, 3, 4);
            act.ShouldThrow<ArgumentOutOfRangeException>();

            act = () => builder.AddShowWithRating(new TraktShow { Ids = new TraktShowIds { Trakt = 1 } }, 11, ratedAt, 1, 2, 3, 4);
            act.ShouldThrow<ArgumentOutOfRangeException>();

            act = () => builder.AddShowWithRating(new TraktShow { Ids = new TraktShowIds { Trakt = 1 } }, rating, ratedAt, -1);
            act.ShouldThrow<ArgumentOutOfRangeException>();

            act = () => builder.AddShowWithRating(new TraktShow { Ids = new TraktShowIds { Trakt = 1 } }, rating, ratedAt, 1, 2, -1);
            act.ShouldThrow<ArgumentOutOfRangeException>();

            act = () => builder.AddShowWithRating(new TraktShow { Ids = new TraktShowIds { Trakt = 1 } }, rating, ratedAt, new PostRatingsSeasons { -1 });
            act.ShouldThrow<ArgumentOutOfRangeException>();

            act = () => builder.AddShowWithRating(new TraktShow { Ids = new TraktShowIds { Trakt = 1 } }, rating, ratedAt, new PostRatingsSeasons { 1, -1 });
            act.ShouldThrow<ArgumentOutOfRangeException>();
        }

        // ----------------------------------------------------------------------------------------
        // ----------------------------------------------------------------------------------------

        [TestMethod]
        public void TestTraktSyncRatingsPostBuilderAddShowWithSeasonsAndEpisodes()
        {
            var show1 = new TraktShow
            {
                Title = "show1",
                Year = 2016,
                Ids = new TraktShowIds
                {
                    Trakt = 1,
                    Slug = "show1",
                    Imdb = "imdb1",
                    Tmdb = 1234,
                    Tvdb = 12345,
                    TvRage = 123456
                }
            };

            var builder = TraktSyncRatingsPost.Builder();

            builder.AddShow(show1, new PostRatingsSeasons { { 1, new PostRatingsEpisodes { 1 } } }); // season 1 - episode 1

            var ratingsPost = builder.Build();

            ratingsPost.Should().NotBeNull();
            ratingsPost.Episodes.Should().BeNull();
            ratingsPost.Shows.Should().NotBeNull().And.HaveCount(1);
            ratingsPost.Movies.Should().BeNull();

            var shows = ratingsPost.Shows.ToArray();

            shows[0].Should().NotBeNull();
            shows[0].Title.Should().Be("show1");
            shows[0].Year.Should().Be(2016);
            shows[0].Ids.Should().NotBeNull();
            shows[0].Ids.Trakt.Should().Be(1U);
            shows[0].Ids.Slug.Should().Be("show1");
            shows[0].Ids.Imdb.Should().Be("imdb1");
            shows[0].Ids.Tmdb.Should().Be(1234U);
            shows[0].Ids.Tvdb.Should().Be(12345U);
            shows[0].Ids.TvRage.Should().Be(123456U);
            shows[0].Rating.Should().NotHaveValue();
            shows[0].RatedAt.Should().NotHaveValue();
            shows[0].Seasons.Should().NotBeNull().And.HaveCount(1);

            var show1Seasons = shows[0].Seasons.ToArray();

            show1Seasons[0].Number.Should().Be(1);
            show1Seasons[0].Episodes.Should().NotBeNull().And.HaveCount(1);
            show1Seasons[0].Rating.Should().NotHaveValue();
            show1Seasons[0].RatedAt.Should().NotHaveValue();

            var show1Season1Episodes = show1Seasons[0].Episodes.ToArray();

            show1Season1Episodes[0].Number.Should().Be(1);
            show1Season1Episodes[0].Rating.Should().NotHaveValue();
            show1Season1Episodes[0].RatedAt.Should().NotHaveValue();

            // ---------------------------------------------------------

            builder.AddShow(show1, new PostRatingsSeasons { { 1, new PostRatingsEpisodes { 1, 2 } } }); // season 1 - episode 1, 2

            ratingsPost = builder.Build();

            ratingsPost.Should().NotBeNull();
            ratingsPost.Episodes.Should().BeNull();
            ratingsPost.Shows.Should().NotBeNull().And.HaveCount(1);
            ratingsPost.Movies.Should().BeNull();

            shows = ratingsPost.Shows.ToArray();

            shows[0].Should().NotBeNull();
            shows[0].Title.Should().Be("show1");
            shows[0].Year.Should().Be(2016);
            shows[0].Ids.Should().NotBeNull();
            shows[0].Ids.Trakt.Should().Be(1U);
            shows[0].Ids.Slug.Should().Be("show1");
            shows[0].Ids.Imdb.Should().Be("imdb1");
            shows[0].Ids.Tmdb.Should().Be(1234U);
            shows[0].Ids.Tvdb.Should().Be(12345U);
            shows[0].Ids.TvRage.Should().Be(123456U);
            shows[0].Rating.Should().NotHaveValue();
            shows[0].RatedAt.Should().NotHaveValue();
            shows[0].Seasons.Should().NotBeNull().And.HaveCount(1);

            show1Seasons = shows[0].Seasons.ToArray();

            show1Seasons[0].Number.Should().Be(1);
            show1Seasons[0].Episodes.Should().NotBeNull().And.HaveCount(2);
            show1Seasons[0].Rating.Should().NotHaveValue();
            show1Seasons[0].RatedAt.Should().NotHaveValue();

            show1Season1Episodes = show1Seasons[0].Episodes.ToArray();

            show1Season1Episodes[0].Number.Should().Be(1);
            show1Season1Episodes[0].Rating.Should().NotHaveValue();
            show1Season1Episodes[0].RatedAt.Should().NotHaveValue();

            show1Season1Episodes[1].Number.Should().Be(2);
            show1Season1Episodes[1].Rating.Should().NotHaveValue();
            show1Season1Episodes[1].RatedAt.Should().NotHaveValue();

            // ---------------------------------------------------------

            builder.AddShow(show1, new PostRatingsSeasons { { 1, new PostRatingsEpisodes { 1, 2, 3 } } }); // season 1 - episode 1, 2, 3

            ratingsPost = builder.Build();

            ratingsPost.Should().NotBeNull();
            ratingsPost.Episodes.Should().BeNull();
            ratingsPost.Shows.Should().NotBeNull().And.HaveCount(1);
            ratingsPost.Movies.Should().BeNull();

            shows = ratingsPost.Shows.ToArray();

            shows[0].Should().NotBeNull();
            shows[0].Title.Should().Be("show1");
            shows[0].Year.Should().Be(2016);
            shows[0].Ids.Should().NotBeNull();
            shows[0].Ids.Trakt.Should().Be(1U);
            shows[0].Ids.Slug.Should().Be("show1");
            shows[0].Ids.Imdb.Should().Be("imdb1");
            shows[0].Ids.Tmdb.Should().Be(1234U);
            shows[0].Ids.Tvdb.Should().Be(12345U);
            shows[0].Ids.TvRage.Should().Be(123456U);
            shows[0].Rating.Should().NotHaveValue();
            shows[0].RatedAt.Should().NotHaveValue();
            shows[0].Seasons.Should().NotBeNull().And.HaveCount(1);

            show1Seasons = shows[0].Seasons.ToArray();

            show1Seasons[0].Number.Should().Be(1);
            show1Seasons[0].Episodes.Should().NotBeNull().And.HaveCount(3);
            show1Seasons[0].Rating.Should().NotHaveValue();
            show1Seasons[0].RatedAt.Should().NotHaveValue();

            show1Season1Episodes = show1Seasons[0].Episodes.ToArray();

            show1Season1Episodes[0].Number.Should().Be(1);
            show1Season1Episodes[0].Rating.Should().NotHaveValue();
            show1Season1Episodes[0].RatedAt.Should().NotHaveValue();

            show1Season1Episodes[1].Number.Should().Be(2);
            show1Season1Episodes[1].Rating.Should().NotHaveValue();
            show1Season1Episodes[1].RatedAt.Should().NotHaveValue();

            show1Season1Episodes[2].Number.Should().Be(3);
            show1Season1Episodes[2].Rating.Should().NotHaveValue();
            show1Season1Episodes[2].RatedAt.Should().NotHaveValue();

            // ---------------------------------------------------------

            builder.AddShow(show1, new PostRatingsSeasons {
                { 1, new PostRatingsEpisodes { 1, 2, 3 } }, // season 1 - episode 1, 2, 3
                { 2, new PostRatingsEpisodes { 4 } }        // season 2 - episode 4
            });

            ratingsPost = builder.Build();

            ratingsPost.Should().NotBeNull();
            ratingsPost.Episodes.Should().BeNull();
            ratingsPost.Shows.Should().NotBeNull().And.HaveCount(1);
            ratingsPost.Movies.Should().BeNull();

            shows = ratingsPost.Shows.ToArray();

            shows[0].Should().NotBeNull();
            shows[0].Title.Should().Be("show1");
            shows[0].Year.Should().Be(2016);
            shows[0].Ids.Should().NotBeNull();
            shows[0].Ids.Trakt.Should().Be(1U);
            shows[0].Ids.Slug.Should().Be("show1");
            shows[0].Ids.Imdb.Should().Be("imdb1");
            shows[0].Ids.Tmdb.Should().Be(1234U);
            shows[0].Ids.Tvdb.Should().Be(12345U);
            shows[0].Ids.TvRage.Should().Be(123456U);
            shows[0].Rating.Should().NotHaveValue();
            shows[0].RatedAt.Should().NotHaveValue();
            shows[0].Seasons.Should().NotBeNull().And.HaveCount(2);

            show1Seasons = shows[0].Seasons.ToArray();

            show1Seasons[0].Number.Should().Be(1);
            show1Seasons[0].Episodes.Should().NotBeNull().And.HaveCount(3);
            show1Seasons[0].Rating.Should().NotHaveValue();
            show1Seasons[0].RatedAt.Should().NotHaveValue();

            show1Seasons[1].Number.Should().Be(2);
            show1Seasons[1].Episodes.Should().NotBeNull().And.HaveCount(1);
            show1Seasons[1].Rating.Should().NotHaveValue();
            show1Seasons[1].RatedAt.Should().NotHaveValue();

            show1Season1Episodes = show1Seasons[0].Episodes.ToArray();

            show1Season1Episodes[0].Number.Should().Be(1);
            show1Season1Episodes[0].Rating.Should().NotHaveValue();
            show1Season1Episodes[0].RatedAt.Should().NotHaveValue();

            show1Season1Episodes[1].Number.Should().Be(2);
            show1Season1Episodes[1].Rating.Should().NotHaveValue();
            show1Season1Episodes[1].RatedAt.Should().NotHaveValue();

            show1Season1Episodes[2].Number.Should().Be(3);
            show1Season1Episodes[2].Rating.Should().NotHaveValue();
            show1Season1Episodes[2].RatedAt.Should().NotHaveValue();

            var show1Season2Episodes = show1Seasons[1].Episodes.ToArray();

            show1Season2Episodes[0].Number.Should().Be(4);
            show1Season2Episodes[0].Rating.Should().NotHaveValue();
            show1Season2Episodes[0].RatedAt.Should().NotHaveValue();

            // ---------------------------------------------------------

            builder.AddShow(show1, new PostRatingsSeasons {
                { 1, new PostRatingsEpisodes { 1, 2, 3 } }, // season 1 - episode 1, 2, 3
                { 2, new PostRatingsEpisodes { 4, 5 } }     // season 2 - episode 4, 5
            });

            ratingsPost = builder.Build();

            ratingsPost.Should().NotBeNull();
            ratingsPost.Episodes.Should().BeNull();
            ratingsPost.Shows.Should().NotBeNull().And.HaveCount(1);
            ratingsPost.Movies.Should().BeNull();

            shows = ratingsPost.Shows.ToArray();

            shows[0].Should().NotBeNull();
            shows[0].Title.Should().Be("show1");
            shows[0].Year.Should().Be(2016);
            shows[0].Ids.Should().NotBeNull();
            shows[0].Ids.Trakt.Should().Be(1U);
            shows[0].Ids.Slug.Should().Be("show1");
            shows[0].Ids.Imdb.Should().Be("imdb1");
            shows[0].Ids.Tmdb.Should().Be(1234U);
            shows[0].Ids.Tvdb.Should().Be(12345U);
            shows[0].Ids.TvRage.Should().Be(123456U);
            shows[0].Rating.Should().NotHaveValue();
            shows[0].RatedAt.Should().NotHaveValue();
            shows[0].Seasons.Should().NotBeNull().And.HaveCount(2);

            show1Seasons = shows[0].Seasons.ToArray();

            show1Seasons[0].Number.Should().Be(1);
            show1Seasons[0].Episodes.Should().NotBeNull().And.HaveCount(3);
            show1Seasons[0].Rating.Should().NotHaveValue();
            show1Seasons[0].RatedAt.Should().NotHaveValue();

            show1Seasons[1].Number.Should().Be(2);
            show1Seasons[1].Episodes.Should().NotBeNull().And.HaveCount(2);
            show1Seasons[1].Rating.Should().NotHaveValue();
            show1Seasons[1].RatedAt.Should().NotHaveValue();

            show1Season1Episodes = show1Seasons[0].Episodes.ToArray();

            show1Season1Episodes[0].Number.Should().Be(1);
            show1Season1Episodes[0].Rating.Should().NotHaveValue();
            show1Season1Episodes[0].RatedAt.Should().NotHaveValue();

            show1Season1Episodes[1].Number.Should().Be(2);
            show1Season1Episodes[1].Rating.Should().NotHaveValue();
            show1Season1Episodes[1].RatedAt.Should().NotHaveValue();

            show1Season1Episodes[2].Number.Should().Be(3);
            show1Season1Episodes[2].Rating.Should().NotHaveValue();
            show1Season1Episodes[2].RatedAt.Should().NotHaveValue();

            show1Season2Episodes = show1Seasons[1].Episodes.ToArray();

            show1Season2Episodes[0].Number.Should().Be(4);
            show1Season2Episodes[0].Rating.Should().NotHaveValue();
            show1Season2Episodes[0].RatedAt.Should().NotHaveValue();

            show1Season2Episodes[1].Number.Should().Be(5);
            show1Season2Episodes[1].Rating.Should().NotHaveValue();
            show1Season2Episodes[1].RatedAt.Should().NotHaveValue();

            // ---------------------------------------------------------

            builder.AddShow(show1, new PostRatingsSeasons {
                { 1, new PostRatingsEpisodes { 1, 2, 3 } }, // season 1 - episode 1, 2, 3
                { 2, new PostRatingsEpisodes { 4, 5, 6 } }  // season 2 - episode 4, 5, 6
            });

            ratingsPost = builder.Build();

            ratingsPost.Should().NotBeNull();
            ratingsPost.Episodes.Should().BeNull();
            ratingsPost.Shows.Should().NotBeNull().And.HaveCount(1);
            ratingsPost.Movies.Should().BeNull();

            shows = ratingsPost.Shows.ToArray();

            shows[0].Should().NotBeNull();
            shows[0].Title.Should().Be("show1");
            shows[0].Year.Should().Be(2016);
            shows[0].Ids.Should().NotBeNull();
            shows[0].Ids.Trakt.Should().Be(1U);
            shows[0].Ids.Slug.Should().Be("show1");
            shows[0].Ids.Imdb.Should().Be("imdb1");
            shows[0].Ids.Tmdb.Should().Be(1234U);
            shows[0].Ids.Tvdb.Should().Be(12345U);
            shows[0].Ids.TvRage.Should().Be(123456U);
            shows[0].Rating.Should().NotHaveValue();
            shows[0].RatedAt.Should().NotHaveValue();
            shows[0].Seasons.Should().NotBeNull().And.HaveCount(2);

            show1Seasons = shows[0].Seasons.ToArray();

            show1Seasons[0].Number.Should().Be(1);
            show1Seasons[0].Episodes.Should().NotBeNull().And.HaveCount(3);
            show1Seasons[0].Rating.Should().NotHaveValue();
            show1Seasons[0].RatedAt.Should().NotHaveValue();

            show1Seasons[1].Number.Should().Be(2);
            show1Seasons[1].Episodes.Should().NotBeNull().And.HaveCount(3);
            show1Seasons[1].Rating.Should().NotHaveValue();
            show1Seasons[1].RatedAt.Should().NotHaveValue();

            show1Season1Episodes = show1Seasons[0].Episodes.ToArray();

            show1Season1Episodes[0].Number.Should().Be(1);
            show1Season1Episodes[0].Rating.Should().NotHaveValue();
            show1Season1Episodes[0].RatedAt.Should().NotHaveValue();

            show1Season1Episodes[1].Number.Should().Be(2);
            show1Season1Episodes[1].Rating.Should().NotHaveValue();
            show1Season1Episodes[1].RatedAt.Should().NotHaveValue();

            show1Season1Episodes[2].Number.Should().Be(3);
            show1Season1Episodes[2].Rating.Should().NotHaveValue();
            show1Season1Episodes[2].RatedAt.Should().NotHaveValue();

            show1Season2Episodes = show1Seasons[1].Episodes.ToArray();

            show1Season2Episodes[0].Number.Should().Be(4);
            show1Season2Episodes[0].Rating.Should().NotHaveValue();
            show1Season2Episodes[0].RatedAt.Should().NotHaveValue();

            show1Season2Episodes[1].Number.Should().Be(5);
            show1Season2Episodes[1].Rating.Should().NotHaveValue();
            show1Season2Episodes[1].RatedAt.Should().NotHaveValue();

            show1Season2Episodes[2].Number.Should().Be(6);
            show1Season2Episodes[2].Rating.Should().NotHaveValue();
            show1Season2Episodes[2].RatedAt.Should().NotHaveValue();

            // ---------------------------------------------------------

            show1.Ids.Trakt = 2;

            builder.AddShow(show1, new PostRatingsSeasons {
                { 1, new PostRatingsEpisodes { 1, 2, 3 } }, // season 1 - episode 1, 2, 3
                { 2, new PostRatingsEpisodes { 4, 5, 6 } }  // season 2 - episode 4, 5, 6
            });

            ratingsPost = builder.Build();

            ratingsPost.Should().NotBeNull();
            ratingsPost.Episodes.Should().BeNull();
            ratingsPost.Shows.Should().NotBeNull().And.HaveCount(1);
            ratingsPost.Movies.Should().BeNull();

            shows = ratingsPost.Shows.ToArray();

            shows[0].Should().NotBeNull();
            shows[0].Title.Should().Be("show1");
            shows[0].Year.Should().Be(2016);
            shows[0].Ids.Should().NotBeNull();
            shows[0].Ids.Trakt.Should().Be(2U);
            shows[0].Ids.Slug.Should().Be("show1");
            shows[0].Ids.Imdb.Should().Be("imdb1");
            shows[0].Ids.Tmdb.Should().Be(1234U);
            shows[0].Ids.Tvdb.Should().Be(12345U);
            shows[0].Ids.TvRage.Should().Be(123456U);
            shows[0].Rating.Should().NotHaveValue();
            shows[0].RatedAt.Should().NotHaveValue();
            shows[0].Seasons.Should().NotBeNull().And.HaveCount(2);

            show1Seasons = shows[0].Seasons.ToArray();

            show1Seasons[0].Number.Should().Be(1);
            show1Seasons[0].Episodes.Should().NotBeNull().And.HaveCount(3);
            show1Seasons[0].Rating.Should().NotHaveValue();
            show1Seasons[0].RatedAt.Should().NotHaveValue();

            show1Seasons[1].Number.Should().Be(2);
            show1Seasons[1].Episodes.Should().NotBeNull().And.HaveCount(3);
            show1Seasons[1].Rating.Should().NotHaveValue();
            show1Seasons[1].RatedAt.Should().NotHaveValue();

            show1Season1Episodes = show1Seasons[0].Episodes.ToArray();

            show1Season1Episodes[0].Number.Should().Be(1);
            show1Season1Episodes[0].Rating.Should().NotHaveValue();
            show1Season1Episodes[0].RatedAt.Should().NotHaveValue();

            show1Season1Episodes[1].Number.Should().Be(2);
            show1Season1Episodes[1].Rating.Should().NotHaveValue();
            show1Season1Episodes[1].RatedAt.Should().NotHaveValue();

            show1Season1Episodes[2].Number.Should().Be(3);
            show1Season1Episodes[2].Rating.Should().NotHaveValue();
            show1Season1Episodes[2].RatedAt.Should().NotHaveValue();

            show1Season2Episodes = show1Seasons[1].Episodes.ToArray();

            show1Season2Episodes[0].Number.Should().Be(4);
            show1Season2Episodes[0].Rating.Should().NotHaveValue();
            show1Season2Episodes[0].RatedAt.Should().NotHaveValue();

            show1Season2Episodes[1].Number.Should().Be(5);
            show1Season2Episodes[1].Rating.Should().NotHaveValue();
            show1Season2Episodes[1].RatedAt.Should().NotHaveValue();

            show1Season2Episodes[2].Number.Should().Be(6);
            show1Season2Episodes[2].Rating.Should().NotHaveValue();
            show1Season2Episodes[2].RatedAt.Should().NotHaveValue();

            // ---------------------------------------------------------

            var show2 = new TraktShow
            {
                Title = "show2",
                Year = 2016,
                Ids = new TraktShowIds
                {
                    Trakt = 3,
                    Slug = "show2",
                    Imdb = "imdb2",
                    Tmdb = 12345,
                    Tvdb = 123456,
                    TvRage = 1234567
                }
            };

            builder.AddShow(show2, new PostRatingsSeasons {
                { 1, new PostRatingsEpisodes { 1, 2, 3 } }, // season 1 - episode 1, 2, 3
                { 2, new PostRatingsEpisodes { 4, 5, 6 } }  // season 2 - episode 4, 5, 6
            });

            ratingsPost = builder.Build();

            ratingsPost.Should().NotBeNull();
            ratingsPost.Episodes.Should().BeNull();
            ratingsPost.Shows.Should().NotBeNull().And.HaveCount(2);
            ratingsPost.Movies.Should().BeNull();

            shows = ratingsPost.Shows.ToArray();

            shows[0].Should().NotBeNull();
            shows[0].Title.Should().Be("show1");
            shows[0].Year.Should().Be(2016);
            shows[0].Ids.Should().NotBeNull();
            shows[0].Ids.Trakt.Should().Be(2U);
            shows[0].Ids.Slug.Should().Be("show1");
            shows[0].Ids.Imdb.Should().Be("imdb1");
            shows[0].Ids.Tmdb.Should().Be(1234U);
            shows[0].Ids.Tvdb.Should().Be(12345U);
            shows[0].Ids.TvRage.Should().Be(123456U);
            shows[0].Rating.Should().NotHaveValue();
            shows[0].RatedAt.Should().NotHaveValue();
            shows[0].Seasons.Should().NotBeNull().And.HaveCount(2);

            shows[1].Should().NotBeNull();
            shows[1].Title.Should().Be("show2");
            shows[1].Year.Should().Be(2016);
            shows[1].Ids.Should().NotBeNull();
            shows[1].Ids.Trakt.Should().Be(3U);
            shows[1].Ids.Slug.Should().Be("show2");
            shows[1].Ids.Imdb.Should().Be("imdb2");
            shows[1].Ids.Tmdb.Should().Be(12345U);
            shows[1].Ids.Tvdb.Should().Be(123456U);
            shows[1].Ids.TvRage.Should().Be(1234567U);
            shows[1].Rating.Should().NotHaveValue();
            shows[1].RatedAt.Should().NotHaveValue();
            shows[1].Seasons.Should().NotBeNull().And.HaveCount(2);

            show1Seasons = shows[0].Seasons.ToArray();

            show1Seasons[0].Number.Should().Be(1);
            show1Seasons[0].Episodes.Should().NotBeNull().And.HaveCount(3);
            show1Seasons[0].Rating.Should().NotHaveValue();
            show1Seasons[0].RatedAt.Should().NotHaveValue();

            show1Seasons[1].Number.Should().Be(2);
            show1Seasons[1].Episodes.Should().NotBeNull().And.HaveCount(3);
            show1Seasons[1].Rating.Should().NotHaveValue();
            show1Seasons[1].RatedAt.Should().NotHaveValue();

            show1Season1Episodes = show1Seasons[0].Episodes.ToArray();

            show1Season1Episodes[0].Number.Should().Be(1);
            show1Season1Episodes[0].Rating.Should().NotHaveValue();
            show1Season1Episodes[0].RatedAt.Should().NotHaveValue();

            show1Season1Episodes[1].Number.Should().Be(2);
            show1Season1Episodes[1].Rating.Should().NotHaveValue();
            show1Season1Episodes[1].RatedAt.Should().NotHaveValue();

            show1Season1Episodes[2].Number.Should().Be(3);
            show1Season1Episodes[2].Rating.Should().NotHaveValue();
            show1Season1Episodes[2].RatedAt.Should().NotHaveValue();

            show1Season2Episodes = show1Seasons[1].Episodes.ToArray();

            show1Season2Episodes[0].Number.Should().Be(4);
            show1Season2Episodes[0].Rating.Should().NotHaveValue();
            show1Season2Episodes[0].RatedAt.Should().NotHaveValue();

            show1Season2Episodes[1].Number.Should().Be(5);
            show1Season2Episodes[1].Rating.Should().NotHaveValue();
            show1Season2Episodes[1].RatedAt.Should().NotHaveValue();

            show1Season2Episodes[2].Number.Should().Be(6);
            show1Season2Episodes[2].Rating.Should().NotHaveValue();
            show1Season2Episodes[2].RatedAt.Should().NotHaveValue();

            var show2Seasons = shows[1].Seasons.ToArray();

            show2Seasons[0].Number.Should().Be(1);
            show2Seasons[0].Episodes.Should().NotBeNull().And.HaveCount(3);
            show2Seasons[0].Rating.Should().NotHaveValue();
            show2Seasons[0].RatedAt.Should().NotHaveValue();

            show2Seasons[1].Number.Should().Be(2);
            show2Seasons[1].Episodes.Should().NotBeNull().And.HaveCount(3);
            show2Seasons[1].Rating.Should().NotHaveValue();
            show2Seasons[1].RatedAt.Should().NotHaveValue();

            var show2Season1Episodes = show2Seasons[0].Episodes.ToArray();

            show2Season1Episodes[0].Number.Should().Be(1);
            show2Season1Episodes[0].Rating.Should().NotHaveValue();
            show2Season1Episodes[0].RatedAt.Should().NotHaveValue();

            show2Season1Episodes[1].Number.Should().Be(2);
            show2Season1Episodes[1].Rating.Should().NotHaveValue();
            show2Season1Episodes[1].RatedAt.Should().NotHaveValue();

            show2Season1Episodes[2].Number.Should().Be(3);
            show2Season1Episodes[2].Rating.Should().NotHaveValue();
            show2Season1Episodes[2].RatedAt.Should().NotHaveValue();

            var show2Season2Episodes = show2Seasons[1].Episodes.ToArray();

            show2Season2Episodes[0].Number.Should().Be(4);
            show2Season2Episodes[0].Rating.Should().NotHaveValue();
            show2Season2Episodes[0].RatedAt.Should().NotHaveValue();

            show2Season2Episodes[1].Number.Should().Be(5);
            show2Season2Episodes[1].Rating.Should().NotHaveValue();
            show2Season2Episodes[1].RatedAt.Should().NotHaveValue();

            show2Season2Episodes[2].Number.Should().Be(6);
            show2Season2Episodes[2].Rating.Should().NotHaveValue();
            show2Season2Episodes[2].RatedAt.Should().NotHaveValue();

            // ---------------------------------------------------------

            builder = TraktSyncRatingsPost.Builder();

            builder.AddShow(show2, new PostRatingsSeasons { 1 });  // season 1

            ratingsPost = builder.Build();

            ratingsPost.Should().NotBeNull();
            ratingsPost.Episodes.Should().BeNull();
            ratingsPost.Shows.Should().NotBeNull().And.HaveCount(1);
            ratingsPost.Movies.Should().BeNull();

            shows = ratingsPost.Shows.ToArray();

            shows[0].Should().NotBeNull();
            shows[0].Title.Should().Be("show2");
            shows[0].Year.Should().Be(2016);
            shows[0].Ids.Should().NotBeNull();
            shows[0].Ids.Trakt.Should().Be(3U);
            shows[0].Ids.Slug.Should().Be("show2");
            shows[0].Ids.Imdb.Should().Be("imdb2");
            shows[0].Ids.Tmdb.Should().Be(12345U);
            shows[0].Ids.Tvdb.Should().Be(123456U);
            shows[0].Ids.TvRage.Should().Be(1234567U);
            shows[0].Rating.Should().NotHaveValue();
            shows[0].RatedAt.Should().NotHaveValue();
            shows[0].Seasons.Should().NotBeNull().And.HaveCount(1);

            show1Seasons = shows[0].Seasons.ToArray();

            show1Seasons[0].Number.Should().Be(1);
            show1Seasons[0].Episodes.Should().BeNull();
            show1Seasons[0].Rating.Should().NotHaveValue();
            show1Seasons[0].RatedAt.Should().NotHaveValue();

            // ---------------------------------------------------------

            builder = TraktSyncRatingsPost.Builder();

            builder.AddShow(show2, new PostRatingsSeasons {
                { 1, new PostRatingsEpisodes { 1, 2 } },    // season 1 - episode 1, 2
                2                                           // season 2
            });

            ratingsPost = builder.Build();

            ratingsPost.Should().NotBeNull();
            ratingsPost.Episodes.Should().BeNull();
            ratingsPost.Shows.Should().NotBeNull().And.HaveCount(1);
            ratingsPost.Movies.Should().BeNull();

            shows = ratingsPost.Shows.ToArray();

            shows[0].Should().NotBeNull();
            shows[0].Title.Should().Be("show2");
            shows[0].Year.Should().Be(2016);
            shows[0].Ids.Should().NotBeNull();
            shows[0].Ids.Trakt.Should().Be(3U);
            shows[0].Ids.Slug.Should().Be("show2");
            shows[0].Ids.Imdb.Should().Be("imdb2");
            shows[0].Ids.Tmdb.Should().Be(12345U);
            shows[0].Ids.Tvdb.Should().Be(123456U);
            shows[0].Ids.TvRage.Should().Be(1234567U);
            shows[0].Rating.Should().NotHaveValue();
            shows[0].RatedAt.Should().NotHaveValue();
            shows[0].Seasons.Should().NotBeNull().And.HaveCount(2);

            show1Seasons = shows[0].Seasons.ToArray();

            show1Seasons[0].Number.Should().Be(1);
            show1Seasons[0].Episodes.Should().NotBeNull().And.HaveCount(2);
            show1Seasons[0].Rating.Should().NotHaveValue();
            show1Seasons[0].RatedAt.Should().NotHaveValue();

            show1Seasons[1].Number.Should().Be(2);
            show1Seasons[1].Episodes.Should().BeNull();
            show1Seasons[1].Rating.Should().NotHaveValue();
            show1Seasons[1].RatedAt.Should().NotHaveValue();

            // ---------------------------------------------------------
            // ---------------------------------------------------------
            // ---------------------------------------------------------

            var seasonRating = 5;

            builder = TraktSyncRatingsPost.Builder();

            builder.AddShow(show2, new PostRatingsSeasons {
                { 1, seasonRating },    // season 1
                { 2, seasonRating }     // season 2
            });

            ratingsPost = builder.Build();

            ratingsPost.Should().NotBeNull();
            ratingsPost.Episodes.Should().BeNull();
            ratingsPost.Shows.Should().NotBeNull().And.HaveCount(1);
            ratingsPost.Movies.Should().BeNull();

            shows = ratingsPost.Shows.ToArray();

            shows[0].Should().NotBeNull();
            shows[0].Title.Should().Be("show2");
            shows[0].Year.Should().Be(2016);
            shows[0].Ids.Should().NotBeNull();
            shows[0].Ids.Trakt.Should().Be(3U);
            shows[0].Ids.Slug.Should().Be("show2");
            shows[0].Ids.Imdb.Should().Be("imdb2");
            shows[0].Ids.Tmdb.Should().Be(12345U);
            shows[0].Ids.Tvdb.Should().Be(123456U);
            shows[0].Ids.TvRage.Should().Be(1234567U);
            shows[0].Rating.Should().NotHaveValue();
            shows[0].RatedAt.Should().NotHaveValue();
            shows[0].Seasons.Should().NotBeNull().And.HaveCount(2);

            show1Seasons = shows[0].Seasons.ToArray();

            show1Seasons[0].Number.Should().Be(1);
            show1Seasons[0].Episodes.Should().BeNull();
            show1Seasons[0].Rating.Should().HaveValue();
            show1Seasons[0].RatedAt.Should().NotHaveValue();

            show1Seasons[1].Number.Should().Be(2);
            show1Seasons[1].Episodes.Should().BeNull();
            show1Seasons[1].Rating.Should().HaveValue();
            show1Seasons[1].RatedAt.Should().NotHaveValue();

            // ---------------------------------------------------------

            builder = TraktSyncRatingsPost.Builder();

            builder.AddShow(show2, new PostRatingsSeasons {
                { 1, seasonRating, DateTime.Now },    // season 1
                { 2, seasonRating, DateTime.Now }     // season 2
            });

            ratingsPost = builder.Build();

            ratingsPost.Should().NotBeNull();
            ratingsPost.Episodes.Should().BeNull();
            ratingsPost.Shows.Should().NotBeNull().And.HaveCount(1);
            ratingsPost.Movies.Should().BeNull();

            shows = ratingsPost.Shows.ToArray();

            shows[0].Should().NotBeNull();
            shows[0].Title.Should().Be("show2");
            shows[0].Year.Should().Be(2016);
            shows[0].Ids.Should().NotBeNull();
            shows[0].Ids.Trakt.Should().Be(3U);
            shows[0].Ids.Slug.Should().Be("show2");
            shows[0].Ids.Imdb.Should().Be("imdb2");
            shows[0].Ids.Tmdb.Should().Be(12345U);
            shows[0].Ids.Tvdb.Should().Be(123456U);
            shows[0].Ids.TvRage.Should().Be(1234567U);
            shows[0].Rating.Should().NotHaveValue();
            shows[0].RatedAt.Should().NotHaveValue();
            shows[0].Seasons.Should().NotBeNull().And.HaveCount(2);

            show1Seasons = shows[0].Seasons.ToArray();

            show1Seasons[0].Number.Should().Be(1);
            show1Seasons[0].Episodes.Should().BeNull();
            show1Seasons[0].Rating.Should().HaveValue();
            show1Seasons[0].RatedAt.Should().HaveValue();

            show1Seasons[1].Number.Should().Be(2);
            show1Seasons[1].Episodes.Should().BeNull();
            show1Seasons[1].Rating.Should().HaveValue();
            show1Seasons[1].RatedAt.Should().HaveValue();

            // ---------------------------------------------------------

            builder = TraktSyncRatingsPost.Builder();

            builder.AddShow(show2, new PostRatingsSeasons {
                { 1, seasonRating },                  // season 1
                { 2, seasonRating, DateTime.Now }     // season 2
            });

            ratingsPost = builder.Build();

            ratingsPost.Should().NotBeNull();
            ratingsPost.Episodes.Should().BeNull();
            ratingsPost.Shows.Should().NotBeNull().And.HaveCount(1);
            ratingsPost.Movies.Should().BeNull();

            shows = ratingsPost.Shows.ToArray();

            shows[0].Should().NotBeNull();
            shows[0].Title.Should().Be("show2");
            shows[0].Year.Should().Be(2016);
            shows[0].Ids.Should().NotBeNull();
            shows[0].Ids.Trakt.Should().Be(3U);
            shows[0].Ids.Slug.Should().Be("show2");
            shows[0].Ids.Imdb.Should().Be("imdb2");
            shows[0].Ids.Tmdb.Should().Be(12345U);
            shows[0].Ids.Tvdb.Should().Be(123456U);
            shows[0].Ids.TvRage.Should().Be(1234567U);
            shows[0].Rating.Should().NotHaveValue();
            shows[0].RatedAt.Should().NotHaveValue();
            shows[0].Seasons.Should().NotBeNull().And.HaveCount(2);

            show1Seasons = shows[0].Seasons.ToArray();

            show1Seasons[0].Number.Should().Be(1);
            show1Seasons[0].Episodes.Should().BeNull();
            show1Seasons[0].Rating.Should().HaveValue();
            show1Seasons[0].RatedAt.Should().NotHaveValue();

            show1Seasons[1].Number.Should().Be(2);
            show1Seasons[1].Episodes.Should().BeNull();
            show1Seasons[1].Rating.Should().HaveValue();
            show1Seasons[1].RatedAt.Should().HaveValue();

            // ---------------------------------------------------------

            var episodeRating = 5;

            builder = TraktSyncRatingsPost.Builder();

            builder.AddShow(show2, new PostRatingsSeasons {
                { 1, new PostRatingsEpisodes {  // season 1 - episode 1, 2, 3
                        { 1, episodeRating },
                        2,
                        { 3, episodeRating }
                    }
                },
                { 2, new PostRatingsEpisodes {  // season 2 - episode 4, 5, 6
                        4,
                        { 5, episodeRating },
                        6
                    }
                }
            });

            ratingsPost = builder.Build();

            ratingsPost.Should().NotBeNull();
            ratingsPost.Episodes.Should().BeNull();
            ratingsPost.Shows.Should().NotBeNull().And.HaveCount(1);
            ratingsPost.Movies.Should().BeNull();

            shows = ratingsPost.Shows.ToArray();

            shows[0].Should().NotBeNull();
            shows[0].Title.Should().Be("show2");
            shows[0].Year.Should().Be(2016);
            shows[0].Ids.Should().NotBeNull();
            shows[0].Ids.Trakt.Should().Be(3U);
            shows[0].Ids.Slug.Should().Be("show2");
            shows[0].Ids.Imdb.Should().Be("imdb2");
            shows[0].Ids.Tmdb.Should().Be(12345U);
            shows[0].Ids.Tvdb.Should().Be(123456U);
            shows[0].Ids.TvRage.Should().Be(1234567U);
            shows[0].Rating.Should().NotHaveValue();
            shows[0].RatedAt.Should().NotHaveValue();
            shows[0].Seasons.Should().NotBeNull().And.HaveCount(2);

            show1Seasons = shows[0].Seasons.ToArray();

            show1Seasons[0].Number.Should().Be(1);
            show1Seasons[0].Episodes.Should().NotBeNull().And.HaveCount(3);
            show1Seasons[0].Rating.Should().NotHaveValue();
            show1Seasons[0].RatedAt.Should().NotHaveValue();

            show1Seasons[1].Number.Should().Be(2);
            show1Seasons[1].Episodes.Should().NotBeNull().And.HaveCount(3);
            show1Seasons[1].Rating.Should().NotHaveValue();
            show1Seasons[1].RatedAt.Should().NotHaveValue();

            show1Season1Episodes = show1Seasons[0].Episodes.ToArray();

            show1Season1Episodes[0].Number.Should().Be(1);
            show1Season1Episodes[0].Rating.Should().HaveValue();
            show1Season1Episodes[0].RatedAt.Should().NotHaveValue();

            show1Season1Episodes[1].Number.Should().Be(2);
            show1Season1Episodes[1].Rating.Should().NotHaveValue();
            show1Season1Episodes[1].RatedAt.Should().NotHaveValue();

            show1Season1Episodes[2].Number.Should().Be(3);
            show1Season1Episodes[2].Rating.Should().HaveValue();
            show1Season1Episodes[2].RatedAt.Should().NotHaveValue();

            show1Season2Episodes = show1Seasons[1].Episodes.ToArray();

            show1Season2Episodes[0].Number.Should().Be(4);
            show1Season2Episodes[0].Rating.Should().NotHaveValue();
            show1Season2Episodes[0].RatedAt.Should().NotHaveValue();

            show1Season2Episodes[1].Number.Should().Be(5);
            show1Season2Episodes[1].Rating.Should().HaveValue();
            show1Season2Episodes[1].RatedAt.Should().NotHaveValue();

            show1Season2Episodes[2].Number.Should().Be(6);
            show1Season2Episodes[2].Rating.Should().NotHaveValue();
            show1Season2Episodes[2].RatedAt.Should().NotHaveValue();

            // ---------------------------------------------------------

            builder = TraktSyncRatingsPost.Builder();

            builder.AddShow(show2, new PostRatingsSeasons {
                { 1, new PostRatingsEpisodes {  // season 1 - episode 1, 2, 3
                        { 1, episodeRating, DateTime.Now },
                        2,
                        { 3, episodeRating, DateTime.Now }
                    }
                },
                { 2, new PostRatingsEpisodes {  // season 2 - episode 4, 5, 6
                        4,
                        { 5, episodeRating, DateTime.Now },
                        6
                    }
                }
            });

            ratingsPost = builder.Build();

            ratingsPost.Should().NotBeNull();
            ratingsPost.Episodes.Should().BeNull();
            ratingsPost.Shows.Should().NotBeNull().And.HaveCount(1);
            ratingsPost.Movies.Should().BeNull();

            shows = ratingsPost.Shows.ToArray();

            shows[0].Should().NotBeNull();
            shows[0].Title.Should().Be("show2");
            shows[0].Year.Should().Be(2016);
            shows[0].Ids.Should().NotBeNull();
            shows[0].Ids.Trakt.Should().Be(3U);
            shows[0].Ids.Slug.Should().Be("show2");
            shows[0].Ids.Imdb.Should().Be("imdb2");
            shows[0].Ids.Tmdb.Should().Be(12345U);
            shows[0].Ids.Tvdb.Should().Be(123456U);
            shows[0].Ids.TvRage.Should().Be(1234567U);
            shows[0].Rating.Should().NotHaveValue();
            shows[0].RatedAt.Should().NotHaveValue();
            shows[0].Seasons.Should().NotBeNull().And.HaveCount(2);

            show1Seasons = shows[0].Seasons.ToArray();

            show1Seasons[0].Number.Should().Be(1);
            show1Seasons[0].Episodes.Should().NotBeNull().And.HaveCount(3);
            show1Seasons[0].Rating.Should().NotHaveValue();
            show1Seasons[0].RatedAt.Should().NotHaveValue();

            show1Seasons[1].Number.Should().Be(2);
            show1Seasons[1].Episodes.Should().NotBeNull().And.HaveCount(3);
            show1Seasons[1].Rating.Should().NotHaveValue();
            show1Seasons[1].RatedAt.Should().NotHaveValue();

            show1Season1Episodes = show1Seasons[0].Episodes.ToArray();

            show1Season1Episodes[0].Number.Should().Be(1);
            show1Season1Episodes[0].Rating.Should().HaveValue();
            show1Season1Episodes[0].RatedAt.Should().HaveValue();

            show1Season1Episodes[1].Number.Should().Be(2);
            show1Season1Episodes[1].Rating.Should().NotHaveValue();
            show1Season1Episodes[1].RatedAt.Should().NotHaveValue();

            show1Season1Episodes[2].Number.Should().Be(3);
            show1Season1Episodes[2].Rating.Should().HaveValue();
            show1Season1Episodes[2].RatedAt.Should().HaveValue();

            show1Season2Episodes = show1Seasons[1].Episodes.ToArray();

            show1Season2Episodes[0].Number.Should().Be(4);
            show1Season2Episodes[0].Rating.Should().NotHaveValue();
            show1Season2Episodes[0].RatedAt.Should().NotHaveValue();

            show1Season2Episodes[1].Number.Should().Be(5);
            show1Season2Episodes[1].Rating.Should().HaveValue();
            show1Season2Episodes[1].RatedAt.Should().HaveValue();

            show1Season2Episodes[2].Number.Should().Be(6);
            show1Season2Episodes[2].Rating.Should().NotHaveValue();
            show1Season2Episodes[2].RatedAt.Should().NotHaveValue();

            // ---------------------------------------------------------

            builder = TraktSyncRatingsPost.Builder();

            builder.AddShow(show2, new PostRatingsSeasons {
                { 1, new PostRatingsEpisodes {  // season 1 - episode 1, 2, 3
                        { 1, episodeRating },
                        2,
                        { 3, episodeRating, DateTime.Now }
                    }
                },
                { 2, new PostRatingsEpisodes {  // season 2 - episode 4, 5, 6
                        4,
                        { 5, episodeRating },
                        6
                    }
                }
            });

            ratingsPost = builder.Build();

            ratingsPost.Should().NotBeNull();
            ratingsPost.Episodes.Should().BeNull();
            ratingsPost.Shows.Should().NotBeNull().And.HaveCount(1);
            ratingsPost.Movies.Should().BeNull();

            shows = ratingsPost.Shows.ToArray();

            shows[0].Should().NotBeNull();
            shows[0].Title.Should().Be("show2");
            shows[0].Year.Should().Be(2016);
            shows[0].Ids.Should().NotBeNull();
            shows[0].Ids.Trakt.Should().Be(3U);
            shows[0].Ids.Slug.Should().Be("show2");
            shows[0].Ids.Imdb.Should().Be("imdb2");
            shows[0].Ids.Tmdb.Should().Be(12345U);
            shows[0].Ids.Tvdb.Should().Be(123456U);
            shows[0].Ids.TvRage.Should().Be(1234567U);
            shows[0].Rating.Should().NotHaveValue();
            shows[0].RatedAt.Should().NotHaveValue();
            shows[0].Seasons.Should().NotBeNull().And.HaveCount(2);

            show1Seasons = shows[0].Seasons.ToArray();

            show1Seasons[0].Number.Should().Be(1);
            show1Seasons[0].Episodes.Should().NotBeNull().And.HaveCount(3);
            show1Seasons[0].Rating.Should().NotHaveValue();
            show1Seasons[0].RatedAt.Should().NotHaveValue();

            show1Seasons[1].Number.Should().Be(2);
            show1Seasons[1].Episodes.Should().NotBeNull().And.HaveCount(3);
            show1Seasons[1].Rating.Should().NotHaveValue();
            show1Seasons[1].RatedAt.Should().NotHaveValue();

            show1Season1Episodes = show1Seasons[0].Episodes.ToArray();

            show1Season1Episodes[0].Number.Should().Be(1);
            show1Season1Episodes[0].Rating.Should().HaveValue();
            show1Season1Episodes[0].RatedAt.Should().NotHaveValue();

            show1Season1Episodes[1].Number.Should().Be(2);
            show1Season1Episodes[1].Rating.Should().NotHaveValue();
            show1Season1Episodes[1].RatedAt.Should().NotHaveValue();

            show1Season1Episodes[2].Number.Should().Be(3);
            show1Season1Episodes[2].Rating.Should().HaveValue();
            show1Season1Episodes[2].RatedAt.Should().HaveValue();

            show1Season2Episodes = show1Seasons[1].Episodes.ToArray();

            show1Season2Episodes[0].Number.Should().Be(4);
            show1Season2Episodes[0].Rating.Should().NotHaveValue();
            show1Season2Episodes[0].RatedAt.Should().NotHaveValue();

            show1Season2Episodes[1].Number.Should().Be(5);
            show1Season2Episodes[1].Rating.Should().HaveValue();
            show1Season2Episodes[1].RatedAt.Should().NotHaveValue();

            show1Season2Episodes[2].Number.Should().Be(6);
            show1Season2Episodes[2].Rating.Should().NotHaveValue();
            show1Season2Episodes[2].RatedAt.Should().NotHaveValue();

            // ---------------------------------------------------------

            builder = TraktSyncRatingsPost.Builder();

            builder.AddShow(show2, new PostRatingsSeasons {
                { 1, seasonRating, new PostRatingsEpisodes {  // season 1 - episode 1, 2, 3
                        { 1, episodeRating },
                        2,
                        { 3, episodeRating }
                    }
                },
                { 2, seasonRating, new PostRatingsEpisodes {  // season 2 - episode 4, 5, 6
                        4,
                        { 5, episodeRating },
                        6
                    }
                }
            });

            ratingsPost = builder.Build();

            ratingsPost.Should().NotBeNull();
            ratingsPost.Episodes.Should().BeNull();
            ratingsPost.Shows.Should().NotBeNull().And.HaveCount(1);
            ratingsPost.Movies.Should().BeNull();

            shows = ratingsPost.Shows.ToArray();

            shows[0].Should().NotBeNull();
            shows[0].Title.Should().Be("show2");
            shows[0].Year.Should().Be(2016);
            shows[0].Ids.Should().NotBeNull();
            shows[0].Ids.Trakt.Should().Be(3U);
            shows[0].Ids.Slug.Should().Be("show2");
            shows[0].Ids.Imdb.Should().Be("imdb2");
            shows[0].Ids.Tmdb.Should().Be(12345U);
            shows[0].Ids.Tvdb.Should().Be(123456U);
            shows[0].Ids.TvRage.Should().Be(1234567U);
            shows[0].Rating.Should().NotHaveValue();
            shows[0].RatedAt.Should().NotHaveValue();
            shows[0].Seasons.Should().NotBeNull().And.HaveCount(2);

            show1Seasons = shows[0].Seasons.ToArray();

            show1Seasons[0].Number.Should().Be(1);
            show1Seasons[0].Episodes.Should().NotBeNull().And.HaveCount(3);
            show1Seasons[0].Rating.Should().HaveValue();
            show1Seasons[0].RatedAt.Should().NotHaveValue();

            show1Seasons[1].Number.Should().Be(2);
            show1Seasons[1].Episodes.Should().NotBeNull().And.HaveCount(3);
            show1Seasons[1].Rating.Should().HaveValue();
            show1Seasons[1].RatedAt.Should().NotHaveValue();

            show1Season1Episodes = show1Seasons[0].Episodes.ToArray();

            show1Season1Episodes[0].Number.Should().Be(1);
            show1Season1Episodes[0].Rating.Should().HaveValue();
            show1Season1Episodes[0].RatedAt.Should().NotHaveValue();

            show1Season1Episodes[1].Number.Should().Be(2);
            show1Season1Episodes[1].Rating.Should().NotHaveValue();
            show1Season1Episodes[1].RatedAt.Should().NotHaveValue();

            show1Season1Episodes[2].Number.Should().Be(3);
            show1Season1Episodes[2].Rating.Should().HaveValue();
            show1Season1Episodes[2].RatedAt.Should().NotHaveValue();

            show1Season2Episodes = show1Seasons[1].Episodes.ToArray();

            show1Season2Episodes[0].Number.Should().Be(4);
            show1Season2Episodes[0].Rating.Should().NotHaveValue();
            show1Season2Episodes[0].RatedAt.Should().NotHaveValue();

            show1Season2Episodes[1].Number.Should().Be(5);
            show1Season2Episodes[1].Rating.Should().HaveValue();
            show1Season2Episodes[1].RatedAt.Should().NotHaveValue();

            show1Season2Episodes[2].Number.Should().Be(6);
            show1Season2Episodes[2].Rating.Should().NotHaveValue();
            show1Season2Episodes[2].RatedAt.Should().NotHaveValue();

            // ---------------------------------------------------------

            builder = TraktSyncRatingsPost.Builder();

            builder.AddShow(show2, new PostRatingsSeasons {
                { 1, seasonRating, DateTime.Now, new PostRatingsEpisodes {  // season 1 - episode 1, 2, 3
                        { 1, episodeRating, DateTime.Now },
                        2,
                        { 3, episodeRating, DateTime.Now }
                    }
                },
                { 2, seasonRating, DateTime.Now, new PostRatingsEpisodes {  // season 2 - episode 4, 5, 6
                        4,
                        { 5, episodeRating, DateTime.Now },
                        6
                    }
                }
            });

            ratingsPost = builder.Build();

            ratingsPost.Should().NotBeNull();
            ratingsPost.Episodes.Should().BeNull();
            ratingsPost.Shows.Should().NotBeNull().And.HaveCount(1);
            ratingsPost.Movies.Should().BeNull();

            shows = ratingsPost.Shows.ToArray();

            shows[0].Should().NotBeNull();
            shows[0].Title.Should().Be("show2");
            shows[0].Year.Should().Be(2016);
            shows[0].Ids.Should().NotBeNull();
            shows[0].Ids.Trakt.Should().Be(3U);
            shows[0].Ids.Slug.Should().Be("show2");
            shows[0].Ids.Imdb.Should().Be("imdb2");
            shows[0].Ids.Tmdb.Should().Be(12345U);
            shows[0].Ids.Tvdb.Should().Be(123456U);
            shows[0].Ids.TvRage.Should().Be(1234567U);
            shows[0].Rating.Should().NotHaveValue();
            shows[0].RatedAt.Should().NotHaveValue();
            shows[0].Seasons.Should().NotBeNull().And.HaveCount(2);

            show1Seasons = shows[0].Seasons.ToArray();

            show1Seasons[0].Number.Should().Be(1);
            show1Seasons[0].Episodes.Should().NotBeNull().And.HaveCount(3);
            show1Seasons[0].Rating.Should().HaveValue();
            show1Seasons[0].RatedAt.Should().HaveValue();

            show1Seasons[1].Number.Should().Be(2);
            show1Seasons[1].Episodes.Should().NotBeNull().And.HaveCount(3);
            show1Seasons[1].Rating.Should().HaveValue();
            show1Seasons[1].RatedAt.Should().HaveValue();

            show1Season1Episodes = show1Seasons[0].Episodes.ToArray();

            show1Season1Episodes[0].Number.Should().Be(1);
            show1Season1Episodes[0].Rating.Should().HaveValue();
            show1Season1Episodes[0].RatedAt.Should().HaveValue();

            show1Season1Episodes[1].Number.Should().Be(2);
            show1Season1Episodes[1].Rating.Should().NotHaveValue();
            show1Season1Episodes[1].RatedAt.Should().NotHaveValue();

            show1Season1Episodes[2].Number.Should().Be(3);
            show1Season1Episodes[2].Rating.Should().HaveValue();
            show1Season1Episodes[2].RatedAt.Should().HaveValue();

            show1Season2Episodes = show1Seasons[1].Episodes.ToArray();

            show1Season2Episodes[0].Number.Should().Be(4);
            show1Season2Episodes[0].Rating.Should().NotHaveValue();
            show1Season2Episodes[0].RatedAt.Should().NotHaveValue();

            show1Season2Episodes[1].Number.Should().Be(5);
            show1Season2Episodes[1].Rating.Should().HaveValue();
            show1Season2Episodes[1].RatedAt.Should().HaveValue();

            show1Season2Episodes[2].Number.Should().Be(6);
            show1Season2Episodes[2].Rating.Should().NotHaveValue();
            show1Season2Episodes[2].RatedAt.Should().NotHaveValue();

            // ---------------------------------------------------------

            builder = TraktSyncRatingsPost.Builder();

            builder.AddShow(show2, new PostRatingsSeasons {
                { 1, seasonRating, new PostRatingsEpisodes {  // season 1 - episode 1, 2, 3
                        { 1, episodeRating, DateTime.Now },
                        2,
                        { 3, episodeRating, DateTime.Now }
                    }
                },
                { 2, seasonRating, DateTime.Now, new PostRatingsEpisodes {  // season 2 - episode 4, 5, 6
                        4,
                        { 5, episodeRating, DateTime.Now },
                        6
                    }
                }
            });

            ratingsPost = builder.Build();

            ratingsPost.Should().NotBeNull();
            ratingsPost.Episodes.Should().BeNull();
            ratingsPost.Shows.Should().NotBeNull().And.HaveCount(1);
            ratingsPost.Movies.Should().BeNull();

            shows = ratingsPost.Shows.ToArray();

            shows[0].Should().NotBeNull();
            shows[0].Title.Should().Be("show2");
            shows[0].Year.Should().Be(2016);
            shows[0].Ids.Should().NotBeNull();
            shows[0].Ids.Trakt.Should().Be(3U);
            shows[0].Ids.Slug.Should().Be("show2");
            shows[0].Ids.Imdb.Should().Be("imdb2");
            shows[0].Ids.Tmdb.Should().Be(12345U);
            shows[0].Ids.Tvdb.Should().Be(123456U);
            shows[0].Ids.TvRage.Should().Be(1234567U);
            shows[0].Rating.Should().NotHaveValue();
            shows[0].RatedAt.Should().NotHaveValue();
            shows[0].Seasons.Should().NotBeNull().And.HaveCount(2);

            show1Seasons = shows[0].Seasons.ToArray();

            show1Seasons[0].Number.Should().Be(1);
            show1Seasons[0].Episodes.Should().NotBeNull().And.HaveCount(3);
            show1Seasons[0].Rating.Should().HaveValue();
            show1Seasons[0].RatedAt.Should().NotHaveValue();

            show1Seasons[1].Number.Should().Be(2);
            show1Seasons[1].Episodes.Should().NotBeNull().And.HaveCount(3);
            show1Seasons[1].Rating.Should().HaveValue();
            show1Seasons[1].RatedAt.Should().HaveValue();

            show1Season1Episodes = show1Seasons[0].Episodes.ToArray();

            show1Season1Episodes[0].Number.Should().Be(1);
            show1Season1Episodes[0].Rating.Should().HaveValue();
            show1Season1Episodes[0].RatedAt.Should().HaveValue();

            show1Season1Episodes[1].Number.Should().Be(2);
            show1Season1Episodes[1].Rating.Should().NotHaveValue();
            show1Season1Episodes[1].RatedAt.Should().NotHaveValue();

            show1Season1Episodes[2].Number.Should().Be(3);
            show1Season1Episodes[2].Rating.Should().HaveValue();
            show1Season1Episodes[2].RatedAt.Should().HaveValue();

            show1Season2Episodes = show1Seasons[1].Episodes.ToArray();

            show1Season2Episodes[0].Number.Should().Be(4);
            show1Season2Episodes[0].Rating.Should().NotHaveValue();
            show1Season2Episodes[0].RatedAt.Should().NotHaveValue();

            show1Season2Episodes[1].Number.Should().Be(5);
            show1Season2Episodes[1].Rating.Should().HaveValue();
            show1Season2Episodes[1].RatedAt.Should().HaveValue();

            show1Season2Episodes[2].Number.Should().Be(6);
            show1Season2Episodes[2].Rating.Should().NotHaveValue();
            show1Season2Episodes[2].RatedAt.Should().NotHaveValue();
        }

        [TestMethod]
        public void TestTraktSyncRatingsPostBuilderAddShowWithSeasonsAndEpisodesAndRating()
        {
            var show1 = new TraktShow
            {
                Title = "show1",
                Year = 2016,
                Ids = new TraktShowIds
                {
                    Trakt = 1,
                    Slug = "show1",
                    Imdb = "imdb1",
                    Tmdb = 1234,
                    Tvdb = 12345,
                    TvRage = 123456
                }
            };

            var rating = 5;

            var builder = TraktSyncRatingsPost.Builder();

            builder.AddShowWithRating(show1, rating, new PostRatingsSeasons { { 1, new PostRatingsEpisodes { 1 } } }); // season 1 - episode 1

            var ratingsPost = builder.Build();

            ratingsPost.Should().NotBeNull();
            ratingsPost.Episodes.Should().BeNull();
            ratingsPost.Shows.Should().NotBeNull().And.HaveCount(1);
            ratingsPost.Movies.Should().BeNull();

            var shows = ratingsPost.Shows.ToArray();

            shows[0].Should().NotBeNull();
            shows[0].Title.Should().Be("show1");
            shows[0].Year.Should().Be(2016);
            shows[0].Ids.Should().NotBeNull();
            shows[0].Ids.Trakt.Should().Be(1U);
            shows[0].Ids.Slug.Should().Be("show1");
            shows[0].Ids.Imdb.Should().Be("imdb1");
            shows[0].Ids.Tmdb.Should().Be(1234U);
            shows[0].Ids.Tvdb.Should().Be(12345U);
            shows[0].Ids.TvRage.Should().Be(123456U);
            shows[0].Rating.Should().HaveValue();
            shows[0].RatedAt.Should().NotHaveValue();
            shows[0].Seasons.Should().NotBeNull().And.HaveCount(1);

            var show1Seasons = shows[0].Seasons.ToArray();

            show1Seasons[0].Number.Should().Be(1);
            show1Seasons[0].Episodes.Should().NotBeNull().And.HaveCount(1);
            show1Seasons[0].Rating.Should().NotHaveValue();
            show1Seasons[0].RatedAt.Should().NotHaveValue();

            var show1Season1Episodes = show1Seasons[0].Episodes.ToArray();

            show1Season1Episodes[0].Number.Should().Be(1);
            show1Season1Episodes[0].Rating.Should().NotHaveValue();
            show1Season1Episodes[0].RatedAt.Should().NotHaveValue();

            // ---------------------------------------------------------

            builder.AddShowWithRating(show1, rating, new PostRatingsSeasons { { 1, new PostRatingsEpisodes { 1, 2 } } }); // season 1 - episode 1, 2

            ratingsPost = builder.Build();

            ratingsPost.Should().NotBeNull();
            ratingsPost.Episodes.Should().BeNull();
            ratingsPost.Shows.Should().NotBeNull().And.HaveCount(1);
            ratingsPost.Movies.Should().BeNull();

            shows = ratingsPost.Shows.ToArray();

            shows[0].Should().NotBeNull();
            shows[0].Title.Should().Be("show1");
            shows[0].Year.Should().Be(2016);
            shows[0].Ids.Should().NotBeNull();
            shows[0].Ids.Trakt.Should().Be(1U);
            shows[0].Ids.Slug.Should().Be("show1");
            shows[0].Ids.Imdb.Should().Be("imdb1");
            shows[0].Ids.Tmdb.Should().Be(1234U);
            shows[0].Ids.Tvdb.Should().Be(12345U);
            shows[0].Ids.TvRage.Should().Be(123456U);
            shows[0].Rating.Should().HaveValue();
            shows[0].RatedAt.Should().NotHaveValue();
            shows[0].Seasons.Should().NotBeNull().And.HaveCount(1);

            show1Seasons = shows[0].Seasons.ToArray();

            show1Seasons[0].Number.Should().Be(1);
            show1Seasons[0].Episodes.Should().NotBeNull().And.HaveCount(2);
            show1Seasons[0].Rating.Should().NotHaveValue();
            show1Seasons[0].RatedAt.Should().NotHaveValue();

            show1Season1Episodes = show1Seasons[0].Episodes.ToArray();

            show1Season1Episodes[0].Number.Should().Be(1);
            show1Season1Episodes[0].Rating.Should().NotHaveValue();
            show1Season1Episodes[0].RatedAt.Should().NotHaveValue();

            show1Season1Episodes[1].Number.Should().Be(2);
            show1Season1Episodes[1].Rating.Should().NotHaveValue();
            show1Season1Episodes[1].RatedAt.Should().NotHaveValue();

            // ---------------------------------------------------------

            builder.AddShowWithRating(show1, rating, new PostRatingsSeasons { { 1, new PostRatingsEpisodes { 1, 2, 3 } } }); // season 1 - episode 1, 2, 3

            ratingsPost = builder.Build();

            ratingsPost.Should().NotBeNull();
            ratingsPost.Episodes.Should().BeNull();
            ratingsPost.Shows.Should().NotBeNull().And.HaveCount(1);
            ratingsPost.Movies.Should().BeNull();

            shows = ratingsPost.Shows.ToArray();

            shows[0].Should().NotBeNull();
            shows[0].Title.Should().Be("show1");
            shows[0].Year.Should().Be(2016);
            shows[0].Ids.Should().NotBeNull();
            shows[0].Ids.Trakt.Should().Be(1U);
            shows[0].Ids.Slug.Should().Be("show1");
            shows[0].Ids.Imdb.Should().Be("imdb1");
            shows[0].Ids.Tmdb.Should().Be(1234U);
            shows[0].Ids.Tvdb.Should().Be(12345U);
            shows[0].Ids.TvRage.Should().Be(123456U);
            shows[0].Rating.Should().HaveValue();
            shows[0].RatedAt.Should().NotHaveValue();
            shows[0].Seasons.Should().NotBeNull().And.HaveCount(1);

            show1Seasons = shows[0].Seasons.ToArray();

            show1Seasons[0].Number.Should().Be(1);
            show1Seasons[0].Episodes.Should().NotBeNull().And.HaveCount(3);
            show1Seasons[0].Rating.Should().NotHaveValue();
            show1Seasons[0].RatedAt.Should().NotHaveValue();

            show1Season1Episodes = show1Seasons[0].Episodes.ToArray();

            show1Season1Episodes[0].Number.Should().Be(1);
            show1Season1Episodes[0].Rating.Should().NotHaveValue();
            show1Season1Episodes[0].RatedAt.Should().NotHaveValue();

            show1Season1Episodes[1].Number.Should().Be(2);
            show1Season1Episodes[1].Rating.Should().NotHaveValue();
            show1Season1Episodes[1].RatedAt.Should().NotHaveValue();

            show1Season1Episodes[2].Number.Should().Be(3);
            show1Season1Episodes[2].Rating.Should().NotHaveValue();
            show1Season1Episodes[2].RatedAt.Should().NotHaveValue();

            // ---------------------------------------------------------

            builder.AddShowWithRating(show1, rating, new PostRatingsSeasons {
                { 1, new PostRatingsEpisodes { 1, 2, 3 } }, // season 1 - episode 1, 2, 3
                { 2, new PostRatingsEpisodes { 4 } }        // season 2 - episode 4
            });

            ratingsPost = builder.Build();

            ratingsPost.Should().NotBeNull();
            ratingsPost.Episodes.Should().BeNull();
            ratingsPost.Shows.Should().NotBeNull().And.HaveCount(1);
            ratingsPost.Movies.Should().BeNull();

            shows = ratingsPost.Shows.ToArray();

            shows[0].Should().NotBeNull();
            shows[0].Title.Should().Be("show1");
            shows[0].Year.Should().Be(2016);
            shows[0].Ids.Should().NotBeNull();
            shows[0].Ids.Trakt.Should().Be(1U);
            shows[0].Ids.Slug.Should().Be("show1");
            shows[0].Ids.Imdb.Should().Be("imdb1");
            shows[0].Ids.Tmdb.Should().Be(1234U);
            shows[0].Ids.Tvdb.Should().Be(12345U);
            shows[0].Ids.TvRage.Should().Be(123456U);
            shows[0].Rating.Should().HaveValue();
            shows[0].RatedAt.Should().NotHaveValue();
            shows[0].Seasons.Should().NotBeNull().And.HaveCount(2);

            show1Seasons = shows[0].Seasons.ToArray();

            show1Seasons[0].Number.Should().Be(1);
            show1Seasons[0].Episodes.Should().NotBeNull().And.HaveCount(3);
            show1Seasons[0].Rating.Should().NotHaveValue();
            show1Seasons[0].RatedAt.Should().NotHaveValue();

            show1Seasons[1].Number.Should().Be(2);
            show1Seasons[1].Episodes.Should().NotBeNull().And.HaveCount(1);
            show1Seasons[1].Rating.Should().NotHaveValue();
            show1Seasons[1].RatedAt.Should().NotHaveValue();

            show1Season1Episodes = show1Seasons[0].Episodes.ToArray();

            show1Season1Episodes[0].Number.Should().Be(1);
            show1Season1Episodes[0].Rating.Should().NotHaveValue();
            show1Season1Episodes[0].RatedAt.Should().NotHaveValue();

            show1Season1Episodes[1].Number.Should().Be(2);
            show1Season1Episodes[1].Rating.Should().NotHaveValue();
            show1Season1Episodes[1].RatedAt.Should().NotHaveValue();

            show1Season1Episodes[2].Number.Should().Be(3);
            show1Season1Episodes[2].Rating.Should().NotHaveValue();
            show1Season1Episodes[2].RatedAt.Should().NotHaveValue();

            var show1Season2Episodes = show1Seasons[1].Episodes.ToArray();

            show1Season2Episodes[0].Number.Should().Be(4);
            show1Season2Episodes[0].Rating.Should().NotHaveValue();
            show1Season2Episodes[0].RatedAt.Should().NotHaveValue();

            // ---------------------------------------------------------

            builder.AddShowWithRating(show1, rating, new PostRatingsSeasons {
                { 1, new PostRatingsEpisodes { 1, 2, 3 } }, // season 1 - episode 1, 2, 3
                { 2, new PostRatingsEpisodes { 4, 5 } }     // season 2 - episode 4, 5
            });

            ratingsPost = builder.Build();

            ratingsPost.Should().NotBeNull();
            ratingsPost.Episodes.Should().BeNull();
            ratingsPost.Shows.Should().NotBeNull().And.HaveCount(1);
            ratingsPost.Movies.Should().BeNull();

            shows = ratingsPost.Shows.ToArray();

            shows[0].Should().NotBeNull();
            shows[0].Title.Should().Be("show1");
            shows[0].Year.Should().Be(2016);
            shows[0].Ids.Should().NotBeNull();
            shows[0].Ids.Trakt.Should().Be(1U);
            shows[0].Ids.Slug.Should().Be("show1");
            shows[0].Ids.Imdb.Should().Be("imdb1");
            shows[0].Ids.Tmdb.Should().Be(1234U);
            shows[0].Ids.Tvdb.Should().Be(12345U);
            shows[0].Ids.TvRage.Should().Be(123456U);
            shows[0].Rating.Should().HaveValue();
            shows[0].RatedAt.Should().NotHaveValue();
            shows[0].Seasons.Should().NotBeNull().And.HaveCount(2);

            show1Seasons = shows[0].Seasons.ToArray();

            show1Seasons[0].Number.Should().Be(1);
            show1Seasons[0].Episodes.Should().NotBeNull().And.HaveCount(3);
            show1Seasons[0].Rating.Should().NotHaveValue();
            show1Seasons[0].RatedAt.Should().NotHaveValue();

            show1Seasons[1].Number.Should().Be(2);
            show1Seasons[1].Episodes.Should().NotBeNull().And.HaveCount(2);
            show1Seasons[1].Rating.Should().NotHaveValue();
            show1Seasons[1].RatedAt.Should().NotHaveValue();

            show1Season1Episodes = show1Seasons[0].Episodes.ToArray();

            show1Season1Episodes[0].Number.Should().Be(1);
            show1Season1Episodes[0].Rating.Should().NotHaveValue();
            show1Season1Episodes[0].RatedAt.Should().NotHaveValue();

            show1Season1Episodes[1].Number.Should().Be(2);
            show1Season1Episodes[1].Rating.Should().NotHaveValue();
            show1Season1Episodes[1].RatedAt.Should().NotHaveValue();

            show1Season1Episodes[2].Number.Should().Be(3);
            show1Season1Episodes[2].Rating.Should().NotHaveValue();
            show1Season1Episodes[2].RatedAt.Should().NotHaveValue();

            show1Season2Episodes = show1Seasons[1].Episodes.ToArray();

            show1Season2Episodes[0].Number.Should().Be(4);
            show1Season2Episodes[0].Rating.Should().NotHaveValue();
            show1Season2Episodes[0].RatedAt.Should().NotHaveValue();

            show1Season2Episodes[1].Number.Should().Be(5);
            show1Season2Episodes[1].Rating.Should().NotHaveValue();
            show1Season2Episodes[1].RatedAt.Should().NotHaveValue();

            // ---------------------------------------------------------

            builder.AddShowWithRating(show1, rating, new PostRatingsSeasons {
                { 1, new PostRatingsEpisodes { 1, 2, 3 } }, // season 1 - episode 1, 2, 3
                { 2, new PostRatingsEpisodes { 4, 5, 6 } }  // season 2 - episode 4, 5, 6
            });

            ratingsPost = builder.Build();

            ratingsPost.Should().NotBeNull();
            ratingsPost.Episodes.Should().BeNull();
            ratingsPost.Shows.Should().NotBeNull().And.HaveCount(1);
            ratingsPost.Movies.Should().BeNull();

            shows = ratingsPost.Shows.ToArray();

            shows[0].Should().NotBeNull();
            shows[0].Title.Should().Be("show1");
            shows[0].Year.Should().Be(2016);
            shows[0].Ids.Should().NotBeNull();
            shows[0].Ids.Trakt.Should().Be(1U);
            shows[0].Ids.Slug.Should().Be("show1");
            shows[0].Ids.Imdb.Should().Be("imdb1");
            shows[0].Ids.Tmdb.Should().Be(1234U);
            shows[0].Ids.Tvdb.Should().Be(12345U);
            shows[0].Ids.TvRage.Should().Be(123456U);
            shows[0].Rating.Should().HaveValue();
            shows[0].RatedAt.Should().NotHaveValue();
            shows[0].Seasons.Should().NotBeNull().And.HaveCount(2);

            show1Seasons = shows[0].Seasons.ToArray();

            show1Seasons[0].Number.Should().Be(1);
            show1Seasons[0].Episodes.Should().NotBeNull().And.HaveCount(3);
            show1Seasons[0].Rating.Should().NotHaveValue();
            show1Seasons[0].RatedAt.Should().NotHaveValue();

            show1Seasons[1].Number.Should().Be(2);
            show1Seasons[1].Episodes.Should().NotBeNull().And.HaveCount(3);
            show1Seasons[1].Rating.Should().NotHaveValue();
            show1Seasons[1].RatedAt.Should().NotHaveValue();

            show1Season1Episodes = show1Seasons[0].Episodes.ToArray();

            show1Season1Episodes[0].Number.Should().Be(1);
            show1Season1Episodes[0].Rating.Should().NotHaveValue();
            show1Season1Episodes[0].RatedAt.Should().NotHaveValue();

            show1Season1Episodes[1].Number.Should().Be(2);
            show1Season1Episodes[1].Rating.Should().NotHaveValue();
            show1Season1Episodes[1].RatedAt.Should().NotHaveValue();

            show1Season1Episodes[2].Number.Should().Be(3);
            show1Season1Episodes[2].Rating.Should().NotHaveValue();
            show1Season1Episodes[2].RatedAt.Should().NotHaveValue();

            show1Season2Episodes = show1Seasons[1].Episodes.ToArray();

            show1Season2Episodes[0].Number.Should().Be(4);
            show1Season2Episodes[0].Rating.Should().NotHaveValue();
            show1Season2Episodes[0].RatedAt.Should().NotHaveValue();

            show1Season2Episodes[1].Number.Should().Be(5);
            show1Season2Episodes[1].Rating.Should().NotHaveValue();
            show1Season2Episodes[1].RatedAt.Should().NotHaveValue();

            show1Season2Episodes[2].Number.Should().Be(6);
            show1Season2Episodes[2].Rating.Should().NotHaveValue();
            show1Season2Episodes[2].RatedAt.Should().NotHaveValue();

            // ---------------------------------------------------------

            show1.Ids.Trakt = 2;

            builder.AddShowWithRating(show1, rating, new PostRatingsSeasons {
                { 1, new PostRatingsEpisodes { 1, 2, 3 } }, // season 1 - episode 1, 2, 3
                { 2, new PostRatingsEpisodes { 4, 5, 6 } }  // season 2 - episode 4, 5, 6
            });

            ratingsPost = builder.Build();

            ratingsPost.Should().NotBeNull();
            ratingsPost.Episodes.Should().BeNull();
            ratingsPost.Shows.Should().NotBeNull().And.HaveCount(1);
            ratingsPost.Movies.Should().BeNull();

            shows = ratingsPost.Shows.ToArray();

            shows[0].Should().NotBeNull();
            shows[0].Title.Should().Be("show1");
            shows[0].Year.Should().Be(2016);
            shows[0].Ids.Should().NotBeNull();
            shows[0].Ids.Trakt.Should().Be(2U);
            shows[0].Ids.Slug.Should().Be("show1");
            shows[0].Ids.Imdb.Should().Be("imdb1");
            shows[0].Ids.Tmdb.Should().Be(1234U);
            shows[0].Ids.Tvdb.Should().Be(12345U);
            shows[0].Ids.TvRage.Should().Be(123456U);
            shows[0].Rating.Should().HaveValue();
            shows[0].RatedAt.Should().NotHaveValue();
            shows[0].Seasons.Should().NotBeNull().And.HaveCount(2);

            show1Seasons = shows[0].Seasons.ToArray();

            show1Seasons[0].Number.Should().Be(1);
            show1Seasons[0].Episodes.Should().NotBeNull().And.HaveCount(3);
            show1Seasons[0].Rating.Should().NotHaveValue();
            show1Seasons[0].RatedAt.Should().NotHaveValue();

            show1Seasons[1].Number.Should().Be(2);
            show1Seasons[1].Episodes.Should().NotBeNull().And.HaveCount(3);
            show1Seasons[1].Rating.Should().NotHaveValue();
            show1Seasons[1].RatedAt.Should().NotHaveValue();

            show1Season1Episodes = show1Seasons[0].Episodes.ToArray();

            show1Season1Episodes[0].Number.Should().Be(1);
            show1Season1Episodes[0].Rating.Should().NotHaveValue();
            show1Season1Episodes[0].RatedAt.Should().NotHaveValue();

            show1Season1Episodes[1].Number.Should().Be(2);
            show1Season1Episodes[1].Rating.Should().NotHaveValue();
            show1Season1Episodes[1].RatedAt.Should().NotHaveValue();

            show1Season1Episodes[2].Number.Should().Be(3);
            show1Season1Episodes[2].Rating.Should().NotHaveValue();
            show1Season1Episodes[2].RatedAt.Should().NotHaveValue();

            show1Season2Episodes = show1Seasons[1].Episodes.ToArray();

            show1Season2Episodes[0].Number.Should().Be(4);
            show1Season2Episodes[0].Rating.Should().NotHaveValue();
            show1Season2Episodes[0].RatedAt.Should().NotHaveValue();

            show1Season2Episodes[1].Number.Should().Be(5);
            show1Season2Episodes[1].Rating.Should().NotHaveValue();
            show1Season2Episodes[1].RatedAt.Should().NotHaveValue();

            show1Season2Episodes[2].Number.Should().Be(6);
            show1Season2Episodes[2].Rating.Should().NotHaveValue();
            show1Season2Episodes[2].RatedAt.Should().NotHaveValue();

            // ---------------------------------------------------------

            var show2 = new TraktShow
            {
                Title = "show2",
                Year = 2016,
                Ids = new TraktShowIds
                {
                    Trakt = 3,
                    Slug = "show2",
                    Imdb = "imdb2",
                    Tmdb = 12345,
                    Tvdb = 123456,
                    TvRage = 1234567
                }
            };

            builder.AddShowWithRating(show2, rating, new PostRatingsSeasons {
                { 1, new PostRatingsEpisodes { 1, 2, 3 } }, // season 1 - episode 1, 2, 3
                { 2, new PostRatingsEpisodes { 4, 5, 6 } }  // season 2 - episode 4, 5, 6
            });

            ratingsPost = builder.Build();

            ratingsPost.Should().NotBeNull();
            ratingsPost.Episodes.Should().BeNull();
            ratingsPost.Shows.Should().NotBeNull().And.HaveCount(2);
            ratingsPost.Movies.Should().BeNull();

            shows = ratingsPost.Shows.ToArray();

            shows[0].Should().NotBeNull();
            shows[0].Title.Should().Be("show1");
            shows[0].Year.Should().Be(2016);
            shows[0].Ids.Should().NotBeNull();
            shows[0].Ids.Trakt.Should().Be(2U);
            shows[0].Ids.Slug.Should().Be("show1");
            shows[0].Ids.Imdb.Should().Be("imdb1");
            shows[0].Ids.Tmdb.Should().Be(1234U);
            shows[0].Ids.Tvdb.Should().Be(12345U);
            shows[0].Ids.TvRage.Should().Be(123456U);
            shows[0].Rating.Should().HaveValue();
            shows[0].RatedAt.Should().NotHaveValue();
            shows[0].Seasons.Should().NotBeNull().And.HaveCount(2);

            shows[1].Should().NotBeNull();
            shows[1].Title.Should().Be("show2");
            shows[1].Year.Should().Be(2016);
            shows[1].Ids.Should().NotBeNull();
            shows[1].Ids.Trakt.Should().Be(3U);
            shows[1].Ids.Slug.Should().Be("show2");
            shows[1].Ids.Imdb.Should().Be("imdb2");
            shows[1].Ids.Tmdb.Should().Be(12345U);
            shows[1].Ids.Tvdb.Should().Be(123456U);
            shows[1].Ids.TvRage.Should().Be(1234567U);
            shows[1].Rating.Should().HaveValue();
            shows[1].RatedAt.Should().NotHaveValue();
            shows[1].Seasons.Should().NotBeNull().And.HaveCount(2);

            show1Seasons = shows[0].Seasons.ToArray();

            show1Seasons[0].Number.Should().Be(1);
            show1Seasons[0].Episodes.Should().NotBeNull().And.HaveCount(3);
            show1Seasons[0].Rating.Should().NotHaveValue();
            show1Seasons[0].RatedAt.Should().NotHaveValue();

            show1Seasons[1].Number.Should().Be(2);
            show1Seasons[1].Episodes.Should().NotBeNull().And.HaveCount(3);
            show1Seasons[1].Rating.Should().NotHaveValue();
            show1Seasons[1].RatedAt.Should().NotHaveValue();

            show1Season1Episodes = show1Seasons[0].Episodes.ToArray();

            show1Season1Episodes[0].Number.Should().Be(1);
            show1Season1Episodes[0].Rating.Should().NotHaveValue();
            show1Season1Episodes[0].RatedAt.Should().NotHaveValue();

            show1Season1Episodes[1].Number.Should().Be(2);
            show1Season1Episodes[1].Rating.Should().NotHaveValue();
            show1Season1Episodes[1].RatedAt.Should().NotHaveValue();

            show1Season1Episodes[2].Number.Should().Be(3);
            show1Season1Episodes[2].Rating.Should().NotHaveValue();
            show1Season1Episodes[2].RatedAt.Should().NotHaveValue();

            show1Season2Episodes = show1Seasons[1].Episodes.ToArray();

            show1Season2Episodes[0].Number.Should().Be(4);
            show1Season2Episodes[0].Rating.Should().NotHaveValue();
            show1Season2Episodes[0].RatedAt.Should().NotHaveValue();

            show1Season2Episodes[1].Number.Should().Be(5);
            show1Season2Episodes[1].Rating.Should().NotHaveValue();
            show1Season2Episodes[1].RatedAt.Should().NotHaveValue();

            show1Season2Episodes[2].Number.Should().Be(6);
            show1Season2Episodes[2].Rating.Should().NotHaveValue();
            show1Season2Episodes[2].RatedAt.Should().NotHaveValue();

            var show2Seasons = shows[1].Seasons.ToArray();

            show2Seasons[0].Number.Should().Be(1);
            show2Seasons[0].Episodes.Should().NotBeNull().And.HaveCount(3);
            show2Seasons[0].Rating.Should().NotHaveValue();
            show2Seasons[0].RatedAt.Should().NotHaveValue();

            show2Seasons[1].Number.Should().Be(2);
            show2Seasons[1].Episodes.Should().NotBeNull().And.HaveCount(3);
            show2Seasons[1].Rating.Should().NotHaveValue();
            show2Seasons[1].RatedAt.Should().NotHaveValue();

            var show2Season1Episodes = show2Seasons[0].Episodes.ToArray();

            show2Season1Episodes[0].Number.Should().Be(1);
            show2Season1Episodes[0].Rating.Should().NotHaveValue();
            show2Season1Episodes[0].RatedAt.Should().NotHaveValue();

            show2Season1Episodes[1].Number.Should().Be(2);
            show2Season1Episodes[1].Rating.Should().NotHaveValue();
            show2Season1Episodes[1].RatedAt.Should().NotHaveValue();

            show2Season1Episodes[2].Number.Should().Be(3);
            show2Season1Episodes[2].Rating.Should().NotHaveValue();
            show2Season1Episodes[2].RatedAt.Should().NotHaveValue();

            var show2Season2Episodes = show2Seasons[1].Episodes.ToArray();

            show2Season2Episodes[0].Number.Should().Be(4);
            show2Season2Episodes[0].Rating.Should().NotHaveValue();
            show2Season2Episodes[0].RatedAt.Should().NotHaveValue();

            show2Season2Episodes[1].Number.Should().Be(5);
            show2Season2Episodes[1].Rating.Should().NotHaveValue();
            show2Season2Episodes[1].RatedAt.Should().NotHaveValue();

            show2Season2Episodes[2].Number.Should().Be(6);
            show2Season2Episodes[2].Rating.Should().NotHaveValue();
            show2Season2Episodes[2].RatedAt.Should().NotHaveValue();

            // ---------------------------------------------------------

            builder = TraktSyncRatingsPost.Builder();

            builder.AddShowWithRating(show2, rating, new PostRatingsSeasons { 1 });  // season 1

            ratingsPost = builder.Build();

            ratingsPost.Should().NotBeNull();
            ratingsPost.Episodes.Should().BeNull();
            ratingsPost.Shows.Should().NotBeNull().And.HaveCount(1);
            ratingsPost.Movies.Should().BeNull();

            shows = ratingsPost.Shows.ToArray();

            shows[0].Should().NotBeNull();
            shows[0].Title.Should().Be("show2");
            shows[0].Year.Should().Be(2016);
            shows[0].Ids.Should().NotBeNull();
            shows[0].Ids.Trakt.Should().Be(3U);
            shows[0].Ids.Slug.Should().Be("show2");
            shows[0].Ids.Imdb.Should().Be("imdb2");
            shows[0].Ids.Tmdb.Should().Be(12345U);
            shows[0].Ids.Tvdb.Should().Be(123456U);
            shows[0].Ids.TvRage.Should().Be(1234567U);
            shows[0].Rating.Should().HaveValue();
            shows[0].RatedAt.Should().NotHaveValue();
            shows[0].Seasons.Should().NotBeNull().And.HaveCount(1);

            show1Seasons = shows[0].Seasons.ToArray();

            show1Seasons[0].Number.Should().Be(1);
            show1Seasons[0].Episodes.Should().BeNull();
            show1Seasons[0].Rating.Should().NotHaveValue();
            show1Seasons[0].RatedAt.Should().NotHaveValue();

            // ---------------------------------------------------------

            builder = TraktSyncRatingsPost.Builder();

            builder.AddShowWithRating(show2, rating, new PostRatingsSeasons {
                { 1, new PostRatingsEpisodes { 1, 2 } },    // season 1 - episode 1, 2
                2                                           // season 2
            });

            ratingsPost = builder.Build();

            ratingsPost.Should().NotBeNull();
            ratingsPost.Episodes.Should().BeNull();
            ratingsPost.Shows.Should().NotBeNull().And.HaveCount(1);
            ratingsPost.Movies.Should().BeNull();

            shows = ratingsPost.Shows.ToArray();

            shows[0].Should().NotBeNull();
            shows[0].Title.Should().Be("show2");
            shows[0].Year.Should().Be(2016);
            shows[0].Ids.Should().NotBeNull();
            shows[0].Ids.Trakt.Should().Be(3U);
            shows[0].Ids.Slug.Should().Be("show2");
            shows[0].Ids.Imdb.Should().Be("imdb2");
            shows[0].Ids.Tmdb.Should().Be(12345U);
            shows[0].Ids.Tvdb.Should().Be(123456U);
            shows[0].Ids.TvRage.Should().Be(1234567U);
            shows[0].Rating.Should().HaveValue();
            shows[0].RatedAt.Should().NotHaveValue();
            shows[0].Seasons.Should().NotBeNull().And.HaveCount(2);

            show1Seasons = shows[0].Seasons.ToArray();

            show1Seasons[0].Number.Should().Be(1);
            show1Seasons[0].Episodes.Should().NotBeNull().And.HaveCount(2);
            show1Seasons[0].Rating.Should().NotHaveValue();
            show1Seasons[0].RatedAt.Should().NotHaveValue();

            show1Seasons[1].Number.Should().Be(2);
            show1Seasons[1].Episodes.Should().BeNull();
            show1Seasons[1].Rating.Should().NotHaveValue();
            show1Seasons[1].RatedAt.Should().NotHaveValue();

            // ---------------------------------------------------------
            // ---------------------------------------------------------
            // ---------------------------------------------------------

            var seasonRating = 5;

            builder = TraktSyncRatingsPost.Builder();

            builder.AddShowWithRating(show2, rating, new PostRatingsSeasons {
                { 1, seasonRating },    // season 1
                { 2, seasonRating }     // season 2
            });

            ratingsPost = builder.Build();

            ratingsPost.Should().NotBeNull();
            ratingsPost.Episodes.Should().BeNull();
            ratingsPost.Shows.Should().NotBeNull().And.HaveCount(1);
            ratingsPost.Movies.Should().BeNull();

            shows = ratingsPost.Shows.ToArray();

            shows[0].Should().NotBeNull();
            shows[0].Title.Should().Be("show2");
            shows[0].Year.Should().Be(2016);
            shows[0].Ids.Should().NotBeNull();
            shows[0].Ids.Trakt.Should().Be(3U);
            shows[0].Ids.Slug.Should().Be("show2");
            shows[0].Ids.Imdb.Should().Be("imdb2");
            shows[0].Ids.Tmdb.Should().Be(12345U);
            shows[0].Ids.Tvdb.Should().Be(123456U);
            shows[0].Ids.TvRage.Should().Be(1234567U);
            shows[0].Rating.Should().HaveValue();
            shows[0].RatedAt.Should().NotHaveValue();
            shows[0].Seasons.Should().NotBeNull().And.HaveCount(2);

            show1Seasons = shows[0].Seasons.ToArray();

            show1Seasons[0].Number.Should().Be(1);
            show1Seasons[0].Episodes.Should().BeNull();
            show1Seasons[0].Rating.Should().HaveValue();
            show1Seasons[0].RatedAt.Should().NotHaveValue();

            show1Seasons[1].Number.Should().Be(2);
            show1Seasons[1].Episodes.Should().BeNull();
            show1Seasons[1].Rating.Should().HaveValue();
            show1Seasons[1].RatedAt.Should().NotHaveValue();

            // ---------------------------------------------------------

            builder = TraktSyncRatingsPost.Builder();

            builder.AddShowWithRating(show2, rating, new PostRatingsSeasons {
                { 1, seasonRating, DateTime.Now },    // season 1
                { 2, seasonRating, DateTime.Now }     // season 2
            });

            ratingsPost = builder.Build();

            ratingsPost.Should().NotBeNull();
            ratingsPost.Episodes.Should().BeNull();
            ratingsPost.Shows.Should().NotBeNull().And.HaveCount(1);
            ratingsPost.Movies.Should().BeNull();

            shows = ratingsPost.Shows.ToArray();

            shows[0].Should().NotBeNull();
            shows[0].Title.Should().Be("show2");
            shows[0].Year.Should().Be(2016);
            shows[0].Ids.Should().NotBeNull();
            shows[0].Ids.Trakt.Should().Be(3U);
            shows[0].Ids.Slug.Should().Be("show2");
            shows[0].Ids.Imdb.Should().Be("imdb2");
            shows[0].Ids.Tmdb.Should().Be(12345U);
            shows[0].Ids.Tvdb.Should().Be(123456U);
            shows[0].Ids.TvRage.Should().Be(1234567U);
            shows[0].Rating.Should().HaveValue();
            shows[0].RatedAt.Should().NotHaveValue();
            shows[0].Seasons.Should().NotBeNull().And.HaveCount(2);

            show1Seasons = shows[0].Seasons.ToArray();

            show1Seasons[0].Number.Should().Be(1);
            show1Seasons[0].Episodes.Should().BeNull();
            show1Seasons[0].Rating.Should().HaveValue();
            show1Seasons[0].RatedAt.Should().HaveValue();

            show1Seasons[1].Number.Should().Be(2);
            show1Seasons[1].Episodes.Should().BeNull();
            show1Seasons[1].Rating.Should().HaveValue();
            show1Seasons[1].RatedAt.Should().HaveValue();

            // ---------------------------------------------------------

            builder = TraktSyncRatingsPost.Builder();

            builder.AddShowWithRating(show2, rating, new PostRatingsSeasons {
                { 1, seasonRating },                  // season 1
                { 2, seasonRating, DateTime.Now }     // season 2
            });

            ratingsPost = builder.Build();

            ratingsPost.Should().NotBeNull();
            ratingsPost.Episodes.Should().BeNull();
            ratingsPost.Shows.Should().NotBeNull().And.HaveCount(1);
            ratingsPost.Movies.Should().BeNull();

            shows = ratingsPost.Shows.ToArray();

            shows[0].Should().NotBeNull();
            shows[0].Title.Should().Be("show2");
            shows[0].Year.Should().Be(2016);
            shows[0].Ids.Should().NotBeNull();
            shows[0].Ids.Trakt.Should().Be(3U);
            shows[0].Ids.Slug.Should().Be("show2");
            shows[0].Ids.Imdb.Should().Be("imdb2");
            shows[0].Ids.Tmdb.Should().Be(12345U);
            shows[0].Ids.Tvdb.Should().Be(123456U);
            shows[0].Ids.TvRage.Should().Be(1234567U);
            shows[0].Rating.Should().HaveValue();
            shows[0].RatedAt.Should().NotHaveValue();
            shows[0].Seasons.Should().NotBeNull().And.HaveCount(2);

            show1Seasons = shows[0].Seasons.ToArray();

            show1Seasons[0].Number.Should().Be(1);
            show1Seasons[0].Episodes.Should().BeNull();
            show1Seasons[0].Rating.Should().HaveValue();
            show1Seasons[0].RatedAt.Should().NotHaveValue();

            show1Seasons[1].Number.Should().Be(2);
            show1Seasons[1].Episodes.Should().BeNull();
            show1Seasons[1].Rating.Should().HaveValue();
            show1Seasons[1].RatedAt.Should().HaveValue();

            // ---------------------------------------------------------

            var episodeRating = 5;

            builder = TraktSyncRatingsPost.Builder();

            builder.AddShowWithRating(show2, rating, new PostRatingsSeasons {
                { 1, new PostRatingsEpisodes {  // season 1 - episode 1, 2, 3
                        { 1, episodeRating },
                        2,
                        { 3, episodeRating }
                    }
                },
                { 2, new PostRatingsEpisodes {  // season 2 - episode 4, 5, 6
                        4,
                        { 5, episodeRating },
                        6
                    }
                }
            });

            ratingsPost = builder.Build();

            ratingsPost.Should().NotBeNull();
            ratingsPost.Episodes.Should().BeNull();
            ratingsPost.Shows.Should().NotBeNull().And.HaveCount(1);
            ratingsPost.Movies.Should().BeNull();

            shows = ratingsPost.Shows.ToArray();

            shows[0].Should().NotBeNull();
            shows[0].Title.Should().Be("show2");
            shows[0].Year.Should().Be(2016);
            shows[0].Ids.Should().NotBeNull();
            shows[0].Ids.Trakt.Should().Be(3U);
            shows[0].Ids.Slug.Should().Be("show2");
            shows[0].Ids.Imdb.Should().Be("imdb2");
            shows[0].Ids.Tmdb.Should().Be(12345U);
            shows[0].Ids.Tvdb.Should().Be(123456U);
            shows[0].Ids.TvRage.Should().Be(1234567U);
            shows[0].Rating.Should().HaveValue();
            shows[0].RatedAt.Should().NotHaveValue();
            shows[0].Seasons.Should().NotBeNull().And.HaveCount(2);

            show1Seasons = shows[0].Seasons.ToArray();

            show1Seasons[0].Number.Should().Be(1);
            show1Seasons[0].Episodes.Should().NotBeNull().And.HaveCount(3);
            show1Seasons[0].Rating.Should().NotHaveValue();
            show1Seasons[0].RatedAt.Should().NotHaveValue();

            show1Seasons[1].Number.Should().Be(2);
            show1Seasons[1].Episodes.Should().NotBeNull().And.HaveCount(3);
            show1Seasons[1].Rating.Should().NotHaveValue();
            show1Seasons[1].RatedAt.Should().NotHaveValue();

            show1Season1Episodes = show1Seasons[0].Episodes.ToArray();

            show1Season1Episodes[0].Number.Should().Be(1);
            show1Season1Episodes[0].Rating.Should().HaveValue();
            show1Season1Episodes[0].RatedAt.Should().NotHaveValue();

            show1Season1Episodes[1].Number.Should().Be(2);
            show1Season1Episodes[1].Rating.Should().NotHaveValue();
            show1Season1Episodes[1].RatedAt.Should().NotHaveValue();

            show1Season1Episodes[2].Number.Should().Be(3);
            show1Season1Episodes[2].Rating.Should().HaveValue();
            show1Season1Episodes[2].RatedAt.Should().NotHaveValue();

            show1Season2Episodes = show1Seasons[1].Episodes.ToArray();

            show1Season2Episodes[0].Number.Should().Be(4);
            show1Season2Episodes[0].Rating.Should().NotHaveValue();
            show1Season2Episodes[0].RatedAt.Should().NotHaveValue();

            show1Season2Episodes[1].Number.Should().Be(5);
            show1Season2Episodes[1].Rating.Should().HaveValue();
            show1Season2Episodes[1].RatedAt.Should().NotHaveValue();

            show1Season2Episodes[2].Number.Should().Be(6);
            show1Season2Episodes[2].Rating.Should().NotHaveValue();
            show1Season2Episodes[2].RatedAt.Should().NotHaveValue();

            // ---------------------------------------------------------

            builder = TraktSyncRatingsPost.Builder();

            builder.AddShowWithRating(show2, rating, new PostRatingsSeasons {
                { 1, new PostRatingsEpisodes {  // season 1 - episode 1, 2, 3
                        { 1, episodeRating, DateTime.Now },
                        2,
                        { 3, episodeRating, DateTime.Now }
                    }
                },
                { 2, new PostRatingsEpisodes {  // season 2 - episode 4, 5, 6
                        4,
                        { 5, episodeRating, DateTime.Now },
                        6
                    }
                }
            });

            ratingsPost = builder.Build();

            ratingsPost.Should().NotBeNull();
            ratingsPost.Episodes.Should().BeNull();
            ratingsPost.Shows.Should().NotBeNull().And.HaveCount(1);
            ratingsPost.Movies.Should().BeNull();

            shows = ratingsPost.Shows.ToArray();

            shows[0].Should().NotBeNull();
            shows[0].Title.Should().Be("show2");
            shows[0].Year.Should().Be(2016);
            shows[0].Ids.Should().NotBeNull();
            shows[0].Ids.Trakt.Should().Be(3U);
            shows[0].Ids.Slug.Should().Be("show2");
            shows[0].Ids.Imdb.Should().Be("imdb2");
            shows[0].Ids.Tmdb.Should().Be(12345U);
            shows[0].Ids.Tvdb.Should().Be(123456U);
            shows[0].Ids.TvRage.Should().Be(1234567U);
            shows[0].Rating.Should().HaveValue();
            shows[0].RatedAt.Should().NotHaveValue();
            shows[0].Seasons.Should().NotBeNull().And.HaveCount(2);

            show1Seasons = shows[0].Seasons.ToArray();

            show1Seasons[0].Number.Should().Be(1);
            show1Seasons[0].Episodes.Should().NotBeNull().And.HaveCount(3);
            show1Seasons[0].Rating.Should().NotHaveValue();
            show1Seasons[0].RatedAt.Should().NotHaveValue();

            show1Seasons[1].Number.Should().Be(2);
            show1Seasons[1].Episodes.Should().NotBeNull().And.HaveCount(3);
            show1Seasons[1].Rating.Should().NotHaveValue();
            show1Seasons[1].RatedAt.Should().NotHaveValue();

            show1Season1Episodes = show1Seasons[0].Episodes.ToArray();

            show1Season1Episodes[0].Number.Should().Be(1);
            show1Season1Episodes[0].Rating.Should().HaveValue();
            show1Season1Episodes[0].RatedAt.Should().HaveValue();

            show1Season1Episodes[1].Number.Should().Be(2);
            show1Season1Episodes[1].Rating.Should().NotHaveValue();
            show1Season1Episodes[1].RatedAt.Should().NotHaveValue();

            show1Season1Episodes[2].Number.Should().Be(3);
            show1Season1Episodes[2].Rating.Should().HaveValue();
            show1Season1Episodes[2].RatedAt.Should().HaveValue();

            show1Season2Episodes = show1Seasons[1].Episodes.ToArray();

            show1Season2Episodes[0].Number.Should().Be(4);
            show1Season2Episodes[0].Rating.Should().NotHaveValue();
            show1Season2Episodes[0].RatedAt.Should().NotHaveValue();

            show1Season2Episodes[1].Number.Should().Be(5);
            show1Season2Episodes[1].Rating.Should().HaveValue();
            show1Season2Episodes[1].RatedAt.Should().HaveValue();

            show1Season2Episodes[2].Number.Should().Be(6);
            show1Season2Episodes[2].Rating.Should().NotHaveValue();
            show1Season2Episodes[2].RatedAt.Should().NotHaveValue();

            // ---------------------------------------------------------

            builder = TraktSyncRatingsPost.Builder();

            builder.AddShowWithRating(show2, rating, new PostRatingsSeasons {
                { 1, new PostRatingsEpisodes {  // season 1 - episode 1, 2, 3
                        { 1, episodeRating },
                        2,
                        { 3, episodeRating, DateTime.Now }
                    }
                },
                { 2, new PostRatingsEpisodes {  // season 2 - episode 4, 5, 6
                        4,
                        { 5, episodeRating },
                        6
                    }
                }
            });

            ratingsPost = builder.Build();

            ratingsPost.Should().NotBeNull();
            ratingsPost.Episodes.Should().BeNull();
            ratingsPost.Shows.Should().NotBeNull().And.HaveCount(1);
            ratingsPost.Movies.Should().BeNull();

            shows = ratingsPost.Shows.ToArray();

            shows[0].Should().NotBeNull();
            shows[0].Title.Should().Be("show2");
            shows[0].Year.Should().Be(2016);
            shows[0].Ids.Should().NotBeNull();
            shows[0].Ids.Trakt.Should().Be(3U);
            shows[0].Ids.Slug.Should().Be("show2");
            shows[0].Ids.Imdb.Should().Be("imdb2");
            shows[0].Ids.Tmdb.Should().Be(12345U);
            shows[0].Ids.Tvdb.Should().Be(123456U);
            shows[0].Ids.TvRage.Should().Be(1234567U);
            shows[0].Rating.Should().HaveValue();
            shows[0].RatedAt.Should().NotHaveValue();
            shows[0].Seasons.Should().NotBeNull().And.HaveCount(2);

            show1Seasons = shows[0].Seasons.ToArray();

            show1Seasons[0].Number.Should().Be(1);
            show1Seasons[0].Episodes.Should().NotBeNull().And.HaveCount(3);
            show1Seasons[0].Rating.Should().NotHaveValue();
            show1Seasons[0].RatedAt.Should().NotHaveValue();

            show1Seasons[1].Number.Should().Be(2);
            show1Seasons[1].Episodes.Should().NotBeNull().And.HaveCount(3);
            show1Seasons[1].Rating.Should().NotHaveValue();
            show1Seasons[1].RatedAt.Should().NotHaveValue();

            show1Season1Episodes = show1Seasons[0].Episodes.ToArray();

            show1Season1Episodes[0].Number.Should().Be(1);
            show1Season1Episodes[0].Rating.Should().HaveValue();
            show1Season1Episodes[0].RatedAt.Should().NotHaveValue();

            show1Season1Episodes[1].Number.Should().Be(2);
            show1Season1Episodes[1].Rating.Should().NotHaveValue();
            show1Season1Episodes[1].RatedAt.Should().NotHaveValue();

            show1Season1Episodes[2].Number.Should().Be(3);
            show1Season1Episodes[2].Rating.Should().HaveValue();
            show1Season1Episodes[2].RatedAt.Should().HaveValue();

            show1Season2Episodes = show1Seasons[1].Episodes.ToArray();

            show1Season2Episodes[0].Number.Should().Be(4);
            show1Season2Episodes[0].Rating.Should().NotHaveValue();
            show1Season2Episodes[0].RatedAt.Should().NotHaveValue();

            show1Season2Episodes[1].Number.Should().Be(5);
            show1Season2Episodes[1].Rating.Should().HaveValue();
            show1Season2Episodes[1].RatedAt.Should().NotHaveValue();

            show1Season2Episodes[2].Number.Should().Be(6);
            show1Season2Episodes[2].Rating.Should().NotHaveValue();
            show1Season2Episodes[2].RatedAt.Should().NotHaveValue();

            // ---------------------------------------------------------

            builder = TraktSyncRatingsPost.Builder();

            builder.AddShowWithRating(show2, rating, new PostRatingsSeasons {
                { 1, seasonRating, new PostRatingsEpisodes {  // season 1 - episode 1, 2, 3
                        { 1, episodeRating },
                        2,
                        { 3, episodeRating }
                    }
                },
                { 2, seasonRating, new PostRatingsEpisodes {  // season 2 - episode 4, 5, 6
                        4,
                        { 5, episodeRating },
                        6
                    }
                }
            });

            ratingsPost = builder.Build();

            ratingsPost.Should().NotBeNull();
            ratingsPost.Episodes.Should().BeNull();
            ratingsPost.Shows.Should().NotBeNull().And.HaveCount(1);
            ratingsPost.Movies.Should().BeNull();

            shows = ratingsPost.Shows.ToArray();

            shows[0].Should().NotBeNull();
            shows[0].Title.Should().Be("show2");
            shows[0].Year.Should().Be(2016);
            shows[0].Ids.Should().NotBeNull();
            shows[0].Ids.Trakt.Should().Be(3U);
            shows[0].Ids.Slug.Should().Be("show2");
            shows[0].Ids.Imdb.Should().Be("imdb2");
            shows[0].Ids.Tmdb.Should().Be(12345U);
            shows[0].Ids.Tvdb.Should().Be(123456U);
            shows[0].Ids.TvRage.Should().Be(1234567U);
            shows[0].Rating.Should().HaveValue();
            shows[0].RatedAt.Should().NotHaveValue();
            shows[0].Seasons.Should().NotBeNull().And.HaveCount(2);

            show1Seasons = shows[0].Seasons.ToArray();

            show1Seasons[0].Number.Should().Be(1);
            show1Seasons[0].Episodes.Should().NotBeNull().And.HaveCount(3);
            show1Seasons[0].Rating.Should().HaveValue();
            show1Seasons[0].RatedAt.Should().NotHaveValue();

            show1Seasons[1].Number.Should().Be(2);
            show1Seasons[1].Episodes.Should().NotBeNull().And.HaveCount(3);
            show1Seasons[1].Rating.Should().HaveValue();
            show1Seasons[1].RatedAt.Should().NotHaveValue();

            show1Season1Episodes = show1Seasons[0].Episodes.ToArray();

            show1Season1Episodes[0].Number.Should().Be(1);
            show1Season1Episodes[0].Rating.Should().HaveValue();
            show1Season1Episodes[0].RatedAt.Should().NotHaveValue();

            show1Season1Episodes[1].Number.Should().Be(2);
            show1Season1Episodes[1].Rating.Should().NotHaveValue();
            show1Season1Episodes[1].RatedAt.Should().NotHaveValue();

            show1Season1Episodes[2].Number.Should().Be(3);
            show1Season1Episodes[2].Rating.Should().HaveValue();
            show1Season1Episodes[2].RatedAt.Should().NotHaveValue();

            show1Season2Episodes = show1Seasons[1].Episodes.ToArray();

            show1Season2Episodes[0].Number.Should().Be(4);
            show1Season2Episodes[0].Rating.Should().NotHaveValue();
            show1Season2Episodes[0].RatedAt.Should().NotHaveValue();

            show1Season2Episodes[1].Number.Should().Be(5);
            show1Season2Episodes[1].Rating.Should().HaveValue();
            show1Season2Episodes[1].RatedAt.Should().NotHaveValue();

            show1Season2Episodes[2].Number.Should().Be(6);
            show1Season2Episodes[2].Rating.Should().NotHaveValue();
            show1Season2Episodes[2].RatedAt.Should().NotHaveValue();

            // ---------------------------------------------------------

            builder = TraktSyncRatingsPost.Builder();

            builder.AddShowWithRating(show2, rating, new PostRatingsSeasons {
                { 1, seasonRating, DateTime.Now, new PostRatingsEpisodes {  // season 1 - episode 1, 2, 3
                        { 1, episodeRating, DateTime.Now },
                        2,
                        { 3, episodeRating, DateTime.Now }
                    }
                },
                { 2, seasonRating, DateTime.Now, new PostRatingsEpisodes {  // season 2 - episode 4, 5, 6
                        4,
                        { 5, episodeRating, DateTime.Now },
                        6
                    }
                }
            });

            ratingsPost = builder.Build();

            ratingsPost.Should().NotBeNull();
            ratingsPost.Episodes.Should().BeNull();
            ratingsPost.Shows.Should().NotBeNull().And.HaveCount(1);
            ratingsPost.Movies.Should().BeNull();

            shows = ratingsPost.Shows.ToArray();

            shows[0].Should().NotBeNull();
            shows[0].Title.Should().Be("show2");
            shows[0].Year.Should().Be(2016);
            shows[0].Ids.Should().NotBeNull();
            shows[0].Ids.Trakt.Should().Be(3U);
            shows[0].Ids.Slug.Should().Be("show2");
            shows[0].Ids.Imdb.Should().Be("imdb2");
            shows[0].Ids.Tmdb.Should().Be(12345U);
            shows[0].Ids.Tvdb.Should().Be(123456U);
            shows[0].Ids.TvRage.Should().Be(1234567U);
            shows[0].Rating.Should().HaveValue();
            shows[0].RatedAt.Should().NotHaveValue();
            shows[0].Seasons.Should().NotBeNull().And.HaveCount(2);

            show1Seasons = shows[0].Seasons.ToArray();

            show1Seasons[0].Number.Should().Be(1);
            show1Seasons[0].Episodes.Should().NotBeNull().And.HaveCount(3);
            show1Seasons[0].Rating.Should().HaveValue();
            show1Seasons[0].RatedAt.Should().HaveValue();

            show1Seasons[1].Number.Should().Be(2);
            show1Seasons[1].Episodes.Should().NotBeNull().And.HaveCount(3);
            show1Seasons[1].Rating.Should().HaveValue();
            show1Seasons[1].RatedAt.Should().HaveValue();

            show1Season1Episodes = show1Seasons[0].Episodes.ToArray();

            show1Season1Episodes[0].Number.Should().Be(1);
            show1Season1Episodes[0].Rating.Should().HaveValue();
            show1Season1Episodes[0].RatedAt.Should().HaveValue();

            show1Season1Episodes[1].Number.Should().Be(2);
            show1Season1Episodes[1].Rating.Should().NotHaveValue();
            show1Season1Episodes[1].RatedAt.Should().NotHaveValue();

            show1Season1Episodes[2].Number.Should().Be(3);
            show1Season1Episodes[2].Rating.Should().HaveValue();
            show1Season1Episodes[2].RatedAt.Should().HaveValue();

            show1Season2Episodes = show1Seasons[1].Episodes.ToArray();

            show1Season2Episodes[0].Number.Should().Be(4);
            show1Season2Episodes[0].Rating.Should().NotHaveValue();
            show1Season2Episodes[0].RatedAt.Should().NotHaveValue();

            show1Season2Episodes[1].Number.Should().Be(5);
            show1Season2Episodes[1].Rating.Should().HaveValue();
            show1Season2Episodes[1].RatedAt.Should().HaveValue();

            show1Season2Episodes[2].Number.Should().Be(6);
            show1Season2Episodes[2].Rating.Should().NotHaveValue();
            show1Season2Episodes[2].RatedAt.Should().NotHaveValue();

            // ---------------------------------------------------------

            builder = TraktSyncRatingsPost.Builder();

            builder.AddShowWithRating(show2, rating, new PostRatingsSeasons {
                { 1, seasonRating, new PostRatingsEpisodes {  // season 1 - episode 1, 2, 3
                        { 1, episodeRating, DateTime.Now },
                        2,
                        { 3, episodeRating, DateTime.Now }
                    }
                },
                { 2, seasonRating, DateTime.Now, new PostRatingsEpisodes {  // season 2 - episode 4, 5, 6
                        4,
                        { 5, episodeRating, DateTime.Now },
                        6
                    }
                }
            });

            ratingsPost = builder.Build();

            ratingsPost.Should().NotBeNull();
            ratingsPost.Episodes.Should().BeNull();
            ratingsPost.Shows.Should().NotBeNull().And.HaveCount(1);
            ratingsPost.Movies.Should().BeNull();

            shows = ratingsPost.Shows.ToArray();

            shows[0].Should().NotBeNull();
            shows[0].Title.Should().Be("show2");
            shows[0].Year.Should().Be(2016);
            shows[0].Ids.Should().NotBeNull();
            shows[0].Ids.Trakt.Should().Be(3U);
            shows[0].Ids.Slug.Should().Be("show2");
            shows[0].Ids.Imdb.Should().Be("imdb2");
            shows[0].Ids.Tmdb.Should().Be(12345U);
            shows[0].Ids.Tvdb.Should().Be(123456U);
            shows[0].Ids.TvRage.Should().Be(1234567U);
            shows[0].Rating.Should().HaveValue();
            shows[0].RatedAt.Should().NotHaveValue();
            shows[0].Seasons.Should().NotBeNull().And.HaveCount(2);

            show1Seasons = shows[0].Seasons.ToArray();

            show1Seasons[0].Number.Should().Be(1);
            show1Seasons[0].Episodes.Should().NotBeNull().And.HaveCount(3);
            show1Seasons[0].Rating.Should().HaveValue();
            show1Seasons[0].RatedAt.Should().NotHaveValue();

            show1Seasons[1].Number.Should().Be(2);
            show1Seasons[1].Episodes.Should().NotBeNull().And.HaveCount(3);
            show1Seasons[1].Rating.Should().HaveValue();
            show1Seasons[1].RatedAt.Should().HaveValue();

            show1Season1Episodes = show1Seasons[0].Episodes.ToArray();

            show1Season1Episodes[0].Number.Should().Be(1);
            show1Season1Episodes[0].Rating.Should().HaveValue();
            show1Season1Episodes[0].RatedAt.Should().HaveValue();

            show1Season1Episodes[1].Number.Should().Be(2);
            show1Season1Episodes[1].Rating.Should().NotHaveValue();
            show1Season1Episodes[1].RatedAt.Should().NotHaveValue();

            show1Season1Episodes[2].Number.Should().Be(3);
            show1Season1Episodes[2].Rating.Should().HaveValue();
            show1Season1Episodes[2].RatedAt.Should().HaveValue();

            show1Season2Episodes = show1Seasons[1].Episodes.ToArray();

            show1Season2Episodes[0].Number.Should().Be(4);
            show1Season2Episodes[0].Rating.Should().NotHaveValue();
            show1Season2Episodes[0].RatedAt.Should().NotHaveValue();

            show1Season2Episodes[1].Number.Should().Be(5);
            show1Season2Episodes[1].Rating.Should().HaveValue();
            show1Season2Episodes[1].RatedAt.Should().HaveValue();

            show1Season2Episodes[2].Number.Should().Be(6);
            show1Season2Episodes[2].Rating.Should().NotHaveValue();
            show1Season2Episodes[2].RatedAt.Should().NotHaveValue();
        }

        [TestMethod]
        public void TestTraktSyncRatingsPostBuilderAddShowWithSeasonsAndEpisodesAndRatingAndRatedAt()
        {
            var show1 = new TraktShow
            {
                Title = "show1",
                Year = 2016,
                Ids = new TraktShowIds
                {
                    Trakt = 1,
                    Slug = "show1",
                    Imdb = "imdb1",
                    Tmdb = 1234,
                    Tvdb = 12345,
                    TvRage = 123456
                }
            };

            var rating = 5;
            var ratedAt = DateTime.Now;

            var builder = TraktSyncRatingsPost.Builder();

            builder.AddShowWithRating(show1, rating, ratedAt, new PostRatingsSeasons { { 1, new PostRatingsEpisodes { 1 } } }); // season 1 - episode 1

            var ratingsPost = builder.Build();

            ratingsPost.Should().NotBeNull();
            ratingsPost.Episodes.Should().BeNull();
            ratingsPost.Shows.Should().NotBeNull().And.HaveCount(1);
            ratingsPost.Movies.Should().BeNull();

            var shows = ratingsPost.Shows.ToArray();

            shows[0].Should().NotBeNull();
            shows[0].Title.Should().Be("show1");
            shows[0].Year.Should().Be(2016);
            shows[0].Ids.Should().NotBeNull();
            shows[0].Ids.Trakt.Should().Be(1U);
            shows[0].Ids.Slug.Should().Be("show1");
            shows[0].Ids.Imdb.Should().Be("imdb1");
            shows[0].Ids.Tmdb.Should().Be(1234U);
            shows[0].Ids.Tvdb.Should().Be(12345U);
            shows[0].Ids.TvRage.Should().Be(123456U);
            shows[0].Rating.Should().HaveValue();
            shows[0].RatedAt.Should().HaveValue();
            shows[0].Seasons.Should().NotBeNull().And.HaveCount(1);

            var show1Seasons = shows[0].Seasons.ToArray();

            show1Seasons[0].Number.Should().Be(1);
            show1Seasons[0].Episodes.Should().NotBeNull().And.HaveCount(1);
            show1Seasons[0].Rating.Should().NotHaveValue();
            show1Seasons[0].RatedAt.Should().NotHaveValue();

            var show1Season1Episodes = show1Seasons[0].Episodes.ToArray();

            show1Season1Episodes[0].Number.Should().Be(1);
            show1Season1Episodes[0].Rating.Should().NotHaveValue();
            show1Season1Episodes[0].RatedAt.Should().NotHaveValue();

            // ---------------------------------------------------------

            builder.AddShowWithRating(show1, rating, ratedAt, new PostRatingsSeasons { { 1, new PostRatingsEpisodes { 1, 2 } } }); // season 1 - episode 1, 2

            ratingsPost = builder.Build();

            ratingsPost.Should().NotBeNull();
            ratingsPost.Episodes.Should().BeNull();
            ratingsPost.Shows.Should().NotBeNull().And.HaveCount(1);
            ratingsPost.Movies.Should().BeNull();

            shows = ratingsPost.Shows.ToArray();

            shows[0].Should().NotBeNull();
            shows[0].Title.Should().Be("show1");
            shows[0].Year.Should().Be(2016);
            shows[0].Ids.Should().NotBeNull();
            shows[0].Ids.Trakt.Should().Be(1U);
            shows[0].Ids.Slug.Should().Be("show1");
            shows[0].Ids.Imdb.Should().Be("imdb1");
            shows[0].Ids.Tmdb.Should().Be(1234U);
            shows[0].Ids.Tvdb.Should().Be(12345U);
            shows[0].Ids.TvRage.Should().Be(123456U);
            shows[0].Rating.Should().HaveValue();
            shows[0].RatedAt.Should().HaveValue();
            shows[0].Seasons.Should().NotBeNull().And.HaveCount(1);

            show1Seasons = shows[0].Seasons.ToArray();

            show1Seasons[0].Number.Should().Be(1);
            show1Seasons[0].Episodes.Should().NotBeNull().And.HaveCount(2);
            show1Seasons[0].Rating.Should().NotHaveValue();
            show1Seasons[0].RatedAt.Should().NotHaveValue();

            show1Season1Episodes = show1Seasons[0].Episodes.ToArray();

            show1Season1Episodes[0].Number.Should().Be(1);
            show1Season1Episodes[0].Rating.Should().NotHaveValue();
            show1Season1Episodes[0].RatedAt.Should().NotHaveValue();

            show1Season1Episodes[1].Number.Should().Be(2);
            show1Season1Episodes[1].Rating.Should().NotHaveValue();
            show1Season1Episodes[1].RatedAt.Should().NotHaveValue();

            // ---------------------------------------------------------

            builder.AddShowWithRating(show1, rating, ratedAt, new PostRatingsSeasons { { 1, new PostRatingsEpisodes { 1, 2, 3 } } }); // season 1 - episode 1, 2, 3

            ratingsPost = builder.Build();

            ratingsPost.Should().NotBeNull();
            ratingsPost.Episodes.Should().BeNull();
            ratingsPost.Shows.Should().NotBeNull().And.HaveCount(1);
            ratingsPost.Movies.Should().BeNull();

            shows = ratingsPost.Shows.ToArray();

            shows[0].Should().NotBeNull();
            shows[0].Title.Should().Be("show1");
            shows[0].Year.Should().Be(2016);
            shows[0].Ids.Should().NotBeNull();
            shows[0].Ids.Trakt.Should().Be(1U);
            shows[0].Ids.Slug.Should().Be("show1");
            shows[0].Ids.Imdb.Should().Be("imdb1");
            shows[0].Ids.Tmdb.Should().Be(1234U);
            shows[0].Ids.Tvdb.Should().Be(12345U);
            shows[0].Ids.TvRage.Should().Be(123456U);
            shows[0].Rating.Should().HaveValue();
            shows[0].RatedAt.Should().HaveValue();
            shows[0].Seasons.Should().NotBeNull().And.HaveCount(1);

            show1Seasons = shows[0].Seasons.ToArray();

            show1Seasons[0].Number.Should().Be(1);
            show1Seasons[0].Episodes.Should().NotBeNull().And.HaveCount(3);
            show1Seasons[0].Rating.Should().NotHaveValue();
            show1Seasons[0].RatedAt.Should().NotHaveValue();

            show1Season1Episodes = show1Seasons[0].Episodes.ToArray();

            show1Season1Episodes[0].Number.Should().Be(1);
            show1Season1Episodes[0].Rating.Should().NotHaveValue();
            show1Season1Episodes[0].RatedAt.Should().NotHaveValue();

            show1Season1Episodes[1].Number.Should().Be(2);
            show1Season1Episodes[1].Rating.Should().NotHaveValue();
            show1Season1Episodes[1].RatedAt.Should().NotHaveValue();

            show1Season1Episodes[2].Number.Should().Be(3);
            show1Season1Episodes[2].Rating.Should().NotHaveValue();
            show1Season1Episodes[2].RatedAt.Should().NotHaveValue();

            // ---------------------------------------------------------

            builder.AddShowWithRating(show1, rating, ratedAt, new PostRatingsSeasons {
                { 1, new PostRatingsEpisodes { 1, 2, 3 } }, // season 1 - episode 1, 2, 3
                { 2, new PostRatingsEpisodes { 4 } }        // season 2 - episode 4
            });

            ratingsPost = builder.Build();

            ratingsPost.Should().NotBeNull();
            ratingsPost.Episodes.Should().BeNull();
            ratingsPost.Shows.Should().NotBeNull().And.HaveCount(1);
            ratingsPost.Movies.Should().BeNull();

            shows = ratingsPost.Shows.ToArray();

            shows[0].Should().NotBeNull();
            shows[0].Title.Should().Be("show1");
            shows[0].Year.Should().Be(2016);
            shows[0].Ids.Should().NotBeNull();
            shows[0].Ids.Trakt.Should().Be(1U);
            shows[0].Ids.Slug.Should().Be("show1");
            shows[0].Ids.Imdb.Should().Be("imdb1");
            shows[0].Ids.Tmdb.Should().Be(1234U);
            shows[0].Ids.Tvdb.Should().Be(12345U);
            shows[0].Ids.TvRage.Should().Be(123456U);
            shows[0].Rating.Should().HaveValue();
            shows[0].RatedAt.Should().HaveValue();
            shows[0].Seasons.Should().NotBeNull().And.HaveCount(2);

            show1Seasons = shows[0].Seasons.ToArray();

            show1Seasons[0].Number.Should().Be(1);
            show1Seasons[0].Episodes.Should().NotBeNull().And.HaveCount(3);
            show1Seasons[0].Rating.Should().NotHaveValue();
            show1Seasons[0].RatedAt.Should().NotHaveValue();

            show1Seasons[1].Number.Should().Be(2);
            show1Seasons[1].Episodes.Should().NotBeNull().And.HaveCount(1);
            show1Seasons[1].Rating.Should().NotHaveValue();
            show1Seasons[1].RatedAt.Should().NotHaveValue();

            show1Season1Episodes = show1Seasons[0].Episodes.ToArray();

            show1Season1Episodes[0].Number.Should().Be(1);
            show1Season1Episodes[0].Rating.Should().NotHaveValue();
            show1Season1Episodes[0].RatedAt.Should().NotHaveValue();

            show1Season1Episodes[1].Number.Should().Be(2);
            show1Season1Episodes[1].Rating.Should().NotHaveValue();
            show1Season1Episodes[1].RatedAt.Should().NotHaveValue();

            show1Season1Episodes[2].Number.Should().Be(3);
            show1Season1Episodes[2].Rating.Should().NotHaveValue();
            show1Season1Episodes[2].RatedAt.Should().NotHaveValue();

            var show1Season2Episodes = show1Seasons[1].Episodes.ToArray();

            show1Season2Episodes[0].Number.Should().Be(4);
            show1Season2Episodes[0].Rating.Should().NotHaveValue();
            show1Season2Episodes[0].RatedAt.Should().NotHaveValue();

            // ---------------------------------------------------------

            builder.AddShowWithRating(show1, rating, ratedAt, new PostRatingsSeasons {
                { 1, new PostRatingsEpisodes { 1, 2, 3 } }, // season 1 - episode 1, 2, 3
                { 2, new PostRatingsEpisodes { 4, 5 } }     // season 2 - episode 4, 5
            });

            ratingsPost = builder.Build();

            ratingsPost.Should().NotBeNull();
            ratingsPost.Episodes.Should().BeNull();
            ratingsPost.Shows.Should().NotBeNull().And.HaveCount(1);
            ratingsPost.Movies.Should().BeNull();

            shows = ratingsPost.Shows.ToArray();

            shows[0].Should().NotBeNull();
            shows[0].Title.Should().Be("show1");
            shows[0].Year.Should().Be(2016);
            shows[0].Ids.Should().NotBeNull();
            shows[0].Ids.Trakt.Should().Be(1U);
            shows[0].Ids.Slug.Should().Be("show1");
            shows[0].Ids.Imdb.Should().Be("imdb1");
            shows[0].Ids.Tmdb.Should().Be(1234U);
            shows[0].Ids.Tvdb.Should().Be(12345U);
            shows[0].Ids.TvRage.Should().Be(123456U);
            shows[0].Rating.Should().HaveValue();
            shows[0].RatedAt.Should().HaveValue();
            shows[0].Seasons.Should().NotBeNull().And.HaveCount(2);

            show1Seasons = shows[0].Seasons.ToArray();

            show1Seasons[0].Number.Should().Be(1);
            show1Seasons[0].Episodes.Should().NotBeNull().And.HaveCount(3);
            show1Seasons[0].Rating.Should().NotHaveValue();
            show1Seasons[0].RatedAt.Should().NotHaveValue();

            show1Seasons[1].Number.Should().Be(2);
            show1Seasons[1].Episodes.Should().NotBeNull().And.HaveCount(2);
            show1Seasons[1].Rating.Should().NotHaveValue();
            show1Seasons[1].RatedAt.Should().NotHaveValue();

            show1Season1Episodes = show1Seasons[0].Episodes.ToArray();

            show1Season1Episodes[0].Number.Should().Be(1);
            show1Season1Episodes[0].Rating.Should().NotHaveValue();
            show1Season1Episodes[0].RatedAt.Should().NotHaveValue();

            show1Season1Episodes[1].Number.Should().Be(2);
            show1Season1Episodes[1].Rating.Should().NotHaveValue();
            show1Season1Episodes[1].RatedAt.Should().NotHaveValue();

            show1Season1Episodes[2].Number.Should().Be(3);
            show1Season1Episodes[2].Rating.Should().NotHaveValue();
            show1Season1Episodes[2].RatedAt.Should().NotHaveValue();

            show1Season2Episodes = show1Seasons[1].Episodes.ToArray();

            show1Season2Episodes[0].Number.Should().Be(4);
            show1Season2Episodes[0].Rating.Should().NotHaveValue();
            show1Season2Episodes[0].RatedAt.Should().NotHaveValue();

            show1Season2Episodes[1].Number.Should().Be(5);
            show1Season2Episodes[1].Rating.Should().NotHaveValue();
            show1Season2Episodes[1].RatedAt.Should().NotHaveValue();

            // ---------------------------------------------------------

            builder.AddShowWithRating(show1, rating, ratedAt, new PostRatingsSeasons {
                { 1, new PostRatingsEpisodes { 1, 2, 3 } }, // season 1 - episode 1, 2, 3
                { 2, new PostRatingsEpisodes { 4, 5, 6 } }  // season 2 - episode 4, 5, 6
            });

            ratingsPost = builder.Build();

            ratingsPost.Should().NotBeNull();
            ratingsPost.Episodes.Should().BeNull();
            ratingsPost.Shows.Should().NotBeNull().And.HaveCount(1);
            ratingsPost.Movies.Should().BeNull();

            shows = ratingsPost.Shows.ToArray();

            shows[0].Should().NotBeNull();
            shows[0].Title.Should().Be("show1");
            shows[0].Year.Should().Be(2016);
            shows[0].Ids.Should().NotBeNull();
            shows[0].Ids.Trakt.Should().Be(1U);
            shows[0].Ids.Slug.Should().Be("show1");
            shows[0].Ids.Imdb.Should().Be("imdb1");
            shows[0].Ids.Tmdb.Should().Be(1234U);
            shows[0].Ids.Tvdb.Should().Be(12345U);
            shows[0].Ids.TvRage.Should().Be(123456U);
            shows[0].Rating.Should().HaveValue();
            shows[0].RatedAt.Should().HaveValue();
            shows[0].Seasons.Should().NotBeNull().And.HaveCount(2);

            show1Seasons = shows[0].Seasons.ToArray();

            show1Seasons[0].Number.Should().Be(1);
            show1Seasons[0].Episodes.Should().NotBeNull().And.HaveCount(3);
            show1Seasons[0].Rating.Should().NotHaveValue();
            show1Seasons[0].RatedAt.Should().NotHaveValue();

            show1Seasons[1].Number.Should().Be(2);
            show1Seasons[1].Episodes.Should().NotBeNull().And.HaveCount(3);
            show1Seasons[1].Rating.Should().NotHaveValue();
            show1Seasons[1].RatedAt.Should().NotHaveValue();

            show1Season1Episodes = show1Seasons[0].Episodes.ToArray();

            show1Season1Episodes[0].Number.Should().Be(1);
            show1Season1Episodes[0].Rating.Should().NotHaveValue();
            show1Season1Episodes[0].RatedAt.Should().NotHaveValue();

            show1Season1Episodes[1].Number.Should().Be(2);
            show1Season1Episodes[1].Rating.Should().NotHaveValue();
            show1Season1Episodes[1].RatedAt.Should().NotHaveValue();

            show1Season1Episodes[2].Number.Should().Be(3);
            show1Season1Episodes[2].Rating.Should().NotHaveValue();
            show1Season1Episodes[2].RatedAt.Should().NotHaveValue();

            show1Season2Episodes = show1Seasons[1].Episodes.ToArray();

            show1Season2Episodes[0].Number.Should().Be(4);
            show1Season2Episodes[0].Rating.Should().NotHaveValue();
            show1Season2Episodes[0].RatedAt.Should().NotHaveValue();

            show1Season2Episodes[1].Number.Should().Be(5);
            show1Season2Episodes[1].Rating.Should().NotHaveValue();
            show1Season2Episodes[1].RatedAt.Should().NotHaveValue();

            show1Season2Episodes[2].Number.Should().Be(6);
            show1Season2Episodes[2].Rating.Should().NotHaveValue();
            show1Season2Episodes[2].RatedAt.Should().NotHaveValue();

            // ---------------------------------------------------------

            show1.Ids.Trakt = 2;

            builder.AddShowWithRating(show1, rating, ratedAt, new PostRatingsSeasons {
                { 1, new PostRatingsEpisodes { 1, 2, 3 } }, // season 1 - episode 1, 2, 3
                { 2, new PostRatingsEpisodes { 4, 5, 6 } }  // season 2 - episode 4, 5, 6
            });

            ratingsPost = builder.Build();

            ratingsPost.Should().NotBeNull();
            ratingsPost.Episodes.Should().BeNull();
            ratingsPost.Shows.Should().NotBeNull().And.HaveCount(1);
            ratingsPost.Movies.Should().BeNull();

            shows = ratingsPost.Shows.ToArray();

            shows[0].Should().NotBeNull();
            shows[0].Title.Should().Be("show1");
            shows[0].Year.Should().Be(2016);
            shows[0].Ids.Should().NotBeNull();
            shows[0].Ids.Trakt.Should().Be(2U);
            shows[0].Ids.Slug.Should().Be("show1");
            shows[0].Ids.Imdb.Should().Be("imdb1");
            shows[0].Ids.Tmdb.Should().Be(1234U);
            shows[0].Ids.Tvdb.Should().Be(12345U);
            shows[0].Ids.TvRage.Should().Be(123456U);
            shows[0].Rating.Should().HaveValue();
            shows[0].RatedAt.Should().HaveValue();
            shows[0].Seasons.Should().NotBeNull().And.HaveCount(2);

            show1Seasons = shows[0].Seasons.ToArray();

            show1Seasons[0].Number.Should().Be(1);
            show1Seasons[0].Episodes.Should().NotBeNull().And.HaveCount(3);
            show1Seasons[0].Rating.Should().NotHaveValue();
            show1Seasons[0].RatedAt.Should().NotHaveValue();

            show1Seasons[1].Number.Should().Be(2);
            show1Seasons[1].Episodes.Should().NotBeNull().And.HaveCount(3);
            show1Seasons[1].Rating.Should().NotHaveValue();
            show1Seasons[1].RatedAt.Should().NotHaveValue();

            show1Season1Episodes = show1Seasons[0].Episodes.ToArray();

            show1Season1Episodes[0].Number.Should().Be(1);
            show1Season1Episodes[0].Rating.Should().NotHaveValue();
            show1Season1Episodes[0].RatedAt.Should().NotHaveValue();

            show1Season1Episodes[1].Number.Should().Be(2);
            show1Season1Episodes[1].Rating.Should().NotHaveValue();
            show1Season1Episodes[1].RatedAt.Should().NotHaveValue();

            show1Season1Episodes[2].Number.Should().Be(3);
            show1Season1Episodes[2].Rating.Should().NotHaveValue();
            show1Season1Episodes[2].RatedAt.Should().NotHaveValue();

            show1Season2Episodes = show1Seasons[1].Episodes.ToArray();

            show1Season2Episodes[0].Number.Should().Be(4);
            show1Season2Episodes[0].Rating.Should().NotHaveValue();
            show1Season2Episodes[0].RatedAt.Should().NotHaveValue();

            show1Season2Episodes[1].Number.Should().Be(5);
            show1Season2Episodes[1].Rating.Should().NotHaveValue();
            show1Season2Episodes[1].RatedAt.Should().NotHaveValue();

            show1Season2Episodes[2].Number.Should().Be(6);
            show1Season2Episodes[2].Rating.Should().NotHaveValue();
            show1Season2Episodes[2].RatedAt.Should().NotHaveValue();

            // ---------------------------------------------------------

            var show2 = new TraktShow
            {
                Title = "show2",
                Year = 2016,
                Ids = new TraktShowIds
                {
                    Trakt = 3,
                    Slug = "show2",
                    Imdb = "imdb2",
                    Tmdb = 12345,
                    Tvdb = 123456,
                    TvRage = 1234567
                }
            };

            builder.AddShowWithRating(show2, rating, ratedAt, new PostRatingsSeasons {
                { 1, new PostRatingsEpisodes { 1, 2, 3 } }, // season 1 - episode 1, 2, 3
                { 2, new PostRatingsEpisodes { 4, 5, 6 } }  // season 2 - episode 4, 5, 6
            });

            ratingsPost = builder.Build();

            ratingsPost.Should().NotBeNull();
            ratingsPost.Episodes.Should().BeNull();
            ratingsPost.Shows.Should().NotBeNull().And.HaveCount(2);
            ratingsPost.Movies.Should().BeNull();

            shows = ratingsPost.Shows.ToArray();

            shows[0].Should().NotBeNull();
            shows[0].Title.Should().Be("show1");
            shows[0].Year.Should().Be(2016);
            shows[0].Ids.Should().NotBeNull();
            shows[0].Ids.Trakt.Should().Be(2U);
            shows[0].Ids.Slug.Should().Be("show1");
            shows[0].Ids.Imdb.Should().Be("imdb1");
            shows[0].Ids.Tmdb.Should().Be(1234U);
            shows[0].Ids.Tvdb.Should().Be(12345U);
            shows[0].Ids.TvRage.Should().Be(123456U);
            shows[0].Rating.Should().HaveValue();
            shows[0].RatedAt.Should().HaveValue();
            shows[0].Seasons.Should().NotBeNull().And.HaveCount(2);

            shows[1].Should().NotBeNull();
            shows[1].Title.Should().Be("show2");
            shows[1].Year.Should().Be(2016);
            shows[1].Ids.Should().NotBeNull();
            shows[1].Ids.Trakt.Should().Be(3U);
            shows[1].Ids.Slug.Should().Be("show2");
            shows[1].Ids.Imdb.Should().Be("imdb2");
            shows[1].Ids.Tmdb.Should().Be(12345U);
            shows[1].Ids.Tvdb.Should().Be(123456U);
            shows[1].Ids.TvRage.Should().Be(1234567U);
            shows[1].Rating.Should().HaveValue();
            shows[1].RatedAt.Should().HaveValue();
            shows[1].Seasons.Should().NotBeNull().And.HaveCount(2);

            show1Seasons = shows[0].Seasons.ToArray();

            show1Seasons[0].Number.Should().Be(1);
            show1Seasons[0].Episodes.Should().NotBeNull().And.HaveCount(3);
            show1Seasons[0].Rating.Should().NotHaveValue();
            show1Seasons[0].RatedAt.Should().NotHaveValue();

            show1Seasons[1].Number.Should().Be(2);
            show1Seasons[1].Episodes.Should().NotBeNull().And.HaveCount(3);
            show1Seasons[1].Rating.Should().NotHaveValue();
            show1Seasons[1].RatedAt.Should().NotHaveValue();

            show1Season1Episodes = show1Seasons[0].Episodes.ToArray();

            show1Season1Episodes[0].Number.Should().Be(1);
            show1Season1Episodes[0].Rating.Should().NotHaveValue();
            show1Season1Episodes[0].RatedAt.Should().NotHaveValue();

            show1Season1Episodes[1].Number.Should().Be(2);
            show1Season1Episodes[1].Rating.Should().NotHaveValue();
            show1Season1Episodes[1].RatedAt.Should().NotHaveValue();

            show1Season1Episodes[2].Number.Should().Be(3);
            show1Season1Episodes[2].Rating.Should().NotHaveValue();
            show1Season1Episodes[2].RatedAt.Should().NotHaveValue();

            show1Season2Episodes = show1Seasons[1].Episodes.ToArray();

            show1Season2Episodes[0].Number.Should().Be(4);
            show1Season2Episodes[0].Rating.Should().NotHaveValue();
            show1Season2Episodes[0].RatedAt.Should().NotHaveValue();

            show1Season2Episodes[1].Number.Should().Be(5);
            show1Season2Episodes[1].Rating.Should().NotHaveValue();
            show1Season2Episodes[1].RatedAt.Should().NotHaveValue();

            show1Season2Episodes[2].Number.Should().Be(6);
            show1Season2Episodes[2].Rating.Should().NotHaveValue();
            show1Season2Episodes[2].RatedAt.Should().NotHaveValue();

            var show2Seasons = shows[1].Seasons.ToArray();

            show2Seasons[0].Number.Should().Be(1);
            show2Seasons[0].Episodes.Should().NotBeNull().And.HaveCount(3);
            show2Seasons[0].Rating.Should().NotHaveValue();
            show2Seasons[0].RatedAt.Should().NotHaveValue();

            show2Seasons[1].Number.Should().Be(2);
            show2Seasons[1].Episodes.Should().NotBeNull().And.HaveCount(3);
            show2Seasons[1].Rating.Should().NotHaveValue();
            show2Seasons[1].RatedAt.Should().NotHaveValue();

            var show2Season1Episodes = show2Seasons[0].Episodes.ToArray();

            show2Season1Episodes[0].Number.Should().Be(1);
            show2Season1Episodes[0].Rating.Should().NotHaveValue();
            show2Season1Episodes[0].RatedAt.Should().NotHaveValue();

            show2Season1Episodes[1].Number.Should().Be(2);
            show2Season1Episodes[1].Rating.Should().NotHaveValue();
            show2Season1Episodes[1].RatedAt.Should().NotHaveValue();

            show2Season1Episodes[2].Number.Should().Be(3);
            show2Season1Episodes[2].Rating.Should().NotHaveValue();
            show2Season1Episodes[2].RatedAt.Should().NotHaveValue();

            var show2Season2Episodes = show2Seasons[1].Episodes.ToArray();

            show2Season2Episodes[0].Number.Should().Be(4);
            show2Season2Episodes[0].Rating.Should().NotHaveValue();
            show2Season2Episodes[0].RatedAt.Should().NotHaveValue();

            show2Season2Episodes[1].Number.Should().Be(5);
            show2Season2Episodes[1].Rating.Should().NotHaveValue();
            show2Season2Episodes[1].RatedAt.Should().NotHaveValue();

            show2Season2Episodes[2].Number.Should().Be(6);
            show2Season2Episodes[2].Rating.Should().NotHaveValue();
            show2Season2Episodes[2].RatedAt.Should().NotHaveValue();

            // ---------------------------------------------------------

            builder = TraktSyncRatingsPost.Builder();

            builder.AddShowWithRating(show2, rating, ratedAt, new PostRatingsSeasons { 1 });  // season 1

            ratingsPost = builder.Build();

            ratingsPost.Should().NotBeNull();
            ratingsPost.Episodes.Should().BeNull();
            ratingsPost.Shows.Should().NotBeNull().And.HaveCount(1);
            ratingsPost.Movies.Should().BeNull();

            shows = ratingsPost.Shows.ToArray();

            shows[0].Should().NotBeNull();
            shows[0].Title.Should().Be("show2");
            shows[0].Year.Should().Be(2016);
            shows[0].Ids.Should().NotBeNull();
            shows[0].Ids.Trakt.Should().Be(3U);
            shows[0].Ids.Slug.Should().Be("show2");
            shows[0].Ids.Imdb.Should().Be("imdb2");
            shows[0].Ids.Tmdb.Should().Be(12345U);
            shows[0].Ids.Tvdb.Should().Be(123456U);
            shows[0].Ids.TvRage.Should().Be(1234567U);
            shows[0].Rating.Should().HaveValue();
            shows[0].RatedAt.Should().HaveValue();
            shows[0].Seasons.Should().NotBeNull().And.HaveCount(1);

            show1Seasons = shows[0].Seasons.ToArray();

            show1Seasons[0].Number.Should().Be(1);
            show1Seasons[0].Episodes.Should().BeNull();
            show1Seasons[0].Rating.Should().NotHaveValue();
            show1Seasons[0].RatedAt.Should().NotHaveValue();

            // ---------------------------------------------------------

            builder = TraktSyncRatingsPost.Builder();

            builder.AddShowWithRating(show2, rating, ratedAt, new PostRatingsSeasons {
                { 1, new PostRatingsEpisodes { 1, 2 } },    // season 1 - episode 1, 2
                2                                           // season 2
            });

            ratingsPost = builder.Build();

            ratingsPost.Should().NotBeNull();
            ratingsPost.Episodes.Should().BeNull();
            ratingsPost.Shows.Should().NotBeNull().And.HaveCount(1);
            ratingsPost.Movies.Should().BeNull();

            shows = ratingsPost.Shows.ToArray();

            shows[0].Should().NotBeNull();
            shows[0].Title.Should().Be("show2");
            shows[0].Year.Should().Be(2016);
            shows[0].Ids.Should().NotBeNull();
            shows[0].Ids.Trakt.Should().Be(3U);
            shows[0].Ids.Slug.Should().Be("show2");
            shows[0].Ids.Imdb.Should().Be("imdb2");
            shows[0].Ids.Tmdb.Should().Be(12345U);
            shows[0].Ids.Tvdb.Should().Be(123456U);
            shows[0].Ids.TvRage.Should().Be(1234567U);
            shows[0].Rating.Should().HaveValue();
            shows[0].RatedAt.Should().HaveValue();
            shows[0].Seasons.Should().NotBeNull().And.HaveCount(2);

            show1Seasons = shows[0].Seasons.ToArray();

            show1Seasons[0].Number.Should().Be(1);
            show1Seasons[0].Episodes.Should().NotBeNull().And.HaveCount(2);
            show1Seasons[0].Rating.Should().NotHaveValue();
            show1Seasons[0].RatedAt.Should().NotHaveValue();

            show1Seasons[1].Number.Should().Be(2);
            show1Seasons[1].Episodes.Should().BeNull();
            show1Seasons[1].Rating.Should().NotHaveValue();
            show1Seasons[1].RatedAt.Should().NotHaveValue();

            // ---------------------------------------------------------
            // ---------------------------------------------------------
            // ---------------------------------------------------------

            var seasonRating = 5;

            builder = TraktSyncRatingsPost.Builder();

            builder.AddShowWithRating(show2, rating, ratedAt, new PostRatingsSeasons {
                { 1, seasonRating },    // season 1
                { 2, seasonRating }     // season 2
            });

            ratingsPost = builder.Build();

            ratingsPost.Should().NotBeNull();
            ratingsPost.Episodes.Should().BeNull();
            ratingsPost.Shows.Should().NotBeNull().And.HaveCount(1);
            ratingsPost.Movies.Should().BeNull();

            shows = ratingsPost.Shows.ToArray();

            shows[0].Should().NotBeNull();
            shows[0].Title.Should().Be("show2");
            shows[0].Year.Should().Be(2016);
            shows[0].Ids.Should().NotBeNull();
            shows[0].Ids.Trakt.Should().Be(3U);
            shows[0].Ids.Slug.Should().Be("show2");
            shows[0].Ids.Imdb.Should().Be("imdb2");
            shows[0].Ids.Tmdb.Should().Be(12345U);
            shows[0].Ids.Tvdb.Should().Be(123456U);
            shows[0].Ids.TvRage.Should().Be(1234567U);
            shows[0].Rating.Should().HaveValue();
            shows[0].RatedAt.Should().HaveValue();
            shows[0].Seasons.Should().NotBeNull().And.HaveCount(2);

            show1Seasons = shows[0].Seasons.ToArray();

            show1Seasons[0].Number.Should().Be(1);
            show1Seasons[0].Episodes.Should().BeNull();
            show1Seasons[0].Rating.Should().HaveValue();
            show1Seasons[0].RatedAt.Should().NotHaveValue();

            show1Seasons[1].Number.Should().Be(2);
            show1Seasons[1].Episodes.Should().BeNull();
            show1Seasons[1].Rating.Should().HaveValue();
            show1Seasons[1].RatedAt.Should().NotHaveValue();

            // ---------------------------------------------------------

            builder = TraktSyncRatingsPost.Builder();

            builder.AddShowWithRating(show2, rating, ratedAt, new PostRatingsSeasons {
                { 1, seasonRating, DateTime.Now },    // season 1
                { 2, seasonRating, DateTime.Now }     // season 2
            });

            ratingsPost = builder.Build();

            ratingsPost.Should().NotBeNull();
            ratingsPost.Episodes.Should().BeNull();
            ratingsPost.Shows.Should().NotBeNull().And.HaveCount(1);
            ratingsPost.Movies.Should().BeNull();

            shows = ratingsPost.Shows.ToArray();

            shows[0].Should().NotBeNull();
            shows[0].Title.Should().Be("show2");
            shows[0].Year.Should().Be(2016);
            shows[0].Ids.Should().NotBeNull();
            shows[0].Ids.Trakt.Should().Be(3U);
            shows[0].Ids.Slug.Should().Be("show2");
            shows[0].Ids.Imdb.Should().Be("imdb2");
            shows[0].Ids.Tmdb.Should().Be(12345U);
            shows[0].Ids.Tvdb.Should().Be(123456U);
            shows[0].Ids.TvRage.Should().Be(1234567U);
            shows[0].Rating.Should().HaveValue();
            shows[0].RatedAt.Should().HaveValue();
            shows[0].Seasons.Should().NotBeNull().And.HaveCount(2);

            show1Seasons = shows[0].Seasons.ToArray();

            show1Seasons[0].Number.Should().Be(1);
            show1Seasons[0].Episodes.Should().BeNull();
            show1Seasons[0].Rating.Should().HaveValue();
            show1Seasons[0].RatedAt.Should().HaveValue();

            show1Seasons[1].Number.Should().Be(2);
            show1Seasons[1].Episodes.Should().BeNull();
            show1Seasons[1].Rating.Should().HaveValue();
            show1Seasons[1].RatedAt.Should().HaveValue();

            // ---------------------------------------------------------

            builder = TraktSyncRatingsPost.Builder();

            builder.AddShowWithRating(show2, rating, ratedAt, new PostRatingsSeasons {
                { 1, seasonRating },                  // season 1
                { 2, seasonRating, DateTime.Now }     // season 2
            });

            ratingsPost = builder.Build();

            ratingsPost.Should().NotBeNull();
            ratingsPost.Episodes.Should().BeNull();
            ratingsPost.Shows.Should().NotBeNull().And.HaveCount(1);
            ratingsPost.Movies.Should().BeNull();

            shows = ratingsPost.Shows.ToArray();

            shows[0].Should().NotBeNull();
            shows[0].Title.Should().Be("show2");
            shows[0].Year.Should().Be(2016);
            shows[0].Ids.Should().NotBeNull();
            shows[0].Ids.Trakt.Should().Be(3U);
            shows[0].Ids.Slug.Should().Be("show2");
            shows[0].Ids.Imdb.Should().Be("imdb2");
            shows[0].Ids.Tmdb.Should().Be(12345U);
            shows[0].Ids.Tvdb.Should().Be(123456U);
            shows[0].Ids.TvRage.Should().Be(1234567U);
            shows[0].Rating.Should().HaveValue();
            shows[0].RatedAt.Should().HaveValue();
            shows[0].Seasons.Should().NotBeNull().And.HaveCount(2);

            show1Seasons = shows[0].Seasons.ToArray();

            show1Seasons[0].Number.Should().Be(1);
            show1Seasons[0].Episodes.Should().BeNull();
            show1Seasons[0].Rating.Should().HaveValue();
            show1Seasons[0].RatedAt.Should().NotHaveValue();

            show1Seasons[1].Number.Should().Be(2);
            show1Seasons[1].Episodes.Should().BeNull();
            show1Seasons[1].Rating.Should().HaveValue();
            show1Seasons[1].RatedAt.Should().HaveValue();

            // ---------------------------------------------------------

            var episodeRating = 5;

            builder = TraktSyncRatingsPost.Builder();

            builder.AddShowWithRating(show2, rating, ratedAt, new PostRatingsSeasons {
                { 1, new PostRatingsEpisodes {  // season 1 - episode 1, 2, 3
                        { 1, episodeRating },
                        2,
                        { 3, episodeRating }
                    }
                },
                { 2, new PostRatingsEpisodes {  // season 2 - episode 4, 5, 6
                        4,
                        { 5, episodeRating },
                        6
                    }
                }
            });

            ratingsPost = builder.Build();

            ratingsPost.Should().NotBeNull();
            ratingsPost.Episodes.Should().BeNull();
            ratingsPost.Shows.Should().NotBeNull().And.HaveCount(1);
            ratingsPost.Movies.Should().BeNull();

            shows = ratingsPost.Shows.ToArray();

            shows[0].Should().NotBeNull();
            shows[0].Title.Should().Be("show2");
            shows[0].Year.Should().Be(2016);
            shows[0].Ids.Should().NotBeNull();
            shows[0].Ids.Trakt.Should().Be(3U);
            shows[0].Ids.Slug.Should().Be("show2");
            shows[0].Ids.Imdb.Should().Be("imdb2");
            shows[0].Ids.Tmdb.Should().Be(12345U);
            shows[0].Ids.Tvdb.Should().Be(123456U);
            shows[0].Ids.TvRage.Should().Be(1234567U);
            shows[0].Rating.Should().HaveValue();
            shows[0].RatedAt.Should().HaveValue();
            shows[0].Seasons.Should().NotBeNull().And.HaveCount(2);

            show1Seasons = shows[0].Seasons.ToArray();

            show1Seasons[0].Number.Should().Be(1);
            show1Seasons[0].Episodes.Should().NotBeNull().And.HaveCount(3);
            show1Seasons[0].Rating.Should().NotHaveValue();
            show1Seasons[0].RatedAt.Should().NotHaveValue();

            show1Seasons[1].Number.Should().Be(2);
            show1Seasons[1].Episodes.Should().NotBeNull().And.HaveCount(3);
            show1Seasons[1].Rating.Should().NotHaveValue();
            show1Seasons[1].RatedAt.Should().NotHaveValue();

            show1Season1Episodes = show1Seasons[0].Episodes.ToArray();

            show1Season1Episodes[0].Number.Should().Be(1);
            show1Season1Episodes[0].Rating.Should().HaveValue();
            show1Season1Episodes[0].RatedAt.Should().NotHaveValue();

            show1Season1Episodes[1].Number.Should().Be(2);
            show1Season1Episodes[1].Rating.Should().NotHaveValue();
            show1Season1Episodes[1].RatedAt.Should().NotHaveValue();

            show1Season1Episodes[2].Number.Should().Be(3);
            show1Season1Episodes[2].Rating.Should().HaveValue();
            show1Season1Episodes[2].RatedAt.Should().NotHaveValue();

            show1Season2Episodes = show1Seasons[1].Episodes.ToArray();

            show1Season2Episodes[0].Number.Should().Be(4);
            show1Season2Episodes[0].Rating.Should().NotHaveValue();
            show1Season2Episodes[0].RatedAt.Should().NotHaveValue();

            show1Season2Episodes[1].Number.Should().Be(5);
            show1Season2Episodes[1].Rating.Should().HaveValue();
            show1Season2Episodes[1].RatedAt.Should().NotHaveValue();

            show1Season2Episodes[2].Number.Should().Be(6);
            show1Season2Episodes[2].Rating.Should().NotHaveValue();
            show1Season2Episodes[2].RatedAt.Should().NotHaveValue();

            // ---------------------------------------------------------

            builder = TraktSyncRatingsPost.Builder();

            builder.AddShowWithRating(show2, rating, ratedAt, new PostRatingsSeasons {
                { 1, new PostRatingsEpisodes {  // season 1 - episode 1, 2, 3
                        { 1, episodeRating, DateTime.Now },
                        2,
                        { 3, episodeRating, DateTime.Now }
                    }
                },
                { 2, new PostRatingsEpisodes {  // season 2 - episode 4, 5, 6
                        4,
                        { 5, episodeRating, DateTime.Now },
                        6
                    }
                }
            });

            ratingsPost = builder.Build();

            ratingsPost.Should().NotBeNull();
            ratingsPost.Episodes.Should().BeNull();
            ratingsPost.Shows.Should().NotBeNull().And.HaveCount(1);
            ratingsPost.Movies.Should().BeNull();

            shows = ratingsPost.Shows.ToArray();

            shows[0].Should().NotBeNull();
            shows[0].Title.Should().Be("show2");
            shows[0].Year.Should().Be(2016);
            shows[0].Ids.Should().NotBeNull();
            shows[0].Ids.Trakt.Should().Be(3U);
            shows[0].Ids.Slug.Should().Be("show2");
            shows[0].Ids.Imdb.Should().Be("imdb2");
            shows[0].Ids.Tmdb.Should().Be(12345U);
            shows[0].Ids.Tvdb.Should().Be(123456U);
            shows[0].Ids.TvRage.Should().Be(1234567U);
            shows[0].Rating.Should().HaveValue();
            shows[0].RatedAt.Should().HaveValue();
            shows[0].Seasons.Should().NotBeNull().And.HaveCount(2);

            show1Seasons = shows[0].Seasons.ToArray();

            show1Seasons[0].Number.Should().Be(1);
            show1Seasons[0].Episodes.Should().NotBeNull().And.HaveCount(3);
            show1Seasons[0].Rating.Should().NotHaveValue();
            show1Seasons[0].RatedAt.Should().NotHaveValue();

            show1Seasons[1].Number.Should().Be(2);
            show1Seasons[1].Episodes.Should().NotBeNull().And.HaveCount(3);
            show1Seasons[1].Rating.Should().NotHaveValue();
            show1Seasons[1].RatedAt.Should().NotHaveValue();

            show1Season1Episodes = show1Seasons[0].Episodes.ToArray();

            show1Season1Episodes[0].Number.Should().Be(1);
            show1Season1Episodes[0].Rating.Should().HaveValue();
            show1Season1Episodes[0].RatedAt.Should().HaveValue();

            show1Season1Episodes[1].Number.Should().Be(2);
            show1Season1Episodes[1].Rating.Should().NotHaveValue();
            show1Season1Episodes[1].RatedAt.Should().NotHaveValue();

            show1Season1Episodes[2].Number.Should().Be(3);
            show1Season1Episodes[2].Rating.Should().HaveValue();
            show1Season1Episodes[2].RatedAt.Should().HaveValue();

            show1Season2Episodes = show1Seasons[1].Episodes.ToArray();

            show1Season2Episodes[0].Number.Should().Be(4);
            show1Season2Episodes[0].Rating.Should().NotHaveValue();
            show1Season2Episodes[0].RatedAt.Should().NotHaveValue();

            show1Season2Episodes[1].Number.Should().Be(5);
            show1Season2Episodes[1].Rating.Should().HaveValue();
            show1Season2Episodes[1].RatedAt.Should().HaveValue();

            show1Season2Episodes[2].Number.Should().Be(6);
            show1Season2Episodes[2].Rating.Should().NotHaveValue();
            show1Season2Episodes[2].RatedAt.Should().NotHaveValue();

            // ---------------------------------------------------------

            builder = TraktSyncRatingsPost.Builder();

            builder.AddShowWithRating(show2, rating, ratedAt, new PostRatingsSeasons {
                { 1, new PostRatingsEpisodes {  // season 1 - episode 1, 2, 3
                        { 1, episodeRating },
                        2,
                        { 3, episodeRating, DateTime.Now }
                    }
                },
                { 2, new PostRatingsEpisodes {  // season 2 - episode 4, 5, 6
                        4,
                        { 5, episodeRating },
                        6
                    }
                }
            });

            ratingsPost = builder.Build();

            ratingsPost.Should().NotBeNull();
            ratingsPost.Episodes.Should().BeNull();
            ratingsPost.Shows.Should().NotBeNull().And.HaveCount(1);
            ratingsPost.Movies.Should().BeNull();

            shows = ratingsPost.Shows.ToArray();

            shows[0].Should().NotBeNull();
            shows[0].Title.Should().Be("show2");
            shows[0].Year.Should().Be(2016);
            shows[0].Ids.Should().NotBeNull();
            shows[0].Ids.Trakt.Should().Be(3U);
            shows[0].Ids.Slug.Should().Be("show2");
            shows[0].Ids.Imdb.Should().Be("imdb2");
            shows[0].Ids.Tmdb.Should().Be(12345U);
            shows[0].Ids.Tvdb.Should().Be(123456U);
            shows[0].Ids.TvRage.Should().Be(1234567U);
            shows[0].Rating.Should().HaveValue();
            shows[0].RatedAt.Should().HaveValue();
            shows[0].Seasons.Should().NotBeNull().And.HaveCount(2);

            show1Seasons = shows[0].Seasons.ToArray();

            show1Seasons[0].Number.Should().Be(1);
            show1Seasons[0].Episodes.Should().NotBeNull().And.HaveCount(3);
            show1Seasons[0].Rating.Should().NotHaveValue();
            show1Seasons[0].RatedAt.Should().NotHaveValue();

            show1Seasons[1].Number.Should().Be(2);
            show1Seasons[1].Episodes.Should().NotBeNull().And.HaveCount(3);
            show1Seasons[1].Rating.Should().NotHaveValue();
            show1Seasons[1].RatedAt.Should().NotHaveValue();

            show1Season1Episodes = show1Seasons[0].Episodes.ToArray();

            show1Season1Episodes[0].Number.Should().Be(1);
            show1Season1Episodes[0].Rating.Should().HaveValue();
            show1Season1Episodes[0].RatedAt.Should().NotHaveValue();

            show1Season1Episodes[1].Number.Should().Be(2);
            show1Season1Episodes[1].Rating.Should().NotHaveValue();
            show1Season1Episodes[1].RatedAt.Should().NotHaveValue();

            show1Season1Episodes[2].Number.Should().Be(3);
            show1Season1Episodes[2].Rating.Should().HaveValue();
            show1Season1Episodes[2].RatedAt.Should().HaveValue();

            show1Season2Episodes = show1Seasons[1].Episodes.ToArray();

            show1Season2Episodes[0].Number.Should().Be(4);
            show1Season2Episodes[0].Rating.Should().NotHaveValue();
            show1Season2Episodes[0].RatedAt.Should().NotHaveValue();

            show1Season2Episodes[1].Number.Should().Be(5);
            show1Season2Episodes[1].Rating.Should().HaveValue();
            show1Season2Episodes[1].RatedAt.Should().NotHaveValue();

            show1Season2Episodes[2].Number.Should().Be(6);
            show1Season2Episodes[2].Rating.Should().NotHaveValue();
            show1Season2Episodes[2].RatedAt.Should().NotHaveValue();

            // ---------------------------------------------------------

            builder = TraktSyncRatingsPost.Builder();

            builder.AddShowWithRating(show2, rating, ratedAt, new PostRatingsSeasons {
                { 1, seasonRating, new PostRatingsEpisodes {  // season 1 - episode 1, 2, 3
                        { 1, episodeRating },
                        2,
                        { 3, episodeRating }
                    }
                },
                { 2, seasonRating, new PostRatingsEpisodes {  // season 2 - episode 4, 5, 6
                        4,
                        { 5, episodeRating },
                        6
                    }
                }
            });

            ratingsPost = builder.Build();

            ratingsPost.Should().NotBeNull();
            ratingsPost.Episodes.Should().BeNull();
            ratingsPost.Shows.Should().NotBeNull().And.HaveCount(1);
            ratingsPost.Movies.Should().BeNull();

            shows = ratingsPost.Shows.ToArray();

            shows[0].Should().NotBeNull();
            shows[0].Title.Should().Be("show2");
            shows[0].Year.Should().Be(2016);
            shows[0].Ids.Should().NotBeNull();
            shows[0].Ids.Trakt.Should().Be(3U);
            shows[0].Ids.Slug.Should().Be("show2");
            shows[0].Ids.Imdb.Should().Be("imdb2");
            shows[0].Ids.Tmdb.Should().Be(12345U);
            shows[0].Ids.Tvdb.Should().Be(123456U);
            shows[0].Ids.TvRage.Should().Be(1234567U);
            shows[0].Rating.Should().HaveValue();
            shows[0].RatedAt.Should().HaveValue();
            shows[0].Seasons.Should().NotBeNull().And.HaveCount(2);

            show1Seasons = shows[0].Seasons.ToArray();

            show1Seasons[0].Number.Should().Be(1);
            show1Seasons[0].Episodes.Should().NotBeNull().And.HaveCount(3);
            show1Seasons[0].Rating.Should().HaveValue();
            show1Seasons[0].RatedAt.Should().NotHaveValue();

            show1Seasons[1].Number.Should().Be(2);
            show1Seasons[1].Episodes.Should().NotBeNull().And.HaveCount(3);
            show1Seasons[1].Rating.Should().HaveValue();
            show1Seasons[1].RatedAt.Should().NotHaveValue();

            show1Season1Episodes = show1Seasons[0].Episodes.ToArray();

            show1Season1Episodes[0].Number.Should().Be(1);
            show1Season1Episodes[0].Rating.Should().HaveValue();
            show1Season1Episodes[0].RatedAt.Should().NotHaveValue();

            show1Season1Episodes[1].Number.Should().Be(2);
            show1Season1Episodes[1].Rating.Should().NotHaveValue();
            show1Season1Episodes[1].RatedAt.Should().NotHaveValue();

            show1Season1Episodes[2].Number.Should().Be(3);
            show1Season1Episodes[2].Rating.Should().HaveValue();
            show1Season1Episodes[2].RatedAt.Should().NotHaveValue();

            show1Season2Episodes = show1Seasons[1].Episodes.ToArray();

            show1Season2Episodes[0].Number.Should().Be(4);
            show1Season2Episodes[0].Rating.Should().NotHaveValue();
            show1Season2Episodes[0].RatedAt.Should().NotHaveValue();

            show1Season2Episodes[1].Number.Should().Be(5);
            show1Season2Episodes[1].Rating.Should().HaveValue();
            show1Season2Episodes[1].RatedAt.Should().NotHaveValue();

            show1Season2Episodes[2].Number.Should().Be(6);
            show1Season2Episodes[2].Rating.Should().NotHaveValue();
            show1Season2Episodes[2].RatedAt.Should().NotHaveValue();

            // ---------------------------------------------------------

            builder = TraktSyncRatingsPost.Builder();

            builder.AddShowWithRating(show2, rating, ratedAt, new PostRatingsSeasons {
                { 1, seasonRating, DateTime.Now, new PostRatingsEpisodes {  // season 1 - episode 1, 2, 3
                        { 1, episodeRating, DateTime.Now },
                        2,
                        { 3, episodeRating, DateTime.Now }
                    }
                },
                { 2, seasonRating, DateTime.Now, new PostRatingsEpisodes {  // season 2 - episode 4, 5, 6
                        4,
                        { 5, episodeRating, DateTime.Now },
                        6
                    }
                }
            });

            ratingsPost = builder.Build();

            ratingsPost.Should().NotBeNull();
            ratingsPost.Episodes.Should().BeNull();
            ratingsPost.Shows.Should().NotBeNull().And.HaveCount(1);
            ratingsPost.Movies.Should().BeNull();

            shows = ratingsPost.Shows.ToArray();

            shows[0].Should().NotBeNull();
            shows[0].Title.Should().Be("show2");
            shows[0].Year.Should().Be(2016);
            shows[0].Ids.Should().NotBeNull();
            shows[0].Ids.Trakt.Should().Be(3U);
            shows[0].Ids.Slug.Should().Be("show2");
            shows[0].Ids.Imdb.Should().Be("imdb2");
            shows[0].Ids.Tmdb.Should().Be(12345U);
            shows[0].Ids.Tvdb.Should().Be(123456U);
            shows[0].Ids.TvRage.Should().Be(1234567U);
            shows[0].Rating.Should().HaveValue();
            shows[0].RatedAt.Should().HaveValue();
            shows[0].Seasons.Should().NotBeNull().And.HaveCount(2);

            show1Seasons = shows[0].Seasons.ToArray();

            show1Seasons[0].Number.Should().Be(1);
            show1Seasons[0].Episodes.Should().NotBeNull().And.HaveCount(3);
            show1Seasons[0].Rating.Should().HaveValue();
            show1Seasons[0].RatedAt.Should().HaveValue();

            show1Seasons[1].Number.Should().Be(2);
            show1Seasons[1].Episodes.Should().NotBeNull().And.HaveCount(3);
            show1Seasons[1].Rating.Should().HaveValue();
            show1Seasons[1].RatedAt.Should().HaveValue();

            show1Season1Episodes = show1Seasons[0].Episodes.ToArray();

            show1Season1Episodes[0].Number.Should().Be(1);
            show1Season1Episodes[0].Rating.Should().HaveValue();
            show1Season1Episodes[0].RatedAt.Should().HaveValue();

            show1Season1Episodes[1].Number.Should().Be(2);
            show1Season1Episodes[1].Rating.Should().NotHaveValue();
            show1Season1Episodes[1].RatedAt.Should().NotHaveValue();

            show1Season1Episodes[2].Number.Should().Be(3);
            show1Season1Episodes[2].Rating.Should().HaveValue();
            show1Season1Episodes[2].RatedAt.Should().HaveValue();

            show1Season2Episodes = show1Seasons[1].Episodes.ToArray();

            show1Season2Episodes[0].Number.Should().Be(4);
            show1Season2Episodes[0].Rating.Should().NotHaveValue();
            show1Season2Episodes[0].RatedAt.Should().NotHaveValue();

            show1Season2Episodes[1].Number.Should().Be(5);
            show1Season2Episodes[1].Rating.Should().HaveValue();
            show1Season2Episodes[1].RatedAt.Should().HaveValue();

            show1Season2Episodes[2].Number.Should().Be(6);
            show1Season2Episodes[2].Rating.Should().NotHaveValue();
            show1Season2Episodes[2].RatedAt.Should().NotHaveValue();

            // ---------------------------------------------------------

            builder = TraktSyncRatingsPost.Builder();

            builder.AddShowWithRating(show2, rating, ratedAt, new PostRatingsSeasons {
                { 1, seasonRating, new PostRatingsEpisodes {  // season 1 - episode 1, 2, 3
                        { 1, episodeRating, DateTime.Now },
                        2,
                        { 3, episodeRating, DateTime.Now }
                    }
                },
                { 2, seasonRating, DateTime.Now, new PostRatingsEpisodes {  // season 2 - episode 4, 5, 6
                        4,
                        { 5, episodeRating, DateTime.Now },
                        6
                    }
                }
            });

            ratingsPost = builder.Build();

            ratingsPost.Should().NotBeNull();
            ratingsPost.Episodes.Should().BeNull();
            ratingsPost.Shows.Should().NotBeNull().And.HaveCount(1);
            ratingsPost.Movies.Should().BeNull();

            shows = ratingsPost.Shows.ToArray();

            shows[0].Should().NotBeNull();
            shows[0].Title.Should().Be("show2");
            shows[0].Year.Should().Be(2016);
            shows[0].Ids.Should().NotBeNull();
            shows[0].Ids.Trakt.Should().Be(3U);
            shows[0].Ids.Slug.Should().Be("show2");
            shows[0].Ids.Imdb.Should().Be("imdb2");
            shows[0].Ids.Tmdb.Should().Be(12345U);
            shows[0].Ids.Tvdb.Should().Be(123456U);
            shows[0].Ids.TvRage.Should().Be(1234567U);
            shows[0].Rating.Should().HaveValue();
            shows[0].RatedAt.Should().HaveValue();
            shows[0].Seasons.Should().NotBeNull().And.HaveCount(2);

            show1Seasons = shows[0].Seasons.ToArray();

            show1Seasons[0].Number.Should().Be(1);
            show1Seasons[0].Episodes.Should().NotBeNull().And.HaveCount(3);
            show1Seasons[0].Rating.Should().HaveValue();
            show1Seasons[0].RatedAt.Should().NotHaveValue();

            show1Seasons[1].Number.Should().Be(2);
            show1Seasons[1].Episodes.Should().NotBeNull().And.HaveCount(3);
            show1Seasons[1].Rating.Should().HaveValue();
            show1Seasons[1].RatedAt.Should().HaveValue();

            show1Season1Episodes = show1Seasons[0].Episodes.ToArray();

            show1Season1Episodes[0].Number.Should().Be(1);
            show1Season1Episodes[0].Rating.Should().HaveValue();
            show1Season1Episodes[0].RatedAt.Should().HaveValue();

            show1Season1Episodes[1].Number.Should().Be(2);
            show1Season1Episodes[1].Rating.Should().NotHaveValue();
            show1Season1Episodes[1].RatedAt.Should().NotHaveValue();

            show1Season1Episodes[2].Number.Should().Be(3);
            show1Season1Episodes[2].Rating.Should().HaveValue();
            show1Season1Episodes[2].RatedAt.Should().HaveValue();

            show1Season2Episodes = show1Seasons[1].Episodes.ToArray();

            show1Season2Episodes[0].Number.Should().Be(4);
            show1Season2Episodes[0].Rating.Should().NotHaveValue();
            show1Season2Episodes[0].RatedAt.Should().NotHaveValue();

            show1Season2Episodes[1].Number.Should().Be(5);
            show1Season2Episodes[1].Rating.Should().HaveValue();
            show1Season2Episodes[1].RatedAt.Should().HaveValue();

            show1Season2Episodes[2].Number.Should().Be(6);
            show1Season2Episodes[2].Rating.Should().NotHaveValue();
            show1Season2Episodes[2].RatedAt.Should().NotHaveValue();
        }

        [TestMethod]
        public void TestTraktSyncRatingsPostBuilderAddShowWithSeasonsAndEpisodesArgumentExceptions()
        {
            var builder = TraktSyncRatingsPost.Builder();

            Action act = () => builder.AddShow(null, new PostRatingsSeasons { 1 });
            act.ShouldThrow<ArgumentNullException>();

            act = () => builder.AddShow(new TraktShow(), new PostRatingsSeasons { 1 });
            act.ShouldThrow<ArgumentNullException>();

            act = () => builder.AddShow(new TraktShow { Ids = new TraktShowIds() }, new PostRatingsSeasons { 1 });
            act.ShouldThrow<ArgumentException>();

            act = () => builder.AddShow(new TraktShow { Ids = new TraktShowIds { Trakt = 1 }, Year = 123 }, new PostRatingsSeasons { 1 });
            act.ShouldThrow<ArgumentException>();

            act = () => builder.AddShow(new TraktShow { Ids = new TraktShowIds { Trakt = 1 }, Year = 12345 }, new PostRatingsSeasons { 1 });
            act.ShouldThrow<ArgumentException>();

            act = () => builder.AddShow(new TraktShow { Ids = new TraktShowIds { Trakt = 1 } }, default(PostRatingsSeasons));
            act.ShouldThrow<ArgumentNullException>();

            act = () => builder.AddShow(new TraktShow { Ids = new TraktShowIds { Trakt = 1 } }, new PostRatingsSeasons { -1 });
            act.ShouldThrow<ArgumentOutOfRangeException>();

            act = () => builder.AddShow(new TraktShow { Ids = new TraktShowIds { Trakt = 1 } }, new PostRatingsSeasons { 1, -1 });
            act.ShouldThrow<ArgumentOutOfRangeException>();

            act = () => builder.AddShow(new TraktShow { Ids = new TraktShowIds { Trakt = 1 } }, new PostRatingsSeasons { { -1, new PostRatingsEpisodes { 1, 2 } } });
            act.ShouldThrow<ArgumentOutOfRangeException>();

            act = () => builder.AddShow(new TraktShow { Ids = new TraktShowIds { Trakt = 1 } }, new PostRatingsSeasons { { 1, new PostRatingsEpisodes { 1, -1 } } });
            act.ShouldThrow<ArgumentOutOfRangeException>();

            act = () => builder.AddShow(new TraktShow { Ids = new TraktShowIds { Trakt = 1 } }, new PostRatingsSeasons { { 1, new PostRatingsEpisodes { 1, 2 } },
                                                                                                                         { 1, new PostRatingsEpisodes { 1, -1} } });
            act.ShouldThrow<ArgumentOutOfRangeException>();

            act = () => builder.AddShow(new TraktShow { Ids = new TraktShowIds { Trakt = 1 } }, new PostRatingsSeasons { { 1, new PostRatingsEpisodes { 1, 2 } },
                                                                                                                         { -1, new PostRatingsEpisodes { 1, 2} } });
            act.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [TestMethod]
        public void TestTraktSyncRatingsPostBuilderAddShowWithSeasonsAndEpisodesAndRatingArgumentExceptions()
        {
            var builder = TraktSyncRatingsPost.Builder();

            var rating = 5;

            Action act = () => builder.AddShowWithRating(null, rating, new PostRatingsSeasons { 1 });
            act.ShouldThrow<ArgumentNullException>();

            act = () => builder.AddShowWithRating(new TraktShow(), rating, new PostRatingsSeasons { 1 });
            act.ShouldThrow<ArgumentNullException>();

            act = () => builder.AddShowWithRating(new TraktShow { Ids = new TraktShowIds() }, rating, new PostRatingsSeasons { 1 });
            act.ShouldThrow<ArgumentException>();

            act = () => builder.AddShowWithRating(new TraktShow { Ids = new TraktShowIds { Trakt = 1 }, Year = 123 }, rating, new PostRatingsSeasons { 1 });
            act.ShouldThrow<ArgumentException>();

            act = () => builder.AddShowWithRating(new TraktShow { Ids = new TraktShowIds { Trakt = 1 }, Year = 12345 }, rating, new PostRatingsSeasons { 1 });
            act.ShouldThrow<ArgumentException>();

            act = () => builder.AddShowWithRating(new TraktShow { Ids = new TraktShowIds { Trakt = 1 } }, rating, default(PostRatingsSeasons));
            act.ShouldThrow<ArgumentNullException>();

            act = () => builder.AddShowWithRating(new TraktShow { Ids = new TraktShowIds { Trakt = 1 } }, 0, new PostRatingsSeasons { 1 });
            act.ShouldThrow<ArgumentOutOfRangeException>();

            act = () => builder.AddShowWithRating(new TraktShow { Ids = new TraktShowIds { Trakt = 1 } }, 11, new PostRatingsSeasons { 1 });
            act.ShouldThrow<ArgumentOutOfRangeException>();

            act = () => builder.AddShowWithRating(new TraktShow { Ids = new TraktShowIds { Trakt = 1 } }, rating, new PostRatingsSeasons { -1 });
            act.ShouldThrow<ArgumentOutOfRangeException>();

            act = () => builder.AddShowWithRating(new TraktShow { Ids = new TraktShowIds { Trakt = 1 } }, rating, new PostRatingsSeasons { 1, -1 });
            act.ShouldThrow<ArgumentOutOfRangeException>();

            act = () => builder.AddShowWithRating(new TraktShow { Ids = new TraktShowIds { Trakt = 1 } }, rating, new PostRatingsSeasons { { -1, new PostRatingsEpisodes { 1, 2 } } });
            act.ShouldThrow<ArgumentOutOfRangeException>();

            act = () => builder.AddShowWithRating(new TraktShow { Ids = new TraktShowIds { Trakt = 1 } }, rating, new PostRatingsSeasons { { 1, new PostRatingsEpisodes { 1, -1 } } });
            act.ShouldThrow<ArgumentOutOfRangeException>();

            act = () => builder.AddShowWithRating(new TraktShow { Ids = new TraktShowIds { Trakt = 1 } }, rating, new PostRatingsSeasons { { 1, new PostRatingsEpisodes { 1, 2 } },
                                                                                                                                           { 1, new PostRatingsEpisodes { 1, -1} } });
            act.ShouldThrow<ArgumentOutOfRangeException>();

            act = () => builder.AddShowWithRating(new TraktShow { Ids = new TraktShowIds { Trakt = 1 } }, rating, new PostRatingsSeasons { { 1, new PostRatingsEpisodes { 1, 2 } },
                                                                                                                                           { -1, new PostRatingsEpisodes { 1, 2} } });
            act.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [TestMethod]
        public void TestTraktSyncRatingsPostBuilderAddShowWithSeasonsAndEpisodesAndRatingAndRatedAtArgumentExceptions()
        {
            var builder = TraktSyncRatingsPost.Builder();

            var rating = 5;
            var ratedAt = DateTime.Now;

            Action act = () => builder.AddShowWithRating(null, rating, ratedAt, new PostRatingsSeasons { 1 });
            act.ShouldThrow<ArgumentNullException>();

            act = () => builder.AddShowWithRating(new TraktShow(), rating, ratedAt, new PostRatingsSeasons { 1 });
            act.ShouldThrow<ArgumentNullException>();

            act = () => builder.AddShowWithRating(new TraktShow { Ids = new TraktShowIds() }, rating, ratedAt, new PostRatingsSeasons { 1 });
            act.ShouldThrow<ArgumentException>();

            act = () => builder.AddShowWithRating(new TraktShow { Ids = new TraktShowIds { Trakt = 1 }, Year = 123 }, rating, ratedAt, new PostRatingsSeasons { 1 });
            act.ShouldThrow<ArgumentException>();

            act = () => builder.AddShowWithRating(new TraktShow { Ids = new TraktShowIds { Trakt = 1 }, Year = 12345 }, rating, ratedAt, new PostRatingsSeasons { 1 });
            act.ShouldThrow<ArgumentException>();

            act = () => builder.AddShowWithRating(new TraktShow { Ids = new TraktShowIds { Trakt = 1 } }, rating, ratedAt, default(PostRatingsSeasons));
            act.ShouldThrow<ArgumentNullException>();

            act = () => builder.AddShowWithRating(new TraktShow { Ids = new TraktShowIds { Trakt = 1 } }, 0, ratedAt, new PostRatingsSeasons { 1 });
            act.ShouldThrow<ArgumentOutOfRangeException>();

            act = () => builder.AddShowWithRating(new TraktShow { Ids = new TraktShowIds { Trakt = 1 } }, 11, ratedAt, new PostRatingsSeasons { 1 });
            act.ShouldThrow<ArgumentOutOfRangeException>();

            act = () => builder.AddShowWithRating(new TraktShow { Ids = new TraktShowIds { Trakt = 1 } }, rating, ratedAt, new PostRatingsSeasons { -1 });
            act.ShouldThrow<ArgumentOutOfRangeException>();

            act = () => builder.AddShowWithRating(new TraktShow { Ids = new TraktShowIds { Trakt = 1 } }, rating, ratedAt, new PostRatingsSeasons { 1, -1 });
            act.ShouldThrow<ArgumentOutOfRangeException>();

            act = () => builder.AddShowWithRating(new TraktShow { Ids = new TraktShowIds { Trakt = 1 } }, rating, ratedAt, new PostRatingsSeasons { { -1, new PostRatingsEpisodes { 1, 2 } } });
            act.ShouldThrow<ArgumentOutOfRangeException>();

            act = () => builder.AddShowWithRating(new TraktShow { Ids = new TraktShowIds { Trakt = 1 } }, rating, ratedAt, new PostRatingsSeasons { { 1, new PostRatingsEpisodes { 1, -1 } } });
            act.ShouldThrow<ArgumentOutOfRangeException>();

            act = () => builder.AddShowWithRating(new TraktShow { Ids = new TraktShowIds { Trakt = 1 } }, rating, ratedAt, new PostRatingsSeasons { { 1, new PostRatingsEpisodes { 1, 2 } },
                                                                                                                                                    { 1, new PostRatingsEpisodes { 1, -1} } });
            act.ShouldThrow<ArgumentOutOfRangeException>();

            act = () => builder.AddShowWithRating(new TraktShow { Ids = new TraktShowIds { Trakt = 1 } }, rating, ratedAt, new PostRatingsSeasons { { 1, new PostRatingsEpisodes { 1, 2 } },
                                                                                                                                                    { -1, new PostRatingsEpisodes { 1, 2} } });
            act.ShouldThrow<ArgumentOutOfRangeException>();
        }

        // ----------------------------------------------------------------------------------------
        // ----------------------------------------------------------------------------------------

        [TestMethod]
        public void TestTraktSyncRatingsPostBuilderReset()
        {
            var movie1 = new TraktMovie
            {
                Title = "movie1",
                Year = 2016,
                Ids = new TraktMovieIds
                {
                    Trakt = 1,
                    Slug = "movie1",
                    Imdb = "imdb1",
                    Tmdb = 1234
                }
            };

            var episode1 = new TraktEpisode
            {
                Ids = new TraktEpisodeIds
                {
                    Trakt = 1,
                    Imdb = "imdb1",
                    Tmdb = 1234,
                    Tvdb = 12345,
                    TvRage = 123456
                }
            };

            var show1 = new TraktShow
            {
                Title = "show1",
                Year = 2016,
                Ids = new TraktShowIds
                {
                    Trakt = 1,
                    Slug = "show1",
                    Imdb = "imdb1",
                    Tmdb = 1234,
                    Tvdb = 12345,
                    TvRage = 123456
                }
            };

            var builder = TraktSyncRatingsPost.Builder();

            var ratingsPost = builder.AddMovie(movie1)
                                    .AddEpisode(episode1)
                                    .AddShow(show1)
                                    .Build();

            ratingsPost.Should().NotBeNull();
            ratingsPost.Movies.Should().NotBeNull().And.HaveCount(1);
            ratingsPost.Shows.Should().NotBeNull().And.HaveCount(1);
            ratingsPost.Episodes.Should().NotBeNull().And.HaveCount(1);

            builder.Reset();

            ratingsPost = builder.Build();

            ratingsPost.Should().NotBeNull();
            ratingsPost.Movies.Should().BeNull();
            ratingsPost.Shows.Should().BeNull();
            ratingsPost.Episodes.Should().BeNull();
        }

        // ----------------------------------------------------------------------------------------
        // ----------------------------------------------------------------------------------------

        [TestMethod]
        public void TestTraktSyncRatingsPostBuilderAddAll()
        {
            var movie1 = new TraktMovie
            {
                Title = "movie1",
                Year = 2016,
                Ids = new TraktMovieIds
                {
                    Trakt = 1,
                    Slug = "movie1",
                    Imdb = "imdb1",
                    Tmdb = 1234
                }
            };

            var movie2 = new TraktMovie
            {
                Title = "movie2",
                Year = 2016,
                Ids = new TraktMovieIds
                {
                    Trakt = 2,
                    Slug = "movie2",
                    Imdb = "imdb2",
                    Tmdb = 12345
                }
            };

            var movie3 = new TraktMovie
            {
                Title = "movie3",
                Year = 2016,
                Ids = new TraktMovieIds
                {
                    Trakt = 3,
                    Slug = "movie3",
                    Imdb = "imdb3",
                    Tmdb = 123456
                }
            };

            var episode1 = new TraktEpisode
            {
                Ids = new TraktEpisodeIds
                {
                    Trakt = 1,
                    Imdb = "imdb1",
                    Tmdb = 1234,
                    Tvdb = 12345,
                    TvRage = 123456
                }
            };

            var episode2 = new TraktEpisode
            {
                Ids = new TraktEpisodeIds
                {
                    Trakt = 2,
                    Imdb = "imdb2",
                    Tmdb = 12345,
                    Tvdb = 123456,
                    TvRage = 1234567
                }
            };

            var episode3 = new TraktEpisode
            {
                Ids = new TraktEpisodeIds
                {
                    Trakt = 3,
                    Imdb = "imdb3",
                    Tmdb = 123456,
                    Tvdb = 1234567,
                    TvRage = 12345678
                }
            };

            var show1 = new TraktShow
            {
                Title = "show1",
                Year = 2016,
                Ids = new TraktShowIds
                {
                    Trakt = 1,
                    Slug = "show1",
                    Imdb = "imdb1",
                    Tmdb = 1234,
                    Tvdb = 12345,
                    TvRage = 123456
                }
            };

            var show2 = new TraktShow
            {
                Title = "show2",
                Year = 2016,
                Ids = new TraktShowIds
                {
                    Trakt = 2,
                    Slug = "show2",
                    Imdb = "imdb2",
                    Tmdb = 12345,
                    Tvdb = 123456,
                    TvRage = 1234567
                }
            };

            var show3 = new TraktShow
            {
                Ids = new TraktShowIds
                {
                    Trakt = 3,
                    Slug = "show3",
                    Imdb = "imdb3",
                    Tmdb = 123456,
                    Tvdb = 1234567,
                    TvRage = 12345678
                }
            };

            var show4 = new TraktShow
            {
                Ids = new TraktShowIds
                {
                    Trakt = 4,
                    Slug = "show4",
                    Imdb = "imdb4",
                    Tmdb = 1234567,
                    Tvdb = 12345678,
                    TvRage = 123456789
                }
            };

            var show5 = new TraktShow
            {
                Ids = new TraktShowIds
                {
                    Trakt = 5,
                    Slug = "show5",
                    Imdb = "imdb5",
                    Tmdb = 2234567,
                    Tvdb = 22345678,
                    TvRage = 223456789
                }
            };

            var show6 = new TraktShow
            {
                Ids = new TraktShowIds
                {
                    Trakt = 6,
                    Slug = "show6",
                    Imdb = "imdb6",
                    Tmdb = 2334567,
                    Tvdb = 23345678,
                    TvRage = 233456789
                }
            };

            var show7 = new TraktShow
            {
                Ids = new TraktShowIds
                {
                    Trakt = 7,
                    Slug = "show7",
                    Imdb = "imdb7",
                    Tmdb = 2344567,
                    Tvdb = 23445678,
                    TvRage = 234456789
                }
            };

            var show8 = new TraktShow
            {
                Ids = new TraktShowIds
                {
                    Trakt = 8,
                    Slug = "show8",
                    Imdb = "imdb8",
                    Tmdb = 2345567,
                    Tvdb = 22455678,
                    TvRage = 224556789
                }
            };

            var show9 = new TraktShow
            {
                Ids = new TraktShowIds
                {
                    Trakt = 9,
                    Slug = "show9",
                    Imdb = "imdb9",
                    Tmdb = 2345667,
                    Tvdb = 22456678,
                    TvRage = 224566789
                }
            };

            var rating = 5;
            var ratedAt = DateTime.UtcNow;

            var builder = TraktSyncRatingsPost.Builder();

            var ratingsPost = builder.Build();

            ratingsPost.Should().NotBeNull();
            ratingsPost.Movies.Should().BeNull();
            ratingsPost.Shows.Should().BeNull();
            ratingsPost.Episodes.Should().BeNull();

            // ------------------------------------------------------

            ratingsPost = builder.AddMovie(movie1)
                                .AddMovie(movie2, rating)
                                .AddMovie(movie3, rating, ratedAt)
                                .AddEpisode(episode1)
                                .AddEpisode(episode2, rating)
                                .AddEpisode(episode3, rating, ratedAt)
                                .AddShow(show1)
                                .AddShowWithRating(show2, rating)
                                .AddShowWithRating(show3, rating, ratedAt)
                                .AddShow(show4, 1, 2, 3)
                                .AddShowWithRating(show5, rating, 1, 2, 3)
                                .AddShowWithRating(show6, rating, ratedAt, 1, 2, 3)
                                .AddShow(show7, new PostRatingsSeasons { { 1, new PostRatingsEpisodes { 1, 2, 3 } },
                                                                            { 2, new PostRatingsEpisodes { 2} } })
                                .AddShowWithRating(show8, rating, new PostRatingsSeasons { { 1, new PostRatingsEpisodes { 1, 2, 3 } },
                                                                                            { 2, new PostRatingsEpisodes { 2} } })
                                .AddShowWithRating(show9, rating, ratedAt, new PostRatingsSeasons { { 1, new PostRatingsEpisodes { 1, 2, 3 } },
                                                                                                    { 2, new PostRatingsEpisodes { 2} } })
                                .Build();

            ratingsPost.Should().NotBeNull();
            ratingsPost.Movies.Should().NotBeNull().And.HaveCount(3);
            ratingsPost.Shows.Should().NotBeNull().And.HaveCount(9);
            ratingsPost.Episodes.Should().NotBeNull().And.HaveCount(3);
        }
    }
}

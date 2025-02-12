namespace TraktNET.Json.Movies
{
    public sealed class TraktUpdatedMovieTests
    {
        [Fact]
        public void TestTraktUpdatedMovieConstructor()
        {
            var updatedMovie = new TraktUpdatedMovie();

            updatedMovie.Title.ShouldBeNull();
            updatedMovie.Year.ShouldBeNull();
            updatedMovie.IDs.ShouldBeNull();
            updatedMovie.Tagline.ShouldBeNull();
            updatedMovie.Overview.ShouldBeNull();
            updatedMovie.Released.ShouldBeNull();
            updatedMovie.Runtime.ShouldBeNull();
            updatedMovie.Country.ShouldBeNull();
            updatedMovie.Trailer.ShouldBeNull();
            updatedMovie.Homepage.ShouldBeNull();
            updatedMovie.Status.ShouldBeNull();
            updatedMovie.Rating.ShouldBeNull();
            updatedMovie.Votes.ShouldBeNull();
            updatedMovie.CommentCount.ShouldBeNull();
            updatedMovie.UpdatedAt.ShouldBeNull();
            updatedMovie.Language.ShouldBeNull();
            updatedMovie.Languages.ShouldBeNull();
            updatedMovie.AvailableTranslations.ShouldBeNull();
            updatedMovie.Genres.ShouldBeNull();
            updatedMovie.Certification.ShouldBeNull();

            updatedMovie.ToString().ShouldBeEmpty();
        }

        [Fact]
        public async Task TestTraktUpdatedMovieFromJsonMinimal()
        {
            TraktUpdatedMovie? updatedMovie = await TraktTestUtility.DeserializeJsonAsync<TraktUpdatedMovie>("Movies\\updatedmovie_minimal.json");

            updatedMovie.ShouldNotBeNull();

            updatedMovie!.UpdatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2024-09-23T01:16:57.000Z"));

            updatedMovie!.Title.ShouldBe("Second Life");
            updatedMovie!.Year.ShouldBe(2024U);

            updatedMovie!.IDs!.Trakt.ShouldBe(1110139U);
            updatedMovie!.IDs!.Slug.ShouldBe("second-life-2024-1110139");
            updatedMovie!.IDs!.IMDB.ShouldBe("tt33111253");
            updatedMovie!.IDs!.TMDB.ShouldBe(1329643U);
            updatedMovie!.IDs!.HasAnyID.ShouldBe(true);
            updatedMovie!.IDs!.BestID.ShouldBe("second-life-2024-1110139");

            updatedMovie!.ToString().ShouldBe("Second Life (2024)");
        }

        [Fact]
        public async Task TestTraktUpdatedMovieFromJson()
        {
            TraktUpdatedMovie? updatedMovie = await TraktTestUtility.DeserializeJsonAsync<TraktUpdatedMovie>("Movies\\updatedmovie.json");

            updatedMovie.ShouldNotBeNull();

            updatedMovie!.UpdatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2024-09-23T01:16:57.000Z"));

            updatedMovie!.Title.ShouldBe("Second Life");
            updatedMovie!.Year.ShouldBe(2024U);

            updatedMovie!.IDs!.Trakt.ShouldBe(1110139U);
            updatedMovie!.IDs!.Slug.ShouldBe("second-life-2024-1110139");
            updatedMovie!.IDs!.IMDB.ShouldBe("tt33111253");
            updatedMovie!.IDs!.TMDB.ShouldBe(1329643U);
            updatedMovie!.IDs!.HasAnyID.ShouldBe(true);
            updatedMovie!.IDs!.BestID.ShouldBe("second-life-2024-1110139");

            updatedMovie!.ToString().ShouldBe("Second Life (2024)");

            updatedMovie!.Tagline.ShouldBeEmpty();
            updatedMovie!.Overview.ShouldBe("28 years ago, Liang gives birth to a boy named \"Little Bean Jelly\" in prison.");
            updatedMovie!.Released.ShouldBeNull();
            updatedMovie!.Runtime.ShouldBe(90U);
            updatedMovie!.Country.ShouldBe("cn");
            updatedMovie!.Trailer.ShouldBe("https://youtube.com/watch?v=m3SX4GyJn_M");
            updatedMovie!.Homepage.ShouldBe("http://www.iq.com/album/second-life-2024-xxlxrt2rs0");
            updatedMovie!.Status.ShouldBe(TraktMovieStatus.Released);
            updatedMovie!.Rating.ShouldBe(0.0f);
            updatedMovie!.Votes.ShouldBe(0U);
            updatedMovie!.CommentCount.ShouldBe(0U);
            updatedMovie!.UpdatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2024-09-23T01:16:57.000Z"));
            updatedMovie!.Language.ShouldBe("zh");
            updatedMovie!.Languages.ShouldNotBeNull();
            updatedMovie!.Languages!.Count.ShouldBe(1);
            updatedMovie!.Languages!.ShouldBe(["zh"], Case.Sensitive);

            updatedMovie!.AvailableTranslations.ShouldBeEmpty();

            updatedMovie!.Genres.ShouldNotBeNull();
            updatedMovie!.Genres!.Count.ShouldBe(2);
            updatedMovie!.Genres!.ShouldBe([
                "action", "comedy"
            ], Case.Sensitive);

            updatedMovie!.Certification.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktUpdatedMoviesFromJsonMinimal()
        {
            IReadOnlyList<TraktUpdatedMovie>? updatedMovies = await TraktTestUtility.DeserializeJsonListAsync<TraktUpdatedMovie>("Movies\\updatedmovies_minimal.json");

            updatedMovies.ShouldNotBeNull();
            updatedMovies!.Count.ShouldBe(2);

            TraktUpdatedMovie updatedMovie = updatedMovies![0];

            updatedMovie.ShouldNotBeNull();

            updatedMovie.UpdatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2024-09-23T01:16:57.000Z"));

            updatedMovie.Title.ShouldBe("Second Life");
            updatedMovie.Year.ShouldBe(2024U);

            updatedMovie.IDs!.Trakt.ShouldBe(1110139U);
            updatedMovie.IDs!.Slug.ShouldBe("second-life-2024-1110139");
            updatedMovie.IDs!.IMDB.ShouldBe("tt33111253");
            updatedMovie.IDs!.TMDB.ShouldBe(1329643U);
            updatedMovie.IDs!.HasAnyID.ShouldBe(true);
            updatedMovie.IDs!.BestID.ShouldBe("second-life-2024-1110139");

            updatedMovie.ToString().ShouldBe("Second Life (2024)");

            // --------------------------------------------------------------------------------------------

            updatedMovie = updatedMovies![1];

            updatedMovie.ShouldNotBeNull();

            updatedMovie.UpdatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2024-09-23T01:58:06.000Z"));

            updatedMovie.Title.ShouldBe("Milk & Serial");
            updatedMovie.Year.ShouldBe(2024U);

            updatedMovie.IDs!.Trakt.ShouldBe(957899U);
            updatedMovie.IDs!.Slug.ShouldBe("milk-serial-2024");
            updatedMovie.IDs!.IMDB.ShouldBe("tt22075376");
            updatedMovie.IDs!.TMDB.ShouldBe(1187782U);
            updatedMovie.IDs!.HasAnyID.ShouldBe(true);
            updatedMovie.IDs!.BestID.ShouldBe("milk-serial-2024");

            updatedMovie.ToString().ShouldBe("Milk & Serial (2024)");
        }

        [Fact]
        public async Task TestTraktUpdatedMoviesFromJson()
        {
            IReadOnlyList<TraktUpdatedMovie>? updatedMovies = await TraktTestUtility.DeserializeJsonListAsync<TraktUpdatedMovie>("Movies\\updatedmovies.json");

            updatedMovies.ShouldNotBeNull();
            updatedMovies!.Count.ShouldBe(2);

            TraktUpdatedMovie updatedMovie = updatedMovies![0];

            updatedMovie.ShouldNotBeNull();

            updatedMovie.UpdatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2024-09-23T01:16:57.000Z"));

            updatedMovie.Title.ShouldBe("Second Life");
            updatedMovie.Year.ShouldBe(2024U);

            updatedMovie.IDs!.Trakt.ShouldBe(1110139U);
            updatedMovie.IDs!.Slug.ShouldBe("second-life-2024-1110139");
            updatedMovie.IDs!.IMDB.ShouldBe("tt33111253");
            updatedMovie.IDs!.TMDB.ShouldBe(1329643U);
            updatedMovie.IDs!.HasAnyID.ShouldBe(true);
            updatedMovie.IDs!.BestID.ShouldBe("second-life-2024-1110139");

            updatedMovie.ToString().ShouldBe("Second Life (2024)");

            updatedMovie.Tagline.ShouldBeEmpty();
            updatedMovie.Overview.ShouldBe("28 years ago, Liang gives birth to a boy named \"Little Bean Jelly\" in prison.");
            updatedMovie.Released.ShouldBeNull();
            updatedMovie.Runtime.ShouldBe(90U);
            updatedMovie.Country.ShouldBe("cn");
            updatedMovie.Trailer.ShouldBe("https://youtube.com/watch?v=m3SX4GyJn_M");
            updatedMovie.Homepage.ShouldBe("http://www.iq.com/album/second-life-2024-xxlxrt2rs0");
            updatedMovie.Status.ShouldBe(TraktMovieStatus.Released);
            updatedMovie.Rating.ShouldBe(0.0f);
            updatedMovie.Votes.ShouldBe(0U);
            updatedMovie.CommentCount.ShouldBe(0U);
            updatedMovie.UpdatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2024-09-23T01:16:57.000Z"));
            updatedMovie.Language.ShouldBe("zh");
            updatedMovie.Languages.ShouldNotBeNull();
            updatedMovie.Languages!.Count.ShouldBe(1);
            updatedMovie.Languages!.ShouldBe(["zh"], Case.Sensitive);

            updatedMovie.AvailableTranslations.ShouldBeEmpty();

            updatedMovie.Genres.ShouldNotBeNull();
            updatedMovie.Genres!.Count.ShouldBe(2);
            updatedMovie.Genres!.ShouldBe([
                "action", "comedy"
            ], Case.Sensitive);

            updatedMovie.Certification.ShouldBeNull();

            // --------------------------------------------------------------------------------------------

            updatedMovie = updatedMovies![1];

            updatedMovie.ShouldNotBeNull();

            updatedMovie.UpdatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2024-09-23T01:58:06.000Z"));

            updatedMovie.Title.ShouldBe("Milk & Serial");
            updatedMovie.Year.ShouldBe(2024U);

            updatedMovie.IDs!.Trakt.ShouldBe(957899U);
            updatedMovie.IDs!.Slug.ShouldBe("milk-serial-2024");
            updatedMovie.IDs!.IMDB.ShouldBe("tt22075376");
            updatedMovie.IDs!.TMDB.ShouldBe(1187782U);
            updatedMovie.IDs!.HasAnyID.ShouldBe(true);
            updatedMovie.IDs!.BestID.ShouldBe("milk-serial-2024");

            updatedMovie.ToString().ShouldBe("Milk & Serial (2024)");

            updatedMovie.Tagline.ShouldBeEmpty();

            updatedMovie.Overview.ShouldBe("A surprise birthday prank takes a turn for the worse when a popular social media "
                + "duo must face the reality of the terrifying aftermath.");

#if NET7_0_OR_GREATER
            updatedMovie!.Released.ShouldBe(TestUtility.ParseDate("2024-08-08"));
#else
            updatedMovie!.Released.ShouldBe(TestUtility.ParseUTCDateTime("2024-08-08T00:00:00.000Z"));
#endif
            updatedMovie.Runtime.ShouldBe(62U);
            updatedMovie.Country.ShouldBe("us");
            updatedMovie.Trailer.ShouldBeNull();
            updatedMovie.Homepage.ShouldBeNull();
            updatedMovie.Status.ShouldBe(TraktMovieStatus.Released);
            updatedMovie.Rating.ShouldBe(6.5641f);
            updatedMovie.Votes.ShouldBe(39U);
            updatedMovie.CommentCount.ShouldBe(3U);
            updatedMovie.UpdatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2024-09-23T01:58:06.000Z"));
            updatedMovie.Language.ShouldBe("en");
            updatedMovie.Languages.ShouldNotBeNull();
            updatedMovie.Languages!.Count.ShouldBe(1);
            updatedMovie.Languages!.ShouldBe(["en"], Case.Sensitive);

            updatedMovie.AvailableTranslations.ShouldNotBeNull();
            updatedMovie.AvailableTranslations!.Count.ShouldBe(1);
            updatedMovie.AvailableTranslations!.ShouldBe(["en"], Case.Sensitive);

            updatedMovie.Genres.ShouldNotBeNull();
            updatedMovie.Genres!.Count.ShouldBe(2);
            updatedMovie.Genres!.ShouldBe([
                "horror", "thriller"
            ], Case.Sensitive);

            updatedMovie.Certification.ShouldBeNull();
        }
    }
}

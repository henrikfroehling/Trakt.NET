namespace TraktNET.Json.Movies
{
    public sealed class TraktMostFavoritedMovieTests
    {
        [Fact]
        public void TestTraktMostFavoritedMovieConstructor()
        {
            var mostFavoritedMovie = new TraktMostFavoritedMovie();

            mostFavoritedMovie.UserCount.ShouldBeNull();
            mostFavoritedMovie.Title.ShouldBeNull();
            mostFavoritedMovie.Year.ShouldBeNull();
            mostFavoritedMovie.IDs.ShouldBeNull();
            mostFavoritedMovie.Tagline.ShouldBeNull();
            mostFavoritedMovie.Overview.ShouldBeNull();
            mostFavoritedMovie.Released.ShouldBeNull();
            mostFavoritedMovie.Runtime.ShouldBeNull();
            mostFavoritedMovie.Country.ShouldBeNull();
            mostFavoritedMovie.Trailer.ShouldBeNull();
            mostFavoritedMovie.Homepage.ShouldBeNull();
            mostFavoritedMovie.Status.ShouldBeNull();
            mostFavoritedMovie.Rating.ShouldBeNull();
            mostFavoritedMovie.Votes.ShouldBeNull();
            mostFavoritedMovie.CommentCount.ShouldBeNull();
            mostFavoritedMovie.UpdatedAt.ShouldBeNull();
            mostFavoritedMovie.Language.ShouldBeNull();
            mostFavoritedMovie.Languages.ShouldBeNull();
            mostFavoritedMovie.AvailableTranslations.ShouldBeNull();
            mostFavoritedMovie.Genres.ShouldBeNull();
            mostFavoritedMovie.Certification.ShouldBeNull();

            mostFavoritedMovie.ToString().ShouldBeEmpty();
        }

        [Fact]
        public async Task TestTraktMostFavoritedMovieFromJsonMinimal()
        {
            TraktMostFavoritedMovie? mostFavoritedMovie = await TraktTestUtility.DeserializeJsonAsync<TraktMostFavoritedMovie>("Movies\\mostFavoritedmovie_minimal.json");

            mostFavoritedMovie.ShouldNotBeNull();

            mostFavoritedMovie!.UserCount.ShouldBe(83U);

            mostFavoritedMovie!.Title.ShouldBe("Deadpool & Wolverine");
            mostFavoritedMovie!.Year.ShouldBe(2024U);

            mostFavoritedMovie!.IDs!.Trakt.ShouldBe(395672U);
            mostFavoritedMovie!.IDs!.Slug.ShouldBe("deadpool-wolverine-2024");
            mostFavoritedMovie!.IDs!.IMDB.ShouldBe("tt6263850");
            mostFavoritedMovie!.IDs!.TMDB.ShouldBe(533535U);
            mostFavoritedMovie!.IDs!.HasAnyID.ShouldBe(true);
            mostFavoritedMovie!.IDs!.BestID.ShouldBe("deadpool-wolverine-2024");

            mostFavoritedMovie!.ToString().ShouldBe("Deadpool & Wolverine (2024)");
        }

        [Fact]
        public async Task TestTraktMostFavoritedMovieFromJson()
        {
            TraktMostFavoritedMovie? mostFavoritedMovie = await TraktTestUtility.DeserializeJsonAsync<TraktMostFavoritedMovie>("Movies\\mostFavoritedmovie.json");

            mostFavoritedMovie.ShouldNotBeNull();

            mostFavoritedMovie!.UserCount.ShouldBe(83U);

            mostFavoritedMovie!.Title.ShouldBe("Deadpool & Wolverine");
            mostFavoritedMovie!.Year.ShouldBe(2024U);

            mostFavoritedMovie!.IDs!.Trakt.ShouldBe(395672U);
            mostFavoritedMovie!.IDs!.Slug.ShouldBe("deadpool-wolverine-2024");
            mostFavoritedMovie!.IDs!.IMDB.ShouldBe("tt6263850");
            mostFavoritedMovie!.IDs!.TMDB.ShouldBe(533535U);
            mostFavoritedMovie!.IDs!.HasAnyID.ShouldBe(true);
            mostFavoritedMovie!.IDs!.BestID.ShouldBe("deadpool-wolverine-2024");

            mostFavoritedMovie!.ToString().ShouldBe("Deadpool & Wolverine (2024)");

            mostFavoritedMovie!.Tagline.ShouldBe("Come together.");

            mostFavoritedMovie!.Overview.ShouldBe("A listless Wade Wilson toils away in civilian life with his days as the morally flexible mercenary, "
                + "Deadpool, behind him.");

#if NET7_0_OR_GREATER
            mostFavoritedMovie!.Released.ShouldBe(TestUtility.ParseDate("2024-07-26"));
#else
            mostFavoritedMovie!.Released.ShouldBe(TestUtility.ParseUTCDateTime("2024-07-26T00:00:00.000Z"));
#endif
            mostFavoritedMovie!.Runtime.ShouldBe(128U);
            mostFavoritedMovie!.Country.ShouldBe("us");
            mostFavoritedMovie!.Trailer.ShouldBe("https://youtube.com/watch?v=Idh8n5XuYIA");
            mostFavoritedMovie!.Homepage.ShouldBe("http://www.marvel.com/movies/deadpool-and-wolverine");
            mostFavoritedMovie!.Status.ShouldBe(TraktMovieStatus.Released);
            mostFavoritedMovie!.Rating.ShouldBe(8.204093653364747f);
            mostFavoritedMovie!.Votes.ShouldBe(6791U);
            mostFavoritedMovie!.CommentCount.ShouldBe(173U);
            mostFavoritedMovie!.UpdatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2024-08-12T08:05:41.000Z"));
            mostFavoritedMovie!.Language.ShouldBe("en");
            mostFavoritedMovie!.Languages.ShouldNotBeNull();
            mostFavoritedMovie!.Languages!.Count.ShouldBe(1);
            mostFavoritedMovie!.Languages!.ShouldBe(["en"], Case.Sensitive);

            mostFavoritedMovie!.AvailableTranslations.ShouldNotBeNull();
            mostFavoritedMovie!.AvailableTranslations!.Count.ShouldBe(32);
            mostFavoritedMovie!.AvailableTranslations!.ShouldBe([
                "ar", "bg", "cs", "da", "de", "el", "en", "es", "fa", "fr", "he", "hu", "id", "it", "ja", "ka",
                "kk", "ko", "lt", "nl", "pl", "pt", "ru", "sk", "sl", "sr", "sv", "th", "tr", "uk", "vi", "zh"
            ], Case.Sensitive);

            mostFavoritedMovie!.Genres.ShouldNotBeNull();
            mostFavoritedMovie!.Genres!.Count.ShouldBe(4);
            mostFavoritedMovie!.Genres!.ShouldBe([
                "comedy", "superhero", "science-fiction", "action"
            ], Case.Sensitive);

            mostFavoritedMovie!.Certification.ShouldBe("R");
        }

        [Fact]
        public async Task TestTraktMostFavoritedMoviesFromJsonMinimal()
        {
            IReadOnlyList<TraktMostFavoritedMovie>? mostFavoritedMovies = await TraktTestUtility.DeserializeJsonListAsync<TraktMostFavoritedMovie>("Movies\\mostFavoritedmovies_minimal.json");

            mostFavoritedMovies.ShouldNotBeNull();
            mostFavoritedMovies!.Count.ShouldBe(2);

            TraktMostFavoritedMovie mostFavoritedMovie = mostFavoritedMovies![0];

            mostFavoritedMovie.ShouldNotBeNull();

            mostFavoritedMovie.UserCount.ShouldBe(83U);

            mostFavoritedMovie.Title.ShouldBe("Deadpool & Wolverine");
            mostFavoritedMovie.Year.ShouldBe(2024U);

            mostFavoritedMovie.IDs!.Trakt.ShouldBe(395672U);
            mostFavoritedMovie.IDs!.Slug.ShouldBe("deadpool-wolverine-2024");
            mostFavoritedMovie.IDs!.IMDB.ShouldBe("tt6263850");
            mostFavoritedMovie.IDs!.TMDB.ShouldBe(533535U);
            mostFavoritedMovie.IDs!.HasAnyID.ShouldBe(true);
            mostFavoritedMovie.IDs!.BestID.ShouldBe("deadpool-wolverine-2024");

            mostFavoritedMovie.ToString().ShouldBe("Deadpool & Wolverine (2024)");

            // --------------------------------------------------------------------------------------------

            mostFavoritedMovie = mostFavoritedMovies![1];

            mostFavoritedMovie.ShouldNotBeNull();

            mostFavoritedMovie.UserCount.ShouldBe(48U);

            mostFavoritedMovie.Title.ShouldBe("A Quiet Place: Day One");
            mostFavoritedMovie.Year.ShouldBe(2024U);

            mostFavoritedMovie.IDs!.Trakt.ShouldBe(600962U);
            mostFavoritedMovie.IDs!.Slug.ShouldBe("a-quiet-place-day-one-2024");
            mostFavoritedMovie.IDs!.IMDB.ShouldBe("tt13433802");
            mostFavoritedMovie.IDs!.TMDB.ShouldBe(762441U);
            mostFavoritedMovie.IDs!.HasAnyID.ShouldBe(true);
            mostFavoritedMovie.IDs!.BestID.ShouldBe("a-quiet-place-day-one-2024");

            mostFavoritedMovie.ToString().ShouldBe("A Quiet Place: Day One (2024)");
        }

        [Fact]
        public async Task TestTraktMostFavoritedMoviesFromJson()
        {
            IReadOnlyList<TraktMostFavoritedMovie>? mostFavoritedMovies = await TraktTestUtility.DeserializeJsonListAsync<TraktMostFavoritedMovie>("Movies\\mostFavoritedmovies.json");

            mostFavoritedMovies.ShouldNotBeNull();
            mostFavoritedMovies!.Count.ShouldBe(2);

            TraktMostFavoritedMovie mostFavoritedMovie = mostFavoritedMovies![0];

            mostFavoritedMovie.ShouldNotBeNull();

            mostFavoritedMovie.UserCount.ShouldBe(83U);

            mostFavoritedMovie.Title.ShouldBe("Deadpool & Wolverine");
            mostFavoritedMovie.Year.ShouldBe(2024U);

            mostFavoritedMovie.IDs!.Trakt.ShouldBe(395672U);
            mostFavoritedMovie.IDs!.Slug.ShouldBe("deadpool-wolverine-2024");
            mostFavoritedMovie.IDs!.IMDB.ShouldBe("tt6263850");
            mostFavoritedMovie.IDs!.TMDB.ShouldBe(533535U);
            mostFavoritedMovie.IDs!.HasAnyID.ShouldBe(true);
            mostFavoritedMovie.IDs!.BestID.ShouldBe("deadpool-wolverine-2024");

            mostFavoritedMovie.ToString().ShouldBe("Deadpool & Wolverine (2024)");

            mostFavoritedMovie.Tagline.ShouldBe("Come together.");

            mostFavoritedMovie.Overview.ShouldBe("A listless Wade Wilson toils away in civilian life with his days as the morally flexible mercenary, "
                + "Deadpool, behind him.");

#if NET7_0_OR_GREATER
            mostFavoritedMovie.Released.ShouldBe(TestUtility.ParseDate("2024-07-26"));
#else
            mostFavoritedMovie.Released.ShouldBe(TestUtility.ParseUTCDateTime("2024-07-26T00:00:00.000Z"));
#endif
            mostFavoritedMovie.Runtime.ShouldBe(128U);
            mostFavoritedMovie.Country.ShouldBe("us");
            mostFavoritedMovie.Trailer.ShouldBe("https://youtube.com/watch?v=Idh8n5XuYIA");
            mostFavoritedMovie.Homepage.ShouldBe("http://www.marvel.com/movies/deadpool-and-wolverine");
            mostFavoritedMovie.Status.ShouldBe(TraktMovieStatus.Released);
            mostFavoritedMovie.Rating.ShouldBe(8.204093653364747f);
            mostFavoritedMovie.Votes.ShouldBe(6791U);
            mostFavoritedMovie.CommentCount.ShouldBe(173U);
            mostFavoritedMovie.UpdatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2024-08-12T08:05:41.000Z"));
            mostFavoritedMovie.Language.ShouldBe("en");
            mostFavoritedMovie.Languages.ShouldNotBeNull();
            mostFavoritedMovie.Languages!.Count.ShouldBe(1);
            mostFavoritedMovie.Languages!.ShouldBe(["en"], Case.Sensitive);

            mostFavoritedMovie.AvailableTranslations.ShouldNotBeNull();
            mostFavoritedMovie.AvailableTranslations!.Count.ShouldBe(32);
            mostFavoritedMovie.AvailableTranslations!.ShouldBe([
                "ar", "bg", "cs", "da", "de", "el", "en", "es", "fa", "fr", "he", "hu", "id", "it", "ja", "ka",
                "kk", "ko", "lt", "nl", "pl", "pt", "ru", "sk", "sl", "sr", "sv", "th", "tr", "uk", "vi", "zh"
            ], Case.Sensitive);

            mostFavoritedMovie.Genres.ShouldNotBeNull();
            mostFavoritedMovie.Genres!.Count.ShouldBe(4);
            mostFavoritedMovie.Genres!.ShouldBe([
                "comedy", "superhero", "science-fiction", "action"
            ], Case.Sensitive);

            mostFavoritedMovie.Certification.ShouldBe("R");

            // --------------------------------------------------------------------------------------------

            mostFavoritedMovie = mostFavoritedMovies![1];

            mostFavoritedMovie.ShouldNotBeNull();

            mostFavoritedMovie.UserCount.ShouldBe(48U);

            mostFavoritedMovie.Title.ShouldBe("A Quiet Place: Day One");
            mostFavoritedMovie.Year.ShouldBe(2024U);

            mostFavoritedMovie.IDs!.Trakt.ShouldBe(600962U);
            mostFavoritedMovie.IDs!.Slug.ShouldBe("a-quiet-place-day-one-2024");
            mostFavoritedMovie.IDs!.IMDB.ShouldBe("tt13433802");
            mostFavoritedMovie.IDs!.TMDB.ShouldBe(762441U);
            mostFavoritedMovie.IDs!.HasAnyID.ShouldBe(true);
            mostFavoritedMovie.IDs!.BestID.ShouldBe("a-quiet-place-day-one-2024");

            mostFavoritedMovie.ToString().ShouldBe("A Quiet Place: Day One (2024)");

            mostFavoritedMovie.Tagline.ShouldBe("Hear how it all began.");

            mostFavoritedMovie.Overview.ShouldBe("As New York City is invaded by alien creatures who hunt by sound, a woman named Sam fights "
                + "to survive with her cat.");

#if NET7_0_OR_GREATER
            mostFavoritedMovie!.Released.ShouldBe(TestUtility.ParseDate("2024-06-28"));
#else
            mostFavoritedMovie!.Released.ShouldBe(TestUtility.ParseUTCDateTime("2024-06-28T00:00:00.000Z"));
#endif
            mostFavoritedMovie.Runtime.ShouldBe(99U);
            mostFavoritedMovie.Country.ShouldBe("us");
            mostFavoritedMovie.Trailer.ShouldBe("https://youtube.com/watch?v=E-WIb4ATfT8");
            mostFavoritedMovie.Homepage.ShouldBe("http://www.aquietplacemovie.com");
            mostFavoritedMovie.Status.ShouldBe(TraktMovieStatus.Released);
            mostFavoritedMovie.Rating.ShouldBe(6.583368509919797f);
            mostFavoritedMovie.Votes.ShouldBe(4738U);
            mostFavoritedMovie.CommentCount.ShouldBe(96U);
            mostFavoritedMovie.UpdatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2024-08-12T16:55:51.000Z"));
            mostFavoritedMovie.Language.ShouldBe("en");
            mostFavoritedMovie.Languages.ShouldNotBeNull();
            mostFavoritedMovie.Languages!.Count.ShouldBe(1);
            mostFavoritedMovie.Languages!.ShouldBe(["en"], Case.Sensitive);

            mostFavoritedMovie!.AvailableTranslations.ShouldNotBeNull();
            mostFavoritedMovie!.AvailableTranslations!.Count.ShouldBe(34);
            mostFavoritedMovie!.AvailableTranslations!.ShouldBe([
                "ar", "bg", "cs", "da", "de", "el", "en", "es", "fa", "fi", "fr", "he", "hr", "hu", "id", "it",
                "ja", "ka", "ko", "lt", "nl", "pl", "pt", "ro", "ru", "sk", "sl", "sr", "sv", "th", "tr", "uk",
                "vi", "zh"
            ], Case.Sensitive);

            mostFavoritedMovie.Genres.ShouldNotBeNull();
            mostFavoritedMovie.Genres!.Count.ShouldBe(3);
            mostFavoritedMovie.Genres!.ShouldBe([
                "horror", "science-fiction", "thriller"
            ], Case.Sensitive);

            mostFavoritedMovie.Certification.ShouldBe("PG-13");
        }
    }
}

namespace TraktNET.Json.Movies
{
    public sealed class TraktTrendingMovieTests
    {
        [Fact]
        public void TestTraktTrendingMovieConstructor()
        {
            var trendingMovie = new TraktTrendingMovie();

            trendingMovie.Watchers.ShouldBeNull();
            trendingMovie.Title.ShouldBeNull();
            trendingMovie.Year.ShouldBeNull();
            trendingMovie.IDs.ShouldBeNull();
            trendingMovie.Tagline.ShouldBeNull();
            trendingMovie.Overview.ShouldBeNull();
            trendingMovie.Released.ShouldBeNull();
            trendingMovie.Runtime.ShouldBeNull();
            trendingMovie.Country.ShouldBeNull();
            trendingMovie.Trailer.ShouldBeNull();
            trendingMovie.Homepage.ShouldBeNull();
            trendingMovie.Status.ShouldBeNull();
            trendingMovie.Rating.ShouldBeNull();
            trendingMovie.Votes.ShouldBeNull();
            trendingMovie.CommentCount.ShouldBeNull();
            trendingMovie.UpdatedAt.ShouldBeNull();
            trendingMovie.Language.ShouldBeNull();
            trendingMovie.Languages.ShouldBeNull();
            trendingMovie.AvailableTranslations.ShouldBeNull();
            trendingMovie.Genres.ShouldBeNull();
            trendingMovie.Certification.ShouldBeNull();

            trendingMovie.ToString().ShouldBeEmpty();
        }

        [Fact]
        public async Task TestTraktTrendingMovieFromJsonMinimal()
        {
            TraktTrendingMovie? trendingMovie = await TraktTestUtility.DeserializeJsonAsync<TraktTrendingMovie>("Movies\\trendingmovie_minimal.json");

            trendingMovie.ShouldNotBeNull();

            trendingMovie!.Watchers.ShouldBe(58U);

            trendingMovie!.Title.ShouldBe("Deadpool & Wolverine");
            trendingMovie!.Year.ShouldBe(2024U);

            trendingMovie!.IDs!.Trakt.ShouldBe(395672U);
            trendingMovie!.IDs!.Slug.ShouldBe("deadpool-wolverine-2024");
            trendingMovie!.IDs!.IMDB.ShouldBe("tt6263850");
            trendingMovie!.IDs!.TMDB.ShouldBe(533535U);
            trendingMovie!.IDs!.HasAnyID.ShouldBe(true);
            trendingMovie!.IDs!.BestID.ShouldBe("deadpool-wolverine-2024");

            trendingMovie!.ToString().ShouldBe("Deadpool & Wolverine (2024)");
        }

        [Fact]
        public async Task TestTraktTrendingMovieFromJson()
        {
            TraktTrendingMovie? trendingMovie = await TraktTestUtility.DeserializeJsonAsync<TraktTrendingMovie>("Movies\\trendingmovie.json");

            trendingMovie.ShouldNotBeNull();

            trendingMovie!.Watchers.ShouldBe(58U);

            trendingMovie!.Title.ShouldBe("Deadpool & Wolverine");
            trendingMovie!.Year.ShouldBe(2024U);

            trendingMovie!.IDs!.Trakt.ShouldBe(395672U);
            trendingMovie!.IDs!.Slug.ShouldBe("deadpool-wolverine-2024");
            trendingMovie!.IDs!.IMDB.ShouldBe("tt6263850");
            trendingMovie!.IDs!.TMDB.ShouldBe(533535U);
            trendingMovie!.IDs!.HasAnyID.ShouldBe(true);
            trendingMovie!.IDs!.BestID.ShouldBe("deadpool-wolverine-2024");

            trendingMovie!.ToString().ShouldBe("Deadpool & Wolverine (2024)");

            trendingMovie!.Tagline.ShouldBe("Come together.");

            trendingMovie!.Overview.ShouldBe("A listless Wade Wilson toils away in civilian life with his days as the morally "
                + "flexible mercenary, Deadpool, behind him.");

#if NET7_0_OR_GREATER
            trendingMovie!.Released.ShouldBe(TestUtility.ParseDate("2024-07-26"));
#else
            trendingMovie!.Released.ShouldBe(TestUtility.ParseUTCDateTime("2024-07-26T00:00:00.000Z"));
#endif
            trendingMovie!.Runtime.ShouldBe(128U);
            trendingMovie!.Country.ShouldBe("us");
            trendingMovie!.Trailer.ShouldBe("https://youtube.com/watch?v=Idh8n5XuYIA");
            trendingMovie!.Homepage.ShouldBe("http://www.marvel.com/movies/deadpool-and-wolverine");
            trendingMovie!.Status.ShouldBe(TraktMovieStatus.Released);
            trendingMovie!.Rating.ShouldBe(8.244876693296284f);
            trendingMovie!.Votes.ShouldBe(5758U);
            trendingMovie!.CommentCount.ShouldBe(159U);
            trendingMovie!.UpdatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2024-08-07T08:05:37.000Z"));
            trendingMovie!.Language.ShouldBe("en");
            trendingMovie!.Languages.ShouldNotBeNull();
            trendingMovie!.Languages!.Count.ShouldBe(1);
            trendingMovie!.Languages!.ShouldBe(["en"], Case.Sensitive);

            trendingMovie!.AvailableTranslations.ShouldNotBeNull();
            trendingMovie!.AvailableTranslations!.Count.ShouldBe(31);
            trendingMovie!.AvailableTranslations!.ShouldBe([
                "ar", "bg", "cs", "de", "el", "en", "es", "fa", "fr", "he", "hu", "id", "it", "ja", "ka", "kk",
                "ko", "lt", "nl", "pl", "pt", "ru", "sk", "sl", "sr", "sv", "th", "tr", "uk", "vi", "zh"
            ], Case.Sensitive);

            trendingMovie!.Genres.ShouldNotBeNull();
            trendingMovie!.Genres!.Count.ShouldBe(4);
            trendingMovie!.Genres!.ShouldBe([
                "comedy", "superhero", "science-fiction", "action"
            ], Case.Sensitive);

            trendingMovie!.Certification.ShouldBe("R");
        }

        [Fact]
        public async Task TestTraktTrendingMoviesFromJsonMinimal()
        {
            IReadOnlyList<TraktTrendingMovie>? trendingMovies = await TraktTestUtility.DeserializeJsonListAsync<TraktTrendingMovie>("Movies\\trendingmovies_minimal.json");

            trendingMovies.ShouldNotBeNull();
            trendingMovies!.Count.ShouldBe(2);

            TraktTrendingMovie trendingMovie = trendingMovies![0];

            trendingMovie.ShouldNotBeNull();

            trendingMovie.Watchers.ShouldBe(58U);

            trendingMovie.Title.ShouldBe("Deadpool & Wolverine");
            trendingMovie.Year.ShouldBe(2024U);

            trendingMovie.IDs!.Trakt.ShouldBe(395672U);
            trendingMovie.IDs!.Slug.ShouldBe("deadpool-wolverine-2024");
            trendingMovie.IDs!.IMDB.ShouldBe("tt6263850");
            trendingMovie.IDs!.TMDB.ShouldBe(533535U);
            trendingMovie.IDs!.HasAnyID.ShouldBe(true);
            trendingMovie.IDs!.BestID.ShouldBe("deadpool-wolverine-2024");

            trendingMovie.ToString().ShouldBe("Deadpool & Wolverine (2024)");

            // --------------------------------------------------------------------------------------------

            trendingMovie = trendingMovies![1];

            trendingMovie.ShouldNotBeNull();

            trendingMovie.Watchers.ShouldBe(43U);

            trendingMovie.Title.ShouldBe("Kingdom of the Planet of the Apes");
            trendingMovie.Year.ShouldBe(2024U);

            trendingMovie.IDs!.Trakt.ShouldBe(488280U);
            trendingMovie.IDs!.Slug.ShouldBe("kingdom-of-the-planet-of-the-apes-2024");
            trendingMovie.IDs!.IMDB.ShouldBe("tt11389872");
            trendingMovie.IDs!.TMDB.ShouldBe(653346U);
            trendingMovie.IDs!.HasAnyID.ShouldBe(true);
            trendingMovie.IDs!.BestID.ShouldBe("kingdom-of-the-planet-of-the-apes-2024");

            trendingMovie.ToString().ShouldBe("Kingdom of the Planet of the Apes (2024)");
        }

        [Fact]
        public async Task TestTraktTrendingMoviesFromJson()
        {
            IReadOnlyList<TraktTrendingMovie>? trendingMovies = await TraktTestUtility.DeserializeJsonListAsync<TraktTrendingMovie>("Movies\\trendingmovies.json");

            trendingMovies.ShouldNotBeNull();
            trendingMovies!.Count.ShouldBe(2);

            TraktTrendingMovie trendingMovie = trendingMovies![0];

            trendingMovie.ShouldNotBeNull();

            trendingMovie.Watchers.ShouldBe(58U);

            trendingMovie.Title.ShouldBe("Deadpool & Wolverine");
            trendingMovie.Year.ShouldBe(2024U);

            trendingMovie.IDs!.Trakt.ShouldBe(395672U);
            trendingMovie.IDs!.Slug.ShouldBe("deadpool-wolverine-2024");
            trendingMovie.IDs!.IMDB.ShouldBe("tt6263850");
            trendingMovie.IDs!.TMDB.ShouldBe(533535U);
            trendingMovie.IDs!.HasAnyID.ShouldBe(true);
            trendingMovie.IDs!.BestID.ShouldBe("deadpool-wolverine-2024");

            trendingMovie.ToString().ShouldBe("Deadpool & Wolverine (2024)");

            trendingMovie.Tagline.ShouldBe("Come together.");

            trendingMovie.Overview.ShouldBe("A listless Wade Wilson toils away in civilian life with his days as the morally "
                + "flexible mercenary, Deadpool, behind him.");

#if NET7_0_OR_GREATER
            trendingMovie!.Released.ShouldBe(TestUtility.ParseDate("2024-07-26"));
#else
            trendingMovie!.Released.ShouldBe(TestUtility.ParseUTCDateTime("2024-07-26T00:00:00.000Z"));
#endif
            trendingMovie.Runtime.ShouldBe(128U);
            trendingMovie.Country.ShouldBe("us");
            trendingMovie.Trailer.ShouldBe("https://youtube.com/watch?v=Idh8n5XuYIA");
            trendingMovie.Homepage.ShouldBe("http://www.marvel.com/movies/deadpool-and-wolverine");
            trendingMovie.Status.ShouldBe(TraktMovieStatus.Released);
            trendingMovie.Rating.ShouldBe(8.244876693296284f);
            trendingMovie.Votes.ShouldBe(5758U);
            trendingMovie.CommentCount.ShouldBe(159U);
            trendingMovie.UpdatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2024-08-07T08:05:37.000Z"));
            trendingMovie.Language.ShouldBe("en");
            trendingMovie.Languages.ShouldNotBeNull();
            trendingMovie.Languages!.Count.ShouldBe(1);
            trendingMovie.Languages!.ShouldBe(["en"], Case.Sensitive);

            trendingMovie.AvailableTranslations.ShouldNotBeNull();
            trendingMovie.AvailableTranslations!.Count.ShouldBe(31);
            trendingMovie.AvailableTranslations!.ShouldBe([
                "ar", "bg", "cs", "de", "el", "en", "es", "fa", "fr", "he", "hu", "id", "it", "ja", "ka", "kk",
                "ko", "lt", "nl", "pl", "pt", "ru", "sk", "sl", "sr", "sv", "th", "tr", "uk", "vi", "zh"
            ], Case.Sensitive);

            trendingMovie.Genres.ShouldNotBeNull();
            trendingMovie.Genres!.Count.ShouldBe(4);
            trendingMovie.Genres!.ShouldBe([
                "comedy", "superhero", "science-fiction", "action"
            ], Case.Sensitive);

            trendingMovie.Certification.ShouldBe("R");

            // --------------------------------------------------------------------------------------------

            trendingMovie = trendingMovies![1];

            trendingMovie.ShouldNotBeNull();

            trendingMovie.Watchers.ShouldBe(43U);

            trendingMovie.Title.ShouldBe("Kingdom of the Planet of the Apes");
            trendingMovie.Year.ShouldBe(2024U);

            trendingMovie.IDs!.Trakt.ShouldBe(488280U);
            trendingMovie.IDs!.Slug.ShouldBe("kingdom-of-the-planet-of-the-apes-2024");
            trendingMovie.IDs!.IMDB.ShouldBe("tt11389872");
            trendingMovie.IDs!.TMDB.ShouldBe(653346U);
            trendingMovie.IDs!.HasAnyID.ShouldBe(true);
            trendingMovie.IDs!.BestID.ShouldBe("kingdom-of-the-planet-of-the-apes-2024");

            trendingMovie.ToString().ShouldBe("Kingdom of the Planet of the Apes (2024)");

            trendingMovie.Tagline.ShouldBe("No one can stop the reign.");

            trendingMovie.Overview.ShouldBe("Several generations following Caesar's reign, apes – now the dominant species – "
                + "live harmoniously while humans have been reduced to living in the shadows.");

#if NET7_0_OR_GREATER
            trendingMovie!.Released.ShouldBe(TestUtility.ParseDate("2024-05-10"));
#else
            trendingMovie!.Released.ShouldBe(TestUtility.ParseUTCDateTime("2024-05-10T00:00:00.000Z"));
#endif
            trendingMovie.Runtime.ShouldBe(145U);
            trendingMovie.Country.ShouldBe("us");
            trendingMovie.Trailer.ShouldBe("https://youtube.com/watch?v=Tg1FesR8X90");
            trendingMovie.Homepage.ShouldBe("http://www.20thcenturystudios.com/movies/kingdom-of-the-planet-of-the-apes");
            trendingMovie.Status.ShouldBe(TraktMovieStatus.Released);
            trendingMovie.Rating.ShouldBe(7.188150289017341f);
            trendingMovie.Votes.ShouldBe(6920U);
            trendingMovie.CommentCount.ShouldBe(79U);
            trendingMovie.UpdatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2024-08-07T08:05:40.000Z"));
            trendingMovie.Language.ShouldBe("en");
            trendingMovie.Languages.ShouldNotBeNull();
            trendingMovie.Languages!.Count.ShouldBe(1);
            trendingMovie.Languages!.ShouldBe(["en"], Case.Sensitive);

            trendingMovie!.AvailableTranslations.ShouldNotBeNull();
            trendingMovie!.AvailableTranslations!.Count.ShouldBe(36);
            trendingMovie!.AvailableTranslations!.ShouldBe([
                "ar", "az", "bg", "ca", "cs", "da", "de", "el", "en", "es", "fa", "fi", "fr", "he", "hr", "hu",
                "id", "it", "ja", "ka", "ko", "lt", "nl", "pl", "pt", "ro", "ru", "sk", "sl", "sr", "sv", "th",
                "tr", "uk", "vi", "zh"
            ], Case.Sensitive);

            trendingMovie.Genres.ShouldNotBeNull();
            trendingMovie.Genres!.Count.ShouldBe(3);
            trendingMovie.Genres!.ShouldBe([
                "action", "science-fiction", "adventure"
            ], Case.Sensitive);

            trendingMovie.Certification.ShouldBe("PG-13");
        }
    }
}

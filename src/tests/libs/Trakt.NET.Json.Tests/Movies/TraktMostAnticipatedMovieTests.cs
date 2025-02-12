namespace TraktNET.Json.Movies
{
    public sealed class TraktMostAnticipatedMovieTests
    {
        [Fact]
        public void TestTraktMostAnticipatedMovieConstructor()
        {
            var mostAnticipatedMovie = new TraktMostAnticipatedMovie();

            mostAnticipatedMovie.ListCount.ShouldBeNull();
            mostAnticipatedMovie.Title.ShouldBeNull();
            mostAnticipatedMovie.Year.ShouldBeNull();
            mostAnticipatedMovie.IDs.ShouldBeNull();
            mostAnticipatedMovie.Tagline.ShouldBeNull();
            mostAnticipatedMovie.Overview.ShouldBeNull();
            mostAnticipatedMovie.Released.ShouldBeNull();
            mostAnticipatedMovie.Runtime.ShouldBeNull();
            mostAnticipatedMovie.Country.ShouldBeNull();
            mostAnticipatedMovie.Trailer.ShouldBeNull();
            mostAnticipatedMovie.Homepage.ShouldBeNull();
            mostAnticipatedMovie.Status.ShouldBeNull();
            mostAnticipatedMovie.Rating.ShouldBeNull();
            mostAnticipatedMovie.Votes.ShouldBeNull();
            mostAnticipatedMovie.CommentCount.ShouldBeNull();
            mostAnticipatedMovie.UpdatedAt.ShouldBeNull();
            mostAnticipatedMovie.Language.ShouldBeNull();
            mostAnticipatedMovie.Languages.ShouldBeNull();
            mostAnticipatedMovie.AvailableTranslations.ShouldBeNull();
            mostAnticipatedMovie.Genres.ShouldBeNull();
            mostAnticipatedMovie.Certification.ShouldBeNull();

            mostAnticipatedMovie.ToString().ShouldBeEmpty();
        }

        [Fact]
        public async Task TestTraktMostAnticipatedMovieFromJsonMinimal()
        {
            TraktMostAnticipatedMovie? mostAnticipatedMovie = await TraktTestUtility.DeserializeJsonAsync<TraktMostAnticipatedMovie>("Movies\\mostanticipatedmovie_minimal.json");

            mostAnticipatedMovie.ShouldNotBeNull();

            mostAnticipatedMovie!.ListCount.ShouldBe(33464U);

            mostAnticipatedMovie!.Title.ShouldBe("Avatar: Fire and Ash");
            mostAnticipatedMovie!.Year.ShouldBe(2025U);

            mostAnticipatedMovie!.IDs!.Trakt.ShouldBe(62544U);
            mostAnticipatedMovie!.IDs!.Slug.ShouldBe("avatar-fire-and-ash-2025");
            mostAnticipatedMovie!.IDs!.IMDB.ShouldBe("tt1757678");
            mostAnticipatedMovie!.IDs!.TMDB.ShouldBe(83533U);
            mostAnticipatedMovie!.IDs!.HasAnyID.ShouldBe(true);
            mostAnticipatedMovie!.IDs!.BestID.ShouldBe("avatar-fire-and-ash-2025");

            mostAnticipatedMovie!.ToString().ShouldBe("Avatar: Fire and Ash (2025)");
        }

        [Fact]
        public async Task TestTraktMostAnticipatedMovieFromJson()
        {
            TraktMostAnticipatedMovie? mostAnticipatedMovie = await TraktTestUtility.DeserializeJsonAsync<TraktMostAnticipatedMovie>("Movies\\mostanticipatedmovie.json");

            mostAnticipatedMovie.ShouldNotBeNull();

            mostAnticipatedMovie!.ListCount.ShouldBe(33464U);

            mostAnticipatedMovie!.Title.ShouldBe("Avatar: Fire and Ash");
            mostAnticipatedMovie!.Year.ShouldBe(2025U);

            mostAnticipatedMovie!.IDs!.Trakt.ShouldBe(62544U);
            mostAnticipatedMovie!.IDs!.Slug.ShouldBe("avatar-fire-and-ash-2025");
            mostAnticipatedMovie!.IDs!.IMDB.ShouldBe("tt1757678");
            mostAnticipatedMovie!.IDs!.TMDB.ShouldBe(83533U);
            mostAnticipatedMovie!.IDs!.HasAnyID.ShouldBe(true);
            mostAnticipatedMovie!.IDs!.BestID.ShouldBe("avatar-fire-and-ash-2025");

            mostAnticipatedMovie!.ToString().ShouldBe("Avatar: Fire and Ash (2025)");

            mostAnticipatedMovie!.Tagline.ShouldBeEmpty();

            mostAnticipatedMovie!.Overview.ShouldBe("In the wake of the devastating war against the RDA and the loss of their eldest son, Jake Sully and Neytiri "
                + "face a new threat on Pandora.");

#if NET7_0_OR_GREATER
            mostAnticipatedMovie!.Released.ShouldBe(TestUtility.ParseDate("2025-12-19"));
#else
            mostAnticipatedMovie!.Released.ShouldBe(TestUtility.ParseUTCDateTime("2025-12-19T00:00:00.000Z"));
#endif
            mostAnticipatedMovie!.Runtime.ShouldBe(1U);
            mostAnticipatedMovie!.Country.ShouldBe("us");
            mostAnticipatedMovie!.Trailer.ShouldBeNull();
            mostAnticipatedMovie!.Homepage.ShouldBe("http://www.avatar.com/movies");
            mostAnticipatedMovie!.Status.ShouldBe(TraktMovieStatus.PostProduction);
            mostAnticipatedMovie!.Rating.ShouldBe(7.05102f);
            mostAnticipatedMovie!.Votes.ShouldBe(98U);
            mostAnticipatedMovie!.CommentCount.ShouldBe(2U);
            mostAnticipatedMovie!.UpdatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2024-09-15T08:05:18.000Z"));
            mostAnticipatedMovie!.Language.ShouldBe("en");
            mostAnticipatedMovie!.Languages.ShouldNotBeNull();
            mostAnticipatedMovie!.Languages!.Count.ShouldBe(1);
            mostAnticipatedMovie!.Languages!.ShouldBe(["en"], Case.Sensitive);

            mostAnticipatedMovie!.AvailableTranslations.ShouldNotBeNull();
            mostAnticipatedMovie!.AvailableTranslations!.Count.ShouldBe(13);
            mostAnticipatedMovie!.AvailableTranslations!.ShouldBe([
                "bg", "en", "es", "fr", "he", "ka", "ko", "pl", "pt", "ru", "uk", "vi", "zh"
            ], Case.Sensitive);

            mostAnticipatedMovie!.Genres.ShouldNotBeNull();
            mostAnticipatedMovie!.Genres!.Count.ShouldBe(3);
            mostAnticipatedMovie!.Genres!.ShouldBe([
                "adventure", "science-fiction", "fantasy"
            ], Case.Sensitive);

            mostAnticipatedMovie!.Certification.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktMostAnticipatedMoviesFromJsonMinimal()
        {
            IReadOnlyList<TraktMostAnticipatedMovie>? mostAnticipatedMovies = await TraktTestUtility.DeserializeJsonListAsync<TraktMostAnticipatedMovie>("Movies\\mostanticipatedmovies_minimal.json");

            mostAnticipatedMovies.ShouldNotBeNull();
            mostAnticipatedMovies!.Count.ShouldBe(2);

            TraktMostAnticipatedMovie mostAnticipatedMovie = mostAnticipatedMovies![0];

            mostAnticipatedMovie.ShouldNotBeNull();

            mostAnticipatedMovie.ListCount.ShouldBe(33464U);

            mostAnticipatedMovie.Title.ShouldBe("Avatar: Fire and Ash");
            mostAnticipatedMovie.Year.ShouldBe(2025U);

            mostAnticipatedMovie.IDs!.Trakt.ShouldBe(62544U);
            mostAnticipatedMovie.IDs!.Slug.ShouldBe("avatar-fire-and-ash-2025");
            mostAnticipatedMovie.IDs!.IMDB.ShouldBe("tt1757678");
            mostAnticipatedMovie.IDs!.TMDB.ShouldBe(83533U);
            mostAnticipatedMovie.IDs!.HasAnyID.ShouldBe(true);
            mostAnticipatedMovie.IDs!.BestID.ShouldBe("avatar-fire-and-ash-2025");

            mostAnticipatedMovie.ToString().ShouldBe("Avatar: Fire and Ash (2025)");

            // --------------------------------------------------------------------------------------------

            mostAnticipatedMovie = mostAnticipatedMovies![1];

            mostAnticipatedMovie.ShouldNotBeNull();

            mostAnticipatedMovie.ListCount.ShouldBe(23502U);

            mostAnticipatedMovie.Title.ShouldBe("Blade");
            mostAnticipatedMovie.Year.ShouldBe(2025U);

            mostAnticipatedMovie.IDs!.Trakt.ShouldBe(460195U);
            mostAnticipatedMovie.IDs!.Slug.ShouldBe("blade-2025");
            mostAnticipatedMovie.IDs!.IMDB.ShouldBe("tt10671440");
            mostAnticipatedMovie.IDs!.TMDB.ShouldBe(617127U);
            mostAnticipatedMovie.IDs!.HasAnyID.ShouldBe(true);
            mostAnticipatedMovie.IDs!.BestID.ShouldBe("blade-2025");

            mostAnticipatedMovie.ToString().ShouldBe("Blade (2025)");
        }

        [Fact]
        public async Task TestTraktMostAnticipatedMoviesFromJson()
        {
            IReadOnlyList<TraktMostAnticipatedMovie>? mostAnticipatedMovies = await TraktTestUtility.DeserializeJsonListAsync<TraktMostAnticipatedMovie>("Movies\\mostanticipatedmovies.json");

            mostAnticipatedMovies.ShouldNotBeNull();
            mostAnticipatedMovies!.Count.ShouldBe(2);

            TraktMostAnticipatedMovie mostAnticipatedMovie = mostAnticipatedMovies![0];

            mostAnticipatedMovie.ShouldNotBeNull();

            mostAnticipatedMovie.ListCount.ShouldBe(33464U);

            mostAnticipatedMovie.Title.ShouldBe("Avatar: Fire and Ash");
            mostAnticipatedMovie.Year.ShouldBe(2025U);

            mostAnticipatedMovie.IDs!.Trakt.ShouldBe(62544U);
            mostAnticipatedMovie.IDs!.Slug.ShouldBe("avatar-fire-and-ash-2025");
            mostAnticipatedMovie.IDs!.IMDB.ShouldBe("tt1757678");
            mostAnticipatedMovie.IDs!.TMDB.ShouldBe(83533U);
            mostAnticipatedMovie.IDs!.HasAnyID.ShouldBe(true);
            mostAnticipatedMovie.IDs!.BestID.ShouldBe("avatar-fire-and-ash-2025");

            mostAnticipatedMovie.ToString().ShouldBe("Avatar: Fire and Ash (2025)");

            mostAnticipatedMovie.Tagline.ShouldBeEmpty();

            mostAnticipatedMovie.Overview.ShouldBe("In the wake of the devastating war against the RDA and the loss of their eldest son, Jake Sully and Neytiri "
                + "face a new threat on Pandora.");

#if NET7_0_OR_GREATER
            mostAnticipatedMovie.Released.ShouldBe(TestUtility.ParseDate("2025-12-19"));
#else
            mostAnticipatedMovie.Released.ShouldBe(TestUtility.ParseUTCDateTime("2025-12-19T00:00:00.000Z"));
#endif
            mostAnticipatedMovie.Runtime.ShouldBe(1U);
            mostAnticipatedMovie.Country.ShouldBe("us");
            mostAnticipatedMovie.Trailer.ShouldBeNull();
            mostAnticipatedMovie.Homepage.ShouldBe("http://www.avatar.com/movies");
            mostAnticipatedMovie.Status.ShouldBe(TraktMovieStatus.PostProduction);
            mostAnticipatedMovie.Rating.ShouldBe(7.05102f);
            mostAnticipatedMovie.Votes.ShouldBe(98U);
            mostAnticipatedMovie.CommentCount.ShouldBe(2U);
            mostAnticipatedMovie.UpdatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2024-09-15T08:05:18.000Z"));
            mostAnticipatedMovie.Language.ShouldBe("en");
            mostAnticipatedMovie.Languages.ShouldNotBeNull();
            mostAnticipatedMovie.Languages!.Count.ShouldBe(1);
            mostAnticipatedMovie.Languages!.ShouldBe(["en"], Case.Sensitive);

            mostAnticipatedMovie.AvailableTranslations.ShouldNotBeNull();
            mostAnticipatedMovie.AvailableTranslations!.Count.ShouldBe(13);
            mostAnticipatedMovie.AvailableTranslations!.ShouldBe([
                "bg", "en", "es", "fr", "he", "ka", "ko", "pl", "pt", "ru", "uk", "vi", "zh"
            ], Case.Sensitive);

            mostAnticipatedMovie.Genres.ShouldNotBeNull();
            mostAnticipatedMovie.Genres!.Count.ShouldBe(3);
            mostAnticipatedMovie.Genres!.ShouldBe([
                "adventure", "science-fiction", "fantasy"
            ], Case.Sensitive);

            mostAnticipatedMovie.Certification.ShouldBeNull();

            // --------------------------------------------------------------------------------------------

            mostAnticipatedMovie = mostAnticipatedMovies![1];

            mostAnticipatedMovie.ShouldNotBeNull();

            mostAnticipatedMovie.ListCount.ShouldBe(23502U);

            mostAnticipatedMovie.Title.ShouldBe("Blade");
            mostAnticipatedMovie.Year.ShouldBe(2025U);

            mostAnticipatedMovie.IDs!.Trakt.ShouldBe(460195U);
            mostAnticipatedMovie.IDs!.Slug.ShouldBe("blade-2025");
            mostAnticipatedMovie.IDs!.IMDB.ShouldBe("tt10671440");
            mostAnticipatedMovie.IDs!.TMDB.ShouldBe(617127U);
            mostAnticipatedMovie.IDs!.HasAnyID.ShouldBe(true);
            mostAnticipatedMovie.IDs!.BestID.ShouldBe("blade-2025");

            mostAnticipatedMovie.ToString().ShouldBe("Blade (2025)");

            mostAnticipatedMovie.Tagline.ShouldBeEmpty();

            mostAnticipatedMovie.Overview.ShouldBe("A film set in the Marvel Cinematic Universe (MCU) based on the Marvel Comics character of the same name.");

#if NET7_0_OR_GREATER
            mostAnticipatedMovie!.Released.ShouldBe(TestUtility.ParseDate("2025-11-07"));
#else
            mostAnticipatedMovie!.Released.ShouldBe(TestUtility.ParseUTCDateTime("2025-11-07T00:00:00.000Z"));
#endif
            mostAnticipatedMovie.Runtime.ShouldBe(90U);
            mostAnticipatedMovie.Country.ShouldBe("us");
            mostAnticipatedMovie.Trailer.ShouldBeNull();
            mostAnticipatedMovie.Homepage.ShouldBe("http://www.marvel.com/movies/blade");
            mostAnticipatedMovie.Status.ShouldBe(TraktMovieStatus.Planned);
            mostAnticipatedMovie.Rating.ShouldBe(7.05556f);
            mostAnticipatedMovie.Votes.ShouldBe(36U);
            mostAnticipatedMovie.CommentCount.ShouldBe(10U);
            mostAnticipatedMovie.UpdatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2024-09-16T08:06:34.000Z"));
            mostAnticipatedMovie.Language.ShouldBe("en");
            mostAnticipatedMovie.Languages.ShouldNotBeNull();
            mostAnticipatedMovie.Languages!.Count.ShouldBe(1);
            mostAnticipatedMovie.Languages!.ShouldBe(["en"], Case.Sensitive);

            mostAnticipatedMovie.AvailableTranslations.ShouldNotBeNull();
            mostAnticipatedMovie.AvailableTranslations!.Count.ShouldBe(13);
            mostAnticipatedMovie.AvailableTranslations!.ShouldBe([
                "bg", "en", "es", "fa", "he", "hu", "ka", "ko", "pt", "ru", "th", "uk", "zh"
            ], Case.Sensitive);

            mostAnticipatedMovie.Genres.ShouldNotBeNull();
            mostAnticipatedMovie.Genres!.Count.ShouldBe(2);
            mostAnticipatedMovie.Genres!.ShouldBe([
                "superhero", "fantasy"
            ], Case.Sensitive);

            mostAnticipatedMovie.Certification.ShouldBeNull();
        }
    }
}

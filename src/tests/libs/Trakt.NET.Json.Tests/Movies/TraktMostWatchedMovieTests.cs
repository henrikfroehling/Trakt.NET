namespace TraktNET.Json.Movies
{
    public sealed class TraktMostWatchedMovieTests
    {
        [Fact]
        public void TestTraktMostWatchedMovieConstructor()
        {
            var mostWatchedMovie = new TraktMostWatchedMovie();

            mostWatchedMovie.WatcherCount.ShouldBeNull();
            mostWatchedMovie.PlayCount.ShouldBeNull();
            mostWatchedMovie.CollectedCount.ShouldBeNull();
            mostWatchedMovie.Title.ShouldBeNull();
            mostWatchedMovie.Year.ShouldBeNull();
            mostWatchedMovie.IDs.ShouldBeNull();
            mostWatchedMovie.Tagline.ShouldBeNull();
            mostWatchedMovie.Overview.ShouldBeNull();
            mostWatchedMovie.Released.ShouldBeNull();
            mostWatchedMovie.Runtime.ShouldBeNull();
            mostWatchedMovie.Country.ShouldBeNull();
            mostWatchedMovie.Trailer.ShouldBeNull();
            mostWatchedMovie.Homepage.ShouldBeNull();
            mostWatchedMovie.Status.ShouldBeNull();
            mostWatchedMovie.Rating.ShouldBeNull();
            mostWatchedMovie.Votes.ShouldBeNull();
            mostWatchedMovie.CommentCount.ShouldBeNull();
            mostWatchedMovie.UpdatedAt.ShouldBeNull();
            mostWatchedMovie.Language.ShouldBeNull();
            mostWatchedMovie.Languages.ShouldBeNull();
            mostWatchedMovie.AvailableTranslations.ShouldBeNull();
            mostWatchedMovie.Genres.ShouldBeNull();
            mostWatchedMovie.Certification.ShouldBeNull();

            mostWatchedMovie.ToString().ShouldBeEmpty();
        }

        [Fact]
        public async Task TestTraktMostWatchedMovieFromJsonMinimal()
        {
            TraktMostWatchedMovie? mostWatchedMovie = await TraktTestUtility.DeserializeJsonAsync<TraktMostWatchedMovie>("Movies\\mostpwcmovie_minimal.json");

            mostWatchedMovie.ShouldNotBeNull();

            mostWatchedMovie!.WatcherCount.ShouldBe(10606U);
            mostWatchedMovie!.PlayCount.ShouldBe(14142U);
            mostWatchedMovie!.CollectedCount.ShouldBe(107U);

            mostWatchedMovie!.Title.ShouldBe("The Hunt for Red October");
            mostWatchedMovie!.Year.ShouldBe(1990U);

            mostWatchedMovie!.IDs!.Trakt.ShouldBe(1111U);
            mostWatchedMovie!.IDs!.Slug.ShouldBe("the-hunt-for-red-october-1990");
            mostWatchedMovie!.IDs!.IMDB.ShouldBe("tt0099810");
            mostWatchedMovie!.IDs!.TMDB.ShouldBe(1669U);
            mostWatchedMovie!.IDs!.HasAnyID.ShouldBe(true);
            mostWatchedMovie!.IDs!.BestID.ShouldBe("the-hunt-for-red-october-1990");

            mostWatchedMovie!.ToString().ShouldBe("The Hunt for Red October (1990)");
        }

        [Fact]
        public async Task TestTraktMostWatchedMovieFromJson()
        {
            TraktMostWatchedMovie? mostWatchedMovie = await TraktTestUtility.DeserializeJsonAsync<TraktMostWatchedMovie>("Movies\\mostpwcmovie.json");

            mostWatchedMovie.ShouldNotBeNull();

            mostWatchedMovie!.WatcherCount.ShouldBe(10606U);
            mostWatchedMovie!.PlayCount.ShouldBe(14142U);
            mostWatchedMovie!.CollectedCount.ShouldBe(107U);

            mostWatchedMovie!.Title.ShouldBe("The Hunt for Red October");
            mostWatchedMovie!.Year.ShouldBe(1990U);

            mostWatchedMovie!.IDs!.Trakt.ShouldBe(1111U);
            mostWatchedMovie!.IDs!.Slug.ShouldBe("the-hunt-for-red-october-1990");
            mostWatchedMovie!.IDs!.IMDB.ShouldBe("tt0099810");
            mostWatchedMovie!.IDs!.TMDB.ShouldBe(1669U);
            mostWatchedMovie!.IDs!.HasAnyID.ShouldBe(true);
            mostWatchedMovie!.IDs!.BestID.ShouldBe("the-hunt-for-red-october-1990");

            mostWatchedMovie!.ToString().ShouldBe("The Hunt for Red October (1990)");

            mostWatchedMovie!.Tagline.ShouldBe("Invisible. Silent. Stolen.");

            mostWatchedMovie!.Overview.ShouldBe("A new technologically-superior Soviet nuclear sub, the Red October, is heading for the U.S. "
                + "coast under the command of Captain Marko Ramius.");

#if NET7_0_OR_GREATER
            mostWatchedMovie!.Released.ShouldBe(TestUtility.ParseDate("1990-03-02"));
#else
            mostWatchedMovie!.Released.ShouldBe(TestUtility.ParseUTCDateTime("1990-03-02T00:00:00.000Z"));
#endif
            mostWatchedMovie!.Runtime.ShouldBe(135U);
            mostWatchedMovie!.Country.ShouldBe("us");
            mostWatchedMovie!.Trailer.ShouldBe("https://youtube.com/watch?v=NSiAsQMBSRA");
            mostWatchedMovie!.Homepage.ShouldBe("http://www.paramount.com/movies/hunt-red-october");
            mostWatchedMovie!.Status.ShouldBe(TraktMovieStatus.Released);
            mostWatchedMovie!.Rating.ShouldBe(7.9446390086206895f);
            mostWatchedMovie!.Votes.ShouldBe(7424U);
            mostWatchedMovie!.CommentCount.ShouldBe(22U);
            mostWatchedMovie!.UpdatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2024-09-15T08:06:36.000Z"));
            mostWatchedMovie!.Language.ShouldBe("en");
            mostWatchedMovie!.Languages.ShouldNotBeNull();
            mostWatchedMovie!.Languages!.Count.ShouldBe(2);
            mostWatchedMovie!.Languages!.ShouldBe(["en", "ru"], Case.Sensitive);

            mostWatchedMovie!.AvailableTranslations.ShouldNotBeNull();
            mostWatchedMovie!.AvailableTranslations!.Count.ShouldBe(39);
            mostWatchedMovie!.AvailableTranslations!.ShouldBe([
                "ar", "bg", "ca", "cs", "da", "de", "el", "en", "es", "et", "fa", "fi", "fr", "he", "hi", "hr",
                "hu", "id", "it", "ja", "ko", "lt", "lv", "ms", "nb", "nl", "nn", "no", "pl", "pt", "ro", "ru",
                "sk", "sv", "th", "tr", "uk", "vi", "zh"
            ], Case.Sensitive);

            mostWatchedMovie!.Genres.ShouldNotBeNull();
            mostWatchedMovie!.Genres!.Count.ShouldBe(3);
            mostWatchedMovie!.Genres!.ShouldBe([
                "action", "adventure", "thriller"
            ], Case.Sensitive);

            mostWatchedMovie!.Certification.ShouldBe("PG-13");
        }

        [Fact]
        public async Task TestTraktMostWatchedMoviesFromJsonMinimal()
        {
            IReadOnlyList<TraktMostWatchedMovie>? mostWatchedMovies = await TraktTestUtility.DeserializeJsonListAsync<TraktMostWatchedMovie>("Movies\\mostpwcmovies_minimal.json");

            mostWatchedMovies.ShouldNotBeNull();
            mostWatchedMovies!.Count.ShouldBe(2);

            TraktMostWatchedMovie mostWatchedMovie = mostWatchedMovies![0];

            mostWatchedMovie.ShouldNotBeNull();

            mostWatchedMovie.WatcherCount.ShouldBe(10606U);
            mostWatchedMovie.PlayCount.ShouldBe(14142U);
            mostWatchedMovie.CollectedCount.ShouldBe(107U);

            mostWatchedMovie.Title.ShouldBe("The Hunt for Red October");
            mostWatchedMovie.Year.ShouldBe(1990U);

            mostWatchedMovie.IDs!.Trakt.ShouldBe(1111U);
            mostWatchedMovie.IDs!.Slug.ShouldBe("the-hunt-for-red-october-1990");
            mostWatchedMovie.IDs!.IMDB.ShouldBe("tt0099810");
            mostWatchedMovie.IDs!.TMDB.ShouldBe(1669U);
            mostWatchedMovie.IDs!.HasAnyID.ShouldBe(true);
            mostWatchedMovie.IDs!.BestID.ShouldBe("the-hunt-for-red-october-1990");

            mostWatchedMovie.ToString().ShouldBe("The Hunt for Red October (1990)");

            // --------------------------------------------------------------------------------------------

            mostWatchedMovie = mostWatchedMovies![1];

            mostWatchedMovie.ShouldNotBeNull();

            mostWatchedMovie.WatcherCount.ShouldBe(9076U);
            mostWatchedMovie.PlayCount.ShouldBe(12102U);
            mostWatchedMovie.CollectedCount.ShouldBe(3533U);

            mostWatchedMovie.Title.ShouldBe("Rebel Ridge");
            mostWatchedMovie.Year.ShouldBe(2024U);

            mostWatchedMovie.IDs!.Trakt.ShouldBe(483193U);
            mostWatchedMovie.IDs!.Slug.ShouldBe("rebel-ridge-2024");
            mostWatchedMovie.IDs!.IMDB.ShouldBe("tt11301886");
            mostWatchedMovie.IDs!.TMDB.ShouldBe(646097U);
            mostWatchedMovie.IDs!.HasAnyID.ShouldBe(true);
            mostWatchedMovie.IDs!.BestID.ShouldBe("rebel-ridge-2024");

            mostWatchedMovie.ToString().ShouldBe("Rebel Ridge (2024)");
        }

        [Fact]
        public async Task TestTraktMostWatchedMoviesFromJson()
        {
            IReadOnlyList<TraktMostWatchedMovie>? mostWatchedMovies = await TraktTestUtility.DeserializeJsonListAsync<TraktMostWatchedMovie>("Movies\\mostpwcmovies.json");

            mostWatchedMovies.ShouldNotBeNull();
            mostWatchedMovies!.Count.ShouldBe(2);

            TraktMostWatchedMovie mostWatchedMovie = mostWatchedMovies![0];

            mostWatchedMovie.ShouldNotBeNull();

            mostWatchedMovie.WatcherCount.ShouldBe(10606U);
            mostWatchedMovie.PlayCount.ShouldBe(14142U);
            mostWatchedMovie.CollectedCount.ShouldBe(107U);

            mostWatchedMovie.Title.ShouldBe("The Hunt for Red October");
            mostWatchedMovie.Year.ShouldBe(1990U);

            mostWatchedMovie.IDs!.Trakt.ShouldBe(1111U);
            mostWatchedMovie.IDs!.Slug.ShouldBe("the-hunt-for-red-october-1990");
            mostWatchedMovie.IDs!.IMDB.ShouldBe("tt0099810");
            mostWatchedMovie.IDs!.TMDB.ShouldBe(1669U);
            mostWatchedMovie.IDs!.HasAnyID.ShouldBe(true);
            mostWatchedMovie.IDs!.BestID.ShouldBe("the-hunt-for-red-october-1990");

            mostWatchedMovie.ToString().ShouldBe("The Hunt for Red October (1990)");

            mostWatchedMovie.Tagline.ShouldBe("Invisible. Silent. Stolen.");

            mostWatchedMovie.Overview.ShouldBe("A new technologically-superior Soviet nuclear sub, the Red October, is heading for the U.S. "
                + "coast under the command of Captain Marko Ramius.");

#if NET7_0_OR_GREATER
            mostWatchedMovie.Released.ShouldBe(TestUtility.ParseDate("1990-03-02"));
#else
            mostWatchedMovie.Released.ShouldBe(TestUtility.ParseUTCDateTime("1990-03-02T00:00:00.000Z"));
#endif
            mostWatchedMovie.Runtime.ShouldBe(135U);
            mostWatchedMovie.Country.ShouldBe("us");
            mostWatchedMovie.Trailer.ShouldBe("https://youtube.com/watch?v=NSiAsQMBSRA");
            mostWatchedMovie.Homepage.ShouldBe("http://www.paramount.com/movies/hunt-red-october");
            mostWatchedMovie.Status.ShouldBe(TraktMovieStatus.Released);
            mostWatchedMovie.Rating.ShouldBe(7.9446390086206895f);
            mostWatchedMovie.Votes.ShouldBe(7424U);
            mostWatchedMovie.CommentCount.ShouldBe(22U);
            mostWatchedMovie.UpdatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2024-09-15T08:06:36.000Z"));
            mostWatchedMovie.Language.ShouldBe("en");
            mostWatchedMovie.Languages.ShouldNotBeNull();
            mostWatchedMovie.Languages!.Count.ShouldBe(2);
            mostWatchedMovie.Languages!.ShouldBe(["en", "ru"], Case.Sensitive);

            mostWatchedMovie!.AvailableTranslations.ShouldNotBeNull();
            mostWatchedMovie!.AvailableTranslations!.Count.ShouldBe(39);
            mostWatchedMovie!.AvailableTranslations!.ShouldBe([
                "ar", "bg", "ca", "cs", "da", "de", "el", "en", "es", "et", "fa", "fi", "fr", "he", "hi", "hr",
                "hu", "id", "it", "ja", "ko", "lt", "lv", "ms", "nb", "nl", "nn", "no", "pl", "pt", "ro", "ru",
                "sk", "sv", "th", "tr", "uk", "vi", "zh"
            ], Case.Sensitive);

            mostWatchedMovie.Genres.ShouldNotBeNull();
            mostWatchedMovie.Genres!.Count.ShouldBe(3);
            mostWatchedMovie.Genres!.ShouldBe([
                "action", "adventure", "thriller"
            ], Case.Sensitive);

            mostWatchedMovie.Certification.ShouldBe("PG-13");

            // --------------------------------------------------------------------------------------------

            mostWatchedMovie = mostWatchedMovies![1];

            mostWatchedMovie.ShouldNotBeNull();

            mostWatchedMovie.WatcherCount.ShouldBe(9076U);
            mostWatchedMovie.PlayCount.ShouldBe(12102U);
            mostWatchedMovie.CollectedCount.ShouldBe(3533U);

            mostWatchedMovie.Title.ShouldBe("Rebel Ridge");
            mostWatchedMovie.Year.ShouldBe(2024U);

            mostWatchedMovie.IDs!.Trakt.ShouldBe(483193U);
            mostWatchedMovie.IDs!.Slug.ShouldBe("rebel-ridge-2024");
            mostWatchedMovie.IDs!.IMDB.ShouldBe("tt11301886");
            mostWatchedMovie.IDs!.TMDB.ShouldBe(646097U);
            mostWatchedMovie.IDs!.HasAnyID.ShouldBe(true);
            mostWatchedMovie.IDs!.BestID.ShouldBe("rebel-ridge-2024");

            mostWatchedMovie.ToString().ShouldBe("Rebel Ridge (2024)");

            mostWatchedMovie.Tagline.ShouldBe("Their laws. His rules.");

            mostWatchedMovie.Overview.ShouldBe("A former Marine confronts corruption in a small town when local law enforcement unjustly "
                + "seizes the bag of cash he needs to post his cousin's bail.");

#if NET7_0_OR_GREATER
            mostWatchedMovie!.Released.ShouldBe(TestUtility.ParseDate("2024-09-06"));
#else
            mostWatchedMovie!.Released.ShouldBe(TestUtility.ParseUTCDateTime("2024-09-06T00:00:00.000Z"));
#endif
            mostWatchedMovie.Runtime.ShouldBe(132U);
            mostWatchedMovie.Country.ShouldBe("us");
            mostWatchedMovie.Trailer.ShouldBe("https://youtube.com/watch?v=gF3gZicntIw");
            mostWatchedMovie.Homepage.ShouldBe("http://www.netflix.com/title/81157729");
            mostWatchedMovie.Status.ShouldBe(TraktMovieStatus.Released);
            mostWatchedMovie.Rating.ShouldBe(7.067648663393344f);
            mostWatchedMovie.Votes.ShouldBe(1833U);
            mostWatchedMovie.CommentCount.ShouldBe(27U);
            mostWatchedMovie.UpdatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2024-09-15T08:05:18.000Z"));
            mostWatchedMovie.Language.ShouldBe("en");
            mostWatchedMovie.Languages.ShouldNotBeNull();
            mostWatchedMovie.Languages!.Count.ShouldBe(1);
            mostWatchedMovie.Languages!.ShouldBe(["en"], Case.Sensitive);

            mostWatchedMovie!.AvailableTranslations.ShouldNotBeNull();
            mostWatchedMovie!.AvailableTranslations!.Count.ShouldBe(34);
            mostWatchedMovie!.AvailableTranslations!.ShouldBe([
                "ar", "bg", "cs", "da", "de", "el", "en", "es", "fa", "fi", "fr", "he", "hi", "hr", "hu", "id",
                "it", "ja", "ka", "ko", "nl", "no", "pl", "pt", "ro", "ru", "sl", "sv", "th", "tl", "tr", "uk",
                "vi", "zh"
            ], Case.Sensitive);

            mostWatchedMovie.Genres.ShouldNotBeNull();
            mostWatchedMovie.Genres!.Count.ShouldBe(3);
            mostWatchedMovie.Genres!.ShouldBe([
                "thriller", "crime", "action"
            ], Case.Sensitive);

            mostWatchedMovie.Certification.ShouldBe("R");
        }
    }
}

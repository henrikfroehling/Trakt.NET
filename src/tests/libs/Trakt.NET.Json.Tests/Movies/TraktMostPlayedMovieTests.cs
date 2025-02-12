namespace TraktNET.Json.Movies
{
    public sealed class TraktMostPlayedMovieTests
    {
        [Fact]
        public void TestTraktMostPlayedMovieConstructor()
        {
            var mostPlayedMovie = new TraktMostPlayedMovie();

            mostPlayedMovie.WatcherCount.ShouldBeNull();
            mostPlayedMovie.PlayCount.ShouldBeNull();
            mostPlayedMovie.CollectedCount.ShouldBeNull();
            mostPlayedMovie.Title.ShouldBeNull();
            mostPlayedMovie.Year.ShouldBeNull();
            mostPlayedMovie.IDs.ShouldBeNull();
            mostPlayedMovie.Tagline.ShouldBeNull();
            mostPlayedMovie.Overview.ShouldBeNull();
            mostPlayedMovie.Released.ShouldBeNull();
            mostPlayedMovie.Runtime.ShouldBeNull();
            mostPlayedMovie.Country.ShouldBeNull();
            mostPlayedMovie.Trailer.ShouldBeNull();
            mostPlayedMovie.Homepage.ShouldBeNull();
            mostPlayedMovie.Status.ShouldBeNull();
            mostPlayedMovie.Rating.ShouldBeNull();
            mostPlayedMovie.Votes.ShouldBeNull();
            mostPlayedMovie.CommentCount.ShouldBeNull();
            mostPlayedMovie.UpdatedAt.ShouldBeNull();
            mostPlayedMovie.Language.ShouldBeNull();
            mostPlayedMovie.Languages.ShouldBeNull();
            mostPlayedMovie.AvailableTranslations.ShouldBeNull();
            mostPlayedMovie.Genres.ShouldBeNull();
            mostPlayedMovie.Certification.ShouldBeNull();

            mostPlayedMovie.ToString().ShouldBeEmpty();
        }

        [Fact]
        public async Task TestTraktMostPlayedMovieFromJsonMinimal()
        {
            TraktMostPlayedMovie? mostPlayedMovie = await TraktTestUtility.DeserializeJsonAsync<TraktMostPlayedMovie>("Movies\\mostpwcmovie_minimal.json");

            mostPlayedMovie.ShouldNotBeNull();

            mostPlayedMovie!.WatcherCount.ShouldBe(10606U);
            mostPlayedMovie!.PlayCount.ShouldBe(14142U);
            mostPlayedMovie!.CollectedCount.ShouldBe(107U);

            mostPlayedMovie!.Title.ShouldBe("The Hunt for Red October");
            mostPlayedMovie!.Year.ShouldBe(1990U);

            mostPlayedMovie!.IDs!.Trakt.ShouldBe(1111U);
            mostPlayedMovie!.IDs!.Slug.ShouldBe("the-hunt-for-red-october-1990");
            mostPlayedMovie!.IDs!.IMDB.ShouldBe("tt0099810");
            mostPlayedMovie!.IDs!.TMDB.ShouldBe(1669U);
            mostPlayedMovie!.IDs!.HasAnyID.ShouldBe(true);
            mostPlayedMovie!.IDs!.BestID.ShouldBe("the-hunt-for-red-october-1990");

            mostPlayedMovie!.ToString().ShouldBe("The Hunt for Red October (1990)");
        }

        [Fact]
        public async Task TestTraktMostPlayedMovieFromJson()
        {
            TraktMostPlayedMovie? mostPlayedMovie = await TraktTestUtility.DeserializeJsonAsync<TraktMostPlayedMovie>("Movies\\mostpwcmovie.json");

            mostPlayedMovie.ShouldNotBeNull();

            mostPlayedMovie!.WatcherCount.ShouldBe(10606U);
            mostPlayedMovie!.PlayCount.ShouldBe(14142U);
            mostPlayedMovie!.CollectedCount.ShouldBe(107U);

            mostPlayedMovie!.Title.ShouldBe("The Hunt for Red October");
            mostPlayedMovie!.Year.ShouldBe(1990U);

            mostPlayedMovie!.IDs!.Trakt.ShouldBe(1111U);
            mostPlayedMovie!.IDs!.Slug.ShouldBe("the-hunt-for-red-october-1990");
            mostPlayedMovie!.IDs!.IMDB.ShouldBe("tt0099810");
            mostPlayedMovie!.IDs!.TMDB.ShouldBe(1669U);
            mostPlayedMovie!.IDs!.HasAnyID.ShouldBe(true);
            mostPlayedMovie!.IDs!.BestID.ShouldBe("the-hunt-for-red-october-1990");

            mostPlayedMovie!.ToString().ShouldBe("The Hunt for Red October (1990)");

            mostPlayedMovie!.Tagline.ShouldBe("Invisible. Silent. Stolen.");

            mostPlayedMovie!.Overview.ShouldBe("A new technologically-superior Soviet nuclear sub, the Red October, is heading for the U.S. "
                + "coast under the command of Captain Marko Ramius.");

#if NET7_0_OR_GREATER
            mostPlayedMovie!.Released.ShouldBe(TestUtility.ParseDate("1990-03-02"));
#else
            mostPlayedMovie!.Released.ShouldBe(TestUtility.ParseUTCDateTime("1990-03-02T00:00:00.000Z"));
#endif
            mostPlayedMovie!.Runtime.ShouldBe(135U);
            mostPlayedMovie!.Country.ShouldBe("us");
            mostPlayedMovie!.Trailer.ShouldBe("https://youtube.com/watch?v=NSiAsQMBSRA");
            mostPlayedMovie!.Homepage.ShouldBe("http://www.paramount.com/movies/hunt-red-october");
            mostPlayedMovie!.Status.ShouldBe(TraktMovieStatus.Released);
            mostPlayedMovie!.Rating.ShouldBe(7.9446390086206895f);
            mostPlayedMovie!.Votes.ShouldBe(7424U);
            mostPlayedMovie!.CommentCount.ShouldBe(22U);
            mostPlayedMovie!.UpdatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2024-09-15T08:06:36.000Z"));
            mostPlayedMovie!.Language.ShouldBe("en");
            mostPlayedMovie!.Languages.ShouldNotBeNull();
            mostPlayedMovie!.Languages!.Count.ShouldBe(2);
            mostPlayedMovie!.Languages!.ShouldBe(["en", "ru"], Case.Sensitive);

            mostPlayedMovie!.AvailableTranslations.ShouldNotBeNull();
            mostPlayedMovie!.AvailableTranslations!.Count.ShouldBe(39);
            mostPlayedMovie!.AvailableTranslations!.ShouldBe([
                "ar", "bg", "ca", "cs", "da", "de", "el", "en", "es", "et", "fa", "fi", "fr", "he", "hi", "hr",
                "hu", "id", "it", "ja", "ko", "lt", "lv", "ms", "nb", "nl", "nn", "no", "pl", "pt", "ro", "ru",
                "sk", "sv", "th", "tr", "uk", "vi", "zh"
            ], Case.Sensitive);

            mostPlayedMovie!.Genres.ShouldNotBeNull();
            mostPlayedMovie!.Genres!.Count.ShouldBe(3);
            mostPlayedMovie!.Genres!.ShouldBe([
                "action", "adventure", "thriller"
            ], Case.Sensitive);

            mostPlayedMovie!.Certification.ShouldBe("PG-13");
        }

        [Fact]
        public async Task TestTraktMostPlayedMoviesFromJsonMinimal()
        {
            IReadOnlyList<TraktMostPlayedMovie>? mostPlayedMovies = await TraktTestUtility.DeserializeJsonListAsync<TraktMostPlayedMovie>("Movies\\mostpwcmovies_minimal.json");

            mostPlayedMovies.ShouldNotBeNull();
            mostPlayedMovies!.Count.ShouldBe(2);

            TraktMostPlayedMovie mostPlayedMovie = mostPlayedMovies![0];

            mostPlayedMovie.ShouldNotBeNull();

            mostPlayedMovie.WatcherCount.ShouldBe(10606U);
            mostPlayedMovie.PlayCount.ShouldBe(14142U);
            mostPlayedMovie.CollectedCount.ShouldBe(107U);

            mostPlayedMovie.Title.ShouldBe("The Hunt for Red October");
            mostPlayedMovie.Year.ShouldBe(1990U);

            mostPlayedMovie.IDs!.Trakt.ShouldBe(1111U);
            mostPlayedMovie.IDs!.Slug.ShouldBe("the-hunt-for-red-october-1990");
            mostPlayedMovie.IDs!.IMDB.ShouldBe("tt0099810");
            mostPlayedMovie.IDs!.TMDB.ShouldBe(1669U);
            mostPlayedMovie.IDs!.HasAnyID.ShouldBe(true);
            mostPlayedMovie.IDs!.BestID.ShouldBe("the-hunt-for-red-october-1990");

            mostPlayedMovie.ToString().ShouldBe("The Hunt for Red October (1990)");

            // --------------------------------------------------------------------------------------------

            mostPlayedMovie = mostPlayedMovies![1];

            mostPlayedMovie.ShouldNotBeNull();

            mostPlayedMovie.WatcherCount.ShouldBe(9076U);
            mostPlayedMovie.PlayCount.ShouldBe(12102U);
            mostPlayedMovie.CollectedCount.ShouldBe(3533U);

            mostPlayedMovie.Title.ShouldBe("Rebel Ridge");
            mostPlayedMovie.Year.ShouldBe(2024U);

            mostPlayedMovie.IDs!.Trakt.ShouldBe(483193U);
            mostPlayedMovie.IDs!.Slug.ShouldBe("rebel-ridge-2024");
            mostPlayedMovie.IDs!.IMDB.ShouldBe("tt11301886");
            mostPlayedMovie.IDs!.TMDB.ShouldBe(646097U);
            mostPlayedMovie.IDs!.HasAnyID.ShouldBe(true);
            mostPlayedMovie.IDs!.BestID.ShouldBe("rebel-ridge-2024");

            mostPlayedMovie.ToString().ShouldBe("Rebel Ridge (2024)");
        }

        [Fact]
        public async Task TestTraktMostPlayedMoviesFromJson()
        {
            IReadOnlyList<TraktMostPlayedMovie>? mostPlayedMovies = await TraktTestUtility.DeserializeJsonListAsync<TraktMostPlayedMovie>("Movies\\mostpwcmovies.json");

            mostPlayedMovies.ShouldNotBeNull();
            mostPlayedMovies!.Count.ShouldBe(2);

            TraktMostPlayedMovie mostPlayedMovie = mostPlayedMovies![0];

            mostPlayedMovie.ShouldNotBeNull();

            mostPlayedMovie.WatcherCount.ShouldBe(10606U);
            mostPlayedMovie.PlayCount.ShouldBe(14142U);
            mostPlayedMovie.CollectedCount.ShouldBe(107U);

            mostPlayedMovie.Title.ShouldBe("The Hunt for Red October");
            mostPlayedMovie.Year.ShouldBe(1990U);

            mostPlayedMovie.IDs!.Trakt.ShouldBe(1111U);
            mostPlayedMovie.IDs!.Slug.ShouldBe("the-hunt-for-red-october-1990");
            mostPlayedMovie.IDs!.IMDB.ShouldBe("tt0099810");
            mostPlayedMovie.IDs!.TMDB.ShouldBe(1669U);
            mostPlayedMovie.IDs!.HasAnyID.ShouldBe(true);
            mostPlayedMovie.IDs!.BestID.ShouldBe("the-hunt-for-red-october-1990");

            mostPlayedMovie.ToString().ShouldBe("The Hunt for Red October (1990)");

            mostPlayedMovie.Tagline.ShouldBe("Invisible. Silent. Stolen.");

            mostPlayedMovie.Overview.ShouldBe("A new technologically-superior Soviet nuclear sub, the Red October, is heading for the U.S. "
                + "coast under the command of Captain Marko Ramius.");

#if NET7_0_OR_GREATER
            mostPlayedMovie.Released.ShouldBe(TestUtility.ParseDate("1990-03-02"));
#else
            mostPlayedMovie.Released.ShouldBe(TestUtility.ParseUTCDateTime("1990-03-02T00:00:00.000Z"));
#endif
            mostPlayedMovie.Runtime.ShouldBe(135U);
            mostPlayedMovie.Country.ShouldBe("us");
            mostPlayedMovie.Trailer.ShouldBe("https://youtube.com/watch?v=NSiAsQMBSRA");
            mostPlayedMovie.Homepage.ShouldBe("http://www.paramount.com/movies/hunt-red-october");
            mostPlayedMovie.Status.ShouldBe(TraktMovieStatus.Released);
            mostPlayedMovie.Rating.ShouldBe(7.9446390086206895f);
            mostPlayedMovie.Votes.ShouldBe(7424U);
            mostPlayedMovie.CommentCount.ShouldBe(22U);
            mostPlayedMovie.UpdatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2024-09-15T08:06:36.000Z"));
            mostPlayedMovie.Language.ShouldBe("en");
            mostPlayedMovie.Languages.ShouldNotBeNull();
            mostPlayedMovie.Languages!.Count.ShouldBe(2);
            mostPlayedMovie.Languages!.ShouldBe(["en", "ru"], Case.Sensitive);

            mostPlayedMovie!.AvailableTranslations.ShouldNotBeNull();
            mostPlayedMovie!.AvailableTranslations!.Count.ShouldBe(39);
            mostPlayedMovie!.AvailableTranslations!.ShouldBe([
                "ar", "bg", "ca", "cs", "da", "de", "el", "en", "es", "et", "fa", "fi", "fr", "he", "hi", "hr",
                "hu", "id", "it", "ja", "ko", "lt", "lv", "ms", "nb", "nl", "nn", "no", "pl", "pt", "ro", "ru",
                "sk", "sv", "th", "tr", "uk", "vi", "zh"
            ], Case.Sensitive);

            mostPlayedMovie.Genres.ShouldNotBeNull();
            mostPlayedMovie.Genres!.Count.ShouldBe(3);
            mostPlayedMovie.Genres!.ShouldBe([
                "action", "adventure", "thriller"
            ], Case.Sensitive);

            mostPlayedMovie.Certification.ShouldBe("PG-13");

            // --------------------------------------------------------------------------------------------

            mostPlayedMovie = mostPlayedMovies![1];

            mostPlayedMovie.ShouldNotBeNull();

            mostPlayedMovie.WatcherCount.ShouldBe(9076U);
            mostPlayedMovie.PlayCount.ShouldBe(12102U);
            mostPlayedMovie.CollectedCount.ShouldBe(3533U);

            mostPlayedMovie.Title.ShouldBe("Rebel Ridge");
            mostPlayedMovie.Year.ShouldBe(2024U);

            mostPlayedMovie.IDs!.Trakt.ShouldBe(483193U);
            mostPlayedMovie.IDs!.Slug.ShouldBe("rebel-ridge-2024");
            mostPlayedMovie.IDs!.IMDB.ShouldBe("tt11301886");
            mostPlayedMovie.IDs!.TMDB.ShouldBe(646097U);
            mostPlayedMovie.IDs!.HasAnyID.ShouldBe(true);
            mostPlayedMovie.IDs!.BestID.ShouldBe("rebel-ridge-2024");

            mostPlayedMovie.ToString().ShouldBe("Rebel Ridge (2024)");

            mostPlayedMovie.Tagline.ShouldBe("Their laws. His rules.");

            mostPlayedMovie.Overview.ShouldBe("A former Marine confronts corruption in a small town when local law enforcement unjustly "
                + "seizes the bag of cash he needs to post his cousin's bail.");

#if NET7_0_OR_GREATER
            mostPlayedMovie!.Released.ShouldBe(TestUtility.ParseDate("2024-09-06"));
#else
            mostPlayedMovie!.Released.ShouldBe(TestUtility.ParseUTCDateTime("2024-09-06T00:00:00.000Z"));
#endif
            mostPlayedMovie.Runtime.ShouldBe(132U);
            mostPlayedMovie.Country.ShouldBe("us");
            mostPlayedMovie.Trailer.ShouldBe("https://youtube.com/watch?v=gF3gZicntIw");
            mostPlayedMovie.Homepage.ShouldBe("http://www.netflix.com/title/81157729");
            mostPlayedMovie.Status.ShouldBe(TraktMovieStatus.Released);
            mostPlayedMovie.Rating.ShouldBe(7.067648663393344f);
            mostPlayedMovie.Votes.ShouldBe(1833U);
            mostPlayedMovie.CommentCount.ShouldBe(27U);
            mostPlayedMovie.UpdatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2024-09-15T08:05:18.000Z"));
            mostPlayedMovie.Language.ShouldBe("en");
            mostPlayedMovie.Languages.ShouldNotBeNull();
            mostPlayedMovie.Languages!.Count.ShouldBe(1);
            mostPlayedMovie.Languages!.ShouldBe(["en"], Case.Sensitive);

            mostPlayedMovie!.AvailableTranslations.ShouldNotBeNull();
            mostPlayedMovie!.AvailableTranslations!.Count.ShouldBe(34);
            mostPlayedMovie!.AvailableTranslations!.ShouldBe([
                "ar", "bg", "cs", "da", "de", "el", "en", "es", "fa", "fi", "fr", "he", "hi", "hr", "hu", "id",
                "it", "ja", "ka", "ko", "nl", "no", "pl", "pt", "ro", "ru", "sl", "sv", "th", "tl", "tr", "uk",
                "vi", "zh"
            ], Case.Sensitive);

            mostPlayedMovie.Genres.ShouldNotBeNull();
            mostPlayedMovie.Genres!.Count.ShouldBe(3);
            mostPlayedMovie.Genres!.ShouldBe([
                "thriller", "crime", "action"
            ], Case.Sensitive);

            mostPlayedMovie.Certification.ShouldBe("R");
        }
    }
}

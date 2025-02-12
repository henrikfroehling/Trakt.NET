namespace TraktNET.Json.Movies
{
    public sealed class TraktMostCollectedMovieTests
    {
        [Fact]
        public void TestTraktMostCollectedMovieConstructor()
        {
            var mostCollectedMovie = new TraktMostCollectedMovie();

            mostCollectedMovie.WatcherCount.ShouldBeNull();
            mostCollectedMovie.PlayCount.ShouldBeNull();
            mostCollectedMovie.CollectedCount.ShouldBeNull();
            mostCollectedMovie.Title.ShouldBeNull();
            mostCollectedMovie.Year.ShouldBeNull();
            mostCollectedMovie.IDs.ShouldBeNull();
            mostCollectedMovie.Tagline.ShouldBeNull();
            mostCollectedMovie.Overview.ShouldBeNull();
            mostCollectedMovie.Released.ShouldBeNull();
            mostCollectedMovie.Runtime.ShouldBeNull();
            mostCollectedMovie.Country.ShouldBeNull();
            mostCollectedMovie.Trailer.ShouldBeNull();
            mostCollectedMovie.Homepage.ShouldBeNull();
            mostCollectedMovie.Status.ShouldBeNull();
            mostCollectedMovie.Rating.ShouldBeNull();
            mostCollectedMovie.Votes.ShouldBeNull();
            mostCollectedMovie.CommentCount.ShouldBeNull();
            mostCollectedMovie.UpdatedAt.ShouldBeNull();
            mostCollectedMovie.Language.ShouldBeNull();
            mostCollectedMovie.Languages.ShouldBeNull();
            mostCollectedMovie.AvailableTranslations.ShouldBeNull();
            mostCollectedMovie.Genres.ShouldBeNull();
            mostCollectedMovie.Certification.ShouldBeNull();

            mostCollectedMovie.ToString().ShouldBeEmpty();
        }

        [Fact]
        public async Task TestTraktMostCollectedMovieFromJsonMinimal()
        {
            TraktMostCollectedMovie? mostCollectedMovie = await TraktTestUtility.DeserializeJsonAsync<TraktMostCollectedMovie>("Movies\\mostpwcmovie_minimal.json");

            mostCollectedMovie.ShouldNotBeNull();

            mostCollectedMovie!.WatcherCount.ShouldBe(10606U);
            mostCollectedMovie!.PlayCount.ShouldBe(14142U);
            mostCollectedMovie!.CollectedCount.ShouldBe(107U);

            mostCollectedMovie!.Title.ShouldBe("The Hunt for Red October");
            mostCollectedMovie!.Year.ShouldBe(1990U);

            mostCollectedMovie!.IDs!.Trakt.ShouldBe(1111U);
            mostCollectedMovie!.IDs!.Slug.ShouldBe("the-hunt-for-red-october-1990");
            mostCollectedMovie!.IDs!.IMDB.ShouldBe("tt0099810");
            mostCollectedMovie!.IDs!.TMDB.ShouldBe(1669U);
            mostCollectedMovie!.IDs!.HasAnyID.ShouldBe(true);
            mostCollectedMovie!.IDs!.BestID.ShouldBe("the-hunt-for-red-october-1990");

            mostCollectedMovie!.ToString().ShouldBe("The Hunt for Red October (1990)");
        }

        [Fact]
        public async Task TestTraktMostCollectedMovieFromJson()
        {
            TraktMostCollectedMovie? mostCollectedMovie = await TraktTestUtility.DeserializeJsonAsync<TraktMostCollectedMovie>("Movies\\mostpwcmovie.json");

            mostCollectedMovie.ShouldNotBeNull();

            mostCollectedMovie!.WatcherCount.ShouldBe(10606U);
            mostCollectedMovie!.PlayCount.ShouldBe(14142U);
            mostCollectedMovie!.CollectedCount.ShouldBe(107U);

            mostCollectedMovie!.Title.ShouldBe("The Hunt for Red October");
            mostCollectedMovie!.Year.ShouldBe(1990U);

            mostCollectedMovie!.IDs!.Trakt.ShouldBe(1111U);
            mostCollectedMovie!.IDs!.Slug.ShouldBe("the-hunt-for-red-october-1990");
            mostCollectedMovie!.IDs!.IMDB.ShouldBe("tt0099810");
            mostCollectedMovie!.IDs!.TMDB.ShouldBe(1669U);
            mostCollectedMovie!.IDs!.HasAnyID.ShouldBe(true);
            mostCollectedMovie!.IDs!.BestID.ShouldBe("the-hunt-for-red-october-1990");

            mostCollectedMovie!.ToString().ShouldBe("The Hunt for Red October (1990)");

            mostCollectedMovie!.Tagline.ShouldBe("Invisible. Silent. Stolen.");

            mostCollectedMovie!.Overview.ShouldBe("A new technologically-superior Soviet nuclear sub, the Red October, is heading for the U.S. "
                + "coast under the command of Captain Marko Ramius.");

#if NET7_0_OR_GREATER
            mostCollectedMovie!.Released.ShouldBe(TestUtility.ParseDate("1990-03-02"));
#else
            mostCollectedMovie!.Released.ShouldBe(TestUtility.ParseUTCDateTime("1990-03-02T00:00:00.000Z"));
#endif
            mostCollectedMovie!.Runtime.ShouldBe(135U);
            mostCollectedMovie!.Country.ShouldBe("us");
            mostCollectedMovie!.Trailer.ShouldBe("https://youtube.com/watch?v=NSiAsQMBSRA");
            mostCollectedMovie!.Homepage.ShouldBe("http://www.paramount.com/movies/hunt-red-october");
            mostCollectedMovie!.Status.ShouldBe(TraktMovieStatus.Released);
            mostCollectedMovie!.Rating.ShouldBe(7.9446390086206895f);
            mostCollectedMovie!.Votes.ShouldBe(7424U);
            mostCollectedMovie!.CommentCount.ShouldBe(22U);
            mostCollectedMovie!.UpdatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2024-09-15T08:06:36.000Z"));
            mostCollectedMovie!.Language.ShouldBe("en");
            mostCollectedMovie!.Languages.ShouldNotBeNull();
            mostCollectedMovie!.Languages!.Count.ShouldBe(2);
            mostCollectedMovie!.Languages!.ShouldBe(["en", "ru"], Case.Sensitive);

            mostCollectedMovie!.AvailableTranslations.ShouldNotBeNull();
            mostCollectedMovie!.AvailableTranslations!.Count.ShouldBe(39);
            mostCollectedMovie!.AvailableTranslations!.ShouldBe([
                "ar", "bg", "ca", "cs", "da", "de", "el", "en", "es", "et", "fa", "fi", "fr", "he", "hi", "hr",
                "hu", "id", "it", "ja", "ko", "lt", "lv", "ms", "nb", "nl", "nn", "no", "pl", "pt", "ro", "ru",
                "sk", "sv", "th", "tr", "uk", "vi", "zh"
            ], Case.Sensitive);

            mostCollectedMovie!.Genres.ShouldNotBeNull();
            mostCollectedMovie!.Genres!.Count.ShouldBe(3);
            mostCollectedMovie!.Genres!.ShouldBe([
                "action", "adventure", "thriller"
            ], Case.Sensitive);

            mostCollectedMovie!.Certification.ShouldBe("PG-13");
        }

        [Fact]
        public async Task TestTraktMostCollectedMoviesFromJsonMinimal()
        {
            IReadOnlyList<TraktMostCollectedMovie>? mostCollectedMovies = await TraktTestUtility.DeserializeJsonListAsync<TraktMostCollectedMovie>("Movies\\mostpwcmovies_minimal.json");

            mostCollectedMovies.ShouldNotBeNull();
            mostCollectedMovies!.Count.ShouldBe(2);

            TraktMostCollectedMovie mostCollectedMovie = mostCollectedMovies![0];

            mostCollectedMovie.ShouldNotBeNull();

            mostCollectedMovie.WatcherCount.ShouldBe(10606U);
            mostCollectedMovie.PlayCount.ShouldBe(14142U);
            mostCollectedMovie.CollectedCount.ShouldBe(107U);

            mostCollectedMovie.Title.ShouldBe("The Hunt for Red October");
            mostCollectedMovie.Year.ShouldBe(1990U);

            mostCollectedMovie.IDs!.Trakt.ShouldBe(1111U);
            mostCollectedMovie.IDs!.Slug.ShouldBe("the-hunt-for-red-october-1990");
            mostCollectedMovie.IDs!.IMDB.ShouldBe("tt0099810");
            mostCollectedMovie.IDs!.TMDB.ShouldBe(1669U);
            mostCollectedMovie.IDs!.HasAnyID.ShouldBe(true);
            mostCollectedMovie.IDs!.BestID.ShouldBe("the-hunt-for-red-october-1990");

            mostCollectedMovie.ToString().ShouldBe("The Hunt for Red October (1990)");

            // --------------------------------------------------------------------------------------------

            mostCollectedMovie = mostCollectedMovies![1];

            mostCollectedMovie.ShouldNotBeNull();

            mostCollectedMovie.WatcherCount.ShouldBe(9076U);
            mostCollectedMovie.PlayCount.ShouldBe(12102U);
            mostCollectedMovie.CollectedCount.ShouldBe(3533U);

            mostCollectedMovie.Title.ShouldBe("Rebel Ridge");
            mostCollectedMovie.Year.ShouldBe(2024U);

            mostCollectedMovie.IDs!.Trakt.ShouldBe(483193U);
            mostCollectedMovie.IDs!.Slug.ShouldBe("rebel-ridge-2024");
            mostCollectedMovie.IDs!.IMDB.ShouldBe("tt11301886");
            mostCollectedMovie.IDs!.TMDB.ShouldBe(646097U);
            mostCollectedMovie.IDs!.HasAnyID.ShouldBe(true);
            mostCollectedMovie.IDs!.BestID.ShouldBe("rebel-ridge-2024");

            mostCollectedMovie.ToString().ShouldBe("Rebel Ridge (2024)");
        }

        [Fact]
        public async Task TestTraktMostCollectedMoviesFromJson()
        {
            IReadOnlyList<TraktMostCollectedMovie>? mostCollectedMovies = await TraktTestUtility.DeserializeJsonListAsync<TraktMostCollectedMovie>("Movies\\mostpwcmovies.json");

            mostCollectedMovies.ShouldNotBeNull();
            mostCollectedMovies!.Count.ShouldBe(2);

            TraktMostCollectedMovie mostCollectedMovie = mostCollectedMovies![0];

            mostCollectedMovie.ShouldNotBeNull();

            mostCollectedMovie.WatcherCount.ShouldBe(10606U);
            mostCollectedMovie.PlayCount.ShouldBe(14142U);
            mostCollectedMovie.CollectedCount.ShouldBe(107U);

            mostCollectedMovie.Title.ShouldBe("The Hunt for Red October");
            mostCollectedMovie.Year.ShouldBe(1990U);

            mostCollectedMovie.IDs!.Trakt.ShouldBe(1111U);
            mostCollectedMovie.IDs!.Slug.ShouldBe("the-hunt-for-red-october-1990");
            mostCollectedMovie.IDs!.IMDB.ShouldBe("tt0099810");
            mostCollectedMovie.IDs!.TMDB.ShouldBe(1669U);
            mostCollectedMovie.IDs!.HasAnyID.ShouldBe(true);
            mostCollectedMovie.IDs!.BestID.ShouldBe("the-hunt-for-red-october-1990");

            mostCollectedMovie.ToString().ShouldBe("The Hunt for Red October (1990)");

            mostCollectedMovie.Tagline.ShouldBe("Invisible. Silent. Stolen.");

            mostCollectedMovie.Overview.ShouldBe("A new technologically-superior Soviet nuclear sub, the Red October, is heading for the U.S. "
                + "coast under the command of Captain Marko Ramius.");

#if NET7_0_OR_GREATER
            mostCollectedMovie.Released.ShouldBe(TestUtility.ParseDate("1990-03-02"));
#else
            mostCollectedMovie.Released.ShouldBe(TestUtility.ParseUTCDateTime("1990-03-02T00:00:00.000Z"));
#endif
            mostCollectedMovie.Runtime.ShouldBe(135U);
            mostCollectedMovie.Country.ShouldBe("us");
            mostCollectedMovie.Trailer.ShouldBe("https://youtube.com/watch?v=NSiAsQMBSRA");
            mostCollectedMovie.Homepage.ShouldBe("http://www.paramount.com/movies/hunt-red-october");
            mostCollectedMovie.Status.ShouldBe(TraktMovieStatus.Released);
            mostCollectedMovie.Rating.ShouldBe(7.9446390086206895f);
            mostCollectedMovie.Votes.ShouldBe(7424U);
            mostCollectedMovie.CommentCount.ShouldBe(22U);
            mostCollectedMovie.UpdatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2024-09-15T08:06:36.000Z"));
            mostCollectedMovie.Language.ShouldBe("en");
            mostCollectedMovie.Languages.ShouldNotBeNull();
            mostCollectedMovie.Languages!.Count.ShouldBe(2);
            mostCollectedMovie.Languages!.ShouldBe(["en", "ru"], Case.Sensitive);

            mostCollectedMovie!.AvailableTranslations.ShouldNotBeNull();
            mostCollectedMovie!.AvailableTranslations!.Count.ShouldBe(39);
            mostCollectedMovie!.AvailableTranslations!.ShouldBe([
                "ar", "bg", "ca", "cs", "da", "de", "el", "en", "es", "et", "fa", "fi", "fr", "he", "hi", "hr",
                "hu", "id", "it", "ja", "ko", "lt", "lv", "ms", "nb", "nl", "nn", "no", "pl", "pt", "ro", "ru",
                "sk", "sv", "th", "tr", "uk", "vi", "zh"
            ], Case.Sensitive);

            mostCollectedMovie.Genres.ShouldNotBeNull();
            mostCollectedMovie.Genres!.Count.ShouldBe(3);
            mostCollectedMovie.Genres!.ShouldBe([
                "action", "adventure", "thriller"
            ], Case.Sensitive);

            mostCollectedMovie.Certification.ShouldBe("PG-13");

            // --------------------------------------------------------------------------------------------

            mostCollectedMovie = mostCollectedMovies![1];

            mostCollectedMovie.ShouldNotBeNull();

            mostCollectedMovie.WatcherCount.ShouldBe(9076U);
            mostCollectedMovie.PlayCount.ShouldBe(12102U);
            mostCollectedMovie.CollectedCount.ShouldBe(3533U);

            mostCollectedMovie.Title.ShouldBe("Rebel Ridge");
            mostCollectedMovie.Year.ShouldBe(2024U);

            mostCollectedMovie.IDs!.Trakt.ShouldBe(483193U);
            mostCollectedMovie.IDs!.Slug.ShouldBe("rebel-ridge-2024");
            mostCollectedMovie.IDs!.IMDB.ShouldBe("tt11301886");
            mostCollectedMovie.IDs!.TMDB.ShouldBe(646097U);
            mostCollectedMovie.IDs!.HasAnyID.ShouldBe(true);
            mostCollectedMovie.IDs!.BestID.ShouldBe("rebel-ridge-2024");

            mostCollectedMovie.ToString().ShouldBe("Rebel Ridge (2024)");

            mostCollectedMovie.Tagline.ShouldBe("Their laws. His rules.");

            mostCollectedMovie.Overview.ShouldBe("A former Marine confronts corruption in a small town when local law enforcement unjustly "
                + "seizes the bag of cash he needs to post his cousin's bail.");

#if NET7_0_OR_GREATER
            mostCollectedMovie!.Released.ShouldBe(TestUtility.ParseDate("2024-09-06"));
#else
            mostCollectedMovie!.Released.ShouldBe(TestUtility.ParseUTCDateTime("2024-09-06T00:00:00.000Z"));
#endif
            mostCollectedMovie.Runtime.ShouldBe(132U);
            mostCollectedMovie.Country.ShouldBe("us");
            mostCollectedMovie.Trailer.ShouldBe("https://youtube.com/watch?v=gF3gZicntIw");
            mostCollectedMovie.Homepage.ShouldBe("http://www.netflix.com/title/81157729");
            mostCollectedMovie.Status.ShouldBe(TraktMovieStatus.Released);
            mostCollectedMovie.Rating.ShouldBe(7.067648663393344f);
            mostCollectedMovie.Votes.ShouldBe(1833U);
            mostCollectedMovie.CommentCount.ShouldBe(27U);
            mostCollectedMovie.UpdatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2024-09-15T08:05:18.000Z"));
            mostCollectedMovie.Language.ShouldBe("en");
            mostCollectedMovie.Languages.ShouldNotBeNull();
            mostCollectedMovie.Languages!.Count.ShouldBe(1);
            mostCollectedMovie.Languages!.ShouldBe(["en"], Case.Sensitive);

            mostCollectedMovie!.AvailableTranslations.ShouldNotBeNull();
            mostCollectedMovie!.AvailableTranslations!.Count.ShouldBe(34);
            mostCollectedMovie!.AvailableTranslations!.ShouldBe([
                "ar", "bg", "cs", "da", "de", "el", "en", "es", "fa", "fi", "fr", "he", "hi", "hr", "hu", "id",
                "it", "ja", "ka", "ko", "nl", "no", "pl", "pt", "ro", "ru", "sl", "sv", "th", "tl", "tr", "uk",
                "vi", "zh"
            ], Case.Sensitive);

            mostCollectedMovie.Genres.ShouldNotBeNull();
            mostCollectedMovie.Genres!.Count.ShouldBe(3);
            mostCollectedMovie.Genres!.ShouldBe([
                "thriller", "crime", "action"
            ], Case.Sensitive);

            mostCollectedMovie.Certification.ShouldBe("R");
        }
    }
}

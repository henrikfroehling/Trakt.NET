namespace TraktNET.Json.Movies
{
    public sealed class TraktMostPWCMovieTests
    {
        [Fact]
        public void TestTraktMostPWCMovieConstructor()
        {
            var mostPWCMovie = new TraktMostPWCMovie();

            mostPWCMovie.WatcherCount.ShouldBeNull();
            mostPWCMovie.PlayCount.ShouldBeNull();
            mostPWCMovie.CollectedCount.ShouldBeNull();
            mostPWCMovie.Title.ShouldBeNull();
            mostPWCMovie.Year.ShouldBeNull();
            mostPWCMovie.IDs.ShouldBeNull();
            mostPWCMovie.Tagline.ShouldBeNull();
            mostPWCMovie.Overview.ShouldBeNull();
            mostPWCMovie.Released.ShouldBeNull();
            mostPWCMovie.Runtime.ShouldBeNull();
            mostPWCMovie.Country.ShouldBeNull();
            mostPWCMovie.Trailer.ShouldBeNull();
            mostPWCMovie.Homepage.ShouldBeNull();
            mostPWCMovie.Status.ShouldBeNull();
            mostPWCMovie.Rating.ShouldBeNull();
            mostPWCMovie.Votes.ShouldBeNull();
            mostPWCMovie.CommentCount.ShouldBeNull();
            mostPWCMovie.UpdatedAt.ShouldBeNull();
            mostPWCMovie.Language.ShouldBeNull();
            mostPWCMovie.Languages.ShouldBeNull();
            mostPWCMovie.AvailableTranslations.ShouldBeNull();
            mostPWCMovie.Genres.ShouldBeNull();
            mostPWCMovie.Certification.ShouldBeNull();

            mostPWCMovie.ToString().ShouldBeEmpty();
        }

        [Fact]
        public async Task TestTraktMostPWCMovieFromJsonMinimal()
        {
            TraktMostPWCMovie? mostPWCMovie = await TraktTestUtility.DeserializeJsonAsync<TraktMostPWCMovie>("Movies\\mostpwcmovie_minimal.json");

            mostPWCMovie.ShouldNotBeNull();

            mostPWCMovie!.WatcherCount.ShouldBe(10606U);
            mostPWCMovie!.PlayCount.ShouldBe(14142U);
            mostPWCMovie!.CollectedCount.ShouldBe(107U);

            mostPWCMovie!.Title.ShouldBe("The Hunt for Red October");
            mostPWCMovie!.Year.ShouldBe(1990U);

            mostPWCMovie!.IDs!.Trakt.ShouldBe(1111U);
            mostPWCMovie!.IDs!.Slug.ShouldBe("the-hunt-for-red-october-1990");
            mostPWCMovie!.IDs!.IMDB.ShouldBe("tt0099810");
            mostPWCMovie!.IDs!.TMDB.ShouldBe(1669U);
            mostPWCMovie!.IDs!.HasAnyID.ShouldBe(true);
            mostPWCMovie!.IDs!.BestID.ShouldBe("the-hunt-for-red-october-1990");

            mostPWCMovie!.ToString().ShouldBe("The Hunt for Red October (1990)");
        }

        [Fact]
        public async Task TestTraktMostPWCMovieFromJson()
        {
            TraktMostPWCMovie? mostPWCMovie = await TraktTestUtility.DeserializeJsonAsync<TraktMostPWCMovie>("Movies\\mostpwcmovie.json");

            mostPWCMovie.ShouldNotBeNull();

            mostPWCMovie!.WatcherCount.ShouldBe(10606U);
            mostPWCMovie!.PlayCount.ShouldBe(14142U);
            mostPWCMovie!.CollectedCount.ShouldBe(107U);

            mostPWCMovie!.Title.ShouldBe("The Hunt for Red October");
            mostPWCMovie!.Year.ShouldBe(1990U);

            mostPWCMovie!.IDs!.Trakt.ShouldBe(1111U);
            mostPWCMovie!.IDs!.Slug.ShouldBe("the-hunt-for-red-october-1990");
            mostPWCMovie!.IDs!.IMDB.ShouldBe("tt0099810");
            mostPWCMovie!.IDs!.TMDB.ShouldBe(1669U);
            mostPWCMovie!.IDs!.HasAnyID.ShouldBe(true);
            mostPWCMovie!.IDs!.BestID.ShouldBe("the-hunt-for-red-october-1990");

            mostPWCMovie!.ToString().ShouldBe("The Hunt for Red October (1990)");

            mostPWCMovie!.Tagline.ShouldBe("Invisible. Silent. Stolen.");

            mostPWCMovie!.Overview.ShouldBe("A new technologically-superior Soviet nuclear sub, the Red October, is heading for the U.S. "
                + "coast under the command of Captain Marko Ramius.");

#if NET7_0_OR_GREATER
            mostPWCMovie!.Released.ShouldBe(TestUtility.ParseDate("1990-03-02"));
#else
            mostPWCMovie!.Released.ShouldBe(TestUtility.ParseUTCDateTime("1990-03-02T00:00:00.000Z"));
#endif
            mostPWCMovie!.Runtime.ShouldBe(135U);
            mostPWCMovie!.Country.ShouldBe("us");
            mostPWCMovie!.Trailer.ShouldBe("https://youtube.com/watch?v=NSiAsQMBSRA");
            mostPWCMovie!.Homepage.ShouldBe("http://www.paramount.com/movies/hunt-red-october");
            mostPWCMovie!.Status.ShouldBe(TraktMovieStatus.Released);
            mostPWCMovie!.Rating.ShouldBe(7.9446390086206895f);
            mostPWCMovie!.Votes.ShouldBe(7424U);
            mostPWCMovie!.CommentCount.ShouldBe(22U);
            mostPWCMovie!.UpdatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2024-09-15T08:06:36.000Z"));
            mostPWCMovie!.Language.ShouldBe("en");
            mostPWCMovie!.Languages.ShouldNotBeNull();
            mostPWCMovie!.Languages!.Count.ShouldBe(2);
            mostPWCMovie!.Languages!.ShouldBe(["en", "ru"], Case.Sensitive);

            mostPWCMovie!.AvailableTranslations.ShouldNotBeNull();
            mostPWCMovie!.AvailableTranslations!.Count.ShouldBe(39);
            mostPWCMovie!.AvailableTranslations!.ShouldBe([
                "ar", "bg", "ca", "cs", "da", "de", "el", "en", "es", "et", "fa", "fi", "fr", "he", "hi", "hr",
                "hu", "id", "it", "ja", "ko", "lt", "lv", "ms", "nb", "nl", "nn", "no", "pl", "pt", "ro", "ru",
                "sk", "sv", "th", "tr", "uk", "vi", "zh"
            ], Case.Sensitive);

            mostPWCMovie!.Genres.ShouldNotBeNull();
            mostPWCMovie!.Genres!.Count.ShouldBe(3);
            mostPWCMovie!.Genres!.ShouldBe([
                "action", "adventure", "thriller"
            ], Case.Sensitive);

            mostPWCMovie!.Certification.ShouldBe("PG-13");
        }

        [Fact]
        public async Task TestTraktMostPWCMoviesFromJsonMinimal()
        {
            IReadOnlyList<TraktMostPWCMovie>? mostPWCMovies = await TraktTestUtility.DeserializeJsonListAsync<TraktMostPWCMovie>("Movies\\mostpwcmovies_minimal.json");

            mostPWCMovies.ShouldNotBeNull();
            mostPWCMovies!.Count.ShouldBe(2);

            TraktMostPWCMovie mostPWCMovie = mostPWCMovies![0];

            mostPWCMovie.ShouldNotBeNull();

            mostPWCMovie.WatcherCount.ShouldBe(10606U);
            mostPWCMovie.PlayCount.ShouldBe(14142U);
            mostPWCMovie.CollectedCount.ShouldBe(107U);

            mostPWCMovie.Title.ShouldBe("The Hunt for Red October");
            mostPWCMovie.Year.ShouldBe(1990U);

            mostPWCMovie.IDs!.Trakt.ShouldBe(1111U);
            mostPWCMovie.IDs!.Slug.ShouldBe("the-hunt-for-red-october-1990");
            mostPWCMovie.IDs!.IMDB.ShouldBe("tt0099810");
            mostPWCMovie.IDs!.TMDB.ShouldBe(1669U);
            mostPWCMovie.IDs!.HasAnyID.ShouldBe(true);
            mostPWCMovie.IDs!.BestID.ShouldBe("the-hunt-for-red-october-1990");

            mostPWCMovie.ToString().ShouldBe("The Hunt for Red October (1990)");

            // --------------------------------------------------------------------------------------------

            mostPWCMovie = mostPWCMovies![1];

            mostPWCMovie.ShouldNotBeNull();

            mostPWCMovie.WatcherCount.ShouldBe(9076U);
            mostPWCMovie.PlayCount.ShouldBe(12102U);
            mostPWCMovie.CollectedCount.ShouldBe(3533U);

            mostPWCMovie.Title.ShouldBe("Rebel Ridge");
            mostPWCMovie.Year.ShouldBe(2024U);

            mostPWCMovie.IDs!.Trakt.ShouldBe(483193U);
            mostPWCMovie.IDs!.Slug.ShouldBe("rebel-ridge-2024");
            mostPWCMovie.IDs!.IMDB.ShouldBe("tt11301886");
            mostPWCMovie.IDs!.TMDB.ShouldBe(646097U);
            mostPWCMovie.IDs!.HasAnyID.ShouldBe(true);
            mostPWCMovie.IDs!.BestID.ShouldBe("rebel-ridge-2024");

            mostPWCMovie.ToString().ShouldBe("Rebel Ridge (2024)");
        }

        [Fact]
        public async Task TestTraktMostPWCMoviesFromJson()
        {
            IReadOnlyList<TraktMostPWCMovie>? mostPWCMovies = await TraktTestUtility.DeserializeJsonListAsync<TraktMostPWCMovie>("Movies\\mostpwcmovies.json");

            mostPWCMovies.ShouldNotBeNull();
            mostPWCMovies!.Count.ShouldBe(2);

            TraktMostPWCMovie mostPWCMovie = mostPWCMovies![0];

            mostPWCMovie.ShouldNotBeNull();

            mostPWCMovie.WatcherCount.ShouldBe(10606U);
            mostPWCMovie.PlayCount.ShouldBe(14142U);
            mostPWCMovie.CollectedCount.ShouldBe(107U);

            mostPWCMovie.Title.ShouldBe("The Hunt for Red October");
            mostPWCMovie.Year.ShouldBe(1990U);

            mostPWCMovie.IDs!.Trakt.ShouldBe(1111U);
            mostPWCMovie.IDs!.Slug.ShouldBe("the-hunt-for-red-october-1990");
            mostPWCMovie.IDs!.IMDB.ShouldBe("tt0099810");
            mostPWCMovie.IDs!.TMDB.ShouldBe(1669U);
            mostPWCMovie.IDs!.HasAnyID.ShouldBe(true);
            mostPWCMovie.IDs!.BestID.ShouldBe("the-hunt-for-red-october-1990");

            mostPWCMovie.ToString().ShouldBe("The Hunt for Red October (1990)");

            mostPWCMovie.Tagline.ShouldBe("Invisible. Silent. Stolen.");

            mostPWCMovie.Overview.ShouldBe("A new technologically-superior Soviet nuclear sub, the Red October, is heading for the U.S. "
                + "coast under the command of Captain Marko Ramius.");

#if NET7_0_OR_GREATER
            mostPWCMovie.Released.ShouldBe(TestUtility.ParseDate("1990-03-02"));
#else
            mostPWCMovie.Released.ShouldBe(TestUtility.ParseUTCDateTime("1990-03-02T00:00:00.000Z"));
#endif
            mostPWCMovie.Runtime.ShouldBe(135U);
            mostPWCMovie.Country.ShouldBe("us");
            mostPWCMovie.Trailer.ShouldBe("https://youtube.com/watch?v=NSiAsQMBSRA");
            mostPWCMovie.Homepage.ShouldBe("http://www.paramount.com/movies/hunt-red-october");
            mostPWCMovie.Status.ShouldBe(TraktMovieStatus.Released);
            mostPWCMovie.Rating.ShouldBe(7.9446390086206895f);
            mostPWCMovie.Votes.ShouldBe(7424U);
            mostPWCMovie.CommentCount.ShouldBe(22U);
            mostPWCMovie.UpdatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2024-09-15T08:06:36.000Z"));
            mostPWCMovie.Language.ShouldBe("en");
            mostPWCMovie.Languages.ShouldNotBeNull();
            mostPWCMovie.Languages!.Count.ShouldBe(2);
            mostPWCMovie.Languages!.ShouldBe(["en", "ru"], Case.Sensitive);

            mostPWCMovie!.AvailableTranslations.ShouldNotBeNull();
            mostPWCMovie!.AvailableTranslations!.Count.ShouldBe(39);
            mostPWCMovie!.AvailableTranslations!.ShouldBe([
                "ar", "bg", "ca", "cs", "da", "de", "el", "en", "es", "et", "fa", "fi", "fr", "he", "hi", "hr",
                "hu", "id", "it", "ja", "ko", "lt", "lv", "ms", "nb", "nl", "nn", "no", "pl", "pt", "ro", "ru",
                "sk", "sv", "th", "tr", "uk", "vi", "zh"
            ], Case.Sensitive);

            mostPWCMovie.Genres.ShouldNotBeNull();
            mostPWCMovie.Genres!.Count.ShouldBe(3);
            mostPWCMovie.Genres!.ShouldBe([
                "action", "adventure", "thriller"
            ], Case.Sensitive);

            mostPWCMovie.Certification.ShouldBe("PG-13");

            // --------------------------------------------------------------------------------------------

            mostPWCMovie = mostPWCMovies![1];

            mostPWCMovie.ShouldNotBeNull();

            mostPWCMovie.WatcherCount.ShouldBe(9076U);
            mostPWCMovie.PlayCount.ShouldBe(12102U);
            mostPWCMovie.CollectedCount.ShouldBe(3533U);

            mostPWCMovie.Title.ShouldBe("Rebel Ridge");
            mostPWCMovie.Year.ShouldBe(2024U);

            mostPWCMovie.IDs!.Trakt.ShouldBe(483193U);
            mostPWCMovie.IDs!.Slug.ShouldBe("rebel-ridge-2024");
            mostPWCMovie.IDs!.IMDB.ShouldBe("tt11301886");
            mostPWCMovie.IDs!.TMDB.ShouldBe(646097U);
            mostPWCMovie.IDs!.HasAnyID.ShouldBe(true);
            mostPWCMovie.IDs!.BestID.ShouldBe("rebel-ridge-2024");

            mostPWCMovie.ToString().ShouldBe("Rebel Ridge (2024)");

            mostPWCMovie.Tagline.ShouldBe("Their laws. His rules.");

            mostPWCMovie.Overview.ShouldBe("A former Marine confronts corruption in a small town when local law enforcement unjustly "
                + "seizes the bag of cash he needs to post his cousin's bail.");

#if NET7_0_OR_GREATER
            mostPWCMovie!.Released.ShouldBe(TestUtility.ParseDate("2024-09-06"));
#else
            mostPWCMovie!.Released.ShouldBe(TestUtility.ParseUTCDateTime("2024-09-06T00:00:00.000Z"));
#endif
            mostPWCMovie.Runtime.ShouldBe(132U);
            mostPWCMovie.Country.ShouldBe("us");
            mostPWCMovie.Trailer.ShouldBe("https://youtube.com/watch?v=gF3gZicntIw");
            mostPWCMovie.Homepage.ShouldBe("http://www.netflix.com/title/81157729");
            mostPWCMovie.Status.ShouldBe(TraktMovieStatus.Released);
            mostPWCMovie.Rating.ShouldBe(7.067648663393344f);
            mostPWCMovie.Votes.ShouldBe(1833U);
            mostPWCMovie.CommentCount.ShouldBe(27U);
            mostPWCMovie.UpdatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2024-09-15T08:05:18.000Z"));
            mostPWCMovie.Language.ShouldBe("en");
            mostPWCMovie.Languages.ShouldNotBeNull();
            mostPWCMovie.Languages!.Count.ShouldBe(1);
            mostPWCMovie.Languages!.ShouldBe(["en"], Case.Sensitive);

            mostPWCMovie!.AvailableTranslations.ShouldNotBeNull();
            mostPWCMovie!.AvailableTranslations!.Count.ShouldBe(34);
            mostPWCMovie!.AvailableTranslations!.ShouldBe([
                "ar", "bg", "cs", "da", "de", "el", "en", "es", "fa", "fi", "fr", "he", "hi", "hr", "hu", "id",
                "it", "ja", "ka", "ko", "nl", "no", "pl", "pt", "ro", "ru", "sl", "sv", "th", "tl", "tr", "uk",
                "vi", "zh"
            ], Case.Sensitive);

            mostPWCMovie.Genres.ShouldNotBeNull();
            mostPWCMovie.Genres!.Count.ShouldBe(3);
            mostPWCMovie.Genres!.ShouldBe([
                "thriller", "crime", "action"
            ], Case.Sensitive);

            mostPWCMovie.Certification.ShouldBe("R");
        }
    }
}

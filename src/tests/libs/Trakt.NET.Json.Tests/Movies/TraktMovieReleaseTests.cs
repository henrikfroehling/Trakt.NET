namespace TraktNET.Json.Movies
{
    public sealed class TraktMovieReleaseTests
    {
        [Fact]
        public void TestTraktMovieReleaseConstructor()
        {
            var movieRelease = new TraktMovieRelease();

            movieRelease.Country.ShouldBeNull();
            movieRelease.Certification.ShouldBeNull();
            movieRelease.ReleaseDate.ShouldBeNull();
            movieRelease.ReleaseType.ShouldBeNull();
            movieRelease.Note.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktMovieReleaseFromJson()
        {
            TraktMovieRelease? movieRelease = await TraktTestUtility.DeserializeJsonAsync<TraktMovieRelease>("Movies\\movierelease.json");

            movieRelease.ShouldNotBeNull();

            movieRelease!.Country.ShouldBe("fr");
            movieRelease!.Certification.ShouldBe("12");

#if NET7_0_OR_GREATER
            movieRelease!.ReleaseDate.ShouldBe(TestUtility.ParseDate("2023-04-22"));
#else
            movieRelease!.ReleaseDate.ShouldBe(TestUtility.ParseUTCDateTime("2023-04-22T00:00:00.000Z"));
#endif

            movieRelease!.ReleaseType.ShouldBe(TraktReleaseType.Premiere);
            movieRelease!.Note.ShouldBe("Disneyland Paris");
        }

        [Fact]
        public async Task TestTraktMovieReleasesFromJson()
        {
            IReadOnlyList<TraktMovieRelease>? movieReleases = await TraktTestUtility.DeserializeJsonListAsync<TraktMovieRelease>("Movies\\moviereleases.json");

            movieReleases.ShouldNotBeNull();
            movieReleases!.Count.ShouldBe(2);

            TraktMovieRelease movieRelease = movieReleases![0];

            movieRelease.ShouldNotBeNull();

            movieRelease.Country.ShouldBe("fr");
            movieRelease.Certification.ShouldBe("12");

#if NET7_0_OR_GREATER
            movieRelease.ReleaseDate.ShouldBe(TestUtility.ParseDate("2023-04-22"));
#else
            movieRelease.ReleaseDate.ShouldBe(TestUtility.ParseUTCDateTime("2023-04-22T00:00:00.000Z"));
#endif

            movieRelease.ReleaseType.ShouldBe(TraktReleaseType.Premiere);
            movieRelease.Note.ShouldBe("Disneyland Paris");

            // --------------------------------------------------------------------------------------------

            movieRelease = movieReleases![1];

            movieRelease.ShouldNotBeNull();

            movieRelease.Country.ShouldBe("us");
            movieRelease.Certification.ShouldBe("PG-13");

#if NET7_0_OR_GREATER
            movieRelease.ReleaseDate.ShouldBe(TestUtility.ParseDate("2023-04-27"));
#else
            movieRelease.ReleaseDate.ShouldBe(TestUtility.ParseUTCDateTime("2023-04-27T00:00:00.000Z"));
#endif

            movieRelease.ReleaseType.ShouldBe(TraktReleaseType.Premiere);
            movieRelease.Note.ShouldBe("El Capitan Theatre");
        }
    }
}

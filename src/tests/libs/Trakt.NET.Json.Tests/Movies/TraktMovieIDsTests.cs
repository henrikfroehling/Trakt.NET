namespace TraktNET.Json.Movies
{
    public sealed class TraktMovieIDsTests
    {
        [Fact]
        public void TestTraktMovieIDsConstructor()
        {
            var movieIDs = new TraktMovieIDs();

            movieIDs.Trakt.ShouldBeNull();
            movieIDs.Slug.ShouldBeNull();
            movieIDs.IMDB.ShouldBeNull();
            movieIDs.TMDB.ShouldBeNull();

            movieIDs.HasAnyID.ShouldBe(false);
            movieIDs.BestID.ShouldBeEmpty();
        }

        [Fact]
        public async Task TestTraktMovieIDsFromJson()
        {
            TraktMovieIDs? movieIDs = await TraktTestUtility.DeserializeJsonAsync<TraktMovieIDs>("Movies\\movieids.json");

            movieIDs.ShouldNotBeNull();

            movieIDs!.Trakt.ShouldBe(293990U);
            movieIDs!.Slug.ShouldBe("guardians-of-the-galaxy-volume-3-2023");
            movieIDs!.IMDB.ShouldBe("tt6791350");
            movieIDs!.TMDB.ShouldBe(447365U);

            movieIDs!.HasAnyID.ShouldBe(true);
            movieIDs!.BestID.ShouldBe("guardians-of-the-galaxy-volume-3-2023");
        }
    }
}

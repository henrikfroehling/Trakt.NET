namespace TraktNET.Json.Movies
{
    public sealed class TraktMovieIdsTests
    {
        [Fact]
        public void TestTraktMovieIdsConstructor()
        {
            var movieIds = new TraktMovieIds();

            movieIds.Trakt.Should().BeNull();
            movieIds.Slug.Should().BeNull();
            movieIds.IMDB.Should().BeNull();
            movieIds.TMDB.Should().BeNull();

            movieIds.HasAnyID.Should().BeFalse();
            movieIds.BestID.Should().BeEmpty();
        }

        [Fact]
        public async Task TestTraktMovieIdsFromJson()
        {
            TraktMovieIds? movieIds = await TestUtility.DeserializeJsonAsync<TraktMovieIds>("Movies\\movieids.json");

            movieIds.Should().NotBeNull();

            movieIds!.Trakt.Should().Be(293990U);
            movieIds!.Slug.Should().Be("guardians-of-the-galaxy-volume-3-2023");
            movieIds!.IMDB.Should().Be("tt6791350");
            movieIds!.TMDB.Should().Be(447365U);

            movieIds!.HasAnyID.Should().BeTrue();
            movieIds!.BestID.Should().Be("293990");
        }
    }
}

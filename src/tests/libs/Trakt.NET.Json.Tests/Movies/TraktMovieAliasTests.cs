namespace TraktNET.Json.Movies
{
    public sealed class TraktMovieAliasTests
    {
        [Fact]
        public void TestTraktMovieAliasConstructor()
        {
            var movieAlias = new TraktMovieAlias();

            movieAlias.Title.ShouldBeNull();
            movieAlias.Country.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktMovieAliasFromJson()
        {
            TraktMovieAlias? movieAlias = await TraktTestUtility.DeserializeJsonAsync<TraktMovieAlias>("Movies\\moviealias.json");

            movieAlias.ShouldNotBeNull();

            movieAlias!.Title.ShouldBe("Les Gardiens de la Galaxie 3");
            movieAlias!.Country.ShouldBe("fr");
        }

        [Fact]
        public async Task TestTraktMovieAliasesFromJson()
        {
            IReadOnlyList<TraktMovieAlias>? movieAliases = await TraktTestUtility.DeserializeJsonListAsync<TraktMovieAlias>("Movies\\moviealiases.json");

            movieAliases.ShouldNotBeNull();
            movieAliases!.Count.ShouldBe(2);

            TraktMovieAlias movieAlias = movieAliases![0];

            movieAlias.ShouldNotBeNull();

            movieAlias.Title.ShouldBe("Les Gardiens de la Galaxie 3");
            movieAlias.Country.ShouldBe("fr");

            // --------------------------------------------------------------------------------------------

            movieAlias = movieAliases![1];

            movieAlias.ShouldNotBeNull();

            movieAlias.Title.ShouldBe("Guardians of the Galaxy Vol. 3");
            movieAlias.Country.ShouldBe("us");
        }
    }
}

namespace TraktNET.Json.Shows
{
    public sealed class TraktShowIdsTests
    {
        [Fact]
        public void TestTraktShowIdsConstructor()
        {
            var showIds = new TraktShowIds();

            showIds.Trakt.Should().BeNull();
            showIds.Slug.Should().BeNull();
            showIds.TVDB.Should().BeNull();
            showIds.IMDB.Should().BeNull();
            showIds.TMDB.Should().BeNull();

            showIds.HasAnyID.Should().BeFalse();
            showIds.BestID.Should().BeEmpty();
        }

        [Fact]
        public async Task TestTraktShowIdsFromJson()
        {
            TraktShowIds? showIds = await TestUtility.DeserializeJsonAsync<TraktShowIds>("Shows\\showids.json");

            showIds.Should().NotBeNull();

            showIds!.Trakt.Should().Be(1390U);
            showIds!.Slug.Should().Be("game-of-thrones");
            showIds!.TVDB.Should().Be(121361U);
            showIds!.IMDB.Should().Be("tt0944947");
            showIds!.TMDB.Should().Be(1399U);

            showIds!.HasAnyID.Should().BeTrue();
            showIds!.BestID.Should().Be("1390");
        }
    }
}

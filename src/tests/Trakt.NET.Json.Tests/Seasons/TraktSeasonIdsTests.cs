namespace TraktNET.Json.Seasons
{
    public sealed class TraktSeasonIdsTests
    {
        [Fact]
        public void TestTraktSeasonIdsConstructor()
        {
            var seasonIds = new TraktSeasonIds();

            seasonIds.Trakt.Should().BeNull();
            seasonIds.TVDB.Should().BeNull();
            seasonIds.TMDB.Should().BeNull();

            seasonIds.HasAnyID.Should().BeFalse();
            seasonIds.BestID.Should().BeEmpty();
        }

        [Fact]
        public async Task TestTraktSeasonIdsFromJson()
        {
            TraktSeasonIds? seasonIds = await TestUtility.DeserializeJsonAsync<TraktSeasonIds>("Seasons\\seasonids.json");

            seasonIds.Should().NotBeNull();

            seasonIds!.Trakt.Should().Be(3963U);
            seasonIds!.TVDB.Should().Be(364731U);
            seasonIds!.TMDB.Should().Be(3624U);

            seasonIds!.HasAnyID.Should().BeTrue();
            seasonIds!.BestID.Should().Be("3963");
        }
    }
}

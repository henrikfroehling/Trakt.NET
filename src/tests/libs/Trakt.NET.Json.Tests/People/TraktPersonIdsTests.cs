namespace TraktNET.Json.People
{
    public sealed class TraktPersonIdsTests
    {
        [Fact]
        public void TestTraktPersonIdsConstructor()
        {
            var personIds = new TraktPersonIds();

            personIds.Trakt.Should().BeNull();
            personIds.Slug.Should().BeNull();
            personIds.IMDB.Should().BeNull();
            personIds.TMDB.Should().BeNull();

            personIds.HasAnyID.Should().BeFalse();
            personIds.BestID.Should().BeEmpty();
        }

        [Fact]
        public async Task TestTraktPersonIdsFromJson()
        {
            TraktPersonIds? personIds = await TestUtility.DeserializeJsonAsync<TraktPersonIds>("People\\personids.json");

            personIds.Should().NotBeNull();

            personIds!.Trakt.Should().Be(297737U);
            personIds!.Slug.Should().Be("bryan-cranston");
            personIds!.IMDB.Should().Be("nm0186505");
            personIds!.TMDB.Should().Be(17419U);

            personIds!.HasAnyID.Should().BeTrue();
            personIds!.BestID.Should().Be("297737");
        }
    }
}

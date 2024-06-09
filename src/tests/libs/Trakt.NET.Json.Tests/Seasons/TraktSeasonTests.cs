namespace TraktNET.Json.Seasons
{
    public sealed class TraktSeasonTests
    {
        [Fact]
        public void TestTraktSeasonConstructor()
        {
            var season = new TraktSeason();

            season.Number.Should().BeNull();
            season.Ids.Should().BeNull();
            season.Rating.Should().BeNull();
            season.Votes.Should().BeNull();
            season.EpisodeCount.Should().BeNull();
            season.AiredEpisodes.Should().BeNull();
            season.Title.Should().BeNull();
            season.Overview.Should().BeNull();
            season.FirstAired.Should().BeNull();
            season.UpdatedAt.Should().BeNull();
            season.Network.Should().BeNull();
            season.Episodes.Should().BeNull();
        }

        [Fact]
        public async Task TestTraktSeasonFromJsonMinimal()
        {
            TraktSeasonMinimal? season = await TestUtility.DeserializeJsonAsync<TraktSeasonMinimal>("Seasons\\season_minimal.json");

            season.Should().NotBeNull();

            season!.Number.Should().Be(1U);

            season!.Ids.Should().NotBeNull();
            season!.Ids!.Trakt.Should().Be(3963U);
            season!.Ids!.TVDB.Should().Be(364731U);
            season!.Ids!.TMDB.Should().Be(3624U);
            season!.Ids!.HasAnyID.Should().BeTrue();
            season!.Ids!.BestID.Should().Be("3963");
        }

        [Fact]
        public async Task TestTraktSeasonFromJson()
        {
            TraktSeason? season = await TestUtility.DeserializeJsonAsync<TraktSeason>("Seasons\\season.json");

            season.Should().NotBeNull();

            season!.Number.Should().Be(1U);

            season!.Ids.Should().NotBeNull();
            season!.Ids!.Trakt.Should().Be(3963U);
            season!.Ids!.TVDB.Should().Be(364731U);
            season!.Ids!.TMDB.Should().Be(3624U);
            season!.Ids!.HasAnyID.Should().BeTrue();
            season!.Ids!.BestID.Should().Be("3963");

            season!.Rating.Should().Be(8.96076f);
            season!.Votes.Should().Be(4970U);
            season!.EpisodeCount.Should().Be(10U);
            season!.AiredEpisodes.Should().Be(10U);
            season!.Title.Should().Be("Season 1");
            season!.Overview.Should().Be("Trouble is brewing in the Seven Kingdoms of Westeros.");
            season!.FirstAired.Should().Be(TestUtility.ParseUTCDateTime("2011-04-18T01:00:00.000Z"));
            season!.UpdatedAt.Should().Be(TestUtility.ParseUTCDateTime("2024-03-23T06:24:59.000Z"));
            season!.Network.Should().Be("HBO");
            season!.Episodes.Should().BeNull();
        }

        [Fact]
        public async Task TestTraktSeasonFromJsonWithEpisodes()
        {
            TraktSeason? season = await TestUtility.DeserializeJsonAsync<TraktSeason>("Seasons\\season_with_episodes.json");

            season.Should().NotBeNull();

            season!.Number.Should().Be(1U);

            season!.Ids.Should().NotBeNull();
            season!.Ids!.Trakt.Should().Be(3963U);
            season!.Ids!.TVDB.Should().Be(364731U);
            season!.Ids!.TMDB.Should().Be(3624U);
            season!.Ids!.HasAnyID.Should().BeTrue();
            season!.Ids!.BestID.Should().Be("3963");

            season!.Rating.Should().Be(8.96076f);
            season!.Votes.Should().Be(4970U);
            season!.EpisodeCount.Should().Be(10U);
            season!.AiredEpisodes.Should().Be(10U);
            season!.Title.Should().Be("Season 1");
            season!.Overview.Should().Be("Trouble is brewing in the Seven Kingdoms of Westeros.");
            season!.FirstAired.Should().Be(TestUtility.ParseUTCDateTime("2011-04-18T01:00:00.000Z"));
            season!.UpdatedAt.Should().Be(TestUtility.ParseUTCDateTime("2024-03-23T06:24:59.000Z"));
            season!.Network.Should().Be("HBO");
            season!.Episodes.Should().NotBeNull().And.HaveCount(10);

            IList<TraktEpisode> episodes = season!.Episodes!;

            episodes[0].Should().NotBeNull();
            episodes[0].Season.Should().Be(1U);
            episodes[0].Number.Should().Be(1U);
            episodes[0].Title.Should().Be("Winter Is Coming");
            episodes[0].Ids.Should().NotBeNull();
            episodes[0].Ids!.Trakt.Should().Be(73640U);
            episodes[0].Ids!.TVDB.Should().Be(3254641U);
            episodes[0].Ids!.IMDB.Should().Be("tt1480055");
            episodes[0].Ids!.TMDB.Should().Be(63056U);

            episodes[1].Should().NotBeNull();
            episodes[1].Season.Should().Be(1U);
            episodes[1].Number.Should().Be(2U);
            episodes[1].Title.Should().Be("The Kingsroad");
            episodes[1].Ids.Should().NotBeNull();
            episodes[1].Ids!.Trakt.Should().Be(73641U);
            episodes[1].Ids!.TVDB.Should().Be(3436411U);
            episodes[1].Ids!.IMDB.Should().Be("tt1668746");
            episodes[1].Ids!.TMDB.Should().Be(63057U);

            episodes[2].Should().NotBeNull();
            episodes[2].Season.Should().Be(1U);
            episodes[2].Number.Should().Be(3U);
            episodes[2].Title.Should().Be("Lord Snow");
            episodes[2].Ids.Should().NotBeNull();
            episodes[2].Ids!.Trakt.Should().Be(73642U);
            episodes[2].Ids!.TVDB.Should().Be(3436421U);
            episodes[2].Ids!.IMDB.Should().Be("tt1829962");
            episodes[2].Ids!.TMDB.Should().Be(63058U);

            episodes[3].Should().NotBeNull();
            episodes[3].Season.Should().Be(1U);
            episodes[3].Number.Should().Be(4U);
            episodes[3].Title.Should().Be("Cripples, Bastards, and Broken Things");
            episodes[3].Ids.Should().NotBeNull();
            episodes[3].Ids!.Trakt.Should().Be(73643U);
            episodes[3].Ids!.TVDB.Should().Be(3436431U);
            episodes[3].Ids!.IMDB.Should().Be("tt1829963");
            episodes[3].Ids!.TMDB.Should().Be(63059U);

            episodes[4].Should().NotBeNull();
            episodes[4].Season.Should().Be(1U);
            episodes[4].Number.Should().Be(5U);
            episodes[4].Title.Should().Be("The Wolf and the Lion");
            episodes[4].Ids.Should().NotBeNull();
            episodes[4].Ids!.Trakt.Should().Be(73644U);
            episodes[4].Ids!.TVDB.Should().Be(3436441U);
            episodes[4].Ids!.IMDB.Should().Be("tt1829964");
            episodes[4].Ids!.TMDB.Should().Be(63060U);

            episodes[5].Should().NotBeNull();
            episodes[5].Season.Should().Be(1U);
            episodes[5].Number.Should().Be(6U);
            episodes[5].Title.Should().Be("A Golden Crown");
            episodes[5].Ids.Should().NotBeNull();
            episodes[5].Ids!.Trakt.Should().Be(73645U);
            episodes[5].Ids!.TVDB.Should().Be(3436451U);
            episodes[5].Ids!.IMDB.Should().Be("tt1837862");
            episodes[5].Ids!.TMDB.Should().Be(63061U);

            episodes[6].Should().NotBeNull();
            episodes[6].Season.Should().Be(1U);
            episodes[6].Number.Should().Be(7U);
            episodes[6].Title.Should().Be("You Win or You Die");
            episodes[6].Ids.Should().NotBeNull();
            episodes[6].Ids!.Trakt.Should().Be(73646U);
            episodes[6].Ids!.TVDB.Should().Be(3436461U);
            episodes[6].Ids!.IMDB.Should().Be("tt1837863");
            episodes[6].Ids!.TMDB.Should().Be(63062U);

            episodes[7].Should().NotBeNull();
            episodes[7].Season.Should().Be(1U);
            episodes[7].Number.Should().Be(8U);
            episodes[7].Title.Should().Be("The Pointy End");
            episodes[7].Ids.Should().NotBeNull();
            episodes[7].Ids!.Trakt.Should().Be(73647U);
            episodes[7].Ids!.TVDB.Should().Be(3360391U);
            episodes[7].Ids!.IMDB.Should().Be("tt1837864");
            episodes[7].Ids!.TMDB.Should().Be(63063U);

            episodes[8].Should().NotBeNull();
            episodes[8].Season.Should().Be(1U);
            episodes[8].Number.Should().Be(9U);
            episodes[8].Title.Should().Be("Baelor");
            episodes[8].Ids.Should().NotBeNull();
            episodes[8].Ids!.Trakt.Should().Be(73648U);
            episodes[8].Ids!.TVDB.Should().Be(4063481U);
            episodes[8].Ids!.IMDB.Should().Be("tt1851398");
            episodes[8].Ids!.TMDB.Should().Be(63064U);

            episodes[9].Should().NotBeNull();
            episodes[9].Season.Should().Be(1U);
            episodes[9].Number.Should().Be(10U);
            episodes[9].Title.Should().Be("Fire and Blood");
            episodes[9].Ids.Should().NotBeNull();
            episodes[9].Ids!.Trakt.Should().Be(73649U);
            episodes[9].Ids!.TVDB.Should().Be(4063491U);
            episodes[9].Ids!.IMDB.Should().Be("tt1851397");
            episodes[9].Ids!.TMDB.Should().Be(63065U);
        }
    }
}

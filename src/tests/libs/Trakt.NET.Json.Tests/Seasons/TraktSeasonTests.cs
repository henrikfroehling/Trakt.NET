namespace TraktNET.Json.Seasons
{
    public sealed class TraktSeasonTests
    {
        [Fact]
        public void TestTraktSeasonConstructor()
        {
            var season = new TraktSeason();

            season.Number.ShouldBeNull();
            season.IDs.ShouldBeNull();
            season.Rating.ShouldBeNull();
            season.Votes.ShouldBeNull();
            season.EpisodeCount.ShouldBeNull();
            season.AiredEpisodes.ShouldBeNull();
            season.Title.ShouldBeNull();
            season.Overview.ShouldBeNull();
            season.FirstAired.ShouldBeNull();
            season.UpdatedAt.ShouldBeNull();
            season.Network.ShouldBeNull();
            season.Episodes.ShouldBeNull();

            season.ToString().ShouldBeEmpty();
        }

        [Fact]
        public async Task TestTraktSeasonFromJsonMinimal()
        {
            TraktSeasonMinimal? season = await TestUtility.DeserializeJsonAsync<TraktSeasonMinimal>("Seasons\\season_minimal.json");

            season.ShouldNotBeNull();

            season!.Number.ShouldBe(1U);

            season!.IDs.ShouldNotBeNull();
            season!.IDs!.Trakt.ShouldBe(3963U);
            season!.IDs!.TVDB.ShouldBe(364731U);
            season!.IDs!.TMDB.ShouldBe(3624U);
            season!.IDs!.HasAnyID.ShouldBe(true);
            season!.IDs!.BestID.ShouldBe("3963");
        }

        [Fact]
        public async Task TestTraktSeasonFromJsonMinimalWithImages()
        {
            TraktSeasonMinimal? season = await TestUtility.DeserializeJsonAsync<TraktSeasonMinimal>("Seasons\\season_minimal_images.json");

            season.ShouldNotBeNull();

            season!.Number.ShouldBe(1U);

            season!.IDs.ShouldNotBeNull();
            season!.IDs!.Trakt.ShouldBe(3963U);
            season!.IDs!.TVDB.ShouldBe(364731U);
            season!.IDs!.TMDB.ShouldBe(3624U);
            season!.IDs!.HasAnyID.ShouldBe(true);
            season!.IDs!.BestID.ShouldBe("3963");

            season!.Images.ShouldNotBeNull();

            season!.Images!.Poster.ShouldNotBeNull();
            season!.Images!.Poster!.Count.ShouldBe(1);
            season!.Images!.Poster!.ShouldBe([ "walter-r2.trakt.tv/images/seasons/000/003/963/posters/thumb/15e611179e.jpg.webp" ]);

            season!.Images!.Thumb.ShouldNotBeNull();
            season!.Images!.Thumb!.Count.ShouldBe(1);
            season!.Images!.Thumb!.ShouldBe([ "walter-r2.trakt.tv/images/seasons/000/003/963/thumbs/medium/6c996deed7.jpg.webp" ]);
        }

        [Fact]
        public async Task TestTraktSeasonFromJsonFull()
        {
            TraktSeason? season = await TestUtility.DeserializeJsonAsync<TraktSeason>("Seasons\\season_full.json");

            season.ShouldNotBeNull();

            season!.Number.ShouldBe(1U);

            season!.IDs.ShouldNotBeNull();
            season!.IDs!.Trakt.ShouldBe(3963U);
            season!.IDs!.TVDB.ShouldBe(364731U);
            season!.IDs!.TMDB.ShouldBe(3624U);
            season!.IDs!.HasAnyID.ShouldBe(true);
            season!.IDs!.BestID.ShouldBe("3963");

            season!.Rating.ShouldBe(8.96076f);
            season!.Votes.ShouldBe(4970U);
            season!.EpisodeCount.ShouldBe(10U);
            season!.AiredEpisodes.ShouldBe(10U);
            season!.Title.ShouldBe("Season 1");
            season!.Overview.ShouldBe("Trouble is brewing in the Seven Kingdoms of Westeros.");
            season!.FirstAired.ShouldBe(TestUtility.ParseUTCDateTime("2011-04-18T01:00:00.000Z"));
            season!.UpdatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2024-03-23T06:24:59.000Z"));
            season!.Network.ShouldBe("HBO");
            season!.Episodes.ShouldBeNull();

            season!.ToString().ShouldBe("S01: Season 1");
        }

        [Fact]
        public async Task TestTraktSeasonFromJsonFullWithImages()
        {
            TraktSeason? season = await TestUtility.DeserializeJsonAsync<TraktSeason>("Seasons\\season_full_images.json");

            season.ShouldNotBeNull();

            season!.Number.ShouldBe(1U);

            season!.IDs.ShouldNotBeNull();
            season!.IDs!.Trakt.ShouldBe(3963U);
            season!.IDs!.TVDB.ShouldBe(364731U);
            season!.IDs!.TMDB.ShouldBe(3624U);
            season!.IDs!.HasAnyID.ShouldBe(true);
            season!.IDs!.BestID.ShouldBe("3963");

            season!.Rating.ShouldBe(8.96076f);
            season!.Votes.ShouldBe(4970U);
            season!.EpisodeCount.ShouldBe(10U);
            season!.AiredEpisodes.ShouldBe(10U);
            season!.Title.ShouldBe("Season 1");
            season!.Overview.ShouldBe("Trouble is brewing in the Seven Kingdoms of Westeros.");
            season!.FirstAired.ShouldBe(TestUtility.ParseUTCDateTime("2011-04-18T01:00:00.000Z"));
            season!.UpdatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2024-03-23T06:24:59.000Z"));
            season!.Network.ShouldBe("HBO");
            season!.Episodes.ShouldBeNull();

            season!.Images.ShouldNotBeNull();

            season!.Images!.Poster.ShouldNotBeNull();
            season!.Images!.Poster!.Count.ShouldBe(1);
            season!.Images!.Poster!.ShouldBe([ "walter-r2.trakt.tv/images/seasons/000/003/963/posters/thumb/15e611179e.jpg.webp" ]);

            season!.Images!.Thumb.ShouldNotBeNull();
            season!.Images!.Thumb!.Count.ShouldBe(1);
            season!.Images!.Thumb!.ShouldBe([ "walter-r2.trakt.tv/images/seasons/000/003/963/thumbs/medium/6c996deed7.jpg.webp" ]);

            season!.ToString().ShouldBe("S01: Season 1");
        }

        [Fact]
        public async Task TestTraktSeasonFromJsonFullWithEpisodes()
        {
            TraktSeason? season = await TestUtility.DeserializeJsonAsync<TraktSeason>("Seasons\\season_full_episodes.json");

            season.ShouldNotBeNull();

            season!.Number.ShouldBe(1U);

            season!.IDs.ShouldNotBeNull();
            season!.IDs!.Trakt.ShouldBe(3963U);
            season!.IDs!.TVDB.ShouldBe(364731U);
            season!.IDs!.TMDB.ShouldBe(3624U);
            season!.IDs!.HasAnyID.ShouldBe(true);
            season!.IDs!.BestID.ShouldBe("3963");

            season!.Rating.ShouldBe(8.96076f);
            season!.Votes.ShouldBe(4970U);
            season!.EpisodeCount.ShouldBe(10U);
            season!.AiredEpisodes.ShouldBe(10U);
            season!.Title.ShouldBe("Season 1");
            season!.Overview.ShouldBe("Trouble is brewing in the Seven Kingdoms of Westeros.");
            season!.FirstAired.ShouldBe(TestUtility.ParseUTCDateTime("2011-04-18T01:00:00.000Z"));
            season!.UpdatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2024-03-23T06:24:59.000Z"));
            season!.Network.ShouldBe("HBO");
            season!.Episodes.ShouldNotBeNull();
            season!.Episodes!.Count.ShouldBe(10);

            season!.ToString().ShouldBe("S01: Season 1");

            List<TraktEpisode> episodes = season!.Episodes!;

            episodes[0].ShouldNotBeNull();
            episodes[0].Season.ShouldBe(1U);
            episodes[0].Number.ShouldBe(1U);
            episodes[0].Title.ShouldBe("Winter Is Coming");
            episodes[0].IDs.ShouldNotBeNull();
            episodes[0].IDs!.Trakt.ShouldBe(73640U);
            episodes[0].IDs!.TVDB.ShouldBe(3254641U);
            episodes[0].IDs!.IMDB.ShouldBe("tt1480055");
            episodes[0].IDs!.TMDB.ShouldBe(63056U);

            episodes[1].ShouldNotBeNull();
            episodes[1].Season.ShouldBe(1U);
            episodes[1].Number.ShouldBe(2U);
            episodes[1].Title.ShouldBe("The Kingsroad");
            episodes[1].IDs.ShouldNotBeNull();
            episodes[1].IDs!.Trakt.ShouldBe(73641U);
            episodes[1].IDs!.TVDB.ShouldBe(3436411U);
            episodes[1].IDs!.IMDB.ShouldBe("tt1668746");
            episodes[1].IDs!.TMDB.ShouldBe(63057U);

            episodes[2].ShouldNotBeNull();
            episodes[2].Season.ShouldBe(1U);
            episodes[2].Number.ShouldBe(3U);
            episodes[2].Title.ShouldBe("Lord Snow");
            episodes[2].IDs.ShouldNotBeNull();
            episodes[2].IDs!.Trakt.ShouldBe(73642U);
            episodes[2].IDs!.TVDB.ShouldBe(3436421U);
            episodes[2].IDs!.IMDB.ShouldBe("tt1829962");
            episodes[2].IDs!.TMDB.ShouldBe(63058U);

            episodes[3].ShouldNotBeNull();
            episodes[3].Season.ShouldBe(1U);
            episodes[3].Number.ShouldBe(4U);
            episodes[3].Title.ShouldBe("Cripples, Bastards, and Broken Things");
            episodes[3].IDs.ShouldNotBeNull();
            episodes[3].IDs!.Trakt.ShouldBe(73643U);
            episodes[3].IDs!.TVDB.ShouldBe(3436431U);
            episodes[3].IDs!.IMDB.ShouldBe("tt1829963");
            episodes[3].IDs!.TMDB.ShouldBe(63059U);

            episodes[4].ShouldNotBeNull();
            episodes[4].Season.ShouldBe(1U);
            episodes[4].Number.ShouldBe(5U);
            episodes[4].Title.ShouldBe("The Wolf and the Lion");
            episodes[4].IDs.ShouldNotBeNull();
            episodes[4].IDs!.Trakt.ShouldBe(73644U);
            episodes[4].IDs!.TVDB.ShouldBe(3436441U);
            episodes[4].IDs!.IMDB.ShouldBe("tt1829964");
            episodes[4].IDs!.TMDB.ShouldBe(63060U);

            episodes[5].ShouldNotBeNull();
            episodes[5].Season.ShouldBe(1U);
            episodes[5].Number.ShouldBe(6U);
            episodes[5].Title.ShouldBe("A Golden Crown");
            episodes[5].IDs.ShouldNotBeNull();
            episodes[5].IDs!.Trakt.ShouldBe(73645U);
            episodes[5].IDs!.TVDB.ShouldBe(3436451U);
            episodes[5].IDs!.IMDB.ShouldBe("tt1837862");
            episodes[5].IDs!.TMDB.ShouldBe(63061U);

            episodes[6].ShouldNotBeNull();
            episodes[6].Season.ShouldBe(1U);
            episodes[6].Number.ShouldBe(7U);
            episodes[6].Title.ShouldBe("You Win or You Die");
            episodes[6].IDs.ShouldNotBeNull();
            episodes[6].IDs!.Trakt.ShouldBe(73646U);
            episodes[6].IDs!.TVDB.ShouldBe(3436461U);
            episodes[6].IDs!.IMDB.ShouldBe("tt1837863");
            episodes[6].IDs!.TMDB.ShouldBe(63062U);

            episodes[7].ShouldNotBeNull();
            episodes[7].Season.ShouldBe(1U);
            episodes[7].Number.ShouldBe(8U);
            episodes[7].Title.ShouldBe("The Pointy End");
            episodes[7].IDs.ShouldNotBeNull();
            episodes[7].IDs!.Trakt.ShouldBe(73647U);
            episodes[7].IDs!.TVDB.ShouldBe(3360391U);
            episodes[7].IDs!.IMDB.ShouldBe("tt1837864");
            episodes[7].IDs!.TMDB.ShouldBe(63063U);

            episodes[8].ShouldNotBeNull();
            episodes[8].Season.ShouldBe(1U);
            episodes[8].Number.ShouldBe(9U);
            episodes[8].Title.ShouldBe("Baelor");
            episodes[8].IDs.ShouldNotBeNull();
            episodes[8].IDs!.Trakt.ShouldBe(73648U);
            episodes[8].IDs!.TVDB.ShouldBe(4063481U);
            episodes[8].IDs!.IMDB.ShouldBe("tt1851398");
            episodes[8].IDs!.TMDB.ShouldBe(63064U);

            episodes[9].ShouldNotBeNull();
            episodes[9].Season.ShouldBe(1U);
            episodes[9].Number.ShouldBe(10U);
            episodes[9].Title.ShouldBe("Fire and Blood");
            episodes[9].IDs.ShouldNotBeNull();
            episodes[9].IDs!.Trakt.ShouldBe(73649U);
            episodes[9].IDs!.TVDB.ShouldBe(4063491U);
            episodes[9].IDs!.IMDB.ShouldBe("tt1851397");
            episodes[9].IDs!.TMDB.ShouldBe(63065U);
        }

        [Fact]
        public async Task TestTraktSeasonFromJsonFullWithEpisodesAndImages()
        {
            TraktSeason? season = await TestUtility.DeserializeJsonAsync<TraktSeason>("Seasons\\season_full_episodes_images.json");

            season.ShouldNotBeNull();

            season!.Number.ShouldBe(1U);

            season!.IDs.ShouldNotBeNull();
            season!.IDs!.Trakt.ShouldBe(3963U);
            season!.IDs!.TVDB.ShouldBe(364731U);
            season!.IDs!.TMDB.ShouldBe(3624U);
            season!.IDs!.HasAnyID.ShouldBe(true);
            season!.IDs!.BestID.ShouldBe("3963");

            season!.Rating.ShouldBe(8.96076f);
            season!.Votes.ShouldBe(4970U);
            season!.EpisodeCount.ShouldBe(10U);
            season!.AiredEpisodes.ShouldBe(10U);
            season!.Title.ShouldBe("Season 1");
            season!.Overview.ShouldBe("Trouble is brewing in the Seven Kingdoms of Westeros.");
            season!.FirstAired.ShouldBe(TestUtility.ParseUTCDateTime("2011-04-18T01:00:00.000Z"));
            season!.UpdatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2024-03-23T06:24:59.000Z"));
            season!.Network.ShouldBe("HBO");
            season!.Episodes.ShouldNotBeNull();
            season!.Episodes!.Count.ShouldBe(10);

            season!.Images.ShouldNotBeNull();

            season!.Images!.Poster.ShouldNotBeNull();
            season!.Images!.Poster!.Count.ShouldBe(1);
            season!.Images!.Poster!.ShouldBe([ "walter-r2.trakt.tv/images/seasons/000/003/963/posters/thumb/15e611179e.jpg.webp" ]);

            season!.Images!.Thumb.ShouldNotBeNull();
            season!.Images!.Thumb!.Count.ShouldBe(1);
            season!.Images!.Thumb!.ShouldBe([ "walter-r2.trakt.tv/images/seasons/000/003/963/thumbs/medium/6c996deed7.jpg.webp" ]);

            season!.ToString().ShouldBe("S01: Season 1");

            List<TraktEpisode> episodes = season!.Episodes!;

            episodes[0].ShouldNotBeNull();
            episodes[0].Season.ShouldBe(1U);
            episodes[0].Number.ShouldBe(1U);
            episodes[0].Title.ShouldBe("Winter Is Coming");
            episodes[0].IDs.ShouldNotBeNull();
            episodes[0].IDs!.Trakt.ShouldBe(73640U);
            episodes[0].IDs!.TVDB.ShouldBe(3254641U);
            episodes[0].IDs!.IMDB.ShouldBe("tt1480055");
            episodes[0].IDs!.TMDB.ShouldBe(63056U);

            episodes[1].ShouldNotBeNull();
            episodes[1].Season.ShouldBe(1U);
            episodes[1].Number.ShouldBe(2U);
            episodes[1].Title.ShouldBe("The Kingsroad");
            episodes[1].IDs.ShouldNotBeNull();
            episodes[1].IDs!.Trakt.ShouldBe(73641U);
            episodes[1].IDs!.TVDB.ShouldBe(3436411U);
            episodes[1].IDs!.IMDB.ShouldBe("tt1668746");
            episodes[1].IDs!.TMDB.ShouldBe(63057U);

            episodes[2].ShouldNotBeNull();
            episodes[2].Season.ShouldBe(1U);
            episodes[2].Number.ShouldBe(3U);
            episodes[2].Title.ShouldBe("Lord Snow");
            episodes[2].IDs.ShouldNotBeNull();
            episodes[2].IDs!.Trakt.ShouldBe(73642U);
            episodes[2].IDs!.TVDB.ShouldBe(3436421U);
            episodes[2].IDs!.IMDB.ShouldBe("tt1829962");
            episodes[2].IDs!.TMDB.ShouldBe(63058U);

            episodes[3].ShouldNotBeNull();
            episodes[3].Season.ShouldBe(1U);
            episodes[3].Number.ShouldBe(4U);
            episodes[3].Title.ShouldBe("Cripples, Bastards, and Broken Things");
            episodes[3].IDs.ShouldNotBeNull();
            episodes[3].IDs!.Trakt.ShouldBe(73643U);
            episodes[3].IDs!.TVDB.ShouldBe(3436431U);
            episodes[3].IDs!.IMDB.ShouldBe("tt1829963");
            episodes[3].IDs!.TMDB.ShouldBe(63059U);

            episodes[4].ShouldNotBeNull();
            episodes[4].Season.ShouldBe(1U);
            episodes[4].Number.ShouldBe(5U);
            episodes[4].Title.ShouldBe("The Wolf and the Lion");
            episodes[4].IDs.ShouldNotBeNull();
            episodes[4].IDs!.Trakt.ShouldBe(73644U);
            episodes[4].IDs!.TVDB.ShouldBe(3436441U);
            episodes[4].IDs!.IMDB.ShouldBe("tt1829964");
            episodes[4].IDs!.TMDB.ShouldBe(63060U);

            episodes[5].ShouldNotBeNull();
            episodes[5].Season.ShouldBe(1U);
            episodes[5].Number.ShouldBe(6U);
            episodes[5].Title.ShouldBe("A Golden Crown");
            episodes[5].IDs.ShouldNotBeNull();
            episodes[5].IDs!.Trakt.ShouldBe(73645U);
            episodes[5].IDs!.TVDB.ShouldBe(3436451U);
            episodes[5].IDs!.IMDB.ShouldBe("tt1837862");
            episodes[5].IDs!.TMDB.ShouldBe(63061U);

            episodes[6].ShouldNotBeNull();
            episodes[6].Season.ShouldBe(1U);
            episodes[6].Number.ShouldBe(7U);
            episodes[6].Title.ShouldBe("You Win or You Die");
            episodes[6].IDs.ShouldNotBeNull();
            episodes[6].IDs!.Trakt.ShouldBe(73646U);
            episodes[6].IDs!.TVDB.ShouldBe(3436461U);
            episodes[6].IDs!.IMDB.ShouldBe("tt1837863");
            episodes[6].IDs!.TMDB.ShouldBe(63062U);

            episodes[7].ShouldNotBeNull();
            episodes[7].Season.ShouldBe(1U);
            episodes[7].Number.ShouldBe(8U);
            episodes[7].Title.ShouldBe("The Pointy End");
            episodes[7].IDs.ShouldNotBeNull();
            episodes[7].IDs!.Trakt.ShouldBe(73647U);
            episodes[7].IDs!.TVDB.ShouldBe(3360391U);
            episodes[7].IDs!.IMDB.ShouldBe("tt1837864");
            episodes[7].IDs!.TMDB.ShouldBe(63063U);

            episodes[8].ShouldNotBeNull();
            episodes[8].Season.ShouldBe(1U);
            episodes[8].Number.ShouldBe(9U);
            episodes[8].Title.ShouldBe("Baelor");
            episodes[8].IDs.ShouldNotBeNull();
            episodes[8].IDs!.Trakt.ShouldBe(73648U);
            episodes[8].IDs!.TVDB.ShouldBe(4063481U);
            episodes[8].IDs!.IMDB.ShouldBe("tt1851398");
            episodes[8].IDs!.TMDB.ShouldBe(63064U);

            episodes[9].ShouldNotBeNull();
            episodes[9].Season.ShouldBe(1U);
            episodes[9].Number.ShouldBe(10U);
            episodes[9].Title.ShouldBe("Fire and Blood");
            episodes[9].IDs.ShouldNotBeNull();
            episodes[9].IDs!.Trakt.ShouldBe(73649U);
            episodes[9].IDs!.TVDB.ShouldBe(4063491U);
            episodes[9].IDs!.IMDB.ShouldBe("tt1851397");
            episodes[9].IDs!.TMDB.ShouldBe(63065U);
        }
    }
}

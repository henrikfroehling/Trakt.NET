namespace TraktNET.Json.Episodes
{
    public sealed class TraktEpisodeTests
    {
        [Fact]
        public void TestTraktEpisodeConstructor()
        {
            var episode = new TraktEpisode();

            episode.Season.ShouldBeNull();
            episode.Number.ShouldBeNull();
            episode.NumberAbsolute.ShouldBeNull();
            episode.Title.ShouldBeNull();
            episode.IDs.ShouldBeNull();
            episode.Overview.ShouldBeNull();
            episode.Rating.ShouldBeNull();
            episode.Votes.ShouldBeNull();
            episode.CommentCount.ShouldBeNull();
            episode.FirstAired.ShouldBeNull();
            episode.UpdatedAt.ShouldBeNull();
            episode.Runtime.ShouldBeNull();
            episode.EpisodeType.ShouldBeNull();
            episode.AvailableTranslations.ShouldBeNull();
            episode.Translations.ShouldBeNull();

            episode.ToString().ShouldBeEmpty();
        }

        [Fact]
        public async Task TestTraktEpisodeFromJsonMinimal()
        {
            TraktEpisodeMinimal? episode = await TestUtility.DeserializeJsonAsync<TraktEpisodeMinimal>("Episodes\\episode_minimal.json");

            episode.ShouldNotBeNull();

            episode!.Season.ShouldBe(1U);
            episode!.Number.ShouldBe(1U);
            episode!.Title.ShouldBe("Winter Is Coming");

            episode!.IDs.ShouldNotBeNull();
            episode!.IDs!.Trakt.ShouldBe(73640U);
            episode!.IDs!.TVDB.ShouldBe(3254641U);
            episode!.IDs!.IMDB.ShouldBe("tt1480055");
            episode!.IDs!.TMDB.ShouldBe(63056U);
            episode!.IDs!.HasAnyID.ShouldBe(true);
            episode!.IDs!.BestID.ShouldBe("73640");

            episode!.ToString().ShouldBe("S01E01: Winter Is Coming");
        }

        [Fact]
        public async Task TestTraktEpisodeFromJsonMinimalWithImages()
        {
            TraktEpisodeMinimal? episode = await TestUtility.DeserializeJsonAsync<TraktEpisodeMinimal>("Episodes\\episode_minimal_images.json");

            episode.ShouldNotBeNull();

            episode!.Season.ShouldBe(1U);
            episode!.Number.ShouldBe(1U);
            episode!.Title.ShouldBe("Winter Is Coming");

            episode!.IDs.ShouldNotBeNull();
            episode!.IDs!.Trakt.ShouldBe(73640U);
            episode!.IDs!.TVDB.ShouldBe(3254641U);
            episode!.IDs!.IMDB.ShouldBe("tt1480055");
            episode!.IDs!.TMDB.ShouldBe(63056U);
            episode!.IDs!.HasAnyID.ShouldBe(true);
            episode!.IDs!.BestID.ShouldBe("73640");

            episode!.Images.ShouldNotBeNull();

            episode!.Images!.Screenshot.ShouldNotBeNull();
            episode!.Images!.Screenshot!.Count.ShouldBe(1);
            episode!.Images!.Screenshot!.ShouldBe([ "walter-r2.trakt.tv/images/episodes/000/073/640/screenshots/medium/66c1ba1793.jpg.webp" ]);

            episode!.ToString().ShouldBe("S01E01: Winter Is Coming");
        }

        [Fact]
        public async Task TestTraktEpisodeFromJsonFull()
        {
            TraktEpisode? episode = await TestUtility.DeserializeJsonAsync<TraktEpisode>("Episodes\\episode_full.json");

            episode.ShouldNotBeNull();

            episode!.Season.ShouldBe(1U);
            episode!.Number.ShouldBe(1U);
            episode!.NumberAbsolute.ShouldBe(1U);
            episode!.Title.ShouldBe("Winter Is Coming");

            episode!.IDs.ShouldNotBeNull();
            episode!.IDs!.Trakt.ShouldBe(73640U);
            episode!.IDs!.TVDB.ShouldBe(3254641U);
            episode!.IDs!.IMDB.ShouldBe("tt1480055");
            episode!.IDs!.TMDB.ShouldBe(63056U);
            episode!.IDs!.HasAnyID.ShouldBe(true);
            episode!.IDs!.BestID.ShouldBe("73640");

            episode!.ToString().ShouldBe("S01E01: Winter Is Coming");

            episode!.Overview.ShouldBe("Jon Arryn, the Hand of the King, is dead. King Robert Baratheon plans to ask his oldest friend,"
                + " Eddard Stark, to take Jon's place. Across the sea, Viserys Targaryen plans to wed his sister to a nomadic warlord in "
                + "exchange for an army.");

            episode!.Rating.ShouldBe(8.08208f);
            episode!.Votes.ShouldBe(14619U);
            episode!.CommentCount.ShouldBe(38U);
            episode!.FirstAired.ShouldBe(TestUtility.ParseUTCDateTime("2011-04-18T01:00:00.000Z"));
            episode!.UpdatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2024-03-22T18:44:49.000Z"));
            episode!.Runtime.ShouldBe(62U);
            episode!.EpisodeType.ShouldBe(TraktEpisodeType.SeriesPremiere);

            episode!.AvailableTranslations.ShouldNotBeNull();
            episode!.AvailableTranslations!.Count.ShouldBe(30);
            episode!.AvailableTranslations!.ShouldBe([
                "ar", "bg", "bs", "ca", "cs", "da", "de", "el", "en", "es", "fa", "fi", "fr", "he", "hu",
                "it", "ja", "ko", "nl", "no", "pl", "pt", "ro", "ru", "sk", "sl", "sv", "tr", "uk", "zh"
            ], Case.Sensitive);

            episode.Translations.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktEpisodeFromJsonFullWithImages()
        {
            TraktEpisode? episode = await TestUtility.DeserializeJsonAsync<TraktEpisode>("Episodes\\episode_full_images.json");

            episode.ShouldNotBeNull();

            episode!.Season.ShouldBe(1U);
            episode!.Number.ShouldBe(1U);
            episode!.NumberAbsolute.ShouldBe(1U);
            episode!.Title.ShouldBe("Winter Is Coming");

            episode!.IDs.ShouldNotBeNull();
            episode!.IDs!.Trakt.ShouldBe(73640U);
            episode!.IDs!.TVDB.ShouldBe(3254641U);
            episode!.IDs!.IMDB.ShouldBe("tt1480055");
            episode!.IDs!.TMDB.ShouldBe(63056U);
            episode!.IDs!.HasAnyID.ShouldBe(true);
            episode!.IDs!.BestID.ShouldBe("73640");

            episode!.ToString().ShouldBe("S01E01: Winter Is Coming");

            episode!.Overview.ShouldBe("Jon Arryn, the Hand of the King, is dead. King Robert Baratheon plans to ask his oldest friend,"
                + " Eddard Stark, to take Jon's place. Across the sea, Viserys Targaryen plans to wed his sister to a nomadic warlord in "
                + "exchange for an army.");

            episode!.Rating.ShouldBe(8.08208f);
            episode!.Votes.ShouldBe(14619U);
            episode!.CommentCount.ShouldBe(38U);
            episode!.FirstAired.ShouldBe(TestUtility.ParseUTCDateTime("2011-04-18T01:00:00.000Z"));
            episode!.UpdatedAt.ShouldBe(TestUtility.ParseUTCDateTime("2024-03-22T18:44:49.000Z"));
            episode!.Runtime.ShouldBe(62U);
            episode!.EpisodeType.ShouldBe(TraktEpisodeType.SeriesPremiere);

            episode!.AvailableTranslations.ShouldNotBeNull();
            episode!.AvailableTranslations!.Count.ShouldBe(30);
            episode!.AvailableTranslations!.ShouldBe([
                "ar", "bg", "bs", "ca", "cs", "da", "de", "el", "en", "es", "fa", "fi", "fr", "he", "hu",
                "it", "ja", "ko", "nl", "no", "pl", "pt", "ro", "ru", "sk", "sl", "sv", "tr", "uk", "zh"
            ], Case.Sensitive);

            episode!.Images.ShouldNotBeNull();

            episode!.Images!.Screenshot.ShouldNotBeNull();
            episode!.Images!.Screenshot!.Count.ShouldBe(1);
            episode!.Images!.Screenshot!.ShouldBe([ "walter-r2.trakt.tv/images/episodes/000/073/640/screenshots/medium/66c1ba1793.jpg.webp" ]);

            episode.Translations.ShouldBeNull();
        }

        [Fact]
        public async Task TestTraktEpisodeFromJsonWithTranslations()
        {
            TraktEpisode? episode = await TestUtility.DeserializeJsonAsync<TraktEpisode>("Episodes\\episode_with_translations.json");

            episode.ShouldNotBeNull();

            episode!.Season.ShouldBe(1U);
            episode!.Number.ShouldBe(1U);
            episode!.NumberAbsolute.ShouldBeNull();
            episode!.Title.ShouldBe("Winter Is Coming");

            episode!.IDs.ShouldNotBeNull();
            episode!.IDs!.Trakt.ShouldBe(73640U);
            episode!.IDs!.TVDB.ShouldBe(3254641U);
            episode!.IDs!.IMDB.ShouldBe("tt1480055");
            episode!.IDs!.TMDB.ShouldBe(63056U);
            episode!.IDs!.HasAnyID.ShouldBe(true);
            episode!.IDs!.BestID.ShouldBe("73640");

            episode!.ToString().ShouldBe("S01E01: Winter Is Coming");

            episode!.Overview.ShouldBeNull();
            episode!.Rating.ShouldBeNull();
            episode!.Votes.ShouldBeNull();
            episode!.CommentCount.ShouldBeNull();
            episode!.FirstAired.ShouldBeNull();
            episode!.UpdatedAt.ShouldBeNull();
            episode!.Runtime.ShouldBeNull();
            episode!.EpisodeType.ShouldBeNull();
            episode!.AvailableTranslations.ShouldBeNull();

            episode.Translations.ShouldNotBeNull();
            episode.Translations!.Count.ShouldBe(2);

            List<TraktEpisodeTranslation> translations = episode.Translations!;

            translations[0].ShouldNotBeNull();
            translations[0].Title.ShouldBe("Der Winter naht");
            translations[0].Overview.ShouldBe("Jon Arryn, die Hand des Königs, ist tot.");
            translations[0].Language.ShouldBe("de");
            translations[0].Country.ShouldBeNull();

            translations[1].ShouldNotBeNull();
            translations[1].Title.ShouldBe("Winter Is Coming");
            translations[1].Overview.ShouldBe("Jon Arryn, the Hand of the King, is dead.");
            translations[1].Language.ShouldBe("en");
            translations[1].Country.ShouldBeNull();
        }
    }
}

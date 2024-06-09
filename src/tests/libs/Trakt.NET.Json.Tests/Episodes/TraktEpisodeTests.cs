namespace TraktNET.Json.Episodes
{
    public sealed class TraktEpisodeTests
    {
        [Fact]
        public void TestTraktEpisodeConstructor()
        {
            var episode = new TraktEpisode();

            episode.Season.Should().BeNull();
            episode.Number.Should().BeNull();
            episode.NumberAbsolute.Should().BeNull();
            episode.Title.Should().BeNull();
            episode.Ids.Should().BeNull();
            episode.Overview.Should().BeNull();
            episode.Rating.Should().BeNull();
            episode.Votes.Should().BeNull();
            episode.CommentCount.Should().BeNull();
            episode.FirstAired.Should().BeNull();
            episode.UpdatedAt.Should().BeNull();
            episode.Runtime.Should().BeNull();
            episode.EpisodeType.Should().BeNull();
            episode.AvailableTranslations.Should().BeNull();
            episode.Translations.Should().BeNull();
        }

        [Fact]
        public async Task TestTraktEpisodeFromJsonMinimal()
        {
            TraktEpisodeMinimal? episode = await TestUtility.DeserializeJsonAsync<TraktEpisodeMinimal>("Episodes\\episode_minimal.json");

            episode.Should().NotBeNull();

            episode!.Season.Should().Be(1U);
            episode!.Number.Should().Be(1U);
            episode!.Title.Should().Be("Winter Is Coming");

            episode!.Ids.Should().NotBeNull();
            episode!.Ids!.Trakt.Should().Be(73640U);
            episode!.Ids!.TVDB.Should().Be(3254641U);
            episode!.Ids!.IMDB.Should().Be("tt1480055");
            episode!.Ids!.TMDB.Should().Be(63056U);
            episode!.Ids!.HasAnyID.Should().BeTrue();
            episode!.Ids!.BestID.Should().Be("73640");
        }

        [Fact]
        public async Task TestTraktEpisodeFromJson()
        {
            TraktEpisode? episode = await TestUtility.DeserializeJsonAsync<TraktEpisode>("Episodes\\episode.json");

            episode.Should().NotBeNull();

            episode!.Season.Should().Be(1U);
            episode!.Number.Should().Be(1U);
            episode!.NumberAbsolute.Should().Be(1U);
            episode!.Title.Should().Be("Winter Is Coming");

            episode!.Ids.Should().NotBeNull();
            episode!.Ids!.Trakt.Should().Be(73640U);
            episode!.Ids!.TVDB.Should().Be(3254641U);
            episode!.Ids!.IMDB.Should().Be("tt1480055");
            episode!.Ids!.TMDB.Should().Be(63056U);
            episode!.Ids!.HasAnyID.Should().BeTrue();
            episode!.Ids!.BestID.Should().Be("73640");

            episode!.Overview.Should().Be("Jon Arryn, the Hand of the King, is dead. King Robert Baratheon plans to ask his oldest friend,"
                + " Eddard Stark, to take Jon's place. Across the sea, Viserys Targaryen plans to wed his sister to a nomadic warlord in "
                + "exchange for an army.");

            episode!.Rating.Should().Be(8.08208f);
            episode!.Votes.Should().Be(14619U);
            episode!.CommentCount.Should().Be(38U);
            episode!.FirstAired.Should().Be(TestUtility.ParseUTCDateTime("2011-04-18T01:00:00.000Z"));
            episode!.UpdatedAt.Should().Be(TestUtility.ParseUTCDateTime("2024-03-22T18:44:49.000Z"));
            episode!.Runtime.Should().Be(62U);
            episode!.EpisodeType.Should().Be(TraktEpisodeType.SeriesPremiere);

            episode!.AvailableTranslations.Should().NotBeNull().And.HaveCount(30).And.BeEquivalentTo([
                "ar", "bg", "bs", "ca", "cs", "da", "de", "el", "en", "es", "fa", "fi", "fr", "he", "hu",
                "it", "ja", "ko", "nl", "no", "pl", "pt", "ro", "ru", "sk", "sl", "sv", "tr", "uk", "zh"
            ]);

            episode.Translations.Should().BeNull();
        }

        [Fact]
        public async Task TestTraktEpisodeFromJsonWithTranslations()
        {
            TraktEpisode? episode = await TestUtility.DeserializeJsonAsync<TraktEpisode>("Episodes\\episode_with_translations.json");

            episode.Should().NotBeNull();

            episode!.Season.Should().Be(1U);
            episode!.Number.Should().Be(1U);
            episode!.NumberAbsolute.Should().BeNull();
            episode!.Title.Should().Be("Winter Is Coming");

            episode!.Ids.Should().NotBeNull();
            episode!.Ids!.Trakt.Should().Be(73640U);
            episode!.Ids!.TVDB.Should().Be(3254641U);
            episode!.Ids!.IMDB.Should().Be("tt1480055");
            episode!.Ids!.TMDB.Should().Be(63056U);
            episode!.Ids!.HasAnyID.Should().BeTrue();
            episode!.Ids!.BestID.Should().Be("73640");

            episode!.Overview.Should().BeNull();
            episode!.Rating.Should().BeNull();
            episode!.Votes.Should().BeNull();
            episode!.CommentCount.Should().BeNull();
            episode!.FirstAired.Should().BeNull();
            episode!.UpdatedAt.Should().BeNull();
            episode!.Runtime.Should().BeNull();
            episode!.EpisodeType.Should().BeNull();
            episode!.AvailableTranslations.Should().BeNull();

            episode.Translations.Should().NotBeNull().And.HaveCount(2);

            IList<TraktEpisodeTranslation> translations = episode.Translations!;

            translations[0].Should().NotBeNull();
            translations[0].Title.Should().Be("Der Winter naht");
            translations[0].Overview.Should().Be("Jon Arryn, die Hand des Königs, ist tot.");
            translations[0].Language.Should().Be("de");
            translations[0].Country.Should().BeNull();

            translations[1].Should().NotBeNull();
            translations[1].Title.Should().Be("Winter Is Coming");
            translations[1].Overview.Should().Be("Jon Arryn, the Hand of the King, is dead.");
            translations[1].Language.Should().Be("en");
            translations[1].Country.Should().BeNull();
        }
    }
}

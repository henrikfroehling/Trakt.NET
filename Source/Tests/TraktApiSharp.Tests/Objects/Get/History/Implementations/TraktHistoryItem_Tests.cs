namespace TraktApiSharp.Tests.Objects.Get.History.Implementations
{
    using FluentAssertions;
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Enums;
    using TraktApiSharp.Objects.Get.History.Implementations;
    using TraktApiSharp.Objects.Get.History.JsonReader;
    using Xunit;

    [Category("Objects.Get.History.Implementations")]
    public class TraktHistoryItem_Tests
    {
        [Fact]
        public void Test_TraktHistoryItem_Default_Constructor()
        {
            var historyItem = new TraktHistoryItem();

            historyItem.Id.Should().Be(0);
            historyItem.WatchedAt.Should().NotHaveValue();
            historyItem.Action.Should().BeNull();
            historyItem.Type.Should().BeNull();
            historyItem.Movie.Should().BeNull();
            historyItem.Show.Should().BeNull();
            historyItem.Season.Should().BeNull();
            historyItem.Episode.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktHistoryItem_With_Type_Movie_From_Minimal_Json()
        {
            var jsonReader = new HistoryItemObjectJsonReader();
            var historyItem = await jsonReader.ReadObjectAsync(TYPE_MOVIE_MINIMAL_JSON) as TraktHistoryItem;

            historyItem.Should().NotBeNull();
            historyItem.Id.Should().Be(1982346UL);
            historyItem.WatchedAt.Should().Be(DateTime.Parse("2014-03-31T09:28:53.000Z").ToUniversalTime());
            historyItem.Action.Should().Be(TraktHistoryActionType.Scrobble);
            historyItem.Type.Should().Be(TraktSyncItemType.Movie);
            historyItem.Movie.Should().NotBeNull();
            historyItem.Movie.Title.Should().Be("Star Wars: The Force Awakens");
            historyItem.Movie.Year.Should().Be(2015);
            historyItem.Movie.Ids.Should().NotBeNull();
            historyItem.Movie.Ids.Trakt.Should().Be(94024U);
            historyItem.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            historyItem.Movie.Ids.Imdb.Should().Be("tt2488496");
            historyItem.Movie.Ids.Tmdb.Should().Be(140607U);
            historyItem.Movie.Tagline.Should().BeNullOrEmpty();
            historyItem.Movie.Overview.Should().BeNullOrEmpty();
            historyItem.Movie.Released.Should().NotHaveValue();
            historyItem.Movie.Runtime.Should().NotHaveValue();
            historyItem.Movie.UpdatedAt.Should().NotHaveValue();
            historyItem.Movie.Trailer.Should().BeNullOrEmpty();
            historyItem.Movie.Homepage.Should().BeNullOrEmpty();
            historyItem.Movie.Rating.Should().NotHaveValue();
            historyItem.Movie.Votes.Should().NotHaveValue();
            historyItem.Movie.LanguageCode.Should().BeNullOrEmpty();
            historyItem.Movie.AvailableTranslationLanguageCodes.Should().BeNull();
            historyItem.Movie.Genres.Should().BeNull();
            historyItem.Movie.Certification.Should().BeNullOrEmpty();
            historyItem.Show.Should().BeNull();
            historyItem.Season.Should().BeNull();
            historyItem.Episode.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktHistoryItem_With_Type_Show_From_Minimal_Json()
        {
            var jsonReader = new HistoryItemObjectJsonReader();
            var historyItem = await jsonReader.ReadObjectAsync(TYPE_SHOW_MINIMAL_JSON) as TraktHistoryItem;

            historyItem.Should().NotBeNull();
            historyItem.Id.Should().Be(1982348UL);
            historyItem.WatchedAt.Should().Be(DateTime.Parse("2013-06-15T05:54:27.000Z").ToUniversalTime());
            historyItem.Action.Should().Be(TraktHistoryActionType.Checkin);
            historyItem.Type.Should().Be(TraktSyncItemType.Show);
            historyItem.Movie.Should().BeNull();
            historyItem.Show.Should().NotBeNull();
            historyItem.Show.Title.Should().Be("Game of Thrones");
            historyItem.Show.Year.Should().Be(2011);
            historyItem.Show.Airs.Should().BeNull();
            historyItem.Show.AvailableTranslationLanguageCodes.Should().BeNull();
            historyItem.Show.Ids.Should().NotBeNull();
            historyItem.Show.Ids.Trakt.Should().Be(1390U);
            historyItem.Show.Ids.Slug.Should().Be("game-of-thrones");
            historyItem.Show.Ids.Tvdb.Should().Be(121361U);
            historyItem.Show.Ids.Imdb.Should().Be("tt0944947");
            historyItem.Show.Ids.Tmdb.Should().Be(1399U);
            historyItem.Show.Ids.TvRage.Should().Be(24493U);
            historyItem.Show.Genres.Should().BeNull();
            historyItem.Show.Seasons.Should().BeNull();
            historyItem.Show.Overview.Should().BeNullOrEmpty();
            historyItem.Show.FirstAired.Should().NotHaveValue();
            historyItem.Show.Runtime.Should().NotHaveValue();
            historyItem.Show.Certification.Should().BeNullOrEmpty();
            historyItem.Show.Network.Should().BeNullOrEmpty();
            historyItem.Show.CountryCode.Should().BeNullOrEmpty();
            historyItem.Show.UpdatedAt.Should().NotHaveValue();
            historyItem.Show.Trailer.Should().BeNullOrEmpty();
            historyItem.Show.Homepage.Should().BeNullOrEmpty();
            historyItem.Show.Status.Should().BeNull();
            historyItem.Show.Rating.Should().NotHaveValue();
            historyItem.Show.Votes.Should().NotHaveValue();
            historyItem.Show.LanguageCode.Should().BeNullOrEmpty();
            historyItem.Show.AiredEpisodes.Should().NotHaveValue();
            historyItem.Season.Should().BeNull();
            historyItem.Episode.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktHistoryItem_With_Type_Season_From_Minimal_Json()
        {
            var jsonReader = new HistoryItemObjectJsonReader();
            var historyItem = await jsonReader.ReadObjectAsync(TYPE_SEASON_MINIMAL_JSON) as TraktHistoryItem;

            historyItem.Should().NotBeNull();
            historyItem.Id.Should().Be(1982344UL);
            historyItem.WatchedAt.Should().Be(DateTime.Parse("2013-05-15T05:54:27.000Z").ToUniversalTime());
            historyItem.Action.Should().Be(TraktHistoryActionType.Watch);
            historyItem.Type.Should().Be(TraktSyncItemType.Season);
            historyItem.Movie.Should().BeNull();
            historyItem.Show.Should().BeNull();
            historyItem.Season.Should().NotBeNull();
            historyItem.Season.Number.Should().Be(1);
            historyItem.Season.Ids.Should().NotBeNull();
            historyItem.Season.Ids.Trakt.Should().Be(61430U);
            historyItem.Season.Ids.Tvdb.Should().Be(279121U);
            historyItem.Season.Ids.Tmdb.Should().Be(60523U);
            historyItem.Season.Ids.TvRage.Should().Be(36939U);
            historyItem.Season.Rating.Should().NotHaveValue();
            historyItem.Season.Votes.Should().NotHaveValue();
            historyItem.Season.TotalEpisodesCount.Should().NotHaveValue();
            historyItem.Season.AiredEpisodesCount.Should().NotHaveValue();
            historyItem.Season.Overview.Should().BeNullOrEmpty();
            historyItem.Season.FirstAired.Should().NotHaveValue();
            historyItem.Season.Episodes.Should().BeNull();
            historyItem.Episode.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktHistoryItem_With_Type_Episode_From_Minimal_Json()
        {
            var jsonReader = new HistoryItemObjectJsonReader();
            var historyItem = await jsonReader.ReadObjectAsync(TYPE_EPISODE_MINIMAL_JSON) as TraktHistoryItem;

            historyItem.Should().NotBeNull();
            historyItem.Id.Should().Be(1982347UL);
            historyItem.WatchedAt.Should().Be(DateTime.Parse("2014-02-27T09:28:53.000Z").ToUniversalTime());
            historyItem.Action.Should().Be(TraktHistoryActionType.Checkin);
            historyItem.Type.Should().Be(TraktSyncItemType.Episode);
            historyItem.Movie.Should().BeNull();
            historyItem.Show.Should().NotBeNull();
            historyItem.Show.Title.Should().Be("Game of Thrones");
            historyItem.Show.Year.Should().Be(2011);
            historyItem.Show.Airs.Should().BeNull();
            historyItem.Show.AvailableTranslationLanguageCodes.Should().BeNull();
            historyItem.Show.Ids.Should().NotBeNull();
            historyItem.Show.Ids.Trakt.Should().Be(1390U);
            historyItem.Show.Ids.Slug.Should().Be("game-of-thrones");
            historyItem.Show.Ids.Tvdb.Should().Be(121361U);
            historyItem.Show.Ids.Imdb.Should().Be("tt0944947");
            historyItem.Show.Ids.Tmdb.Should().Be(1399U);
            historyItem.Show.Ids.TvRage.Should().Be(24493U);
            historyItem.Show.Genres.Should().BeNull();
            historyItem.Show.Seasons.Should().BeNull();
            historyItem.Show.Overview.Should().BeNullOrEmpty();
            historyItem.Show.FirstAired.Should().NotHaveValue();
            historyItem.Show.Runtime.Should().NotHaveValue();
            historyItem.Show.Certification.Should().BeNullOrEmpty();
            historyItem.Show.Network.Should().BeNullOrEmpty();
            historyItem.Show.CountryCode.Should().BeNullOrEmpty();
            historyItem.Show.UpdatedAt.Should().NotHaveValue();
            historyItem.Show.Trailer.Should().BeNullOrEmpty();
            historyItem.Show.Homepage.Should().BeNullOrEmpty();
            historyItem.Show.Status.Should().BeNull();
            historyItem.Show.Rating.Should().NotHaveValue();
            historyItem.Show.Votes.Should().NotHaveValue();
            historyItem.Show.LanguageCode.Should().BeNullOrEmpty();
            historyItem.Show.AiredEpisodes.Should().NotHaveValue();
            historyItem.Season.Should().BeNull();
            historyItem.Episode.Should().NotBeNull();
            historyItem.Episode.SeasonNumber.Should().Be(1);
            historyItem.Episode.Number.Should().Be(1);
            historyItem.Episode.Title.Should().Be("Winter Is Coming");
            historyItem.Episode.Ids.Should().NotBeNull();
            historyItem.Episode.Ids.Trakt.Should().Be(73640U);
            historyItem.Episode.Ids.Tvdb.Should().Be(3254641U);
            historyItem.Episode.Ids.Imdb.Should().Be("tt1480055");
            historyItem.Episode.Ids.Tmdb.Should().Be(63056U);
            historyItem.Episode.Ids.TvRage.Should().Be(1065008299U);
            historyItem.Episode.NumberAbsolute.Should().NotHaveValue();
            historyItem.Episode.Overview.Should().BeNullOrEmpty();
            historyItem.Episode.Runtime.Should().NotHaveValue();
            historyItem.Episode.Rating.Should().NotHaveValue();
            historyItem.Episode.Votes.Should().NotHaveValue();
            historyItem.Episode.FirstAired.Should().NotHaveValue();
            historyItem.Episode.UpdatedAt.Should().NotHaveValue();
            historyItem.Episode.AvailableTranslationLanguageCodes.Should().BeNull();
            historyItem.Episode.Translations.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktHistoryItem_With_Type_Movie_From_Full_Json()
        {
            var jsonReader = new HistoryItemObjectJsonReader();
            var historyItem = await jsonReader.ReadObjectAsync(TYPE_MOVIE_FULL_JSON) as TraktHistoryItem;

            historyItem.Should().NotBeNull();
            historyItem.Id.Should().Be(1982346UL);
            historyItem.WatchedAt.Should().Be(DateTime.Parse("2014-03-31T09:28:53.000Z").ToUniversalTime());
            historyItem.Action.Should().Be(TraktHistoryActionType.Scrobble);
            historyItem.Type.Should().Be(TraktSyncItemType.Movie);
            historyItem.Movie.Should().NotBeNull();
            historyItem.Movie.Title.Should().Be("Star Wars: The Force Awakens");
            historyItem.Movie.Year.Should().Be(2015);
            historyItem.Movie.Ids.Should().NotBeNull();
            historyItem.Movie.Ids.Trakt.Should().Be(94024U);
            historyItem.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            historyItem.Movie.Ids.Imdb.Should().Be("tt2488496");
            historyItem.Movie.Ids.Tmdb.Should().Be(140607U);
            historyItem.Movie.Tagline.Should().Be("Every generation has a story.");
            historyItem.Movie.Overview.Should().Be("Thirty years after defeating the Galactic Empire, Han Solo and his allies face a new threat from the evil Kylo Ren and his army of Stormtroopers.");
            historyItem.Movie.Released.Should().Be(DateTime.Parse("2015-12-18"));
            historyItem.Movie.Runtime.Should().Be(136);
            historyItem.Movie.UpdatedAt.Should().Be(DateTime.Parse("2016-03-31T09:01:59Z").ToUniversalTime());
            historyItem.Movie.Trailer.Should().Be("http://youtube.com/watch?v=uwa7N0ShN2U");
            historyItem.Movie.Homepage.Should().Be("http://www.starwars.com/films/star-wars-episode-vii");
            historyItem.Movie.Rating.Should().Be(8.31988f);
            historyItem.Movie.Votes.Should().Be(9338);
            historyItem.Movie.LanguageCode.Should().Be("en");
            historyItem.Movie.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "de", "en", "it");
            historyItem.Movie.Genres.Should().NotBeNull().And.HaveCount(4).And.Contain("action", "adventure", "fantasy", "science-fiction");
            historyItem.Movie.Certification.Should().Be("PG-13");
            historyItem.Show.Should().BeNull();
            historyItem.Season.Should().BeNull();
            historyItem.Episode.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktHistoryItem_With_Type_Show_From_Full_Json()
        {
            var jsonReader = new HistoryItemObjectJsonReader();
            var historyItem = await jsonReader.ReadObjectAsync(TYPE_SHOW_FULL_JSON) as TraktHistoryItem;

            historyItem.Should().NotBeNull();
            historyItem.Id.Should().Be(1982348UL);
            historyItem.WatchedAt.Should().Be(DateTime.Parse("2013-06-15T05:54:27.000Z").ToUniversalTime());
            historyItem.Action.Should().Be(TraktHistoryActionType.Checkin);
            historyItem.Type.Should().Be(TraktSyncItemType.Show);
            historyItem.Movie.Should().BeNull();
            historyItem.Show.Should().NotBeNull();
            historyItem.Show.Title.Should().Be("Game of Thrones");
            historyItem.Show.Year.Should().Be(2011);
            historyItem.Show.Airs.Should().NotBeNull();
            historyItem.Show.Airs.Day.Should().Be("Sunday");
            historyItem.Show.Airs.Time.Should().Be("21:00");
            historyItem.Show.Airs.TimeZoneId.Should().Be("America/New_York");
            historyItem.Show.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "fr", "it", "de");
            historyItem.Show.Ids.Should().NotBeNull();
            historyItem.Show.Ids.Trakt.Should().Be(1390U);
            historyItem.Show.Ids.Slug.Should().Be("game-of-thrones");
            historyItem.Show.Ids.Tvdb.Should().Be(121361U);
            historyItem.Show.Ids.Imdb.Should().Be("tt0944947");
            historyItem.Show.Ids.Tmdb.Should().Be(1399U);
            historyItem.Show.Ids.TvRage.Should().Be(24493U);
            historyItem.Show.Genres.Should().NotBeNull().And.HaveCount(5).And.Contain("drama", "fantasy", "science-fiction", "action", "adventure");
            historyItem.Show.Seasons.Should().BeNull();
            historyItem.Show.Overview.Should().Be("Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond.");
            historyItem.Show.FirstAired.Should().Be(DateTime.Parse("2011-04-17T07:00:00Z").ToUniversalTime());
            historyItem.Show.Runtime.Should().Be(60);
            historyItem.Show.Certification.Should().Be("TV-MA");
            historyItem.Show.Network.Should().Be("HBO");
            historyItem.Show.CountryCode.Should().Be("us");
            historyItem.Show.UpdatedAt.Should().Be(DateTime.Parse("2016-04-06T10:39:11Z").ToUniversalTime());
            historyItem.Show.Trailer.Should().Be("http://youtube.com/watch?v=F9Bo89m2f6g");
            historyItem.Show.Homepage.Should().Be("http://www.hbo.com/game-of-thrones");
            historyItem.Show.Status.Should().Be(TraktShowStatus.ReturningSeries);
            historyItem.Show.Rating.Should().Be(9.38327f);
            historyItem.Show.Votes.Should().Be(44773);
            historyItem.Show.LanguageCode.Should().Be("en");
            historyItem.Show.AiredEpisodes.Should().Be(50);
            historyItem.Season.Should().BeNull();
            historyItem.Episode.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktHistoryItem_With_Type_Season_From_Full_Json()
        {
            var jsonReader = new HistoryItemObjectJsonReader();
            var historyItem = await jsonReader.ReadObjectAsync(TYPE_SEASON_FULL_JSON) as TraktHistoryItem;

            historyItem.Should().NotBeNull();
            historyItem.Id.Should().Be(1982344UL);
            historyItem.WatchedAt.Should().Be(DateTime.Parse("2013-05-15T05:54:27.000Z").ToUniversalTime());
            historyItem.Action.Should().Be(TraktHistoryActionType.Watch);
            historyItem.Type.Should().Be(TraktSyncItemType.Season);
            historyItem.Movie.Should().BeNull();
            historyItem.Show.Should().BeNull();
            historyItem.Season.Should().NotBeNull();
            historyItem.Season.Number.Should().Be(1);
            historyItem.Season.Ids.Should().NotBeNull();
            historyItem.Season.Ids.Trakt.Should().Be(61430U);
            historyItem.Season.Ids.Tvdb.Should().Be(279121U);
            historyItem.Season.Ids.Tmdb.Should().Be(60523U);
            historyItem.Season.Ids.TvRage.Should().Be(36939U);
            historyItem.Season.Rating.Should().Be(8.57053f);
            historyItem.Season.Votes.Should().Be(794);
            historyItem.Season.TotalEpisodesCount.Should().Be(23);
            historyItem.Season.AiredEpisodesCount.Should().Be(23);
            historyItem.Season.Overview.Should().Be("Text text text");
            historyItem.Season.FirstAired.Should().Be(DateTime.Parse("2014-10-08T00:00:00.000Z").ToUniversalTime());
            historyItem.Season.Episodes.Should().NotBeNull().And.HaveCount(2);

            var episodes = historyItem.Season.Episodes.ToArray();

            episodes[0].Should().NotBeNull();
            episodes[0].SeasonNumber.Should().Be(1);
            episodes[0].Number.Should().Be(1);
            episodes[0].Title.Should().Be("Winter Is Coming");
            episodes[0].Ids.Should().NotBeNull();
            episodes[0].Ids.Trakt.Should().Be(73640U);
            episodes[0].Ids.Tvdb.Should().Be(3254641U);
            episodes[0].Ids.Imdb.Should().Be("tt1480055");
            episodes[0].Ids.Tmdb.Should().Be(63056U);
            episodes[0].Ids.TvRage.Should().Be(1065008299U);
            episodes[0].NumberAbsolute.Should().NotHaveValue();
            episodes[0].Overview.Should().BeNullOrEmpty();
            episodes[0].Runtime.Should().NotHaveValue();
            episodes[0].Rating.Should().NotHaveValue();
            episodes[0].Votes.Should().NotHaveValue();
            episodes[0].FirstAired.Should().NotHaveValue();
            episodes[0].UpdatedAt.Should().NotHaveValue();
            episodes[0].AvailableTranslationLanguageCodes.Should().BeNull();
            episodes[0].Translations.Should().BeNull();

            episodes[1].Should().NotBeNull();
            episodes[1].SeasonNumber.Should().Be(1);
            episodes[1].Number.Should().Be(2);
            episodes[1].Title.Should().Be("The Kingsroad");
            episodes[1].Ids.Should().NotBeNull();
            episodes[1].Ids.Trakt.Should().Be(74138U);
            episodes[1].Ids.Tvdb.Should().Be(3436411U);
            episodes[1].Ids.Imdb.Should().Be("tt1668746");
            episodes[1].Ids.Tmdb.Should().Be(63141U);
            episodes[1].Ids.TvRage.Should().Be(1325718577U);
            episodes[1].NumberAbsolute.Should().NotHaveValue();
            episodes[1].Overview.Should().BeNullOrEmpty();
            episodes[1].Runtime.Should().NotHaveValue();
            episodes[1].Rating.Should().NotHaveValue();
            episodes[1].Votes.Should().NotHaveValue();
            episodes[1].FirstAired.Should().NotHaveValue();
            episodes[1].UpdatedAt.Should().NotHaveValue();
            episodes[1].AvailableTranslationLanguageCodes.Should().BeNull();
            episodes[1].Translations.Should().BeNull();

            historyItem.Episode.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktHistoryItem_With_Type_Episode_From_Full_Json()
        {
            var jsonReader = new HistoryItemObjectJsonReader();
            var historyItem = await jsonReader.ReadObjectAsync(TYPE_EPISODE_FULL_JSON) as TraktHistoryItem;

            historyItem.Should().NotBeNull();
            historyItem.Id.Should().Be(1982347UL);
            historyItem.WatchedAt.Should().Be(DateTime.Parse("2014-02-27T09:28:53.000Z").ToUniversalTime());
            historyItem.Action.Should().Be(TraktHistoryActionType.Checkin);
            historyItem.Type.Should().Be(TraktSyncItemType.Episode);
            historyItem.Movie.Should().BeNull();
            historyItem.Show.Should().NotBeNull();
            historyItem.Show.Title.Should().Be("Game of Thrones");
            historyItem.Show.Year.Should().Be(2011);
            historyItem.Show.Airs.Should().NotBeNull();
            historyItem.Show.Airs.Day.Should().Be("Sunday");
            historyItem.Show.Airs.Time.Should().Be("21:00");
            historyItem.Show.Airs.TimeZoneId.Should().Be("America/New_York");
            historyItem.Show.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "fr", "it", "de");
            historyItem.Show.Ids.Should().NotBeNull();
            historyItem.Show.Ids.Trakt.Should().Be(1390U);
            historyItem.Show.Ids.Slug.Should().Be("game-of-thrones");
            historyItem.Show.Ids.Tvdb.Should().Be(121361U);
            historyItem.Show.Ids.Imdb.Should().Be("tt0944947");
            historyItem.Show.Ids.Tmdb.Should().Be(1399U);
            historyItem.Show.Ids.TvRage.Should().Be(24493U);
            historyItem.Show.Genres.Should().NotBeNull().And.HaveCount(5).And.Contain("drama", "fantasy", "science-fiction", "action", "adventure");
            historyItem.Show.Seasons.Should().BeNull();
            historyItem.Show.Overview.Should().Be("Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond.");
            historyItem.Show.FirstAired.Should().Be(DateTime.Parse("2011-04-17T07:00:00Z").ToUniversalTime());
            historyItem.Show.Runtime.Should().Be(60);
            historyItem.Show.Certification.Should().Be("TV-MA");
            historyItem.Show.Network.Should().Be("HBO");
            historyItem.Show.CountryCode.Should().Be("us");
            historyItem.Show.UpdatedAt.Should().Be(DateTime.Parse("2016-04-06T10:39:11Z").ToUniversalTime());
            historyItem.Show.Trailer.Should().Be("http://youtube.com/watch?v=F9Bo89m2f6g");
            historyItem.Show.Homepage.Should().Be("http://www.hbo.com/game-of-thrones");
            historyItem.Show.Status.Should().Be(TraktShowStatus.ReturningSeries);
            historyItem.Show.Rating.Should().Be(9.38327f);
            historyItem.Show.Votes.Should().Be(44773);
            historyItem.Show.LanguageCode.Should().Be("en");
            historyItem.Show.AiredEpisodes.Should().Be(50);
            historyItem.Season.Should().BeNull();
            historyItem.Episode.Should().NotBeNull();
            historyItem.Episode.SeasonNumber.Should().Be(1);
            historyItem.Episode.Number.Should().Be(1);
            historyItem.Episode.Title.Should().Be("Winter Is Coming");
            historyItem.Episode.Ids.Should().NotBeNull();
            historyItem.Episode.Ids.Trakt.Should().Be(73640U);
            historyItem.Episode.Ids.Tvdb.Should().Be(3254641U);
            historyItem.Episode.Ids.Imdb.Should().Be("tt1480055");
            historyItem.Episode.Ids.Tmdb.Should().Be(63056U);
            historyItem.Episode.Ids.TvRage.Should().Be(1065008299U);
            historyItem.Episode.NumberAbsolute.Should().Be(50);
            historyItem.Episode.Overview.Should().Be("Ned Stark, Lord of Winterfell learns that his mentor, Jon Arryn, has died and that King Robert is on his way north to offer Ned Arryn’s position as the King’s Hand. Across the Narrow Sea in Pentos, Viserys Targaryen plans to wed his sister Daenerys to the nomadic Dothraki warrior leader, Khal Drogo to forge an alliance to take the throne.");
            historyItem.Episode.Runtime.Should().Be(55);
            historyItem.Episode.Rating.Should().Be(9.0f);
            historyItem.Episode.Votes.Should().Be(111);
            historyItem.Episode.FirstAired.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());
            historyItem.Episode.UpdatedAt.Should().Be(DateTime.Parse("2014-08-29T23:16:39.000Z").ToUniversalTime());
            historyItem.Episode.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(2).And.Contain("en", "es");
            historyItem.Episode.Translations.Should().NotBeNull().And.HaveCount(2);

            var translations = historyItem.Episode.Translations.ToArray();

            translations[0].Should().NotBeNull();
            translations[0].Title.Should().Be("Winter Is Coming");
            translations[0].Overview.Should().Be("Jon Arryn, the Hand of the King, is dead. King Robert Baratheon plans to ask his oldest friend, Eddard Stark, to take Jon's place. Across the sea, Viserys Targaryen plans to wed his sister to a nomadic warlord in exchange for an army.");
            translations[0].LanguageCode.Should().Be("en");

            translations[1].Should().NotBeNull();
            translations[1].Title.Should().Be("Se acerca el invierno");
            translations[1].Overview.Should().Be("El Lord Ned Stark está preocupado por los perturbantes reportes de un desertor del Nights Watch; El Rey Robert y los Lannisters llegan a Winterfell; el exiliado Viserys Targaryen forja una nueva y poderosa alianza.");
            translations[1].LanguageCode.Should().Be("es");
        }

        private const string TYPE_MOVIE_MINIMAL_JSON =
            @"{
                ""id"": 1982346,
                ""watched_at"": ""2014-03-31T09:28:53.000Z"",
                ""action"": ""scrobble"",
                ""type"": ""movie"",
                ""movie"": {
                  ""title"": ""Star Wars: The Force Awakens"",
                  ""year"": 2015,
                  ""ids"": {
                    ""trakt"": 94024,
                    ""slug"": ""star-wars-the-force-awakens-2015"",
                    ""imdb"": ""tt2488496"",
                    ""tmdb"": 140607
                  }
                }
              }";

        private const string TYPE_SHOW_MINIMAL_JSON =
            @"{
                ""id"": 1982348,
                ""watched_at"": ""2013-06-15T05:54:27.000Z"",
                ""action"": ""checkin"",
                ""type"": ""show"",
                ""show"": {
                  ""title"": ""Game of Thrones"",
                  ""year"": 2011,
                  ""ids"": {
                    ""trakt"": 1390,
                    ""slug"": ""game-of-thrones"",
                    ""tvdb"": 121361,
                    ""imdb"": ""tt0944947"",
                    ""tmdb"": 1399,
                    ""tvrage"": 24493
                  }
                }
              }";

        private const string TYPE_SEASON_MINIMAL_JSON =
            @"{
                ""id"": 1982344,
                ""watched_at"": ""2013-05-15T05:54:27.000Z"",
                ""action"": ""watch"",
                ""type"": ""season"",
                ""season"": {
                  ""number"": 1,
                  ""ids"": {
                    ""trakt"": 61430,
                    ""tvdb"": 279121,
                    ""tmdb"": 60523,
                    ""tvrage"": 36939
                  }
                }
              }";

        private const string TYPE_EPISODE_MINIMAL_JSON =
            @"{
                ""id"": 1982347,
                ""watched_at"": ""2014-02-27T09:28:53.000Z"",
                ""action"": ""checkin"",
                ""type"": ""episode"",
                ""episode"": {
                  ""season"": 1,
                  ""number"": 1,
                  ""title"": ""Winter Is Coming"",
                  ""ids"": {
                    ""trakt"": 73640,
                    ""tvdb"": 3254641,
                    ""imdb"": ""tt1480055"",
                    ""tmdb"": 63056,
                    ""tvrage"": 1065008299
                  }
                },
                ""show"": {
                  ""title"": ""Game of Thrones"",
                  ""year"": 2011,
                  ""ids"": {
                    ""trakt"": 1390,
                    ""slug"": ""game-of-thrones"",
                    ""tvdb"": 121361,
                    ""imdb"": ""tt0944947"",
                    ""tmdb"": 1399,
                    ""tvrage"": 24493
                  }
                }
              }";

        private const string TYPE_MOVIE_FULL_JSON =
            @"{
                ""id"": 1982346,
                ""watched_at"": ""2014-03-31T09:28:53.000Z"",
                ""action"": ""scrobble"",
                ""type"": ""movie"",
                ""movie"": {
                  ""title"": ""Star Wars: The Force Awakens"",
                  ""year"": 2015,
                  ""ids"": {
                    ""trakt"": 94024,
                    ""slug"": ""star-wars-the-force-awakens-2015"",
                    ""imdb"": ""tt2488496"",
                    ""tmdb"": 140607
                  },
                  ""tagline"": ""Every generation has a story."",
                  ""overview"": ""Thirty years after defeating the Galactic Empire, Han Solo and his allies face a new threat from the evil Kylo Ren and his army of Stormtroopers."",
                  ""released"": ""2015-12-18"",
                  ""runtime"": 136,
                  ""trailer"": ""http://youtube.com/watch?v=uwa7N0ShN2U"",
                  ""homepage"": ""http://www.starwars.com/films/star-wars-episode-vii"",
                  ""rating"": 8.31988,
                  ""votes"": 9338,
                  ""updated_at"": ""2016-03-31T09:01:59Z"",
                  ""language"": ""en"",
                  ""available_translations"": [
                    ""en"",
                    ""de"",
                    ""en"",
                    ""it""
                  ],
                  ""genres"": [
                    ""action"",
                    ""adventure"",
                    ""fantasy"",
                    ""science-fiction""
                  ],
                  ""certification"": ""PG-13""
                }
              }";

        private const string TYPE_SHOW_FULL_JSON =
            @"{
                ""id"": 1982348,
                ""watched_at"": ""2013-06-15T05:54:27.000Z"",
                ""action"": ""checkin"",
                ""type"": ""show"",
                ""show"": {
                  ""title"": ""Game of Thrones"",
                  ""year"": 2011,
                  ""ids"": {
                    ""trakt"": 1390,
                    ""slug"": ""game-of-thrones"",
                    ""tvdb"": 121361,
                    ""imdb"": ""tt0944947"",
                    ""tmdb"": 1399,
                    ""tvrage"": 24493
                  },
                  ""overview"": ""Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond."",
                  ""first_aired"": ""2011-04-17T07:00:00Z"",
                  ""airs"": {
                    ""day"": ""Sunday"",
                    ""time"": ""21:00"",
                    ""timezone"": ""America/New_York""
                  },
                  ""runtime"": 60,
                  ""certification"": ""TV-MA"",
                  ""network"": ""HBO"",
                  ""country"": ""us"",
                  ""trailer"": ""http://youtube.com/watch?v=F9Bo89m2f6g"",
                  ""homepage"": ""http://www.hbo.com/game-of-thrones"",
                  ""status"": ""returning series"",
                  ""rating"": 9.38327,
                  ""votes"": 44773,
                  ""updated_at"": ""2016-04-06T10:39:11Z"",
                  ""language"": ""en"",
                  ""available_translations"": [
                    ""en"",
                    ""fr"",
                    ""it"",
                    ""de""
                  ],
                  ""genres"": [
                    ""drama"",
                    ""fantasy"",
                    ""science-fiction"",
                    ""action"",
                    ""adventure""
                  ],
                  ""aired_episodes"": 50
                }
              }";

        private const string TYPE_SEASON_FULL_JSON =
            @"{
                ""id"": 1982344,
                ""watched_at"": ""2013-05-15T05:54:27.000Z"",
                ""action"": ""watch"",
                ""type"": ""season"",
                ""season"": {
                  ""number"": 1,
                  ""ids"": {
                    ""trakt"": 61430,
                    ""tvdb"": 279121,
                    ""tmdb"": 60523,
                    ""tvrage"": 36939
                  },
                  ""rating"": 8.57053,
                  ""votes"": 794,
                  ""episode_count"": 23,
                  ""aired_episodes"": 23,
                  ""overview"": ""Text text text"",
                  ""first_aired"": ""2014-10-08T00:00:00.000Z"",
                  ""episodes"": [
                    {
                      ""season"": 1,
                      ""number"": 1,
                      ""title"": ""Winter Is Coming"",
                      ""ids"": {
                        ""trakt"": 73640,
                        ""tvdb"": 3254641,
                        ""imdb"": ""tt1480055"",
                        ""tmdb"": 63056,
                        ""tvrage"": 1065008299
                      }
                    },
                    {
                      ""season"": 1,
                      ""number"": 2,
                      ""title"": ""The Kingsroad"",
                      ""ids"": {
                        ""trakt"": 74138,
                        ""tvdb"": 3436411,
                        ""imdb"": ""tt1668746"",
                        ""tmdb"": 63141,
                        ""tvrage"": 1325718577
                      }
                    }
                  ]
                }
              }";

        private const string TYPE_EPISODE_FULL_JSON =
            @"{
                ""id"": 1982347,
                ""watched_at"": ""2014-02-27T09:28:53.000Z"",
                ""action"": ""checkin"",
                ""type"": ""episode"",
                ""episode"": {
                  ""season"": 1,
                  ""number"": 1,
                  ""title"": ""Winter Is Coming"",
                  ""ids"": {
                    ""trakt"": 73640,
                    ""tvdb"": 3254641,
                    ""imdb"": ""tt1480055"",
                    ""tmdb"": 63056,
                    ""tvrage"": 1065008299
                  },
                  ""number_abs"": 50,
                  ""overview"": ""Ned Stark, Lord of Winterfell learns that his mentor, Jon Arryn, has died and that King Robert is on his way north to offer Ned Arryn’s position as the King’s Hand. Across the Narrow Sea in Pentos, Viserys Targaryen plans to wed his sister Daenerys to the nomadic Dothraki warrior leader, Khal Drogo to forge an alliance to take the throne."",
                  ""first_aired"": ""2011-04-18T01:00:00.000Z"",
                  ""updated_at"": ""2014-08-29T23:16:39.000Z"",
                  ""rating"": 9,
                  ""votes"": 111,
                  ""available_translations"": [
                    ""en"",
                    ""es""
                  ],
                  ""runtime"": 55,
                  ""translations"": [
                    {
                      ""title"": ""Winter Is Coming"",
                      ""overview"": ""Jon Arryn, the Hand of the King, is dead. King Robert Baratheon plans to ask his oldest friend, Eddard Stark, to take Jon's place. Across the sea, Viserys Targaryen plans to wed his sister to a nomadic warlord in exchange for an army."",
                      ""language"": ""en""
                    },
                    {
                      ""title"": ""Se acerca el invierno"",
                      ""overview"": ""El Lord Ned Stark está preocupado por los perturbantes reportes de un desertor del Nights Watch; El Rey Robert y los Lannisters llegan a Winterfell; el exiliado Viserys Targaryen forja una nueva y poderosa alianza."",
                      ""language"": ""es""
                    }
                  ]
                },
                ""show"": {
                  ""title"": ""Game of Thrones"",
                  ""year"": 2011,
                  ""ids"": {
                    ""trakt"": 1390,
                    ""slug"": ""game-of-thrones"",
                    ""tvdb"": 121361,
                    ""imdb"": ""tt0944947"",
                    ""tmdb"": 1399,
                    ""tvrage"": 24493
                  },
                  ""overview"": ""Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond."",
                  ""first_aired"": ""2011-04-17T07:00:00Z"",
                  ""airs"": {
                    ""day"": ""Sunday"",
                    ""time"": ""21:00"",
                    ""timezone"": ""America/New_York""
                  },
                  ""runtime"": 60,
                  ""certification"": ""TV-MA"",
                  ""network"": ""HBO"",
                  ""country"": ""us"",
                  ""trailer"": ""http://youtube.com/watch?v=F9Bo89m2f6g"",
                  ""homepage"": ""http://www.hbo.com/game-of-thrones"",
                  ""status"": ""returning series"",
                  ""rating"": 9.38327,
                  ""votes"": 44773,
                  ""updated_at"": ""2016-04-06T10:39:11Z"",
                  ""language"": ""en"",
                  ""available_translations"": [
                    ""en"",
                    ""fr"",
                    ""it"",
                    ""de""
                  ],
                  ""genres"": [
                    ""drama"",
                    ""fantasy"",
                    ""science-fiction"",
                    ""action"",
                    ""adventure""
                  ],
                  ""aired_episodes"": 50
                }
              }";
    }
}

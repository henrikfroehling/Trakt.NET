namespace TraktNet.Objects.Get.Tests.Watchlist.Implementations
{
    using FluentAssertions;
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Enums;
    using TraktNet.Objects.Get.Watchlist;
    using TraktNet.Objects.Get.Watchlist.Json.Reader;
    using Xunit;

    [TestCategory("Objects.Get.Watchlist.Implementations")]
    public class TraktWatchlistItem_Tests
    {
        [Fact]
        public void Test_TraktWatchlistItem_Default_Constructor()
        {
            var watchlistItem = new TraktWatchlistItem();

            watchlistItem.Id.Should().BeNull();
            watchlistItem.Rank.Should().BeNull();
            watchlistItem.ListedAt.Should().NotHaveValue();
            watchlistItem.Notes.Should().BeNull();
            watchlistItem.Type.Should().BeNull();
            watchlistItem.Movie.Should().BeNull();
            watchlistItem.Show.Should().BeNull();
            watchlistItem.Season.Should().BeNull();
            watchlistItem.Episode.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktWatchlistItem_With_Type_Movie_From_Minimal_Json()
        {
            var jsonReader = new WatchlistItemObjectJsonReader();
            var watchlistItem = await jsonReader.ReadObjectAsync(TYPE_MOVIE_MINIMAL_JSON) as TraktWatchlistItem;

            watchlistItem.Should().NotBeNull();
            watchlistItem.Id.Should().Be(101U);
            watchlistItem.Rank.Should().Be(1);
            watchlistItem.ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            watchlistItem.Notes.Should().Be("list item notes");
            watchlistItem.Type.Should().Be(TraktSyncItemType.Movie);
            watchlistItem.Movie.Should().NotBeNull();
            watchlistItem.Movie.Title.Should().Be("Star Wars: The Force Awakens");
            watchlistItem.Movie.Year.Should().Be(2015);
            watchlistItem.Movie.Ids.Should().NotBeNull();
            watchlistItem.Movie.Ids.Trakt.Should().Be(94024U);
            watchlistItem.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            watchlistItem.Movie.Ids.Imdb.Should().Be("tt2488496");
            watchlistItem.Movie.Ids.Tmdb.Should().Be(140607U);
            watchlistItem.Movie.Tagline.Should().BeNullOrEmpty();
            watchlistItem.Movie.Overview.Should().BeNullOrEmpty();
            watchlistItem.Movie.Released.Should().NotHaveValue();
            watchlistItem.Movie.Runtime.Should().NotHaveValue();
            watchlistItem.Movie.UpdatedAt.Should().NotHaveValue();
            watchlistItem.Movie.Trailer.Should().BeNullOrEmpty();
            watchlistItem.Movie.Homepage.Should().BeNullOrEmpty();
            watchlistItem.Movie.Rating.Should().NotHaveValue();
            watchlistItem.Movie.Votes.Should().NotHaveValue();
            watchlistItem.Movie.LanguageCode.Should().BeNullOrEmpty();
            watchlistItem.Movie.AvailableTranslationLanguageCodes.Should().BeNull();
            watchlistItem.Movie.Genres.Should().BeNull();
            watchlistItem.Movie.Certification.Should().BeNullOrEmpty();
            watchlistItem.Show.Should().BeNull();
            watchlistItem.Season.Should().BeNull();
            watchlistItem.Episode.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktWatchlistItem_With_Type_Show_From_Minimal_Json()
        {
            var jsonReader = new WatchlistItemObjectJsonReader();
            var watchlistItem = await jsonReader.ReadObjectAsync(TYPE_SHOW_MINIMAL_JSON) as TraktWatchlistItem;

            watchlistItem.Should().NotBeNull();
            watchlistItem.Id.Should().Be(101U);
            watchlistItem.Rank.Should().Be(1);
            watchlistItem.ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            watchlistItem.Notes.Should().Be("list item notes");
            watchlistItem.Type.Should().Be(TraktSyncItemType.Show);
            watchlistItem.Movie.Should().BeNull();
            watchlistItem.Show.Should().NotBeNull();
            watchlistItem.Show.Title.Should().Be("Game of Thrones");
            watchlistItem.Show.Year.Should().Be(2011);
            watchlistItem.Show.Airs.Should().BeNull();
            watchlistItem.Show.AvailableTranslationLanguageCodes.Should().BeNull();
            watchlistItem.Show.Ids.Should().NotBeNull();
            watchlistItem.Show.Ids.Trakt.Should().Be(1390U);
            watchlistItem.Show.Ids.Slug.Should().Be("game-of-thrones");
            watchlistItem.Show.Ids.Tvdb.Should().Be(121361U);
            watchlistItem.Show.Ids.Imdb.Should().Be("tt0944947");
            watchlistItem.Show.Ids.Tmdb.Should().Be(1399U);
            watchlistItem.Show.Ids.TvRage.Should().Be(24493U);
            watchlistItem.Show.Genres.Should().BeNull();
            watchlistItem.Show.Seasons.Should().BeNull();
            watchlistItem.Show.Overview.Should().BeNullOrEmpty();
            watchlistItem.Show.FirstAired.Should().NotHaveValue();
            watchlistItem.Show.Runtime.Should().NotHaveValue();
            watchlistItem.Show.Certification.Should().BeNullOrEmpty();
            watchlistItem.Show.Network.Should().BeNullOrEmpty();
            watchlistItem.Show.CountryCode.Should().BeNullOrEmpty();
            watchlistItem.Show.UpdatedAt.Should().NotHaveValue();
            watchlistItem.Show.Trailer.Should().BeNullOrEmpty();
            watchlistItem.Show.Homepage.Should().BeNullOrEmpty();
            watchlistItem.Show.Status.Should().BeNull();
            watchlistItem.Show.Rating.Should().NotHaveValue();
            watchlistItem.Show.Votes.Should().NotHaveValue();
            watchlistItem.Show.LanguageCode.Should().BeNullOrEmpty();
            watchlistItem.Show.AiredEpisodes.Should().NotHaveValue();
            watchlistItem.Season.Should().BeNull();
            watchlistItem.Episode.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktWatchlistItem_With_Type_Season_From_Minimal_Json()
        {
            var jsonReader = new WatchlistItemObjectJsonReader();
            var watchlistItem = await jsonReader.ReadObjectAsync(TYPE_SEASON_MINIMAL_JSON) as TraktWatchlistItem;

            watchlistItem.Should().NotBeNull();
            watchlistItem.Id.Should().Be(101U);
            watchlistItem.Rank.Should().Be(1);
            watchlistItem.ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            watchlistItem.Notes.Should().Be("list item notes");
            watchlistItem.Type.Should().Be(TraktSyncItemType.Season);
            watchlistItem.Movie.Should().BeNull();
            watchlistItem.Show.Should().BeNull();
            watchlistItem.Season.Should().NotBeNull();
            watchlistItem.Season.Number.Should().Be(1);
            watchlistItem.Season.Ids.Should().NotBeNull();
            watchlistItem.Season.Ids.Trakt.Should().Be(61430U);
            watchlistItem.Season.Ids.Tvdb.Should().Be(279121U);
            watchlistItem.Season.Ids.Tmdb.Should().Be(60523U);
            watchlistItem.Season.Ids.TvRage.Should().Be(36939U);
            watchlistItem.Season.Rating.Should().NotHaveValue();
            watchlistItem.Season.Votes.Should().NotHaveValue();
            watchlistItem.Season.TotalEpisodesCount.Should().NotHaveValue();
            watchlistItem.Season.AiredEpisodesCount.Should().NotHaveValue();
            watchlistItem.Season.Overview.Should().BeNullOrEmpty();
            watchlistItem.Season.FirstAired.Should().NotHaveValue();
            watchlistItem.Season.Episodes.Should().BeNull();
            watchlistItem.Episode.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktWatchlistItem_With_Type_Episode_From_Minimal_Json()
        {
            var jsonReader = new WatchlistItemObjectJsonReader();
            var watchlistItem = await jsonReader.ReadObjectAsync(TYPE_EPISODE_MINIMAL_JSON) as TraktWatchlistItem;

            watchlistItem.Should().NotBeNull();
            watchlistItem.Id.Should().Be(101U);
            watchlistItem.Rank.Should().Be(1);
            watchlistItem.ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            watchlistItem.Notes.Should().Be("list item notes");
            watchlistItem.Type.Should().Be(TraktSyncItemType.Episode);
            watchlistItem.Movie.Should().BeNull();
            watchlistItem.Show.Should().NotBeNull();
            watchlistItem.Show.Title.Should().Be("Game of Thrones");
            watchlistItem.Show.Year.Should().Be(2011);
            watchlistItem.Show.Airs.Should().BeNull();
            watchlistItem.Show.AvailableTranslationLanguageCodes.Should().BeNull();
            watchlistItem.Show.Ids.Should().NotBeNull();
            watchlistItem.Show.Ids.Trakt.Should().Be(1390U);
            watchlistItem.Show.Ids.Slug.Should().Be("game-of-thrones");
            watchlistItem.Show.Ids.Tvdb.Should().Be(121361U);
            watchlistItem.Show.Ids.Imdb.Should().Be("tt0944947");
            watchlistItem.Show.Ids.Tmdb.Should().Be(1399U);
            watchlistItem.Show.Ids.TvRage.Should().Be(24493U);
            watchlistItem.Show.Genres.Should().BeNull();
            watchlistItem.Show.Seasons.Should().BeNull();
            watchlistItem.Show.Overview.Should().BeNullOrEmpty();
            watchlistItem.Show.FirstAired.Should().NotHaveValue();
            watchlistItem.Show.Runtime.Should().NotHaveValue();
            watchlistItem.Show.Certification.Should().BeNullOrEmpty();
            watchlistItem.Show.Network.Should().BeNullOrEmpty();
            watchlistItem.Show.CountryCode.Should().BeNullOrEmpty();
            watchlistItem.Show.UpdatedAt.Should().NotHaveValue();
            watchlistItem.Show.Trailer.Should().BeNullOrEmpty();
            watchlistItem.Show.Homepage.Should().BeNullOrEmpty();
            watchlistItem.Show.Status.Should().BeNull();
            watchlistItem.Show.Rating.Should().NotHaveValue();
            watchlistItem.Show.Votes.Should().NotHaveValue();
            watchlistItem.Show.LanguageCode.Should().BeNullOrEmpty();
            watchlistItem.Show.AiredEpisodes.Should().NotHaveValue();
            watchlistItem.Season.Should().BeNull();
            watchlistItem.Episode.Should().NotBeNull();
            watchlistItem.Episode.SeasonNumber.Should().Be(1);
            watchlistItem.Episode.Number.Should().Be(1);
            watchlistItem.Episode.Title.Should().Be("Winter Is Coming");
            watchlistItem.Episode.Ids.Should().NotBeNull();
            watchlistItem.Episode.Ids.Trakt.Should().Be(73640U);
            watchlistItem.Episode.Ids.Tvdb.Should().Be(3254641U);
            watchlistItem.Episode.Ids.Imdb.Should().Be("tt1480055");
            watchlistItem.Episode.Ids.Tmdb.Should().Be(63056U);
            watchlistItem.Episode.Ids.TvRage.Should().Be(1065008299U);
            watchlistItem.Episode.NumberAbsolute.Should().NotHaveValue();
            watchlistItem.Episode.Overview.Should().BeNullOrEmpty();
            watchlistItem.Episode.Runtime.Should().NotHaveValue();
            watchlistItem.Episode.Rating.Should().NotHaveValue();
            watchlistItem.Episode.Votes.Should().NotHaveValue();
            watchlistItem.Episode.FirstAired.Should().NotHaveValue();
            watchlistItem.Episode.UpdatedAt.Should().NotHaveValue();
            watchlistItem.Episode.AvailableTranslationLanguageCodes.Should().BeNull();
            watchlistItem.Episode.Translations.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktWatchlistItem_With_Type_Movie_From_Full_Json()
        {
            var jsonReader = new WatchlistItemObjectJsonReader();
            var watchlistItem = await jsonReader.ReadObjectAsync(TYPE_MOVIE_FULL_JSON) as TraktWatchlistItem;

            watchlistItem.Should().NotBeNull();
            watchlistItem.Id.Should().Be(101U);
            watchlistItem.Rank.Should().Be(1);
            watchlistItem.ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            watchlistItem.Notes.Should().Be("list item notes");
            watchlistItem.Type.Should().Be(TraktSyncItemType.Movie);
            watchlistItem.Movie.Should().NotBeNull();
            watchlistItem.Movie.Title.Should().Be("Star Wars: The Force Awakens");
            watchlistItem.Movie.Year.Should().Be(2015);
            watchlistItem.Movie.Ids.Should().NotBeNull();
            watchlistItem.Movie.Ids.Trakt.Should().Be(94024U);
            watchlistItem.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            watchlistItem.Movie.Ids.Imdb.Should().Be("tt2488496");
            watchlistItem.Movie.Ids.Tmdb.Should().Be(140607U);
            watchlistItem.Movie.Tagline.Should().Be("Every generation has a story.");
            watchlistItem.Movie.Overview.Should().Be("Thirty years after defeating the Galactic Empire, Han Solo and his allies face a new threat from the evil Kylo Ren and his army of Stormtroopers.");
            watchlistItem.Movie.Released.Should().Be(DateTime.Parse("2015-12-18"));
            watchlistItem.Movie.Runtime.Should().Be(136);
            watchlistItem.Movie.UpdatedAt.Should().Be(DateTime.Parse("2016-03-31T09:01:59Z").ToUniversalTime());
            watchlistItem.Movie.Trailer.Should().Be("http://youtube.com/watch?v=uwa7N0ShN2U");
            watchlistItem.Movie.Homepage.Should().Be("http://www.starwars.com/films/star-wars-episode-vii");
            watchlistItem.Movie.Rating.Should().Be(8.31988f);
            watchlistItem.Movie.Votes.Should().Be(9338);
            watchlistItem.Movie.LanguageCode.Should().Be("en");
            watchlistItem.Movie.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "de", "en", "it");
            watchlistItem.Movie.Genres.Should().NotBeNull().And.HaveCount(4).And.Contain("action", "adventure", "fantasy", "science-fiction");
            watchlistItem.Movie.Certification.Should().Be("PG-13");
            watchlistItem.Show.Should().BeNull();
            watchlistItem.Season.Should().BeNull();
            watchlistItem.Episode.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktWatchlistItem_With_Type_Show_From_Full_Json()
        {
            var jsonReader = new WatchlistItemObjectJsonReader();
            var watchlistItem = await jsonReader.ReadObjectAsync(TYPE_SHOW_FULL_JSON) as TraktWatchlistItem;

            watchlistItem.Should().NotBeNull();
            watchlistItem.Id.Should().Be(101U);
            watchlistItem.Rank.Should().Be(1);
            watchlistItem.ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            watchlistItem.Notes.Should().Be("list item notes");
            watchlistItem.Type.Should().Be(TraktSyncItemType.Show);
            watchlistItem.Movie.Should().BeNull();
            watchlistItem.Show.Should().NotBeNull();
            watchlistItem.Show.Title.Should().Be("Game of Thrones");
            watchlistItem.Show.Year.Should().Be(2011);
            watchlistItem.Show.Airs.Should().NotBeNull();
            watchlistItem.Show.Airs.Day.Should().Be("Sunday");
            watchlistItem.Show.Airs.Time.Should().Be("21:00");
            watchlistItem.Show.Airs.TimeZoneId.Should().Be("America/New_York");
            watchlistItem.Show.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "fr", "it", "de");
            watchlistItem.Show.Ids.Should().NotBeNull();
            watchlistItem.Show.Ids.Trakt.Should().Be(1390U);
            watchlistItem.Show.Ids.Slug.Should().Be("game-of-thrones");
            watchlistItem.Show.Ids.Tvdb.Should().Be(121361U);
            watchlistItem.Show.Ids.Imdb.Should().Be("tt0944947");
            watchlistItem.Show.Ids.Tmdb.Should().Be(1399U);
            watchlistItem.Show.Ids.TvRage.Should().Be(24493U);
            watchlistItem.Show.Genres.Should().NotBeNull().And.HaveCount(5).And.Contain("drama", "fantasy", "science-fiction", "action", "adventure");
            watchlistItem.Show.Seasons.Should().BeNull();
            watchlistItem.Show.Overview.Should().Be("Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond.");
            watchlistItem.Show.FirstAired.Should().Be(DateTime.Parse("2011-04-17T07:00:00Z").ToUniversalTime());
            watchlistItem.Show.Runtime.Should().Be(60);
            watchlistItem.Show.Certification.Should().Be("TV-MA");
            watchlistItem.Show.Network.Should().Be("HBO");
            watchlistItem.Show.CountryCode.Should().Be("us");
            watchlistItem.Show.UpdatedAt.Should().Be(DateTime.Parse("2016-04-06T10:39:11Z").ToUniversalTime());
            watchlistItem.Show.Trailer.Should().Be("http://youtube.com/watch?v=F9Bo89m2f6g");
            watchlistItem.Show.Homepage.Should().Be("http://www.hbo.com/game-of-thrones");
            watchlistItem.Show.Status.Should().Be(TraktShowStatus.ReturningSeries);
            watchlistItem.Show.Rating.Should().Be(9.38327f);
            watchlistItem.Show.Votes.Should().Be(44773);
            watchlistItem.Show.LanguageCode.Should().Be("en");
            watchlistItem.Show.AiredEpisodes.Should().Be(50);
            watchlistItem.Season.Should().BeNull();
            watchlistItem.Episode.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktWatchlistItem_With_Type_Season_From_Full_Json()
        {
            var jsonReader = new WatchlistItemObjectJsonReader();
            var watchlistItem = await jsonReader.ReadObjectAsync(TYPE_SEASON_FULL_JSON) as TraktWatchlistItem;

            watchlistItem.Should().NotBeNull();
            watchlistItem.Id.Should().Be(101U);
            watchlistItem.Rank.Should().Be(1);
            watchlistItem.ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            watchlistItem.Notes.Should().Be("list item notes");
            watchlistItem.Type.Should().Be(TraktSyncItemType.Season);
            watchlistItem.Movie.Should().BeNull();
            watchlistItem.Show.Should().BeNull();
            watchlistItem.Season.Should().NotBeNull();
            watchlistItem.Season.Number.Should().Be(1);
            watchlistItem.Season.Ids.Should().NotBeNull();
            watchlistItem.Season.Ids.Trakt.Should().Be(61430U);
            watchlistItem.Season.Ids.Tvdb.Should().Be(279121U);
            watchlistItem.Season.Ids.Tmdb.Should().Be(60523U);
            watchlistItem.Season.Ids.TvRage.Should().Be(36939U);
            watchlistItem.Season.Rating.Should().Be(8.57053f);
            watchlistItem.Season.Votes.Should().Be(794);
            watchlistItem.Season.TotalEpisodesCount.Should().Be(23);
            watchlistItem.Season.AiredEpisodesCount.Should().Be(23);
            watchlistItem.Season.Overview.Should().Be("Text text text");
            watchlistItem.Season.FirstAired.Should().Be(DateTime.Parse("2014-10-08T00:00:00.000Z").ToUniversalTime());
            watchlistItem.Season.Episodes.Should().NotBeNull().And.HaveCount(2);

            var episodes = watchlistItem.Season.Episodes.ToArray();

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

            watchlistItem.Episode.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktWatchlistItem_With_Type_Episode_From_Full_Json()
        {
            var jsonReader = new WatchlistItemObjectJsonReader();
            var watchlistItem = await jsonReader.ReadObjectAsync(TYPE_EPISODE_FULL_JSON) as TraktWatchlistItem;

            watchlistItem.Should().NotBeNull();
            watchlistItem.Id.Should().Be(101U);
            watchlistItem.Rank.Should().Be(1);
            watchlistItem.ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            watchlistItem.Notes.Should().Be("list item notes");
            watchlistItem.Type.Should().Be(TraktSyncItemType.Episode);
            watchlistItem.Movie.Should().BeNull();
            watchlistItem.Show.Should().NotBeNull();
            watchlistItem.Show.Title.Should().Be("Game of Thrones");
            watchlistItem.Show.Year.Should().Be(2011);
            watchlistItem.Show.Airs.Should().NotBeNull();
            watchlistItem.Show.Airs.Day.Should().Be("Sunday");
            watchlistItem.Show.Airs.Time.Should().Be("21:00");
            watchlistItem.Show.Airs.TimeZoneId.Should().Be("America/New_York");
            watchlistItem.Show.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "fr", "it", "de");
            watchlistItem.Show.Ids.Should().NotBeNull();
            watchlistItem.Show.Ids.Trakt.Should().Be(1390U);
            watchlistItem.Show.Ids.Slug.Should().Be("game-of-thrones");
            watchlistItem.Show.Ids.Tvdb.Should().Be(121361U);
            watchlistItem.Show.Ids.Imdb.Should().Be("tt0944947");
            watchlistItem.Show.Ids.Tmdb.Should().Be(1399U);
            watchlistItem.Show.Ids.TvRage.Should().Be(24493U);
            watchlistItem.Show.Genres.Should().NotBeNull().And.HaveCount(5).And.Contain("drama", "fantasy", "science-fiction", "action", "adventure");
            watchlistItem.Show.Seasons.Should().BeNull();
            watchlistItem.Show.Overview.Should().Be("Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond.");
            watchlistItem.Show.FirstAired.Should().Be(DateTime.Parse("2011-04-17T07:00:00Z").ToUniversalTime());
            watchlistItem.Show.Runtime.Should().Be(60);
            watchlistItem.Show.Certification.Should().Be("TV-MA");
            watchlistItem.Show.Network.Should().Be("HBO");
            watchlistItem.Show.CountryCode.Should().Be("us");
            watchlistItem.Show.UpdatedAt.Should().Be(DateTime.Parse("2016-04-06T10:39:11Z").ToUniversalTime());
            watchlistItem.Show.Trailer.Should().Be("http://youtube.com/watch?v=F9Bo89m2f6g");
            watchlistItem.Show.Homepage.Should().Be("http://www.hbo.com/game-of-thrones");
            watchlistItem.Show.Status.Should().Be(TraktShowStatus.ReturningSeries);
            watchlistItem.Show.Rating.Should().Be(9.38327f);
            watchlistItem.Show.Votes.Should().Be(44773);
            watchlistItem.Show.LanguageCode.Should().Be("en");
            watchlistItem.Show.AiredEpisodes.Should().Be(50);
            watchlistItem.Season.Should().BeNull();
            watchlistItem.Episode.Should().NotBeNull();
            watchlistItem.Episode.SeasonNumber.Should().Be(1);
            watchlistItem.Episode.Number.Should().Be(1);
            watchlistItem.Episode.Title.Should().Be("Winter Is Coming");
            watchlistItem.Episode.Ids.Should().NotBeNull();
            watchlistItem.Episode.Ids.Trakt.Should().Be(73640U);
            watchlistItem.Episode.Ids.Tvdb.Should().Be(3254641U);
            watchlistItem.Episode.Ids.Imdb.Should().Be("tt1480055");
            watchlistItem.Episode.Ids.Tmdb.Should().Be(63056U);
            watchlistItem.Episode.Ids.TvRage.Should().Be(1065008299U);
            watchlistItem.Episode.NumberAbsolute.Should().Be(50);
            watchlistItem.Episode.Overview.Should().Be("Ned Stark, Lord of Winterfell learns that his mentor, Jon Arryn, has died and that King Robert is on his way north to offer Ned Arryn’s position as the King’s Hand. Across the Narrow Sea in Pentos, Viserys Targaryen plans to wed his sister Daenerys to the nomadic Dothraki warrior leader, Khal Drogo to forge an alliance to take the throne.");
            watchlistItem.Episode.Runtime.Should().Be(55);
            watchlistItem.Episode.Rating.Should().Be(9.0f);
            watchlistItem.Episode.Votes.Should().Be(111);
            watchlistItem.Episode.FirstAired.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());
            watchlistItem.Episode.UpdatedAt.Should().Be(DateTime.Parse("2014-08-29T23:16:39.000Z").ToUniversalTime());
            watchlistItem.Episode.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(2).And.Contain("en", "es");
            watchlistItem.Episode.Translations.Should().NotBeNull().And.HaveCount(2);

            var translations = watchlistItem.Episode.Translations.ToArray();

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
                ""id"": 101,
                ""rank"": 1,
                ""listed_at"": ""2014-09-01T09:10:11.000Z"",
                ""notes"": ""list item notes"",
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
                ""id"": 101,
                ""rank"": 1,
                ""listed_at"": ""2014-09-01T09:10:11.000Z"",
                ""notes"": ""list item notes"",
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
                ""id"": 101,
                ""rank"": 1,
                ""listed_at"": ""2014-09-01T09:10:11.000Z"",
                ""notes"": ""list item notes"",
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
                ""id"": 101,
                ""rank"": 1,
                ""listed_at"": ""2014-09-01T09:10:11.000Z"",
                ""notes"": ""list item notes"",
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
                ""id"": 101,
                ""rank"": 1,
                ""listed_at"": ""2014-09-01T09:10:11.000Z"",
                ""notes"": ""list item notes"",
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
                ""id"": 101,
                ""rank"": 1,
                ""listed_at"": ""2014-09-01T09:10:11.000Z"",
                ""notes"": ""list item notes"",
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
                ""id"": 101,
                ""rank"": 1,
                ""listed_at"": ""2014-09-01T09:10:11.000Z"",
                ""notes"": ""list item notes"",
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
                ""id"": 101,
                ""rank"": 1,
                ""listed_at"": ""2014-09-01T09:10:11.000Z"",
                ""notes"": ""list item notes"",
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

namespace TraktApiSharp.Tests.Objects.Get.Ratings.Implementations
{
    using FluentAssertions;
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Enums;
    using TraktApiSharp.Objects.Get.Ratings;
    using TraktApiSharp.Objects.Get.Ratings.Implementations;
    using TraktApiSharp.Objects.Get.Ratings.JsonReader;
    using Xunit;

    [Category("Objects.Get.Ratings.Implementations")]
    public class TraktRatingsItem_Tests
    {
        [Fact]
        public void Test_TraktRatingsItem_Implements_ITraktRatingsItem_Interface()
        {
            typeof(TraktRatingsItem).GetInterfaces().Should().Contain(typeof(ITraktRatingsItem));
        }

        [Fact]
        public void Test_TraktRatingsItem_Default_Constructor()
        {
            var ratingsItem = new TraktRatingsItem();

            ratingsItem.Rating.Should().NotHaveValue();
            ratingsItem.RatedAt.Should().NotHaveValue();
            ratingsItem.Type.Should().BeNull();
            ratingsItem.Movie.Should().BeNull();
            ratingsItem.Show.Should().BeNull();
            ratingsItem.Season.Should().BeNull();
            ratingsItem.Episode.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktRatingsItem_With_Type_Movie_From_Minimal_Json()
        {
            var jsonReader = new ITraktRatingsItemObjectJsonReader();
            var ratingsItem = await jsonReader.ReadObjectAsync(TYPE_MOVIE_MINIMAL_JSON) as TraktRatingsItem;

            ratingsItem.Should().NotBeNull();
            ratingsItem.Rating.Should().Be(10);
            ratingsItem.RatedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            ratingsItem.Type.Should().Be(TraktRatingsItemType.Movie);
            ratingsItem.Movie.Should().NotBeNull();
            ratingsItem.Movie.Title.Should().Be("Star Wars: The Force Awakens");
            ratingsItem.Movie.Year.Should().Be(2015);
            ratingsItem.Movie.Ids.Should().NotBeNull();
            ratingsItem.Movie.Ids.Trakt.Should().Be(94024U);
            ratingsItem.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            ratingsItem.Movie.Ids.Imdb.Should().Be("tt2488496");
            ratingsItem.Movie.Ids.Tmdb.Should().Be(140607U);
            ratingsItem.Movie.Tagline.Should().BeNullOrEmpty();
            ratingsItem.Movie.Overview.Should().BeNullOrEmpty();
            ratingsItem.Movie.Released.Should().NotHaveValue();
            ratingsItem.Movie.Runtime.Should().NotHaveValue();
            ratingsItem.Movie.UpdatedAt.Should().NotHaveValue();
            ratingsItem.Movie.Trailer.Should().BeNullOrEmpty();
            ratingsItem.Movie.Homepage.Should().BeNullOrEmpty();
            ratingsItem.Movie.Rating.Should().NotHaveValue();
            ratingsItem.Movie.Votes.Should().NotHaveValue();
            ratingsItem.Movie.LanguageCode.Should().BeNullOrEmpty();
            ratingsItem.Movie.AvailableTranslationLanguageCodes.Should().BeNull();
            ratingsItem.Movie.Genres.Should().BeNull();
            ratingsItem.Movie.Certification.Should().BeNullOrEmpty();
            ratingsItem.Show.Should().BeNull();
            ratingsItem.Season.Should().BeNull();
            ratingsItem.Episode.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktRatingsItem_With_Type_Show_From_Minimal_Json()
        {
            var jsonReader = new ITraktRatingsItemObjectJsonReader();
            var ratingsItem = await jsonReader.ReadObjectAsync(TYPE_SHOW_MINIMAL_JSON) as TraktRatingsItem;

            ratingsItem.Should().NotBeNull();
            ratingsItem.Rating.Should().Be(9);
            ratingsItem.RatedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            ratingsItem.Type.Should().Be(TraktRatingsItemType.Show);
            ratingsItem.Movie.Should().BeNull();
            ratingsItem.Show.Should().NotBeNull();
            ratingsItem.Show.Title.Should().Be("Game of Thrones");
            ratingsItem.Show.Year.Should().Be(2011);
            ratingsItem.Show.Airs.Should().BeNull();
            ratingsItem.Show.AvailableTranslationLanguageCodes.Should().BeNull();
            ratingsItem.Show.Ids.Should().NotBeNull();
            ratingsItem.Show.Ids.Trakt.Should().Be(1390U);
            ratingsItem.Show.Ids.Slug.Should().Be("game-of-thrones");
            ratingsItem.Show.Ids.Tvdb.Should().Be(121361U);
            ratingsItem.Show.Ids.Imdb.Should().Be("tt0944947");
            ratingsItem.Show.Ids.Tmdb.Should().Be(1399U);
            ratingsItem.Show.Ids.TvRage.Should().Be(24493U);
            ratingsItem.Show.Genres.Should().BeNull();
            ratingsItem.Show.Seasons.Should().BeNull();
            ratingsItem.Show.Overview.Should().BeNullOrEmpty();
            ratingsItem.Show.FirstAired.Should().NotHaveValue();
            ratingsItem.Show.Runtime.Should().NotHaveValue();
            ratingsItem.Show.Certification.Should().BeNullOrEmpty();
            ratingsItem.Show.Network.Should().BeNullOrEmpty();
            ratingsItem.Show.CountryCode.Should().BeNullOrEmpty();
            ratingsItem.Show.UpdatedAt.Should().NotHaveValue();
            ratingsItem.Show.Trailer.Should().BeNullOrEmpty();
            ratingsItem.Show.Homepage.Should().BeNullOrEmpty();
            ratingsItem.Show.Status.Should().BeNull();
            ratingsItem.Show.Rating.Should().NotHaveValue();
            ratingsItem.Show.Votes.Should().NotHaveValue();
            ratingsItem.Show.LanguageCode.Should().BeNullOrEmpty();
            ratingsItem.Show.AiredEpisodes.Should().NotHaveValue();
            ratingsItem.Season.Should().BeNull();
            ratingsItem.Episode.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktRatingsItem_With_Type_Season_From_Minimal_Json()
        {
            var jsonReader = new ITraktRatingsItemObjectJsonReader();
            var ratingsItem = await jsonReader.ReadObjectAsync(TYPE_SEASON_MINIMAL_JSON) as TraktRatingsItem;

            ratingsItem.Should().NotBeNull();
            ratingsItem.Rating.Should().Be(8);
            ratingsItem.RatedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            ratingsItem.Type.Should().Be(TraktRatingsItemType.Season);
            ratingsItem.Movie.Should().BeNull();
            ratingsItem.Show.Should().BeNull();
            ratingsItem.Season.Should().NotBeNull();
            ratingsItem.Season.Number.Should().Be(1);
            ratingsItem.Season.Ids.Should().NotBeNull();
            ratingsItem.Season.Ids.Trakt.Should().Be(61430U);
            ratingsItem.Season.Ids.Tvdb.Should().Be(279121U);
            ratingsItem.Season.Ids.Tmdb.Should().Be(60523U);
            ratingsItem.Season.Ids.TvRage.Should().Be(36939U);
            ratingsItem.Season.Rating.Should().NotHaveValue();
            ratingsItem.Season.Votes.Should().NotHaveValue();
            ratingsItem.Season.TotalEpisodesCount.Should().NotHaveValue();
            ratingsItem.Season.AiredEpisodesCount.Should().NotHaveValue();
            ratingsItem.Season.Overview.Should().BeNullOrEmpty();
            ratingsItem.Season.FirstAired.Should().NotHaveValue();
            ratingsItem.Season.Episodes.Should().BeNull();
            ratingsItem.Episode.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktRatingsItem_With_Type_Episode_From_Minimal_Json()
        {
            var jsonReader = new ITraktRatingsItemObjectJsonReader();
            var ratingsItem = await jsonReader.ReadObjectAsync(TYPE_EPISODE_MINIMAL_JSON) as TraktRatingsItem;

            ratingsItem.Should().NotBeNull();
            ratingsItem.Rating.Should().Be(7);
            ratingsItem.RatedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            ratingsItem.Type.Should().Be(TraktRatingsItemType.Episode);
            ratingsItem.Movie.Should().BeNull();
            ratingsItem.Show.Should().NotBeNull();
            ratingsItem.Show.Title.Should().Be("Game of Thrones");
            ratingsItem.Show.Year.Should().Be(2011);
            ratingsItem.Show.Airs.Should().BeNull();
            ratingsItem.Show.AvailableTranslationLanguageCodes.Should().BeNull();
            ratingsItem.Show.Ids.Should().NotBeNull();
            ratingsItem.Show.Ids.Trakt.Should().Be(1390U);
            ratingsItem.Show.Ids.Slug.Should().Be("game-of-thrones");
            ratingsItem.Show.Ids.Tvdb.Should().Be(121361U);
            ratingsItem.Show.Ids.Imdb.Should().Be("tt0944947");
            ratingsItem.Show.Ids.Tmdb.Should().Be(1399U);
            ratingsItem.Show.Ids.TvRage.Should().Be(24493U);
            ratingsItem.Show.Genres.Should().BeNull();
            ratingsItem.Show.Seasons.Should().BeNull();
            ratingsItem.Show.Overview.Should().BeNullOrEmpty();
            ratingsItem.Show.FirstAired.Should().NotHaveValue();
            ratingsItem.Show.Runtime.Should().NotHaveValue();
            ratingsItem.Show.Certification.Should().BeNullOrEmpty();
            ratingsItem.Show.Network.Should().BeNullOrEmpty();
            ratingsItem.Show.CountryCode.Should().BeNullOrEmpty();
            ratingsItem.Show.UpdatedAt.Should().NotHaveValue();
            ratingsItem.Show.Trailer.Should().BeNullOrEmpty();
            ratingsItem.Show.Homepage.Should().BeNullOrEmpty();
            ratingsItem.Show.Status.Should().BeNull();
            ratingsItem.Show.Rating.Should().NotHaveValue();
            ratingsItem.Show.Votes.Should().NotHaveValue();
            ratingsItem.Show.LanguageCode.Should().BeNullOrEmpty();
            ratingsItem.Show.AiredEpisodes.Should().NotHaveValue();
            ratingsItem.Season.Should().BeNull();
            ratingsItem.Episode.Should().NotBeNull();
            ratingsItem.Episode.SeasonNumber.Should().Be(1);
            ratingsItem.Episode.Number.Should().Be(1);
            ratingsItem.Episode.Title.Should().Be("Winter Is Coming");
            ratingsItem.Episode.Ids.Should().NotBeNull();
            ratingsItem.Episode.Ids.Trakt.Should().Be(73640U);
            ratingsItem.Episode.Ids.Tvdb.Should().Be(3254641U);
            ratingsItem.Episode.Ids.Imdb.Should().Be("tt1480055");
            ratingsItem.Episode.Ids.Tmdb.Should().Be(63056U);
            ratingsItem.Episode.Ids.TvRage.Should().Be(1065008299U);
            ratingsItem.Episode.NumberAbsolute.Should().NotHaveValue();
            ratingsItem.Episode.Overview.Should().BeNullOrEmpty();
            ratingsItem.Episode.Runtime.Should().NotHaveValue();
            ratingsItem.Episode.Rating.Should().NotHaveValue();
            ratingsItem.Episode.Votes.Should().NotHaveValue();
            ratingsItem.Episode.FirstAired.Should().NotHaveValue();
            ratingsItem.Episode.UpdatedAt.Should().NotHaveValue();
            ratingsItem.Episode.AvailableTranslationLanguageCodes.Should().BeNull();
            ratingsItem.Episode.Translations.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktRatingsItem_With_Type_Movie_From_Full_Json()
        {
            var jsonReader = new ITraktRatingsItemObjectJsonReader();
            var ratingsItem = await jsonReader.ReadObjectAsync(TYPE_MOVIE_FULL_JSON) as TraktRatingsItem;

            ratingsItem.Should().NotBeNull();
            ratingsItem.Rating.Should().Be(10);
            ratingsItem.RatedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            ratingsItem.Type.Should().Be(TraktRatingsItemType.Movie);
            ratingsItem.Movie.Should().NotBeNull();
            ratingsItem.Movie.Title.Should().Be("Star Wars: The Force Awakens");
            ratingsItem.Movie.Year.Should().Be(2015);
            ratingsItem.Movie.Ids.Should().NotBeNull();
            ratingsItem.Movie.Ids.Trakt.Should().Be(94024U);
            ratingsItem.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            ratingsItem.Movie.Ids.Imdb.Should().Be("tt2488496");
            ratingsItem.Movie.Ids.Tmdb.Should().Be(140607U);
            ratingsItem.Movie.Tagline.Should().Be("Every generation has a story.");
            ratingsItem.Movie.Overview.Should().Be("Thirty years after defeating the Galactic Empire, Han Solo and his allies face a new threat from the evil Kylo Ren and his army of Stormtroopers.");
            ratingsItem.Movie.Released.Should().Be(DateTime.Parse("2015-12-18"));
            ratingsItem.Movie.Runtime.Should().Be(136);
            ratingsItem.Movie.UpdatedAt.Should().Be(DateTime.Parse("2016-03-31T09:01:59Z").ToUniversalTime());
            ratingsItem.Movie.Trailer.Should().Be("http://youtube.com/watch?v=uwa7N0ShN2U");
            ratingsItem.Movie.Homepage.Should().Be("http://www.starwars.com/films/star-wars-episode-vii");
            ratingsItem.Movie.Rating.Should().Be(8.31988f);
            ratingsItem.Movie.Votes.Should().Be(9338);
            ratingsItem.Movie.LanguageCode.Should().Be("en");
            ratingsItem.Movie.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "de", "en", "it");
            ratingsItem.Movie.Genres.Should().NotBeNull().And.HaveCount(4).And.Contain("action", "adventure", "fantasy", "science-fiction");
            ratingsItem.Movie.Certification.Should().Be("PG-13");
            ratingsItem.Show.Should().BeNull();
            ratingsItem.Season.Should().BeNull();
            ratingsItem.Episode.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktRatingsItem_With_Type_Show_From_Full_Json()
        {
            var jsonReader = new ITraktRatingsItemObjectJsonReader();
            var ratingsItem = await jsonReader.ReadObjectAsync(TYPE_SHOW_FULL_JSON) as TraktRatingsItem;

            ratingsItem.Should().NotBeNull();
            ratingsItem.Rating.Should().Be(9);
            ratingsItem.RatedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            ratingsItem.Type.Should().Be(TraktRatingsItemType.Show);
            ratingsItem.Movie.Should().BeNull();
            ratingsItem.Show.Should().NotBeNull();
            ratingsItem.Show.Title.Should().Be("Game of Thrones");
            ratingsItem.Show.Year.Should().Be(2011);
            ratingsItem.Show.Airs.Should().NotBeNull();
            ratingsItem.Show.Airs.Day.Should().Be("Sunday");
            ratingsItem.Show.Airs.Time.Should().Be("21:00");
            ratingsItem.Show.Airs.TimeZoneId.Should().Be("America/New_York");
            ratingsItem.Show.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "fr", "it", "de");
            ratingsItem.Show.Ids.Should().NotBeNull();
            ratingsItem.Show.Ids.Trakt.Should().Be(1390U);
            ratingsItem.Show.Ids.Slug.Should().Be("game-of-thrones");
            ratingsItem.Show.Ids.Tvdb.Should().Be(121361U);
            ratingsItem.Show.Ids.Imdb.Should().Be("tt0944947");
            ratingsItem.Show.Ids.Tmdb.Should().Be(1399U);
            ratingsItem.Show.Ids.TvRage.Should().Be(24493U);
            ratingsItem.Show.Genres.Should().NotBeNull().And.HaveCount(5).And.Contain("drama", "fantasy", "science-fiction", "action", "adventure");
            ratingsItem.Show.Seasons.Should().BeNull();
            ratingsItem.Show.Overview.Should().Be("Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond.");
            ratingsItem.Show.FirstAired.Should().Be(DateTime.Parse("2011-04-17T07:00:00Z").ToUniversalTime());
            ratingsItem.Show.Runtime.Should().Be(60);
            ratingsItem.Show.Certification.Should().Be("TV-MA");
            ratingsItem.Show.Network.Should().Be("HBO");
            ratingsItem.Show.CountryCode.Should().Be("us");
            ratingsItem.Show.UpdatedAt.Should().Be(DateTime.Parse("2016-04-06T10:39:11Z").ToUniversalTime());
            ratingsItem.Show.Trailer.Should().Be("http://youtube.com/watch?v=F9Bo89m2f6g");
            ratingsItem.Show.Homepage.Should().Be("http://www.hbo.com/game-of-thrones");
            ratingsItem.Show.Status.Should().Be(TraktShowStatus.ReturningSeries);
            ratingsItem.Show.Rating.Should().Be(9.38327f);
            ratingsItem.Show.Votes.Should().Be(44773);
            ratingsItem.Show.LanguageCode.Should().Be("en");
            ratingsItem.Show.AiredEpisodes.Should().Be(50);
            ratingsItem.Season.Should().BeNull();
            ratingsItem.Episode.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktRatingsItem_With_Type_Season_From_Full_Json()
        {
            var jsonReader = new ITraktRatingsItemObjectJsonReader();
            var ratingsItem = await jsonReader.ReadObjectAsync(TYPE_SEASON_FULL_JSON) as TraktRatingsItem;

            ratingsItem.Should().NotBeNull();
            ratingsItem.Rating.Should().Be(8);
            ratingsItem.RatedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            ratingsItem.Type.Should().Be(TraktRatingsItemType.Season);
            ratingsItem.Movie.Should().BeNull();
            ratingsItem.Show.Should().BeNull();
            ratingsItem.Season.Should().NotBeNull();
            ratingsItem.Season.Number.Should().Be(1);
            ratingsItem.Season.Ids.Should().NotBeNull();
            ratingsItem.Season.Ids.Trakt.Should().Be(61430U);
            ratingsItem.Season.Ids.Tvdb.Should().Be(279121U);
            ratingsItem.Season.Ids.Tmdb.Should().Be(60523U);
            ratingsItem.Season.Ids.TvRage.Should().Be(36939U);
            ratingsItem.Season.Rating.Should().Be(8.57053f);
            ratingsItem.Season.Votes.Should().Be(794);
            ratingsItem.Season.TotalEpisodesCount.Should().Be(23);
            ratingsItem.Season.AiredEpisodesCount.Should().Be(23);
            ratingsItem.Season.Overview.Should().Be("Text text text");
            ratingsItem.Season.FirstAired.Should().Be(DateTime.Parse("2014-10-08T00:00:00.000Z").ToUniversalTime());
            ratingsItem.Season.Episodes.Should().NotBeNull().And.HaveCount(2);

            var episodes = ratingsItem.Season.Episodes.ToArray();

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

            ratingsItem.Episode.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktRatingsItem_With_Type_Episode_From_Full_Json()
        {
            var jsonReader = new ITraktRatingsItemObjectJsonReader();
            var ratingsItem = await jsonReader.ReadObjectAsync(TYPE_EPISODE_FULL_JSON) as TraktRatingsItem;

            ratingsItem.Should().NotBeNull();
            ratingsItem.Rating.Should().Be(7);
            ratingsItem.RatedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            ratingsItem.Type.Should().Be(TraktRatingsItemType.Episode);
            ratingsItem.Movie.Should().BeNull();
            ratingsItem.Show.Should().NotBeNull();
            ratingsItem.Show.Title.Should().Be("Game of Thrones");
            ratingsItem.Show.Year.Should().Be(2011);
            ratingsItem.Show.Airs.Should().NotBeNull();
            ratingsItem.Show.Airs.Day.Should().Be("Sunday");
            ratingsItem.Show.Airs.Time.Should().Be("21:00");
            ratingsItem.Show.Airs.TimeZoneId.Should().Be("America/New_York");
            ratingsItem.Show.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "fr", "it", "de");
            ratingsItem.Show.Ids.Should().NotBeNull();
            ratingsItem.Show.Ids.Trakt.Should().Be(1390U);
            ratingsItem.Show.Ids.Slug.Should().Be("game-of-thrones");
            ratingsItem.Show.Ids.Tvdb.Should().Be(121361U);
            ratingsItem.Show.Ids.Imdb.Should().Be("tt0944947");
            ratingsItem.Show.Ids.Tmdb.Should().Be(1399U);
            ratingsItem.Show.Ids.TvRage.Should().Be(24493U);
            ratingsItem.Show.Genres.Should().NotBeNull().And.HaveCount(5).And.Contain("drama", "fantasy", "science-fiction", "action", "adventure");
            ratingsItem.Show.Seasons.Should().BeNull();
            ratingsItem.Show.Overview.Should().Be("Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond.");
            ratingsItem.Show.FirstAired.Should().Be(DateTime.Parse("2011-04-17T07:00:00Z").ToUniversalTime());
            ratingsItem.Show.Runtime.Should().Be(60);
            ratingsItem.Show.Certification.Should().Be("TV-MA");
            ratingsItem.Show.Network.Should().Be("HBO");
            ratingsItem.Show.CountryCode.Should().Be("us");
            ratingsItem.Show.UpdatedAt.Should().Be(DateTime.Parse("2016-04-06T10:39:11Z").ToUniversalTime());
            ratingsItem.Show.Trailer.Should().Be("http://youtube.com/watch?v=F9Bo89m2f6g");
            ratingsItem.Show.Homepage.Should().Be("http://www.hbo.com/game-of-thrones");
            ratingsItem.Show.Status.Should().Be(TraktShowStatus.ReturningSeries);
            ratingsItem.Show.Rating.Should().Be(9.38327f);
            ratingsItem.Show.Votes.Should().Be(44773);
            ratingsItem.Show.LanguageCode.Should().Be("en");
            ratingsItem.Show.AiredEpisodes.Should().Be(50);
            ratingsItem.Season.Should().BeNull();
            ratingsItem.Episode.Should().NotBeNull();
            ratingsItem.Episode.SeasonNumber.Should().Be(1);
            ratingsItem.Episode.Number.Should().Be(1);
            ratingsItem.Episode.Title.Should().Be("Winter Is Coming");
            ratingsItem.Episode.Ids.Should().NotBeNull();
            ratingsItem.Episode.Ids.Trakt.Should().Be(73640U);
            ratingsItem.Episode.Ids.Tvdb.Should().Be(3254641U);
            ratingsItem.Episode.Ids.Imdb.Should().Be("tt1480055");
            ratingsItem.Episode.Ids.Tmdb.Should().Be(63056U);
            ratingsItem.Episode.Ids.TvRage.Should().Be(1065008299U);
            ratingsItem.Episode.NumberAbsolute.Should().Be(50);
            ratingsItem.Episode.Overview.Should().Be("Ned Stark, Lord of Winterfell learns that his mentor, Jon Arryn, has died and that King Robert is on his way north to offer Ned Arryn’s position as the King’s Hand. Across the Narrow Sea in Pentos, Viserys Targaryen plans to wed his sister Daenerys to the nomadic Dothraki warrior leader, Khal Drogo to forge an alliance to take the throne.");
            ratingsItem.Episode.Runtime.Should().Be(55);
            ratingsItem.Episode.Rating.Should().Be(9.0f);
            ratingsItem.Episode.Votes.Should().Be(111);
            ratingsItem.Episode.FirstAired.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());
            ratingsItem.Episode.UpdatedAt.Should().Be(DateTime.Parse("2014-08-29T23:16:39.000Z").ToUniversalTime());
            ratingsItem.Episode.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(2).And.Contain("en", "es");
            ratingsItem.Episode.Translations.Should().NotBeNull().And.HaveCount(2);

            var translations = ratingsItem.Episode.Translations.ToArray();

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
                ""rated_at"": ""2014-09-01T09:10:11.000Z"",
                ""rating"": 10,
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
                ""rated_at"": ""2014-09-01T09:10:11.000Z"",
                ""rating"": 9,
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
                ""rated_at"": ""2014-09-01T09:10:11.000Z"",
                ""rating"": 8,
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
                ""rated_at"": ""2014-09-01T09:10:11.000Z"",
                ""rating"": 7,
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
                ""rated_at"": ""2014-09-01T09:10:11.000Z"",
                ""rating"": 10,
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
                ""rated_at"": ""2014-09-01T09:10:11.000Z"",
                ""rating"": 9,
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
                ""rated_at"": ""2014-09-01T09:10:11.000Z"",
                ""rating"": 8,
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
                ""rated_at"": ""2014-09-01T09:10:11.000Z"",
                ""rating"": 7,
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

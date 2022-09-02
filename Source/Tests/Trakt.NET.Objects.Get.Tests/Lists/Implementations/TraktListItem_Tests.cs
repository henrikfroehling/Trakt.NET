namespace TraktNet.Objects.Get.Tests.Lists.Implementations
{
    using FluentAssertions;
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Enums;
    using TraktNet.Objects.Get.Lists;
    using TraktNet.Objects.Get.Lists.Json.Reader;
    using Xunit;

    [Category("Objects.Get.Lists.Implementations")]
    public class TraktListItem_Tests
    {
        [Fact]
        public void Test_TraktListItem_Default_Constructor()
        {
            var listItem = new TraktListItem();

            listItem.Id.Should().BeNull();
            listItem.Rank.Should().BeNull();
            listItem.ListedAt.Should().BeNull();
            listItem.Type.Should().BeNull();
            listItem.Movie.Should().BeNull();
            listItem.Show.Should().BeNull();
            listItem.Season.Should().BeNull();
            listItem.Episode.Should().BeNull();
            listItem.Person.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktListItem_With_Type_Movie_From_Minimal_Json()
        {
            var jsonReader = new ListItemObjectJsonReader();
            var listItem = await jsonReader.ReadObjectAsync(TYPE_MOVIE_MINIMAL_JSON) as TraktListItem;

            listItem.Should().NotBeNull();
            listItem.Id.Should().Be(101U);
            listItem.Rank.Should().Be("1");
            listItem.ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            listItem.Type.Should().Be(TraktListItemType.Movie);
            listItem.Movie.Should().NotBeNull();
            listItem.Movie.Title.Should().Be("Star Wars: The Force Awakens");
            listItem.Movie.Year.Should().Be(2015);
            listItem.Movie.Ids.Should().NotBeNull();
            listItem.Movie.Ids.Trakt.Should().Be(94024U);
            listItem.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            listItem.Movie.Ids.Imdb.Should().Be("tt2488496");
            listItem.Movie.Ids.Tmdb.Should().Be(140607U);
            listItem.Movie.Tagline.Should().BeNullOrEmpty();
            listItem.Movie.Overview.Should().BeNullOrEmpty();
            listItem.Movie.Released.Should().NotHaveValue();
            listItem.Movie.Runtime.Should().NotHaveValue();
            listItem.Movie.UpdatedAt.Should().NotHaveValue();
            listItem.Movie.Trailer.Should().BeNullOrEmpty();
            listItem.Movie.Homepage.Should().BeNullOrEmpty();
            listItem.Movie.Rating.Should().NotHaveValue();
            listItem.Movie.Votes.Should().NotHaveValue();
            listItem.Movie.LanguageCode.Should().BeNullOrEmpty();
            listItem.Movie.AvailableTranslationLanguageCodes.Should().BeNull();
            listItem.Movie.Genres.Should().BeNull();
            listItem.Movie.Certification.Should().BeNullOrEmpty();
            listItem.Show.Should().BeNull();
            listItem.Season.Should().BeNull();
            listItem.Episode.Should().BeNull();
            listItem.Person.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktListItem_With_Type_Show_From_Minimal_Json()
        {
            var jsonReader = new ListItemObjectJsonReader();
            var listItem = await jsonReader.ReadObjectAsync(TYPE_SHOW_MINIMAL_JSON) as TraktListItem;

            listItem.Should().NotBeNull();
            listItem.Id.Should().Be(101U);
            listItem.Rank.Should().Be("1");
            listItem.ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            listItem.Type.Should().Be(TraktListItemType.Show);
            listItem.Movie.Should().BeNull();
            listItem.Show.Should().NotBeNull();
            listItem.Show.Title.Should().Be("Game of Thrones");
            listItem.Show.Year.Should().Be(2011);
            listItem.Show.Airs.Should().BeNull();
            listItem.Show.AvailableTranslationLanguageCodes.Should().BeNull();
            listItem.Show.Ids.Should().NotBeNull();
            listItem.Show.Ids.Trakt.Should().Be(1390U);
            listItem.Show.Ids.Slug.Should().Be("game-of-thrones");
            listItem.Show.Ids.Tvdb.Should().Be(121361U);
            listItem.Show.Ids.Imdb.Should().Be("tt0944947");
            listItem.Show.Ids.Tmdb.Should().Be(1399U);
            listItem.Show.Ids.TvRage.Should().Be(24493U);
            listItem.Show.Genres.Should().BeNull();
            listItem.Show.Seasons.Should().BeNull();
            listItem.Show.Overview.Should().BeNullOrEmpty();
            listItem.Show.FirstAired.Should().NotHaveValue();
            listItem.Show.Runtime.Should().NotHaveValue();
            listItem.Show.Certification.Should().BeNullOrEmpty();
            listItem.Show.Network.Should().BeNullOrEmpty();
            listItem.Show.CountryCode.Should().BeNullOrEmpty();
            listItem.Show.UpdatedAt.Should().NotHaveValue();
            listItem.Show.Trailer.Should().BeNullOrEmpty();
            listItem.Show.Homepage.Should().BeNullOrEmpty();
            listItem.Show.Status.Should().BeNull();
            listItem.Show.Rating.Should().NotHaveValue();
            listItem.Show.Votes.Should().NotHaveValue();
            listItem.Show.LanguageCode.Should().BeNullOrEmpty();
            listItem.Show.AiredEpisodes.Should().NotHaveValue();
            listItem.Season.Should().BeNull();
            listItem.Episode.Should().BeNull();
            listItem.Person.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktListItem_With_Type_Season_From_Minimal_Json()
        {
            var jsonReader = new ListItemObjectJsonReader();
            var listItem = await jsonReader.ReadObjectAsync(TYPE_SEASON_MINIMAL_JSON) as TraktListItem;

            listItem.Should().NotBeNull();
            listItem.Id.Should().Be(101U);
            listItem.Rank.Should().Be("1");
            listItem.ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            listItem.Type.Should().Be(TraktListItemType.Season);
            listItem.Movie.Should().BeNull();
            listItem.Show.Should().BeNull();
            listItem.Season.Should().NotBeNull();
            listItem.Season.Number.Should().Be(1);
            listItem.Season.Ids.Should().NotBeNull();
            listItem.Season.Ids.Trakt.Should().Be(61430U);
            listItem.Season.Ids.Tvdb.Should().Be(279121U);
            listItem.Season.Ids.Tmdb.Should().Be(60523U);
            listItem.Season.Ids.TvRage.Should().Be(36939U);
            listItem.Season.Rating.Should().NotHaveValue();
            listItem.Season.Votes.Should().NotHaveValue();
            listItem.Season.TotalEpisodesCount.Should().NotHaveValue();
            listItem.Season.AiredEpisodesCount.Should().NotHaveValue();
            listItem.Season.Overview.Should().BeNullOrEmpty();
            listItem.Season.FirstAired.Should().NotHaveValue();
            listItem.Season.Episodes.Should().BeNull();
            listItem.Episode.Should().BeNull();
            listItem.Person.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktListItem_With_Type_Episode_From_Minimal_Json()
        {
            var jsonReader = new ListItemObjectJsonReader();
            var listItem = await jsonReader.ReadObjectAsync(TYPE_EPISODE_MINIMAL_JSON) as TraktListItem;

            listItem.Should().NotBeNull();
            listItem.Id.Should().Be(101U);
            listItem.Rank.Should().Be("1");
            listItem.ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            listItem.Type.Should().Be(TraktListItemType.Episode);
            listItem.Movie.Should().BeNull();
            listItem.Show.Should().NotBeNull();
            listItem.Show.Title.Should().Be("Game of Thrones");
            listItem.Show.Year.Should().Be(2011);
            listItem.Show.Airs.Should().BeNull();
            listItem.Show.AvailableTranslationLanguageCodes.Should().BeNull();
            listItem.Show.Ids.Should().NotBeNull();
            listItem.Show.Ids.Trakt.Should().Be(1390U);
            listItem.Show.Ids.Slug.Should().Be("game-of-thrones");
            listItem.Show.Ids.Tvdb.Should().Be(121361U);
            listItem.Show.Ids.Imdb.Should().Be("tt0944947");
            listItem.Show.Ids.Tmdb.Should().Be(1399U);
            listItem.Show.Ids.TvRage.Should().Be(24493U);
            listItem.Show.Genres.Should().BeNull();
            listItem.Show.Seasons.Should().BeNull();
            listItem.Show.Overview.Should().BeNullOrEmpty();
            listItem.Show.FirstAired.Should().NotHaveValue();
            listItem.Show.Runtime.Should().NotHaveValue();
            listItem.Show.Certification.Should().BeNullOrEmpty();
            listItem.Show.Network.Should().BeNullOrEmpty();
            listItem.Show.CountryCode.Should().BeNullOrEmpty();
            listItem.Show.UpdatedAt.Should().NotHaveValue();
            listItem.Show.Trailer.Should().BeNullOrEmpty();
            listItem.Show.Homepage.Should().BeNullOrEmpty();
            listItem.Show.Status.Should().BeNull();
            listItem.Show.Rating.Should().NotHaveValue();
            listItem.Show.Votes.Should().NotHaveValue();
            listItem.Show.LanguageCode.Should().BeNullOrEmpty();
            listItem.Show.AiredEpisodes.Should().NotHaveValue();
            listItem.Season.Should().BeNull();
            listItem.Episode.Should().NotBeNull();
            listItem.Episode.SeasonNumber.Should().Be(1);
            listItem.Episode.Number.Should().Be(1);
            listItem.Episode.Title.Should().Be("Winter Is Coming");
            listItem.Episode.Ids.Should().NotBeNull();
            listItem.Episode.Ids.Trakt.Should().Be(73640U);
            listItem.Episode.Ids.Tvdb.Should().Be(3254641U);
            listItem.Episode.Ids.Imdb.Should().Be("tt1480055");
            listItem.Episode.Ids.Tmdb.Should().Be(63056U);
            listItem.Episode.Ids.TvRage.Should().Be(1065008299U);
            listItem.Episode.NumberAbsolute.Should().NotHaveValue();
            listItem.Episode.Overview.Should().BeNullOrEmpty();
            listItem.Episode.Runtime.Should().NotHaveValue();
            listItem.Episode.Rating.Should().NotHaveValue();
            listItem.Episode.Votes.Should().NotHaveValue();
            listItem.Episode.FirstAired.Should().NotHaveValue();
            listItem.Episode.UpdatedAt.Should().NotHaveValue();
            listItem.Episode.AvailableTranslationLanguageCodes.Should().BeNull();
            listItem.Episode.Translations.Should().BeNull();
            listItem.Person.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktListItem_With_Type_Person_From_Minimal_Json()
        {
            var jsonReader = new ListItemObjectJsonReader();
            var listItem = await jsonReader.ReadObjectAsync(TYPE_PERSON_MINIMAL_JSON) as TraktListItem;

            listItem.Should().NotBeNull();
            listItem.Id.Should().Be(101U);
            listItem.Rank.Should().Be("1");
            listItem.ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            listItem.Type.Should().Be(TraktListItemType.Person);
            listItem.Movie.Should().BeNull();
            listItem.Show.Should().BeNull();
            listItem.Season.Should().BeNull();
            listItem.Episode.Should().BeNull();
            listItem.Person.Should().NotBeNull();
            listItem.Person.Name.Should().Be("Bryan Cranston");
            listItem.Person.Ids.Should().NotBeNull();
            listItem.Person.Ids.Trakt.Should().Be(297737U);
            listItem.Person.Ids.Slug.Should().Be("bryan-cranston");
            listItem.Person.Ids.Imdb.Should().Be("nm0186505");
            listItem.Person.Ids.Tmdb.Should().Be(17419U);
            listItem.Person.Ids.TvRage.Should().Be(1797U);
            listItem.Person.Biography.Should().BeNull();
            listItem.Person.Birthday.Should().BeNull();
            listItem.Person.Death.Should().BeNull();
            listItem.Person.Age.Should().Be(0);
            listItem.Person.Birthplace.Should().BeNull();
            listItem.Person.Homepage.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktListItem_With_Type_Movie_From_Full_Json()
        {
            var jsonReader = new ListItemObjectJsonReader();
            var listItem = await jsonReader.ReadObjectAsync(TYPE_MOVIE_FULL_JSON) as TraktListItem;

            listItem.Should().NotBeNull();
            listItem.Id.Should().Be(101U);
            listItem.Rank.Should().Be("1");
            listItem.ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            listItem.Type.Should().Be(TraktListItemType.Movie);
            listItem.Movie.Should().NotBeNull();
            listItem.Movie.Title.Should().Be("Star Wars: The Force Awakens");
            listItem.Movie.Year.Should().Be(2015);
            listItem.Movie.Ids.Should().NotBeNull();
            listItem.Movie.Ids.Trakt.Should().Be(94024U);
            listItem.Movie.Ids.Slug.Should().Be("star-wars-the-force-awakens-2015");
            listItem.Movie.Ids.Imdb.Should().Be("tt2488496");
            listItem.Movie.Ids.Tmdb.Should().Be(140607U);
            listItem.Movie.Tagline.Should().Be("Every generation has a story.");
            listItem.Movie.Overview.Should().Be("Thirty years after defeating the Galactic Empire, Han Solo and his allies face a new threat from the evil Kylo Ren and his army of Stormtroopers.");
            listItem.Movie.Released.Should().Be(DateTime.Parse("2015-12-18"));
            listItem.Movie.Runtime.Should().Be(136);
            listItem.Movie.UpdatedAt.Should().Be(DateTime.Parse("2016-03-31T09:01:59Z").ToUniversalTime());
            listItem.Movie.Trailer.Should().Be("http://youtube.com/watch?v=uwa7N0ShN2U");
            listItem.Movie.Homepage.Should().Be("http://www.starwars.com/films/star-wars-episode-vii");
            listItem.Movie.Rating.Should().Be(8.31988f);
            listItem.Movie.Votes.Should().Be(9338);
            listItem.Movie.LanguageCode.Should().Be("en");
            listItem.Movie.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "de", "en", "it");
            listItem.Movie.Genres.Should().NotBeNull().And.HaveCount(4).And.Contain("action", "adventure", "fantasy", "science-fiction");
            listItem.Movie.Certification.Should().Be("PG-13");
            listItem.Show.Should().BeNull();
            listItem.Season.Should().BeNull();
            listItem.Episode.Should().BeNull();
            listItem.Person.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktListItem_With_Type_Show_From_Full_Json()
        {
            var jsonReader = new ListItemObjectJsonReader();
            var listItem = await jsonReader.ReadObjectAsync(TYPE_SHOW_FULL_JSON) as TraktListItem;

            listItem.Should().NotBeNull();
            listItem.Id.Should().Be(101U);
            listItem.Rank.Should().Be("1");
            listItem.ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            listItem.Type.Should().Be(TraktListItemType.Show);
            listItem.Movie.Should().BeNull();
            listItem.Show.Should().NotBeNull();
            listItem.Show.Title.Should().Be("Game of Thrones");
            listItem.Show.Year.Should().Be(2011);
            listItem.Show.Airs.Should().NotBeNull();
            listItem.Show.Airs.Day.Should().Be("Sunday");
            listItem.Show.Airs.Time.Should().Be("21:00");
            listItem.Show.Airs.TimeZoneId.Should().Be("America/New_York");
            listItem.Show.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "fr", "it", "de");
            listItem.Show.Ids.Should().NotBeNull();
            listItem.Show.Ids.Trakt.Should().Be(1390U);
            listItem.Show.Ids.Slug.Should().Be("game-of-thrones");
            listItem.Show.Ids.Tvdb.Should().Be(121361U);
            listItem.Show.Ids.Imdb.Should().Be("tt0944947");
            listItem.Show.Ids.Tmdb.Should().Be(1399U);
            listItem.Show.Ids.TvRage.Should().Be(24493U);
            listItem.Show.Genres.Should().NotBeNull().And.HaveCount(5).And.Contain("drama", "fantasy", "science-fiction", "action", "adventure");
            listItem.Show.Seasons.Should().BeNull();
            listItem.Show.Overview.Should().Be("Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond.");
            listItem.Show.FirstAired.Should().Be(DateTime.Parse("2011-04-17T07:00:00Z").ToUniversalTime());
            listItem.Show.Runtime.Should().Be(60);
            listItem.Show.Certification.Should().Be("TV-MA");
            listItem.Show.Network.Should().Be("HBO");
            listItem.Show.CountryCode.Should().Be("us");
            listItem.Show.UpdatedAt.Should().Be(DateTime.Parse("2016-04-06T10:39:11Z").ToUniversalTime());
            listItem.Show.Trailer.Should().Be("http://youtube.com/watch?v=F9Bo89m2f6g");
            listItem.Show.Homepage.Should().Be("http://www.hbo.com/game-of-thrones");
            listItem.Show.Status.Should().Be(TraktShowStatus.ReturningSeries);
            listItem.Show.Rating.Should().Be(9.38327f);
            listItem.Show.Votes.Should().Be(44773);
            listItem.Show.LanguageCode.Should().Be("en");
            listItem.Show.AiredEpisodes.Should().Be(50);
            listItem.Season.Should().BeNull();
            listItem.Episode.Should().BeNull();
            listItem.Person.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktListItem_With_Type_Season_From_Full_Json()
        {
            var jsonReader = new ListItemObjectJsonReader();
            var listItem = await jsonReader.ReadObjectAsync(TYPE_SEASON_FULL_JSON) as TraktListItem;

            listItem.Should().NotBeNull();
            listItem.Id.Should().Be(101U);
            listItem.Rank.Should().Be("1");
            listItem.ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            listItem.Type.Should().Be(TraktListItemType.Season);
            listItem.Movie.Should().BeNull();
            listItem.Show.Should().BeNull();
            listItem.Season.Should().NotBeNull();
            listItem.Season.Number.Should().Be(1);
            listItem.Season.Ids.Should().NotBeNull();
            listItem.Season.Ids.Trakt.Should().Be(61430U);
            listItem.Season.Ids.Tvdb.Should().Be(279121U);
            listItem.Season.Ids.Tmdb.Should().Be(60523U);
            listItem.Season.Ids.TvRage.Should().Be(36939U);
            listItem.Season.Rating.Should().Be(8.57053f);
            listItem.Season.Votes.Should().Be(794);
            listItem.Season.TotalEpisodesCount.Should().Be(23);
            listItem.Season.AiredEpisodesCount.Should().Be(23);
            listItem.Season.Overview.Should().Be("Text text text");
            listItem.Season.FirstAired.Should().Be(DateTime.Parse("2014-10-08T00:00:00.000Z").ToUniversalTime());
            listItem.Season.Episodes.Should().NotBeNull().And.HaveCount(2);

            var episodes = listItem.Season.Episodes.ToArray();

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

            listItem.Episode.Should().BeNull();
            listItem.Person.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktListItem_With_Type_Episode_From_Full_Json()
        {
            var jsonReader = new ListItemObjectJsonReader();
            var listItem = await jsonReader.ReadObjectAsync(TYPE_EPISODE_FULL_JSON) as TraktListItem;

            listItem.Should().NotBeNull();
            listItem.Id.Should().Be(101U);
            listItem.Rank.Should().Be("1");
            listItem.ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            listItem.Type.Should().Be(TraktListItemType.Episode);
            listItem.Movie.Should().BeNull();
            listItem.Show.Should().NotBeNull();
            listItem.Show.Title.Should().Be("Game of Thrones");
            listItem.Show.Year.Should().Be(2011);
            listItem.Show.Airs.Should().NotBeNull();
            listItem.Show.Airs.Day.Should().Be("Sunday");
            listItem.Show.Airs.Time.Should().Be("21:00");
            listItem.Show.Airs.TimeZoneId.Should().Be("America/New_York");
            listItem.Show.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(4).And.Contain("en", "fr", "it", "de");
            listItem.Show.Ids.Should().NotBeNull();
            listItem.Show.Ids.Trakt.Should().Be(1390U);
            listItem.Show.Ids.Slug.Should().Be("game-of-thrones");
            listItem.Show.Ids.Tvdb.Should().Be(121361U);
            listItem.Show.Ids.Imdb.Should().Be("tt0944947");
            listItem.Show.Ids.Tmdb.Should().Be(1399U);
            listItem.Show.Ids.TvRage.Should().Be(24493U);
            listItem.Show.Genres.Should().NotBeNull().And.HaveCount(5).And.Contain("drama", "fantasy", "science-fiction", "action", "adventure");
            listItem.Show.Seasons.Should().BeNull();
            listItem.Show.Overview.Should().Be("Seven noble families fight for control of the mythical land of Westeros. Friction between the houses leads to full-scale war. All while a very ancient evil awakens in the farthest north. Amidst the war, a neglected military order of misfits, the Night's Watch, is all that stands between the realms of men and the icy horrors beyond.");
            listItem.Show.FirstAired.Should().Be(DateTime.Parse("2011-04-17T07:00:00Z").ToUniversalTime());
            listItem.Show.Runtime.Should().Be(60);
            listItem.Show.Certification.Should().Be("TV-MA");
            listItem.Show.Network.Should().Be("HBO");
            listItem.Show.CountryCode.Should().Be("us");
            listItem.Show.UpdatedAt.Should().Be(DateTime.Parse("2016-04-06T10:39:11Z").ToUniversalTime());
            listItem.Show.Trailer.Should().Be("http://youtube.com/watch?v=F9Bo89m2f6g");
            listItem.Show.Homepage.Should().Be("http://www.hbo.com/game-of-thrones");
            listItem.Show.Status.Should().Be(TraktShowStatus.ReturningSeries);
            listItem.Show.Rating.Should().Be(9.38327f);
            listItem.Show.Votes.Should().Be(44773);
            listItem.Show.LanguageCode.Should().Be("en");
            listItem.Show.AiredEpisodes.Should().Be(50);
            listItem.Season.Should().BeNull();
            listItem.Episode.Should().NotBeNull();
            listItem.Episode.SeasonNumber.Should().Be(1);
            listItem.Episode.Number.Should().Be(1);
            listItem.Episode.Title.Should().Be("Winter Is Coming");
            listItem.Episode.Ids.Should().NotBeNull();
            listItem.Episode.Ids.Trakt.Should().Be(73640U);
            listItem.Episode.Ids.Tvdb.Should().Be(3254641U);
            listItem.Episode.Ids.Imdb.Should().Be("tt1480055");
            listItem.Episode.Ids.Tmdb.Should().Be(63056U);
            listItem.Episode.Ids.TvRage.Should().Be(1065008299U);
            listItem.Episode.NumberAbsolute.Should().Be(50);
            listItem.Episode.Overview.Should().Be("Ned Stark, Lord of Winterfell learns that his mentor, Jon Arryn, has died and that King Robert is on his way north to offer Ned Arryn’s position as the King’s Hand. Across the Narrow Sea in Pentos, Viserys Targaryen plans to wed his sister Daenerys to the nomadic Dothraki warrior leader, Khal Drogo to forge an alliance to take the throne.");
            listItem.Episode.Runtime.Should().Be(55);
            listItem.Episode.Rating.Should().Be(9.0f);
            listItem.Episode.Votes.Should().Be(111);
            listItem.Episode.FirstAired.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());
            listItem.Episode.UpdatedAt.Should().Be(DateTime.Parse("2014-08-29T23:16:39.000Z").ToUniversalTime());
            listItem.Episode.AvailableTranslationLanguageCodes.Should().NotBeNull().And.HaveCount(2).And.Contain("en", "es");
            listItem.Episode.Translations.Should().NotBeNull().And.HaveCount(2);

            var translations = listItem.Episode.Translations.ToArray();

            translations[0].Should().NotBeNull();
            translations[0].Title.Should().Be("Winter Is Coming");
            translations[0].Overview.Should().Be("Jon Arryn, the Hand of the King, is dead. King Robert Baratheon plans to ask his oldest friend, Eddard Stark, to take Jon's place. Across the sea, Viserys Targaryen plans to wed his sister to a nomadic warlord in exchange for an army.");
            translations[0].LanguageCode.Should().Be("en");

            translations[1].Should().NotBeNull();
            translations[1].Title.Should().Be("Se acerca el invierno");
            translations[1].Overview.Should().Be("El Lord Ned Stark está preocupado por los perturbantes reportes de un desertor del Nights Watch; El Rey Robert y los Lannisters llegan a Winterfell; el exiliado Viserys Targaryen forja una nueva y poderosa alianza.");
            translations[1].LanguageCode.Should().Be("es");

            listItem.Person.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktListItem_With_Type_Person_From_Full_Json()
        {
            var jsonReader = new ListItemObjectJsonReader();
            var listItem = await jsonReader.ReadObjectAsync(TYPE_PERSON_FULL_JSON) as TraktListItem;

            listItem.Should().NotBeNull();
            listItem.Id.Should().Be(101U);
            listItem.Rank.Should().Be("1");
            listItem.ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            listItem.Type.Should().Be(TraktListItemType.Person);
            listItem.Movie.Should().BeNull();
            listItem.Show.Should().BeNull();
            listItem.Season.Should().BeNull();
            listItem.Episode.Should().BeNull();
            listItem.Person.Should().NotBeNull();
            listItem.Person.Name.Should().Be("Bryan Cranston");
            listItem.Person.Ids.Should().NotBeNull();
            listItem.Person.Ids.Trakt.Should().Be(297737U);
            listItem.Person.Ids.Slug.Should().Be("bryan-cranston");
            listItem.Person.Ids.Imdb.Should().Be("nm0186505");
            listItem.Person.Ids.Tmdb.Should().Be(17419U);
            listItem.Person.Ids.TvRage.Should().Be(1797U);
            listItem.Person.Biography.Should().Be("Bryan Lee Cranston(born March 7, 1956) is an American actor, voice actor, writer and director.He is perhaps best known for his roles as Hal, the father in the Fox situation comedy Malcolm in the Middle, and as Walter White in the AMC drama series Breaking Bad, for which he has won three consecutive Outstanding Lead Actor in a Drama Series Emmy Awards. Other notable roles include Dr. Tim Whatley on Seinfeld, Doug Heffernan's neighbor in The King of Queens, Astronaut Buzz Aldrin in From the Earth to the Moon, and Ted Mosby's boss on How I Met Your Mother. Description above from the Wikipedia article Bryan Cranston, licensed under CC-BY-SA, full list of contributors on Wikipedia.");
            listItem.Person.Birthday.Should().Be(DateTime.Parse("1956-03-07T00:00:00Z").ToUniversalTime());
            listItem.Person.Death.Should().Be(DateTime.Parse("2016-04-06T00:00:00Z").ToUniversalTime());
            listItem.Person.Age.Should().Be(60);
            listItem.Person.Birthplace.Should().Be("San Fernando Valley, California, USA");
            listItem.Person.Homepage.Should().Be("http://www.bryancranston.com/");
        }

        private const string TYPE_MOVIE_MINIMAL_JSON =
            @"{
                ""id"": 101,
                ""rank"": ""1"",
                ""listed_at"": ""2014-09-01T09:10:11.000Z"",
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
                ""rank"": ""1"",
                ""listed_at"": ""2014-09-01T09:10:11.000Z"",
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
                ""rank"": ""1"",
                ""listed_at"": ""2014-09-01T09:10:11.000Z"",
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
                ""rank"": ""1"",
                ""listed_at"": ""2014-09-01T09:10:11.000Z"",
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

        private const string TYPE_PERSON_MINIMAL_JSON =
            @"{
                ""id"": 101,
                ""rank"": ""1"",
                ""listed_at"": ""2014-09-01T09:10:11.000Z"",
                ""type"": ""person"",
                ""person"": {
                  ""name"": ""Bryan Cranston"",
                  ""ids"": {
                    ""trakt"": 297737,
                    ""slug"": ""bryan-cranston"",
                    ""imdb"": ""nm0186505"",
                    ""tmdb"": 17419,
                    ""tvrage"": 1797
                  }
                }
              }";

        private const string TYPE_MOVIE_FULL_JSON =
            @"{
                ""id"": 101,
                ""rank"": ""1"",
                ""listed_at"": ""2014-09-01T09:10:11.000Z"",
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
                ""rank"": ""1"",
                ""listed_at"": ""2014-09-01T09:10:11.000Z"",
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
                ""rank"": ""1"",
                ""listed_at"": ""2014-09-01T09:10:11.000Z"",
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
                ""rank"": ""1"",
                ""listed_at"": ""2014-09-01T09:10:11.000Z"",
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

        private const string TYPE_PERSON_FULL_JSON =
            @"{
                ""id"": 101,
                ""rank"": ""1"",
                ""listed_at"": ""2014-09-01T09:10:11.000Z"",
                ""type"": ""person"",
                ""person"": {
                  ""name"": ""Bryan Cranston"",
                  ""ids"": {
                    ""trakt"": 297737,
                    ""slug"": ""bryan-cranston"",
                    ""imdb"": ""nm0186505"",
                    ""tmdb"": 17419,
                    ""tvrage"": 1797
                  },
                  ""biography"": ""Bryan Lee Cranston(born March 7, 1956) is an American actor, voice actor, writer and director.He is perhaps best known for his roles as Hal, the father in the Fox situation comedy Malcolm in the Middle, and as Walter White in the AMC drama series Breaking Bad, for which he has won three consecutive Outstanding Lead Actor in a Drama Series Emmy Awards. Other notable roles include Dr. Tim Whatley on Seinfeld, Doug Heffernan's neighbor in The King of Queens, Astronaut Buzz Aldrin in From the Earth to the Moon, and Ted Mosby's boss on How I Met Your Mother. Description above from the Wikipedia article Bryan Cranston, licensed under CC-BY-SA, full list of contributors on Wikipedia."",
                  ""birthday"": ""1956-03-07"",
                  ""death"": ""2016-04-06"",
                  ""birthplace"": ""San Fernando Valley, California, USA"",
                  ""homepage"": ""http://www.bryancranston.com/""
                }
              }";
    }
}

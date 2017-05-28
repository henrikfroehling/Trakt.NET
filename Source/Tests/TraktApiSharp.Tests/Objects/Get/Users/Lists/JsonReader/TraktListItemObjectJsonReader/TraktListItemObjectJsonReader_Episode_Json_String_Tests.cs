namespace TraktApiSharp.Tests.Objects.Get.Users.Lists.JsonReader
{
    using FluentAssertions;
    using System;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Enums;
    using TraktApiSharp.Objects.Get.Users.Lists.JsonReader;
    using Xunit;

    [Category("Objects.Get.Users.Lists.JsonReader")]
    public partial class TraktListItemObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_TraktListItemObjectJsonReader_Episode_ReadObject_From_Json_String_Complete()
        {
            var jsonReader = new TraktListItemObjectJsonReader();

            var traktListItem = await jsonReader.ReadObjectAsync(TYPE_EPISODE_JSON_COMPLETE);

            traktListItem.Should().NotBeNull();
            traktListItem.Rank.Should().Be("1");
            traktListItem.ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            traktListItem.Type.Should().Be(TraktListItemType.Episode);
            traktListItem.Episode.Should().NotBeNull();
            traktListItem.Episode.SeasonNumber.Should().Be(1);
            traktListItem.Episode.Number.Should().Be(1);
            traktListItem.Episode.Title.Should().Be("Winter Is Coming");
            traktListItem.Episode.Ids.Should().NotBeNull();
            traktListItem.Episode.Ids.Trakt.Should().Be(73640U);
            traktListItem.Episode.Ids.Tvdb.Should().Be(3254641U);
            traktListItem.Episode.Ids.Imdb.Should().Be("tt1480055");
            traktListItem.Episode.Ids.Tmdb.Should().Be(63056U);
            traktListItem.Episode.Ids.TvRage.Should().Be(1065008299U);
            traktListItem.Show.Should().NotBeNull();
            traktListItem.Show.Title.Should().Be("Game of Thrones");
            traktListItem.Show.Year.Should().Be(2011);
            traktListItem.Show.Ids.Should().NotBeNull();
            traktListItem.Show.Ids.Trakt.Should().Be(1390U);
            traktListItem.Show.Ids.Slug.Should().Be("game-of-thrones");
            traktListItem.Show.Ids.Tvdb.Should().Be(121361U);
            traktListItem.Show.Ids.Imdb.Should().Be("tt0944947");
            traktListItem.Show.Ids.Tmdb.Should().Be(1399U);
            traktListItem.Show.Ids.TvRage.Should().Be(24493U);

            traktListItem.Movie.Should().BeNull();
            traktListItem.Season.Should().BeNull();
            traktListItem.Person.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktListItemObjectJsonReader_Episode_ReadObject_From_Json_String_Incomplete_1()
        {
            var jsonReader = new TraktListItemObjectJsonReader();

            var traktListItem = await jsonReader.ReadObjectAsync(TYPE_EPISODE_JSON_INCOMPLETE_1);

            traktListItem.Should().NotBeNull();
            traktListItem.Rank.Should().BeNull();
            traktListItem.ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            traktListItem.Type.Should().Be(TraktListItemType.Episode);
            traktListItem.Episode.Should().NotBeNull();
            traktListItem.Episode.SeasonNumber.Should().Be(1);
            traktListItem.Episode.Number.Should().Be(1);
            traktListItem.Episode.Title.Should().Be("Winter Is Coming");
            traktListItem.Episode.Ids.Should().NotBeNull();
            traktListItem.Episode.Ids.Trakt.Should().Be(73640U);
            traktListItem.Episode.Ids.Tvdb.Should().Be(3254641U);
            traktListItem.Episode.Ids.Imdb.Should().Be("tt1480055");
            traktListItem.Episode.Ids.Tmdb.Should().Be(63056U);
            traktListItem.Episode.Ids.TvRage.Should().Be(1065008299U);
            traktListItem.Show.Should().NotBeNull();
            traktListItem.Show.Title.Should().Be("Game of Thrones");
            traktListItem.Show.Year.Should().Be(2011);
            traktListItem.Show.Ids.Should().NotBeNull();
            traktListItem.Show.Ids.Trakt.Should().Be(1390U);
            traktListItem.Show.Ids.Slug.Should().Be("game-of-thrones");
            traktListItem.Show.Ids.Tvdb.Should().Be(121361U);
            traktListItem.Show.Ids.Imdb.Should().Be("tt0944947");
            traktListItem.Show.Ids.Tmdb.Should().Be(1399U);
            traktListItem.Show.Ids.TvRage.Should().Be(24493U);

            traktListItem.Movie.Should().BeNull();
            traktListItem.Season.Should().BeNull();
            traktListItem.Person.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktListItemObjectJsonReader_Episode_ReadObject_From_Json_String_Incomplete_2()
        {
            var jsonReader = new TraktListItemObjectJsonReader();

            var traktListItem = await jsonReader.ReadObjectAsync(TYPE_EPISODE_JSON_INCOMPLETE_2);

            traktListItem.Should().NotBeNull();
            traktListItem.Rank.Should().Be("1");
            traktListItem.ListedAt.Should().BeNull();
            traktListItem.Type.Should().Be(TraktListItemType.Episode);
            traktListItem.Episode.Should().NotBeNull();
            traktListItem.Episode.SeasonNumber.Should().Be(1);
            traktListItem.Episode.Number.Should().Be(1);
            traktListItem.Episode.Title.Should().Be("Winter Is Coming");
            traktListItem.Episode.Ids.Should().NotBeNull();
            traktListItem.Episode.Ids.Trakt.Should().Be(73640U);
            traktListItem.Episode.Ids.Tvdb.Should().Be(3254641U);
            traktListItem.Episode.Ids.Imdb.Should().Be("tt1480055");
            traktListItem.Episode.Ids.Tmdb.Should().Be(63056U);
            traktListItem.Episode.Ids.TvRage.Should().Be(1065008299U);
            traktListItem.Show.Should().NotBeNull();
            traktListItem.Show.Title.Should().Be("Game of Thrones");
            traktListItem.Show.Year.Should().Be(2011);
            traktListItem.Show.Ids.Should().NotBeNull();
            traktListItem.Show.Ids.Trakt.Should().Be(1390U);
            traktListItem.Show.Ids.Slug.Should().Be("game-of-thrones");
            traktListItem.Show.Ids.Tvdb.Should().Be(121361U);
            traktListItem.Show.Ids.Imdb.Should().Be("tt0944947");
            traktListItem.Show.Ids.Tmdb.Should().Be(1399U);
            traktListItem.Show.Ids.TvRage.Should().Be(24493U);

            traktListItem.Movie.Should().BeNull();
            traktListItem.Season.Should().BeNull();
            traktListItem.Person.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktListItemObjectJsonReader_Episode_ReadObject_From_Json_String_Incomplete_3()
        {
            var jsonReader = new TraktListItemObjectJsonReader();

            var traktListItem = await jsonReader.ReadObjectAsync(TYPE_EPISODE_JSON_INCOMPLETE_3);

            traktListItem.Should().NotBeNull();
            traktListItem.Rank.Should().Be("1");
            traktListItem.ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            traktListItem.Type.Should().BeNull();
            traktListItem.Episode.Should().NotBeNull();
            traktListItem.Episode.SeasonNumber.Should().Be(1);
            traktListItem.Episode.Number.Should().Be(1);
            traktListItem.Episode.Title.Should().Be("Winter Is Coming");
            traktListItem.Episode.Ids.Should().NotBeNull();
            traktListItem.Episode.Ids.Trakt.Should().Be(73640U);
            traktListItem.Episode.Ids.Tvdb.Should().Be(3254641U);
            traktListItem.Episode.Ids.Imdb.Should().Be("tt1480055");
            traktListItem.Episode.Ids.Tmdb.Should().Be(63056U);
            traktListItem.Episode.Ids.TvRage.Should().Be(1065008299U);
            traktListItem.Show.Should().NotBeNull();
            traktListItem.Show.Title.Should().Be("Game of Thrones");
            traktListItem.Show.Year.Should().Be(2011);
            traktListItem.Show.Ids.Should().NotBeNull();
            traktListItem.Show.Ids.Trakt.Should().Be(1390U);
            traktListItem.Show.Ids.Slug.Should().Be("game-of-thrones");
            traktListItem.Show.Ids.Tvdb.Should().Be(121361U);
            traktListItem.Show.Ids.Imdb.Should().Be("tt0944947");
            traktListItem.Show.Ids.Tmdb.Should().Be(1399U);
            traktListItem.Show.Ids.TvRage.Should().Be(24493U);

            traktListItem.Movie.Should().BeNull();
            traktListItem.Season.Should().BeNull();
            traktListItem.Person.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktListItemObjectJsonReader_Episode_ReadObject_From_Json_String_Incomplete_4()
        {
            var jsonReader = new TraktListItemObjectJsonReader();

            var traktListItem = await jsonReader.ReadObjectAsync(TYPE_EPISODE_JSON_INCOMPLETE_4);

            traktListItem.Should().NotBeNull();
            traktListItem.Rank.Should().Be("1");
            traktListItem.ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            traktListItem.Type.Should().Be(TraktListItemType.Episode);
            traktListItem.Episode.Should().BeNull();
            traktListItem.Show.Should().NotBeNull();
            traktListItem.Show.Title.Should().Be("Game of Thrones");
            traktListItem.Show.Year.Should().Be(2011);
            traktListItem.Show.Ids.Should().NotBeNull();
            traktListItem.Show.Ids.Trakt.Should().Be(1390U);
            traktListItem.Show.Ids.Slug.Should().Be("game-of-thrones");
            traktListItem.Show.Ids.Tvdb.Should().Be(121361U);
            traktListItem.Show.Ids.Imdb.Should().Be("tt0944947");
            traktListItem.Show.Ids.Tmdb.Should().Be(1399U);
            traktListItem.Show.Ids.TvRage.Should().Be(24493U);

            traktListItem.Movie.Should().BeNull();
            traktListItem.Season.Should().BeNull();
            traktListItem.Person.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktListItemObjectJsonReader_Episode_ReadObject_From_Json_String_Incomplete_5()
        {
            var jsonReader = new TraktListItemObjectJsonReader();

            var traktListItem = await jsonReader.ReadObjectAsync(TYPE_EPISODE_JSON_INCOMPLETE_5);

            traktListItem.Should().NotBeNull();
            traktListItem.Rank.Should().Be("1");
            traktListItem.ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            traktListItem.Type.Should().Be(TraktListItemType.Episode);
            traktListItem.Episode.Should().NotBeNull();
            traktListItem.Episode.SeasonNumber.Should().Be(1);
            traktListItem.Episode.Number.Should().Be(1);
            traktListItem.Episode.Title.Should().Be("Winter Is Coming");
            traktListItem.Episode.Ids.Should().NotBeNull();
            traktListItem.Episode.Ids.Trakt.Should().Be(73640U);
            traktListItem.Episode.Ids.Tvdb.Should().Be(3254641U);
            traktListItem.Episode.Ids.Imdb.Should().Be("tt1480055");
            traktListItem.Episode.Ids.Tmdb.Should().Be(63056U);
            traktListItem.Episode.Ids.TvRage.Should().Be(1065008299U);
            traktListItem.Show.Should().BeNull();

            traktListItem.Movie.Should().BeNull();
            traktListItem.Season.Should().BeNull();
            traktListItem.Person.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktListItemObjectJsonReader_Episode_ReadObject_From_Json_String_Incomplete_6()
        {
            var jsonReader = new TraktListItemObjectJsonReader();

            var traktListItem = await jsonReader.ReadObjectAsync(TYPE_EPISODE_JSON_INCOMPLETE_6);

            traktListItem.Should().NotBeNull();
            traktListItem.Rank.Should().Be("1");
            traktListItem.ListedAt.Should().BeNull();
            traktListItem.Type.Should().BeNull();
            traktListItem.Episode.Should().BeNull();
            traktListItem.Show.Should().BeNull();

            traktListItem.Movie.Should().BeNull();
            traktListItem.Season.Should().BeNull();
            traktListItem.Person.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktListItemObjectJsonReader_Episode_ReadObject_From_Json_String_Incomplete_7()
        {
            var jsonReader = new TraktListItemObjectJsonReader();

            var traktListItem = await jsonReader.ReadObjectAsync(TYPE_EPISODE_JSON_INCOMPLETE_7);

            traktListItem.Should().NotBeNull();
            traktListItem.Rank.Should().BeNull();
            traktListItem.ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            traktListItem.Type.Should().BeNull();
            traktListItem.Episode.Should().BeNull();
            traktListItem.Show.Should().BeNull();

            traktListItem.Movie.Should().BeNull();
            traktListItem.Season.Should().BeNull();
            traktListItem.Person.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktListItemObjectJsonReader_Episode_ReadObject_From_Json_String_Incomplete_8()
        {
            var jsonReader = new TraktListItemObjectJsonReader();

            var traktListItem = await jsonReader.ReadObjectAsync(TYPE_EPISODE_JSON_INCOMPLETE_8);

            traktListItem.Should().NotBeNull();
            traktListItem.Rank.Should().BeNull();
            traktListItem.ListedAt.Should().BeNull();
            traktListItem.Type.Should().Be(TraktListItemType.Episode);
            traktListItem.Episode.Should().BeNull();
            traktListItem.Show.Should().BeNull();

            traktListItem.Movie.Should().BeNull();
            traktListItem.Season.Should().BeNull();
            traktListItem.Person.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktListItemObjectJsonReader_Episode_ReadObject_From_Json_String_Incomplete_9()
        {
            var jsonReader = new TraktListItemObjectJsonReader();

            var traktListItem = await jsonReader.ReadObjectAsync(TYPE_EPISODE_JSON_INCOMPLETE_9);

            traktListItem.Should().NotBeNull();
            traktListItem.Rank.Should().BeNull();
            traktListItem.ListedAt.Should().BeNull();
            traktListItem.Type.Should().BeNull();
            traktListItem.Episode.Should().NotBeNull();
            traktListItem.Episode.SeasonNumber.Should().Be(1);
            traktListItem.Episode.Number.Should().Be(1);
            traktListItem.Episode.Title.Should().Be("Winter Is Coming");
            traktListItem.Episode.Ids.Should().NotBeNull();
            traktListItem.Episode.Ids.Trakt.Should().Be(73640U);
            traktListItem.Episode.Ids.Tvdb.Should().Be(3254641U);
            traktListItem.Episode.Ids.Imdb.Should().Be("tt1480055");
            traktListItem.Episode.Ids.Tmdb.Should().Be(63056U);
            traktListItem.Episode.Ids.TvRage.Should().Be(1065008299U);
            traktListItem.Show.Should().BeNull();

            traktListItem.Movie.Should().BeNull();
            traktListItem.Season.Should().BeNull();
            traktListItem.Person.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktListItemObjectJsonReader_Episode_ReadObject_From_Json_String_Incomplete_10()
        {
            var jsonReader = new TraktListItemObjectJsonReader();

            var traktListItem = await jsonReader.ReadObjectAsync(TYPE_EPISODE_JSON_INCOMPLETE_10);

            traktListItem.Should().NotBeNull();
            traktListItem.Rank.Should().BeNull();
            traktListItem.ListedAt.Should().BeNull();
            traktListItem.Type.Should().BeNull();
            traktListItem.Episode.Should().BeNull();
            traktListItem.Show.Should().NotBeNull();
            traktListItem.Show.Title.Should().Be("Game of Thrones");
            traktListItem.Show.Year.Should().Be(2011);
            traktListItem.Show.Ids.Should().NotBeNull();
            traktListItem.Show.Ids.Trakt.Should().Be(1390U);
            traktListItem.Show.Ids.Slug.Should().Be("game-of-thrones");
            traktListItem.Show.Ids.Tvdb.Should().Be(121361U);
            traktListItem.Show.Ids.Imdb.Should().Be("tt0944947");
            traktListItem.Show.Ids.Tmdb.Should().Be(1399U);
            traktListItem.Show.Ids.TvRage.Should().Be(24493U);

            traktListItem.Movie.Should().BeNull();
            traktListItem.Season.Should().BeNull();
            traktListItem.Person.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktListItemObjectJsonReader_Episode_ReadObject_From_Json_String_Not_Valid_1()
        {
            var jsonReader = new TraktListItemObjectJsonReader();

            var traktListItem = await jsonReader.ReadObjectAsync(TYPE_EPISODE_JSON_NOT_VALID_1);

            traktListItem.Should().NotBeNull();
            traktListItem.Rank.Should().BeNull();
            traktListItem.ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            traktListItem.Type.Should().Be(TraktListItemType.Episode);
            traktListItem.Episode.Should().NotBeNull();
            traktListItem.Episode.SeasonNumber.Should().Be(1);
            traktListItem.Episode.Number.Should().Be(1);
            traktListItem.Episode.Title.Should().Be("Winter Is Coming");
            traktListItem.Episode.Ids.Should().NotBeNull();
            traktListItem.Episode.Ids.Trakt.Should().Be(73640U);
            traktListItem.Episode.Ids.Tvdb.Should().Be(3254641U);
            traktListItem.Episode.Ids.Imdb.Should().Be("tt1480055");
            traktListItem.Episode.Ids.Tmdb.Should().Be(63056U);
            traktListItem.Episode.Ids.TvRage.Should().Be(1065008299U);
            traktListItem.Show.Should().NotBeNull();
            traktListItem.Show.Title.Should().Be("Game of Thrones");
            traktListItem.Show.Year.Should().Be(2011);
            traktListItem.Show.Ids.Should().NotBeNull();
            traktListItem.Show.Ids.Trakt.Should().Be(1390U);
            traktListItem.Show.Ids.Slug.Should().Be("game-of-thrones");
            traktListItem.Show.Ids.Tvdb.Should().Be(121361U);
            traktListItem.Show.Ids.Imdb.Should().Be("tt0944947");
            traktListItem.Show.Ids.Tmdb.Should().Be(1399U);
            traktListItem.Show.Ids.TvRage.Should().Be(24493U);

            traktListItem.Movie.Should().BeNull();
            traktListItem.Season.Should().BeNull();
            traktListItem.Person.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktListItemObjectJsonReader_Episode_ReadObject_From_Json_String_Not_Valid_2()
        {
            var jsonReader = new TraktListItemObjectJsonReader();

            var traktListItem = await jsonReader.ReadObjectAsync(TYPE_EPISODE_JSON_NOT_VALID_2);

            traktListItem.Should().NotBeNull();
            traktListItem.Rank.Should().Be("1");
            traktListItem.ListedAt.Should().BeNull();
            traktListItem.Type.Should().Be(TraktListItemType.Episode);
            traktListItem.Episode.Should().NotBeNull();
            traktListItem.Episode.SeasonNumber.Should().Be(1);
            traktListItem.Episode.Number.Should().Be(1);
            traktListItem.Episode.Title.Should().Be("Winter Is Coming");
            traktListItem.Episode.Ids.Should().NotBeNull();
            traktListItem.Episode.Ids.Trakt.Should().Be(73640U);
            traktListItem.Episode.Ids.Tvdb.Should().Be(3254641U);
            traktListItem.Episode.Ids.Imdb.Should().Be("tt1480055");
            traktListItem.Episode.Ids.Tmdb.Should().Be(63056U);
            traktListItem.Episode.Ids.TvRage.Should().Be(1065008299U);
            traktListItem.Show.Should().NotBeNull();
            traktListItem.Show.Title.Should().Be("Game of Thrones");
            traktListItem.Show.Year.Should().Be(2011);
            traktListItem.Show.Ids.Should().NotBeNull();
            traktListItem.Show.Ids.Trakt.Should().Be(1390U);
            traktListItem.Show.Ids.Slug.Should().Be("game-of-thrones");
            traktListItem.Show.Ids.Tvdb.Should().Be(121361U);
            traktListItem.Show.Ids.Imdb.Should().Be("tt0944947");
            traktListItem.Show.Ids.Tmdb.Should().Be(1399U);
            traktListItem.Show.Ids.TvRage.Should().Be(24493U);

            traktListItem.Movie.Should().BeNull();
            traktListItem.Season.Should().BeNull();
            traktListItem.Person.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktListItemObjectJsonReader_Episode_ReadObject_From_Json_String_Not_Valid_3()
        {
            var jsonReader = new TraktListItemObjectJsonReader();

            var traktListItem = await jsonReader.ReadObjectAsync(TYPE_EPISODE_JSON_NOT_VALID_3);

            traktListItem.Should().NotBeNull();
            traktListItem.Rank.Should().Be("1");
            traktListItem.ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            traktListItem.Type.Should().BeNull();
            traktListItem.Episode.Should().NotBeNull();
            traktListItem.Episode.SeasonNumber.Should().Be(1);
            traktListItem.Episode.Number.Should().Be(1);
            traktListItem.Episode.Title.Should().Be("Winter Is Coming");
            traktListItem.Episode.Ids.Should().NotBeNull();
            traktListItem.Episode.Ids.Trakt.Should().Be(73640U);
            traktListItem.Episode.Ids.Tvdb.Should().Be(3254641U);
            traktListItem.Episode.Ids.Imdb.Should().Be("tt1480055");
            traktListItem.Episode.Ids.Tmdb.Should().Be(63056U);
            traktListItem.Episode.Ids.TvRage.Should().Be(1065008299U);
            traktListItem.Show.Should().NotBeNull();
            traktListItem.Show.Title.Should().Be("Game of Thrones");
            traktListItem.Show.Year.Should().Be(2011);
            traktListItem.Show.Ids.Should().NotBeNull();
            traktListItem.Show.Ids.Trakt.Should().Be(1390U);
            traktListItem.Show.Ids.Slug.Should().Be("game-of-thrones");
            traktListItem.Show.Ids.Tvdb.Should().Be(121361U);
            traktListItem.Show.Ids.Imdb.Should().Be("tt0944947");
            traktListItem.Show.Ids.Tmdb.Should().Be(1399U);
            traktListItem.Show.Ids.TvRage.Should().Be(24493U);

            traktListItem.Movie.Should().BeNull();
            traktListItem.Season.Should().BeNull();
            traktListItem.Person.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktListItemObjectJsonReader_Episode_ReadObject_From_Json_String_Not_Valid_4()
        {
            var jsonReader = new TraktListItemObjectJsonReader();

            var traktListItem = await jsonReader.ReadObjectAsync(TYPE_EPISODE_JSON_NOT_VALID_4);

            traktListItem.Should().NotBeNull();
            traktListItem.Rank.Should().Be("1");
            traktListItem.ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            traktListItem.Type.Should().Be(TraktListItemType.Episode);
            traktListItem.Episode.Should().BeNull();
            traktListItem.Show.Should().NotBeNull();
            traktListItem.Show.Title.Should().Be("Game of Thrones");
            traktListItem.Show.Year.Should().Be(2011);
            traktListItem.Show.Ids.Should().NotBeNull();
            traktListItem.Show.Ids.Trakt.Should().Be(1390U);
            traktListItem.Show.Ids.Slug.Should().Be("game-of-thrones");
            traktListItem.Show.Ids.Tvdb.Should().Be(121361U);
            traktListItem.Show.Ids.Imdb.Should().Be("tt0944947");
            traktListItem.Show.Ids.Tmdb.Should().Be(1399U);
            traktListItem.Show.Ids.TvRage.Should().Be(24493U);

            traktListItem.Movie.Should().BeNull();
            traktListItem.Season.Should().BeNull();
            traktListItem.Person.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktListItemObjectJsonReader_Episode_ReadObject_From_Json_String_Not_Valid_5()
        {
            var jsonReader = new TraktListItemObjectJsonReader();

            var traktListItem = await jsonReader.ReadObjectAsync(TYPE_EPISODE_JSON_NOT_VALID_5);

            traktListItem.Should().NotBeNull();
            traktListItem.Rank.Should().Be("1");
            traktListItem.ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            traktListItem.Type.Should().Be(TraktListItemType.Episode);
            traktListItem.Episode.Should().NotBeNull();
            traktListItem.Episode.SeasonNumber.Should().Be(1);
            traktListItem.Episode.Number.Should().Be(1);
            traktListItem.Episode.Title.Should().Be("Winter Is Coming");
            traktListItem.Episode.Ids.Should().NotBeNull();
            traktListItem.Episode.Ids.Trakt.Should().Be(73640U);
            traktListItem.Episode.Ids.Tvdb.Should().Be(3254641U);
            traktListItem.Episode.Ids.Imdb.Should().Be("tt1480055");
            traktListItem.Episode.Ids.Tmdb.Should().Be(63056U);
            traktListItem.Episode.Ids.TvRage.Should().Be(1065008299U);
            traktListItem.Show.Should().BeNull();

            traktListItem.Movie.Should().BeNull();
            traktListItem.Season.Should().BeNull();
            traktListItem.Person.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktListItemObjectJsonReader_Episode_ReadObject_From_Json_String_Not_Valid_6()
        {
            var jsonReader = new TraktListItemObjectJsonReader();

            var traktListItem = await jsonReader.ReadObjectAsync(TYPE_EPISODE_JSON_NOT_VALID_6);

            traktListItem.Should().NotBeNull();
            traktListItem.Rank.Should().BeNull();
            traktListItem.ListedAt.Should().BeNull();
            traktListItem.Type.Should().BeNull();
            traktListItem.Episode.Should().BeNull();
            traktListItem.Show.Should().BeNull();
            traktListItem.Movie.Should().BeNull();
            traktListItem.Season.Should().BeNull();
            traktListItem.Person.Should().BeNull();
        }
    }
}

namespace TraktNet.Objects.Get.Tests.Lists.Json.Reader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Enums;
    using TraktNet.Objects.Get.Lists;
    using TraktNet.Objects.Get.Lists.Json.Reader;
    using Xunit;

    [TestCategory("Objects.Get.Lists.JsonReader")]
    public partial class ListItemObjectJsonReader_Season_Tests
    {
        [Fact]
        public async Task Test_ListItemObjectJsonReader_Season_ReadObject_From_JsonReader_Complete()
        {
            var traktJsonReader = new ListItemObjectJsonReader();

            using var reader = new StringReader(TYPE_SEASON_JSON_COMPLETE);
            using var jsonReader = new JsonTextReader(reader);
            ITraktListItem traktListItem = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktListItem.Should().NotBeNull();
            traktListItem.Id.Should().Be(101U);
            traktListItem.Rank.Should().Be(1);
            traktListItem.ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            traktListItem.Notes.Should().Be("list item notes");
            traktListItem.Type.Should().Be(TraktListItemType.Season);
            traktListItem.Season.Should().NotBeNull();
            traktListItem.Season.Number.Should().Be(1);
            traktListItem.Season.Ids.Should().NotBeNull();
            traktListItem.Season.Ids.Trakt.Should().Be(61430U);
            traktListItem.Season.Ids.Tvdb.Should().Be(279121U);
            traktListItem.Season.Ids.Tmdb.Should().Be(60523U);
            traktListItem.Season.Ids.TvRage.Should().Be(36939U);

            traktListItem.Movie.Should().BeNull();
            traktListItem.Show.Should().BeNull();
            traktListItem.Episode.Should().BeNull();
            traktListItem.Person.Should().BeNull();
        }

        [Fact]
        public async Task Test_ListItemObjectJsonReader_Season_ReadObject_From_JsonReader_Incomplete_1()
        {
            var traktJsonReader = new ListItemObjectJsonReader();

            using var reader = new StringReader(TYPE_SEASON_JSON_INCOMPLETE_1);
            using var jsonReader = new JsonTextReader(reader);
            ITraktListItem traktListItem = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktListItem.Should().NotBeNull();
            traktListItem.Id.Should().BeNull();
            traktListItem.Rank.Should().Be(1);
            traktListItem.ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            traktListItem.Notes.Should().Be("list item notes");
            traktListItem.Type.Should().Be(TraktListItemType.Season);
            traktListItem.Season.Should().NotBeNull();
            traktListItem.Season.Number.Should().Be(1);
            traktListItem.Season.Ids.Should().NotBeNull();
            traktListItem.Season.Ids.Trakt.Should().Be(61430U);
            traktListItem.Season.Ids.Tvdb.Should().Be(279121U);
            traktListItem.Season.Ids.Tmdb.Should().Be(60523U);
            traktListItem.Season.Ids.TvRage.Should().Be(36939U);

            traktListItem.Movie.Should().BeNull();
            traktListItem.Show.Should().BeNull();
            traktListItem.Episode.Should().BeNull();
            traktListItem.Person.Should().BeNull();
        }

        [Fact]
        public async Task Test_ListItemObjectJsonReader_Season_ReadObject_From_JsonReader_Incomplete_2()
        {
            var traktJsonReader = new ListItemObjectJsonReader();

            using var reader = new StringReader(TYPE_SEASON_JSON_INCOMPLETE_2);
            using var jsonReader = new JsonTextReader(reader);
            ITraktListItem traktListItem = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktListItem.Should().NotBeNull();
            traktListItem.Id.Should().Be(101U);
            traktListItem.Rank.Should().BeNull();
            traktListItem.ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            traktListItem.Notes.Should().Be("list item notes");
            traktListItem.Type.Should().Be(TraktListItemType.Season);
            traktListItem.Season.Should().NotBeNull();
            traktListItem.Season.Number.Should().Be(1);
            traktListItem.Season.Ids.Should().NotBeNull();
            traktListItem.Season.Ids.Trakt.Should().Be(61430U);
            traktListItem.Season.Ids.Tvdb.Should().Be(279121U);
            traktListItem.Season.Ids.Tmdb.Should().Be(60523U);
            traktListItem.Season.Ids.TvRage.Should().Be(36939U);

            traktListItem.Movie.Should().BeNull();
            traktListItem.Show.Should().BeNull();
            traktListItem.Episode.Should().BeNull();
            traktListItem.Person.Should().BeNull();
        }

        [Fact]
        public async Task Test_ListItemObjectJsonReader_Season_ReadObject_From_JsonReader_Incomplete_3()
        {
            var traktJsonReader = new ListItemObjectJsonReader();

            using var reader = new StringReader(TYPE_SEASON_JSON_INCOMPLETE_3);
            using var jsonReader = new JsonTextReader(reader);
            ITraktListItem traktListItem = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktListItem.Should().NotBeNull();
            traktListItem.Id.Should().Be(101U);
            traktListItem.Rank.Should().Be(1);
            traktListItem.ListedAt.Should().BeNull();
            traktListItem.Notes.Should().Be("list item notes");
            traktListItem.Type.Should().Be(TraktListItemType.Season);
            traktListItem.Season.Should().NotBeNull();
            traktListItem.Season.Number.Should().Be(1);
            traktListItem.Season.Ids.Should().NotBeNull();
            traktListItem.Season.Ids.Trakt.Should().Be(61430U);
            traktListItem.Season.Ids.Tvdb.Should().Be(279121U);
            traktListItem.Season.Ids.Tmdb.Should().Be(60523U);
            traktListItem.Season.Ids.TvRage.Should().Be(36939U);

            traktListItem.Movie.Should().BeNull();
            traktListItem.Show.Should().BeNull();
            traktListItem.Episode.Should().BeNull();
            traktListItem.Person.Should().BeNull();
        }

        [Fact]
        public async Task Test_ListItemObjectJsonReader_Season_ReadObject_From_JsonReader_Incomplete_4()
        {
            var traktJsonReader = new ListItemObjectJsonReader();

            using var reader = new StringReader(TYPE_SEASON_JSON_INCOMPLETE_4);
            using var jsonReader = new JsonTextReader(reader);
            ITraktListItem traktListItem = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktListItem.Should().NotBeNull();
            traktListItem.Id.Should().Be(101U);
            traktListItem.Rank.Should().Be(1);
            traktListItem.ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            traktListItem.Notes.Should().BeNull();
            traktListItem.Type.Should().Be(TraktListItemType.Season);
            traktListItem.Season.Should().NotBeNull();
            traktListItem.Season.Number.Should().Be(1);
            traktListItem.Season.Ids.Should().NotBeNull();
            traktListItem.Season.Ids.Trakt.Should().Be(61430U);
            traktListItem.Season.Ids.Tvdb.Should().Be(279121U);
            traktListItem.Season.Ids.Tmdb.Should().Be(60523U);
            traktListItem.Season.Ids.TvRage.Should().Be(36939U);

            traktListItem.Movie.Should().BeNull();
            traktListItem.Show.Should().BeNull();
            traktListItem.Episode.Should().BeNull();
            traktListItem.Person.Should().BeNull();
        }

        [Fact]
        public async Task Test_ListItemObjectJsonReader_Season_ReadObject_From_JsonReader_Incomplete_5()
        {
            var traktJsonReader = new ListItemObjectJsonReader();

            using var reader = new StringReader(TYPE_SEASON_JSON_INCOMPLETE_5);
            using var jsonReader = new JsonTextReader(reader);
            ITraktListItem traktListItem = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktListItem.Should().NotBeNull();
            traktListItem.Id.Should().Be(101U);
            traktListItem.Rank.Should().Be(1);
            traktListItem.ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            traktListItem.Notes.Should().Be("list item notes");
            traktListItem.Type.Should().BeNull();
            traktListItem.Season.Should().NotBeNull();
            traktListItem.Season.Number.Should().Be(1);
            traktListItem.Season.Ids.Should().NotBeNull();
            traktListItem.Season.Ids.Trakt.Should().Be(61430U);
            traktListItem.Season.Ids.Tvdb.Should().Be(279121U);
            traktListItem.Season.Ids.Tmdb.Should().Be(60523U);
            traktListItem.Season.Ids.TvRage.Should().Be(36939U);

            traktListItem.Movie.Should().BeNull();
            traktListItem.Show.Should().BeNull();
            traktListItem.Episode.Should().BeNull();
            traktListItem.Person.Should().BeNull();
        }

        [Fact]
        public async Task Test_ListItemObjectJsonReader_Season_ReadObject_From_JsonReader_Incomplete_6()
        {
            var traktJsonReader = new ListItemObjectJsonReader();

            using var reader = new StringReader(TYPE_SEASON_JSON_INCOMPLETE_6);
            using var jsonReader = new JsonTextReader(reader);
            ITraktListItem traktListItem = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktListItem.Should().NotBeNull();
            traktListItem.Id.Should().Be(101U);
            traktListItem.Rank.Should().Be(1);
            traktListItem.ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            traktListItem.Notes.Should().Be("list item notes");
            traktListItem.Type.Should().Be(TraktListItemType.Season);
            traktListItem.Season.Should().BeNull();

            traktListItem.Movie.Should().BeNull();
            traktListItem.Show.Should().BeNull();
            traktListItem.Episode.Should().BeNull();
            traktListItem.Person.Should().BeNull();
        }

        [Fact]
        public async Task Test_ListItemObjectJsonReader_Season_ReadObject_From_JsonReader_Not_Valid_1()
        {
            var traktJsonReader = new ListItemObjectJsonReader();

            using var reader = new StringReader(TYPE_SEASON_JSON_NOT_VALID_1);
            using var jsonReader = new JsonTextReader(reader);
            ITraktListItem traktListItem = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktListItem.Should().NotBeNull();
            traktListItem.Id.Should().BeNull();
            traktListItem.Rank.Should().Be(1);
            traktListItem.ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            traktListItem.Notes.Should().Be("list item notes");
            traktListItem.Type.Should().Be(TraktListItemType.Season);
            traktListItem.Season.Should().NotBeNull();
            traktListItem.Season.Number.Should().Be(1);
            traktListItem.Season.Ids.Should().NotBeNull();
            traktListItem.Season.Ids.Trakt.Should().Be(61430U);
            traktListItem.Season.Ids.Tvdb.Should().Be(279121U);
            traktListItem.Season.Ids.Tmdb.Should().Be(60523U);
            traktListItem.Season.Ids.TvRage.Should().Be(36939U);

            traktListItem.Movie.Should().BeNull();
            traktListItem.Show.Should().BeNull();
            traktListItem.Episode.Should().BeNull();
            traktListItem.Person.Should().BeNull();
        }

        [Fact]
        public async Task Test_ListItemObjectJsonReader_Season_ReadObject_From_JsonReader_Not_Valid_2()
        {
            var traktJsonReader = new ListItemObjectJsonReader();

            using var reader = new StringReader(TYPE_SEASON_JSON_NOT_VALID_2);
            using var jsonReader = new JsonTextReader(reader);
            ITraktListItem traktListItem = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktListItem.Should().NotBeNull();
            traktListItem.Id.Should().Be(101U);
            traktListItem.Rank.Should().BeNull();
            traktListItem.ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            traktListItem.Notes.Should().Be("list item notes");
            traktListItem.Type.Should().Be(TraktListItemType.Season);
            traktListItem.Season.Should().NotBeNull();
            traktListItem.Season.Number.Should().Be(1);
            traktListItem.Season.Ids.Should().NotBeNull();
            traktListItem.Season.Ids.Trakt.Should().Be(61430U);
            traktListItem.Season.Ids.Tvdb.Should().Be(279121U);
            traktListItem.Season.Ids.Tmdb.Should().Be(60523U);
            traktListItem.Season.Ids.TvRage.Should().Be(36939U);

            traktListItem.Movie.Should().BeNull();
            traktListItem.Show.Should().BeNull();
            traktListItem.Episode.Should().BeNull();
            traktListItem.Person.Should().BeNull();
        }

        [Fact]
        public async Task Test_ListItemObjectJsonReader_Season_ReadObject_From_JsonReader_Not_Valid_3()
        {
            var traktJsonReader = new ListItemObjectJsonReader();

            using var reader = new StringReader(TYPE_SEASON_JSON_NOT_VALID_3);
            using var jsonReader = new JsonTextReader(reader);
            ITraktListItem traktListItem = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktListItem.Should().NotBeNull();
            traktListItem.Id.Should().Be(101U);
            traktListItem.Rank.Should().Be(1);
            traktListItem.ListedAt.Should().BeNull();
            traktListItem.Notes.Should().Be("list item notes");
            traktListItem.Type.Should().Be(TraktListItemType.Season);
            traktListItem.Season.Should().NotBeNull();
            traktListItem.Season.Number.Should().Be(1);
            traktListItem.Season.Ids.Should().NotBeNull();
            traktListItem.Season.Ids.Trakt.Should().Be(61430U);
            traktListItem.Season.Ids.Tvdb.Should().Be(279121U);
            traktListItem.Season.Ids.Tmdb.Should().Be(60523U);
            traktListItem.Season.Ids.TvRage.Should().Be(36939U);

            traktListItem.Movie.Should().BeNull();
            traktListItem.Show.Should().BeNull();
            traktListItem.Episode.Should().BeNull();
            traktListItem.Person.Should().BeNull();
        }

        [Fact]
        public async Task Test_ListItemObjectJsonReader_Season_ReadObject_From_JsonReader_Not_Valid_4()
        {
            var traktJsonReader = new ListItemObjectJsonReader();

            using var reader = new StringReader(TYPE_SEASON_JSON_NOT_VALID_4);
            using var jsonReader = new JsonTextReader(reader);
            ITraktListItem traktListItem = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktListItem.Should().NotBeNull();
            traktListItem.Id.Should().Be(101U);
            traktListItem.Rank.Should().Be(1);
            traktListItem.ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            traktListItem.Notes.Should().BeNull();
            traktListItem.Type.Should().Be(TraktListItemType.Season);
            traktListItem.Season.Should().NotBeNull();
            traktListItem.Season.Number.Should().Be(1);
            traktListItem.Season.Ids.Should().NotBeNull();
            traktListItem.Season.Ids.Trakt.Should().Be(61430U);
            traktListItem.Season.Ids.Tvdb.Should().Be(279121U);
            traktListItem.Season.Ids.Tmdb.Should().Be(60523U);
            traktListItem.Season.Ids.TvRage.Should().Be(36939U);

            traktListItem.Movie.Should().BeNull();
            traktListItem.Show.Should().BeNull();
            traktListItem.Episode.Should().BeNull();
            traktListItem.Person.Should().BeNull();
        }

        [Fact]
        public async Task Test_ListItemObjectJsonReader_Season_ReadObject_From_JsonReader_Not_Valid_5()
        {
            var traktJsonReader = new ListItemObjectJsonReader();

            using var reader = new StringReader(TYPE_SEASON_JSON_NOT_VALID_5);
            using var jsonReader = new JsonTextReader(reader);
            ITraktListItem traktListItem = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktListItem.Should().NotBeNull();
            traktListItem.Id.Should().Be(101U);
            traktListItem.Rank.Should().Be(1);
            traktListItem.ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            traktListItem.Notes.Should().Be("list item notes");
            traktListItem.Type.Should().BeNull();
            traktListItem.Season.Should().NotBeNull();
            traktListItem.Season.Number.Should().Be(1);
            traktListItem.Season.Ids.Should().NotBeNull();
            traktListItem.Season.Ids.Trakt.Should().Be(61430U);
            traktListItem.Season.Ids.Tvdb.Should().Be(279121U);
            traktListItem.Season.Ids.Tmdb.Should().Be(60523U);
            traktListItem.Season.Ids.TvRage.Should().Be(36939U);

            traktListItem.Movie.Should().BeNull();
            traktListItem.Show.Should().BeNull();
            traktListItem.Episode.Should().BeNull();
            traktListItem.Person.Should().BeNull();
        }

        [Fact]
        public async Task Test_ListItemObjectJsonReader_Season_ReadObject_From_JsonReader_Not_Valid_6()
        {
            var traktJsonReader = new ListItemObjectJsonReader();

            using var reader = new StringReader(TYPE_SEASON_JSON_NOT_VALID_6);
            using var jsonReader = new JsonTextReader(reader);
            ITraktListItem traktListItem = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktListItem.Should().NotBeNull();
            traktListItem.Id.Should().Be(101U);
            traktListItem.Rank.Should().Be(1);
            traktListItem.ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            traktListItem.Notes.Should().Be("list item notes");
            traktListItem.Type.Should().Be(TraktListItemType.Season);
            traktListItem.Season.Should().BeNull();

            traktListItem.Movie.Should().BeNull();
            traktListItem.Show.Should().BeNull();
            traktListItem.Episode.Should().BeNull();
            traktListItem.Person.Should().BeNull();
        }

        [Fact]
        public async Task Test_ListItemObjectJsonReader_Season_ReadObject_From_JsonReader_Not_Valid_7()
        {
            var traktJsonReader = new ListItemObjectJsonReader();

            using var reader = new StringReader(TYPE_SEASON_JSON_NOT_VALID_7);
            using var jsonReader = new JsonTextReader(reader);
            ITraktListItem traktListItem = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktListItem.Should().NotBeNull();
            traktListItem.Id.Should().BeNull();
            traktListItem.Rank.Should().BeNull();
            traktListItem.ListedAt.Should().BeNull();
            traktListItem.Notes.Should().BeNull();
            traktListItem.Type.Should().BeNull();
            traktListItem.Season.Should().BeNull();

            traktListItem.Movie.Should().BeNull();
            traktListItem.Show.Should().BeNull();
            traktListItem.Episode.Should().BeNull();
            traktListItem.Person.Should().BeNull();
        }
    }
}

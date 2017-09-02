namespace TraktApiSharp.Tests.Objects.Get.Users.JsonReader
{
    using FluentAssertions;
    using System;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Enums;
    using TraktApiSharp.Objects.Get.Users.JsonReader;
    using Xunit;

    [Category("Objects.Get.Users.JsonReader")]
    public partial class UserHiddenItemObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_UserHiddenItemObjectJsonReader_Season_ReadObject_From_Json_String_Complete()
        {
            var jsonReader = new UserHiddenItemObjectJsonReader();

            var traktUserHiddenItem = await jsonReader.ReadObjectAsync(TYPE_SEASON_JSON_COMPLETE);

            traktUserHiddenItem.Should().NotBeNull();
            traktUserHiddenItem.HiddenAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            traktUserHiddenItem.Type.Should().Be(TraktHiddenItemType.Season);
            traktUserHiddenItem.Season.Should().NotBeNull();
            traktUserHiddenItem.Season.Number.Should().Be(1);
            traktUserHiddenItem.Season.Ids.Should().NotBeNull();
            traktUserHiddenItem.Season.Ids.Trakt.Should().Be(61430U);
            traktUserHiddenItem.Season.Ids.Tvdb.Should().Be(279121U);
            traktUserHiddenItem.Season.Ids.Tmdb.Should().Be(60523U);
            traktUserHiddenItem.Season.Ids.TvRage.Should().Be(36939U);

            traktUserHiddenItem.Movie.Should().BeNull();
            traktUserHiddenItem.Show.Should().BeNull();
        }

        [Fact]
        public async Task Test_UserHiddenItemObjectJsonReader_Season_ReadObject_From_Json_String_Incomplete_1()
        {
            var jsonReader = new UserHiddenItemObjectJsonReader();

            var traktUserHiddenItem = await jsonReader.ReadObjectAsync(TYPE_SEASON_JSON_INCOMPLETE_1);

            traktUserHiddenItem.Should().NotBeNull();
            traktUserHiddenItem.HiddenAt.Should().BeNull();
            traktUserHiddenItem.Type.Should().Be(TraktHiddenItemType.Season);
            traktUserHiddenItem.Season.Should().NotBeNull();
            traktUserHiddenItem.Season.Number.Should().Be(1);
            traktUserHiddenItem.Season.Ids.Should().NotBeNull();
            traktUserHiddenItem.Season.Ids.Trakt.Should().Be(61430U);
            traktUserHiddenItem.Season.Ids.Tvdb.Should().Be(279121U);
            traktUserHiddenItem.Season.Ids.Tmdb.Should().Be(60523U);
            traktUserHiddenItem.Season.Ids.TvRage.Should().Be(36939U);

            traktUserHiddenItem.Movie.Should().BeNull();
            traktUserHiddenItem.Show.Should().BeNull();
        }

        [Fact]
        public async Task Test_UserHiddenItemObjectJsonReader_Season_ReadObject_From_Json_String_Incomplete_2()
        {
            var jsonReader = new UserHiddenItemObjectJsonReader();

            var traktUserHiddenItem = await jsonReader.ReadObjectAsync(TYPE_SEASON_JSON_INCOMPLETE_2);

            traktUserHiddenItem.Should().NotBeNull();
            traktUserHiddenItem.HiddenAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            traktUserHiddenItem.Type.Should().BeNull();
            traktUserHiddenItem.Season.Should().NotBeNull();
            traktUserHiddenItem.Season.Number.Should().Be(1);
            traktUserHiddenItem.Season.Ids.Should().NotBeNull();
            traktUserHiddenItem.Season.Ids.Trakt.Should().Be(61430U);
            traktUserHiddenItem.Season.Ids.Tvdb.Should().Be(279121U);
            traktUserHiddenItem.Season.Ids.Tmdb.Should().Be(60523U);
            traktUserHiddenItem.Season.Ids.TvRage.Should().Be(36939U);

            traktUserHiddenItem.Movie.Should().BeNull();
            traktUserHiddenItem.Show.Should().BeNull();
        }

        [Fact]
        public async Task Test_UserHiddenItemObjectJsonReader_Season_ReadObject_From_Json_String_Incomplete_3()
        {
            var jsonReader = new UserHiddenItemObjectJsonReader();

            var traktUserHiddenItem = await jsonReader.ReadObjectAsync(TYPE_SEASON_JSON_INCOMPLETE_3);

            traktUserHiddenItem.Should().NotBeNull();
            traktUserHiddenItem.HiddenAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            traktUserHiddenItem.Type.Should().Be(TraktHiddenItemType.Season);
            traktUserHiddenItem.Season.Should().BeNull();
            traktUserHiddenItem.Movie.Should().BeNull();
            traktUserHiddenItem.Show.Should().BeNull();
        }

        [Fact]
        public async Task Test_UserHiddenItemObjectJsonReader_Season_ReadObject_From_Json_String_Incomplete_4()
        {
            var jsonReader = new UserHiddenItemObjectJsonReader();

            var traktUserHiddenItem = await jsonReader.ReadObjectAsync(TYPE_SEASON_JSON_INCOMPLETE_4);

            traktUserHiddenItem.Should().NotBeNull();
            traktUserHiddenItem.HiddenAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            traktUserHiddenItem.Type.Should().BeNull();
            traktUserHiddenItem.Season.Should().BeNull();
            traktUserHiddenItem.Movie.Should().BeNull();
            traktUserHiddenItem.Show.Should().BeNull();
        }

        [Fact]
        public async Task Test_UserHiddenItemObjectJsonReader_Season_ReadObject_From_Json_String_Incomplete_5()
        {
            var jsonReader = new UserHiddenItemObjectJsonReader();

            var traktUserHiddenItem = await jsonReader.ReadObjectAsync(TYPE_SEASON_JSON_INCOMPLETE_5);

            traktUserHiddenItem.Should().NotBeNull();
            traktUserHiddenItem.HiddenAt.Should().BeNull();
            traktUserHiddenItem.Type.Should().Be(TraktHiddenItemType.Season);
            traktUserHiddenItem.Season.Should().BeNull();
            traktUserHiddenItem.Movie.Should().BeNull();
            traktUserHiddenItem.Show.Should().BeNull();
        }

        [Fact]
        public async Task Test_UserHiddenItemObjectJsonReader_Season_ReadObject_From_Json_String_Incomplete_6()
        {
            var jsonReader = new UserHiddenItemObjectJsonReader();

            var traktUserHiddenItem = await jsonReader.ReadObjectAsync(TYPE_SEASON_JSON_INCOMPLETE_6);

            traktUserHiddenItem.Should().NotBeNull();
            traktUserHiddenItem.HiddenAt.Should().BeNull();
            traktUserHiddenItem.Type.Should().BeNull();
            traktUserHiddenItem.Season.Should().NotBeNull();
            traktUserHiddenItem.Season.Number.Should().Be(1);
            traktUserHiddenItem.Season.Ids.Should().NotBeNull();
            traktUserHiddenItem.Season.Ids.Trakt.Should().Be(61430U);
            traktUserHiddenItem.Season.Ids.Tvdb.Should().Be(279121U);
            traktUserHiddenItem.Season.Ids.Tmdb.Should().Be(60523U);
            traktUserHiddenItem.Season.Ids.TvRage.Should().Be(36939U);

            traktUserHiddenItem.Movie.Should().BeNull();
            traktUserHiddenItem.Show.Should().BeNull();
        }

        [Fact]
        public async Task Test_UserHiddenItemObjectJsonReader_Season_ReadObject_From_Json_String_Not_Valid_1()
        {
            var jsonReader = new UserHiddenItemObjectJsonReader();

            var traktUserHiddenItem = await jsonReader.ReadObjectAsync(TYPE_SEASON_JSON_NOT_VALID_1);

            traktUserHiddenItem.Should().NotBeNull();
            traktUserHiddenItem.HiddenAt.Should().BeNull();
            traktUserHiddenItem.Type.Should().Be(TraktHiddenItemType.Season);
            traktUserHiddenItem.Season.Should().NotBeNull();
            traktUserHiddenItem.Season.Number.Should().Be(1);
            traktUserHiddenItem.Season.Ids.Should().NotBeNull();
            traktUserHiddenItem.Season.Ids.Trakt.Should().Be(61430U);
            traktUserHiddenItem.Season.Ids.Tvdb.Should().Be(279121U);
            traktUserHiddenItem.Season.Ids.Tmdb.Should().Be(60523U);
            traktUserHiddenItem.Season.Ids.TvRage.Should().Be(36939U);

            traktUserHiddenItem.Movie.Should().BeNull();
            traktUserHiddenItem.Show.Should().BeNull();
        }

        [Fact]
        public async Task Test_UserHiddenItemObjectJsonReader_Season_ReadObject_From_Json_String_Not_Valid_2()
        {
            var jsonReader = new UserHiddenItemObjectJsonReader();

            var traktUserHiddenItem = await jsonReader.ReadObjectAsync(TYPE_SEASON_JSON_NOT_VALID_2);

            traktUserHiddenItem.Should().NotBeNull();
            traktUserHiddenItem.HiddenAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            traktUserHiddenItem.Type.Should().BeNull();
            traktUserHiddenItem.Season.Should().NotBeNull();
            traktUserHiddenItem.Season.Number.Should().Be(1);
            traktUserHiddenItem.Season.Ids.Should().NotBeNull();
            traktUserHiddenItem.Season.Ids.Trakt.Should().Be(61430U);
            traktUserHiddenItem.Season.Ids.Tvdb.Should().Be(279121U);
            traktUserHiddenItem.Season.Ids.Tmdb.Should().Be(60523U);
            traktUserHiddenItem.Season.Ids.TvRage.Should().Be(36939U);

            traktUserHiddenItem.Movie.Should().BeNull();
            traktUserHiddenItem.Show.Should().BeNull();
        }

        [Fact]
        public async Task Test_UserHiddenItemObjectJsonReader_Season_ReadObject_From_Json_String_Not_Valid_3()
        {
            var jsonReader = new UserHiddenItemObjectJsonReader();

            var traktUserHiddenItem = await jsonReader.ReadObjectAsync(TYPE_SEASON_JSON_NOT_VALID_3);

            traktUserHiddenItem.Should().NotBeNull();
            traktUserHiddenItem.HiddenAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            traktUserHiddenItem.Type.Should().Be(TraktHiddenItemType.Season);
            traktUserHiddenItem.Season.Should().BeNull();
            traktUserHiddenItem.Movie.Should().BeNull();
            traktUserHiddenItem.Show.Should().BeNull();
        }

        [Fact]
        public async Task Test_UserHiddenItemObjectJsonReader_Season_ReadObject_From_Json_String_Not_Valid_4()
        {
            var jsonReader = new UserHiddenItemObjectJsonReader();

            var traktUserHiddenItem = await jsonReader.ReadObjectAsync(TYPE_SEASON_JSON_NOT_VALID_4);

            traktUserHiddenItem.Should().NotBeNull();
            traktUserHiddenItem.HiddenAt.Should().BeNull();
            traktUserHiddenItem.Type.Should().BeNull();
            traktUserHiddenItem.Season.Should().BeNull();
            traktUserHiddenItem.Movie.Should().BeNull();
            traktUserHiddenItem.Show.Should().BeNull();
        }
    }
}

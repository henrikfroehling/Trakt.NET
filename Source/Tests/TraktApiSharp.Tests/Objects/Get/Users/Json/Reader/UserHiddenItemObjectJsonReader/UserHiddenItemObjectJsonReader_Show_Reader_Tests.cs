namespace TraktApiSharp.Tests.Objects.Get.Users.Json.Reader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Enums;
    using TraktApiSharp.Objects.Get.Users.Json.Reader;
    using Xunit;

    [Category("Objects.Get.Users.JsonReader")]
    public partial class UserHiddenItemObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_UserHiddenItemObjectJsonReader_Show_ReadObject_From_JsonReader_Complete()
        {
            var traktJsonReader = new UserHiddenItemObjectJsonReader();

            using (var reader = new StringReader(TYPE_SHOW_JSON_COMPLETE))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktUserHiddenItem = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktUserHiddenItem.Should().NotBeNull();
                traktUserHiddenItem.HiddenAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
                traktUserHiddenItem.Type.Should().Be(TraktHiddenItemType.Show);
                traktUserHiddenItem.Show.Should().NotBeNull();
                traktUserHiddenItem.Show.Title.Should().Be("Game of Thrones");
                traktUserHiddenItem.Show.Year.Should().Be(2011);
                traktUserHiddenItem.Show.Ids.Should().NotBeNull();
                traktUserHiddenItem.Show.Ids.Trakt.Should().Be(1390U);
                traktUserHiddenItem.Show.Ids.Slug.Should().Be("game-of-thrones");
                traktUserHiddenItem.Show.Ids.Tvdb.Should().Be(121361U);
                traktUserHiddenItem.Show.Ids.Imdb.Should().Be("tt0944947");
                traktUserHiddenItem.Show.Ids.Tmdb.Should().Be(1399U);
                traktUserHiddenItem.Show.Ids.TvRage.Should().Be(24493U);

                traktUserHiddenItem.Movie.Should().BeNull();
                traktUserHiddenItem.Season.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_UserHiddenItemObjectJsonReader_Show_ReadObject_From_JsonReader_Incomplete_1()
        {
            var traktJsonReader = new UserHiddenItemObjectJsonReader();

            using (var reader = new StringReader(TYPE_SHOW_JSON_INCOMPLETE_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktUserHiddenItem = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktUserHiddenItem.Should().NotBeNull();
                traktUserHiddenItem.HiddenAt.Should().BeNull();
                traktUserHiddenItem.Type.Should().Be(TraktHiddenItemType.Show);
                traktUserHiddenItem.Show.Should().NotBeNull();
                traktUserHiddenItem.Show.Title.Should().Be("Game of Thrones");
                traktUserHiddenItem.Show.Year.Should().Be(2011);
                traktUserHiddenItem.Show.Ids.Should().NotBeNull();
                traktUserHiddenItem.Show.Ids.Trakt.Should().Be(1390U);
                traktUserHiddenItem.Show.Ids.Slug.Should().Be("game-of-thrones");
                traktUserHiddenItem.Show.Ids.Tvdb.Should().Be(121361U);
                traktUserHiddenItem.Show.Ids.Imdb.Should().Be("tt0944947");
                traktUserHiddenItem.Show.Ids.Tmdb.Should().Be(1399U);
                traktUserHiddenItem.Show.Ids.TvRage.Should().Be(24493U);

                traktUserHiddenItem.Movie.Should().BeNull();
                traktUserHiddenItem.Season.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_UserHiddenItemObjectJsonReader_Show_ReadObject_From_JsonReader_Incomplete_2()
        {
            var traktJsonReader = new UserHiddenItemObjectJsonReader();

            using (var reader = new StringReader(TYPE_SHOW_JSON_INCOMPLETE_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktUserHiddenItem = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktUserHiddenItem.Should().NotBeNull();
                traktUserHiddenItem.HiddenAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
                traktUserHiddenItem.Type.Should().BeNull();
                traktUserHiddenItem.Show.Should().NotBeNull();
                traktUserHiddenItem.Show.Title.Should().Be("Game of Thrones");
                traktUserHiddenItem.Show.Year.Should().Be(2011);
                traktUserHiddenItem.Show.Ids.Should().NotBeNull();
                traktUserHiddenItem.Show.Ids.Trakt.Should().Be(1390U);
                traktUserHiddenItem.Show.Ids.Slug.Should().Be("game-of-thrones");
                traktUserHiddenItem.Show.Ids.Tvdb.Should().Be(121361U);
                traktUserHiddenItem.Show.Ids.Imdb.Should().Be("tt0944947");
                traktUserHiddenItem.Show.Ids.Tmdb.Should().Be(1399U);
                traktUserHiddenItem.Show.Ids.TvRage.Should().Be(24493U);

                traktUserHiddenItem.Movie.Should().BeNull();
                traktUserHiddenItem.Season.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_UserHiddenItemObjectJsonReader_Show_ReadObject_From_JsonReader_Incomplete_3()
        {
            var traktJsonReader = new UserHiddenItemObjectJsonReader();

            using (var reader = new StringReader(TYPE_SHOW_JSON_INCOMPLETE_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktUserHiddenItem = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktUserHiddenItem.Should().NotBeNull();
                traktUserHiddenItem.HiddenAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
                traktUserHiddenItem.Type.Should().Be(TraktHiddenItemType.Show);
                traktUserHiddenItem.Show.Should().BeNull();
                traktUserHiddenItem.Movie.Should().BeNull();
                traktUserHiddenItem.Season.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_UserHiddenItemObjectJsonReader_Show_ReadObject_From_JsonReader_Incomplete_4()
        {
            var traktJsonReader = new UserHiddenItemObjectJsonReader();

            using (var reader = new StringReader(TYPE_SHOW_JSON_INCOMPLETE_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktUserHiddenItem = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktUserHiddenItem.Should().NotBeNull();
                traktUserHiddenItem.HiddenAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
                traktUserHiddenItem.Type.Should().BeNull();
                traktUserHiddenItem.Show.Should().BeNull();
                traktUserHiddenItem.Movie.Should().BeNull();
                traktUserHiddenItem.Season.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_UserHiddenItemObjectJsonReader_Show_ReadObject_From_JsonReader_Incomplete_5()
        {
            var traktJsonReader = new UserHiddenItemObjectJsonReader();

            using (var reader = new StringReader(TYPE_SHOW_JSON_INCOMPLETE_5))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktUserHiddenItem = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktUserHiddenItem.Should().NotBeNull();
                traktUserHiddenItem.HiddenAt.Should().BeNull();
                traktUserHiddenItem.Type.Should().Be(TraktHiddenItemType.Show);
                traktUserHiddenItem.Show.Should().BeNull();
                traktUserHiddenItem.Movie.Should().BeNull();
                traktUserHiddenItem.Season.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_UserHiddenItemObjectJsonReader_Show_ReadObject_From_JsonReader_Incomplete_6()
        {
            var traktJsonReader = new UserHiddenItemObjectJsonReader();

            using (var reader = new StringReader(TYPE_SHOW_JSON_INCOMPLETE_6))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktUserHiddenItem = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktUserHiddenItem.Should().NotBeNull();
                traktUserHiddenItem.HiddenAt.Should().BeNull();
                traktUserHiddenItem.Type.Should().BeNull();
                traktUserHiddenItem.Show.Should().NotBeNull();
                traktUserHiddenItem.Show.Title.Should().Be("Game of Thrones");
                traktUserHiddenItem.Show.Year.Should().Be(2011);
                traktUserHiddenItem.Show.Ids.Should().NotBeNull();
                traktUserHiddenItem.Show.Ids.Trakt.Should().Be(1390U);
                traktUserHiddenItem.Show.Ids.Slug.Should().Be("game-of-thrones");
                traktUserHiddenItem.Show.Ids.Tvdb.Should().Be(121361U);
                traktUserHiddenItem.Show.Ids.Imdb.Should().Be("tt0944947");
                traktUserHiddenItem.Show.Ids.Tmdb.Should().Be(1399U);
                traktUserHiddenItem.Show.Ids.TvRage.Should().Be(24493U);

                traktUserHiddenItem.Movie.Should().BeNull();
                traktUserHiddenItem.Season.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_UserHiddenItemObjectJsonReader_Show_ReadObject_From_JsonReader_Not_Valid_1()
        {
            var traktJsonReader = new UserHiddenItemObjectJsonReader();

            using (var reader = new StringReader(TYPE_SHOW_JSON_NOT_VALID_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktUserHiddenItem = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktUserHiddenItem.Should().NotBeNull();
                traktUserHiddenItem.HiddenAt.Should().BeNull();
                traktUserHiddenItem.Type.Should().Be(TraktHiddenItemType.Show);
                traktUserHiddenItem.Show.Should().NotBeNull();
                traktUserHiddenItem.Show.Title.Should().Be("Game of Thrones");
                traktUserHiddenItem.Show.Year.Should().Be(2011);
                traktUserHiddenItem.Show.Ids.Should().NotBeNull();
                traktUserHiddenItem.Show.Ids.Trakt.Should().Be(1390U);
                traktUserHiddenItem.Show.Ids.Slug.Should().Be("game-of-thrones");
                traktUserHiddenItem.Show.Ids.Tvdb.Should().Be(121361U);
                traktUserHiddenItem.Show.Ids.Imdb.Should().Be("tt0944947");
                traktUserHiddenItem.Show.Ids.Tmdb.Should().Be(1399U);
                traktUserHiddenItem.Show.Ids.TvRage.Should().Be(24493U);

                traktUserHiddenItem.Movie.Should().BeNull();
                traktUserHiddenItem.Season.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_UserHiddenItemObjectJsonReader_Show_ReadObject_From_JsonReader_Not_Valid_2()
        {
            var traktJsonReader = new UserHiddenItemObjectJsonReader();

            using (var reader = new StringReader(TYPE_SHOW_JSON_NOT_VALID_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktUserHiddenItem = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktUserHiddenItem.Should().NotBeNull();
                traktUserHiddenItem.HiddenAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
                traktUserHiddenItem.Type.Should().BeNull();
                traktUserHiddenItem.Show.Should().NotBeNull();
                traktUserHiddenItem.Show.Title.Should().Be("Game of Thrones");
                traktUserHiddenItem.Show.Year.Should().Be(2011);
                traktUserHiddenItem.Show.Ids.Should().NotBeNull();
                traktUserHiddenItem.Show.Ids.Trakt.Should().Be(1390U);
                traktUserHiddenItem.Show.Ids.Slug.Should().Be("game-of-thrones");
                traktUserHiddenItem.Show.Ids.Tvdb.Should().Be(121361U);
                traktUserHiddenItem.Show.Ids.Imdb.Should().Be("tt0944947");
                traktUserHiddenItem.Show.Ids.Tmdb.Should().Be(1399U);
                traktUserHiddenItem.Show.Ids.TvRage.Should().Be(24493U);

                traktUserHiddenItem.Movie.Should().BeNull();
                traktUserHiddenItem.Season.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_UserHiddenItemObjectJsonReader_Show_ReadObject_From_JsonReader_Not_Valid_3()
        {
            var traktJsonReader = new UserHiddenItemObjectJsonReader();

            using (var reader = new StringReader(TYPE_SHOW_JSON_NOT_VALID_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktUserHiddenItem = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktUserHiddenItem.Should().NotBeNull();
                traktUserHiddenItem.HiddenAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
                traktUserHiddenItem.Type.Should().Be(TraktHiddenItemType.Show);
                traktUserHiddenItem.Show.Should().BeNull();
                traktUserHiddenItem.Movie.Should().BeNull();
                traktUserHiddenItem.Season.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_UserHiddenItemObjectJsonReader_Show_ReadObject_From_JsonReader_Not_Valid_4()
        {
            var traktJsonReader = new UserHiddenItemObjectJsonReader();

            using (var reader = new StringReader(TYPE_SHOW_JSON_NOT_VALID_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktUserHiddenItem = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktUserHiddenItem.Should().NotBeNull();
                traktUserHiddenItem.HiddenAt.Should().BeNull();
                traktUserHiddenItem.Type.Should().BeNull();
                traktUserHiddenItem.Show.Should().BeNull();
                traktUserHiddenItem.Movie.Should().BeNull();
                traktUserHiddenItem.Season.Should().BeNull();
            }
        }
    }
}

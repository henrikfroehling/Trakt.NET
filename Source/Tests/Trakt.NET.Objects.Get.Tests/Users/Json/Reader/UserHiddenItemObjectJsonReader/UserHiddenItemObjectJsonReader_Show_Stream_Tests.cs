namespace TraktNet.Objects.Get.Tests.Users.Json.Reader
{
    using FluentAssertions;
    using System;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Enums;
    using TraktNet.Objects.Get.Users.Json.Reader;
    using Xunit;

    [TestCategory("Objects.Get.Users.JsonReader")]
    public partial class UserHiddenItemObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_UserHiddenItemObjectJsonReader_Show_ReadObject_From_Stream_Complete()
        {
            var jsonReader = new UserHiddenItemObjectJsonReader();

            using (var stream = TYPE_SHOW_JSON_COMPLETE.ToStream())
            {
                var traktUserHiddenItem = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_UserHiddenItemObjectJsonReader_Show_ReadObject_From_Stream_Incomplete_1()
        {
            var jsonReader = new UserHiddenItemObjectJsonReader();

            using (var stream = TYPE_SHOW_JSON_INCOMPLETE_1.ToStream())
            {
                var traktUserHiddenItem = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_UserHiddenItemObjectJsonReader_Show_ReadObject_From_Stream_Incomplete_2()
        {
            var jsonReader = new UserHiddenItemObjectJsonReader();

            using (var stream = TYPE_SHOW_JSON_INCOMPLETE_2.ToStream())
            {
                var traktUserHiddenItem = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_UserHiddenItemObjectJsonReader_Show_ReadObject_From_Stream_Incomplete_3()
        {
            var jsonReader = new UserHiddenItemObjectJsonReader();

            using (var stream = TYPE_SHOW_JSON_INCOMPLETE_3.ToStream())
            {
                var traktUserHiddenItem = await jsonReader.ReadObjectAsync(stream);

                traktUserHiddenItem.Should().NotBeNull();
                traktUserHiddenItem.HiddenAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
                traktUserHiddenItem.Type.Should().Be(TraktHiddenItemType.Show);
                traktUserHiddenItem.Show.Should().BeNull();
                traktUserHiddenItem.Movie.Should().BeNull();
                traktUserHiddenItem.Season.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_UserHiddenItemObjectJsonReader_Show_ReadObject_From_Stream_Incomplete_4()
        {
            var jsonReader = new UserHiddenItemObjectJsonReader();

            using (var stream = TYPE_SHOW_JSON_INCOMPLETE_4.ToStream())
            {
                var traktUserHiddenItem = await jsonReader.ReadObjectAsync(stream);

                traktUserHiddenItem.Should().NotBeNull();
                traktUserHiddenItem.HiddenAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
                traktUserHiddenItem.Type.Should().BeNull();
                traktUserHiddenItem.Show.Should().BeNull();
                traktUserHiddenItem.Movie.Should().BeNull();
                traktUserHiddenItem.Season.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_UserHiddenItemObjectJsonReader_Show_ReadObject_From_Stream_Incomplete_5()
        {
            var jsonReader = new UserHiddenItemObjectJsonReader();

            using (var stream = TYPE_SHOW_JSON_INCOMPLETE_5.ToStream())
            {
                var traktUserHiddenItem = await jsonReader.ReadObjectAsync(stream);

                traktUserHiddenItem.Should().NotBeNull();
                traktUserHiddenItem.HiddenAt.Should().BeNull();
                traktUserHiddenItem.Type.Should().Be(TraktHiddenItemType.Show);
                traktUserHiddenItem.Show.Should().BeNull();
                traktUserHiddenItem.Movie.Should().BeNull();
                traktUserHiddenItem.Season.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_UserHiddenItemObjectJsonReader_Show_ReadObject_From_Stream_Incomplete_6()
        {
            var jsonReader = new UserHiddenItemObjectJsonReader();

            using (var stream = TYPE_SHOW_JSON_INCOMPLETE_6.ToStream())
            {
                var traktUserHiddenItem = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_UserHiddenItemObjectJsonReader_Show_ReadObject_From_Stream_Not_Valid_1()
        {
            var jsonReader = new UserHiddenItemObjectJsonReader();

            using (var stream = TYPE_SHOW_JSON_NOT_VALID_1.ToStream())
            {
                var traktUserHiddenItem = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_UserHiddenItemObjectJsonReader_Show_ReadObject_From_Stream_Not_Valid_2()
        {
            var jsonReader = new UserHiddenItemObjectJsonReader();

            using (var stream = TYPE_SHOW_JSON_NOT_VALID_2.ToStream())
            {
                var traktUserHiddenItem = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_UserHiddenItemObjectJsonReader_Show_ReadObject_From_Stream_Not_Valid_3()
        {
            var jsonReader = new UserHiddenItemObjectJsonReader();

            using (var stream = TYPE_SHOW_JSON_NOT_VALID_3.ToStream())
            {
                var traktUserHiddenItem = await jsonReader.ReadObjectAsync(stream);

                traktUserHiddenItem.Should().NotBeNull();
                traktUserHiddenItem.HiddenAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
                traktUserHiddenItem.Type.Should().Be(TraktHiddenItemType.Show);
                traktUserHiddenItem.Show.Should().BeNull();
                traktUserHiddenItem.Movie.Should().BeNull();
                traktUserHiddenItem.Season.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_UserHiddenItemObjectJsonReader_Show_ReadObject_From_Stream_Not_Valid_4()
        {
            var jsonReader = new UserHiddenItemObjectJsonReader();

            using (var stream = TYPE_SHOW_JSON_NOT_VALID_4.ToStream())
            {
                var traktUserHiddenItem = await jsonReader.ReadObjectAsync(stream);

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

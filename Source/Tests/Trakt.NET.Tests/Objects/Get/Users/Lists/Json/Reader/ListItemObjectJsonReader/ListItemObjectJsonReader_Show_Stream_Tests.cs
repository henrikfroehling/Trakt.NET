namespace TraktNet.Tests.Objects.Get.Users.Lists.Json.Reader
{
    using FluentAssertions;
    using System;
    using System.Threading.Tasks;
    using TestUtils;
    using Traits;
    using TraktNet.Enums;
    using TraktNet.Objects.Get.Users.Lists.Json.Reader;
    using Xunit;

    [Category("Objects.Get.Users.Lists.JsonReader")]
    public partial class ListItemObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_ListItemObjectJsonReader_Show_ReadObject_From_Stream_Complete()
        {
            var jsonReader = new ListItemObjectJsonReader();

            using (var stream = TYPE_SHOW_JSON_COMPLETE.ToStream())
            {
                var traktListItem = await jsonReader.ReadObjectAsync(stream);

                traktListItem.Should().NotBeNull();
                traktListItem.Rank.Should().Be("1");
                traktListItem.ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
                traktListItem.Type.Should().Be(TraktListItemType.Show);
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
                traktListItem.Episode.Should().BeNull();
                traktListItem.Person.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ListItemObjectJsonReader_Show_ReadObject_From_Stream_Incomplete_1()
        {
            var jsonReader = new ListItemObjectJsonReader();

            using (var stream = TYPE_SHOW_JSON_INCOMPLETE_1.ToStream())
            {
                var traktListItem = await jsonReader.ReadObjectAsync(stream);

                traktListItem.Should().NotBeNull();
                traktListItem.Rank.Should().BeNull();
                traktListItem.ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
                traktListItem.Type.Should().Be(TraktListItemType.Show);
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
                traktListItem.Episode.Should().BeNull();
                traktListItem.Person.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ListItemObjectJsonReader_Show_ReadObject_From_Stream_Incomplete_2()
        {
            var jsonReader = new ListItemObjectJsonReader();

            using (var stream = TYPE_SHOW_JSON_INCOMPLETE_2.ToStream())
            {
                var traktListItem = await jsonReader.ReadObjectAsync(stream);

                traktListItem.Should().NotBeNull();
                traktListItem.Rank.Should().Be("1");
                traktListItem.ListedAt.Should().BeNull();
                traktListItem.Type.Should().Be(TraktListItemType.Show);
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
                traktListItem.Episode.Should().BeNull();
                traktListItem.Person.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ListItemObjectJsonReader_Show_ReadObject_From_Stream_Incomplete_3()
        {
            var jsonReader = new ListItemObjectJsonReader();

            using (var stream = TYPE_SHOW_JSON_INCOMPLETE_3.ToStream())
            {
                var traktListItem = await jsonReader.ReadObjectAsync(stream);

                traktListItem.Should().NotBeNull();
                traktListItem.Rank.Should().Be("1");
                traktListItem.ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
                traktListItem.Type.Should().BeNull();
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
                traktListItem.Episode.Should().BeNull();
                traktListItem.Person.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ListItemObjectJsonReader_Show_ReadObject_From_Stream_Incomplete_4()
        {
            var jsonReader = new ListItemObjectJsonReader();

            using (var stream = TYPE_SHOW_JSON_INCOMPLETE_4.ToStream())
            {
                var traktListItem = await jsonReader.ReadObjectAsync(stream);

                traktListItem.Should().NotBeNull();
                traktListItem.Rank.Should().Be("1");
                traktListItem.ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
                traktListItem.Type.Should().Be(TraktListItemType.Show);
                traktListItem.Show.Should().BeNull();

                traktListItem.Movie.Should().BeNull();
                traktListItem.Season.Should().BeNull();
                traktListItem.Episode.Should().BeNull();
                traktListItem.Person.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ListItemObjectJsonReader_Show_ReadObject_From_Stream_Incomplete_5()
        {
            var jsonReader = new ListItemObjectJsonReader();

            using (var stream = TYPE_SHOW_JSON_INCOMPLETE_5.ToStream())
            {
                var traktListItem = await jsonReader.ReadObjectAsync(stream);

                traktListItem.Should().NotBeNull();
                traktListItem.Rank.Should().Be("1");
                traktListItem.ListedAt.Should().BeNull();
                traktListItem.Type.Should().BeNull();
                traktListItem.Show.Should().BeNull();

                traktListItem.Movie.Should().BeNull();
                traktListItem.Season.Should().BeNull();
                traktListItem.Episode.Should().BeNull();
                traktListItem.Person.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ListItemObjectJsonReader_Show_ReadObject_From_Stream_Incomplete_6()
        {
            var jsonReader = new ListItemObjectJsonReader();

            using (var stream = TYPE_SHOW_JSON_INCOMPLETE_6.ToStream())
            {
                var traktListItem = await jsonReader.ReadObjectAsync(stream);

                traktListItem.Should().NotBeNull();
                traktListItem.Rank.Should().BeNull();
                traktListItem.ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
                traktListItem.Type.Should().BeNull();
                traktListItem.Show.Should().BeNull();

                traktListItem.Movie.Should().BeNull();
                traktListItem.Season.Should().BeNull();
                traktListItem.Episode.Should().BeNull();
                traktListItem.Person.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ListItemObjectJsonReader_Show_ReadObject_From_Stream_Incomplete_7()
        {
            var jsonReader = new ListItemObjectJsonReader();

            using (var stream = TYPE_SHOW_JSON_INCOMPLETE_7.ToStream())
            {
                var traktListItem = await jsonReader.ReadObjectAsync(stream);

                traktListItem.Should().NotBeNull();
                traktListItem.Rank.Should().BeNull();
                traktListItem.ListedAt.Should().BeNull();
                traktListItem.Type.Should().Be(TraktListItemType.Show);
                traktListItem.Show.Should().BeNull();

                traktListItem.Movie.Should().BeNull();
                traktListItem.Season.Should().BeNull();
                traktListItem.Episode.Should().BeNull();
                traktListItem.Person.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ListItemObjectJsonReader_Show_ReadObject_From_Stream_Incomplete_8()
        {
            var jsonReader = new ListItemObjectJsonReader();

            using (var stream = TYPE_SHOW_JSON_INCOMPLETE_8.ToStream())
            {
                var traktListItem = await jsonReader.ReadObjectAsync(stream);

                traktListItem.Should().NotBeNull();
                traktListItem.Rank.Should().BeNull();
                traktListItem.ListedAt.Should().BeNull();
                traktListItem.Type.Should().BeNull();
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
                traktListItem.Episode.Should().BeNull();
                traktListItem.Person.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ListItemObjectJsonReader_Show_ReadObject_From_Stream_Not_Valid_1()
        {
            var jsonReader = new ListItemObjectJsonReader();

            using (var stream = TYPE_SHOW_JSON_NOT_VALID_1.ToStream())
            {
                var traktListItem = await jsonReader.ReadObjectAsync(stream);

                traktListItem.Should().NotBeNull();
                traktListItem.Rank.Should().BeNull();
                traktListItem.ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
                traktListItem.Type.Should().Be(TraktListItemType.Show);
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
                traktListItem.Episode.Should().BeNull();
                traktListItem.Person.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ListItemObjectJsonReader_Show_ReadObject_From_Stream_Not_Valid_2()
        {
            var jsonReader = new ListItemObjectJsonReader();

            using (var stream = TYPE_SHOW_JSON_NOT_VALID_2.ToStream())
            {
                var traktListItem = await jsonReader.ReadObjectAsync(stream);

                traktListItem.Should().NotBeNull();
                traktListItem.Rank.Should().Be("1");
                traktListItem.ListedAt.Should().BeNull();
                traktListItem.Type.Should().Be(TraktListItemType.Show);
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
                traktListItem.Episode.Should().BeNull();
                traktListItem.Person.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ListItemObjectJsonReader_Show_ReadObject_From_Stream_Not_Valid_3()
        {
            var jsonReader = new ListItemObjectJsonReader();

            using (var stream = TYPE_SHOW_JSON_NOT_VALID_3.ToStream())
            {
                var traktListItem = await jsonReader.ReadObjectAsync(stream);

                traktListItem.Should().NotBeNull();
                traktListItem.Rank.Should().Be("1");
                traktListItem.ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
                traktListItem.Type.Should().BeNull();
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
                traktListItem.Episode.Should().BeNull();
                traktListItem.Person.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ListItemObjectJsonReader_Show_ReadObject_From_Stream_Not_Valid_4()
        {
            var jsonReader = new ListItemObjectJsonReader();

            using (var stream = TYPE_SHOW_JSON_NOT_VALID_4.ToStream())
            {
                var traktListItem = await jsonReader.ReadObjectAsync(stream);

                traktListItem.Should().NotBeNull();
                traktListItem.Rank.Should().Be("1");
                traktListItem.ListedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
                traktListItem.Type.Should().Be(TraktListItemType.Show);
                traktListItem.Show.Should().BeNull();

                traktListItem.Movie.Should().BeNull();
                traktListItem.Season.Should().BeNull();
                traktListItem.Episode.Should().BeNull();
                traktListItem.Person.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ListItemObjectJsonReader_Show_ReadObject_From_Stream_Not_Valid_5()
        {
            var jsonReader = new ListItemObjectJsonReader();

            using (var stream = TYPE_SHOW_JSON_NOT_VALID_5.ToStream())
            {
                var traktListItem = await jsonReader.ReadObjectAsync(stream);

                traktListItem.Should().NotBeNull();
                traktListItem.Rank.Should().BeNull();
                traktListItem.ListedAt.Should().BeNull();
                traktListItem.Type.Should().BeNull();
                traktListItem.Show.Should().BeNull();
                traktListItem.Movie.Should().BeNull();
                traktListItem.Season.Should().BeNull();
                traktListItem.Episode.Should().BeNull();
                traktListItem.Person.Should().BeNull();
            }
        }
    }
}

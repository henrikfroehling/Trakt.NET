namespace TraktNet.Objects.Tests.Get.Shows.Json.Reader
{
    using FluentAssertions;
    using System;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Shows.Json.Reader;
    using Xunit;

    [Category("Objects.Get.Shows.JsonReader")]
    public partial class RecentlyUpdatedShowObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_RecentlyUpdatedShowObjectJsonReader_ReadObject_From_Json_String_Complete()
        {
            var jsonReader = new RecentlyUpdatedShowObjectJsonReader();

            var traktRecentlyUpdatedShow = await jsonReader.ReadObjectAsync(JSON_COMPLETE);

            traktRecentlyUpdatedShow.Should().NotBeNull();
            traktRecentlyUpdatedShow.RecentlyUpdatedAt.Should().Be(DateTime.Parse("2016-03-31T01:29:13Z").ToUniversalTime());
            traktRecentlyUpdatedShow.Show.Should().NotBeNull();
            traktRecentlyUpdatedShow.Show.Title.Should().Be("Game of Thrones");
            traktRecentlyUpdatedShow.Show.Year.Should().Be(2011);
            traktRecentlyUpdatedShow.Show.Ids.Should().NotBeNull();
            traktRecentlyUpdatedShow.Show.Ids.Trakt.Should().Be(1390U);
            traktRecentlyUpdatedShow.Show.Ids.Slug.Should().Be("game-of-thrones");
            traktRecentlyUpdatedShow.Show.Ids.Tvdb.Should().Be(121361U);
            traktRecentlyUpdatedShow.Show.Ids.Imdb.Should().Be("tt0944947");
            traktRecentlyUpdatedShow.Show.Ids.Tmdb.Should().Be(1399U);
            traktRecentlyUpdatedShow.Show.Ids.TvRage.Should().Be(24493U);
        }

        [Fact]
        public async Task RecentlyUpdatedShowObjectJsonReader()
        {
            var jsonReader = new RecentlyUpdatedShowObjectJsonReader();

            var traktRecentlyUpdatedShow = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_1);

            traktRecentlyUpdatedShow.Should().NotBeNull();
            traktRecentlyUpdatedShow.RecentlyUpdatedAt.Should().Be(DateTime.Parse("2016-03-31T01:29:13Z").ToUniversalTime());
            traktRecentlyUpdatedShow.Show.Should().BeNull();
        }

        [Fact]
        public async Task Test_RecentlyUpdatedShowObjectJsonReader_ReadObject_From_Json_String_Incomplete_2()
        {
            var jsonReader = new RecentlyUpdatedShowObjectJsonReader();

            var traktRecentlyUpdatedShow = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_2);

            traktRecentlyUpdatedShow.Should().NotBeNull();
            traktRecentlyUpdatedShow.RecentlyUpdatedAt.Should().BeNull();
            traktRecentlyUpdatedShow.Show.Should().NotBeNull();
            traktRecentlyUpdatedShow.Show.Title.Should().Be("Game of Thrones");
            traktRecentlyUpdatedShow.Show.Year.Should().Be(2011);
            traktRecentlyUpdatedShow.Show.Ids.Should().NotBeNull();
            traktRecentlyUpdatedShow.Show.Ids.Trakt.Should().Be(1390U);
            traktRecentlyUpdatedShow.Show.Ids.Slug.Should().Be("game-of-thrones");
            traktRecentlyUpdatedShow.Show.Ids.Tvdb.Should().Be(121361U);
            traktRecentlyUpdatedShow.Show.Ids.Imdb.Should().Be("tt0944947");
            traktRecentlyUpdatedShow.Show.Ids.Tmdb.Should().Be(1399U);
            traktRecentlyUpdatedShow.Show.Ids.TvRage.Should().Be(24493U);
        }

        [Fact]
        public async Task Test_RecentlyUpdatedShowObjectJsonReader_ReadObject_From_Json_String_Not_Valid_1()
        {
            var jsonReader = new RecentlyUpdatedShowObjectJsonReader();

            var traktRecentlyUpdatedShow = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_1);

            traktRecentlyUpdatedShow.Should().NotBeNull();
            traktRecentlyUpdatedShow.RecentlyUpdatedAt.Should().BeNull();
            traktRecentlyUpdatedShow.Show.Should().NotBeNull();
            traktRecentlyUpdatedShow.Show.Title.Should().Be("Game of Thrones");
            traktRecentlyUpdatedShow.Show.Year.Should().Be(2011);
            traktRecentlyUpdatedShow.Show.Ids.Should().NotBeNull();
            traktRecentlyUpdatedShow.Show.Ids.Trakt.Should().Be(1390U);
            traktRecentlyUpdatedShow.Show.Ids.Slug.Should().Be("game-of-thrones");
            traktRecentlyUpdatedShow.Show.Ids.Tvdb.Should().Be(121361U);
            traktRecentlyUpdatedShow.Show.Ids.Imdb.Should().Be("tt0944947");
            traktRecentlyUpdatedShow.Show.Ids.Tmdb.Should().Be(1399U);
            traktRecentlyUpdatedShow.Show.Ids.TvRage.Should().Be(24493U);
        }

        [Fact]
        public async Task Test_RecentlyUpdatedShowObjectJsonReader_ReadObject_From_Json_String_Not_Valid_2()
        {
            var jsonReader = new RecentlyUpdatedShowObjectJsonReader();

            var traktRecentlyUpdatedShow = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_2);

            traktRecentlyUpdatedShow.Should().NotBeNull();
            traktRecentlyUpdatedShow.RecentlyUpdatedAt.Should().Be(DateTime.Parse("2016-03-31T01:29:13Z").ToUniversalTime());
            traktRecentlyUpdatedShow.Show.Should().BeNull();
        }

        [Fact]
        public async Task Test_RecentlyUpdatedShowObjectJsonReader_ReadObject_From_Json_String_Not_Valid_3()
        {
            var jsonReader = new RecentlyUpdatedShowObjectJsonReader();

            var traktRecentlyUpdatedShow = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_3);

            traktRecentlyUpdatedShow.Should().NotBeNull();
            traktRecentlyUpdatedShow.RecentlyUpdatedAt.Should().BeNull();
            traktRecentlyUpdatedShow.Show.Should().BeNull();
        }

        [Fact]
        public async Task Test_RecentlyUpdatedShowObjectJsonReader_ReadObject_From_Json_String_Null()
        {
            var jsonReader = new RecentlyUpdatedShowObjectJsonReader();

            var traktRecentlyUpdatedShow = await jsonReader.ReadObjectAsync(default(string));
            traktRecentlyUpdatedShow.Should().BeNull();
        }

        [Fact]
        public async Task Test_RecentlyUpdatedShowObjectJsonReader_ReadObject_From_Json_String_Empty()
        {
            var jsonReader = new RecentlyUpdatedShowObjectJsonReader();

            var traktRecentlyUpdatedShow = await jsonReader.ReadObjectAsync(string.Empty);
            traktRecentlyUpdatedShow.Should().BeNull();
        }
    }
}

namespace TraktApiSharp.Tests.Objects.Get.Shows.Json.Reader
{
    using FluentAssertions;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using TestUtils;
    using Traits;
    using TraktApiSharp.Objects.Get.Shows.Json.Reader;
    using Xunit;

    [Category("Objects.Get.Shows.JsonReader")]
    public partial class RecentlyUpdatedShowObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_RecentlyUpdatedShowObjectJsonReader_ReadObject_From_Stream_Complete()
        {
            var traktJsonReader = new RecentlyUpdatedShowObjectJsonReader();

            using (var stream = JSON_COMPLETE.ToStream())
            {
                var traktRecentlyUpdatedShow = await traktJsonReader.ReadObjectAsync(stream);

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
        }

        [Fact]
        public async Task Test_RecentlyUpdatedShowObjectJsonReader_ReadObject_From_Stream_Incomplete_1()
        {
            var traktJsonReader = new RecentlyUpdatedShowObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_1.ToStream())
            {
                var traktRecentlyUpdatedShow = await traktJsonReader.ReadObjectAsync(stream);

                traktRecentlyUpdatedShow.Should().NotBeNull();
                traktRecentlyUpdatedShow.RecentlyUpdatedAt.Should().Be(DateTime.Parse("2016-03-31T01:29:13Z").ToUniversalTime());
                traktRecentlyUpdatedShow.Show.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_RecentlyUpdatedShowObjectJsonReader_ReadObject_From_Stream_Incomplete_2()
        {
            var traktJsonReader = new RecentlyUpdatedShowObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_2.ToStream())
            {
                var traktRecentlyUpdatedShow = await traktJsonReader.ReadObjectAsync(stream);

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
        }

        [Fact]
        public async Task Test_RecentlyUpdatedShowObjectJsonReader_ReadObject_From_Stream_Not_Valid_1()
        {
            var traktJsonReader = new RecentlyUpdatedShowObjectJsonReader();

            using (var stream = JSON_NOT_VALID_1.ToStream())
            {
                var traktRecentlyUpdatedShow = await traktJsonReader.ReadObjectAsync(stream);

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
        }

        [Fact]
        public async Task Test_RecentlyUpdatedShowObjectJsonReader_ReadObject_From_Stream_Not_Valid_2()
        {
            var traktJsonReader = new RecentlyUpdatedShowObjectJsonReader();

            using (var stream = JSON_NOT_VALID_2.ToStream())
            {
                var traktRecentlyUpdatedShow = await traktJsonReader.ReadObjectAsync(stream);

                traktRecentlyUpdatedShow.Should().NotBeNull();
                traktRecentlyUpdatedShow.RecentlyUpdatedAt.Should().Be(DateTime.Parse("2016-03-31T01:29:13Z").ToUniversalTime());
                traktRecentlyUpdatedShow.Show.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_RecentlyUpdatedShowObjectJsonReader_ReadObject_From_Stream_Not_Valid_3()
        {
            var traktJsonReader = new RecentlyUpdatedShowObjectJsonReader();

            using (var stream = JSON_NOT_VALID_3.ToStream())
            {
                var traktRecentlyUpdatedShow = await traktJsonReader.ReadObjectAsync(stream);

                traktRecentlyUpdatedShow.Should().NotBeNull();
                traktRecentlyUpdatedShow.RecentlyUpdatedAt.Should().BeNull();
                traktRecentlyUpdatedShow.Show.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_RecentlyUpdatedShowObjectJsonReader_ReadObject_From_Stream_Null()
        {
            var traktJsonReader = new RecentlyUpdatedShowObjectJsonReader();

            var traktRecentlyUpdatedShow = await traktJsonReader.ReadObjectAsync(default(Stream));
            traktRecentlyUpdatedShow.Should().BeNull();
        }

        [Fact]
        public async Task Test_RecentlyUpdatedShowObjectJsonReader_ReadObject_From_Stream_Empty()
        {
            var traktJsonReader = new RecentlyUpdatedShowObjectJsonReader();

            using (var stream = string.Empty.ToStream())
            {
                var traktRecentlyUpdatedShow = await traktJsonReader.ReadObjectAsync(stream);
                traktRecentlyUpdatedShow.Should().BeNull();
            }
        }
    }
}

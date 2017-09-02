namespace TraktApiSharp.Tests.Objects.Get.Shows.JsonReader
{
    using FluentAssertions;
    using System.IO;
    using System.Threading.Tasks;
    using TestUtils;
    using Traits;
    using TraktApiSharp.Objects.Get.Shows.JsonReader;
    using Xunit;

    [Category("Objects.Get.Shows.JsonReader")]
    public partial class MostPWCShowObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_MostPWCShowObjectJsonReader_ReadObject_From_Stream_Complete()
        {
            var traktJsonReader = new MostPWCShowObjectJsonReader();

            using (var stream = JSON_COMPLETE.ToStream())
            {
                var traktMostPWCShow = await traktJsonReader.ReadObjectAsync(stream);

                traktMostPWCShow.Should().NotBeNull();
                traktMostPWCShow.WatcherCount.Should().Be(4992);
                traktMostPWCShow.PlayCount.Should().Be(7100);
                traktMostPWCShow.CollectedCount.Should().Be(1348);
                traktMostPWCShow.CollectorCount.Should().Be(7964);
                traktMostPWCShow.Show.Should().NotBeNull();
                traktMostPWCShow.Show.Title.Should().Be("Game of Thrones");
                traktMostPWCShow.Show.Year.Should().Be(2011);
                traktMostPWCShow.Show.Ids.Should().NotBeNull();
                traktMostPWCShow.Show.Ids.Trakt.Should().Be(1390U);
                traktMostPWCShow.Show.Ids.Slug.Should().Be("game-of-thrones");
                traktMostPWCShow.Show.Ids.Tvdb.Should().Be(121361U);
                traktMostPWCShow.Show.Ids.Imdb.Should().Be("tt0944947");
                traktMostPWCShow.Show.Ids.Tmdb.Should().Be(1399U);
                traktMostPWCShow.Show.Ids.TvRage.Should().Be(24493U);
            }
        }

        [Fact]
        public async Task Test_MostPWCShowObjectJsonReader_ReadObject_From_Stream_Incomplete_1()
        {
            var traktJsonReader = new MostPWCShowObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_1.ToStream())
            {
                var traktMostPWCShow = await traktJsonReader.ReadObjectAsync(stream);

                traktMostPWCShow.Should().NotBeNull();
                traktMostPWCShow.WatcherCount.Should().BeNull();
                traktMostPWCShow.PlayCount.Should().Be(7100);
                traktMostPWCShow.CollectedCount.Should().Be(1348);
                traktMostPWCShow.CollectorCount.Should().Be(7964);
                traktMostPWCShow.Show.Should().NotBeNull();
                traktMostPWCShow.Show.Title.Should().Be("Game of Thrones");
                traktMostPWCShow.Show.Year.Should().Be(2011);
                traktMostPWCShow.Show.Ids.Should().NotBeNull();
                traktMostPWCShow.Show.Ids.Trakt.Should().Be(1390U);
                traktMostPWCShow.Show.Ids.Slug.Should().Be("game-of-thrones");
                traktMostPWCShow.Show.Ids.Tvdb.Should().Be(121361U);
                traktMostPWCShow.Show.Ids.Imdb.Should().Be("tt0944947");
                traktMostPWCShow.Show.Ids.Tmdb.Should().Be(1399U);
                traktMostPWCShow.Show.Ids.TvRage.Should().Be(24493U);
            }
        }

        [Fact]
        public async Task Test_MostPWCShowObjectJsonReader_ReadObject_From_Stream_Incomplete_2()
        {
            var traktJsonReader = new MostPWCShowObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_2.ToStream())
            {
                var traktMostPWCShow = await traktJsonReader.ReadObjectAsync(stream);

                traktMostPWCShow.Should().NotBeNull();
                traktMostPWCShow.WatcherCount.Should().Be(4992);
                traktMostPWCShow.PlayCount.Should().BeNull();
                traktMostPWCShow.CollectedCount.Should().Be(1348);
                traktMostPWCShow.CollectorCount.Should().Be(7964);
                traktMostPWCShow.Show.Should().NotBeNull();
                traktMostPWCShow.Show.Title.Should().Be("Game of Thrones");
                traktMostPWCShow.Show.Year.Should().Be(2011);
                traktMostPWCShow.Show.Ids.Should().NotBeNull();
                traktMostPWCShow.Show.Ids.Trakt.Should().Be(1390U);
                traktMostPWCShow.Show.Ids.Slug.Should().Be("game-of-thrones");
                traktMostPWCShow.Show.Ids.Tvdb.Should().Be(121361U);
                traktMostPWCShow.Show.Ids.Imdb.Should().Be("tt0944947");
                traktMostPWCShow.Show.Ids.Tmdb.Should().Be(1399U);
                traktMostPWCShow.Show.Ids.TvRage.Should().Be(24493U);
            }
        }

        [Fact]
        public async Task Test_MostPWCShowObjectJsonReader_ReadObject_From_Stream_Incomplete_3()
        {
            var traktJsonReader = new MostPWCShowObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_3.ToStream())
            {
                var traktMostPWCShow = await traktJsonReader.ReadObjectAsync(stream);

                traktMostPWCShow.Should().NotBeNull();
                traktMostPWCShow.WatcherCount.Should().Be(4992);
                traktMostPWCShow.PlayCount.Should().Be(7100);
                traktMostPWCShow.CollectedCount.Should().BeNull();
                traktMostPWCShow.CollectorCount.Should().Be(7964);
                traktMostPWCShow.Show.Should().NotBeNull();
                traktMostPWCShow.Show.Title.Should().Be("Game of Thrones");
                traktMostPWCShow.Show.Year.Should().Be(2011);
                traktMostPWCShow.Show.Ids.Should().NotBeNull();
                traktMostPWCShow.Show.Ids.Trakt.Should().Be(1390U);
                traktMostPWCShow.Show.Ids.Slug.Should().Be("game-of-thrones");
                traktMostPWCShow.Show.Ids.Tvdb.Should().Be(121361U);
                traktMostPWCShow.Show.Ids.Imdb.Should().Be("tt0944947");
                traktMostPWCShow.Show.Ids.Tmdb.Should().Be(1399U);
                traktMostPWCShow.Show.Ids.TvRage.Should().Be(24493U);
            }
        }

        [Fact]
        public async Task Test_MostPWCShowObjectJsonReader_ReadObject_From_Stream_Incomplete_4()
        {
            var traktJsonReader = new MostPWCShowObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_4.ToStream())
            {
                var traktMostPWCShow = await traktJsonReader.ReadObjectAsync(stream);

                traktMostPWCShow.Should().NotBeNull();
                traktMostPWCShow.WatcherCount.Should().Be(4992);
                traktMostPWCShow.PlayCount.Should().Be(7100);
                traktMostPWCShow.CollectedCount.Should().Be(1348);
                traktMostPWCShow.CollectorCount.Should().BeNull();
                traktMostPWCShow.Show.Should().NotBeNull();
                traktMostPWCShow.Show.Title.Should().Be("Game of Thrones");
                traktMostPWCShow.Show.Year.Should().Be(2011);
                traktMostPWCShow.Show.Ids.Should().NotBeNull();
                traktMostPWCShow.Show.Ids.Trakt.Should().Be(1390U);
                traktMostPWCShow.Show.Ids.Slug.Should().Be("game-of-thrones");
                traktMostPWCShow.Show.Ids.Tvdb.Should().Be(121361U);
                traktMostPWCShow.Show.Ids.Imdb.Should().Be("tt0944947");
                traktMostPWCShow.Show.Ids.Tmdb.Should().Be(1399U);
                traktMostPWCShow.Show.Ids.TvRage.Should().Be(24493U);
            }
        }

        [Fact]
        public async Task Test_MostPWCShowObjectJsonReader_ReadObject_From_Stream_Incomplete_5()
        {
            var traktJsonReader = new MostPWCShowObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_5.ToStream())
            {
                var traktMostPWCShow = await traktJsonReader.ReadObjectAsync(stream);

                traktMostPWCShow.Should().NotBeNull();
                traktMostPWCShow.WatcherCount.Should().Be(4992);
                traktMostPWCShow.PlayCount.Should().Be(7100);
                traktMostPWCShow.CollectedCount.Should().Be(1348);
                traktMostPWCShow.CollectorCount.Should().Be(7964);
                traktMostPWCShow.Show.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_MostPWCShowObjectJsonReader_ReadObject_From_Stream_Incomplete_6()
        {
            var traktJsonReader = new MostPWCShowObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_6.ToStream())
            {
                var traktMostPWCShow = await traktJsonReader.ReadObjectAsync(stream);

                traktMostPWCShow.Should().NotBeNull();
                traktMostPWCShow.WatcherCount.Should().Be(4992);
                traktMostPWCShow.PlayCount.Should().BeNull();
                traktMostPWCShow.CollectedCount.Should().BeNull();
                traktMostPWCShow.CollectorCount.Should().BeNull();
                traktMostPWCShow.Show.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_MostPWCShowObjectJsonReader_ReadObject_From_Stream_Incomplete_7()
        {
            var traktJsonReader = new MostPWCShowObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_7.ToStream())
            {
                var traktMostPWCShow = await traktJsonReader.ReadObjectAsync(stream);

                traktMostPWCShow.Should().NotBeNull();
                traktMostPWCShow.WatcherCount.Should().BeNull();
                traktMostPWCShow.PlayCount.Should().Be(7100);
                traktMostPWCShow.CollectedCount.Should().BeNull();
                traktMostPWCShow.CollectorCount.Should().BeNull();
                traktMostPWCShow.Show.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_MostPWCShowObjectJsonReader_ReadObject_From_Stream_Incomplete_8()
        {
            var traktJsonReader = new MostPWCShowObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_8.ToStream())
            {
                var traktMostPWCShow = await traktJsonReader.ReadObjectAsync(stream);

                traktMostPWCShow.Should().NotBeNull();
                traktMostPWCShow.WatcherCount.Should().BeNull();
                traktMostPWCShow.PlayCount.Should().BeNull();
                traktMostPWCShow.CollectedCount.Should().Be(1348);
                traktMostPWCShow.CollectorCount.Should().BeNull();
                traktMostPWCShow.Show.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_MostPWCShowObjectJsonReader_ReadObject_From_Stream_Incomplete_9()
        {
            var traktJsonReader = new MostPWCShowObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_9.ToStream())
            {
                var traktMostPWCShow = await traktJsonReader.ReadObjectAsync(stream);

                traktMostPWCShow.Should().NotBeNull();
                traktMostPWCShow.WatcherCount.Should().BeNull();
                traktMostPWCShow.PlayCount.Should().BeNull();
                traktMostPWCShow.CollectedCount.Should().BeNull();
                traktMostPWCShow.CollectorCount.Should().Be(7964);
                traktMostPWCShow.Show.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_MostPWCShowObjectJsonReader_ReadObject_From_Stream_Incomplete_10()
        {
            var traktJsonReader = new MostPWCShowObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_10.ToStream())
            {
                var traktMostPWCShow = await traktJsonReader.ReadObjectAsync(stream);

                traktMostPWCShow.Should().NotBeNull();
                traktMostPWCShow.WatcherCount.Should().BeNull();
                traktMostPWCShow.PlayCount.Should().BeNull();
                traktMostPWCShow.CollectedCount.Should().BeNull();
                traktMostPWCShow.CollectorCount.Should().BeNull();
                traktMostPWCShow.Show.Should().NotBeNull();
                traktMostPWCShow.Show.Title.Should().Be("Game of Thrones");
                traktMostPWCShow.Show.Year.Should().Be(2011);
                traktMostPWCShow.Show.Ids.Should().NotBeNull();
                traktMostPWCShow.Show.Ids.Trakt.Should().Be(1390U);
                traktMostPWCShow.Show.Ids.Slug.Should().Be("game-of-thrones");
                traktMostPWCShow.Show.Ids.Tvdb.Should().Be(121361U);
                traktMostPWCShow.Show.Ids.Imdb.Should().Be("tt0944947");
                traktMostPWCShow.Show.Ids.Tmdb.Should().Be(1399U);
                traktMostPWCShow.Show.Ids.TvRage.Should().Be(24493U);
            }
        }

        [Fact]
        public async Task Test_MostPWCShowObjectJsonReader_ReadObject_From_Stream_Not_Valid_1()
        {
            var traktJsonReader = new MostPWCShowObjectJsonReader();

            using (var stream = JSON_NOT_VALID_1.ToStream())
            {
                var traktMostPWCShow = await traktJsonReader.ReadObjectAsync(stream);

                traktMostPWCShow.Should().NotBeNull();
                traktMostPWCShow.WatcherCount.Should().BeNull();
                traktMostPWCShow.PlayCount.Should().Be(7100);
                traktMostPWCShow.CollectedCount.Should().Be(1348);
                traktMostPWCShow.CollectorCount.Should().Be(7964);
                traktMostPWCShow.Show.Should().NotBeNull();
                traktMostPWCShow.Show.Title.Should().Be("Game of Thrones");
                traktMostPWCShow.Show.Year.Should().Be(2011);
                traktMostPWCShow.Show.Ids.Should().NotBeNull();
                traktMostPWCShow.Show.Ids.Trakt.Should().Be(1390U);
                traktMostPWCShow.Show.Ids.Slug.Should().Be("game-of-thrones");
                traktMostPWCShow.Show.Ids.Tvdb.Should().Be(121361U);
                traktMostPWCShow.Show.Ids.Imdb.Should().Be("tt0944947");
                traktMostPWCShow.Show.Ids.Tmdb.Should().Be(1399U);
                traktMostPWCShow.Show.Ids.TvRage.Should().Be(24493U);
            }
        }

        [Fact]
        public async Task Test_MostPWCShowObjectJsonReader_ReadObject_From_Stream_Not_Valid_2()
        {
            var traktJsonReader = new MostPWCShowObjectJsonReader();

            using (var stream = JSON_NOT_VALID_2.ToStream())
            {
                var traktMostPWCShow = await traktJsonReader.ReadObjectAsync(stream);

                traktMostPWCShow.Should().NotBeNull();
                traktMostPWCShow.WatcherCount.Should().Be(4992);
                traktMostPWCShow.PlayCount.Should().BeNull();
                traktMostPWCShow.CollectedCount.Should().Be(1348);
                traktMostPWCShow.CollectorCount.Should().Be(7964);
                traktMostPWCShow.Show.Should().NotBeNull();
                traktMostPWCShow.Show.Title.Should().Be("Game of Thrones");
                traktMostPWCShow.Show.Year.Should().Be(2011);
                traktMostPWCShow.Show.Ids.Should().NotBeNull();
                traktMostPWCShow.Show.Ids.Trakt.Should().Be(1390U);
                traktMostPWCShow.Show.Ids.Slug.Should().Be("game-of-thrones");
                traktMostPWCShow.Show.Ids.Tvdb.Should().Be(121361U);
                traktMostPWCShow.Show.Ids.Imdb.Should().Be("tt0944947");
                traktMostPWCShow.Show.Ids.Tmdb.Should().Be(1399U);
                traktMostPWCShow.Show.Ids.TvRage.Should().Be(24493U);
            }
        }

        [Fact]
        public async Task Test_MostPWCShowObjectJsonReader_ReadObject_From_Stream_Not_Valid_3()
        {
            var traktJsonReader = new MostPWCShowObjectJsonReader();

            using (var stream = JSON_NOT_VALID_3.ToStream())
            {
                var traktMostPWCShow = await traktJsonReader.ReadObjectAsync(stream);

                traktMostPWCShow.Should().NotBeNull();
                traktMostPWCShow.WatcherCount.Should().Be(4992);
                traktMostPWCShow.PlayCount.Should().Be(7100);
                traktMostPWCShow.CollectedCount.Should().BeNull();
                traktMostPWCShow.CollectorCount.Should().Be(7964);
                traktMostPWCShow.Show.Should().NotBeNull();
                traktMostPWCShow.Show.Title.Should().Be("Game of Thrones");
                traktMostPWCShow.Show.Year.Should().Be(2011);
                traktMostPWCShow.Show.Ids.Should().NotBeNull();
                traktMostPWCShow.Show.Ids.Trakt.Should().Be(1390U);
                traktMostPWCShow.Show.Ids.Slug.Should().Be("game-of-thrones");
                traktMostPWCShow.Show.Ids.Tvdb.Should().Be(121361U);
                traktMostPWCShow.Show.Ids.Imdb.Should().Be("tt0944947");
                traktMostPWCShow.Show.Ids.Tmdb.Should().Be(1399U);
                traktMostPWCShow.Show.Ids.TvRage.Should().Be(24493U);
            }
        }

        [Fact]
        public async Task Test_MostPWCShowObjectJsonReader_ReadObject_From_Stream_Not_Valid_4()
        {
            var traktJsonReader = new MostPWCShowObjectJsonReader();

            using (var stream = JSON_NOT_VALID_4.ToStream())
            {
                var traktMostPWCShow = await traktJsonReader.ReadObjectAsync(stream);

                traktMostPWCShow.Should().NotBeNull();
                traktMostPWCShow.WatcherCount.Should().Be(4992);
                traktMostPWCShow.PlayCount.Should().Be(7100);
                traktMostPWCShow.CollectedCount.Should().Be(1348);
                traktMostPWCShow.CollectorCount.Should().BeNull();
                traktMostPWCShow.Show.Should().NotBeNull();
                traktMostPWCShow.Show.Title.Should().Be("Game of Thrones");
                traktMostPWCShow.Show.Year.Should().Be(2011);
                traktMostPWCShow.Show.Ids.Should().NotBeNull();
                traktMostPWCShow.Show.Ids.Trakt.Should().Be(1390U);
                traktMostPWCShow.Show.Ids.Slug.Should().Be("game-of-thrones");
                traktMostPWCShow.Show.Ids.Tvdb.Should().Be(121361U);
                traktMostPWCShow.Show.Ids.Imdb.Should().Be("tt0944947");
                traktMostPWCShow.Show.Ids.Tmdb.Should().Be(1399U);
                traktMostPWCShow.Show.Ids.TvRage.Should().Be(24493U);
            }
        }

        [Fact]
        public async Task Test_MostPWCShowObjectJsonReader_ReadObject_From_Stream_Not_Valid_5()
        {
            var traktJsonReader = new MostPWCShowObjectJsonReader();

            using (var stream = JSON_NOT_VALID_5.ToStream())
            {
                var traktMostPWCShow = await traktJsonReader.ReadObjectAsync(stream);

                traktMostPWCShow.Should().NotBeNull();
                traktMostPWCShow.WatcherCount.Should().Be(4992);
                traktMostPWCShow.PlayCount.Should().Be(7100);
                traktMostPWCShow.CollectedCount.Should().Be(1348);
                traktMostPWCShow.CollectorCount.Should().Be(7964);
                traktMostPWCShow.Show.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_MostPWCShowObjectJsonReader_ReadObject_From_Stream_Not_Valid_6()
        {
            var traktJsonReader = new MostPWCShowObjectJsonReader();

            using (var stream = JSON_NOT_VALID_6.ToStream())
            {
                var traktMostPWCShow = await traktJsonReader.ReadObjectAsync(stream);

                traktMostPWCShow.Should().NotBeNull();
                traktMostPWCShow.WatcherCount.Should().BeNull();
                traktMostPWCShow.PlayCount.Should().BeNull();
                traktMostPWCShow.CollectedCount.Should().BeNull();
                traktMostPWCShow.CollectorCount.Should().BeNull();
                traktMostPWCShow.Show.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_MostPWCShowObjectJsonReader_ReadObject_From_Stream_Null()
        {
            var traktJsonReader = new MostPWCShowObjectJsonReader();

            var traktMostPWCShow = await traktJsonReader.ReadObjectAsync(default(Stream));
            traktMostPWCShow.Should().BeNull();
        }

        [Fact]
        public async Task Test_MostPWCShowObjectJsonReader_ReadObject_From_Stream_Empty()
        {
            var traktJsonReader = new MostPWCShowObjectJsonReader();

            using (var stream = string.Empty.ToStream())
            {
                var traktMostPWCShow = await traktJsonReader.ReadObjectAsync(stream);
                traktMostPWCShow.Should().BeNull();
            }
        }
    }
}

namespace TraktApiSharp.Tests.Objects.Get.Shows.Json
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System.IO;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Objects.Get.Shows.Json;
    using Xunit;

    [Category("Objects.Get.Shows.JsonReader")]
    public partial class MostPWCShowObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_MostPWCShowObjectJsonReader_ReadObject_From_JsonReader_Complete()
        {
            var traktJsonReader = new MostPWCShowObjectJsonReader();

            using (var reader = new StringReader(JSON_COMPLETE))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMostPWCShow = await traktJsonReader.ReadObjectAsync(jsonReader);

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
        public async Task Test_MostPWCShowObjectJsonReader_ReadObject_From_JsonReader_Incomplete_1()
        {
            var traktJsonReader = new MostPWCShowObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMostPWCShow = await traktJsonReader.ReadObjectAsync(jsonReader);

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
        public async Task Test_MostPWCShowObjectJsonReader_ReadObject_From_JsonReader_Incomplete_2()
        {
            var traktJsonReader = new MostPWCShowObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMostPWCShow = await traktJsonReader.ReadObjectAsync(jsonReader);

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
        public async Task Test_MostPWCShowObjectJsonReader_ReadObject_From_JsonReader_Incomplete_3()
        {
            var traktJsonReader = new MostPWCShowObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMostPWCShow = await traktJsonReader.ReadObjectAsync(jsonReader);

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
        public async Task Test_MostPWCShowObjectJsonReader_ReadObject_From_JsonReader_Incomplete_4()
        {
            var traktJsonReader = new MostPWCShowObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMostPWCShow = await traktJsonReader.ReadObjectAsync(jsonReader);

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
        public async Task Test_MostPWCShowObjectJsonReader_ReadObject_From_JsonReader_Incomplete_5()
        {
            var traktJsonReader = new MostPWCShowObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_5))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMostPWCShow = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMostPWCShow.Should().NotBeNull();
                traktMostPWCShow.WatcherCount.Should().Be(4992);
                traktMostPWCShow.PlayCount.Should().Be(7100);
                traktMostPWCShow.CollectedCount.Should().Be(1348);
                traktMostPWCShow.CollectorCount.Should().Be(7964);
                traktMostPWCShow.Show.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_MostPWCShowObjectJsonReader_ReadObject_From_JsonReader_Incomplete_6()
        {
            var traktJsonReader = new MostPWCShowObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_6))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMostPWCShow = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMostPWCShow.Should().NotBeNull();
                traktMostPWCShow.WatcherCount.Should().Be(4992);
                traktMostPWCShow.PlayCount.Should().BeNull();
                traktMostPWCShow.CollectedCount.Should().BeNull();
                traktMostPWCShow.CollectorCount.Should().BeNull();
                traktMostPWCShow.Show.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_MostPWCShowObjectJsonReader_ReadObject_From_JsonReader_Incomplete_7()
        {
            var traktJsonReader = new MostPWCShowObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_7))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMostPWCShow = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMostPWCShow.Should().NotBeNull();
                traktMostPWCShow.WatcherCount.Should().BeNull();
                traktMostPWCShow.PlayCount.Should().Be(7100);
                traktMostPWCShow.CollectedCount.Should().BeNull();
                traktMostPWCShow.CollectorCount.Should().BeNull();
                traktMostPWCShow.Show.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_MostPWCShowObjectJsonReader_ReadObject_From_JsonReader_Incomplete_8()
        {
            var traktJsonReader = new MostPWCShowObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_8))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMostPWCShow = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMostPWCShow.Should().NotBeNull();
                traktMostPWCShow.WatcherCount.Should().BeNull();
                traktMostPWCShow.PlayCount.Should().BeNull();
                traktMostPWCShow.CollectedCount.Should().Be(1348);
                traktMostPWCShow.CollectorCount.Should().BeNull();
                traktMostPWCShow.Show.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_MostPWCShowObjectJsonReader_ReadObject_From_JsonReader_Incomplete_9()
        {
            var traktJsonReader = new MostPWCShowObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_9))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMostPWCShow = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMostPWCShow.Should().NotBeNull();
                traktMostPWCShow.WatcherCount.Should().BeNull();
                traktMostPWCShow.PlayCount.Should().BeNull();
                traktMostPWCShow.CollectedCount.Should().BeNull();
                traktMostPWCShow.CollectorCount.Should().Be(7964);
                traktMostPWCShow.Show.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_MostPWCShowObjectJsonReader_ReadObject_From_JsonReader_Incomplete_10()
        {
            var traktJsonReader = new MostPWCShowObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_10))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMostPWCShow = await traktJsonReader.ReadObjectAsync(jsonReader);

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
        public async Task Test_MostPWCShowObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_1()
        {
            var traktJsonReader = new MostPWCShowObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMostPWCShow = await traktJsonReader.ReadObjectAsync(jsonReader);

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
        public async Task Test_MostPWCShowObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_2()
        {
            var traktJsonReader = new MostPWCShowObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMostPWCShow = await traktJsonReader.ReadObjectAsync(jsonReader);

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
        public async Task Test_MostPWCShowObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_3()
        {
            var traktJsonReader = new MostPWCShowObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMostPWCShow = await traktJsonReader.ReadObjectAsync(jsonReader);

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
        public async Task Test_MostPWCShowObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_4()
        {
            var traktJsonReader = new MostPWCShowObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMostPWCShow = await traktJsonReader.ReadObjectAsync(jsonReader);

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
        public async Task Test_MostPWCShowObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_5()
        {
            var traktJsonReader = new MostPWCShowObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_5))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMostPWCShow = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMostPWCShow.Should().NotBeNull();
                traktMostPWCShow.WatcherCount.Should().Be(4992);
                traktMostPWCShow.PlayCount.Should().Be(7100);
                traktMostPWCShow.CollectedCount.Should().Be(1348);
                traktMostPWCShow.CollectorCount.Should().Be(7964);
                traktMostPWCShow.Show.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_MostPWCShowObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_6()
        {
            var traktJsonReader = new MostPWCShowObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_6))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMostPWCShow = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktMostPWCShow.Should().NotBeNull();
                traktMostPWCShow.WatcherCount.Should().BeNull();
                traktMostPWCShow.PlayCount.Should().BeNull();
                traktMostPWCShow.CollectedCount.Should().BeNull();
                traktMostPWCShow.CollectorCount.Should().BeNull();
                traktMostPWCShow.Show.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_MostPWCShowObjectJsonReader_ReadObject_From_JsonReader_Null()
        {
            var traktJsonReader = new MostPWCShowObjectJsonReader();

            var traktMostPWCShow = await traktJsonReader.ReadObjectAsync(default(JsonTextReader));
            traktMostPWCShow.Should().BeNull();
        }

        [Fact]
        public async Task Test_MostPWCShowObjectJsonReader_ReadObject_From_JsonReader_Empty()
        {
            var traktJsonReader = new MostPWCShowObjectJsonReader();

            using (var reader = new StringReader(string.Empty))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMostPWCShow = await traktJsonReader.ReadObjectAsync(jsonReader);
                traktMostPWCShow.Should().BeNull();
            }
        }
    }
}

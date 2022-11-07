namespace TraktNet.Objects.Get.Tests.Shows.Json.Reader
{
    using FluentAssertions;
    using System;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Shows;
    using TraktNet.Objects.Get.Shows.Json.Reader;
    using Xunit;

    [TestCategory("Objects.Get.Shows.JsonReader")]
    public partial class MostPWCShowObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_MostPWCShowObjectJsonReader_ReadObject_From_Json_String_Complete()
        {
            var jsonReader = new MostPWCShowObjectJsonReader();

            var traktMostPWCShow = await jsonReader.ReadObjectAsync(JSON_COMPLETE);

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

        [Fact]
        public async Task Test_MostPWCShowObjectJsonReader_ReadObject_From_Json_String_Incomplete_1()
        {
            var jsonReader = new MostPWCShowObjectJsonReader();

            var traktMostPWCShow = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_1);

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

        [Fact]
        public async Task Test_MostPWCShowObjectJsonReader_ReadObject_From_Json_String_Incomplete_2()
        {
            var jsonReader = new MostPWCShowObjectJsonReader();

            var traktMostPWCShow = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_2);

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

        [Fact]
        public async Task Test_MostPWCShowObjectJsonReader_ReadObject_From_Json_String_Incomplete_3()
        {
            var jsonReader = new MostPWCShowObjectJsonReader();

            var traktMostPWCShow = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_3);

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

        [Fact]
        public async Task Test_MostPWCShowObjectJsonReader_ReadObject_From_Json_String_Incomplete_4()
        {
            var jsonReader = new MostPWCShowObjectJsonReader();

            var traktMostPWCShow = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_4);

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

        [Fact]
        public async Task Test_MostPWCShowObjectJsonReader_ReadObject_From_Json_String_Incomplete_5()
        {
            var jsonReader = new MostPWCShowObjectJsonReader();

            var traktMostPWCShow = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_5);

            traktMostPWCShow.Should().NotBeNull();
            traktMostPWCShow.WatcherCount.Should().Be(4992);
            traktMostPWCShow.PlayCount.Should().Be(7100);
            traktMostPWCShow.CollectedCount.Should().Be(1348);
            traktMostPWCShow.CollectorCount.Should().Be(7964);
            traktMostPWCShow.Show.Should().BeNull();
        }

        [Fact]
        public async Task Test_MostPWCShowObjectJsonReader_ReadObject_From_Json_String_Incomplete_6()
        {
            var jsonReader = new MostPWCShowObjectJsonReader();

            var traktMostPWCShow = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_6);

            traktMostPWCShow.Should().NotBeNull();
            traktMostPWCShow.WatcherCount.Should().Be(4992);
            traktMostPWCShow.PlayCount.Should().BeNull();
            traktMostPWCShow.CollectedCount.Should().BeNull();
            traktMostPWCShow.CollectorCount.Should().BeNull();
            traktMostPWCShow.Show.Should().BeNull();
        }

        [Fact]
        public async Task Test_MostPWCShowObjectJsonReader_ReadObject_From_Json_String_Incomplete_7()
        {
            var jsonReader = new MostPWCShowObjectJsonReader();

            var traktMostPWCShow = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_7);

            traktMostPWCShow.Should().NotBeNull();
            traktMostPWCShow.WatcherCount.Should().BeNull();
            traktMostPWCShow.PlayCount.Should().Be(7100);
            traktMostPWCShow.CollectedCount.Should().BeNull();
            traktMostPWCShow.CollectorCount.Should().BeNull();
            traktMostPWCShow.Show.Should().BeNull();
        }

        [Fact]
        public async Task Test_MostPWCShowObjectJsonReader_ReadObject_From_Json_String_Incomplete_8()
        {
            var jsonReader = new MostPWCShowObjectJsonReader();

            var traktMostPWCShow = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_8);

            traktMostPWCShow.Should().NotBeNull();
            traktMostPWCShow.WatcherCount.Should().BeNull();
            traktMostPWCShow.PlayCount.Should().BeNull();
            traktMostPWCShow.CollectedCount.Should().Be(1348);
            traktMostPWCShow.CollectorCount.Should().BeNull();
            traktMostPWCShow.Show.Should().BeNull();
        }

        [Fact]
        public async Task Test_MostPWCShowObjectJsonReader_ReadObject_From_Json_String_Incomplete_9()
        {
            var jsonReader = new MostPWCShowObjectJsonReader();

            var traktMostPWCShow = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_9);

            traktMostPWCShow.Should().NotBeNull();
            traktMostPWCShow.WatcherCount.Should().BeNull();
            traktMostPWCShow.PlayCount.Should().BeNull();
            traktMostPWCShow.CollectedCount.Should().BeNull();
            traktMostPWCShow.CollectorCount.Should().Be(7964);
            traktMostPWCShow.Show.Should().BeNull();
        }

        [Fact]
        public async Task Test_MostPWCShowObjectJsonReader_ReadObject_From_Json_String_Incomplete_10()
        {
            var jsonReader = new MostPWCShowObjectJsonReader();

            var traktMostPWCShow = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_10);

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

        [Fact]
        public async Task Test_MostPWCShowObjectJsonReader_ReadObject_From_Json_String_Not_Valid_1()
        {
            var jsonReader = new MostPWCShowObjectJsonReader();

            var traktMostPWCShow = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_1);

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

        [Fact]
        public async Task Test_MostPWCShowObjectJsonReader_ReadObject_From_Json_String_Not_Valid_2()
        {
            var jsonReader = new MostPWCShowObjectJsonReader();

            var traktMostPWCShow = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_2);

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

        [Fact]
        public async Task Test_MostPWCShowObjectJsonReader_ReadObject_From_Json_String_Not_Valid_3()
        {
            var jsonReader = new MostPWCShowObjectJsonReader();

            var traktMostPWCShow = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_3);

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

        [Fact]
        public async Task Test_MostPWCShowObjectJsonReader_ReadObject_From_Json_String_Not_Valid_4()
        {
            var jsonReader = new MostPWCShowObjectJsonReader();

            var traktMostPWCShow = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_4);

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

        [Fact]
        public async Task Test_MostPWCShowObjectJsonReader_ReadObject_From_Json_String_Not_Valid_5()
        {
            var jsonReader = new MostPWCShowObjectJsonReader();

            var traktMostPWCShow = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_5);

            traktMostPWCShow.Should().NotBeNull();
            traktMostPWCShow.WatcherCount.Should().Be(4992);
            traktMostPWCShow.PlayCount.Should().Be(7100);
            traktMostPWCShow.CollectedCount.Should().Be(1348);
            traktMostPWCShow.CollectorCount.Should().Be(7964);
            traktMostPWCShow.Show.Should().BeNull();
        }

        [Fact]
        public async Task Test_MostPWCShowObjectJsonReader_ReadObject_From_Json_String_Not_Valid_6()
        {
            var jsonReader = new MostPWCShowObjectJsonReader();

            var traktMostPWCShow = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_6);

            traktMostPWCShow.Should().NotBeNull();
            traktMostPWCShow.WatcherCount.Should().BeNull();
            traktMostPWCShow.PlayCount.Should().BeNull();
            traktMostPWCShow.CollectedCount.Should().BeNull();
            traktMostPWCShow.CollectorCount.Should().BeNull();
            traktMostPWCShow.Show.Should().BeNull();
        }

        [Fact]
        public async Task Test_MostPWCShowObjectJsonReader_ReadObject_From_Json_String_Null()
        {
            var jsonReader = new MostPWCShowObjectJsonReader();
            Func<Task<ITraktMostPWCShow>> traktMostPWCShow = () => jsonReader.ReadObjectAsync(default(string));
            await traktMostPWCShow.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_MostPWCShowObjectJsonReader_ReadObject_From_Json_String_Empty()
        {
            var jsonReader = new MostPWCShowObjectJsonReader();

            var traktMostPWCShow = await jsonReader.ReadObjectAsync(string.Empty);
            traktMostPWCShow.Should().BeNull();
        }
    }
}

namespace TraktApiSharp.Tests.Objects.Get.Shows.JsonReader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System.IO;
    using Traits;
    using TraktApiSharp.Objects.Get.Shows;
    using TraktApiSharp.Objects.Get.Shows.JsonReader;
    using TraktApiSharp.Objects.JsonReader;
    using Xunit;

    [Category("Objects.Get.Shows.JsonReader")]
    public class ITraktMostPWCShowObjectJsonReader_Tests
    {
        [Fact]
        public void Test_ITraktMostPWCShowObjectJsonReader_Implements_ITraktObjectJsonReader_Interface()
        {
            typeof(ITraktMostPWCShowObjectJsonReader).GetInterfaces().Should().Contain(typeof(ITraktObjectJsonReader<ITraktMostPWCShow>));
        }

        [Fact]
        public void Test_ITraktMostPWCShowObjectJsonReader_ReadObject_From_Json_String_Complete()
        {
            var jsonReader = new ITraktMostPWCShowObjectJsonReader();

            var traktMostPWCShow = jsonReader.ReadObject(JSON_COMPLETE);

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
        public void Test_ITraktMostPWCShowObjectJsonReader_ReadObject_From_Json_String_Incomplete_1()
        {
            var jsonReader = new ITraktMostPWCShowObjectJsonReader();

            var traktMostPWCShow = jsonReader.ReadObject(JSON_INCOMPLETE_1);

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
        public void Test_ITraktMostPWCShowObjectJsonReader_ReadObject_From_Json_String_Incomplete_2()
        {
            var jsonReader = new ITraktMostPWCShowObjectJsonReader();

            var traktMostPWCShow = jsonReader.ReadObject(JSON_INCOMPLETE_2);

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
        public void Test_ITraktMostPWCShowObjectJsonReader_ReadObject_From_Json_String_Incomplete_3()
        {
            var jsonReader = new ITraktMostPWCShowObjectJsonReader();

            var traktMostPWCShow = jsonReader.ReadObject(JSON_INCOMPLETE_3);

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
        public void Test_ITraktMostPWCShowObjectJsonReader_ReadObject_From_Json_String_Incomplete_4()
        {
            var jsonReader = new ITraktMostPWCShowObjectJsonReader();

            var traktMostPWCShow = jsonReader.ReadObject(JSON_INCOMPLETE_4);

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
        public void Test_ITraktMostPWCShowObjectJsonReader_ReadObject_From_Json_String_Incomplete_5()
        {
            var jsonReader = new ITraktMostPWCShowObjectJsonReader();

            var traktMostPWCShow = jsonReader.ReadObject(JSON_INCOMPLETE_5);

            traktMostPWCShow.Should().NotBeNull();
            traktMostPWCShow.WatcherCount.Should().Be(4992);
            traktMostPWCShow.PlayCount.Should().Be(7100);
            traktMostPWCShow.CollectedCount.Should().Be(1348);
            traktMostPWCShow.CollectorCount.Should().Be(7964);
            traktMostPWCShow.Show.Should().BeNull();
        }

        [Fact]
        public void Test_ITraktMostPWCShowObjectJsonReader_ReadObject_From_Json_String_Incomplete_6()
        {
            var jsonReader = new ITraktMostPWCShowObjectJsonReader();

            var traktMostPWCShow = jsonReader.ReadObject(JSON_INCOMPLETE_6);

            traktMostPWCShow.Should().NotBeNull();
            traktMostPWCShow.WatcherCount.Should().Be(4992);
            traktMostPWCShow.PlayCount.Should().BeNull();
            traktMostPWCShow.CollectedCount.Should().BeNull();
            traktMostPWCShow.CollectorCount.Should().BeNull();
            traktMostPWCShow.Show.Should().BeNull();
        }

        [Fact]
        public void Test_ITraktMostPWCShowObjectJsonReader_ReadObject_From_Json_String_Incomplete_7()
        {
            var jsonReader = new ITraktMostPWCShowObjectJsonReader();

            var traktMostPWCShow = jsonReader.ReadObject(JSON_INCOMPLETE_7);

            traktMostPWCShow.Should().NotBeNull();
            traktMostPWCShow.WatcherCount.Should().BeNull();
            traktMostPWCShow.PlayCount.Should().Be(7100);
            traktMostPWCShow.CollectedCount.Should().BeNull();
            traktMostPWCShow.CollectorCount.Should().BeNull();
            traktMostPWCShow.Show.Should().BeNull();
        }

        [Fact]
        public void Test_ITraktMostPWCShowObjectJsonReader_ReadObject_From_Json_String_Incomplete_8()
        {
            var jsonReader = new ITraktMostPWCShowObjectJsonReader();

            var traktMostPWCShow = jsonReader.ReadObject(JSON_INCOMPLETE_8);

            traktMostPWCShow.Should().NotBeNull();
            traktMostPWCShow.WatcherCount.Should().BeNull();
            traktMostPWCShow.PlayCount.Should().BeNull();
            traktMostPWCShow.CollectedCount.Should().Be(1348);
            traktMostPWCShow.CollectorCount.Should().BeNull();
            traktMostPWCShow.Show.Should().BeNull();
        }

        [Fact]
        public void Test_ITraktMostPWCShowObjectJsonReader_ReadObject_From_Json_String_Incomplete_9()
        {
            var jsonReader = new ITraktMostPWCShowObjectJsonReader();

            var traktMostPWCShow = jsonReader.ReadObject(JSON_INCOMPLETE_9);

            traktMostPWCShow.Should().NotBeNull();
            traktMostPWCShow.WatcherCount.Should().BeNull();
            traktMostPWCShow.PlayCount.Should().BeNull();
            traktMostPWCShow.CollectedCount.Should().BeNull();
            traktMostPWCShow.CollectorCount.Should().Be(7964);
            traktMostPWCShow.Show.Should().BeNull();
        }

        [Fact]
        public void Test_ITraktMostPWCShowObjectJsonReader_ReadObject_From_Json_String_Incomplete_10()
        {
            var jsonReader = new ITraktMostPWCShowObjectJsonReader();

            var traktMostPWCShow = jsonReader.ReadObject(JSON_INCOMPLETE_10);

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
        public void Test_ITraktMostPWCShowObjectJsonReader_ReadObject_From_Json_String_Not_Valid_1()
        {
            var jsonReader = new ITraktMostPWCShowObjectJsonReader();

            var traktMostPWCShow = jsonReader.ReadObject(JSON_NOT_VALID_1);

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
        public void Test_ITraktMostPWCShowObjectJsonReader_ReadObject_From_Json_String_Not_Valid_2()
        {
            var jsonReader = new ITraktMostPWCShowObjectJsonReader();

            var traktMostPWCShow = jsonReader.ReadObject(JSON_NOT_VALID_2);

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
        public void Test_ITraktMostPWCShowObjectJsonReader_ReadObject_From_Json_String_Not_Valid_3()
        {
            var jsonReader = new ITraktMostPWCShowObjectJsonReader();

            var traktMostPWCShow = jsonReader.ReadObject(JSON_NOT_VALID_3);

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
        public void Test_ITraktMostPWCShowObjectJsonReader_ReadObject_From_Json_String_Not_Valid_4()
        {
            var jsonReader = new ITraktMostPWCShowObjectJsonReader();

            var traktMostPWCShow = jsonReader.ReadObject(JSON_NOT_VALID_4);

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
        public void Test_ITraktMostPWCShowObjectJsonReader_ReadObject_From_Json_String_Not_Valid_5()
        {
            var jsonReader = new ITraktMostPWCShowObjectJsonReader();

            var traktMostPWCShow = jsonReader.ReadObject(JSON_NOT_VALID_5);

            traktMostPWCShow.Should().NotBeNull();
            traktMostPWCShow.WatcherCount.Should().Be(4992);
            traktMostPWCShow.PlayCount.Should().Be(7100);
            traktMostPWCShow.CollectedCount.Should().Be(1348);
            traktMostPWCShow.CollectorCount.Should().Be(7964);
            traktMostPWCShow.Show.Should().BeNull();
        }

        [Fact]
        public void Test_ITraktMostPWCShowObjectJsonReader_ReadObject_From_Json_String_Not_Valid_6()
        {
            var jsonReader = new ITraktMostPWCShowObjectJsonReader();

            var traktMostPWCShow = jsonReader.ReadObject(JSON_NOT_VALID_6);

            traktMostPWCShow.Should().NotBeNull();
            traktMostPWCShow.WatcherCount.Should().BeNull();
            traktMostPWCShow.PlayCount.Should().BeNull();
            traktMostPWCShow.CollectedCount.Should().BeNull();
            traktMostPWCShow.CollectorCount.Should().BeNull();
            traktMostPWCShow.Show.Should().BeNull();
        }

        [Fact]
        public void Test_ITraktMostPWCShowObjectJsonReader_ReadObject_From_Json_String_Null()
        {
            var jsonReader = new ITraktMostPWCShowObjectJsonReader();

            var traktMostPWCShow = jsonReader.ReadObject(default(string));
            traktMostPWCShow.Should().BeNull();
        }

        [Fact]
        public void Test_ITraktMostPWCShowObjectJsonReader_ReadObject_From_Json_String_Empty()
        {
            var jsonReader = new ITraktMostPWCShowObjectJsonReader();

            var traktMostPWCShow = jsonReader.ReadObject(string.Empty);
            traktMostPWCShow.Should().BeNull();
        }

        [Fact]
        public void Test_ITraktMostPWCShowObjectJsonReader_ReadObject_From_JsonReader_Complete()
        {
            var traktJsonReader = new ITraktMostPWCShowObjectJsonReader();

            using (var reader = new StringReader(JSON_COMPLETE))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMostPWCShow = traktJsonReader.ReadObject(jsonReader);

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
        public void Test_ITraktMostPWCShowObjectJsonReader_ReadObject_From_JsonReader_Incomplete_1()
        {
            var traktJsonReader = new ITraktMostPWCShowObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMostPWCShow = traktJsonReader.ReadObject(jsonReader);

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
        public void Test_ITraktMostPWCShowObjectJsonReader_ReadObject_From_JsonReader_Incomplete_2()
        {
            var traktJsonReader = new ITraktMostPWCShowObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMostPWCShow = traktJsonReader.ReadObject(jsonReader);

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
        public void Test_ITraktMostPWCShowObjectJsonReader_ReadObject_From_JsonReader_Incomplete_3()
        {
            var traktJsonReader = new ITraktMostPWCShowObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMostPWCShow = traktJsonReader.ReadObject(jsonReader);

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
        public void Test_ITraktMostPWCShowObjectJsonReader_ReadObject_From_JsonReader_Incomplete_4()
        {
            var traktJsonReader = new ITraktMostPWCShowObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMostPWCShow = traktJsonReader.ReadObject(jsonReader);

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
        public void Test_ITraktMostPWCShowObjectJsonReader_ReadObject_From_JsonReader_Incomplete_5()
        {
            var traktJsonReader = new ITraktMostPWCShowObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_5))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMostPWCShow = traktJsonReader.ReadObject(jsonReader);

                traktMostPWCShow.Should().NotBeNull();
                traktMostPWCShow.WatcherCount.Should().Be(4992);
                traktMostPWCShow.PlayCount.Should().Be(7100);
                traktMostPWCShow.CollectedCount.Should().Be(1348);
                traktMostPWCShow.CollectorCount.Should().Be(7964);
                traktMostPWCShow.Show.Should().BeNull();
            }
        }

        [Fact]
        public void Test_ITraktMostPWCShowObjectJsonReader_ReadObject_From_JsonReader_Incomplete_6()
        {
            var traktJsonReader = new ITraktMostPWCShowObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_6))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMostPWCShow = traktJsonReader.ReadObject(jsonReader);

                traktMostPWCShow.Should().NotBeNull();
                traktMostPWCShow.WatcherCount.Should().Be(4992);
                traktMostPWCShow.PlayCount.Should().BeNull();
                traktMostPWCShow.CollectedCount.Should().BeNull();
                traktMostPWCShow.CollectorCount.Should().BeNull();
                traktMostPWCShow.Show.Should().BeNull();
            }
        }

        [Fact]
        public void Test_ITraktMostPWCShowObjectJsonReader_ReadObject_From_JsonReader_Incomplete_7()
        {
            var traktJsonReader = new ITraktMostPWCShowObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_7))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMostPWCShow = traktJsonReader.ReadObject(jsonReader);

                traktMostPWCShow.Should().NotBeNull();
                traktMostPWCShow.WatcherCount.Should().BeNull();
                traktMostPWCShow.PlayCount.Should().Be(7100);
                traktMostPWCShow.CollectedCount.Should().BeNull();
                traktMostPWCShow.CollectorCount.Should().BeNull();
                traktMostPWCShow.Show.Should().BeNull();
            }
        }

        [Fact]
        public void Test_ITraktMostPWCShowObjectJsonReader_ReadObject_From_JsonReader_Incomplete_8()
        {
            var traktJsonReader = new ITraktMostPWCShowObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_8))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMostPWCShow = traktJsonReader.ReadObject(jsonReader);

                traktMostPWCShow.Should().NotBeNull();
                traktMostPWCShow.WatcherCount.Should().BeNull();
                traktMostPWCShow.PlayCount.Should().BeNull();
                traktMostPWCShow.CollectedCount.Should().Be(1348);
                traktMostPWCShow.CollectorCount.Should().BeNull();
                traktMostPWCShow.Show.Should().BeNull();
            }
        }

        [Fact]
        public void Test_ITraktMostPWCShowObjectJsonReader_ReadObject_From_JsonReader_Incomplete_9()
        {
            var traktJsonReader = new ITraktMostPWCShowObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_9))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMostPWCShow = traktJsonReader.ReadObject(jsonReader);

                traktMostPWCShow.Should().NotBeNull();
                traktMostPWCShow.WatcherCount.Should().BeNull();
                traktMostPWCShow.PlayCount.Should().BeNull();
                traktMostPWCShow.CollectedCount.Should().BeNull();
                traktMostPWCShow.CollectorCount.Should().Be(7964);
                traktMostPWCShow.Show.Should().BeNull();
            }
        }

        [Fact]
        public void Test_ITraktMostPWCShowObjectJsonReader_ReadObject_From_JsonReader_Incomplete_10()
        {
            var traktJsonReader = new ITraktMostPWCShowObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_10))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMostPWCShow = traktJsonReader.ReadObject(jsonReader);

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
        public void Test_ITraktMostPWCShowObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_1()
        {
            var traktJsonReader = new ITraktMostPWCShowObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMostPWCShow = traktJsonReader.ReadObject(jsonReader);

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
        public void Test_ITraktMostPWCShowObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_2()
        {
            var traktJsonReader = new ITraktMostPWCShowObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMostPWCShow = traktJsonReader.ReadObject(jsonReader);

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
        public void Test_ITraktMostPWCShowObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_3()
        {
            var traktJsonReader = new ITraktMostPWCShowObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMostPWCShow = traktJsonReader.ReadObject(jsonReader);

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
        public void Test_ITraktMostPWCShowObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_4()
        {
            var traktJsonReader = new ITraktMostPWCShowObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMostPWCShow = traktJsonReader.ReadObject(jsonReader);

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
        public void Test_ITraktMostPWCShowObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_5()
        {
            var traktJsonReader = new ITraktMostPWCShowObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_5))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMostPWCShow = traktJsonReader.ReadObject(jsonReader);

                traktMostPWCShow.Should().NotBeNull();
                traktMostPWCShow.WatcherCount.Should().Be(4992);
                traktMostPWCShow.PlayCount.Should().Be(7100);
                traktMostPWCShow.CollectedCount.Should().Be(1348);
                traktMostPWCShow.CollectorCount.Should().Be(7964);
                traktMostPWCShow.Show.Should().BeNull();
            }
        }

        [Fact]
        public void Test_ITraktMostPWCShowObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_6()
        {
            var traktJsonReader = new ITraktMostPWCShowObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_6))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMostPWCShow = traktJsonReader.ReadObject(jsonReader);

                traktMostPWCShow.Should().NotBeNull();
                traktMostPWCShow.WatcherCount.Should().BeNull();
                traktMostPWCShow.PlayCount.Should().BeNull();
                traktMostPWCShow.CollectedCount.Should().BeNull();
                traktMostPWCShow.CollectorCount.Should().BeNull();
                traktMostPWCShow.Show.Should().BeNull();
            }
        }

        [Fact]
        public void Test_ITraktMostPWCShowObjectJsonReader_ReadObject_From_JsonReader_Null()
        {
            var jsonReader = new ITraktMostPWCShowObjectJsonReader();

            var traktMostPWCShow = jsonReader.ReadObject(default(JsonTextReader));
            traktMostPWCShow.Should().BeNull();
        }

        [Fact]
        public void Test_ITraktMostPWCShowObjectJsonReader_ReadObject_From_JsonReader_Empty()
        {
            var traktJsonReader = new ITraktMostPWCShowObjectJsonReader();

            using (var reader = new StringReader(string.Empty))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMostPWCShow = traktJsonReader.ReadObject(jsonReader);
                traktMostPWCShow.Should().BeNull();
            }
        }

        private const string JSON_COMPLETE =
            @"{
                ""watcher_count"": 4992,
                ""play_count"": 7100,
                ""collected_count"": 1348,
                ""collector_count"": 7964,
                ""show"": {
                  ""title"": ""Game of Thrones"",
                  ""year"": 2011,
                  ""ids"": {
                    ""trakt"": 1390,
                    ""slug"": ""game-of-thrones"",
                    ""tvdb"": 121361,
                    ""imdb"": ""tt0944947"",
                    ""tmdb"": 1399,
                    ""tvrage"": 24493
                  }
                }
              }";

        private const string JSON_INCOMPLETE_1 =
            @"{
                ""play_count"": 7100,
                ""collected_count"": 1348,
                ""collector_count"": 7964,
                ""show"": {
                  ""title"": ""Game of Thrones"",
                  ""year"": 2011,
                  ""ids"": {
                    ""trakt"": 1390,
                    ""slug"": ""game-of-thrones"",
                    ""tvdb"": 121361,
                    ""imdb"": ""tt0944947"",
                    ""tmdb"": 1399,
                    ""tvrage"": 24493
                  }
                }
              }";

        private const string JSON_INCOMPLETE_2 =
            @"{
                ""watcher_count"": 4992,
                ""collected_count"": 1348,
                ""collector_count"": 7964,
                ""show"": {
                  ""title"": ""Game of Thrones"",
                  ""year"": 2011,
                  ""ids"": {
                    ""trakt"": 1390,
                    ""slug"": ""game-of-thrones"",
                    ""tvdb"": 121361,
                    ""imdb"": ""tt0944947"",
                    ""tmdb"": 1399,
                    ""tvrage"": 24493
                  }
                }
              }";

        private const string JSON_INCOMPLETE_3 =
            @"{
                ""watcher_count"": 4992,
                ""play_count"": 7100,
                ""collector_count"": 7964,
                ""show"": {
                  ""title"": ""Game of Thrones"",
                  ""year"": 2011,
                  ""ids"": {
                    ""trakt"": 1390,
                    ""slug"": ""game-of-thrones"",
                    ""tvdb"": 121361,
                    ""imdb"": ""tt0944947"",
                    ""tmdb"": 1399,
                    ""tvrage"": 24493
                  }
                }
              }";

        private const string JSON_INCOMPLETE_4 =
            @"{
                ""watcher_count"": 4992,
                ""play_count"": 7100,
                ""collected_count"": 1348,
                ""show"": {
                  ""title"": ""Game of Thrones"",
                  ""year"": 2011,
                  ""ids"": {
                    ""trakt"": 1390,
                    ""slug"": ""game-of-thrones"",
                    ""tvdb"": 121361,
                    ""imdb"": ""tt0944947"",
                    ""tmdb"": 1399,
                    ""tvrage"": 24493
                  }
                }
              }";

        private const string JSON_INCOMPLETE_5 =
            @"{
                ""watcher_count"": 4992,
                ""play_count"": 7100,
                ""collected_count"": 1348,
                ""collector_count"": 7964
              }";

        private const string JSON_INCOMPLETE_6 =
            @"{
                ""watcher_count"": 4992
              }";

        private const string JSON_INCOMPLETE_7 =
            @"{
                ""play_count"": 7100
              }";

        private const string JSON_INCOMPLETE_8 =
            @"{
                ""collected_count"": 1348
              }";

        private const string JSON_INCOMPLETE_9 =
            @"{
                ""collector_count"": 7964
              }";

        private const string JSON_INCOMPLETE_10 =
            @"{
                ""show"": {
                  ""title"": ""Game of Thrones"",
                  ""year"": 2011,
                  ""ids"": {
                    ""trakt"": 1390,
                    ""slug"": ""game-of-thrones"",
                    ""tvdb"": 121361,
                    ""imdb"": ""tt0944947"",
                    ""tmdb"": 1399,
                    ""tvrage"": 24493
                  }
                }
              }";

        private const string JSON_NOT_VALID_1 =
            @"{
                ""wc"": 4992,
                ""play_count"": 7100,
                ""collected_count"": 1348,
                ""collector_count"": 7964,
                ""show"": {
                  ""title"": ""Game of Thrones"",
                  ""year"": 2011,
                  ""ids"": {
                    ""trakt"": 1390,
                    ""slug"": ""game-of-thrones"",
                    ""tvdb"": 121361,
                    ""imdb"": ""tt0944947"",
                    ""tmdb"": 1399,
                    ""tvrage"": 24493
                  }
                }
              }";

        private const string JSON_NOT_VALID_2 =
            @"{
                ""watcher_count"": 4992,
                ""pc"": 7100,
                ""collected_count"": 1348,
                ""collector_count"": 7964,
                ""show"": {
                  ""title"": ""Game of Thrones"",
                  ""year"": 2011,
                  ""ids"": {
                    ""trakt"": 1390,
                    ""slug"": ""game-of-thrones"",
                    ""tvdb"": 121361,
                    ""imdb"": ""tt0944947"",
                    ""tmdb"": 1399,
                    ""tvrage"": 24493
                  }
                }
              }";

        private const string JSON_NOT_VALID_3 =
            @"{
                ""watcher_count"": 4992,
                ""play_count"": 7100,
                ""cdc"": 1348,
                ""collector_count"": 7964,
                ""show"": {
                  ""title"": ""Game of Thrones"",
                  ""year"": 2011,
                  ""ids"": {
                    ""trakt"": 1390,
                    ""slug"": ""game-of-thrones"",
                    ""tvdb"": 121361,
                    ""imdb"": ""tt0944947"",
                    ""tmdb"": 1399,
                    ""tvrage"": 24493
                  }
                }
              }";

        private const string JSON_NOT_VALID_4 =
            @"{
                ""watcher_count"": 4992,
                ""play_count"": 7100,
                ""collected_count"": 1348,
                ""crc"": 7964,
                ""show"": {
                  ""title"": ""Game of Thrones"",
                  ""year"": 2011,
                  ""ids"": {
                    ""trakt"": 1390,
                    ""slug"": ""game-of-thrones"",
                    ""tvdb"": 121361,
                    ""imdb"": ""tt0944947"",
                    ""tmdb"": 1399,
                    ""tvrage"": 24493
                  }
                }
              }";

        private const string JSON_NOT_VALID_5 =
            @"{
                ""watcher_count"": 4992,
                ""play_count"": 7100,
                ""collected_count"": 1348,
                ""collector_count"": 7964,
                ""sh"": {
                  ""title"": ""Game of Thrones"",
                  ""year"": 2011,
                  ""ids"": {
                    ""trakt"": 1390,
                    ""slug"": ""game-of-thrones"",
                    ""tvdb"": 121361,
                    ""imdb"": ""tt0944947"",
                    ""tmdb"": 1399,
                    ""tvrage"": 24493
                  }
                }
              }";

        private const string JSON_NOT_VALID_6 =
            @"{
                ""wc"": 4992,
                ""pc"": 7100,
                ""cdc"": 1348,
                ""crc"": 7964,
                ""sh"": {
                  ""title"": ""Game of Thrones"",
                  ""year"": 2011,
                  ""ids"": {
                    ""trakt"": 1390,
                    ""slug"": ""game-of-thrones"",
                    ""tvdb"": 121361,
                    ""imdb"": ""tt0944947"",
                    ""tmdb"": 1399,
                    ""tvrage"": 24493
                  }
                }
              }";
    }
}

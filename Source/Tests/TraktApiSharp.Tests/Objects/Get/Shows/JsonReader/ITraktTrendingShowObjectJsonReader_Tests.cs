namespace TraktApiSharp.Tests.Objects.Get.Shows.JsonReader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System.IO;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Objects.Get.Shows;
    using TraktApiSharp.Objects.Get.Shows.JsonReader;
    using TraktApiSharp.Objects.JsonReader;
    using Xunit;

    [Category("Objects.Get.Shows.JsonReader")]
    public class ITraktTrendingShowObjectJsonReader_Tests
    {
        [Fact]
        public void Test_ITraktTrendingShowObjectJsonReader_Implements_ITraktObjectJsonReader_Interface()
        {
            typeof(ITraktTrendingShowObjectJsonReader).GetInterfaces().Should().Contain(typeof(ITraktObjectJsonReader<ITraktTrendingShow>));
        }

        [Fact]
        public async Task Test_ITraktTrendingShowObjectJsonReader_ReadObject_From_Json_String_Complete()
        {
            var jsonReader = new ITraktTrendingShowObjectJsonReader();

            var traktTrendingShow = await jsonReader.ReadObjectAsync(JSON_COMPLETE);

            traktTrendingShow.Should().NotBeNull();
            traktTrendingShow.Watchers.Should().Be(35);
            traktTrendingShow.Show.Should().NotBeNull();
            traktTrendingShow.Show.Title.Should().Be("Game of Thrones");
            traktTrendingShow.Show.Year.Should().Be(2011);
            traktTrendingShow.Show.Ids.Should().NotBeNull();
            traktTrendingShow.Show.Ids.Trakt.Should().Be(1390U);
            traktTrendingShow.Show.Ids.Slug.Should().Be("game-of-thrones");
            traktTrendingShow.Show.Ids.Tvdb.Should().Be(121361U);
            traktTrendingShow.Show.Ids.Imdb.Should().Be("tt0944947");
            traktTrendingShow.Show.Ids.Tmdb.Should().Be(1399U);
            traktTrendingShow.Show.Ids.TvRage.Should().Be(24493U);
        }

        [Fact]
        public async Task Test_ITraktTrendingShowObjectJsonReader_ReadObject_From_Json_String_Incomplete_1()
        {
            var jsonReader = new ITraktTrendingShowObjectJsonReader();

            var traktTrendingShow = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_1);

            traktTrendingShow.Should().NotBeNull();
            traktTrendingShow.Watchers.Should().Be(35);
            traktTrendingShow.Show.Should().BeNull();
        }

        [Fact]
        public async Task Test_ITraktTrendingShowObjectJsonReader_ReadObject_From_Json_String_Incomplete_2()
        {
            var jsonReader = new ITraktTrendingShowObjectJsonReader();

            var traktTrendingShow = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_2);

            traktTrendingShow.Should().NotBeNull();
            traktTrendingShow.Watchers.Should().BeNull();
            traktTrendingShow.Show.Should().NotBeNull();
            traktTrendingShow.Show.Title.Should().Be("Game of Thrones");
            traktTrendingShow.Show.Year.Should().Be(2011);
            traktTrendingShow.Show.Ids.Should().NotBeNull();
            traktTrendingShow.Show.Ids.Trakt.Should().Be(1390U);
            traktTrendingShow.Show.Ids.Slug.Should().Be("game-of-thrones");
            traktTrendingShow.Show.Ids.Tvdb.Should().Be(121361U);
            traktTrendingShow.Show.Ids.Imdb.Should().Be("tt0944947");
            traktTrendingShow.Show.Ids.Tmdb.Should().Be(1399U);
            traktTrendingShow.Show.Ids.TvRage.Should().Be(24493U);
        }

        [Fact]
        public async Task Test_ITraktTrendingShowObjectJsonReader_ReadObject_From_Json_String_Not_Valid_1()
        {
            var jsonReader = new ITraktTrendingShowObjectJsonReader();

            var traktTrendingShow = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_1);

            traktTrendingShow.Should().NotBeNull();
            traktTrendingShow.Watchers.Should().BeNull();
            traktTrendingShow.Show.Should().NotBeNull();
            traktTrendingShow.Show.Title.Should().Be("Game of Thrones");
            traktTrendingShow.Show.Year.Should().Be(2011);
            traktTrendingShow.Show.Ids.Should().NotBeNull();
            traktTrendingShow.Show.Ids.Trakt.Should().Be(1390U);
            traktTrendingShow.Show.Ids.Slug.Should().Be("game-of-thrones");
            traktTrendingShow.Show.Ids.Tvdb.Should().Be(121361U);
            traktTrendingShow.Show.Ids.Imdb.Should().Be("tt0944947");
            traktTrendingShow.Show.Ids.Tmdb.Should().Be(1399U);
            traktTrendingShow.Show.Ids.TvRage.Should().Be(24493U);
        }

        [Fact]
        public async Task Test_ITraktTrendingShowObjectJsonReader_ReadObject_From_Json_String_Not_Valid_2()
        {
            var jsonReader = new ITraktTrendingShowObjectJsonReader();

            var traktTrendingShow = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_2);

            traktTrendingShow.Should().NotBeNull();
            traktTrendingShow.Watchers.Should().Be(35);
            traktTrendingShow.Show.Should().BeNull();
        }

        [Fact]
        public async Task Test_ITraktTrendingShowObjectJsonReader_ReadObject_From_Json_String_Not_Valid_3()
        {
            var jsonReader = new ITraktTrendingShowObjectJsonReader();

            var traktTrendingShow = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_3);

            traktTrendingShow.Should().NotBeNull();
            traktTrendingShow.Watchers.Should().BeNull();
            traktTrendingShow.Show.Should().BeNull();
        }

        [Fact]
        public async Task Test_ITraktTrendingShowObjectJsonReader_ReadObject_From_Json_String_Null()
        {
            var jsonReader = new ITraktTrendingShowObjectJsonReader();

            var traktTrendingShow = await jsonReader.ReadObjectAsync(default(string));
            traktTrendingShow.Should().BeNull();
        }

        [Fact]
        public async Task Test_ITraktTrendingShowObjectJsonReader_ReadObject_From_Json_String_Empty()
        {
            var jsonReader = new ITraktTrendingShowObjectJsonReader();

            var traktTrendingShow = await jsonReader.ReadObjectAsync(string.Empty);
            traktTrendingShow.Should().BeNull();
        }

        [Fact]
        public async Task Test_ITraktTrendingShowObjectJsonReader_ReadObject_From_JsonReader_Complete()
        {
            var traktJsonReader = new ITraktTrendingShowObjectJsonReader();

            using (var reader = new StringReader(JSON_COMPLETE))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktTrendingShow = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktTrendingShow.Should().NotBeNull();
                traktTrendingShow.Watchers.Should().Be(35);
                traktTrendingShow.Show.Should().NotBeNull();
                traktTrendingShow.Show.Title.Should().Be("Game of Thrones");
                traktTrendingShow.Show.Year.Should().Be(2011);
                traktTrendingShow.Show.Ids.Should().NotBeNull();
                traktTrendingShow.Show.Ids.Trakt.Should().Be(1390U);
                traktTrendingShow.Show.Ids.Slug.Should().Be("game-of-thrones");
                traktTrendingShow.Show.Ids.Tvdb.Should().Be(121361U);
                traktTrendingShow.Show.Ids.Imdb.Should().Be("tt0944947");
                traktTrendingShow.Show.Ids.Tmdb.Should().Be(1399U);
                traktTrendingShow.Show.Ids.TvRage.Should().Be(24493U);
            }
        }

        [Fact]
        public async Task Test_ITraktTrendingShowObjectJsonReader_ReadObject_From_JsonReader_Incomplete_1()
        {
            var traktJsonReader = new ITraktTrendingShowObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktTrendingShow = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktTrendingShow.Should().NotBeNull();
                traktTrendingShow.Watchers.Should().Be(35);
                traktTrendingShow.Show.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ITraktTrendingShowObjectJsonReader_ReadObject_From_JsonReader_Incomplete_2()
        {
            var traktJsonReader = new ITraktTrendingShowObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktTrendingShow = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktTrendingShow.Should().NotBeNull();
                traktTrendingShow.Watchers.Should().BeNull();
                traktTrendingShow.Show.Should().NotBeNull();
                traktTrendingShow.Show.Title.Should().Be("Game of Thrones");
                traktTrendingShow.Show.Year.Should().Be(2011);
                traktTrendingShow.Show.Ids.Should().NotBeNull();
                traktTrendingShow.Show.Ids.Trakt.Should().Be(1390U);
                traktTrendingShow.Show.Ids.Slug.Should().Be("game-of-thrones");
                traktTrendingShow.Show.Ids.Tvdb.Should().Be(121361U);
                traktTrendingShow.Show.Ids.Imdb.Should().Be("tt0944947");
                traktTrendingShow.Show.Ids.Tmdb.Should().Be(1399U);
                traktTrendingShow.Show.Ids.TvRage.Should().Be(24493U);
            }
        }

        [Fact]
        public async Task Test_ITraktTrendingShowObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_1()
        {
            var traktJsonReader = new ITraktTrendingShowObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktTrendingShow = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktTrendingShow.Should().NotBeNull();
                traktTrendingShow.Watchers.Should().BeNull();
                traktTrendingShow.Show.Should().NotBeNull();
                traktTrendingShow.Show.Title.Should().Be("Game of Thrones");
                traktTrendingShow.Show.Year.Should().Be(2011);
                traktTrendingShow.Show.Ids.Should().NotBeNull();
                traktTrendingShow.Show.Ids.Trakt.Should().Be(1390U);
                traktTrendingShow.Show.Ids.Slug.Should().Be("game-of-thrones");
                traktTrendingShow.Show.Ids.Tvdb.Should().Be(121361U);
                traktTrendingShow.Show.Ids.Imdb.Should().Be("tt0944947");
                traktTrendingShow.Show.Ids.Tmdb.Should().Be(1399U);
                traktTrendingShow.Show.Ids.TvRage.Should().Be(24493U);
            }
        }

        [Fact]
        public async Task Test_ITraktTrendingShowObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_2()
        {
            var traktJsonReader = new ITraktTrendingShowObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktTrendingShow = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktTrendingShow.Should().NotBeNull();
                traktTrendingShow.Watchers.Should().Be(35);
                traktTrendingShow.Show.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ITraktTrendingShowObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_3()
        {
            var traktJsonReader = new ITraktTrendingShowObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktTrendingShow = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktTrendingShow.Should().NotBeNull();
                traktTrendingShow.Watchers.Should().BeNull();
                traktTrendingShow.Show.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ITraktTrendingShowObjectJsonReader_ReadObject_From_JsonReader_Null()
        {
            var jsonReader = new ITraktTrendingShowObjectJsonReader();

            var traktTrendingShow = await jsonReader.ReadObjectAsync(default(JsonTextReader));
            traktTrendingShow.Should().BeNull();
        }

        [Fact]
        public async Task Test_ITraktTrendingShowObjectJsonReader_ReadObject_From_JsonReader_Empty()
        {
            var traktJsonReader = new ITraktTrendingShowObjectJsonReader();

            using (var reader = new StringReader(string.Empty))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktTrendingShow = await traktJsonReader.ReadObjectAsync(jsonReader);
                traktTrendingShow.Should().BeNull();
            }
        }

        private const string JSON_COMPLETE =
            @"{
                ""watchers"": 35,
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
                ""watchers"": 35
              }";

        private const string JSON_INCOMPLETE_2 =
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
                ""wa"": 35,
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
                ""watchers"": 35,
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

        private const string JSON_NOT_VALID_3 =
            @"{
                ""wa"": 35,
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

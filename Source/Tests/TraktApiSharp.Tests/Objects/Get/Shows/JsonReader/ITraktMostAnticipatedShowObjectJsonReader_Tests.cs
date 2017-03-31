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

    [Category("Objects.JsonReader.Get.Shows")]
    public class ITraktMostAnticipatedShowObjectJsonReader_Tests
    {
        [Fact]
        public void Test_ITraktMostAnticipatedShowObjectJsonReader_Implements_ITraktObjectJsonReader_Interface()
        {
            typeof(ITraktMostAnticipatedShowObjectJsonReader).GetInterfaces().Should().Contain(typeof(ITraktObjectJsonReader<ITraktMostAnticipatedShow>));
        }

        [Fact]
        public void Test_ITraktMostAnticipatedShowObjectJsonReader_ReadObject_From_Json_String_Complete()
        {
            var jsonReader = new ITraktMostAnticipatedShowObjectJsonReader();

            var traktMostAnticipatedShow = jsonReader.ReadObject(JSON_COMPLETE);

            traktMostAnticipatedShow.Should().NotBeNull();
            traktMostAnticipatedShow.ListCount.Should().Be(12805);
            traktMostAnticipatedShow.Show.Should().NotBeNull();
            traktMostAnticipatedShow.Show.Title.Should().Be("Game of Thrones");
            traktMostAnticipatedShow.Show.Year.Should().Be(2011);
            traktMostAnticipatedShow.Show.Ids.Should().NotBeNull();
            traktMostAnticipatedShow.Show.Ids.Trakt.Should().Be(1390U);
            traktMostAnticipatedShow.Show.Ids.Slug.Should().Be("game-of-thrones");
            traktMostAnticipatedShow.Show.Ids.Tvdb.Should().Be(121361U);
            traktMostAnticipatedShow.Show.Ids.Imdb.Should().Be("tt0944947");
            traktMostAnticipatedShow.Show.Ids.Tmdb.Should().Be(1399U);
            traktMostAnticipatedShow.Show.Ids.TvRage.Should().Be(24493U);
        }

        [Fact]
        public void Test_ITraktMostAnticipatedShowObjectJsonReader_ReadObject_From_Json_String_Incomplete_1()
        {
            var jsonReader = new ITraktMostAnticipatedShowObjectJsonReader();

            var traktMostAnticipatedShow = jsonReader.ReadObject(JSON_INCOMPLETE_1);

            traktMostAnticipatedShow.Should().NotBeNull();
            traktMostAnticipatedShow.ListCount.Should().Be(12805);
            traktMostAnticipatedShow.Show.Should().BeNull();
        }

        [Fact]
        public void Test_ITraktMostAnticipatedShowObjectJsonReader_ReadObject_From_Json_String_Incomplete_2()
        {
            var jsonReader = new ITraktMostAnticipatedShowObjectJsonReader();

            var traktMostAnticipatedShow = jsonReader.ReadObject(JSON_INCOMPLETE_2);

            traktMostAnticipatedShow.Should().NotBeNull();
            traktMostAnticipatedShow.ListCount.Should().BeNull();
            traktMostAnticipatedShow.Show.Should().NotBeNull();
            traktMostAnticipatedShow.Show.Title.Should().Be("Game of Thrones");
            traktMostAnticipatedShow.Show.Year.Should().Be(2011);
            traktMostAnticipatedShow.Show.Ids.Should().NotBeNull();
            traktMostAnticipatedShow.Show.Ids.Trakt.Should().Be(1390U);
            traktMostAnticipatedShow.Show.Ids.Slug.Should().Be("game-of-thrones");
            traktMostAnticipatedShow.Show.Ids.Tvdb.Should().Be(121361U);
            traktMostAnticipatedShow.Show.Ids.Imdb.Should().Be("tt0944947");
            traktMostAnticipatedShow.Show.Ids.Tmdb.Should().Be(1399U);
            traktMostAnticipatedShow.Show.Ids.TvRage.Should().Be(24493U);
        }

        [Fact]
        public void Test_ITraktMostAnticipatedShowObjectJsonReader_ReadObject_From_Json_String_Not_Valid_1()
        {
            var jsonReader = new ITraktMostAnticipatedShowObjectJsonReader();

            var traktMostAnticipatedShow = jsonReader.ReadObject(JSON_NOT_VALID_1);

            traktMostAnticipatedShow.Should().NotBeNull();
            traktMostAnticipatedShow.ListCount.Should().BeNull();
            traktMostAnticipatedShow.Show.Should().NotBeNull();
            traktMostAnticipatedShow.Show.Title.Should().Be("Game of Thrones");
            traktMostAnticipatedShow.Show.Year.Should().Be(2011);
            traktMostAnticipatedShow.Show.Ids.Should().NotBeNull();
            traktMostAnticipatedShow.Show.Ids.Trakt.Should().Be(1390U);
            traktMostAnticipatedShow.Show.Ids.Slug.Should().Be("game-of-thrones");
            traktMostAnticipatedShow.Show.Ids.Tvdb.Should().Be(121361U);
            traktMostAnticipatedShow.Show.Ids.Imdb.Should().Be("tt0944947");
            traktMostAnticipatedShow.Show.Ids.Tmdb.Should().Be(1399U);
            traktMostAnticipatedShow.Show.Ids.TvRage.Should().Be(24493U);
        }

        [Fact]
        public void Test_ITraktMostAnticipatedShowObjectJsonReader_ReadObject_From_Json_String_Not_Valid_2()
        {
            var jsonReader = new ITraktMostAnticipatedShowObjectJsonReader();

            var traktMostAnticipatedShow = jsonReader.ReadObject(JSON_NOT_VALID_2);

            traktMostAnticipatedShow.Should().NotBeNull();
            traktMostAnticipatedShow.ListCount.Should().Be(12805);
            traktMostAnticipatedShow.Show.Should().BeNull();
        }

        [Fact]
        public void Test_ITraktMostAnticipatedShowObjectJsonReader_ReadObject_From_Json_String_Not_Valid_3()
        {
            var jsonReader = new ITraktMostAnticipatedShowObjectJsonReader();

            var traktMostAnticipatedShow = jsonReader.ReadObject(JSON_NOT_VALID_3);

            traktMostAnticipatedShow.Should().NotBeNull();
            traktMostAnticipatedShow.ListCount.Should().BeNull();
            traktMostAnticipatedShow.Show.Should().BeNull();
        }

        [Fact]
        public void Test_ITraktMostAnticipatedShowObjectJsonReader_ReadObject_From_Json_String_Null()
        {
            var jsonReader = new ITraktMostAnticipatedShowObjectJsonReader();

            var traktMostAnticipatedShow = jsonReader.ReadObject(default(string));
            traktMostAnticipatedShow.Should().BeNull();
        }

        [Fact]
        public void Test_ITraktMostAnticipatedShowObjectJsonReader_ReadObject_From_Json_String_Empty()
        {
            var jsonReader = new ITraktMostAnticipatedShowObjectJsonReader();

            var traktMostAnticipatedShow = jsonReader.ReadObject(string.Empty);
            traktMostAnticipatedShow.Should().BeNull();
        }

        [Fact]
        public void Test_ITraktMostAnticipatedShowObjectJsonReader_ReadObject_From_JsonReader_Complete()
        {
            var traktJsonReader = new ITraktMostAnticipatedShowObjectJsonReader();

            using (var reader = new StringReader(JSON_COMPLETE))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMostAnticipatedShow = traktJsonReader.ReadObject(jsonReader);

                traktMostAnticipatedShow.Should().NotBeNull();
                traktMostAnticipatedShow.ListCount.Should().Be(12805);
                traktMostAnticipatedShow.Show.Should().NotBeNull();
                traktMostAnticipatedShow.Show.Title.Should().Be("Game of Thrones");
                traktMostAnticipatedShow.Show.Year.Should().Be(2011);
                traktMostAnticipatedShow.Show.Ids.Should().NotBeNull();
                traktMostAnticipatedShow.Show.Ids.Trakt.Should().Be(1390U);
                traktMostAnticipatedShow.Show.Ids.Slug.Should().Be("game-of-thrones");
                traktMostAnticipatedShow.Show.Ids.Tvdb.Should().Be(121361U);
                traktMostAnticipatedShow.Show.Ids.Imdb.Should().Be("tt0944947");
                traktMostAnticipatedShow.Show.Ids.Tmdb.Should().Be(1399U);
                traktMostAnticipatedShow.Show.Ids.TvRage.Should().Be(24493U);
            }
        }

        [Fact]
        public void Test_ITraktMostAnticipatedShowObjectJsonReader_ReadObject_From_JsonReader_Incomplete_1()
        {
            var traktJsonReader = new ITraktMostAnticipatedShowObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMostAnticipatedShow = traktJsonReader.ReadObject(jsonReader);

                traktMostAnticipatedShow.Should().NotBeNull();
                traktMostAnticipatedShow.ListCount.Should().Be(12805);
                traktMostAnticipatedShow.Show.Should().BeNull();
            }
        }

        [Fact]
        public void Test_ITraktMostAnticipatedShowObjectJsonReader_ReadObject_From_JsonReader_Incomplete_2()
        {
            var traktJsonReader = new ITraktMostAnticipatedShowObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMostAnticipatedShow = traktJsonReader.ReadObject(jsonReader);

                traktMostAnticipatedShow.Should().NotBeNull();
                traktMostAnticipatedShow.ListCount.Should().BeNull();
                traktMostAnticipatedShow.Show.Should().NotBeNull();
                traktMostAnticipatedShow.Show.Title.Should().Be("Game of Thrones");
                traktMostAnticipatedShow.Show.Year.Should().Be(2011);
                traktMostAnticipatedShow.Show.Ids.Should().NotBeNull();
                traktMostAnticipatedShow.Show.Ids.Trakt.Should().Be(1390U);
                traktMostAnticipatedShow.Show.Ids.Slug.Should().Be("game-of-thrones");
                traktMostAnticipatedShow.Show.Ids.Tvdb.Should().Be(121361U);
                traktMostAnticipatedShow.Show.Ids.Imdb.Should().Be("tt0944947");
                traktMostAnticipatedShow.Show.Ids.Tmdb.Should().Be(1399U);
                traktMostAnticipatedShow.Show.Ids.TvRage.Should().Be(24493U);
            }
        }

        [Fact]
        public void Test_ITraktMostAnticipatedShowObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_1()
        {
            var traktJsonReader = new ITraktMostAnticipatedShowObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMostAnticipatedShow = traktJsonReader.ReadObject(jsonReader);

                traktMostAnticipatedShow.Should().NotBeNull();
                traktMostAnticipatedShow.ListCount.Should().BeNull();
                traktMostAnticipatedShow.Show.Should().NotBeNull();
                traktMostAnticipatedShow.Show.Title.Should().Be("Game of Thrones");
                traktMostAnticipatedShow.Show.Year.Should().Be(2011);
                traktMostAnticipatedShow.Show.Ids.Should().NotBeNull();
                traktMostAnticipatedShow.Show.Ids.Trakt.Should().Be(1390U);
                traktMostAnticipatedShow.Show.Ids.Slug.Should().Be("game-of-thrones");
                traktMostAnticipatedShow.Show.Ids.Tvdb.Should().Be(121361U);
                traktMostAnticipatedShow.Show.Ids.Imdb.Should().Be("tt0944947");
                traktMostAnticipatedShow.Show.Ids.Tmdb.Should().Be(1399U);
                traktMostAnticipatedShow.Show.Ids.TvRage.Should().Be(24493U);
            }
        }

        [Fact]
        public void Test_ITraktMostAnticipatedShowObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_2()
        {
            var traktJsonReader = new ITraktMostAnticipatedShowObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMostAnticipatedShow = traktJsonReader.ReadObject(jsonReader);

                traktMostAnticipatedShow.Should().NotBeNull();
                traktMostAnticipatedShow.ListCount.Should().Be(12805);
                traktMostAnticipatedShow.Show.Should().BeNull();
            }
        }

        [Fact]
        public void Test_ITraktMostAnticipatedShowObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_3()
        {
            var traktJsonReader = new ITraktMostAnticipatedShowObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMostAnticipatedShow = traktJsonReader.ReadObject(jsonReader);

                traktMostAnticipatedShow.Should().NotBeNull();
                traktMostAnticipatedShow.ListCount.Should().BeNull();
                traktMostAnticipatedShow.Show.Should().BeNull();
            }
        }

        [Fact]
        public void Test_ITraktMostAnticipatedShowObjectJsonReader_ReadObject_From_JsonReader_Null()
        {
            var jsonReader = new ITraktMostAnticipatedShowObjectJsonReader();

            var traktMostAnticipatedShow = jsonReader.ReadObject(default(JsonTextReader));
            traktMostAnticipatedShow.Should().BeNull();
        }

        [Fact]
        public void Test_ITraktMostAnticipatedShowObjectJsonReader_ReadObject_From_JsonReader_Empty()
        {
            var traktJsonReader = new ITraktMostAnticipatedShowObjectJsonReader();

            using (var reader = new StringReader(string.Empty))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktMostAnticipatedShow = traktJsonReader.ReadObject(jsonReader);
                traktMostAnticipatedShow.Should().BeNull();
            }
        }

        private const string JSON_COMPLETE =
            @"{
                ""list_count"": 12805,
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
                ""list_count"": 12805
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
                ""lc"": 12805,
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
                ""list_count"": 12805,
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
                ""lc"": 12805,
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

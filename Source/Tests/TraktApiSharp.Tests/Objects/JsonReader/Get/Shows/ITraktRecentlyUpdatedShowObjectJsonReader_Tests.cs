namespace TraktApiSharp.Tests.Objects.JsonReader.Get.Shows
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using Traits;
    using TraktApiSharp.Objects.Get.Shows;
    using TraktApiSharp.Objects.JsonReader;
    using TraktApiSharp.Objects.JsonReader.Get.Shows;
    using Xunit;

    [Category("Objects.JsonReader.Get.Shows")]
    public class ITraktRecentlyUpdatedShowObjectJsonReader_Tests
    {
        [Fact]
        public void Test_ITraktRecentlyUpdatedShowObjectJsonReader_Implements_ITraktObjectJsonReader_Interface()
        {
            typeof(ITraktRecentlyUpdatedShowObjectJsonReader).GetInterfaces().Should().Contain(typeof(ITraktObjectJsonReader<ITraktRecentlyUpdatedShow>));
        }

        [Fact]
        public void Test_ITraktRecentlyUpdatedShowObjectJsonReader_ReadObject_From_Json_String_Complete()
        {
            var jsonReader = new ITraktRecentlyUpdatedShowObjectJsonReader();

            var traktRecentlyUpdatedShow = jsonReader.ReadObject(JSON_COMPLETE);

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
        public void Test_ITraktRecentlyUpdatedShowObjectJsonReader_ReadObject_From_Json_String_Incomplete_1()
        {
            var jsonReader = new ITraktRecentlyUpdatedShowObjectJsonReader();

            var traktRecentlyUpdatedShow = jsonReader.ReadObject(JSON_INCOMPLETE_1);

            traktRecentlyUpdatedShow.Should().NotBeNull();
            traktRecentlyUpdatedShow.RecentlyUpdatedAt.Should().Be(DateTime.Parse("2016-03-31T01:29:13Z").ToUniversalTime());
            traktRecentlyUpdatedShow.Show.Should().BeNull();
        }

        [Fact]
        public void Test_ITraktRecentlyUpdatedShowObjectJsonReader_ReadObject_From_Json_String_Incomplete_2()
        {
            var jsonReader = new ITraktRecentlyUpdatedShowObjectJsonReader();

            var traktRecentlyUpdatedShow = jsonReader.ReadObject(JSON_INCOMPLETE_2);

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
        public void Test_ITraktRecentlyUpdatedShowObjectJsonReader_ReadObject_From_Json_String_Not_Valid_1()
        {
            var jsonReader = new ITraktRecentlyUpdatedShowObjectJsonReader();

            var traktRecentlyUpdatedShow = jsonReader.ReadObject(JSON_NOT_VALID_1);

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
        public void Test_ITraktRecentlyUpdatedShowObjectJsonReader_ReadObject_From_Json_String_Not_Valid_2()
        {
            var jsonReader = new ITraktRecentlyUpdatedShowObjectJsonReader();

            var traktRecentlyUpdatedShow = jsonReader.ReadObject(JSON_NOT_VALID_2);

            traktRecentlyUpdatedShow.Should().NotBeNull();
            traktRecentlyUpdatedShow.RecentlyUpdatedAt.Should().Be(DateTime.Parse("2016-03-31T01:29:13Z").ToUniversalTime());
            traktRecentlyUpdatedShow.Show.Should().BeNull();
        }

        [Fact]
        public void Test_ITraktRecentlyUpdatedShowObjectJsonReader_ReadObject_From_Json_String_Not_Valid_3()
        {
            var jsonReader = new ITraktRecentlyUpdatedShowObjectJsonReader();

            var traktRecentlyUpdatedShow = jsonReader.ReadObject(JSON_NOT_VALID_3);

            traktRecentlyUpdatedShow.Should().NotBeNull();
            traktRecentlyUpdatedShow.RecentlyUpdatedAt.Should().BeNull();
            traktRecentlyUpdatedShow.Show.Should().BeNull();
        }

        [Fact]
        public void Test_ITraktRecentlyUpdatedShowObjectJsonReader_ReadObject_From_Json_String_Null()
        {
            var jsonReader = new ITraktRecentlyUpdatedShowObjectJsonReader();

            var traktRecentlyUpdatedShow = jsonReader.ReadObject(default(string));
            traktRecentlyUpdatedShow.Should().BeNull();
        }

        [Fact]
        public void Test_ITraktRecentlyUpdatedShowObjectJsonReader_ReadObject_From_Json_String_Empty()
        {
            var jsonReader = new ITraktRecentlyUpdatedShowObjectJsonReader();

            var traktRecentlyUpdatedShow = jsonReader.ReadObject(string.Empty);
            traktRecentlyUpdatedShow.Should().BeNull();
        }

        [Fact]
        public void Test_ITraktRecentlyUpdatedShowObjectJsonReader_ReadObject_From_JsonReader_Complete()
        {
            var traktJsonReader = new ITraktRecentlyUpdatedShowObjectJsonReader();

            using (var reader = new StringReader(JSON_COMPLETE))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktRecentlyUpdatedShow = traktJsonReader.ReadObject(jsonReader);

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
        public void Test_ITraktRecentlyUpdatedShowObjectJsonReader_ReadObject_From_JsonReader_Incomplete_1()
        {
            var traktJsonReader = new ITraktRecentlyUpdatedShowObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktRecentlyUpdatedShow = traktJsonReader.ReadObject(jsonReader);

                traktRecentlyUpdatedShow.Should().NotBeNull();
                traktRecentlyUpdatedShow.RecentlyUpdatedAt.Should().Be(DateTime.Parse("2016-03-31T01:29:13Z").ToUniversalTime());
                traktRecentlyUpdatedShow.Show.Should().BeNull();
            }
        }

        [Fact]
        public void Test_ITraktRecentlyUpdatedShowObjectJsonReader_ReadObject_From_JsonReader_Incomplete_2()
        {
            var traktJsonReader = new ITraktRecentlyUpdatedShowObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktRecentlyUpdatedShow = traktJsonReader.ReadObject(jsonReader);

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
        public void Test_ITraktRecentlyUpdatedShowObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_1()
        {
            var traktJsonReader = new ITraktRecentlyUpdatedShowObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktRecentlyUpdatedShow = traktJsonReader.ReadObject(jsonReader);

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
        public void Test_ITraktRecentlyUpdatedShowObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_2()
        {
            var traktJsonReader = new ITraktRecentlyUpdatedShowObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktRecentlyUpdatedShow = traktJsonReader.ReadObject(jsonReader);

                traktRecentlyUpdatedShow.Should().NotBeNull();
                traktRecentlyUpdatedShow.RecentlyUpdatedAt.Should().Be(DateTime.Parse("2016-03-31T01:29:13Z").ToUniversalTime());
                traktRecentlyUpdatedShow.Show.Should().BeNull();
            }
        }

        [Fact]
        public void Test_ITraktRecentlyUpdatedShowObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_3()
        {
            var traktJsonReader = new ITraktRecentlyUpdatedShowObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktRecentlyUpdatedShow = traktJsonReader.ReadObject(jsonReader);

                traktRecentlyUpdatedShow.Should().NotBeNull();
                traktRecentlyUpdatedShow.RecentlyUpdatedAt.Should().BeNull();
                traktRecentlyUpdatedShow.Show.Should().BeNull();
            }
        }

        [Fact]
        public void Test_ITraktRecentlyUpdatedShowObjectJsonReader_ReadObject_From_JsonReader_Null()
        {
            var jsonReader = new ITraktRecentlyUpdatedShowObjectJsonReader();

            var traktRecentlyUpdatedShow = jsonReader.ReadObject(default(JsonTextReader));
            traktRecentlyUpdatedShow.Should().BeNull();
        }

        [Fact]
        public void Test_ITraktRecentlyUpdatedShowObjectJsonReader_ReadObject_From_JsonReader_Empty()
        {
            var traktJsonReader = new ITraktRecentlyUpdatedShowObjectJsonReader();

            using (var reader = new StringReader(string.Empty))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktRecentlyUpdatedShow = traktJsonReader.ReadObject(jsonReader);
                traktRecentlyUpdatedShow.Should().BeNull();
            }
        }

        private const string JSON_COMPLETE =
            @"{
                ""updated_at"": ""2016-03-31T01:29:13Z"",
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
                ""updated_at"": ""2016-03-31T01:29:13Z""
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
                ""ua"": ""2016-03-31T01:29:13Z"",
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
                ""updated_at"": ""2016-03-31T01:29:13Z"",
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
                ""ua"": ""2016-03-31T01:29:13Z"",
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

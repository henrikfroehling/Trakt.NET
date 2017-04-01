namespace TraktApiSharp.Tests.Objects.Get.Episodes.JsonReader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using Traits;
    using TraktApiSharp.Objects.Get.Episodes;
    using TraktApiSharp.Objects.Get.Episodes.JsonReader;
    using TraktApiSharp.Objects.JsonReader;
    using Xunit;

    [Category("Objects.Get.Episodes.JsonReader")]
    public class ITraktEpisodeWatchedProgressObjectJsonReader_Tests
    {
        [Fact]
        public void Test_ITraktEpisodeWatchedProgressObjectJsonReader_Implements_ITraktObjectJsonReader_Interface()
        {
            typeof(ITraktEpisodeWatchedProgressObjectJsonReader).GetInterfaces().Should().Contain(typeof(ITraktObjectJsonReader<ITraktEpisodeWatchedProgress>));
        }

        [Fact]
        public void Test_ITraktEpisodeWatchedProgressObjectJsonReader_ReadObject_From_Json_String_Complete()
        {
            var jsonReader = new ITraktEpisodeWatchedProgressObjectJsonReader();

            var traktEpisodeWatchedProgress = jsonReader.ReadObject(JSON_COMPLETE);

            traktEpisodeWatchedProgress.Should().NotBeNull();
            traktEpisodeWatchedProgress.Number.Should().Be(2);
            traktEpisodeWatchedProgress.Completed.Should().BeTrue();
            traktEpisodeWatchedProgress.LastWatchedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());
        }

        [Fact]
        public void Test_ITraktEpisodeWatchedProgressObjectJsonReader_ReadObject_From_Json_String_Incomplete_1()
        {
            var jsonReader = new ITraktEpisodeWatchedProgressObjectJsonReader();

            var traktEpisodeWatchedProgress = jsonReader.ReadObject(JSON_INCOMPLETE_1);

            traktEpisodeWatchedProgress.Should().NotBeNull();
            traktEpisodeWatchedProgress.Number.Should().BeNull();
            traktEpisodeWatchedProgress.Completed.Should().BeTrue();
            traktEpisodeWatchedProgress.LastWatchedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());
        }

        [Fact]
        public void Test_ITraktEpisodeWatchedProgressObjectJsonReader_ReadObject_From_Json_String_Incomplete_2()
        {
            var jsonReader = new ITraktEpisodeWatchedProgressObjectJsonReader();

            var traktEpisodeWatchedProgress = jsonReader.ReadObject(JSON_INCOMPLETE_2);

            traktEpisodeWatchedProgress.Should().NotBeNull();
            traktEpisodeWatchedProgress.Number.Should().Be(2);
            traktEpisodeWatchedProgress.Completed.Should().BeNull();
            traktEpisodeWatchedProgress.LastWatchedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());
        }

        [Fact]
        public void Test_ITraktEpisodeWatchedProgressObjectJsonReader_ReadObject_From_Json_String_Incomplete_3()
        {
            var jsonReader = new ITraktEpisodeWatchedProgressObjectJsonReader();

            var traktEpisodeWatchedProgress = jsonReader.ReadObject(JSON_INCOMPLETE_3);

            traktEpisodeWatchedProgress.Should().NotBeNull();
            traktEpisodeWatchedProgress.Number.Should().Be(2);
            traktEpisodeWatchedProgress.Completed.Should().BeTrue();
            traktEpisodeWatchedProgress.LastWatchedAt.Should().BeNull();
        }

        [Fact]
        public void Test_ITraktEpisodeWatchedProgressObjectJsonReader_ReadObject_From_Json_String_Incomplete_4()
        {
            var jsonReader = new ITraktEpisodeWatchedProgressObjectJsonReader();

            var traktEpisodeWatchedProgress = jsonReader.ReadObject(JSON_INCOMPLETE_4);

            traktEpisodeWatchedProgress.Should().NotBeNull();
            traktEpisodeWatchedProgress.Number.Should().Be(2);
            traktEpisodeWatchedProgress.Completed.Should().BeNull();
            traktEpisodeWatchedProgress.LastWatchedAt.Should().BeNull();
        }

        [Fact]
        public void Test_ITraktEpisodeWatchedProgressObjectJsonReader_ReadObject_From_Json_String_Incomplete_5()
        {
            var jsonReader = new ITraktEpisodeWatchedProgressObjectJsonReader();

            var traktEpisodeWatchedProgress = jsonReader.ReadObject(JSON_INCOMPLETE_5);

            traktEpisodeWatchedProgress.Should().NotBeNull();
            traktEpisodeWatchedProgress.Number.Should().BeNull();
            traktEpisodeWatchedProgress.Completed.Should().BeTrue();
            traktEpisodeWatchedProgress.LastWatchedAt.Should().BeNull();
        }

        [Fact]
        public void Test_ITraktEpisodeWatchedProgressObjectJsonReader_ReadObject_From_Json_String_Incomplete_6()
        {
            var jsonReader = new ITraktEpisodeWatchedProgressObjectJsonReader();

            var traktEpisodeWatchedProgress = jsonReader.ReadObject(JSON_INCOMPLETE_6);

            traktEpisodeWatchedProgress.Should().NotBeNull();
            traktEpisodeWatchedProgress.Number.Should().BeNull();
            traktEpisodeWatchedProgress.Completed.Should().BeNull();
            traktEpisodeWatchedProgress.LastWatchedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());
        }

        [Fact]
        public void Test_ITraktEpisodeWatchedProgressObjectJsonReader_ReadObject_From_Json_String_Not_Valid_1()
        {
            var jsonReader = new ITraktEpisodeWatchedProgressObjectJsonReader();

            var traktEpisodeWatchedProgress = jsonReader.ReadObject(JSON_NOT_VALID_1);

            traktEpisodeWatchedProgress.Should().NotBeNull();
            traktEpisodeWatchedProgress.Number.Should().BeNull();
            traktEpisodeWatchedProgress.Completed.Should().BeTrue();
            traktEpisodeWatchedProgress.LastWatchedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());
        }

        [Fact]
        public void Test_ITraktEpisodeWatchedProgressObjectJsonReader_ReadObject_From_Json_String_Not_Valid_2()
        {
            var jsonReader = new ITraktEpisodeWatchedProgressObjectJsonReader();

            var traktEpisodeWatchedProgress = jsonReader.ReadObject(JSON_NOT_VALID_2);

            traktEpisodeWatchedProgress.Should().NotBeNull();
            traktEpisodeWatchedProgress.Number.Should().Be(2);
            traktEpisodeWatchedProgress.Completed.Should().BeNull();
            traktEpisodeWatchedProgress.LastWatchedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());
        }

        [Fact]
        public void Test_ITraktEpisodeWatchedProgressObjectJsonReader_ReadObject_From_Json_String_Not_Valid_3()
        {
            var jsonReader = new ITraktEpisodeWatchedProgressObjectJsonReader();

            var traktEpisodeWatchedProgress = jsonReader.ReadObject(JSON_NOT_VALID_3);

            traktEpisodeWatchedProgress.Should().NotBeNull();
            traktEpisodeWatchedProgress.Number.Should().Be(2);
            traktEpisodeWatchedProgress.Completed.Should().BeTrue();
            traktEpisodeWatchedProgress.LastWatchedAt.Should().BeNull();
        }

        [Fact]
        public void Test_ITraktEpisodeWatchedProgressObjectJsonReader_ReadObject_From_Json_String_Not_Valid_4()
        {
            var jsonReader = new ITraktEpisodeWatchedProgressObjectJsonReader();

            var traktEpisodeWatchedProgress = jsonReader.ReadObject(JSON_NOT_VALID_4);

            traktEpisodeWatchedProgress.Should().NotBeNull();
            traktEpisodeWatchedProgress.Number.Should().BeNull();
            traktEpisodeWatchedProgress.Completed.Should().BeNull();
            traktEpisodeWatchedProgress.LastWatchedAt.Should().BeNull();
        }

        [Fact]
        public void Test_ITraktEpisodeWatchedProgressObjectJsonReader_ReadObject_From_Json_String_Null()
        {
            var jsonReader = new ITraktEpisodeWatchedProgressObjectJsonReader();

            var traktEpisodeWatchedProgress = jsonReader.ReadObject(default(string));
            traktEpisodeWatchedProgress.Should().BeNull();
        }

        [Fact]
        public void Test_ITraktEpisodeWatchedProgressObjectJsonReader_ReadObject_From_Json_String_Empty()
        {
            var jsonReader = new ITraktEpisodeWatchedProgressObjectJsonReader();

            var traktEpisodeWatchedProgress = jsonReader.ReadObject(string.Empty);
            traktEpisodeWatchedProgress.Should().BeNull();
        }

        [Fact]
        public void Test_ITraktEpisodeWatchedProgressObjectJsonReader_ReadObject_From_JsonReader_Complete()
        {
            var traktJsonReader = new ITraktEpisodeWatchedProgressObjectJsonReader();

            using (var reader = new StringReader(JSON_COMPLETE))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisodeWatchedProgress = traktJsonReader.ReadObject(jsonReader);

                traktEpisodeWatchedProgress.Should().NotBeNull();
                traktEpisodeWatchedProgress.Number.Should().Be(2);
                traktEpisodeWatchedProgress.Completed.Should().BeTrue();
                traktEpisodeWatchedProgress.LastWatchedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());
            }
        }

        [Fact]
        public void Test_ITraktEpisodeWatchedProgressObjectJsonReader_ReadObject_From_JsonReader_Incomplete_1()
        {
            var traktJsonReader = new ITraktEpisodeWatchedProgressObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisodeWatchedProgress = traktJsonReader.ReadObject(jsonReader);

                traktEpisodeWatchedProgress.Should().NotBeNull();
                traktEpisodeWatchedProgress.Number.Should().BeNull();
                traktEpisodeWatchedProgress.Completed.Should().BeTrue();
                traktEpisodeWatchedProgress.LastWatchedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());
            }
        }

        [Fact]
        public void Test_ITraktEpisodeWatchedProgressObjectJsonReader_ReadObject_From_JsonReader_Incomplete_2()
        {
            var traktJsonReader = new ITraktEpisodeWatchedProgressObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisodeWatchedProgress = traktJsonReader.ReadObject(jsonReader);

                traktEpisodeWatchedProgress.Should().NotBeNull();
                traktEpisodeWatchedProgress.Number.Should().Be(2);
                traktEpisodeWatchedProgress.Completed.Should().BeNull();
                traktEpisodeWatchedProgress.LastWatchedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());
            }
        }

        [Fact]
        public void Test_ITraktEpisodeWatchedProgressObjectJsonReader_ReadObject_From_JsonReader_Incomplete_3()
        {
            var traktJsonReader = new ITraktEpisodeWatchedProgressObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisodeWatchedProgress = traktJsonReader.ReadObject(jsonReader);

                traktEpisodeWatchedProgress.Should().NotBeNull();
                traktEpisodeWatchedProgress.Number.Should().Be(2);
                traktEpisodeWatchedProgress.Completed.Should().BeTrue();
                traktEpisodeWatchedProgress.LastWatchedAt.Should().BeNull();
            }
        }

        [Fact]
        public void Test_ITraktEpisodeWatchedProgressObjectJsonReader_ReadObject_From_JsonReader_Incomplete_4()
        {
            var traktJsonReader = new ITraktEpisodeWatchedProgressObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisodeWatchedProgress = traktJsonReader.ReadObject(jsonReader);

                traktEpisodeWatchedProgress.Should().NotBeNull();
                traktEpisodeWatchedProgress.Number.Should().Be(2);
                traktEpisodeWatchedProgress.Completed.Should().BeNull();
                traktEpisodeWatchedProgress.LastWatchedAt.Should().BeNull();
            }
        }

        [Fact]
        public void Test_ITraktEpisodeWatchedProgressObjectJsonReader_ReadObject_From_JsonReader_Incomplete_5()
        {
            var traktJsonReader = new ITraktEpisodeWatchedProgressObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_5))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisodeWatchedProgress = traktJsonReader.ReadObject(jsonReader);

                traktEpisodeWatchedProgress.Should().NotBeNull();
                traktEpisodeWatchedProgress.Number.Should().BeNull();
                traktEpisodeWatchedProgress.Completed.Should().BeTrue();
                traktEpisodeWatchedProgress.LastWatchedAt.Should().BeNull();
            }
        }

        [Fact]
        public void Test_ITraktEpisodeWatchedProgressObjectJsonReader_ReadObject_From_JsonReader_Incomplete_6()
        {
            var traktJsonReader = new ITraktEpisodeWatchedProgressObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_6))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisodeWatchedProgress = traktJsonReader.ReadObject(jsonReader);

                traktEpisodeWatchedProgress.Should().NotBeNull();
                traktEpisodeWatchedProgress.Number.Should().BeNull();
                traktEpisodeWatchedProgress.Completed.Should().BeNull();
                traktEpisodeWatchedProgress.LastWatchedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());
            }
        }

        [Fact]
        public void Test_ITraktEpisodeWatchedProgressObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_1()
        {
            var traktJsonReader = new ITraktEpisodeWatchedProgressObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisodeWatchedProgress = traktJsonReader.ReadObject(jsonReader);

                traktEpisodeWatchedProgress.Should().NotBeNull();
                traktEpisodeWatchedProgress.Number.Should().BeNull();
                traktEpisodeWatchedProgress.Completed.Should().BeTrue();
                traktEpisodeWatchedProgress.LastWatchedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());
            }
        }

        [Fact]
        public void Test_ITraktEpisodeWatchedProgressObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_2()
        {
            var traktJsonReader = new ITraktEpisodeWatchedProgressObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisodeWatchedProgress = traktJsonReader.ReadObject(jsonReader);

                traktEpisodeWatchedProgress.Should().NotBeNull();
                traktEpisodeWatchedProgress.Number.Should().Be(2);
                traktEpisodeWatchedProgress.Completed.Should().BeNull();
                traktEpisodeWatchedProgress.LastWatchedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());
            }
        }

        [Fact]
        public void Test_ITraktEpisodeWatchedProgressObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_3()
        {
            var traktJsonReader = new ITraktEpisodeWatchedProgressObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisodeWatchedProgress = traktJsonReader.ReadObject(jsonReader);

                traktEpisodeWatchedProgress.Should().NotBeNull();
                traktEpisodeWatchedProgress.Number.Should().Be(2);
                traktEpisodeWatchedProgress.Completed.Should().BeTrue();
                traktEpisodeWatchedProgress.LastWatchedAt.Should().BeNull();
            }
        }

        [Fact]
        public void Test_ITraktEpisodeWatchedProgressObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_4()
        {
            var traktJsonReader = new ITraktEpisodeWatchedProgressObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisodeWatchedProgress = traktJsonReader.ReadObject(jsonReader);

                traktEpisodeWatchedProgress.Should().NotBeNull();
                traktEpisodeWatchedProgress.Number.Should().BeNull();
                traktEpisodeWatchedProgress.Completed.Should().BeNull();
                traktEpisodeWatchedProgress.LastWatchedAt.Should().BeNull();
            }
        }

        [Fact]
        public void Test_ITraktEpisodeWatchedProgressObjectJsonReader_ReadObject_From_JsonReader_Null()
        {
            var jsonReader = new ITraktEpisodeWatchedProgressObjectJsonReader();

            var traktEpisodeWatchedProgress = jsonReader.ReadObject(default(JsonTextReader));
            traktEpisodeWatchedProgress.Should().BeNull();
        }

        [Fact]
        public void Test_ITraktEpisodeWatchedProgressObjectJsonReader_ReadObject_From_JsonReader_Empty()
        {
            var traktJsonReader = new ITraktEpisodeWatchedProgressObjectJsonReader();

            using (var reader = new StringReader(string.Empty))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisodeWatchedProgress = traktJsonReader.ReadObject(jsonReader);
                traktEpisodeWatchedProgress.Should().BeNull();
            }
        }

        private const string JSON_COMPLETE =
            @"{
                ""number"": 2,
                ""completed"": true,
                ""last_watched_at"": ""2011-04-18T01:00:00.000Z""
              }";

        private const string JSON_INCOMPLETE_1 =
            @"{
                ""completed"": true,
                ""last_watched_at"": ""2011-04-18T01:00:00.000Z""
              }";

        private const string JSON_INCOMPLETE_2 =
            @"{
                ""number"": 2,
                ""last_watched_at"": ""2011-04-18T01:00:00.000Z""
              }";

        private const string JSON_INCOMPLETE_3 =
            @"{
                ""number"": 2,
                ""completed"": true
              }";

        private const string JSON_INCOMPLETE_4 =
            @"{
                ""number"": 2
              }";

        private const string JSON_INCOMPLETE_5 =
            @"{
                ""completed"": true
              }";

        private const string JSON_INCOMPLETE_6 =
            @"{
                ""last_watched_at"": ""2011-04-18T01:00:00.000Z""
              }";

        private const string JSON_NOT_VALID_1 =
            @"{
                ""n"": 2,
                ""completed"": true,
                ""last_watched_at"": ""2011-04-18T01:00:00.000Z""
              }";

        private const string JSON_NOT_VALID_2 =
            @"{
                ""number"": 2,
                ""co"": true,
                ""last_watched_at"": ""2011-04-18T01:00:00.000Z""
              }";

        private const string JSON_NOT_VALID_3 =
            @"{
                ""number"": 2,
                ""completed"": true,
                ""lw"": ""2011-04-18T01:00:00.000Z""
              }";

        private const string JSON_NOT_VALID_4 =
            @"{
                ""n"": 2,
                ""co"": true,
                ""lw"": ""2011-04-18T01:00:00.000Z""
              }";
    }
}

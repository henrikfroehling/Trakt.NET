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
    public class ITraktEpisodeCollectionProgressObjectJsonReader_Tests
    {
        [Fact]
        public void Test_ITraktEpisodeCollectionProgressObjectJsonReader_Implements_ITraktObjectJsonReader_Interface()
        {
            typeof(ITraktEpisodeCollectionProgressObjectJsonReader).GetInterfaces().Should().Contain(typeof(ITraktObjectJsonReader<ITraktEpisodeCollectionProgress>));
        }

        [Fact]
        public void Test_ITraktEpisodeCollectionProgressObjectJsonReader_ReadObject_From_Json_String_Complete()
        {
            var jsonReader = new ITraktEpisodeCollectionProgressObjectJsonReader();

            var traktEpisodeCollectionProgress = jsonReader.ReadObject(JSON_COMPLETE);

            traktEpisodeCollectionProgress.Should().NotBeNull();
            traktEpisodeCollectionProgress.Number.Should().Be(2);
            traktEpisodeCollectionProgress.Completed.Should().BeTrue();
            traktEpisodeCollectionProgress.CollectedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());
        }

        [Fact]
        public void Test_ITraktEpisodeCollectionProgressObjectJsonReader_ReadObject_From_Json_String_Incomplete_1()
        {
            var jsonReader = new ITraktEpisodeCollectionProgressObjectJsonReader();

            var traktEpisodeCollectionProgress = jsonReader.ReadObject(JSON_INCOMPLETE_1);

            traktEpisodeCollectionProgress.Should().NotBeNull();
            traktEpisodeCollectionProgress.Number.Should().BeNull();
            traktEpisodeCollectionProgress.Completed.Should().BeTrue();
            traktEpisodeCollectionProgress.CollectedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());
        }

        [Fact]
        public void Test_ITraktEpisodeCollectionProgressObjectJsonReader_ReadObject_From_Json_String_Incomplete_2()
        {
            var jsonReader = new ITraktEpisodeCollectionProgressObjectJsonReader();

            var traktEpisodeCollectionProgress = jsonReader.ReadObject(JSON_INCOMPLETE_2);

            traktEpisodeCollectionProgress.Should().NotBeNull();
            traktEpisodeCollectionProgress.Number.Should().Be(2);
            traktEpisodeCollectionProgress.Completed.Should().BeNull();
            traktEpisodeCollectionProgress.CollectedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());
        }

        [Fact]
        public void Test_ITraktEpisodeCollectionProgressObjectJsonReader_ReadObject_From_Json_String_Incomplete_3()
        {
            var jsonReader = new ITraktEpisodeCollectionProgressObjectJsonReader();

            var traktEpisodeCollectionProgress = jsonReader.ReadObject(JSON_INCOMPLETE_3);

            traktEpisodeCollectionProgress.Should().NotBeNull();
            traktEpisodeCollectionProgress.Number.Should().Be(2);
            traktEpisodeCollectionProgress.Completed.Should().BeTrue();
            traktEpisodeCollectionProgress.CollectedAt.Should().BeNull();
        }

        [Fact]
        public void Test_ITraktEpisodeCollectionProgressObjectJsonReader_ReadObject_From_Json_String_Incomplete_4()
        {
            var jsonReader = new ITraktEpisodeCollectionProgressObjectJsonReader();

            var traktEpisodeCollectionProgress = jsonReader.ReadObject(JSON_INCOMPLETE_4);

            traktEpisodeCollectionProgress.Should().NotBeNull();
            traktEpisodeCollectionProgress.Number.Should().Be(2);
            traktEpisodeCollectionProgress.Completed.Should().BeNull();
            traktEpisodeCollectionProgress.CollectedAt.Should().BeNull();
        }

        [Fact]
        public void Test_ITraktEpisodeCollectionProgressObjectJsonReader_ReadObject_From_Json_String_Incomplete_5()
        {
            var jsonReader = new ITraktEpisodeCollectionProgressObjectJsonReader();

            var traktEpisodeCollectionProgress = jsonReader.ReadObject(JSON_INCOMPLETE_5);

            traktEpisodeCollectionProgress.Should().NotBeNull();
            traktEpisodeCollectionProgress.Number.Should().BeNull();
            traktEpisodeCollectionProgress.Completed.Should().BeTrue();
            traktEpisodeCollectionProgress.CollectedAt.Should().BeNull();
        }

        [Fact]
        public void Test_ITraktEpisodeCollectionProgressObjectJsonReader_ReadObject_From_Json_String_Incomplete_6()
        {
            var jsonReader = new ITraktEpisodeCollectionProgressObjectJsonReader();

            var traktEpisodeCollectionProgress = jsonReader.ReadObject(JSON_INCOMPLETE_6);

            traktEpisodeCollectionProgress.Should().NotBeNull();
            traktEpisodeCollectionProgress.Number.Should().BeNull();
            traktEpisodeCollectionProgress.Completed.Should().BeNull();
            traktEpisodeCollectionProgress.CollectedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());
        }

        [Fact]
        public void Test_ITraktEpisodeCollectionProgressObjectJsonReader_ReadObject_From_Json_String_Not_Valid_1()
        {
            var jsonReader = new ITraktEpisodeCollectionProgressObjectJsonReader();

            var traktEpisodeCollectionProgress = jsonReader.ReadObject(JSON_NOT_VALID_1);

            traktEpisodeCollectionProgress.Should().NotBeNull();
            traktEpisodeCollectionProgress.Number.Should().BeNull();
            traktEpisodeCollectionProgress.Completed.Should().BeTrue();
            traktEpisodeCollectionProgress.CollectedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());
        }

        [Fact]
        public void Test_ITraktEpisodeCollectionProgressObjectJsonReader_ReadObject_From_Json_String_Not_Valid_2()
        {
            var jsonReader = new ITraktEpisodeCollectionProgressObjectJsonReader();

            var traktEpisodeCollectionProgress = jsonReader.ReadObject(JSON_NOT_VALID_2);

            traktEpisodeCollectionProgress.Should().NotBeNull();
            traktEpisodeCollectionProgress.Number.Should().Be(2);
            traktEpisodeCollectionProgress.Completed.Should().BeNull();
            traktEpisodeCollectionProgress.CollectedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());
        }

        [Fact]
        public void Test_ITraktEpisodeCollectionProgressObjectJsonReader_ReadObject_From_Json_String_Not_Valid_3()
        {
            var jsonReader = new ITraktEpisodeCollectionProgressObjectJsonReader();

            var traktEpisodeCollectionProgress = jsonReader.ReadObject(JSON_NOT_VALID_3);

            traktEpisodeCollectionProgress.Should().NotBeNull();
            traktEpisodeCollectionProgress.Number.Should().Be(2);
            traktEpisodeCollectionProgress.Completed.Should().BeTrue();
            traktEpisodeCollectionProgress.CollectedAt.Should().BeNull();
        }

        [Fact]
        public void Test_ITraktEpisodeCollectionProgressObjectJsonReader_ReadObject_From_Json_String_Not_Valid_4()
        {
            var jsonReader = new ITraktEpisodeCollectionProgressObjectJsonReader();

            var traktEpisodeCollectionProgress = jsonReader.ReadObject(JSON_NOT_VALID_4);

            traktEpisodeCollectionProgress.Should().NotBeNull();
            traktEpisodeCollectionProgress.Number.Should().BeNull();
            traktEpisodeCollectionProgress.Completed.Should().BeNull();
            traktEpisodeCollectionProgress.CollectedAt.Should().BeNull();
        }

        [Fact]
        public void Test_ITraktEpisodeCollectionProgressObjectJsonReader_ReadObject_From_Json_String_Null()
        {
            var jsonReader = new ITraktEpisodeCollectionProgressObjectJsonReader();

            var traktEpisodeCollectionProgress = jsonReader.ReadObject(default(string));
            traktEpisodeCollectionProgress.Should().BeNull();
        }

        [Fact]
        public void Test_ITraktEpisodeCollectionProgressObjectJsonReader_ReadObject_From_Json_String_Empty()
        {
            var jsonReader = new ITraktEpisodeCollectionProgressObjectJsonReader();

            var traktEpisodeCollectionProgress = jsonReader.ReadObject(string.Empty);
            traktEpisodeCollectionProgress.Should().BeNull();
        }

        [Fact]
        public void Test_ITraktEpisodeCollectionProgressObjectJsonReader_ReadObject_From_JsonReader_Complete()
        {
            var traktJsonReader = new ITraktEpisodeCollectionProgressObjectJsonReader();

            using (var reader = new StringReader(JSON_COMPLETE))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisodeCollectionProgress = traktJsonReader.ReadObject(jsonReader);

                traktEpisodeCollectionProgress.Should().NotBeNull();
                traktEpisodeCollectionProgress.Number.Should().Be(2);
                traktEpisodeCollectionProgress.Completed.Should().BeTrue();
                traktEpisodeCollectionProgress.CollectedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());
            }
        }

        [Fact]
        public void Test_ITraktEpisodeCollectionProgressObjectJsonReader_ReadObject_From_JsonReader_Incomplete_1()
        {
            var traktJsonReader = new ITraktEpisodeCollectionProgressObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisodeCollectionProgress = traktJsonReader.ReadObject(jsonReader);

                traktEpisodeCollectionProgress.Should().NotBeNull();
                traktEpisodeCollectionProgress.Number.Should().BeNull();
                traktEpisodeCollectionProgress.Completed.Should().BeTrue();
                traktEpisodeCollectionProgress.CollectedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());
            }
        }

        [Fact]
        public void Test_ITraktEpisodeCollectionProgressObjectJsonReader_ReadObject_From_JsonReader_Incomplete_2()
        {
            var traktJsonReader = new ITraktEpisodeCollectionProgressObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisodeCollectionProgress = traktJsonReader.ReadObject(jsonReader);

                traktEpisodeCollectionProgress.Should().NotBeNull();
                traktEpisodeCollectionProgress.Number.Should().Be(2);
                traktEpisodeCollectionProgress.Completed.Should().BeNull();
                traktEpisodeCollectionProgress.CollectedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());
            }
        }

        [Fact]
        public void Test_ITraktEpisodeCollectionProgressObjectJsonReader_ReadObject_From_JsonReader_Incomplete_3()
        {
            var traktJsonReader = new ITraktEpisodeCollectionProgressObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisodeCollectionProgress = traktJsonReader.ReadObject(jsonReader);

                traktEpisodeCollectionProgress.Should().NotBeNull();
                traktEpisodeCollectionProgress.Number.Should().Be(2);
                traktEpisodeCollectionProgress.Completed.Should().BeTrue();
                traktEpisodeCollectionProgress.CollectedAt.Should().BeNull();
            }
        }

        [Fact]
        public void Test_ITraktEpisodeCollectionProgressObjectJsonReader_ReadObject_From_JsonReader_Incomplete_4()
        {
            var traktJsonReader = new ITraktEpisodeCollectionProgressObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisodeCollectionProgress = traktJsonReader.ReadObject(jsonReader);

                traktEpisodeCollectionProgress.Should().NotBeNull();
                traktEpisodeCollectionProgress.Number.Should().Be(2);
                traktEpisodeCollectionProgress.Completed.Should().BeNull();
                traktEpisodeCollectionProgress.CollectedAt.Should().BeNull();
            }
        }

        [Fact]
        public void Test_ITraktEpisodeCollectionProgressObjectJsonReader_ReadObject_From_JsonReader_Incomplete_5()
        {
            var traktJsonReader = new ITraktEpisodeCollectionProgressObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_5))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisodeCollectionProgress = traktJsonReader.ReadObject(jsonReader);

                traktEpisodeCollectionProgress.Should().NotBeNull();
                traktEpisodeCollectionProgress.Number.Should().BeNull();
                traktEpisodeCollectionProgress.Completed.Should().BeTrue();
                traktEpisodeCollectionProgress.CollectedAt.Should().BeNull();
            }
        }

        [Fact]
        public void Test_ITraktEpisodeCollectionProgressObjectJsonReader_ReadObject_From_JsonReader_Incomplete_6()
        {
            var traktJsonReader = new ITraktEpisodeCollectionProgressObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_6))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisodeCollectionProgress = traktJsonReader.ReadObject(jsonReader);

                traktEpisodeCollectionProgress.Should().NotBeNull();
                traktEpisodeCollectionProgress.Number.Should().BeNull();
                traktEpisodeCollectionProgress.Completed.Should().BeNull();
                traktEpisodeCollectionProgress.CollectedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());
            }
        }

        [Fact]
        public void Test_ITraktEpisodeCollectionProgressObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_1()
        {
            var traktJsonReader = new ITraktEpisodeCollectionProgressObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisodeCollectionProgress = traktJsonReader.ReadObject(jsonReader);

                traktEpisodeCollectionProgress.Should().NotBeNull();
                traktEpisodeCollectionProgress.Number.Should().BeNull();
                traktEpisodeCollectionProgress.Completed.Should().BeTrue();
                traktEpisodeCollectionProgress.CollectedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());
            }
        }

        [Fact]
        public void Test_ITraktEpisodeCollectionProgressObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_2()
        {
            var traktJsonReader = new ITraktEpisodeCollectionProgressObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisodeCollectionProgress = traktJsonReader.ReadObject(jsonReader);

                traktEpisodeCollectionProgress.Should().NotBeNull();
                traktEpisodeCollectionProgress.Number.Should().Be(2);
                traktEpisodeCollectionProgress.Completed.Should().BeNull();
                traktEpisodeCollectionProgress.CollectedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());
            }
        }

        [Fact]
        public void Test_ITraktEpisodeCollectionProgressObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_3()
        {
            var traktJsonReader = new ITraktEpisodeCollectionProgressObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisodeCollectionProgress = traktJsonReader.ReadObject(jsonReader);

                traktEpisodeCollectionProgress.Should().NotBeNull();
                traktEpisodeCollectionProgress.Number.Should().Be(2);
                traktEpisodeCollectionProgress.Completed.Should().BeTrue();
                traktEpisodeCollectionProgress.CollectedAt.Should().BeNull();
            }
        }

        [Fact]
        public void Test_ITraktEpisodeCollectionProgressObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_4()
        {
            var traktJsonReader = new ITraktEpisodeCollectionProgressObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisodeCollectionProgress = traktJsonReader.ReadObject(jsonReader);

                traktEpisodeCollectionProgress.Should().NotBeNull();
                traktEpisodeCollectionProgress.Number.Should().BeNull();
                traktEpisodeCollectionProgress.Completed.Should().BeNull();
                traktEpisodeCollectionProgress.CollectedAt.Should().BeNull();
            }
        }

        [Fact]
        public void Test_ITraktEpisodeCollectionProgressObjectJsonReader_ReadObject_From_JsonReader_Null()
        {
            var jsonReader = new ITraktEpisodeCollectionProgressObjectJsonReader();

            var traktEpisodeCollectionProgress = jsonReader.ReadObject(default(JsonTextReader));
            traktEpisodeCollectionProgress.Should().BeNull();
        }

        [Fact]
        public void Test_ITraktEpisodeCollectionProgressObjectJsonReader_ReadObject_From_JsonReader_Empty()
        {
            var traktJsonReader = new ITraktEpisodeCollectionProgressObjectJsonReader();

            using (var reader = new StringReader(string.Empty))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisodeCollectionProgress = traktJsonReader.ReadObject(jsonReader);
                traktEpisodeCollectionProgress.Should().BeNull();
            }
        }

        private const string JSON_COMPLETE =
            @"{
                ""number"": 2,
                ""completed"": true,
                ""collected_at"": ""2011-04-18T01:00:00.000Z""
              }";

        private const string JSON_INCOMPLETE_1 =
            @"{
                ""completed"": true,
                ""collected_at"": ""2011-04-18T01:00:00.000Z""
              }";

        private const string JSON_INCOMPLETE_2 =
            @"{
                ""number"": 2,
                ""collected_at"": ""2011-04-18T01:00:00.000Z""
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
                ""collected_at"": ""2011-04-18T01:00:00.000Z""
              }";

        private const string JSON_NOT_VALID_1 =
            @"{
                ""n"": 2,
                ""completed"": true,
                ""collected_at"": ""2011-04-18T01:00:00.000Z""
              }";

        private const string JSON_NOT_VALID_2 =
            @"{
                ""number"": 2,
                ""co"": true,
                ""collected_at"": ""2011-04-18T01:00:00.000Z""
              }";

        private const string JSON_NOT_VALID_3 =
            @"{
                ""number"": 2,
                ""completed"": true,
                ""cl"": ""2011-04-18T01:00:00.000Z""
              }";

        private const string JSON_NOT_VALID_4 =
            @"{
                ""n"": 2,
                ""co"": true,
                ""cl"": ""2011-04-18T01:00:00.000Z""
              }";
    }
}

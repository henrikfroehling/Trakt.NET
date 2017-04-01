namespace TraktApiSharp.Tests.Objects.Get.Seasons.JsonReader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Linq;
    using Traits;
    using TraktApiSharp.Objects.Get.Seasons;
    using TraktApiSharp.Objects.Get.Seasons.JsonReader;
    using TraktApiSharp.Objects.JsonReader;
    using Xunit;

    [Category("Objects.JsonReader.Get.Seasons")]
    public class ITraktSeasonCollectionProgressObjectJsonReader_Tests
    {
        [Fact]
        public void Test_ITraktSeasonCollectionProgressObjectJsonReader_Implements_ITraktObjectJsonReader_Interface()
        {
            typeof(ITraktSeasonCollectionProgressObjectJsonReader).GetInterfaces().Should().Contain(typeof(ITraktObjectJsonReader<ITraktSeasonCollectionProgress>));
        }

        [Fact]
        public void Test_ITraktSeasonCollectionProgressObjectJsonReader_ReadObject_From_Json_String_Complete()
        {
            var jsonReader = new ITraktSeasonCollectionProgressObjectJsonReader();

            var traktSeasonCollectionProgress = jsonReader.ReadObject(JSON_COMPLETE);

            traktSeasonCollectionProgress.Should().NotBeNull();
            traktSeasonCollectionProgress.Number.Should().Be(2);
            traktSeasonCollectionProgress.Aired.Should().Be(3);
            traktSeasonCollectionProgress.Completed.Should().Be(2);
            traktSeasonCollectionProgress.Episodes.Should().NotBeNull().And.HaveCount(2);

            var episodesCollectionProgress = traktSeasonCollectionProgress.Episodes.ToArray();

            episodesCollectionProgress[0].Should().NotBeNull();
            episodesCollectionProgress[0].Number.Should().Be(1);
            episodesCollectionProgress[0].Completed.Should().BeTrue();
            episodesCollectionProgress[0].CollectedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

            episodesCollectionProgress[1].Should().NotBeNull();
            episodesCollectionProgress[1].Number.Should().Be(2);
            episodesCollectionProgress[1].Completed.Should().BeTrue();
            episodesCollectionProgress[1].CollectedAt.Should().Be(DateTime.Parse("2011-04-19T02:00:00.000Z").ToUniversalTime());
        }

        [Fact]
        public void Test_ITraktSeasonCollectionProgressObjectJsonReader_ReadObject_From_Json_String_Incomplete_1()
        {
            var jsonReader = new ITraktSeasonCollectionProgressObjectJsonReader();

            var traktSeasonCollectionProgress = jsonReader.ReadObject(JSON_INCOMPLETE_1);

            traktSeasonCollectionProgress.Should().NotBeNull();
            traktSeasonCollectionProgress.Number.Should().BeNull();
            traktSeasonCollectionProgress.Aired.Should().Be(3);
            traktSeasonCollectionProgress.Completed.Should().Be(2);
            traktSeasonCollectionProgress.Episodes.Should().NotBeNull().And.HaveCount(2);

            var episodesCollectionProgress = traktSeasonCollectionProgress.Episodes.ToArray();

            episodesCollectionProgress[0].Should().NotBeNull();
            episodesCollectionProgress[0].Number.Should().Be(1);
            episodesCollectionProgress[0].Completed.Should().BeTrue();
            episodesCollectionProgress[0].CollectedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

            episodesCollectionProgress[1].Should().NotBeNull();
            episodesCollectionProgress[1].Number.Should().Be(2);
            episodesCollectionProgress[1].Completed.Should().BeTrue();
            episodesCollectionProgress[1].CollectedAt.Should().Be(DateTime.Parse("2011-04-19T02:00:00.000Z").ToUniversalTime());
        }

        [Fact]
        public void Test_ITraktSeasonCollectionProgressObjectJsonReader_ReadObject_From_Json_String_Incomplete_2()
        {
            var jsonReader = new ITraktSeasonCollectionProgressObjectJsonReader();

            var traktSeasonCollectionProgress = jsonReader.ReadObject(JSON_INCOMPLETE_2);

            traktSeasonCollectionProgress.Should().NotBeNull();
            traktSeasonCollectionProgress.Number.Should().Be(2);
            traktSeasonCollectionProgress.Aired.Should().BeNull();
            traktSeasonCollectionProgress.Completed.Should().Be(2);
            traktSeasonCollectionProgress.Episodes.Should().NotBeNull().And.HaveCount(2);

            var episodesCollectionProgress = traktSeasonCollectionProgress.Episodes.ToArray();

            episodesCollectionProgress[0].Should().NotBeNull();
            episodesCollectionProgress[0].Number.Should().Be(1);
            episodesCollectionProgress[0].Completed.Should().BeTrue();
            episodesCollectionProgress[0].CollectedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

            episodesCollectionProgress[1].Should().NotBeNull();
            episodesCollectionProgress[1].Number.Should().Be(2);
            episodesCollectionProgress[1].Completed.Should().BeTrue();
            episodesCollectionProgress[1].CollectedAt.Should().Be(DateTime.Parse("2011-04-19T02:00:00.000Z").ToUniversalTime());
        }

        [Fact]
        public void Test_ITraktSeasonCollectionProgressObjectJsonReader_ReadObject_From_Json_String_Incomplete_3()
        {
            var jsonReader = new ITraktSeasonCollectionProgressObjectJsonReader();

            var traktSeasonCollectionProgress = jsonReader.ReadObject(JSON_INCOMPLETE_3);

            traktSeasonCollectionProgress.Should().NotBeNull();
            traktSeasonCollectionProgress.Number.Should().Be(2);
            traktSeasonCollectionProgress.Aired.Should().Be(3);
            traktSeasonCollectionProgress.Completed.Should().BeNull();
            traktSeasonCollectionProgress.Episodes.Should().NotBeNull().And.HaveCount(2);

            var episodesCollectionProgress = traktSeasonCollectionProgress.Episodes.ToArray();

            episodesCollectionProgress[0].Should().NotBeNull();
            episodesCollectionProgress[0].Number.Should().Be(1);
            episodesCollectionProgress[0].Completed.Should().BeTrue();
            episodesCollectionProgress[0].CollectedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

            episodesCollectionProgress[1].Should().NotBeNull();
            episodesCollectionProgress[1].Number.Should().Be(2);
            episodesCollectionProgress[1].Completed.Should().BeTrue();
            episodesCollectionProgress[1].CollectedAt.Should().Be(DateTime.Parse("2011-04-19T02:00:00.000Z").ToUniversalTime());
        }

        [Fact]
        public void Test_ITraktSeasonCollectionProgressObjectJsonReader_ReadObject_From_Json_String_Incomplete_4()
        {
            var jsonReader = new ITraktSeasonCollectionProgressObjectJsonReader();

            var traktSeasonCollectionProgress = jsonReader.ReadObject(JSON_INCOMPLETE_4);

            traktSeasonCollectionProgress.Should().NotBeNull();
            traktSeasonCollectionProgress.Number.Should().Be(2);
            traktSeasonCollectionProgress.Aired.Should().Be(3);
            traktSeasonCollectionProgress.Completed.Should().Be(2);
            traktSeasonCollectionProgress.Episodes.Should().BeNull();
        }

        [Fact]
        public void Test_ITraktSeasonCollectionProgressObjectJsonReader_ReadObject_From_Json_String_Incomplete_5()
        {
            var jsonReader = new ITraktSeasonCollectionProgressObjectJsonReader();

            var traktSeasonCollectionProgress = jsonReader.ReadObject(JSON_INCOMPLETE_5);

            traktSeasonCollectionProgress.Should().NotBeNull();
            traktSeasonCollectionProgress.Number.Should().Be(2);
            traktSeasonCollectionProgress.Aired.Should().BeNull();
            traktSeasonCollectionProgress.Completed.Should().BeNull();
            traktSeasonCollectionProgress.Episodes.Should().BeNull();
        }

        [Fact]
        public void Test_ITraktSeasonCollectionProgressObjectJsonReader_ReadObject_From_Json_String_Incomplete_6()
        {
            var jsonReader = new ITraktSeasonCollectionProgressObjectJsonReader();

            var traktSeasonCollectionProgress = jsonReader.ReadObject(JSON_INCOMPLETE_6);

            traktSeasonCollectionProgress.Should().NotBeNull();
            traktSeasonCollectionProgress.Number.Should().BeNull();
            traktSeasonCollectionProgress.Aired.Should().Be(3);
            traktSeasonCollectionProgress.Completed.Should().BeNull();
            traktSeasonCollectionProgress.Episodes.Should().BeNull();
        }

        [Fact]
        public void Test_ITraktSeasonCollectionProgressObjectJsonReader_ReadObject_From_Json_String_Incomplete_7()
        {
            var jsonReader = new ITraktSeasonCollectionProgressObjectJsonReader();

            var traktSeasonCollectionProgress = jsonReader.ReadObject(JSON_INCOMPLETE_7);

            traktSeasonCollectionProgress.Should().NotBeNull();
            traktSeasonCollectionProgress.Number.Should().BeNull();
            traktSeasonCollectionProgress.Aired.Should().BeNull();
            traktSeasonCollectionProgress.Completed.Should().Be(2);
            traktSeasonCollectionProgress.Episodes.Should().BeNull();
        }

        [Fact]
        public void Test_ITraktSeasonCollectionProgressObjectJsonReader_ReadObject_From_Json_String_Incomplete_8()
        {
            var jsonReader = new ITraktSeasonCollectionProgressObjectJsonReader();

            var traktSeasonCollectionProgress = jsonReader.ReadObject(JSON_INCOMPLETE_8);

            traktSeasonCollectionProgress.Should().NotBeNull();
            traktSeasonCollectionProgress.Number.Should().BeNull();
            traktSeasonCollectionProgress.Aired.Should().BeNull();
            traktSeasonCollectionProgress.Completed.Should().BeNull();
            traktSeasonCollectionProgress.Episodes.Should().NotBeNull().And.HaveCount(2);

            var episodesCollectionProgress = traktSeasonCollectionProgress.Episodes.ToArray();

            episodesCollectionProgress[0].Should().NotBeNull();
            episodesCollectionProgress[0].Number.Should().Be(1);
            episodesCollectionProgress[0].Completed.Should().BeTrue();
            episodesCollectionProgress[0].CollectedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

            episodesCollectionProgress[1].Should().NotBeNull();
            episodesCollectionProgress[1].Number.Should().Be(2);
            episodesCollectionProgress[1].Completed.Should().BeTrue();
            episodesCollectionProgress[1].CollectedAt.Should().Be(DateTime.Parse("2011-04-19T02:00:00.000Z").ToUniversalTime());
        }

        [Fact]
        public void Test_ITraktSeasonCollectionProgressObjectJsonReader_ReadObject_From_Json_String_Not_Valid_1()
        {
            var jsonReader = new ITraktSeasonCollectionProgressObjectJsonReader();

            var traktSeasonCollectionProgress = jsonReader.ReadObject(JSON_NOT_VALID_1);

            traktSeasonCollectionProgress.Should().NotBeNull();
            traktSeasonCollectionProgress.Number.Should().BeNull();
            traktSeasonCollectionProgress.Aired.Should().Be(3);
            traktSeasonCollectionProgress.Completed.Should().Be(2);
            traktSeasonCollectionProgress.Episodes.Should().NotBeNull().And.HaveCount(2);

            var episodesCollectionProgress = traktSeasonCollectionProgress.Episodes.ToArray();

            episodesCollectionProgress[0].Should().NotBeNull();
            episodesCollectionProgress[0].Number.Should().Be(1);
            episodesCollectionProgress[0].Completed.Should().BeTrue();
            episodesCollectionProgress[0].CollectedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

            episodesCollectionProgress[1].Should().NotBeNull();
            episodesCollectionProgress[1].Number.Should().Be(2);
            episodesCollectionProgress[1].Completed.Should().BeTrue();
            episodesCollectionProgress[1].CollectedAt.Should().Be(DateTime.Parse("2011-04-19T02:00:00.000Z").ToUniversalTime());
        }

        [Fact]
        public void Test_ITraktSeasonCollectionProgressObjectJsonReader_ReadObject_From_Json_String_Not_Valid_2()
        {
            var jsonReader = new ITraktSeasonCollectionProgressObjectJsonReader();

            var traktSeasonCollectionProgress = jsonReader.ReadObject(JSON_NOT_VALID_2);

            traktSeasonCollectionProgress.Should().NotBeNull();
            traktSeasonCollectionProgress.Number.Should().Be(2);
            traktSeasonCollectionProgress.Aired.Should().BeNull();
            traktSeasonCollectionProgress.Completed.Should().Be(2);
            traktSeasonCollectionProgress.Episodes.Should().NotBeNull().And.HaveCount(2);

            var episodesCollectionProgress = traktSeasonCollectionProgress.Episodes.ToArray();

            episodesCollectionProgress[0].Should().NotBeNull();
            episodesCollectionProgress[0].Number.Should().Be(1);
            episodesCollectionProgress[0].Completed.Should().BeTrue();
            episodesCollectionProgress[0].CollectedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

            episodesCollectionProgress[1].Should().NotBeNull();
            episodesCollectionProgress[1].Number.Should().Be(2);
            episodesCollectionProgress[1].Completed.Should().BeTrue();
            episodesCollectionProgress[1].CollectedAt.Should().Be(DateTime.Parse("2011-04-19T02:00:00.000Z").ToUniversalTime());
        }

        [Fact]
        public void Test_ITraktSeasonCollectionProgressObjectJsonReader_ReadObject_From_Json_String_Not_Valid_3()
        {
            var jsonReader = new ITraktSeasonCollectionProgressObjectJsonReader();

            var traktSeasonCollectionProgress = jsonReader.ReadObject(JSON_NOT_VALID_3);

            traktSeasonCollectionProgress.Should().NotBeNull();
            traktSeasonCollectionProgress.Number.Should().Be(2);
            traktSeasonCollectionProgress.Aired.Should().Be(3);
            traktSeasonCollectionProgress.Completed.Should().BeNull();
            traktSeasonCollectionProgress.Episodes.Should().NotBeNull().And.HaveCount(2);

            var episodesCollectionProgress = traktSeasonCollectionProgress.Episodes.ToArray();

            episodesCollectionProgress[0].Should().NotBeNull();
            episodesCollectionProgress[0].Number.Should().Be(1);
            episodesCollectionProgress[0].Completed.Should().BeTrue();
            episodesCollectionProgress[0].CollectedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

            episodesCollectionProgress[1].Should().NotBeNull();
            episodesCollectionProgress[1].Number.Should().Be(2);
            episodesCollectionProgress[1].Completed.Should().BeTrue();
            episodesCollectionProgress[1].CollectedAt.Should().Be(DateTime.Parse("2011-04-19T02:00:00.000Z").ToUniversalTime());
        }

        [Fact]
        public void Test_ITraktSeasonCollectionProgressObjectJsonReader_ReadObject_From_Json_String_Not_Valid_4()
        {
            var jsonReader = new ITraktSeasonCollectionProgressObjectJsonReader();

            var traktSeasonCollectionProgress = jsonReader.ReadObject(JSON_NOT_VALID_4);

            traktSeasonCollectionProgress.Should().NotBeNull();
            traktSeasonCollectionProgress.Number.Should().Be(2);
            traktSeasonCollectionProgress.Aired.Should().Be(3);
            traktSeasonCollectionProgress.Completed.Should().Be(2);
            traktSeasonCollectionProgress.Episodes.Should().BeNull();
        }

        [Fact]
        public void Test_ITraktSeasonCollectionProgressObjectJsonReader_ReadObject_From_Json_String_Not_Valid_5()
        {
            var jsonReader = new ITraktSeasonCollectionProgressObjectJsonReader();

            var traktSeasonCollectionProgress = jsonReader.ReadObject(JSON_NOT_VALID_5);

            traktSeasonCollectionProgress.Should().NotBeNull();
            traktSeasonCollectionProgress.Number.Should().BeNull();
            traktSeasonCollectionProgress.Aired.Should().BeNull();
            traktSeasonCollectionProgress.Completed.Should().BeNull();
            traktSeasonCollectionProgress.Episodes.Should().BeNull();
        }

        [Fact]
        public void Test_ITraktSeasonCollectionProgressObjectJsonReader_ReadObject_From_Json_String_Null()
        {
            var jsonReader = new ITraktSeasonCollectionProgressObjectJsonReader();

            var traktSeasonCollectionProgress = jsonReader.ReadObject(default(string));
            traktSeasonCollectionProgress.Should().BeNull();
        }

        [Fact]
        public void Test_ITraktSeasonCollectionProgressObjectJsonReader_ReadObject_From_Json_String_Empty()
        {
            var jsonReader = new ITraktSeasonCollectionProgressObjectJsonReader();

            var traktSeasonCollectionProgress = jsonReader.ReadObject(string.Empty);
            traktSeasonCollectionProgress.Should().BeNull();
        }

        [Fact]
        public void Test_ITraktSeasonCollectionProgressObjectJsonReader_ReadObject_From_JsonReader_Complete()
        {
            var traktJsonReader = new ITraktSeasonCollectionProgressObjectJsonReader();

            using (var reader = new StringReader(JSON_COMPLETE))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSeasonCollectionProgress = traktJsonReader.ReadObject(jsonReader);

                traktSeasonCollectionProgress.Should().NotBeNull();
                traktSeasonCollectionProgress.Number.Should().Be(2);
                traktSeasonCollectionProgress.Aired.Should().Be(3);
                traktSeasonCollectionProgress.Completed.Should().Be(2);
                traktSeasonCollectionProgress.Episodes.Should().NotBeNull().And.HaveCount(2);

                var episodesCollectionProgress = traktSeasonCollectionProgress.Episodes.ToArray();

                episodesCollectionProgress[0].Should().NotBeNull();
                episodesCollectionProgress[0].Number.Should().Be(1);
                episodesCollectionProgress[0].Completed.Should().BeTrue();
                episodesCollectionProgress[0].CollectedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

                episodesCollectionProgress[1].Should().NotBeNull();
                episodesCollectionProgress[1].Number.Should().Be(2);
                episodesCollectionProgress[1].Completed.Should().BeTrue();
                episodesCollectionProgress[1].CollectedAt.Should().Be(DateTime.Parse("2011-04-19T02:00:00.000Z").ToUniversalTime());
            }
        }

        [Fact]
        public void Test_ITraktSeasonCollectionProgressObjectJsonReader_ReadObject_From_JsonReader_Incomplete_1()
        {
            var traktJsonReader = new ITraktSeasonCollectionProgressObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSeasonCollectionProgress = traktJsonReader.ReadObject(jsonReader);

                traktSeasonCollectionProgress.Should().NotBeNull();
                traktSeasonCollectionProgress.Number.Should().BeNull();
                traktSeasonCollectionProgress.Aired.Should().Be(3);
                traktSeasonCollectionProgress.Completed.Should().Be(2);
                traktSeasonCollectionProgress.Episodes.Should().NotBeNull().And.HaveCount(2);

                var episodesCollectionProgress = traktSeasonCollectionProgress.Episodes.ToArray();

                episodesCollectionProgress[0].Should().NotBeNull();
                episodesCollectionProgress[0].Number.Should().Be(1);
                episodesCollectionProgress[0].Completed.Should().BeTrue();
                episodesCollectionProgress[0].CollectedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

                episodesCollectionProgress[1].Should().NotBeNull();
                episodesCollectionProgress[1].Number.Should().Be(2);
                episodesCollectionProgress[1].Completed.Should().BeTrue();
                episodesCollectionProgress[1].CollectedAt.Should().Be(DateTime.Parse("2011-04-19T02:00:00.000Z").ToUniversalTime());
            }
        }

        [Fact]
        public void Test_ITraktSeasonCollectionProgressObjectJsonReader_ReadObject_From_JsonReader_Incomplete_2()
        {
            var traktJsonReader = new ITraktSeasonCollectionProgressObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSeasonCollectionProgress = traktJsonReader.ReadObject(jsonReader);

                traktSeasonCollectionProgress.Should().NotBeNull();
                traktSeasonCollectionProgress.Number.Should().Be(2);
                traktSeasonCollectionProgress.Aired.Should().BeNull();
                traktSeasonCollectionProgress.Completed.Should().Be(2);
                traktSeasonCollectionProgress.Episodes.Should().NotBeNull().And.HaveCount(2);

                var episodesCollectionProgress = traktSeasonCollectionProgress.Episodes.ToArray();

                episodesCollectionProgress[0].Should().NotBeNull();
                episodesCollectionProgress[0].Number.Should().Be(1);
                episodesCollectionProgress[0].Completed.Should().BeTrue();
                episodesCollectionProgress[0].CollectedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

                episodesCollectionProgress[1].Should().NotBeNull();
                episodesCollectionProgress[1].Number.Should().Be(2);
                episodesCollectionProgress[1].Completed.Should().BeTrue();
                episodesCollectionProgress[1].CollectedAt.Should().Be(DateTime.Parse("2011-04-19T02:00:00.000Z").ToUniversalTime());
            }
        }

        [Fact]
        public void Test_ITraktSeasonCollectionProgressObjectJsonReader_ReadObject_From_JsonReader_Incomplete_3()
        {
            var traktJsonReader = new ITraktSeasonCollectionProgressObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSeasonCollectionProgress = traktJsonReader.ReadObject(jsonReader);

                traktSeasonCollectionProgress.Should().NotBeNull();
                traktSeasonCollectionProgress.Number.Should().Be(2);
                traktSeasonCollectionProgress.Aired.Should().Be(3);
                traktSeasonCollectionProgress.Completed.Should().BeNull();
                traktSeasonCollectionProgress.Episodes.Should().NotBeNull().And.HaveCount(2);

                var episodesCollectionProgress = traktSeasonCollectionProgress.Episodes.ToArray();

                episodesCollectionProgress[0].Should().NotBeNull();
                episodesCollectionProgress[0].Number.Should().Be(1);
                episodesCollectionProgress[0].Completed.Should().BeTrue();
                episodesCollectionProgress[0].CollectedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

                episodesCollectionProgress[1].Should().NotBeNull();
                episodesCollectionProgress[1].Number.Should().Be(2);
                episodesCollectionProgress[1].Completed.Should().BeTrue();
                episodesCollectionProgress[1].CollectedAt.Should().Be(DateTime.Parse("2011-04-19T02:00:00.000Z").ToUniversalTime());
            }
        }

        [Fact]
        public void Test_ITraktSeasonCollectionProgressObjectJsonReader_ReadObject_From_JsonReader_Incomplete_4()
        {
            var traktJsonReader = new ITraktSeasonCollectionProgressObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSeasonCollectionProgress = traktJsonReader.ReadObject(jsonReader);

                traktSeasonCollectionProgress.Should().NotBeNull();
                traktSeasonCollectionProgress.Number.Should().Be(2);
                traktSeasonCollectionProgress.Aired.Should().Be(3);
                traktSeasonCollectionProgress.Completed.Should().Be(2);
                traktSeasonCollectionProgress.Episodes.Should().BeNull();
            }
        }

        [Fact]
        public void Test_ITraktSeasonCollectionProgressObjectJsonReader_ReadObject_From_JsonReader_Incomplete_5()
        {
            var traktJsonReader = new ITraktSeasonCollectionProgressObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_5))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSeasonCollectionProgress = traktJsonReader.ReadObject(jsonReader);

                traktSeasonCollectionProgress.Should().NotBeNull();
                traktSeasonCollectionProgress.Number.Should().Be(2);
                traktSeasonCollectionProgress.Aired.Should().BeNull();
                traktSeasonCollectionProgress.Completed.Should().BeNull();
                traktSeasonCollectionProgress.Episodes.Should().BeNull();
            }
        }

        [Fact]
        public void Test_ITraktSeasonCollectionProgressObjectJsonReader_ReadObject_From_JsonReader_Incomplete_6()
        {
            var traktJsonReader = new ITraktSeasonCollectionProgressObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_6))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSeasonCollectionProgress = traktJsonReader.ReadObject(jsonReader);

                traktSeasonCollectionProgress.Should().NotBeNull();
                traktSeasonCollectionProgress.Number.Should().BeNull();
                traktSeasonCollectionProgress.Aired.Should().Be(3);
                traktSeasonCollectionProgress.Completed.Should().BeNull();
                traktSeasonCollectionProgress.Episodes.Should().BeNull();
            }
        }

        [Fact]
        public void Test_ITraktSeasonCollectionProgressObjectJsonReader_ReadObject_From_JsonReader_Incomplete_7()
        {
            var traktJsonReader = new ITraktSeasonCollectionProgressObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_7))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSeasonCollectionProgress = traktJsonReader.ReadObject(jsonReader);

                traktSeasonCollectionProgress.Should().NotBeNull();
                traktSeasonCollectionProgress.Number.Should().BeNull();
                traktSeasonCollectionProgress.Aired.Should().BeNull();
                traktSeasonCollectionProgress.Completed.Should().Be(2);
                traktSeasonCollectionProgress.Episodes.Should().BeNull();
            }
        }

        [Fact]
        public void Test_ITraktSeasonCollectionProgressObjectJsonReader_ReadObject_From_JsonReader_Incomplete_8()
        {
            var traktJsonReader = new ITraktSeasonCollectionProgressObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_8))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSeasonCollectionProgress = traktJsonReader.ReadObject(jsonReader);

                traktSeasonCollectionProgress.Should().NotBeNull();
                traktSeasonCollectionProgress.Number.Should().BeNull();
                traktSeasonCollectionProgress.Aired.Should().BeNull();
                traktSeasonCollectionProgress.Completed.Should().BeNull();
                traktSeasonCollectionProgress.Episodes.Should().NotBeNull().And.HaveCount(2);

                var episodesCollectionProgress = traktSeasonCollectionProgress.Episodes.ToArray();

                episodesCollectionProgress[0].Should().NotBeNull();
                episodesCollectionProgress[0].Number.Should().Be(1);
                episodesCollectionProgress[0].Completed.Should().BeTrue();
                episodesCollectionProgress[0].CollectedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

                episodesCollectionProgress[1].Should().NotBeNull();
                episodesCollectionProgress[1].Number.Should().Be(2);
                episodesCollectionProgress[1].Completed.Should().BeTrue();
                episodesCollectionProgress[1].CollectedAt.Should().Be(DateTime.Parse("2011-04-19T02:00:00.000Z").ToUniversalTime());
            }
        }

        [Fact]
        public void Test_ITraktSeasonCollectionProgressObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_1()
        {
            var traktJsonReader = new ITraktSeasonCollectionProgressObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSeasonCollectionProgress = traktJsonReader.ReadObject(jsonReader);

                traktSeasonCollectionProgress.Should().NotBeNull();
                traktSeasonCollectionProgress.Number.Should().BeNull();
                traktSeasonCollectionProgress.Aired.Should().Be(3);
                traktSeasonCollectionProgress.Completed.Should().Be(2);
                traktSeasonCollectionProgress.Episodes.Should().NotBeNull().And.HaveCount(2);

                var episodesCollectionProgress = traktSeasonCollectionProgress.Episodes.ToArray();

                episodesCollectionProgress[0].Should().NotBeNull();
                episodesCollectionProgress[0].Number.Should().Be(1);
                episodesCollectionProgress[0].Completed.Should().BeTrue();
                episodesCollectionProgress[0].CollectedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

                episodesCollectionProgress[1].Should().NotBeNull();
                episodesCollectionProgress[1].Number.Should().Be(2);
                episodesCollectionProgress[1].Completed.Should().BeTrue();
                episodesCollectionProgress[1].CollectedAt.Should().Be(DateTime.Parse("2011-04-19T02:00:00.000Z").ToUniversalTime());
            }
        }

        [Fact]
        public void Test_ITraktSeasonCollectionProgressObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_2()
        {
            var traktJsonReader = new ITraktSeasonCollectionProgressObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSeasonCollectionProgress = traktJsonReader.ReadObject(jsonReader);

                traktSeasonCollectionProgress.Should().NotBeNull();
                traktSeasonCollectionProgress.Number.Should().Be(2);
                traktSeasonCollectionProgress.Aired.Should().BeNull();
                traktSeasonCollectionProgress.Completed.Should().Be(2);
                traktSeasonCollectionProgress.Episodes.Should().NotBeNull().And.HaveCount(2);

                var episodesCollectionProgress = traktSeasonCollectionProgress.Episodes.ToArray();

                episodesCollectionProgress[0].Should().NotBeNull();
                episodesCollectionProgress[0].Number.Should().Be(1);
                episodesCollectionProgress[0].Completed.Should().BeTrue();
                episodesCollectionProgress[0].CollectedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

                episodesCollectionProgress[1].Should().NotBeNull();
                episodesCollectionProgress[1].Number.Should().Be(2);
                episodesCollectionProgress[1].Completed.Should().BeTrue();
                episodesCollectionProgress[1].CollectedAt.Should().Be(DateTime.Parse("2011-04-19T02:00:00.000Z").ToUniversalTime());
            }
        }

        [Fact]
        public void Test_ITraktSeasonCollectionProgressObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_3()
        {
            var traktJsonReader = new ITraktSeasonCollectionProgressObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSeasonCollectionProgress = traktJsonReader.ReadObject(jsonReader);

                traktSeasonCollectionProgress.Should().NotBeNull();
                traktSeasonCollectionProgress.Number.Should().Be(2);
                traktSeasonCollectionProgress.Aired.Should().Be(3);
                traktSeasonCollectionProgress.Completed.Should().BeNull();
                traktSeasonCollectionProgress.Episodes.Should().NotBeNull().And.HaveCount(2);

                var episodesCollectionProgress = traktSeasonCollectionProgress.Episodes.ToArray();

                episodesCollectionProgress[0].Should().NotBeNull();
                episodesCollectionProgress[0].Number.Should().Be(1);
                episodesCollectionProgress[0].Completed.Should().BeTrue();
                episodesCollectionProgress[0].CollectedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

                episodesCollectionProgress[1].Should().NotBeNull();
                episodesCollectionProgress[1].Number.Should().Be(2);
                episodesCollectionProgress[1].Completed.Should().BeTrue();
                episodesCollectionProgress[1].CollectedAt.Should().Be(DateTime.Parse("2011-04-19T02:00:00.000Z").ToUniversalTime());
            }
        }

        [Fact]
        public void Test_ITraktSeasonCollectionProgressObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_4()
        {
            var traktJsonReader = new ITraktSeasonCollectionProgressObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSeasonCollectionProgress = traktJsonReader.ReadObject(jsonReader);

                traktSeasonCollectionProgress.Should().NotBeNull();
                traktSeasonCollectionProgress.Number.Should().Be(2);
                traktSeasonCollectionProgress.Aired.Should().Be(3);
                traktSeasonCollectionProgress.Completed.Should().Be(2);
                traktSeasonCollectionProgress.Episodes.Should().BeNull();
            }
        }

        [Fact]
        public void Test_ITraktSeasonCollectionProgressObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_5()
        {
            var traktJsonReader = new ITraktSeasonCollectionProgressObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_5))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSeasonCollectionProgress = traktJsonReader.ReadObject(jsonReader);

                traktSeasonCollectionProgress.Should().NotBeNull();
                traktSeasonCollectionProgress.Number.Should().BeNull();
                traktSeasonCollectionProgress.Aired.Should().BeNull();
                traktSeasonCollectionProgress.Completed.Should().BeNull();
                traktSeasonCollectionProgress.Episodes.Should().BeNull();
            }
        }

        [Fact]
        public void Test_ITraktSeasonCollectionProgressObjectJsonReader_ReadObject_From_JsonReader_Null()
        {
            var jsonReader = new ITraktSeasonCollectionProgressObjectJsonReader();

            var traktSeasonCollectionProgress = jsonReader.ReadObject(default(JsonTextReader));
            traktSeasonCollectionProgress.Should().BeNull();
        }

        [Fact]
        public void Test_ITraktSeasonCollectionProgressObjectJsonReader_ReadObject_From_JsonReader_Empty()
        {
            var traktJsonReader = new ITraktSeasonCollectionProgressObjectJsonReader();

            using (var reader = new StringReader(string.Empty))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSeasonCollectionProgress = traktJsonReader.ReadObject(jsonReader);
                traktSeasonCollectionProgress.Should().BeNull();
            }
        }

        private const string JSON_COMPLETE =
            @"{
                ""number"": 2,
                ""aired"": 3,
                ""completed"": 2,
                ""episodes"": [
                  {
                    ""number"": 1,
                    ""completed"": true,
                    ""collected_at"": ""2011-04-18T01:00:00.000Z""
                  },
                  {
                    ""number"": 2,
                    ""completed"": true,
                    ""collected_at"": ""2011-04-19T02:00:00.000Z""
                  }
                ]
              }";

        private const string JSON_INCOMPLETE_1 =
            @"{
                ""aired"": 3,
                ""completed"": 2,
                ""episodes"": [
                  {
                    ""number"": 1,
                    ""completed"": true,
                    ""collected_at"": ""2011-04-18T01:00:00.000Z""
                  },
                  {
                    ""number"": 2,
                    ""completed"": true,
                    ""collected_at"": ""2011-04-19T02:00:00.000Z""
                  }
                ]
              }";

        private const string JSON_INCOMPLETE_2 =
            @"{
                ""number"": 2,
                ""completed"": 2,
                ""episodes"": [
                  {
                    ""number"": 1,
                    ""completed"": true,
                    ""collected_at"": ""2011-04-18T01:00:00.000Z""
                  },
                  {
                    ""number"": 2,
                    ""completed"": true,
                    ""collected_at"": ""2011-04-19T02:00:00.000Z""
                  }
                ]
              }";

        private const string JSON_INCOMPLETE_3 =
            @"{
                ""number"": 2,
                ""aired"": 3,
                ""episodes"": [
                  {
                    ""number"": 1,
                    ""completed"": true,
                    ""collected_at"": ""2011-04-18T01:00:00.000Z""
                  },
                  {
                    ""number"": 2,
                    ""completed"": true,
                    ""collected_at"": ""2011-04-19T02:00:00.000Z""
                  }
                ]
              }";

        private const string JSON_INCOMPLETE_4 =
            @"{
                ""number"": 2,
                ""aired"": 3,
                ""completed"": 2
              }";

        private const string JSON_INCOMPLETE_5 =
            @"{
                ""number"": 2
              }";

        private const string JSON_INCOMPLETE_6 =
            @"{
                ""aired"": 3
              }";

        private const string JSON_INCOMPLETE_7 =
            @"{
                ""completed"": 2
              }";

        private const string JSON_INCOMPLETE_8 =
            @"{
                ""episodes"": [
                  {
                    ""number"": 1,
                    ""completed"": true,
                    ""collected_at"": ""2011-04-18T01:00:00.000Z""
                  },
                  {
                    ""number"": 2,
                    ""completed"": true,
                    ""collected_at"": ""2011-04-19T02:00:00.000Z""
                  }
                ]
              }";

        private const string JSON_NOT_VALID_1 =
            @"{
                ""nu"": 2,
                ""aired"": 3,
                ""completed"": 2,
                ""episodes"": [
                  {
                    ""number"": 1,
                    ""completed"": true,
                    ""collected_at"": ""2011-04-18T01:00:00.000Z""
                  },
                  {
                    ""number"": 2,
                    ""completed"": true,
                    ""collected_at"": ""2011-04-19T02:00:00.000Z""
                  }
                ]
              }";

        private const string JSON_NOT_VALID_2 =
            @"{
                ""number"": 2,
                ""ai"": 3,
                ""completed"": 2,
                ""episodes"": [
                  {
                    ""number"": 1,
                    ""completed"": true,
                    ""collected_at"": ""2011-04-18T01:00:00.000Z""
                  },
                  {
                    ""number"": 2,
                    ""completed"": true,
                    ""collected_at"": ""2011-04-19T02:00:00.000Z""
                  }
                ]
              }";

        private const string JSON_NOT_VALID_3 =
            @"{
                ""number"": 2,
                ""aired"": 3,
                ""com"": 2,
                ""episodes"": [
                  {
                    ""number"": 1,
                    ""completed"": true,
                    ""collected_at"": ""2011-04-18T01:00:00.000Z""
                  },
                  {
                    ""number"": 2,
                    ""completed"": true,
                    ""collected_at"": ""2011-04-19T02:00:00.000Z""
                  }
                ]
              }";

        private const string JSON_NOT_VALID_4 =
            @"{
                ""number"": 2,
                ""aired"": 3,
                ""completed"": 2,
                ""ep"": [
                  {
                    ""number"": 1,
                    ""completed"": true,
                    ""collected_at"": ""2011-04-18T01:00:00.000Z""
                  },
                  {
                    ""number"": 2,
                    ""completed"": true,
                    ""collected_at"": ""2011-04-19T02:00:00.000Z""
                  }
                ]
              }";

        private const string JSON_NOT_VALID_5 =
            @"{
                ""nu"": 2,
                ""ai"": 3,
                ""com"": 2,
                ""ep"": [
                  {
                    ""number"": 1,
                    ""completed"": true,
                    ""collected_at"": ""2011-04-18T01:00:00.000Z""
                  },
                  {
                    ""number"": 2,
                    ""completed"": true,
                    ""collected_at"": ""2011-04-19T02:00:00.000Z""
                  }
                ]
              }";
    }
}

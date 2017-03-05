namespace TraktApiSharp.Tests.Objects.JsonReader.Get.Seasons
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Linq;
    using Traits;
    using TraktApiSharp.Objects.Get.Seasons;
    using TraktApiSharp.Objects.JsonReader;
    using TraktApiSharp.Objects.JsonReader.Get.Seasons;
    using Xunit;

    [Category("Objects.JsonReader.Get.Seasons")]
    public class TraktSeasonWatchedProgressObjectJsonReader_Tests
    {
        [Fact]
        public void Test_TraktSeasonWatchedProgressObjectJsonReader_Implements_ITraktObjectJsonReader_Interface()
        {
            typeof(TraktSeasonWatchedProgressObjectJsonReader).GetInterfaces().Should().Contain(typeof(ITraktObjectJsonReader<TraktSeasonWatchedProgress>));
        }

        [Fact]
        public void Test_TraktSeasonWatchedProgressObjectJsonReader_ReadObject_From_Json_String_Complete()
        {
            var jsonReader = new TraktSeasonWatchedProgressObjectJsonReader();

            var traktSeasonWatchedProgress = jsonReader.ReadObject(JSON_COMPLETE);

            traktSeasonWatchedProgress.Should().NotBeNull();
            traktSeasonWatchedProgress.Number.Should().Be(2);
            traktSeasonWatchedProgress.Aired.Should().Be(3);
            traktSeasonWatchedProgress.Completed.Should().Be(2);
            traktSeasonWatchedProgress.Episodes.Should().NotBeNull().And.HaveCount(2);

            var episodesCollectionProgress = traktSeasonWatchedProgress.Episodes.ToArray();

            episodesCollectionProgress[0].Should().NotBeNull();
            episodesCollectionProgress[0].Number.Should().Be(1);
            episodesCollectionProgress[0].Completed.Should().BeTrue();
            episodesCollectionProgress[0].LastWatchedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

            episodesCollectionProgress[1].Should().NotBeNull();
            episodesCollectionProgress[1].Number.Should().Be(2);
            episodesCollectionProgress[1].Completed.Should().BeTrue();
            episodesCollectionProgress[1].LastWatchedAt.Should().Be(DateTime.Parse("2011-04-19T02:00:00.000Z").ToUniversalTime());
        }

        [Fact]
        public void Test_TraktSeasonWatchedProgressObjectJsonReader_ReadObject_From_Json_String_Incomplete_1()
        {
            var jsonReader = new TraktSeasonWatchedProgressObjectJsonReader();

            var traktSeasonWatchedProgress = jsonReader.ReadObject(JSON_INCOMPLETE_1);

            traktSeasonWatchedProgress.Should().NotBeNull();
            traktSeasonWatchedProgress.Number.Should().BeNull();
            traktSeasonWatchedProgress.Aired.Should().Be(3);
            traktSeasonWatchedProgress.Completed.Should().Be(2);
            traktSeasonWatchedProgress.Episodes.Should().NotBeNull().And.HaveCount(2);

            var episodesCollectionProgress = traktSeasonWatchedProgress.Episodes.ToArray();

            episodesCollectionProgress[0].Should().NotBeNull();
            episodesCollectionProgress[0].Number.Should().Be(1);
            episodesCollectionProgress[0].Completed.Should().BeTrue();
            episodesCollectionProgress[0].LastWatchedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

            episodesCollectionProgress[1].Should().NotBeNull();
            episodesCollectionProgress[1].Number.Should().Be(2);
            episodesCollectionProgress[1].Completed.Should().BeTrue();
            episodesCollectionProgress[1].LastWatchedAt.Should().Be(DateTime.Parse("2011-04-19T02:00:00.000Z").ToUniversalTime());
        }

        [Fact]
        public void Test_TraktSeasonWatchedProgressObjectJsonReader_ReadObject_From_Json_String_Incomplete_2()
        {
            var jsonReader = new TraktSeasonWatchedProgressObjectJsonReader();

            var traktSeasonWatchedProgress = jsonReader.ReadObject(JSON_INCOMPLETE_2);

            traktSeasonWatchedProgress.Should().NotBeNull();
            traktSeasonWatchedProgress.Number.Should().Be(2);
            traktSeasonWatchedProgress.Aired.Should().BeNull();
            traktSeasonWatchedProgress.Completed.Should().Be(2);
            traktSeasonWatchedProgress.Episodes.Should().NotBeNull().And.HaveCount(2);

            var episodesCollectionProgress = traktSeasonWatchedProgress.Episodes.ToArray();

            episodesCollectionProgress[0].Should().NotBeNull();
            episodesCollectionProgress[0].Number.Should().Be(1);
            episodesCollectionProgress[0].Completed.Should().BeTrue();
            episodesCollectionProgress[0].LastWatchedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

            episodesCollectionProgress[1].Should().NotBeNull();
            episodesCollectionProgress[1].Number.Should().Be(2);
            episodesCollectionProgress[1].Completed.Should().BeTrue();
            episodesCollectionProgress[1].LastWatchedAt.Should().Be(DateTime.Parse("2011-04-19T02:00:00.000Z").ToUniversalTime());
        }

        [Fact]
        public void Test_TraktSeasonWatchedProgressObjectJsonReader_ReadObject_From_Json_String_Incomplete_3()
        {
            var jsonReader = new TraktSeasonWatchedProgressObjectJsonReader();

            var traktSeasonWatchedProgress = jsonReader.ReadObject(JSON_INCOMPLETE_3);

            traktSeasonWatchedProgress.Should().NotBeNull();
            traktSeasonWatchedProgress.Number.Should().Be(2);
            traktSeasonWatchedProgress.Aired.Should().Be(3);
            traktSeasonWatchedProgress.Completed.Should().BeNull();
            traktSeasonWatchedProgress.Episodes.Should().NotBeNull().And.HaveCount(2);

            var episodesCollectionProgress = traktSeasonWatchedProgress.Episodes.ToArray();

            episodesCollectionProgress[0].Should().NotBeNull();
            episodesCollectionProgress[0].Number.Should().Be(1);
            episodesCollectionProgress[0].Completed.Should().BeTrue();
            episodesCollectionProgress[0].LastWatchedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

            episodesCollectionProgress[1].Should().NotBeNull();
            episodesCollectionProgress[1].Number.Should().Be(2);
            episodesCollectionProgress[1].Completed.Should().BeTrue();
            episodesCollectionProgress[1].LastWatchedAt.Should().Be(DateTime.Parse("2011-04-19T02:00:00.000Z").ToUniversalTime());
        }

        [Fact]
        public void Test_TraktSeasonWatchedProgressObjectJsonReader_ReadObject_From_Json_String_Incomplete_4()
        {
            var jsonReader = new TraktSeasonWatchedProgressObjectJsonReader();

            var traktSeasonWatchedProgress = jsonReader.ReadObject(JSON_INCOMPLETE_4);

            traktSeasonWatchedProgress.Should().NotBeNull();
            traktSeasonWatchedProgress.Number.Should().Be(2);
            traktSeasonWatchedProgress.Aired.Should().Be(3);
            traktSeasonWatchedProgress.Completed.Should().Be(2);
            traktSeasonWatchedProgress.Episodes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktSeasonWatchedProgressObjectJsonReader_ReadObject_From_Json_String_Incomplete_5()
        {
            var jsonReader = new TraktSeasonWatchedProgressObjectJsonReader();

            var traktSeasonWatchedProgress = jsonReader.ReadObject(JSON_INCOMPLETE_5);

            traktSeasonWatchedProgress.Should().NotBeNull();
            traktSeasonWatchedProgress.Number.Should().Be(2);
            traktSeasonWatchedProgress.Aired.Should().BeNull();
            traktSeasonWatchedProgress.Completed.Should().BeNull();
            traktSeasonWatchedProgress.Episodes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktSeasonWatchedProgressObjectJsonReader_ReadObject_From_Json_String_Incomplete_6()
        {
            var jsonReader = new TraktSeasonWatchedProgressObjectJsonReader();

            var traktSeasonWatchedProgress = jsonReader.ReadObject(JSON_INCOMPLETE_6);

            traktSeasonWatchedProgress.Should().NotBeNull();
            traktSeasonWatchedProgress.Number.Should().BeNull();
            traktSeasonWatchedProgress.Aired.Should().Be(3);
            traktSeasonWatchedProgress.Completed.Should().BeNull();
            traktSeasonWatchedProgress.Episodes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktSeasonWatchedProgressObjectJsonReader_ReadObject_From_Json_String_Incomplete_7()
        {
            var jsonReader = new TraktSeasonWatchedProgressObjectJsonReader();

            var traktSeasonWatchedProgress = jsonReader.ReadObject(JSON_INCOMPLETE_7);

            traktSeasonWatchedProgress.Should().NotBeNull();
            traktSeasonWatchedProgress.Number.Should().BeNull();
            traktSeasonWatchedProgress.Aired.Should().BeNull();
            traktSeasonWatchedProgress.Completed.Should().Be(2);
            traktSeasonWatchedProgress.Episodes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktSeasonWatchedProgressObjectJsonReader_ReadObject_From_Json_String_Incomplete_8()
        {
            var jsonReader = new TraktSeasonWatchedProgressObjectJsonReader();

            var traktSeasonWatchedProgress = jsonReader.ReadObject(JSON_INCOMPLETE_8);

            traktSeasonWatchedProgress.Should().NotBeNull();
            traktSeasonWatchedProgress.Number.Should().BeNull();
            traktSeasonWatchedProgress.Aired.Should().BeNull();
            traktSeasonWatchedProgress.Completed.Should().BeNull();
            traktSeasonWatchedProgress.Episodes.Should().NotBeNull().And.HaveCount(2);

            var episodesCollectionProgress = traktSeasonWatchedProgress.Episodes.ToArray();

            episodesCollectionProgress[0].Should().NotBeNull();
            episodesCollectionProgress[0].Number.Should().Be(1);
            episodesCollectionProgress[0].Completed.Should().BeTrue();
            episodesCollectionProgress[0].LastWatchedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

            episodesCollectionProgress[1].Should().NotBeNull();
            episodesCollectionProgress[1].Number.Should().Be(2);
            episodesCollectionProgress[1].Completed.Should().BeTrue();
            episodesCollectionProgress[1].LastWatchedAt.Should().Be(DateTime.Parse("2011-04-19T02:00:00.000Z").ToUniversalTime());
        }

        [Fact]
        public void Test_TraktSeasonWatchedProgressObjectJsonReader_ReadObject_From_Json_String_Not_Valid_1()
        {
            var jsonReader = new TraktSeasonWatchedProgressObjectJsonReader();

            var traktSeasonWatchedProgress = jsonReader.ReadObject(JSON_NOT_VALID_1);

            traktSeasonWatchedProgress.Should().NotBeNull();
            traktSeasonWatchedProgress.Number.Should().BeNull();
            traktSeasonWatchedProgress.Aired.Should().Be(3);
            traktSeasonWatchedProgress.Completed.Should().Be(2);
            traktSeasonWatchedProgress.Episodes.Should().NotBeNull().And.HaveCount(2);

            var episodesCollectionProgress = traktSeasonWatchedProgress.Episodes.ToArray();

            episodesCollectionProgress[0].Should().NotBeNull();
            episodesCollectionProgress[0].Number.Should().Be(1);
            episodesCollectionProgress[0].Completed.Should().BeTrue();
            episodesCollectionProgress[0].LastWatchedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

            episodesCollectionProgress[1].Should().NotBeNull();
            episodesCollectionProgress[1].Number.Should().Be(2);
            episodesCollectionProgress[1].Completed.Should().BeTrue();
            episodesCollectionProgress[1].LastWatchedAt.Should().Be(DateTime.Parse("2011-04-19T02:00:00.000Z").ToUniversalTime());
        }

        [Fact]
        public void Test_TraktSeasonWatchedProgressObjectJsonReader_ReadObject_From_Json_String_Not_Valid_2()
        {
            var jsonReader = new TraktSeasonWatchedProgressObjectJsonReader();

            var traktSeasonWatchedProgress = jsonReader.ReadObject(JSON_NOT_VALID_2);

            traktSeasonWatchedProgress.Should().NotBeNull();
            traktSeasonWatchedProgress.Number.Should().Be(2);
            traktSeasonWatchedProgress.Aired.Should().BeNull();
            traktSeasonWatchedProgress.Completed.Should().Be(2);
            traktSeasonWatchedProgress.Episodes.Should().NotBeNull().And.HaveCount(2);

            var episodesCollectionProgress = traktSeasonWatchedProgress.Episodes.ToArray();

            episodesCollectionProgress[0].Should().NotBeNull();
            episodesCollectionProgress[0].Number.Should().Be(1);
            episodesCollectionProgress[0].Completed.Should().BeTrue();
            episodesCollectionProgress[0].LastWatchedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

            episodesCollectionProgress[1].Should().NotBeNull();
            episodesCollectionProgress[1].Number.Should().Be(2);
            episodesCollectionProgress[1].Completed.Should().BeTrue();
            episodesCollectionProgress[1].LastWatchedAt.Should().Be(DateTime.Parse("2011-04-19T02:00:00.000Z").ToUniversalTime());
        }

        [Fact]
        public void Test_TraktSeasonWatchedProgressObjectJsonReader_ReadObject_From_Json_String_Not_Valid_3()
        {
            var jsonReader = new TraktSeasonWatchedProgressObjectJsonReader();

            var traktSeasonWatchedProgress = jsonReader.ReadObject(JSON_NOT_VALID_3);

            traktSeasonWatchedProgress.Should().NotBeNull();
            traktSeasonWatchedProgress.Number.Should().Be(2);
            traktSeasonWatchedProgress.Aired.Should().Be(3);
            traktSeasonWatchedProgress.Completed.Should().BeNull();
            traktSeasonWatchedProgress.Episodes.Should().NotBeNull().And.HaveCount(2);

            var episodesCollectionProgress = traktSeasonWatchedProgress.Episodes.ToArray();

            episodesCollectionProgress[0].Should().NotBeNull();
            episodesCollectionProgress[0].Number.Should().Be(1);
            episodesCollectionProgress[0].Completed.Should().BeTrue();
            episodesCollectionProgress[0].LastWatchedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

            episodesCollectionProgress[1].Should().NotBeNull();
            episodesCollectionProgress[1].Number.Should().Be(2);
            episodesCollectionProgress[1].Completed.Should().BeTrue();
            episodesCollectionProgress[1].LastWatchedAt.Should().Be(DateTime.Parse("2011-04-19T02:00:00.000Z").ToUniversalTime());
        }

        [Fact]
        public void Test_TraktSeasonWatchedProgressObjectJsonReader_ReadObject_From_Json_String_Not_Valid_4()
        {
            var jsonReader = new TraktSeasonWatchedProgressObjectJsonReader();

            var traktSeasonWatchedProgress = jsonReader.ReadObject(JSON_NOT_VALID_4);

            traktSeasonWatchedProgress.Should().NotBeNull();
            traktSeasonWatchedProgress.Number.Should().Be(2);
            traktSeasonWatchedProgress.Aired.Should().Be(3);
            traktSeasonWatchedProgress.Completed.Should().Be(2);
            traktSeasonWatchedProgress.Episodes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktSeasonWatchedProgressObjectJsonReader_ReadObject_From_Json_String_Not_Valid_5()
        {
            var jsonReader = new TraktSeasonWatchedProgressObjectJsonReader();

            var traktSeasonWatchedProgress = jsonReader.ReadObject(JSON_NOT_VALID_5);

            traktSeasonWatchedProgress.Should().NotBeNull();
            traktSeasonWatchedProgress.Number.Should().BeNull();
            traktSeasonWatchedProgress.Aired.Should().BeNull();
            traktSeasonWatchedProgress.Completed.Should().BeNull();
            traktSeasonWatchedProgress.Episodes.Should().BeNull();
        }

        [Fact]
        public void Test_TraktSeasonWatchedProgressObjectJsonReader_ReadObject_From_Json_String_Null()
        {
            var jsonReader = new TraktSeasonWatchedProgressObjectJsonReader();

            var traktSeasonWatchedProgress = jsonReader.ReadObject(default(string));
            traktSeasonWatchedProgress.Should().BeNull();
        }

        [Fact]
        public void Test_TraktSeasonWatchedProgressObjectJsonReader_ReadObject_From_Json_String_Empty()
        {
            var jsonReader = new TraktSeasonWatchedProgressObjectJsonReader();

            var traktSeasonWatchedProgress = jsonReader.ReadObject(string.Empty);
            traktSeasonWatchedProgress.Should().BeNull();
        }

        [Fact]
        public void Test_TraktSeasonWatchedProgressObjectJsonReader_ReadObject_From_JsonReader_Complete()
        {
            var traktJsonReader = new TraktSeasonWatchedProgressObjectJsonReader();

            using (var reader = new StringReader(JSON_COMPLETE))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSeasonWatchedProgress = traktJsonReader.ReadObject(jsonReader);

                traktSeasonWatchedProgress.Should().NotBeNull();
                traktSeasonWatchedProgress.Number.Should().Be(2);
                traktSeasonWatchedProgress.Aired.Should().Be(3);
                traktSeasonWatchedProgress.Completed.Should().Be(2);
                traktSeasonWatchedProgress.Episodes.Should().NotBeNull().And.HaveCount(2);

                var episodesCollectionProgress = traktSeasonWatchedProgress.Episodes.ToArray();

                episodesCollectionProgress[0].Should().NotBeNull();
                episodesCollectionProgress[0].Number.Should().Be(1);
                episodesCollectionProgress[0].Completed.Should().BeTrue();
                episodesCollectionProgress[0].LastWatchedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

                episodesCollectionProgress[1].Should().NotBeNull();
                episodesCollectionProgress[1].Number.Should().Be(2);
                episodesCollectionProgress[1].Completed.Should().BeTrue();
                episodesCollectionProgress[1].LastWatchedAt.Should().Be(DateTime.Parse("2011-04-19T02:00:00.000Z").ToUniversalTime());
            }
        }

        [Fact]
        public void Test_TraktSeasonWatchedProgressObjectJsonReader_ReadObject_From_JsonReader_Incomplete_1()
        {
            var traktJsonReader = new TraktSeasonWatchedProgressObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSeasonWatchedProgress = traktJsonReader.ReadObject(jsonReader);

                traktSeasonWatchedProgress.Should().NotBeNull();
                traktSeasonWatchedProgress.Number.Should().BeNull();
                traktSeasonWatchedProgress.Aired.Should().Be(3);
                traktSeasonWatchedProgress.Completed.Should().Be(2);
                traktSeasonWatchedProgress.Episodes.Should().NotBeNull().And.HaveCount(2);

                var episodesCollectionProgress = traktSeasonWatchedProgress.Episodes.ToArray();

                episodesCollectionProgress[0].Should().NotBeNull();
                episodesCollectionProgress[0].Number.Should().Be(1);
                episodesCollectionProgress[0].Completed.Should().BeTrue();
                episodesCollectionProgress[0].LastWatchedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

                episodesCollectionProgress[1].Should().NotBeNull();
                episodesCollectionProgress[1].Number.Should().Be(2);
                episodesCollectionProgress[1].Completed.Should().BeTrue();
                episodesCollectionProgress[1].LastWatchedAt.Should().Be(DateTime.Parse("2011-04-19T02:00:00.000Z").ToUniversalTime());
            }
        }

        [Fact]
        public void Test_TraktSeasonWatchedProgressObjectJsonReader_ReadObject_From_JsonReader_Incomplete_2()
        {
            var traktJsonReader = new TraktSeasonWatchedProgressObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSeasonWatchedProgress = traktJsonReader.ReadObject(jsonReader);

                traktSeasonWatchedProgress.Should().NotBeNull();
                traktSeasonWatchedProgress.Number.Should().Be(2);
                traktSeasonWatchedProgress.Aired.Should().BeNull();
                traktSeasonWatchedProgress.Completed.Should().Be(2);
                traktSeasonWatchedProgress.Episodes.Should().NotBeNull().And.HaveCount(2);

                var episodesCollectionProgress = traktSeasonWatchedProgress.Episodes.ToArray();

                episodesCollectionProgress[0].Should().NotBeNull();
                episodesCollectionProgress[0].Number.Should().Be(1);
                episodesCollectionProgress[0].Completed.Should().BeTrue();
                episodesCollectionProgress[0].LastWatchedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

                episodesCollectionProgress[1].Should().NotBeNull();
                episodesCollectionProgress[1].Number.Should().Be(2);
                episodesCollectionProgress[1].Completed.Should().BeTrue();
                episodesCollectionProgress[1].LastWatchedAt.Should().Be(DateTime.Parse("2011-04-19T02:00:00.000Z").ToUniversalTime());
            }
        }

        [Fact]
        public void Test_TraktSeasonWatchedProgressObjectJsonReader_ReadObject_From_JsonReader_Incomplete_3()
        {
            var traktJsonReader = new TraktSeasonWatchedProgressObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSeasonWatchedProgress = traktJsonReader.ReadObject(jsonReader);

                traktSeasonWatchedProgress.Should().NotBeNull();
                traktSeasonWatchedProgress.Number.Should().Be(2);
                traktSeasonWatchedProgress.Aired.Should().Be(3);
                traktSeasonWatchedProgress.Completed.Should().BeNull();
                traktSeasonWatchedProgress.Episodes.Should().NotBeNull().And.HaveCount(2);

                var episodesCollectionProgress = traktSeasonWatchedProgress.Episodes.ToArray();

                episodesCollectionProgress[0].Should().NotBeNull();
                episodesCollectionProgress[0].Number.Should().Be(1);
                episodesCollectionProgress[0].Completed.Should().BeTrue();
                episodesCollectionProgress[0].LastWatchedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

                episodesCollectionProgress[1].Should().NotBeNull();
                episodesCollectionProgress[1].Number.Should().Be(2);
                episodesCollectionProgress[1].Completed.Should().BeTrue();
                episodesCollectionProgress[1].LastWatchedAt.Should().Be(DateTime.Parse("2011-04-19T02:00:00.000Z").ToUniversalTime());
            }
        }

        [Fact]
        public void Test_TraktSeasonWatchedProgressObjectJsonReader_ReadObject_From_JsonReader_Incomplete_4()
        {
            var traktJsonReader = new TraktSeasonWatchedProgressObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSeasonWatchedProgress = traktJsonReader.ReadObject(jsonReader);

                traktSeasonWatchedProgress.Should().NotBeNull();
                traktSeasonWatchedProgress.Number.Should().Be(2);
                traktSeasonWatchedProgress.Aired.Should().Be(3);
                traktSeasonWatchedProgress.Completed.Should().Be(2);
                traktSeasonWatchedProgress.Episodes.Should().BeNull();
            }
        }

        [Fact]
        public void Test_TraktSeasonWatchedProgressObjectJsonReader_ReadObject_From_JsonReader_Incomplete_5()
        {
            var traktJsonReader = new TraktSeasonWatchedProgressObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_5))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSeasonWatchedProgress = traktJsonReader.ReadObject(jsonReader);

                traktSeasonWatchedProgress.Should().NotBeNull();
                traktSeasonWatchedProgress.Number.Should().Be(2);
                traktSeasonWatchedProgress.Aired.Should().BeNull();
                traktSeasonWatchedProgress.Completed.Should().BeNull();
                traktSeasonWatchedProgress.Episodes.Should().BeNull();
            }
        }

        [Fact]
        public void Test_TraktSeasonWatchedProgressObjectJsonReader_ReadObject_From_JsonReader_Incomplete_6()
        {
            var traktJsonReader = new TraktSeasonWatchedProgressObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_6))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSeasonWatchedProgress = traktJsonReader.ReadObject(jsonReader);

                traktSeasonWatchedProgress.Should().NotBeNull();
                traktSeasonWatchedProgress.Number.Should().BeNull();
                traktSeasonWatchedProgress.Aired.Should().Be(3);
                traktSeasonWatchedProgress.Completed.Should().BeNull();
                traktSeasonWatchedProgress.Episodes.Should().BeNull();
            }
        }

        [Fact]
        public void Test_TraktSeasonWatchedProgressObjectJsonReader_ReadObject_From_JsonReader_Incomplete_7()
        {
            var traktJsonReader = new TraktSeasonWatchedProgressObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_7))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSeasonWatchedProgress = traktJsonReader.ReadObject(jsonReader);

                traktSeasonWatchedProgress.Should().NotBeNull();
                traktSeasonWatchedProgress.Number.Should().BeNull();
                traktSeasonWatchedProgress.Aired.Should().BeNull();
                traktSeasonWatchedProgress.Completed.Should().Be(2);
                traktSeasonWatchedProgress.Episodes.Should().BeNull();
            }
        }

        [Fact]
        public void Test_TraktSeasonWatchedProgressObjectJsonReader_ReadObject_From_JsonReader_Incomplete_8()
        {
            var traktJsonReader = new TraktSeasonWatchedProgressObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_8))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSeasonWatchedProgress = traktJsonReader.ReadObject(jsonReader);

                traktSeasonWatchedProgress.Should().NotBeNull();
                traktSeasonWatchedProgress.Number.Should().BeNull();
                traktSeasonWatchedProgress.Aired.Should().BeNull();
                traktSeasonWatchedProgress.Completed.Should().BeNull();
                traktSeasonWatchedProgress.Episodes.Should().NotBeNull().And.HaveCount(2);

                var episodesCollectionProgress = traktSeasonWatchedProgress.Episodes.ToArray();

                episodesCollectionProgress[0].Should().NotBeNull();
                episodesCollectionProgress[0].Number.Should().Be(1);
                episodesCollectionProgress[0].Completed.Should().BeTrue();
                episodesCollectionProgress[0].LastWatchedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

                episodesCollectionProgress[1].Should().NotBeNull();
                episodesCollectionProgress[1].Number.Should().Be(2);
                episodesCollectionProgress[1].Completed.Should().BeTrue();
                episodesCollectionProgress[1].LastWatchedAt.Should().Be(DateTime.Parse("2011-04-19T02:00:00.000Z").ToUniversalTime());
            }
        }

        [Fact]
        public void Test_TraktSeasonWatchedProgressObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_1()
        {
            var traktJsonReader = new TraktSeasonWatchedProgressObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSeasonWatchedProgress = traktJsonReader.ReadObject(jsonReader);

                traktSeasonWatchedProgress.Should().NotBeNull();
                traktSeasonWatchedProgress.Number.Should().BeNull();
                traktSeasonWatchedProgress.Aired.Should().Be(3);
                traktSeasonWatchedProgress.Completed.Should().Be(2);
                traktSeasonWatchedProgress.Episodes.Should().NotBeNull().And.HaveCount(2);

                var episodesCollectionProgress = traktSeasonWatchedProgress.Episodes.ToArray();

                episodesCollectionProgress[0].Should().NotBeNull();
                episodesCollectionProgress[0].Number.Should().Be(1);
                episodesCollectionProgress[0].Completed.Should().BeTrue();
                episodesCollectionProgress[0].LastWatchedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

                episodesCollectionProgress[1].Should().NotBeNull();
                episodesCollectionProgress[1].Number.Should().Be(2);
                episodesCollectionProgress[1].Completed.Should().BeTrue();
                episodesCollectionProgress[1].LastWatchedAt.Should().Be(DateTime.Parse("2011-04-19T02:00:00.000Z").ToUniversalTime());
            }
        }

        [Fact]
        public void Test_TraktSeasonWatchedProgressObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_2()
        {
            var traktJsonReader = new TraktSeasonWatchedProgressObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSeasonWatchedProgress = traktJsonReader.ReadObject(jsonReader);

                traktSeasonWatchedProgress.Should().NotBeNull();
                traktSeasonWatchedProgress.Number.Should().Be(2);
                traktSeasonWatchedProgress.Aired.Should().BeNull();
                traktSeasonWatchedProgress.Completed.Should().Be(2);
                traktSeasonWatchedProgress.Episodes.Should().NotBeNull().And.HaveCount(2);

                var episodesCollectionProgress = traktSeasonWatchedProgress.Episodes.ToArray();

                episodesCollectionProgress[0].Should().NotBeNull();
                episodesCollectionProgress[0].Number.Should().Be(1);
                episodesCollectionProgress[0].Completed.Should().BeTrue();
                episodesCollectionProgress[0].LastWatchedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

                episodesCollectionProgress[1].Should().NotBeNull();
                episodesCollectionProgress[1].Number.Should().Be(2);
                episodesCollectionProgress[1].Completed.Should().BeTrue();
                episodesCollectionProgress[1].LastWatchedAt.Should().Be(DateTime.Parse("2011-04-19T02:00:00.000Z").ToUniversalTime());
            }
        }

        [Fact]
        public void Test_TraktSeasonWatchedProgressObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_3()
        {
            var traktJsonReader = new TraktSeasonWatchedProgressObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSeasonWatchedProgress = traktJsonReader.ReadObject(jsonReader);

                traktSeasonWatchedProgress.Should().NotBeNull();
                traktSeasonWatchedProgress.Number.Should().Be(2);
                traktSeasonWatchedProgress.Aired.Should().Be(3);
                traktSeasonWatchedProgress.Completed.Should().BeNull();
                traktSeasonWatchedProgress.Episodes.Should().NotBeNull().And.HaveCount(2);

                var episodesCollectionProgress = traktSeasonWatchedProgress.Episodes.ToArray();

                episodesCollectionProgress[0].Should().NotBeNull();
                episodesCollectionProgress[0].Number.Should().Be(1);
                episodesCollectionProgress[0].Completed.Should().BeTrue();
                episodesCollectionProgress[0].LastWatchedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

                episodesCollectionProgress[1].Should().NotBeNull();
                episodesCollectionProgress[1].Number.Should().Be(2);
                episodesCollectionProgress[1].Completed.Should().BeTrue();
                episodesCollectionProgress[1].LastWatchedAt.Should().Be(DateTime.Parse("2011-04-19T02:00:00.000Z").ToUniversalTime());
            }
        }

        [Fact]
        public void Test_TraktSeasonWatchedProgressObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_4()
        {
            var traktJsonReader = new TraktSeasonWatchedProgressObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSeasonWatchedProgress = traktJsonReader.ReadObject(jsonReader);

                traktSeasonWatchedProgress.Should().NotBeNull();
                traktSeasonWatchedProgress.Number.Should().Be(2);
                traktSeasonWatchedProgress.Aired.Should().Be(3);
                traktSeasonWatchedProgress.Completed.Should().Be(2);
                traktSeasonWatchedProgress.Episodes.Should().BeNull();
            }
        }

        [Fact]
        public void Test_TraktSeasonWatchedProgressObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_5()
        {
            var traktJsonReader = new TraktSeasonWatchedProgressObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_5))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSeasonWatchedProgress = traktJsonReader.ReadObject(jsonReader);

                traktSeasonWatchedProgress.Should().NotBeNull();
                traktSeasonWatchedProgress.Number.Should().BeNull();
                traktSeasonWatchedProgress.Aired.Should().BeNull();
                traktSeasonWatchedProgress.Completed.Should().BeNull();
                traktSeasonWatchedProgress.Episodes.Should().BeNull();
            }
        }

        [Fact]
        public void Test_TraktSeasonWatchedProgressObjectJsonReader_ReadObject_From_JsonReader_Null()
        {
            var jsonReader = new TraktSeasonWatchedProgressObjectJsonReader();

            var traktSeasonWatchedProgress = jsonReader.ReadObject(default(JsonTextReader));
            traktSeasonWatchedProgress.Should().BeNull();
        }

        [Fact]
        public void Test_TraktSeasonWatchedProgressObjectJsonReader_ReadObject_From_JsonReader_Empty()
        {
            var traktJsonReader = new TraktSeasonWatchedProgressObjectJsonReader();

            using (var reader = new StringReader(string.Empty))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSeasonWatchedProgress = traktJsonReader.ReadObject(jsonReader);
                traktSeasonWatchedProgress.Should().BeNull();
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
                    ""last_watched_at"": ""2011-04-18T01:00:00.000Z""
                  },
                  {
                    ""number"": 2,
                    ""completed"": true,
                    ""last_watched_at"": ""2011-04-19T02:00:00.000Z""
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
                    ""last_watched_at"": ""2011-04-18T01:00:00.000Z""
                  },
                  {
                    ""number"": 2,
                    ""completed"": true,
                    ""last_watched_at"": ""2011-04-19T02:00:00.000Z""
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
                    ""last_watched_at"": ""2011-04-18T01:00:00.000Z""
                  },
                  {
                    ""number"": 2,
                    ""completed"": true,
                    ""last_watched_at"": ""2011-04-19T02:00:00.000Z""
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
                    ""last_watched_at"": ""2011-04-18T01:00:00.000Z""
                  },
                  {
                    ""number"": 2,
                    ""completed"": true,
                    ""last_watched_at"": ""2011-04-19T02:00:00.000Z""
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
                    ""last_watched_at"": ""2011-04-18T01:00:00.000Z""
                  },
                  {
                    ""number"": 2,
                    ""completed"": true,
                    ""last_watched_at"": ""2011-04-19T02:00:00.000Z""
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
                    ""last_watched_at"": ""2011-04-18T01:00:00.000Z""
                  },
                  {
                    ""number"": 2,
                    ""completed"": true,
                    ""last_watched_at"": ""2011-04-19T02:00:00.000Z""
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
                    ""last_watched_at"": ""2011-04-18T01:00:00.000Z""
                  },
                  {
                    ""number"": 2,
                    ""completed"": true,
                    ""last_watched_at"": ""2011-04-19T02:00:00.000Z""
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
                    ""last_watched_at"": ""2011-04-18T01:00:00.000Z""
                  },
                  {
                    ""number"": 2,
                    ""completed"": true,
                    ""last_watched_at"": ""2011-04-19T02:00:00.000Z""
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
                    ""last_watched_at"": ""2011-04-18T01:00:00.000Z""
                  },
                  {
                    ""number"": 2,
                    ""completed"": true,
                    ""last_watched_at"": ""2011-04-19T02:00:00.000Z""
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
                    ""last_watched_at"": ""2011-04-18T01:00:00.000Z""
                  },
                  {
                    ""number"": 2,
                    ""completed"": true,
                    ""last_watched_at"": ""2011-04-19T02:00:00.000Z""
                  }
                ]
              }";
    }
}

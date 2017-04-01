namespace TraktApiSharp.Tests.Objects.Get.Episodes.JsonReader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Linq;
    using Traits;
    using TraktApiSharp.Objects.Get.Episodes;
    using TraktApiSharp.Objects.Get.Episodes.JsonReader;
    using TraktApiSharp.Objects.JsonReader;
    using Xunit;

    [Category("Objects.Get.Episodes.JsonReader")]
    public class ITraktEpisodeCollectionProgressArrayJsonReader_Tests
    {
        [Fact]
        public void Test_ITraktEpisodeCollectionProgressArrayJsonReader_Implements_ITraktArrayJsonReader_Interface()
        {
            typeof(ITraktEpisodeCollectionProgressArrayJsonReader).GetInterfaces().Should().Contain(typeof(ITraktArrayJsonReader<ITraktEpisodeCollectionProgress>));
        }

        [Fact]
        public void Test_ITraktEpisodeCollectionProgressArrayJsonReader_ReadArray_From_Json_String_Empty_Array()
        {
            var jsonReader = new ITraktEpisodeCollectionProgressArrayJsonReader();

            var traktEpisodeCollectionProgresses = jsonReader.ReadArray(JSON_EMPTY_ARRAY);
            traktEpisodeCollectionProgresses.Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public void Test_ITraktEpisodeCollectionProgressArrayJsonReader_ReadArray_From_Json_String_Complete()
        {
            var jsonReader = new ITraktEpisodeCollectionProgressArrayJsonReader();

            var traktEpisodeCollectionProgresses = jsonReader.ReadArray(JSON_COMPLETE);
            traktEpisodeCollectionProgresses.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(3);

            var collectionProgress = traktEpisodeCollectionProgresses.ToArray();

            collectionProgress[0].Number.Should().Be(1);
            collectionProgress[0].Completed.Should().BeTrue();
            collectionProgress[0].CollectedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

            collectionProgress[1].Number.Should().Be(2);
            collectionProgress[1].Completed.Should().BeTrue();
            collectionProgress[1].CollectedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

            collectionProgress[2].Number.Should().Be(3);
            collectionProgress[2].Completed.Should().BeTrue();
            collectionProgress[2].CollectedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());
        }

        [Fact]
        public void Test_ITraktEpisodeCollectionProgressArrayJsonReader_ReadArray_From_Json_String_Incomplete_1()
        {
            var jsonReader = new ITraktEpisodeCollectionProgressArrayJsonReader();

            var traktEpisodeCollectionProgresses = jsonReader.ReadArray(JSON_INCOMPLETE_1);
            traktEpisodeCollectionProgresses.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(3);

            var collectionProgress = traktEpisodeCollectionProgresses.ToArray();

            collectionProgress[0].Number.Should().BeNull();
            collectionProgress[0].Completed.Should().BeTrue();
            collectionProgress[0].CollectedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

            collectionProgress[1].Number.Should().Be(2);
            collectionProgress[1].Completed.Should().BeTrue();
            collectionProgress[1].CollectedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

            collectionProgress[2].Number.Should().Be(3);
            collectionProgress[2].Completed.Should().BeTrue();
            collectionProgress[2].CollectedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());
        }

        [Fact]
        public void Test_ITraktEpisodeCollectionProgressArrayJsonReader_ReadArray_From_Json_String_Incomplete_2()
        {
            var jsonReader = new ITraktEpisodeCollectionProgressArrayJsonReader();

            var traktEpisodeCollectionProgresses = jsonReader.ReadArray(JSON_INCOMPLETE_2);
            traktEpisodeCollectionProgresses.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(3);

            var collectionProgress = traktEpisodeCollectionProgresses.ToArray();

            collectionProgress[0].Number.Should().Be(1);
            collectionProgress[0].Completed.Should().BeTrue();
            collectionProgress[0].CollectedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

            collectionProgress[1].Number.Should().Be(2);
            collectionProgress[1].Completed.Should().BeNull();
            collectionProgress[1].CollectedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

            collectionProgress[2].Number.Should().Be(3);
            collectionProgress[2].Completed.Should().BeTrue();
            collectionProgress[2].CollectedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());
        }

        [Fact]
        public void Test_ITraktEpisodeCollectionProgressArrayJsonReader_ReadArray_From_Json_String_Incomplete_3()
        {
            var jsonReader = new ITraktEpisodeCollectionProgressArrayJsonReader();

            var traktEpisodeCollectionProgresses = jsonReader.ReadArray(JSON_INCOMPLETE_3);
            traktEpisodeCollectionProgresses.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(3);

            var collectionProgress = traktEpisodeCollectionProgresses.ToArray();

            collectionProgress[0].Number.Should().Be(1);
            collectionProgress[0].Completed.Should().BeTrue();
            collectionProgress[0].CollectedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

            collectionProgress[1].Number.Should().Be(2);
            collectionProgress[1].Completed.Should().BeTrue();
            collectionProgress[1].CollectedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

            collectionProgress[2].Number.Should().Be(3);
            collectionProgress[2].Completed.Should().BeTrue();
            collectionProgress[2].CollectedAt.Should().BeNull();
        }

        [Fact]
        public void Test_ITraktEpisodeCollectionProgressArrayJsonReader_ReadArray_From_Json_String_Incomplete_4()
        {
            var jsonReader = new ITraktEpisodeCollectionProgressArrayJsonReader();

            var traktEpisodeCollectionProgresses = jsonReader.ReadArray(JSON_INCOMPLETE_4);
            traktEpisodeCollectionProgresses.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(3);

            var collectionProgress = traktEpisodeCollectionProgresses.ToArray();

            collectionProgress[0].Number.Should().Be(1);
            collectionProgress[0].Completed.Should().BeNull();
            collectionProgress[0].CollectedAt.Should().BeNull();

            collectionProgress[1].Number.Should().Be(2);
            collectionProgress[1].Completed.Should().BeTrue();
            collectionProgress[1].CollectedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

            collectionProgress[2].Number.Should().Be(3);
            collectionProgress[2].Completed.Should().BeTrue();
            collectionProgress[2].CollectedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());
        }

        [Fact]
        public void Test_ITraktEpisodeCollectionProgressArrayJsonReader_ReadArray_From_Json_String_Incomplete_5()
        {
            var jsonReader = new ITraktEpisodeCollectionProgressArrayJsonReader();

            var traktEpisodeCollectionProgresses = jsonReader.ReadArray(JSON_INCOMPLETE_5);
            traktEpisodeCollectionProgresses.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(3);

            var collectionProgress = traktEpisodeCollectionProgresses.ToArray();

            collectionProgress[0].Number.Should().Be(1);
            collectionProgress[0].Completed.Should().BeTrue();
            collectionProgress[0].CollectedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

            collectionProgress[1].Number.Should().BeNull();
            collectionProgress[1].Completed.Should().BeTrue();
            collectionProgress[1].CollectedAt.Should().BeNull();

            collectionProgress[2].Number.Should().Be(3);
            collectionProgress[2].Completed.Should().BeTrue();
            collectionProgress[2].CollectedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());
        }

        [Fact]
        public void Test_ITraktEpisodeCollectionProgressArrayJsonReader_ReadArray_From_Json_String_Incomplete_6()
        {
            var jsonReader = new ITraktEpisodeCollectionProgressArrayJsonReader();

            var traktEpisodeCollectionProgresses = jsonReader.ReadArray(JSON_INCOMPLETE_6);
            traktEpisodeCollectionProgresses.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(3);

            var collectionProgress = traktEpisodeCollectionProgresses.ToArray();

            collectionProgress[0].Number.Should().Be(1);
            collectionProgress[0].Completed.Should().BeTrue();
            collectionProgress[0].CollectedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

            collectionProgress[1].Number.Should().Be(2);
            collectionProgress[1].Completed.Should().BeTrue();
            collectionProgress[1].CollectedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

            collectionProgress[2].Number.Should().BeNull();
            collectionProgress[2].Completed.Should().BeNull();
            collectionProgress[2].CollectedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());
        }

        [Fact]
        public void Test_ITraktEpisodeCollectionProgressArrayJsonReader_ReadArray_From_Json_String_Not_Valid_1()
        {
            var jsonReader = new ITraktEpisodeCollectionProgressArrayJsonReader();

            var traktEpisodeCollectionProgresses = jsonReader.ReadArray(JSON_NOT_VALID_1);
            traktEpisodeCollectionProgresses.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(3);

            var collectionProgress = traktEpisodeCollectionProgresses.ToArray();

            collectionProgress[0].Number.Should().BeNull();
            collectionProgress[0].Completed.Should().BeTrue();
            collectionProgress[0].CollectedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

            collectionProgress[1].Number.Should().Be(2);
            collectionProgress[1].Completed.Should().BeTrue();
            collectionProgress[1].CollectedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

            collectionProgress[2].Number.Should().Be(3);
            collectionProgress[2].Completed.Should().BeTrue();
            collectionProgress[2].CollectedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());
        }

        [Fact]
        public void Test_ITraktEpisodeCollectionProgressArrayJsonReader_ReadArray_From_Json_String_Not_Valid_2()
        {
            var jsonReader = new ITraktEpisodeCollectionProgressArrayJsonReader();

            var traktEpisodeCollectionProgresses = jsonReader.ReadArray(JSON_NOT_VALID_2);
            traktEpisodeCollectionProgresses.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(3);

            var collectionProgress = traktEpisodeCollectionProgresses.ToArray();

            collectionProgress[0].Number.Should().Be(1);
            collectionProgress[0].Completed.Should().BeTrue();
            collectionProgress[0].CollectedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

            collectionProgress[1].Number.Should().Be(2);
            collectionProgress[1].Completed.Should().BeNull();
            collectionProgress[1].CollectedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

            collectionProgress[2].Number.Should().Be(3);
            collectionProgress[2].Completed.Should().BeTrue();
            collectionProgress[2].CollectedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());
        }

        [Fact]
        public void Test_ITraktEpisodeCollectionProgressArrayJsonReader_ReadArray_From_Json_String_Not_Valid_3()
        {
            var jsonReader = new ITraktEpisodeCollectionProgressArrayJsonReader();

            var traktEpisodeCollectionProgresses = jsonReader.ReadArray(JSON_NOT_VALID_3);
            traktEpisodeCollectionProgresses.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(3);

            var collectionProgress = traktEpisodeCollectionProgresses.ToArray();

            collectionProgress[0].Number.Should().Be(1);
            collectionProgress[0].Completed.Should().BeTrue();
            collectionProgress[0].CollectedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

            collectionProgress[1].Number.Should().Be(2);
            collectionProgress[1].Completed.Should().BeTrue();
            collectionProgress[1].CollectedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

            collectionProgress[2].Number.Should().Be(3);
            collectionProgress[2].Completed.Should().BeTrue();
            collectionProgress[2].CollectedAt.Should().BeNull();
        }

        [Fact]
        public void Test_ITraktEpisodeCollectionProgressArrayJsonReader_ReadArray_From_Json_String_Not_Valid_4()
        {
            var jsonReader = new ITraktEpisodeCollectionProgressArrayJsonReader();

            var traktEpisodeCollectionProgresses = jsonReader.ReadArray(JSON_NOT_VALID_4);
            traktEpisodeCollectionProgresses.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(3);

            var collectionProgress = traktEpisodeCollectionProgresses.ToArray();

            collectionProgress[0].Number.Should().BeNull();
            collectionProgress[0].Completed.Should().BeTrue();
            collectionProgress[0].CollectedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

            collectionProgress[1].Number.Should().Be(2);
            collectionProgress[1].Completed.Should().BeNull();
            collectionProgress[1].CollectedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

            collectionProgress[2].Number.Should().Be(3);
            collectionProgress[2].Completed.Should().BeTrue();
            collectionProgress[2].CollectedAt.Should().BeNull();
        }

        [Fact]
        public void Test_ITraktEpisodeCollectionProgressArrayJsonReader_ReadArray_From_Json_String_Null()
        {
            var jsonReader = new ITraktEpisodeCollectionProgressArrayJsonReader();

            var traktEpisodeCollectionProgress = jsonReader.ReadArray(default(string));
            traktEpisodeCollectionProgress.Should().BeNull();
        }

        [Fact]
        public void Test_ITraktEpisodeCollectionProgressArrayJsonReader_ReadArray_From_Json_String_Empty()
        {
            var jsonReader = new ITraktEpisodeCollectionProgressArrayJsonReader();

            var traktEpisodeCollectionProgress = jsonReader.ReadArray(string.Empty);
            traktEpisodeCollectionProgress.Should().BeNull();
        }

        [Fact]
        public void Test_ITraktEpisodeCollectionProgressArrayJsonReader_ReadArray_From_JsonReader_Empty_Array()
        {
            var traktJsonReader = new ITraktEpisodeCollectionProgressArrayJsonReader();

            using (var reader = new StringReader(JSON_EMPTY_ARRAY))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisodeCollectionProgresses = traktJsonReader.ReadArray(jsonReader);
                traktEpisodeCollectionProgresses.Should().NotBeNull().And.BeEmpty();
            }
        }

        [Fact]
        public void Test_ITraktEpisodeCollectionProgressArrayJsonReader_ReadArray_From_JsonReader_Complete()
        {
            var traktJsonReader = new ITraktEpisodeCollectionProgressArrayJsonReader();

            using (var reader = new StringReader(JSON_COMPLETE))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisodeCollectionProgresses = traktJsonReader.ReadArray(jsonReader);
                traktEpisodeCollectionProgresses.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(3);

                var collectionProgress = traktEpisodeCollectionProgresses.ToArray();

                collectionProgress[0].Number.Should().Be(1);
                collectionProgress[0].Completed.Should().BeTrue();
                collectionProgress[0].CollectedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

                collectionProgress[1].Number.Should().Be(2);
                collectionProgress[1].Completed.Should().BeTrue();
                collectionProgress[1].CollectedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

                collectionProgress[2].Number.Should().Be(3);
                collectionProgress[2].Completed.Should().BeTrue();
                collectionProgress[2].CollectedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());
            }
        }

        [Fact]
        public void Test_ITraktEpisodeCollectionProgressArrayJsonReader_ReadArray_From_JsonReader_Incomplete_1()
        {
            var traktJsonReader = new ITraktEpisodeCollectionProgressArrayJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisodeCollectionProgresses = traktJsonReader.ReadArray(jsonReader);
                traktEpisodeCollectionProgresses.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(3);

                var collectionProgress = traktEpisodeCollectionProgresses.ToArray();

                collectionProgress[0].Number.Should().BeNull();
                collectionProgress[0].Completed.Should().BeTrue();
                collectionProgress[0].CollectedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

                collectionProgress[1].Number.Should().Be(2);
                collectionProgress[1].Completed.Should().BeTrue();
                collectionProgress[1].CollectedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

                collectionProgress[2].Number.Should().Be(3);
                collectionProgress[2].Completed.Should().BeTrue();
                collectionProgress[2].CollectedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());
            }
        }

        [Fact]
        public void Test_ITraktEpisodeCollectionProgressArrayJsonReader_ReadArray_From_JsonReader_Incomplete_2()
        {
            var traktJsonReader = new ITraktEpisodeCollectionProgressArrayJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisodeCollectionProgresses = traktJsonReader.ReadArray(jsonReader);
                traktEpisodeCollectionProgresses.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(3);

                var collectionProgress = traktEpisodeCollectionProgresses.ToArray();

                collectionProgress[0].Number.Should().Be(1);
                collectionProgress[0].Completed.Should().BeTrue();
                collectionProgress[0].CollectedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

                collectionProgress[1].Number.Should().Be(2);
                collectionProgress[1].Completed.Should().BeNull();
                collectionProgress[1].CollectedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

                collectionProgress[2].Number.Should().Be(3);
                collectionProgress[2].Completed.Should().BeTrue();
                collectionProgress[2].CollectedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());
            }
        }

        [Fact]
        public void Test_ITraktEpisodeCollectionProgressArrayJsonReader_ReadArray_From_JsonReader_Incomplete_3()
        {
            var traktJsonReader = new ITraktEpisodeCollectionProgressArrayJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisodeCollectionProgresses = traktJsonReader.ReadArray(jsonReader);
                traktEpisodeCollectionProgresses.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(3);

                var collectionProgress = traktEpisodeCollectionProgresses.ToArray();

                collectionProgress[0].Number.Should().Be(1);
                collectionProgress[0].Completed.Should().BeTrue();
                collectionProgress[0].CollectedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

                collectionProgress[1].Number.Should().Be(2);
                collectionProgress[1].Completed.Should().BeTrue();
                collectionProgress[1].CollectedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

                collectionProgress[2].Number.Should().Be(3);
                collectionProgress[2].Completed.Should().BeTrue();
                collectionProgress[2].CollectedAt.Should().BeNull();
            }
        }

        [Fact]
        public void Test_ITraktEpisodeCollectionProgressArrayJsonReader_ReadArray_From_JsonReader_Incomplete_4()
        {
            var traktJsonReader = new ITraktEpisodeCollectionProgressArrayJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisodeCollectionProgresses = traktJsonReader.ReadArray(jsonReader);
                traktEpisodeCollectionProgresses.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(3);

                var collectionProgress = traktEpisodeCollectionProgresses.ToArray();

                collectionProgress[0].Number.Should().Be(1);
                collectionProgress[0].Completed.Should().BeNull();
                collectionProgress[0].CollectedAt.Should().BeNull();

                collectionProgress[1].Number.Should().Be(2);
                collectionProgress[1].Completed.Should().BeTrue();
                collectionProgress[1].CollectedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

                collectionProgress[2].Number.Should().Be(3);
                collectionProgress[2].Completed.Should().BeTrue();
                collectionProgress[2].CollectedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());
            }
        }

        [Fact]
        public void Test_ITraktEpisodeCollectionProgressArrayJsonReader_ReadArray_From_JsonReader_Incomplete_5()
        {
            var traktJsonReader = new ITraktEpisodeCollectionProgressArrayJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_5))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisodeCollectionProgresses = traktJsonReader.ReadArray(jsonReader);
                traktEpisodeCollectionProgresses.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(3);

                var collectionProgress = traktEpisodeCollectionProgresses.ToArray();

                collectionProgress[0].Number.Should().Be(1);
                collectionProgress[0].Completed.Should().BeTrue();
                collectionProgress[0].CollectedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

                collectionProgress[1].Number.Should().BeNull();
                collectionProgress[1].Completed.Should().BeTrue();
                collectionProgress[1].CollectedAt.Should().BeNull();

                collectionProgress[2].Number.Should().Be(3);
                collectionProgress[2].Completed.Should().BeTrue();
                collectionProgress[2].CollectedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());
            }
        }

        [Fact]
        public void Test_ITraktEpisodeCollectionProgressArrayJsonReader_ReadArray_From_JsonReader_Incomplete_6()
        {
            var traktJsonReader = new ITraktEpisodeCollectionProgressArrayJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_6))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisodeCollectionProgresses = traktJsonReader.ReadArray(jsonReader);
                traktEpisodeCollectionProgresses.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(3);

                var collectionProgress = traktEpisodeCollectionProgresses.ToArray();

                collectionProgress[0].Number.Should().Be(1);
                collectionProgress[0].Completed.Should().BeTrue();
                collectionProgress[0].CollectedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

                collectionProgress[1].Number.Should().Be(2);
                collectionProgress[1].Completed.Should().BeTrue();
                collectionProgress[1].CollectedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

                collectionProgress[2].Number.Should().BeNull();
                collectionProgress[2].Completed.Should().BeNull();
                collectionProgress[2].CollectedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());
            }
        }

        [Fact]
        public void Test_ITraktEpisodeCollectionProgressArrayJsonReader_ReadArray_From_JsonReader_Not_Valid_1()
        {
            var traktJsonReader = new ITraktEpisodeCollectionProgressArrayJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisodeCollectionProgresses = traktJsonReader.ReadArray(jsonReader);
                traktEpisodeCollectionProgresses.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(3);

                var collectionProgress = traktEpisodeCollectionProgresses.ToArray();

                collectionProgress[0].Number.Should().BeNull();
                collectionProgress[0].Completed.Should().BeTrue();
                collectionProgress[0].CollectedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

                collectionProgress[1].Number.Should().Be(2);
                collectionProgress[1].Completed.Should().BeTrue();
                collectionProgress[1].CollectedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

                collectionProgress[2].Number.Should().Be(3);
                collectionProgress[2].Completed.Should().BeTrue();
                collectionProgress[2].CollectedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());
            }
        }

        [Fact]
        public void Test_ITraktEpisodeCollectionProgressArrayJsonReader_ReadArray_From_JsonReader_Not_Valid_2()
        {
            var traktJsonReader = new ITraktEpisodeCollectionProgressArrayJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisodeCollectionProgresses = traktJsonReader.ReadArray(jsonReader);
                traktEpisodeCollectionProgresses.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(3);

                var collectionProgress = traktEpisodeCollectionProgresses.ToArray();

                collectionProgress[0].Number.Should().Be(1);
                collectionProgress[0].Completed.Should().BeTrue();
                collectionProgress[0].CollectedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

                collectionProgress[1].Number.Should().Be(2);
                collectionProgress[1].Completed.Should().BeNull();
                collectionProgress[1].CollectedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

                collectionProgress[2].Number.Should().Be(3);
                collectionProgress[2].Completed.Should().BeTrue();
                collectionProgress[2].CollectedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());
            }
        }

        [Fact]
        public void Test_ITraktEpisodeCollectionProgressArrayJsonReader_ReadArray_From_JsonReader_Not_Valid_3()
        {
            var traktJsonReader = new ITraktEpisodeCollectionProgressArrayJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisodeCollectionProgresses = traktJsonReader.ReadArray(jsonReader);
                traktEpisodeCollectionProgresses.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(3);

                var collectionProgress = traktEpisodeCollectionProgresses.ToArray();

                collectionProgress[0].Number.Should().Be(1);
                collectionProgress[0].Completed.Should().BeTrue();
                collectionProgress[0].CollectedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

                collectionProgress[1].Number.Should().Be(2);
                collectionProgress[1].Completed.Should().BeTrue();
                collectionProgress[1].CollectedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

                collectionProgress[2].Number.Should().Be(3);
                collectionProgress[2].Completed.Should().BeTrue();
                collectionProgress[2].CollectedAt.Should().BeNull();
            }
        }

        [Fact]
        public void Test_ITraktEpisodeCollectionProgressArrayJsonReader_ReadArray_From_JsonReader_Not_Valid_4()
        {
            var traktJsonReader = new ITraktEpisodeCollectionProgressArrayJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisodeCollectionProgresses = traktJsonReader.ReadArray(jsonReader);
                traktEpisodeCollectionProgresses.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(3);

                var collectionProgress = traktEpisodeCollectionProgresses.ToArray();

                collectionProgress[0].Number.Should().BeNull();
                collectionProgress[0].Completed.Should().BeTrue();
                collectionProgress[0].CollectedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

                collectionProgress[1].Number.Should().Be(2);
                collectionProgress[1].Completed.Should().BeNull();
                collectionProgress[1].CollectedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

                collectionProgress[2].Number.Should().Be(3);
                collectionProgress[2].Completed.Should().BeTrue();
                collectionProgress[2].CollectedAt.Should().BeNull();
            }
        }

        [Fact]
        public void Test_ITraktEpisodeCollectionProgressArrayJsonReader_ReadArray_From_JsonReader_Null()
        {
            var jsonReader = new ITraktEpisodeCollectionProgressArrayJsonReader();

            var traktEpisodeCollectionProgress = jsonReader.ReadArray(default(JsonTextReader));
            traktEpisodeCollectionProgress.Should().BeNull();
        }

        [Fact]
        public void Test_ITraktEpisodeCollectionProgressArrayJsonReader_ReadArray_From_JsonReader_Empty()
        {
            var traktJsonReader = new ITraktEpisodeCollectionProgressArrayJsonReader();

            using (var reader = new StringReader(string.Empty))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisodeCollectionProgress = traktJsonReader.ReadArray(jsonReader);
                traktEpisodeCollectionProgress.Should().BeNull();
            }
        }

        private const string JSON_EMPTY_ARRAY = @"[]";

        private const string JSON_COMPLETE =
            @"[
                {
                  ""number"": 1,
                  ""completed"": true,
                  ""collected_at"": ""2011-04-18T01:00:00.000Z""
                },
                {
                  ""number"": 2,
                  ""completed"": true,
                  ""collected_at"": ""2011-04-18T01:00:00.000Z""
                },
                {
                  ""number"": 3,
                  ""completed"": true,
                  ""collected_at"": ""2011-04-18T01:00:00.000Z""
                }
              ]";

        private const string JSON_INCOMPLETE_1 =
            @"[
                {
                  ""completed"": true,
                  ""collected_at"": ""2011-04-18T01:00:00.000Z""
                },
                {
                  ""number"": 2,
                  ""completed"": true,
                  ""collected_at"": ""2011-04-18T01:00:00.000Z""
                },
                {
                  ""number"": 3,
                  ""completed"": true,
                  ""collected_at"": ""2011-04-18T01:00:00.000Z""
                }
              ]";

        private const string JSON_INCOMPLETE_2 =
            @"[
                {
                  ""number"": 1,
                  ""completed"": true,
                  ""collected_at"": ""2011-04-18T01:00:00.000Z""
                },
                {
                  ""number"": 2,
                  ""collected_at"": ""2011-04-18T01:00:00.000Z""
                },
                {
                  ""number"": 3,
                  ""completed"": true,
                  ""collected_at"": ""2011-04-18T01:00:00.000Z""
                }
              ]";

        private const string JSON_INCOMPLETE_3 =
            @"[
                {
                  ""number"": 1,
                  ""completed"": true,
                  ""collected_at"": ""2011-04-18T01:00:00.000Z""
                },
                {
                  ""number"": 2,
                  ""completed"": true,
                  ""collected_at"": ""2011-04-18T01:00:00.000Z""
                },
                {
                  ""number"": 3,
                  ""completed"": true
                }
              ]";

        private const string JSON_INCOMPLETE_4 =
            @"[
                {
                  ""number"": 1
                },
                {
                  ""number"": 2,
                  ""completed"": true,
                  ""collected_at"": ""2011-04-18T01:00:00.000Z""
                },
                {
                  ""number"": 3,
                  ""completed"": true,
                  ""collected_at"": ""2011-04-18T01:00:00.000Z""
                }
              ]";

        private const string JSON_INCOMPLETE_5 =
            @"[
                {
                  ""number"": 1,
                  ""completed"": true,
                  ""collected_at"": ""2011-04-18T01:00:00.000Z""
                },
                {
                  ""completed"": true
                },
                {
                  ""number"": 3,
                  ""completed"": true,
                  ""collected_at"": ""2011-04-18T01:00:00.000Z""
                }
              ]";

        private const string JSON_INCOMPLETE_6 =
            @"[
                {
                  ""number"": 1,
                  ""completed"": true,
                  ""collected_at"": ""2011-04-18T01:00:00.000Z""
                },
                {
                  ""number"": 2,
                  ""completed"": true,
                  ""collected_at"": ""2011-04-18T01:00:00.000Z""
                },
                {
                  ""collected_at"": ""2011-04-18T01:00:00.000Z""
                }
              ]";

        private const string JSON_NOT_VALID_1 =
            @"[
                {
                  ""nu"": 1,
                  ""completed"": true,
                  ""collected_at"": ""2011-04-18T01:00:00.000Z""
                },
                {
                  ""number"": 2,
                  ""completed"": true,
                  ""collected_at"": ""2011-04-18T01:00:00.000Z""
                },
                {
                  ""number"": 3,
                  ""completed"": true,
                  ""collected_at"": ""2011-04-18T01:00:00.000Z""
                }
              ]";

        private const string JSON_NOT_VALID_2 =
            @"[
                {
                  ""number"": 1,
                  ""completed"": true,
                  ""collected_at"": ""2011-04-18T01:00:00.000Z""
                },
                {
                  ""number"": 2,
                  ""com"": true,
                  ""collected_at"": ""2011-04-18T01:00:00.000Z""
                },
                {
                  ""number"": 3,
                  ""completed"": true,
                  ""collected_at"": ""2011-04-18T01:00:00.000Z""
                }
              ]";

        private const string JSON_NOT_VALID_3 =
            @"[
                {
                  ""number"": 1,
                  ""completed"": true,
                  ""collected_at"": ""2011-04-18T01:00:00.000Z""
                },
                {
                  ""number"": 2,
                  ""completed"": true,
                  ""collected_at"": ""2011-04-18T01:00:00.000Z""
                },
                {
                  ""number"": 3,
                  ""completed"": true,
                  ""colat"": ""2011-04-18T01:00:00.000Z""
                }
              ]";

        private const string JSON_NOT_VALID_4 =
            @"[
                {
                  ""nu"": 1,
                  ""completed"": true,
                  ""collected_at"": ""2011-04-18T01:00:00.000Z""
                },
                {
                  ""number"": 2,
                  ""com"": true,
                  ""collected_at"": ""2011-04-18T01:00:00.000Z""
                },
                {
                  ""number"": 3,
                  ""completed"": true,
                  ""colat"": ""2011-04-18T01:00:00.000Z""
                }
              ]";
    }
}

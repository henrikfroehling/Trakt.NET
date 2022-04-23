﻿namespace TraktNet.Objects.Get.Tests.Episodes.Json.Reader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Episodes;
    using TraktNet.Objects.Json;
    using Xunit;

    [Category("Objects.Get.Episodes.JsonReader")]
    public partial class EpisodeCollectionProgressArrayJsonReader_Tests
    {
        [Fact]
        public async Task Test_EpisodeCollectionProgressArrayJsonReader_ReadArray_From_JsonReader_Empty_Array()
        {
            var traktJsonReader = new ArrayJsonReader<ITraktEpisodeCollectionProgress>();

            using (var reader = new StringReader(JSON_EMPTY_ARRAY))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisodeCollectionProgresses = await traktJsonReader.ReadArrayAsync(jsonReader);
                traktEpisodeCollectionProgresses.Should().NotBeNull().And.BeEmpty();
            }
        }

        [Fact]
        public async Task Test_EpisodeCollectionProgressArrayJsonReader_ReadArray_From_JsonReader_Complete()
        {
            var traktJsonReader = new ArrayJsonReader<ITraktEpisodeCollectionProgress>();

            using (var reader = new StringReader(JSON_COMPLETE))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisodeCollectionProgresses = await traktJsonReader.ReadArrayAsync(jsonReader);
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
        public async Task Test_EpisodeCollectionProgressArrayJsonReader_ReadArray_From_JsonReader_Incomplete_1()
        {
            var traktJsonReader = new ArrayJsonReader<ITraktEpisodeCollectionProgress>();

            using (var reader = new StringReader(JSON_INCOMPLETE_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisodeCollectionProgresses = await traktJsonReader.ReadArrayAsync(jsonReader);
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
        public async Task Test_EpisodeCollectionProgressArrayJsonReader_ReadArray_From_JsonReader_Incomplete_2()
        {
            var traktJsonReader = new ArrayJsonReader<ITraktEpisodeCollectionProgress>();

            using (var reader = new StringReader(JSON_INCOMPLETE_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisodeCollectionProgresses = await traktJsonReader.ReadArrayAsync(jsonReader);
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
        public async Task Test_EpisodeCollectionProgressArrayJsonReader_ReadArray_From_JsonReader_Incomplete_3()
        {
            var traktJsonReader = new ArrayJsonReader<ITraktEpisodeCollectionProgress>();

            using (var reader = new StringReader(JSON_INCOMPLETE_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisodeCollectionProgresses = await traktJsonReader.ReadArrayAsync(jsonReader);
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
        public async Task Test_EpisodeCollectionProgressArrayJsonReader_ReadArray_From_JsonReader_Incomplete_4()
        {
            var traktJsonReader = new ArrayJsonReader<ITraktEpisodeCollectionProgress>();

            using (var reader = new StringReader(JSON_INCOMPLETE_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisodeCollectionProgresses = await traktJsonReader.ReadArrayAsync(jsonReader);
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
        public async Task Test_EpisodeCollectionProgressArrayJsonReader_ReadArray_From_JsonReader_Incomplete_5()
        {
            var traktJsonReader = new ArrayJsonReader<ITraktEpisodeCollectionProgress>();

            using (var reader = new StringReader(JSON_INCOMPLETE_5))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisodeCollectionProgresses = await traktJsonReader.ReadArrayAsync(jsonReader);
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
        public async Task Test_EpisodeCollectionProgressArrayJsonReader_ReadArray_From_JsonReader_Incomplete_6()
        {
            var traktJsonReader = new ArrayJsonReader<ITraktEpisodeCollectionProgress>();

            using (var reader = new StringReader(JSON_INCOMPLETE_6))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisodeCollectionProgresses = await traktJsonReader.ReadArrayAsync(jsonReader);
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
        public async Task Test_EpisodeCollectionProgressArrayJsonReader_ReadArray_From_JsonReader_Not_Valid_1()
        {
            var traktJsonReader = new ArrayJsonReader<ITraktEpisodeCollectionProgress>();

            using (var reader = new StringReader(JSON_NOT_VALID_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisodeCollectionProgresses = await traktJsonReader.ReadArrayAsync(jsonReader);
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
        public async Task Test_EpisodeCollectionProgressArrayJsonReader_ReadArray_From_JsonReader_Not_Valid_2()
        {
            var traktJsonReader = new ArrayJsonReader<ITraktEpisodeCollectionProgress>();

            using (var reader = new StringReader(JSON_NOT_VALID_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisodeCollectionProgresses = await traktJsonReader.ReadArrayAsync(jsonReader);
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
        public async Task Test_EpisodeCollectionProgressArrayJsonReader_ReadArray_From_JsonReader_Not_Valid_3()
        {
            var traktJsonReader = new ArrayJsonReader<ITraktEpisodeCollectionProgress>();

            using (var reader = new StringReader(JSON_NOT_VALID_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisodeCollectionProgresses = await traktJsonReader.ReadArrayAsync(jsonReader);
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
        public async Task Test_EpisodeCollectionProgressArrayJsonReader_ReadArray_From_JsonReader_Not_Valid_4()
        {
            var traktJsonReader = new ArrayJsonReader<ITraktEpisodeCollectionProgress>();

            using (var reader = new StringReader(JSON_NOT_VALID_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisodeCollectionProgresses = await traktJsonReader.ReadArrayAsync(jsonReader);
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
        public async Task Test_EpisodeCollectionProgressArrayJsonReader_ReadArray_From_JsonReader_Null()
        {
            var traktJsonReader = new ArrayJsonReader<ITraktEpisodeCollectionProgress>();
            Func<Task<IEnumerable<ITraktEpisodeCollectionProgress>>> traktEpisodeCollectionProgress = () => traktJsonReader.ReadArrayAsync(default(JsonTextReader));
            await traktEpisodeCollectionProgress.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_EpisodeCollectionProgressArrayJsonReader_ReadArray_From_JsonReader_Empty()
        {
            var traktJsonReader = new ArrayJsonReader<ITraktEpisodeCollectionProgress>();

            using (var reader = new StringReader(string.Empty))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisodeCollectionProgress = await traktJsonReader.ReadArrayAsync(jsonReader);
                traktEpisodeCollectionProgress.Should().BeNull();
            }
        }
    }
}

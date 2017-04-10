﻿namespace TraktApiSharp.Tests.Objects.Get.Episodes.JsonReader
{
    using FluentAssertions;
    using System;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using TestUtils;
    using Traits;
    using TraktApiSharp.Objects.Get.Episodes.JsonReader;
    using Xunit;

    [Category("Objects.Get.Episodes.JsonReader")]
    public partial class ITraktEpisodeCollectionProgressArrayJsonReader_Tests
    {
        [Fact]
        public async Task Test_ITraktEpisodeCollectionProgressArrayJsonReader_ReadArray_From_Stream_Empty_Array()
        {
            var traktJsonReader = new ITraktEpisodeCollectionProgressArrayJsonReader();

            using (var stream = JSON_EMPTY_ARRAY.ToStream())
            {
                var traktEpisodeCollectionProgresses = await traktJsonReader.ReadArrayAsync(stream);
                traktEpisodeCollectionProgresses.Should().NotBeNull().And.BeEmpty();
            }
        }

        [Fact]
        public async Task Test_ITraktEpisodeCollectionProgressArrayJsonReader_ReadArray_From_Stream_Complete()
        {
            var traktJsonReader = new ITraktEpisodeCollectionProgressArrayJsonReader();

            using (var stream = JSON_COMPLETE.ToStream())
            {
                var traktEpisodeCollectionProgresses = await traktJsonReader.ReadArrayAsync(stream);
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
        public async Task Test_ITraktEpisodeCollectionProgressArrayJsonReader_ReadArray_From_Stream_Incomplete_1()
        {
            var traktJsonReader = new ITraktEpisodeCollectionProgressArrayJsonReader();

            using (var stream = JSON_INCOMPLETE_1.ToStream())
            {
                var traktEpisodeCollectionProgresses = await traktJsonReader.ReadArrayAsync(stream);
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
        public async Task Test_ITraktEpisodeCollectionProgressArrayJsonReader_ReadArray_From_Stream_Incomplete_2()
        {
            var traktJsonReader = new ITraktEpisodeCollectionProgressArrayJsonReader();

            using (var stream = JSON_INCOMPLETE_2.ToStream())
            {
                var traktEpisodeCollectionProgresses = await traktJsonReader.ReadArrayAsync(stream);
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
        public async Task Test_ITraktEpisodeCollectionProgressArrayJsonReader_ReadArray_From_Stream_Incomplete_3()
        {
            var traktJsonReader = new ITraktEpisodeCollectionProgressArrayJsonReader();

            using (var stream = JSON_INCOMPLETE_3.ToStream())
            {
                var traktEpisodeCollectionProgresses = await traktJsonReader.ReadArrayAsync(stream);
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
        public async Task Test_ITraktEpisodeCollectionProgressArrayJsonReader_ReadArray_From_Stream_Incomplete_4()
        {
            var traktJsonReader = new ITraktEpisodeCollectionProgressArrayJsonReader();

            using (var stream = JSON_INCOMPLETE_4.ToStream())
            {
                var traktEpisodeCollectionProgresses = await traktJsonReader.ReadArrayAsync(stream);
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
        public async Task Test_ITraktEpisodeCollectionProgressArrayJsonReader_ReadArray_From_Stream_Incomplete_5()
        {
            var traktJsonReader = new ITraktEpisodeCollectionProgressArrayJsonReader();

            using (var stream = JSON_INCOMPLETE_5.ToStream())
            {
                var traktEpisodeCollectionProgresses = await traktJsonReader.ReadArrayAsync(stream);
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
        public async Task Test_ITraktEpisodeCollectionProgressArrayJsonReader_ReadArray_From_Stream_Incomplete_6()
        {
            var traktJsonReader = new ITraktEpisodeCollectionProgressArrayJsonReader();

            using (var stream = JSON_INCOMPLETE_6.ToStream())
            {
                var traktEpisodeCollectionProgresses = await traktJsonReader.ReadArrayAsync(stream);
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
        public async Task Test_ITraktEpisodeCollectionProgressArrayJsonReader_ReadArray_From_Stream_Not_Valid_1()
        {
            var traktJsonReader = new ITraktEpisodeCollectionProgressArrayJsonReader();

            using (var stream = JSON_NOT_VALID_1.ToStream())
            {
                var traktEpisodeCollectionProgresses = await traktJsonReader.ReadArrayAsync(stream);
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
        public async Task Test_ITraktEpisodeCollectionProgressArrayJsonReader_ReadArray_From_Stream_Not_Valid_2()
        {
            var traktJsonReader = new ITraktEpisodeCollectionProgressArrayJsonReader();

            using (var stream = JSON_NOT_VALID_2.ToStream())
            {
                var traktEpisodeCollectionProgresses = await traktJsonReader.ReadArrayAsync(stream);
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
        public async Task Test_ITraktEpisodeCollectionProgressArrayJsonReader_ReadArray_From_Stream_Not_Valid_3()
        {
            var traktJsonReader = new ITraktEpisodeCollectionProgressArrayJsonReader();

            using (var stream = JSON_NOT_VALID_3.ToStream())
            {
                var traktEpisodeCollectionProgresses = await traktJsonReader.ReadArrayAsync(stream);
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
        public async Task Test_ITraktEpisodeCollectionProgressArrayJsonReader_ReadArray_From_Stream_Not_Valid_4()
        {
            var traktJsonReader = new ITraktEpisodeCollectionProgressArrayJsonReader();

            using (var stream = JSON_NOT_VALID_4.ToStream())
            {
                var traktEpisodeCollectionProgresses = await traktJsonReader.ReadArrayAsync(stream);
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
        public async Task Test_ITraktEpisodeCollectionProgressArrayJsonReader_ReadArray_From_Stream_Null()
        {
            var traktJsonReader = new ITraktEpisodeCollectionProgressArrayJsonReader();

            var traktEpisodeCollectionProgress = await traktJsonReader.ReadArrayAsync(default(Stream));
            traktEpisodeCollectionProgress.Should().BeNull();
        }

        [Fact]
        public async Task Test_ITraktEpisodeCollectionProgressArrayJsonReader_ReadArray_From_Stream_Empty()
        {
            var traktJsonReader = new ITraktEpisodeCollectionProgressArrayJsonReader();

            using (var stream = string.Empty.ToStream())
            {
                var traktEpisodeCollectionProgress = await traktJsonReader.ReadArrayAsync(stream);
                traktEpisodeCollectionProgress.Should().BeNull();
            }
        }
    }
}

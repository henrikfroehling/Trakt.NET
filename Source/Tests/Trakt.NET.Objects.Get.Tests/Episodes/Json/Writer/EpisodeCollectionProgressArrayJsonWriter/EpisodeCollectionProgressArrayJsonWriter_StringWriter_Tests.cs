namespace TraktNet.Objects.Get.Tests.Episodes.Json.Writer
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Extensions;
    using TraktNet.Objects.Get.Episodes;
    using TraktNet.Objects.Json;
    using Xunit;

    [Category("Objects.Get.Episodes.JsonWriter")]
    public partial class EpisodeCollectionProgressArrayJsonWriter_Tests
    {
        [Fact]
        public async Task Test_EpisodeCollectionProgressArrayJsonWriter_WriteArray_StringWriter_Exceptions()
        {
            var traktJsonWriter = new ArrayJsonWriter<ITraktEpisodeCollectionProgress>();
            IEnumerable<ITraktEpisodeCollectionProgress> traktEpisodeCollectionProgresss = new List<TraktEpisodeCollectionProgress>();
            Func<Task<string>> action = () => traktJsonWriter.WriteArrayAsync(default(StringWriter), traktEpisodeCollectionProgresss);
            await action.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_EpisodeCollectionProgressArrayJsonWriter_WriteArray_StringWriter_Empty()
        {
            IEnumerable<ITraktEpisodeCollectionProgress> traktEpisodeCollectionProgresss = new List<TraktEpisodeCollectionProgress>();

            using (var stringWriter = new StringWriter())
            {
                var traktJsonWriter = new ArrayJsonWriter<ITraktEpisodeCollectionProgress>();
                string json = await traktJsonWriter.WriteArrayAsync(stringWriter, traktEpisodeCollectionProgresss);
                json.Should().Be("[]");
            }
        }

        [Fact]
        public async Task Test_EpisodeCollectionProgressArrayJsonWriter_WriteArray_StringWriter_SingleObject()
        {
            IEnumerable<ITraktEpisodeCollectionProgress> traktEpisodeCollectionProgresss = new List<ITraktEpisodeCollectionProgress>
            {
                new TraktEpisodeCollectionProgress
                {
                    Number = 1,
                    Completed = true,
                    CollectedAt = COLLECTED_AT
                }
            };

            using (var stringWriter = new StringWriter())
            {
                var traktJsonWriter = new ArrayJsonWriter<ITraktEpisodeCollectionProgress>();
                string json = await traktJsonWriter.WriteArrayAsync(stringWriter, traktEpisodeCollectionProgresss);
                json.Should().Be($"[{{\"number\":1,\"completed\":true,\"collected_at\":\"{COLLECTED_AT.ToTraktLongDateTimeString()}\"}}]");
            }
        }

        [Fact]
        public async Task Test_EpisodeCollectionProgressArrayJsonWriter_WriteArray_StringWriter_Complete()
        {
            IEnumerable<ITraktEpisodeCollectionProgress> traktEpisodeCollectionProgresss = new List<ITraktEpisodeCollectionProgress>
            {
                new TraktEpisodeCollectionProgress
                {
                    Number = 1,
                    Completed = true,
                    CollectedAt = COLLECTED_AT
                },
                new TraktEpisodeCollectionProgress
                {
                    Number = 2,
                    Completed = true,
                    CollectedAt = COLLECTED_AT
                },
                new TraktEpisodeCollectionProgress
                {
                    Number = 3,
                    Completed = true,
                    CollectedAt = COLLECTED_AT
                }
            };

            using (var stringWriter = new StringWriter())
            {
                var traktJsonWriter = new ArrayJsonWriter<ITraktEpisodeCollectionProgress>();
                string json = await traktJsonWriter.WriteArrayAsync(stringWriter, traktEpisodeCollectionProgresss);
                json.Should().Be($"[{{\"number\":1,\"completed\":true,\"collected_at\":\"{COLLECTED_AT.ToTraktLongDateTimeString()}\"}}," +
                                 $"{{\"number\":2,\"completed\":true,\"collected_at\":\"{COLLECTED_AT.ToTraktLongDateTimeString()}\"}}," +
                                 $"{{\"number\":3,\"completed\":true,\"collected_at\":\"{COLLECTED_AT.ToTraktLongDateTimeString()}\"}}]");
            }
        }
    }
}

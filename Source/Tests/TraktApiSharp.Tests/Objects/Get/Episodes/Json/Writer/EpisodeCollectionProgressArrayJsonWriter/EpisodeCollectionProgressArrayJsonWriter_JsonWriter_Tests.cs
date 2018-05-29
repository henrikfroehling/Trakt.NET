namespace TraktApiSharp.Tests.Objects.Get.Episodes.Json.Writer
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Extensions;
    using TraktApiSharp.Objects.Get.Episodes;
    using TraktApiSharp.Objects.Json;
    using Xunit;

    [Category("Objects.Get.Episodes.JsonWriter")]
    public partial class EpisodeCollectionProgressArrayJsonWriter_Tests
    {
        private static readonly DateTime COLLECTED_AT = DateTime.UtcNow;

        [Fact]
        public void Test_EpisodeCollectionProgressArrayJsonWriter_WriteArray_JsonWriter_Exceptions()
        {
            var traktJsonWriter = new ArrayJsonWriter<ITraktEpisodeCollectionProgress>();
            IEnumerable<ITraktEpisodeCollectionProgress> traktEpisodeCollectionProgresss = new List<TraktEpisodeCollectionProgress>();
            Func<Task> action = () => traktJsonWriter.WriteArrayAsync(default(JsonTextWriter), traktEpisodeCollectionProgresss);
            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_EpisodeCollectionProgressArrayJsonWriter_WriteArray_JsonWriter_Empty()
        {
            IEnumerable<ITraktEpisodeCollectionProgress> traktEpisodeCollectionProgresss = new List<TraktEpisodeCollectionProgress>();

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new ArrayJsonWriter<ITraktEpisodeCollectionProgress>();
                await traktJsonWriter.WriteArrayAsync(jsonWriter, traktEpisodeCollectionProgresss);
                stringWriter.ToString().Should().Be("[]");
            }
        }

        [Fact]
        public async Task Test_EpisodeCollectionProgressArrayJsonWriter_WriteArray_JsonWriter_SingleObject()
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
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new ArrayJsonWriter<ITraktEpisodeCollectionProgress>();
                await traktJsonWriter.WriteArrayAsync(jsonWriter, traktEpisodeCollectionProgresss);
                stringWriter.ToString().Should().Be($"[{{\"number\":1,\"completed\":true,\"collected_at\":\"{COLLECTED_AT.ToTraktLongDateTimeString()}\"}}]");
            }
        }

        [Fact]
        public async Task Test_EpisodeCollectionProgressArrayJsonWriter_WriteArray_JsonWriter_Complete()
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
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new ArrayJsonWriter<ITraktEpisodeCollectionProgress>();
                await traktJsonWriter.WriteArrayAsync(jsonWriter, traktEpisodeCollectionProgresss);
                stringWriter.ToString().Should().Be($"[{{\"number\":1,\"completed\":true,\"collected_at\":\"{COLLECTED_AT.ToTraktLongDateTimeString()}\"}}," +
                                                    $"{{\"number\":2,\"completed\":true,\"collected_at\":\"{COLLECTED_AT.ToTraktLongDateTimeString()}\"}}," +
                                                    $"{{\"number\":3,\"completed\":true,\"collected_at\":\"{COLLECTED_AT.ToTraktLongDateTimeString()}\"}}]");
            }
        }
    }
}

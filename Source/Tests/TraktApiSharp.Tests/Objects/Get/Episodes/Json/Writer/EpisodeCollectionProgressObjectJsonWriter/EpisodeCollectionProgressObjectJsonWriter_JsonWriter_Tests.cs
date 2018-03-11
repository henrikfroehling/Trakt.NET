namespace TraktApiSharp.Tests.Objects.Get.Episodes.Json.Writer
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Extensions;
    using TraktApiSharp.Objects.Get.Episodes;
    using TraktApiSharp.Objects.Get.Episodes.Implementations;
    using TraktApiSharp.Objects.Get.Episodes.Json.Writer;
    using Xunit;

    [Category("Objects.Get.Episodes.JsonWriter")]
    public partial class EpisodeCollectionProgressObjectJsonWriter_Tests
    {
        private static readonly DateTime COLLECTED_AT = DateTime.UtcNow;

        [Fact]
        public void Test_EpisodeCollectionProgressObjectJsonWriter_WriteObject_JsonWriter_Exceptions()
        {
            var traktJsonWriter = new EpisodeCollectionProgressObjectJsonWriter();
            ITraktEpisodeCollectionProgress traktEpisodeCollectionProgress = new TraktEpisodeCollectionProgress();
            Func<Task> action = () => traktJsonWriter.WriteObjectAsync(default(JsonTextWriter), traktEpisodeCollectionProgress);
            action.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_EpisodeCollectionProgressObjectJsonWriter_WriteObject_JsonWriter_Only_Number_Property()
        {
            ITraktEpisodeCollectionProgress traktEpisodeCollectionProgress = new TraktEpisodeCollectionProgress
            {
                Number = 1
            };

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new EpisodeCollectionProgressObjectJsonWriter();
                await traktJsonWriter.WriteObjectAsync(jsonWriter, traktEpisodeCollectionProgress);
                stringWriter.ToString().Should().Be(@"{""number"":1}");
            }
        }

        [Fact]
        public async Task Test_EpisodeCollectionProgressObjectJsonWriter_WriteObject_JsonWriter_Only_Completed_Property()
        {
            ITraktEpisodeCollectionProgress traktEpisodeCollectionProgress = new TraktEpisodeCollectionProgress
            {
                Completed = true
            };

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new EpisodeCollectionProgressObjectJsonWriter();
                await traktJsonWriter.WriteObjectAsync(jsonWriter, traktEpisodeCollectionProgress);
                stringWriter.ToString().Should().Be(@"{""completed"":true}");
            }
        }

        [Fact]
        public async Task Test_EpisodeCollectionProgressObjectJsonWriter_WriteObject_JsonWriter_Only_CollectedAt_Property()
        {
            ITraktEpisodeCollectionProgress traktEpisodeCollectionProgress = new TraktEpisodeCollectionProgress
            {
                CollectedAt = COLLECTED_AT
            };

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new EpisodeCollectionProgressObjectJsonWriter();
                await traktJsonWriter.WriteObjectAsync(jsonWriter, traktEpisodeCollectionProgress);
                stringWriter.ToString().Should().Be($"{{\"collected_at\":\"{COLLECTED_AT.ToTraktLongDateTimeString()}\"}}");
            }
        }

        [Fact]
        public async Task Test_EpisodeCollectionProgressObjectJsonWriter_WriteObject_JsonWriter_Complete()
        {
            ITraktEpisodeCollectionProgress traktEpisodeCollectionProgress = new TraktEpisodeCollectionProgress
            {
                Number = 1,
                Completed = true,
                CollectedAt = COLLECTED_AT
            };

            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var traktJsonWriter = new EpisodeCollectionProgressObjectJsonWriter();
                await traktJsonWriter.WriteObjectAsync(jsonWriter, traktEpisodeCollectionProgress);
                stringWriter.ToString().Should().Be(@"{""number"":1,""completed"":true," +
                                                    $"\"collected_at\":\"{COLLECTED_AT.ToTraktLongDateTimeString()}\"}}");
            }
        }
    }
}

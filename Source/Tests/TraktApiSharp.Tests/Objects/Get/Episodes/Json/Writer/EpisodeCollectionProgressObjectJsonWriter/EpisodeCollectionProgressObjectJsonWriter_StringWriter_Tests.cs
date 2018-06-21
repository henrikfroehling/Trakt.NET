namespace TraktNet.Tests.Objects.Get.Episodes.Json.Writer
{
    using FluentAssertions;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Traits;
    using TraktNet.Extensions;
    using TraktNet.Objects.Get.Episodes;
    using TraktNet.Objects.Get.Episodes.Json.Writer;
    using Xunit;

    [Category("Objects.Get.Episodes.JsonWriter")]
    public partial class EpisodeCollectionProgressObjectJsonWriter_Tests
    {
        [Fact]
        public void Test_EpisodeCollectionProgressObjectJsonWriter_WriteObject_StringWriter_Exceptions()
        {
            var traktJsonWriter = new EpisodeCollectionProgressObjectJsonWriter();
            ITraktEpisodeCollectionProgress traktEpisodeCollectionProgress = new TraktEpisodeCollectionProgress();
            Func<Task<string>> action = () => traktJsonWriter.WriteObjectAsync(default(StringWriter), traktEpisodeCollectionProgress);
            action.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_EpisodeCollectionProgressObjectJsonWriter_WriteObject_StringWriter_Only_Number_Property()
        {
            ITraktEpisodeCollectionProgress traktEpisodeCollectionProgress = new TraktEpisodeCollectionProgress
            {
                Number = 1
            };

            using (var stringWriter = new StringWriter())
            {
                var traktJsonWriter = new EpisodeCollectionProgressObjectJsonWriter();
                string json = await traktJsonWriter.WriteObjectAsync(stringWriter, traktEpisodeCollectionProgress);
                json.Should().Be(@"{""number"":1}");
            }
        }

        [Fact]
        public async Task Test_EpisodeCollectionProgressObjectJsonWriter_WriteObject_StringWriter_Only_Completed_Property()
        {
            ITraktEpisodeCollectionProgress traktEpisodeCollectionProgress = new TraktEpisodeCollectionProgress
            {
                Completed = true
            };

            using (var stringWriter = new StringWriter())
            {
                var traktJsonWriter = new EpisodeCollectionProgressObjectJsonWriter();
                string json = await traktJsonWriter.WriteObjectAsync(stringWriter, traktEpisodeCollectionProgress);
                json.Should().Be(@"{""completed"":true}");
            }
        }

        [Fact]
        public async Task Test_EpisodeCollectionProgressObjectJsonWriter_WriteObject_StringWriter_Only_CollectedAt_Property()
        {
            ITraktEpisodeCollectionProgress traktEpisodeCollectionProgress = new TraktEpisodeCollectionProgress
            {
                CollectedAt = COLLECTED_AT
            };

            using (var stringWriter = new StringWriter())
            {
                var traktJsonWriter = new EpisodeCollectionProgressObjectJsonWriter();
                string json = await traktJsonWriter.WriteObjectAsync(stringWriter, traktEpisodeCollectionProgress);
                json.Should().Be($"{{\"collected_at\":\"{COLLECTED_AT.ToTraktLongDateTimeString()}\"}}");
            }
        }

        [Fact]
        public async Task Test_EpisodeCollectionProgressObjectJsonWriter_WriteObject_StringWriter_Complete()
        {
            ITraktEpisodeCollectionProgress traktEpisodeCollectionProgress = new TraktEpisodeCollectionProgress
            {
                Number = 1,
                Completed = true,
                CollectedAt = COLLECTED_AT
            };

            using (var stringWriter = new StringWriter())
            {
                var traktJsonWriter = new EpisodeCollectionProgressObjectJsonWriter();
                string json = await traktJsonWriter.WriteObjectAsync(stringWriter, traktEpisodeCollectionProgress);
                json.Should().Be(@"{""number"":1,""completed"":true," +
                                 $"\"collected_at\":\"{COLLECTED_AT.ToTraktLongDateTimeString()}\"}}");
            }
        }
    }
}

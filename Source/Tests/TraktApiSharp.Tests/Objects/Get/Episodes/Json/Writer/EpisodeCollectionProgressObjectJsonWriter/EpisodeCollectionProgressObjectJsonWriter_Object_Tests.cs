namespace TraktApiSharp.Tests.Objects.Get.Episodes.Json.Writer
{
    using FluentAssertions;
    using System;
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
        [Fact]
        public void Test_EpisodeCollectionProgressObjectJsonWriter_WriteObject_Object_Exceptions()
        {
            var traktJsonWriter = new EpisodeCollectionProgressObjectJsonWriter();
            Func<Task<string>> action = () => traktJsonWriter.WriteObjectAsync(default(ITraktEpisodeCollectionProgress));
            action.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_EpisodeCollectionProgressObjectJsonWriter_WriteObject_Object_Only_Number_Property()
        {
            ITraktEpisodeCollectionProgress traktEpisodeCollectionProgress = new TraktEpisodeCollectionProgress
            {
                Number = 1
            };

            var traktJsonWriter = new EpisodeCollectionProgressObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktEpisodeCollectionProgress);
            json.Should().Be(@"{""number"":1}");
        }

        [Fact]
        public async Task Test_EpisodeCollectionProgressObjectJsonWriter_WriteObject_Object_Only_Completed_Property()
        {
            ITraktEpisodeCollectionProgress traktEpisodeCollectionProgress = new TraktEpisodeCollectionProgress
            {
                Completed = true
            };

            var traktJsonWriter = new EpisodeCollectionProgressObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktEpisodeCollectionProgress);
            json.Should().Be(@"{""completed"":true}");
        }

        [Fact]
        public async Task Test_EpisodeCollectionProgressObjectJsonWriter_WriteObject_Object_Only_CollectedAt_Property()
        {
            ITraktEpisodeCollectionProgress traktEpisodeCollectionProgress = new TraktEpisodeCollectionProgress
            {
                CollectedAt = COLLECTED_AT
            };

            var traktJsonWriter = new EpisodeCollectionProgressObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktEpisodeCollectionProgress);
            json.Should().Be($"{{\"collected_at\":\"{COLLECTED_AT.ToTraktLongDateTimeString()}\"}}");
        }

        [Fact]
        public async Task Test_EpisodeCollectionProgressObjectJsonWriter_WriteObject_Object_Complete()
        {
            ITraktEpisodeCollectionProgress traktEpisodeCollectionProgress = new TraktEpisodeCollectionProgress
            {
                Number = 1,
                Completed = true,
                CollectedAt = COLLECTED_AT
            };

            var traktJsonWriter = new EpisodeCollectionProgressObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktEpisodeCollectionProgress);
            json.Should().Be(@"{""number"":1,""completed"":true," +
                             $"\"collected_at\":\"{COLLECTED_AT.ToTraktLongDateTimeString()}\"}}");
        }
    }
}

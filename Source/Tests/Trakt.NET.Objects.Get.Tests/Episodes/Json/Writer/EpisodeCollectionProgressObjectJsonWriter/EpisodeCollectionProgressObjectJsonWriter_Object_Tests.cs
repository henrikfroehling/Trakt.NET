namespace TraktNet.Objects.Get.Tests.Episodes.Json.Writer
{
    using FluentAssertions;
    using System;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Extensions;
    using TraktNet.Objects.Get.Episodes;
    using TraktNet.Objects.Get.Episodes.Json.Writer;
    using Xunit;

    [Category("Objects.Get.Episodes.JsonWriter")]
    public partial class EpisodeCollectionProgressObjectJsonWriter_Tests
    {
        [Fact]
        public async Task Test_EpisodeCollectionProgressObjectJsonWriter_WriteObject_Object_Exceptions()
        {
            var traktJsonWriter = new EpisodeCollectionProgressObjectJsonWriter();
            Func<Task<string>> action = () => traktJsonWriter.WriteObjectAsync(default(ITraktEpisodeCollectionProgress));
            await action.Should().ThrowAsync<ArgumentNullException>();
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

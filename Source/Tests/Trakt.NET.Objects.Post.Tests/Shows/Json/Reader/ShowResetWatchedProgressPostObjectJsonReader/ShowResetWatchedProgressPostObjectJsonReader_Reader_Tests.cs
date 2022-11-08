namespace TraktNet.Objects.Post.Tests.Shows.Json.Reader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Post.Shows;
    using TraktNet.Objects.Post.Shows.Json.Reader;
    using Xunit;

    [TestCategory("Objects.Post.Shows.JsonReader")]
    public partial class ShowResetWatchedProgressPostObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_ShowResetWatchedProgressPostObjectJsonReader_ReadObject_From_JsonReader_Complete()
        {
            var traktJsonReader = new ShowResetWatchedProgressPostObjectJsonReader();

            using var reader = new StringReader(JSON_COMPLETE);
            using var jsonReader = new JsonTextReader(reader);
            ITraktShowResetWatchedProgressPost traktShowResetWatchedProgressPost = await traktJsonReader.ReadObjectAsync(jsonReader);

            traktShowResetWatchedProgressPost.Should().NotBeNull();
            traktShowResetWatchedProgressPost.ResetAt.Should().Be(DateTime.Parse("2022-01-23T21:12:25.000Z").ToUniversalTime());
        }

        [Fact]
        public async Task Test_ShowResetWatchedProgressPostObjectJsonReader_ReadObject_From_JsonReader_Null()
        {
            var traktJsonReader = new ShowResetWatchedProgressPostObjectJsonReader();
            Func<Task<ITraktShowResetWatchedProgressPost>> traktShowResetWatchedProgressPost = () => traktJsonReader.ReadObjectAsync(default(JsonTextReader));
            await traktShowResetWatchedProgressPost.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_ShowResetWatchedProgressPostObjectJsonReader_ReadObject_From_JsonReader_Empty()
        {
            var traktJsonReader = new ShowResetWatchedProgressPostObjectJsonReader();

            using var reader = new StringReader(string.Empty);
            using var jsonReader = new JsonTextReader(reader);
            ITraktShowResetWatchedProgressPost traktShowResetWatchedProgressPost = await traktJsonReader.ReadObjectAsync(jsonReader);
            traktShowResetWatchedProgressPost.Should().BeNull();
        }
    }
}

namespace TraktNet.Objects.Post.Tests.Shows.Json.Reader
{
    using FluentAssertions;
    using System;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Post.Shows;
    using TraktNet.Objects.Post.Shows.Json.Reader;
    using Xunit;

    [TestCategory("Objects.Post.Shows.JsonReader")]
    public partial class ShowResetWatchedProgressPostObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_ShowResetWatchedProgressPostObjectJsonReader_ReadObject_From_Json_String_Complete()
        {
            var traktJsonReader = new ShowResetWatchedProgressPostObjectJsonReader();
            ITraktShowResetWatchedProgressPost traktShowResetWatchedProgressPost = await traktJsonReader.ReadObjectAsync(JSON_COMPLETE);

            traktShowResetWatchedProgressPost.Should().NotBeNull();
            traktShowResetWatchedProgressPost.ResetAt.Should().Be(DateTime.Parse("2022-01-23T21:12:25.000Z").ToUniversalTime());
        }

        [Fact]
        public async Task Test_ShowResetWatchedProgressPostObjectJsonReader_ReadObject_From_Json_String_Null()
        {
            var traktJsonReader = new ShowResetWatchedProgressPostObjectJsonReader();
            Func<Task<ITraktShowResetWatchedProgressPost>> traktShowResetWatchedProgressPost = () => traktJsonReader.ReadObjectAsync(default(string));
            await traktShowResetWatchedProgressPost.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_ShowResetWatchedProgressPostObjectJsonReader_ReadObject_From_Json_String_Empty()
        {
            var traktJsonReader = new ShowResetWatchedProgressPostObjectJsonReader();
            ITraktShowResetWatchedProgressPost traktShowResetWatchedProgressPost = await traktJsonReader.ReadObjectAsync(string.Empty);
            traktShowResetWatchedProgressPost.Should().BeNull();
        }
    }
}

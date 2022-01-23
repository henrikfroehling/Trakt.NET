namespace TraktNet.Objects.Post.Tests.Shows.Json.Reader
{
    using FluentAssertions;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Post.Shows;
    using TraktNet.Objects.Post.Shows.Json.Reader;
    using Xunit;

    [Category("Objects.Post.Shows.JsonReader")]
    public partial class ShowResetWatchedProgressPostObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_ShowResetWatchedProgressPostObjectJsonReader_ReadObject_From_Stream_Complete()
        {
            var traktJsonReader = new ShowResetWatchedProgressPostObjectJsonReader();

            using var stream = JSON_COMPLETE.ToStream();
            ITraktShowResetWatchedProgressPost traktShowResetWatchedProgressPost = await traktJsonReader.ReadObjectAsync(stream);

            traktShowResetWatchedProgressPost.Should().NotBeNull();
            traktShowResetWatchedProgressPost.ResetAt.Should().Be(DateTime.Parse("2022-01-23T21:12:25.000Z").ToUniversalTime());
        }

        [Fact]
        public async Task Test_ShowResetWatchedProgressPostObjectJsonReader_ReadObject_From_Stream_Null()
        {
            var traktJsonReader = new ShowResetWatchedProgressPostObjectJsonReader();
            Func<Task<ITraktShowResetWatchedProgressPost>> traktShowResetWatchedProgressPost = () => traktJsonReader.ReadObjectAsync(default(Stream));
            await traktShowResetWatchedProgressPost.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_ShowResetWatchedProgressPostObjectJsonReader_ReadObject_From_Stream_Empty()
        {
            var traktJsonReader = new ShowResetWatchedProgressPostObjectJsonReader();

            using var stream = string.Empty.ToStream();
            ITraktShowResetWatchedProgressPost traktShowResetWatchedProgressPost = await traktJsonReader.ReadObjectAsync(stream);
            traktShowResetWatchedProgressPost.Should().BeNull();
        }
    }
}

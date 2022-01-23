namespace TraktNet.Objects.Post.Tests.Shows.Implementations
{
    using FluentAssertions;
    using System;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Post.Shows;
    using TraktNet.Objects.Post.Shows.Json.Reader;
    using Xunit;

    [Category("Objects.Post.Shows.Implementations")]
    public class TraktShowResetWatchedProgressPost_Tests
    {
        [Fact]
        public void Test_TraktShowResetWatchedProgressPost_Default_Constructor()
        {
            var showResetWatchedProgressPost = new TraktShowResetWatchedProgressPost();
            showResetWatchedProgressPost.ResetAt.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktShowResetWatchedProgressPost_From_Json()
        {
            var jsonReader = new ShowResetWatchedProgressPostObjectJsonReader();
            var showResetWatchedProgressPost = await jsonReader.ReadObjectAsync(JSON) as TraktShowResetWatchedProgressPost;

            showResetWatchedProgressPost.Should().NotBeNull();
            showResetWatchedProgressPost.ResetAt.Should().Be(DateTime.Parse("2022-01-23T21:12:25.000Z").ToUniversalTime());
        }

        private const string JSON =
            @"{
                ""reset_at"": ""2022-01-23T21:12:25.000Z""
              }";
    }
}

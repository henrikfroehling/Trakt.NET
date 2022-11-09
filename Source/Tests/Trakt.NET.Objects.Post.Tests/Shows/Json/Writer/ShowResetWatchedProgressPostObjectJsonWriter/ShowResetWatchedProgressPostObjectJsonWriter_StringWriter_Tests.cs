namespace TraktNet.Objects.Post.Tests.Shows.Json.Writer
{
    using FluentAssertions;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Extensions;
    using TraktNet.Objects.Post.Shows;
    using TraktNet.Objects.Post.Shows.Json.Writer;
    using Xunit;

    [TestCategory("Objects.Post.Shows.JsonWriter")]
    public partial class ShowResetWatchedProgressPostObjectJsonWriter_Tests
    {
        [Fact]
        public async Task Test_ShowResetWatchedProgressPostObjectJsonWriter_WriteObject_StringWriter_Exceptions()
        {
            var traktJsonWriter = new ShowResetWatchedProgressPostObjectJsonWriter();
            ITraktShowResetWatchedProgressPost traktShowResetWatchedProgressPost = new TraktShowResetWatchedProgressPost();
            Func<Task<string>> action = () => traktJsonWriter.WriteObjectAsync(default(StringWriter), traktShowResetWatchedProgressPost);
            await action.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_ShowResetWatchedProgressPostObjectJsonWriter_WriteObject_StringWriter_Complete()
        {
            ITraktShowResetWatchedProgressPost traktShowResetWatchedProgressPost = new TraktShowResetWatchedProgressPost
            {
                ResetAt = RESET_AT
            };

            using var stringWriter = new StringWriter();
            var traktJsonWriter = new ShowResetWatchedProgressPostObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(stringWriter, traktShowResetWatchedProgressPost);
            json.Should().Be($"{{\"reset_at\":\"{RESET_AT.ToTraktLongDateTimeString()}\"}}");
        }
    }
}

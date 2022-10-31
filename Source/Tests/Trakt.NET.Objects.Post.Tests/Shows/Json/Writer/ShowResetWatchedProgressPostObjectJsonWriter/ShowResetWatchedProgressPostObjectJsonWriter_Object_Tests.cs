namespace TraktNet.Objects.Post.Tests.Shows.Json.Writer
{
    using FluentAssertions;
    using System;
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
        public async Task Test_ShowResetWatchedProgressPostObjectJsonWriter_WriteObject_Object_Exceptions()
        {
            var traktJsonWriter = new ShowResetWatchedProgressPostObjectJsonWriter();
            Func<Task<string>> action = () => traktJsonWriter.WriteObjectAsync(default);
            await action.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_ShowResetWatchedProgressPostObjectJsonWriter_WriteObject_Object_Complete()
        {
            ITraktShowResetWatchedProgressPost traktShowResetWatchedProgressPost = new TraktShowResetWatchedProgressPost
            {
                ResetAt = RESET_AT
            };

            var traktJsonWriter = new ShowResetWatchedProgressPostObjectJsonWriter();
            string json = await traktJsonWriter.WriteObjectAsync(traktShowResetWatchedProgressPost);
            json.Should().Be($"{{\"reset_at\":\"{RESET_AT.ToTraktLongDateTimeString()}\"}}");
        }
    }
}

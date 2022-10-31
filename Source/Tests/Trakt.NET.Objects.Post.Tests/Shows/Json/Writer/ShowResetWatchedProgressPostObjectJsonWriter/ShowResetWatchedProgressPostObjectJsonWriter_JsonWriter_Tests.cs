namespace TraktNet.Objects.Post.Tests.Shows.Json.Writer
{
    using FluentAssertions;
    using Newtonsoft.Json;
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
        private readonly DateTime RESET_AT = DateTime.UtcNow;

        [Fact]
        public async Task Test_ShowResetWatchedProgressPostObjectJsonWriter_WriteObject_JsonWriter_Exceptions()
        {
            var traktJsonWriter = new ShowResetWatchedProgressPostObjectJsonWriter();
            ITraktShowResetWatchedProgressPost traktShowResetWatchedProgressPost = new TraktShowResetWatchedProgressPost();
            Func<Task> action = () => traktJsonWriter.WriteObjectAsync(default(JsonTextWriter), traktShowResetWatchedProgressPost);
            await action.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_ShowResetWatchedProgressPostObjectJsonWriter_WriteObject_JsonWriter_Complete()
        {
            ITraktShowResetWatchedProgressPost traktShowResetWatchedProgressPost = new TraktShowResetWatchedProgressPost
            {
                ResetAt = RESET_AT
            };

            using var stringWriter = new StringWriter();
            using var jsonWriter = new JsonTextWriter(stringWriter);
            var traktJsonWriter = new ShowResetWatchedProgressPostObjectJsonWriter();
            await traktJsonWriter.WriteObjectAsync(jsonWriter, traktShowResetWatchedProgressPost);
            stringWriter.ToString().Should().Be($"{{\"reset_at\":\"{RESET_AT.ToTraktLongDateTimeString()}\"}}");
        }
    }
}

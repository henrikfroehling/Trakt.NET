namespace TraktApiSharp.Tests.Objects.Post.Scrobbles.Responses.JsonReader
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.JsonReader;
    using TraktApiSharp.Objects.Post.Scrobbles.Responses;
    using TraktApiSharp.Objects.Post.Scrobbles.Responses.JsonReader;
    using Xunit;

    [Category("Objects.Post.Scrobbles.Responses.JsonReader")]
    public partial class TraktEpisodeScrobblePostResponseObjectJsonReader_Tests
    {
        [Fact]
        public void Test_TraktEpisodeScrobblePostResponseObjectJsonReader_Implements_ITraktObjectJsonReader_Interface()
        {
            typeof(TraktEpisodeScrobblePostResponseObjectJsonReader).GetInterfaces().Should().Contain(typeof(ITraktObjectJsonReader<ITraktEpisodeScrobblePostResponse>));
        }
    }
}

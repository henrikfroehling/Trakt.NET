namespace TraktApiSharp.Tests.Objects.Post.Scrobbles.Responses.JsonReader
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.JsonReader;
    using TraktApiSharp.Objects.Post.Scrobbles.Responses;
    using TraktApiSharp.Objects.Post.Scrobbles.Responses.JsonReader;
    using Xunit;

    [Category("Objects.Post.Scrobbles.Responses.JsonReader")]
    public partial class EpisodeScrobblePostResponseObjectJsonReader_Tests
    {
        [Fact]
        public void Test_EpisodeScrobblePostResponseObjectJsonReader_Implements_IObjectJsonReader_Interface()
        {
            typeof(EpisodeScrobblePostResponseObjectJsonReader).GetInterfaces().Should().Contain(typeof(IObjectJsonReader<ITraktEpisodeScrobblePostResponse>));
        }
    }
}

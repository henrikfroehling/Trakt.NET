namespace TraktApiSharp.Tests.Objects.Post.Checkins.Responses.JsonReader
{
    using FluentAssertions;
    using Traits;
    using TraktApiSharp.Objects.JsonReader;
    using TraktApiSharp.Objects.Post.Checkins.Responses;
    using TraktApiSharp.Objects.Post.Checkins.Responses.JsonReader;
    using Xunit;

    [Category("Objects.Post.Checkins.Responses.JsonReader")]
    public partial class EpisodeCheckinPostResponseObjectJsonReader_Tests
    {
        [Fact]
        public void Test_EpisodeCheckinPostResponseObjectJsonReader_Implements_IObjectJsonReader_Interface()
        {
            typeof(EpisodeCheckinPostResponseObjectJsonReader).GetInterfaces().Should().Contain(typeof(IObjectJsonReader<ITraktEpisodeCheckinPostResponse>));
        }
    }
}
